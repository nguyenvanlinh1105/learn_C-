using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_20_delegate
{
    /* ACTION: delegate mà thư viện dotnet định nghĩa sẵn cho chúng ta 
     * -- không trả về dữ liệu gì : void 
     * 
     */

    class Action
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
        static void Main(string[] args)
        {
           

            Action action;//delegate void Kieu();
            Action<string, int> action1;//delegate void kieu(string s, int i)
            Action<string> log = showInfo;
            log?.Invoke("action nhé không phải gì đâu");
        }
    }
}
