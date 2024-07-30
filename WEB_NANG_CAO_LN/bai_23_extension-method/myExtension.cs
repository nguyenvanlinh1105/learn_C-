using System;

namespace bai_23_extension_method
{
     static class myExtension
    {
        public static double binhPhuong(this double a)
        {
            return a * a;
        }

        public static double canBacHai(this double x)
        {
            return Math.Sqrt(x); // Corrected Math.sqrt to Math.Sqrt
        }
    }
}
