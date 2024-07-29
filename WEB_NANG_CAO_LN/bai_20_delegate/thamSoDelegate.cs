using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_20_delegate
{
    public delegate void showLog(string mgs);
    // dùng delegate làm tham số cho phương thức 
    class thamSoDelegate
    {
        public static void showInfo(string mgs)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(mgs);
            Console.ResetColor();
        }
        public static void warning(string mgs)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mgs);
            Console.ResetColor();
        }
        static void Tong(int a, int b,showLog log)
        {
            int kq = a + b;
            log?.Invoke($"Tổng là {kq}");
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            showLog log = showInfo;
            Tong(4, 3, log);// sử dụng như này
            Tong(2, 1, warning);// sử dụng như này;
        }
    }
}
