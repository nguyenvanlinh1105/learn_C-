using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_21_csLamDa
{
    internal class lamba_dotnet
    {
       static void Main(string[] args)
        {
            int[] mang = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, };
            var kq =mang.Select(x => Math.Sqrt(x));// trả về giá trị mà nó return ;
            foreach (var i in kq)
            {
                Console.WriteLine(i);
            }

            // biến mảng thành một list dùng foreach để duyệt qua danh sách.
            mang.ToList().ForEach(x => Console.WriteLine(x));

        }
    }
}
