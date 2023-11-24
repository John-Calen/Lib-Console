using Base.Extensions;
using System.Collections;

namespace JC.Lib.Console.Query
{
    public class Storage<T_Key>: IEnumerable<KeyValuePair<T_Key, object?>>
        where T_Key : Enum
    {
        private readonly Dictionary<T_Key, object?> dictionary = new();





        internal Storage() { }

        internal Storage(IReadOnlyDictionary<T_Key, object> values)
        {
            foreach (var pair in values)
                dictionary.Add(pair.Key, pair.Value);
        }





        public bool TryAdd<T_Value>(T_Key key, T_Value value)
        {
            var attr = key.GetAttribute<ConsoleKeyAttribute>();
            if (attr?.List == true)
            {
                if (dictionary.TryGetValue(key, out var list))
                    ((List<T_Value>)list!).Add(value);

                else
                {
                    list = new List<T_Value>() { value };
                    dictionary.Add(key, list);
                }

                return true;
            }

            else
                return dictionary.TryAdd(key, value);
        }

        public void Set<T_Value>(T_Key key, T_Value value)
        {
            if (dictionary.ContainsKey(key))
                dictionary[key] = value;

            else
                dictionary.Add(key, value);
        }

        public void Remove(T_Key key)
        {
            dictionary.Remove(key);
        }

        public T_Value? Get<T_Value>(T_Key key)
        {
            return (T_Value?) dictionary[key];
        }

        public void Clear()
        {
            dictionary.Clear();
        }

        public IEnumerator<KeyValuePair<T_Key, object?>> GetEnumerator()
        {
            return dictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
