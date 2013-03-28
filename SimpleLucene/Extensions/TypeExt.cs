using System;

namespace SimpleLucene
{
    /// <summary>
    /// Type extensions
    /// </summary>
    public static class TypeExt {
        public static T To<T>(this string obj) {
            return (T)Convert.ChangeType(obj, typeof(T));
        }
    }
}
