using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_20_delegate
{
    // sử dụng Func như sử dụng Action 
    // điểm khác biệt là phải có giá trị trả về  tham số cuối cùng là kiểu trả về 

    class Func
    {
        public static void showInfo(string mgs)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(mgs);
            Console.ResetColor();
        }
        public static string TinhTong()
        {
            Console.WriteLine("vui he");
            return "linh nguyễn";
        }
        public static int Tong(int a, int b)
        {
            return a + b;
        }
        static void Main(string [] args)
        {
            Func<int, int , int> ham;// static int ham() {return string}
            Func<string> ham1 = TinhTong;
            Func<string, double, string> bien3;// static string ham(string s, double d){ return string}
            ham1?.Invoke();
            ham = Tong;
            Console.WriteLine($"tong của a và b là {ham?.Invoke(4, 5)}") ;

        }
    }
}
