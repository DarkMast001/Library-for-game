using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.tvOS;

namespace MillitaryShipConvoy
{
    public struct Pair<T, V>
    {
        private T key;
        private V value;

        public Pair(T key, V value)
        {
            this.key = key;
            this.value = value;
        }

        public static Pair<T, V> makePair(T key, V value)
        {
            Pair<T, V> pair = new Pair<T, V>(key, value);
            return pair;
        }

        public T Key
        {
            get => key;
            set => key = value;
        }

        public V Value
        {
            get => value;
            set => this.value = value;
        }
    }

    public class ModDictionary<T, V>
    {
        private List<Pair<T, V>> pairs;

        private int count;

        public ModDictionary()
        {
            pairs = new List<Pair<T, V>>();
            count = 0;
        }

        public void Add(T key, V value)
        {
            Pair<T, V> pair = Pair<T, V>.makePair(key, value);
            pairs.Add(pair);
            count++;
        }

        public bool ContainsKey(in T key)
        {
            if (key == null)
                return false;
            for(int i = 0; i < count; i++)
            {
                if (key.Equals(pairs[i].Key))
                    return true;
            }
            return false;
        }

        public bool ContainsValue(in V value)
        {
            if (value == null)
                return false;
            for (int i = 0; i < count; i++)
            {
                if (value.Equals(pairs[i].Value))
                    return true;
            }
            return false;
        }

        public List<V> getValuesByKey(in T key)
        {
            List<V> list = new List<V>();
            if (key == null)
                return list;
            for(int i = 0; i < count; i++)
            {
                if (key.Equals(pairs[i].Key))
                {
                    list.Add(pairs[i].Value);
                }
            }
            return list;
        }

        public bool Remove(in T key)
        {
            if (key == null)
                return false;
            for(int i = 0; i < count; i++)
            {
                if (key.Equals(pairs[i].Key)) 
                {
                    pairs.RemoveAt(i);
                    count--;
                    return true;
                }
            }
            return false;
        }

        public bool Remove(in T key, out V? value)
        {
            if (key == null)
            {
                value = default(V);
                return false;
            }
            for(int i = 0; i < count; i++)
            {
                if (key.Equals(pairs[i].Key))
                {
                    value = pairs[i].Value;
                    pairs.RemoveAt(i);
                    count--;
                    return true;
                }
            }
            value = default(V);
            return false;
        }

        public bool RemoveAll(in T key)
        {
            bool flag = false;
            if (key == null)
                return false;
            for (int i = 0; i < count; i++)
            {
                if (key.Equals(pairs[i].Key))
                {
                    pairs.RemoveAt(i);
                    count--;
                    flag = true;
                }
            }
            return flag;
        }

        public bool RevomeAll(in T key, out List<V>? values)
        {
            bool flag = false;
            List<V> val = new List<V>();
            if (key == null)
            {
                values = null;
                return false;
            }
            for (int i = 0; i < count; i++)
            {
                if (key.Equals(pairs[i].Key))
                {
                    val.Add(pairs[i].Value);
                    pairs.RemoveAt(i);
                    count--;
                    flag = true;
                }
            }
            values = val;
            return flag;
        }

        public void Clear()
        {
            pairs.Clear();
            count = 0;
        }

        public IEnumerator<Pair<T, V>> GetEnumerator()
        {
            for(int i = 0; i < count; i++)
            {
                yield return pairs[i];
            }
        }

        public int Count { get => count; }

        public Pair<T, V> this[int index]
        {
            get => pairs[index];
            set => pairs[index] = value;
        }
    }
}
