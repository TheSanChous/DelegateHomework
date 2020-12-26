using System;
using System.Collections.Generic;

namespace Interfaces
{   
    class Program
    {
        static void Main(string[] args)
        {
            var inputList = new LinkedList<string>(new string[]{ "1", "2", "0", "3" });

            var resultList = Map<string, int>(inputList, int.Parse);

            ForEach<string>(inputList, Console.WriteLine);

            var allLengthIsOne = All<string>(inputList, (string a) => a.Length == 1);
            Console.WriteLine(allLengthIsOne);
        }

        static IEnumerable<TOutput> Map<TInput, TOutput>(IEnumerable<TInput> toMap, Func<TInput, TOutput> function)
        {
            if (function == null) throw new ArgumentNullException("Map function is not declared");

            var list = new LinkedList<TOutput>();

            foreach (var item in toMap)
            {
                list.AddLast(function(item));
            }

            return list;
        }

        static bool All<T>(IEnumerable<T> list, Func<T, bool> func)
        {
            if (func == null) throw new ArgumentNullException("Function is not declared");

            foreach (var item in list)
            {
                if (!func(item))
                {
                    return false;
                }
            }
            return true;
        }

        static void ForEach<T>(IEnumerable<T> list, Action<T> func)
        {
            if (func == null) throw new ArgumentNullException("Function is not declared");

            foreach (var item in list)
            {
                func(item);
            }
        }
    }
}
