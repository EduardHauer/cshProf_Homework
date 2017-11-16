using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework3
{
    class Homework
    {
        public static void A()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
            {"four",4 },
            {"two",2 },
            { "one",1 },
            {"three",3 },
            };

            var d = dict.OrderBy((pair) => { return pair.Value; });

            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
        }
        public static void B()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
            {"four",4 },
            {"two",2 },
            { "one",1 },
            {"three",3 },
            };

            Func<KeyValuePair<string, int>, int> func;            func = delegate (KeyValuePair<string, int> pair) { return pair.Value; };

            var d = dict.OrderBy(func);

            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
        }
    }
}
