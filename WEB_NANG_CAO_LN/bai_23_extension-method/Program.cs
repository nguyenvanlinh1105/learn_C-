using static bai_23_extension_method.myExtension;
namespace bai_23_extension_method
{

    static class Abc
    {
        // phương thức muốn mở rộng cho đối tượng của lớp nào thì tham số đầu tiên phải là đối tượng của lớp đó
       public static void Print(this string s, ConsoleColor color)
        {
            Console.ForegroundColor = color; 
            //Console.WriteLine(s);
        }
    }
    internal class Program
    {
        /* extension method: 
         * - mở rọng chức năng  của các thư viên lớp mà không cần tạo ra các lớp mới kế thừa từ lớp có sẵn
         * - việc mở rộng này không pải tạo ra một lớp mới mà nó cho thêm phương thức vào lớp đang có sẵn
         * để tạo ra phương thức mở rộng thì ta phải tạo nó trong class tĩnh
         * 
         */
        //static void Print (string s, ConsoleColor color)
        //{
        //    Console.ForegroundColor = color;
        //    Console.WriteLine(s);
        //}


        static void Main(string[] args)
        {
            string s = "Xin chào các bn";
            //Print(s, ConsoleColor.Red);
            s.Print(ConsoleColor.Green);
            "xin".Print(ConsoleColor.Yellow);
            Console.ResetColor();
            double a = 4.5;
            double kq = a.binhPhuong();
            Console.WriteLine(  kq);
        }
    }
}
