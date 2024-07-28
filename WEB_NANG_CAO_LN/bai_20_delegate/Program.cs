using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_20_delegate
{
    /* DELEGATE(type)
     *  nó được dùng để khai báo tạo ra những biến và biến này có thể tham chiếu đến các phương thứ, có thể được gán bằng các phương thức.
     *   Có thể sử dụng biến kiểu delegate để thi hành các phương thức có trong biến đó
     *   
     *   để khai báo ra một delegate thì ta khai báo nó trong namespace, hoặc khai báo trực tiếp trong lớp
     *   khai báo delegate giống như khai báo tạo ra một phương thức mà nó không có thân hàm.
     *    delegate có thể tham chiếu đến các phương thức nhưng phương thức đó phải có kiểu trả về và tham số giống như định nghĩa delegate
     *    delegate có thể tham chiếu đến nhiều phương thức sử dụng băng toán tử +=
     *   
     */
    public delegate void showLog(string mgs);
    
    class Program
    {
        public static void showInfo(string mgs)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(mgs);
            Console.ResetColor();
        }
        public static void warning (string mgs)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mgs);
            Console.ResetColor();
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // sử dụng delegate : sau khi khai báo biến delegate thì ta gán trực tiếp tên phương thức như là một biến bthuong
            showLog log = null;
             log = showInfo;
            // cách sử dụng delegate: cớ thể chạy như này 
            log("cớ thể chạy như này ");
            //showInfo();// muốn sử dụng được như này thì phải thêm static vào để không cần phải khởi tạo lớp class; program  
            // cách sử dụng delegate: hoặc có thể chạy như này
            log.Invoke("Chạy như này cũng thành công nhé");
            // kiểm tra log khác null
            log?.Invoke("Kiểm tra khác null rồi nhe");


            log = warning;
            log?.Invoke("Cảnh bảo nha");


            // có thể gán nhiều phương thức cho một delegate bằng toán tử += 

            log += showInfo;
            log += warning;
            log?.Invoke("Thông báo mới dành cho bạn nè");
        }
    }
}
