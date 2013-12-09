using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tester.ViewModels
{
    public class Tuple<T1, T2>
    {
        public T1 Item1;
        public T2 Item2;
        private Data.Question question;
        private bool p;

        public Tuple(T1 a, T2 b)
        {
            Item1 = a; Item2 = b;
        }
    }
}
