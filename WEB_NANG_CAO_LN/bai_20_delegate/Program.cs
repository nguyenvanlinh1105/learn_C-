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
     *   
     *   
     */
    public delegate void showLog(string mgs);
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
