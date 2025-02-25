using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillitaryShipConvoy
{
    /// <summary>
    /// Класс итератор для таблицы Table
    /// 
    /// Пример использования:\n
    /// <code>
    /// Table<Ship> table = new Table<Ship>();\n
    /// ...\n
    /// Iterator<Ship> it = new Iterator<Ship>(table);\n
    /// 
    /// for (it = it.begin(); !it.isEnd(); it++)\n
    /// {\n
    ///     if (it.get() is not null)\n
    ///         Console.WriteLine(it.get().ShipName); \n
    /// }\n
    /// </code>
    /// </summary>
    /// <typeparam name="T">Тип итератора (должен совпадать с типом таблицы)</typeparam>
public class Iterator<T>
    {
        private Table<T> table;
        private int index;

        /// <summary>
        /// Инициализирующий конструктор
        /// </summary>
        /// <param name="table">Созданная ранее таблица</param>
        public Iterator(Table<T> table)
        {
            this.table = table;
            index = 0;
        }

        /// <summary>
        /// Функция возврата нулевого элемента таблицы
        /// </summary>
        /// <returns>Нулевой элемент таблицы</returns>
        public T? first()
        {
            return table[0];
        }

        /// <summary>
        /// Функция возврата последнего элемента таблицы
        /// </summary>
        /// <returns>Последний элемент таблицы</returns>
        public T? last()
        {
            return table[table.Count - 1];
        }

        /// <summary>
        /// Функция возвращает тот элемент, на который указывает итератор
        /// </summary>
        /// <returns>Элемент таблицы, на который указывает итератор. Если указатель находится за пределами массива, то вернёт null</returns>
        public T? get()
        {
            if (index < table.Count)
                return table[index];
            return default(T);
        }

        /// <summary>
        /// Ставит указатель итератора на нулевой элемент таблицы
        /// </summary>
        /// <returns>Этот же итератор</returns>
        public Iterator<T> begin() 
        {
            index = 0;
            return this;
        }

        /// <summary>
        /// Функция проверяет дошёл ли курсор итератора до последнего элемента таблицы
        /// </summary>
        /// <returns><c>true</c> если дошёл до конца таблицы, иначе <c>false</c></returns>
        public bool isEnd() => !(index != table.Count);

        /// <summary>
        /// Перегруженный оператор ++ для итератора
        /// 
        /// Перемещает курсор итератора на следующий элемент таблицы
        /// </summary>
        /// <param name="it">Текущий итератор</param>
        /// <returns>Текущий итератор</returns>
        public static Iterator<T> operator ++(Iterator<T> it)
        {
            it.index++;
            return it;
        }
    }
}
