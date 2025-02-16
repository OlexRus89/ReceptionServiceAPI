using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using CryptoCore.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;
using Npgsql;

namespace CryptoCore.DB
{
    public class Concrete
    {
        internal string? ConnectionString { get; set; }
        internal DbProviderFactory? Factory { get; set; }
        protected StartupModel? Startup { get; private set; }
        protected string SqlName { get; set; }
        public Concrete(string name, StartupModel startup) 
        {
            Startup = startup;
            SqlName = ((Startup.AppSetting.ConnectionStrings) ?? []).Where(a => a.Name == name).First().SQLName.ToUpper();
            if (SqlName == "PostgreSQL".ToUpper())
            {
                this.ConnectionString = ((Startup.AppSetting.ConnectionStrings) ?? []).Where(a => a.Name == name).First().ConnectionString;
            }

            if (SqlName == "MSSQL".ToUpper())
            {
                this.ConnectionString = (Startup.AppSetting.ConnectionStrings ?? []).Where(a => a.Name == name).First().ConnectionString;
                DbProviderFactories.RegisterFactory((Startup.AppSetting.ConnectionStrings ?? []).Where(a => a.Name == name).First().ProviderName ?? "", SqlClientFactory.Instance);
                this.Factory = DbProviderFactories.GetFactory((Startup.AppSetting.ConnectionStrings ?? []).Where(a => a.Name == name).First().ProviderName ?? "");
            }
        }

        /// <summary>
        /// Выполнения запроса с количественными данными
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="SQL"></param>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns>Возврат список данных</returns>
        public async Task<IEnumerable<T?>> ExecQuery<T>(string SQL, object? obj = null, CommandType type = CommandType.StoredProcedure, int TimeOut = 360)
        {
            using (var cnt = SqlName == "PostgreSQL".ToUpper() ? OpenConnectionAsyncPostgre() : OpenConnectionAsync())
            {
                return await cnt.QueryAsync<T?>(
                        sql: SQL,
                        param: obj,
                        commandTimeout: TimeOut,
                        commandType: type
                    );
            }
        }

        /// <summary>
        /// Выполнения запроса в единственном значении
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="SQL"></param>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns>Возвращает одно значение или не сущуствующее</returns>
        public async Task<T?> ExecFirstOfDefault<T>(string SQL, object? obj = null, CommandType type = CommandType.StoredProcedure, int TimeOut = 360)
        {
            using (var cnt = SqlName == "PostgreSQL".ToUpper() ? OpenConnectionAsyncPostgre() : OpenConnectionAsync())
            {
                return await cnt.QueryFirstOrDefaultAsync<T>(
                    sql: SQL,
                    param: obj,
                    commandTimeout: TimeOut,
                    commandType: type
                );
            }
        }

        /// <summary>
        /// Выполнения обычного запроса (рекомендуется для внесения, редактирования или удаления данных)
        /// </summary>
        /// <param name="SQL"></param>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns>Ничего, обычный запрос</returns>
        public async Task Exec(string SQL, object? obj = null, CommandType type = CommandType.StoredProcedure, int TimeOut = 360)
        {
            using (var cnt = SqlName == "PostgreSQL".ToUpper() ? OpenConnectionAsyncPostgre() : OpenConnectionAsync())
            {
                await cnt.ExecuteAsync(
                    sql: SQL,
                    param: obj,
                    commandTimeout: TimeOut,
                    commandType: type
                );
            }
        }

        public async Task<TOut?> ExecMultiple<TOut>(string SQL, Func<SqlMapper.GridReader, TOut> func, object? obj = null, CommandType type = CommandType.StoredProcedure, int TimeOut = 360)
        {
            SqlMapper.GridReader reader;
            using (var cnt = SqlName == "PostgreSQL".ToUpper() ? OpenConnectionAsyncPostgre() : OpenConnectionAsync())
            {
                var data = await cnt.QueryMultipleAsync(
                    sql: SQL,
                    param: obj,
                    commandTimeout: TimeOut,
                    commandType: type
                );
                return func(data);
            }
        }

        private async Task UseConnection(Action<DbConnection> action)
        {
            using (DbConnection conn = await CreateConnection()) action(conn);
        }
        public DbConnection OpenConnectionAsync()
        {
            DbConnection cnt = Factory.CreateConnection();
            cnt.ConnectionString = ConnectionString;
            cnt.Open();
            return cnt;
        }
        private async Task<DbConnection> CreateConnection()
        {
            DbConnection cnt = Factory.CreateConnection();
            cnt.ConnectionString = ConnectionString;
            await cnt.OpenAsync();
            return cnt;
        }

        private NpgsqlConnection OpenConnectionAsyncPostgre()
        {
            NpgsqlConnection connection = new NpgsqlConnection();
            connection.ConnectionString = ConnectionString;
            connection.Open();
            return connection;
        }

        private NpgsqlCommand OpenConnectionCommand(string SQL, object? obj = null, CommandType type = CommandType.StoredProcedure, int TimeOut = 360)
        {
            using (var cnt = OpenConnectionAsyncPostgre())
            {
                NpgsqlCommand cmd = new NpgsqlCommand(SQL, cnt);
                cmd.CommandTimeout = TimeOut;
                cmd.CommandType = type;
                // FIX: Исправить на нормальные данные
                cmd.Parameters.AddWithValue("", obj);
                return cmd;
            }
        }
    }
}