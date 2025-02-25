using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Reflection;

namespace MillitaryShipConvoy
{
    /// <summary>
    /// Шаблонный класс, описывающий таблицу
    /// 
    /// В таблице будут хранится все купленные корабли. Таблица реализована на основе двухсвязного списка
    /// </summary>
    /// <typeparam name="T">Тип корабля</typeparam>
    public class Table<T> // where T : Ship
    {
        private class Node
        {
            public T Data { get; set; }
            public Node? Next { get; set; }
            public Node? Prev { get; set; }

            public Node(T data)
            {
                Data = data;
                Next = null;
                Prev = null;
            }
        }

        private Node? head;
        private Node? tail;
        private int count;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Table()
        {
            head = null;
            tail = null;
            count = 0;
        }

        /// <summary>
        /// Получить число элементов в таблице
        /// </summary>
        public int Count {  get => count; }

        /// <summary>
        /// Положить элемент в конец таблицы
        /// </summary>
        /// <param name="item">Элемент типа Т</param>
        public void pushBack(in T item)
        {
            Node newNode = new Node(item);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }

            count++;
        }

        /// <summary>
        /// Удалить последний элемент таблицы
        /// </summary>
        public void popBack()
        {
            if (tail == null)
                return;
            remove(tail.Data);
        }

        /// <summary>
        /// Положить элемент в начало таблицы
        /// </summary>
        /// <param name="item">Элемент типа Т</param>
        public void pushFront(in T item)
        {
            Node newNode = new Node(item);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                head.Prev = newNode;
                newNode.Next = head;
                head = newNode;
            }

            count++;
        }

        /// <summary>
        /// Удалить первый элемент таблицы
        /// </summary>
        public void popFront()
        {
            if (head == null)
                return;
            remove(head.Data);
        }
        
        /// <summary>
        /// Вставить элемент в таблицу по индексу
        /// </summary>
        /// <param name="item">Элемент</param>
        /// <param name="index">Индекс</param>
        /// <exception cref="IndexOutOfRangeException">Если индекс < 0 или больше текущей размерности таблицы</exception>
        public void insert(in T item, int index)
        {
            if (index < 0 || index > count)
                throw new IndexOutOfRangeException();
            if (index == 0)
            {
                pushFront(item);
                return;
            }
            else if (index == count)
            {
                pushBack(item);
                return;
            }
            Node? currentNode = head;
            Node newNode = new Node(item);
            int _index = 0;
            while(currentNode != null)
            {
                if (_index == index)
                {
                    newNode.Next = currentNode;
                    newNode.Prev = currentNode.Prev;
                    currentNode.Prev.Next = newNode;
                    currentNode.Prev = newNode;
                    count++;
                    return;
                }
                _index++;
                currentNode = currentNode.Next;
            }
        }

        /// <summary>
        /// Удаление элемента по элементу
        /// </summary>
        /// <param name="item">Элемент, который надо удалить</param>
        public void remove(in T item)
        {
            Node? currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.Data.Equals(item))
                {
                    if (currentNode.Prev != null)
                        currentNode.Prev.Next = currentNode.Next;
                    else
                        head = currentNode.Next;

                    if (currentNode.Next != null)
                        currentNode.Next.Prev = currentNode.Prev;
                    else
                        tail = currentNode.Prev;

                    count--;
                    return;
                }

                currentNode = currentNode.Next;
            }
        }

        /// <summary>
        /// Поиск корабля по его позывному
        /// </summary>
        /// <param name="name">Позывной корабля</param>
        /// <returns>Элемент таблицы, если такой был найден, иначе <c>null</c></returns>
        public T? find(string name)
        {
            Node? currentNode = head;
            while(currentNode != null)
            {
                if (currentNode.Data is Ship ship)
                {
                    if (ship.ShipName == name)
                        return currentNode.Data;
                }
                currentNode = currentNode.Next;
            }
            return default(T);
        }

        /// <summary>
        /// Перегруженный оператор <c>[ ]</c>
        /// </summary>
        /// <param name="index">Индекс</param>
        /// <returns>Элемент под индексом index</returns>
        /// <exception cref="IndexOutOfRangeException">Если попытаться положить элемент в таблицу по недопустимому индексу </exception>
        public T? this[int index]
        {
            get 
            {
                int _index = 0;
                Node? currentNode = head;
                while (currentNode != null)
                {
                    if (index == _index)
                        return currentNode.Data;
                    currentNode = currentNode.Next;
                    _index++;
                }
                return default(T);
            }
            set 
            {
                if (index < 0 || index > count)
                    throw new IndexOutOfRangeException();
                int _index = 0;
                Node? currentNode = head;
                while (currentNode != null)
                {
                    if (index == _index)
                        currentNode.Data = value;
                    currentNode = currentNode.Next;
                    _index++;
                }
            }
        }
    }
}
