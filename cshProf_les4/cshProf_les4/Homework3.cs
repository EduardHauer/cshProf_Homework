using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework3
{
    class H3
    {
        public static void A()
        {
            // Из мегодички
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
            {"four",4 },
            {"two",2 },
            { "one",1 },
            {"three",3 },
            };
            // ---

            // Сокращеная версия > var d = dict.OrderBy(delegate(KeyValuePair<string,int> pair) { return pair.Value; });
            var d = dict.OrderBy((pair) => { return pair.Value; });
            // ---

            // Из методички
            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }            // ---
        }
        public static void B()
        {
            // Из мегодички
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
            {"four",4 },
            {"two",2 },
            { "one",1 },
            {"three",3 },
            };
            // ---

            // Версия с использованием Func
            Func<KeyValuePair<string, int>, int> func;            func = delegate (KeyValuePair<string, int> pair) { return pair.Value; };

            var d = dict.OrderBy(func);
            // ---

            // Из мегодички
            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
            // ---
        }
    }
}
