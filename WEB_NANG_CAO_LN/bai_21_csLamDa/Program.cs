using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_21_csLamDa
{
    
    class Program
    {
        /*
         * Lamda - anonymous function : biểu thức vô danh.
         * - nhận tham số đầu vào, trả về kết quả.
         * () => biểu thức
         * (int a, int b)=>{các biểu thức}
         * 
         *  biểu thức lambda có thể được gán cho một cho một biến có kiểu là delegate có cùng tham số và cùng kiểu trả về;
         */
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // cách viết tạo ra một biểu thức lambda
            //(string s) => Console.WriteLine(s);
            //(int a, int b) =>
            //{
            //    int kq = a + b;
            //    return kq;
            //}

            //sử dung biểu thức lambda
            Action < string > action = (string s) => Console.WriteLine(s);
            action?.Invoke("vui vẻ mọi người ơi");
            Action thongbao = () => Console.WriteLine("Xin chào mọi người tôi là Linh");
            thongbao?.Invoke();
            // hoặc có thể khai báo sử dụng như này thi nó vẫn hiểu kiểu tham số nhận vào là gì
            Action<string> welcome = (s) => Console.WriteLine(s);
           // ====
          //  Action<string> welcome = s => Console.WriteLine(s);
          Action <string , int> xinchao= (string s, int i)=> Console.WriteLine($"{s} {i}");
            xinchao?.Invoke("HI hi", 3);

            Func<int, int ,int> tinhTong = (int a, int b)=>  a + b;

            Console.WriteLine($"Tổng của 7 và 8 là {tinhTong?.Invoke(7,8)}");



        }
    }
}
