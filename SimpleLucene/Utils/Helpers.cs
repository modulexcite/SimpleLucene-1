using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace SimpleLucene.Utils
{
    public class Helpers {
        public static long TimeFunction(Action action) {
            var sw = new Stopwatch();
            sw.Start();
            action.Invoke();
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        public static void EnsureNotNull(object obj, string arg) {
            if (obj == null)
                throw new ArgumentNullException(arg);
        }
    }
}
