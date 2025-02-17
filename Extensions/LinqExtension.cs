using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCore.Extensions
{
    public static class LinqExtension
    {
        /// <summary>
        /// Выполнить действие ко всем переменным перечисления
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="values">Исходное перечисление</param>
        /// <param name="action">Действие</param>
        public static IEnumerable<TValue> ForEach<TValue>(this IEnumerable<TValue> values, Action<TValue> action)
        {
            foreach (TValue val in values)
            {
                action(val);
            }

            return values;
        }
    }
}