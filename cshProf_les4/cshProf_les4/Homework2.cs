using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework2
{
    class H2
    {
        public static void A(List<int> list, int c)
        {
            int value = 0;

            for (int i = 0; i < list.Count(); i++)
            {
                if (list[i] == c)
                {
                    value++;
                }
            }

            Console.WriteLine($"{value} Value");
        }
    }
}
