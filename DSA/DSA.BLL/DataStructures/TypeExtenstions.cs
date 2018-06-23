using System;

namespace DSA.BLL.DataStructures
{
    public static class TypeExtenstions
    {
        public static string GetCleanTypeName(this Type type)
        {
            var str = type.Name;
            var res = "";
            foreach (var c in str)
                if (char.IsLetter(c))
                {
                    if (char.IsUpper(c))
                        res += " ";
                    res += c;
                }

            res = res.Trim();

            return res;
        }
    }
}