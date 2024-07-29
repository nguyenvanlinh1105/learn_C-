using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_22_csEvent
{
    /*
     *  khai báo sẵn câu trúc delegate để chuyên để khai báo tạo ra các sự kiên
     *  
     */

    class DuLieuNhap: EventArgs
    {
        public int data { set; get; }
        public DuLieuNhap(int x ) { data = x; }
    }
    class UserInput
    {
        public event EventHandler suKienNhapSo;// === delegate voi KIEU(object? sender, EventArgs



        public void input()
        {
            do
            {
                Console.WriteLine("Nhập vào số nguyên dương");
                string s = Console.ReadLine();
                int i = Int32.Parse(s);

                // phát đi sự kiện
                suKienNhapSo?.Invoke(this,new DuLieuNhap(i) );
            } while (true);// nhận ctrl +C để thoát đối tượng 
        }


    }
    class tinhCanBac2
    {
        // đăng kí nhận phương thứ sự kiện nhập số
        public void Sub(UserInput input)
        {
            //input.suKienNhapSo = Can; nếu như khai báo delegate theo kiểu thông thường.
            input.suKienNhapSo += Can;
        }
        public void Can(object sender, EventArgs e)
        {
            DuLieuNhap duLieuNhap = (DuLieuNhap)e;
            int x = duLieuNhap.data;
            Console.WriteLine($"Căn bậc 2 của số {x} là {Math.Sqrt(x)}");
        }
    }
    class tinhBinhPhuong
    {
        public void Sub(UserInput input)
        {
            input.suKienNhapSo += TinhBinhPhuong;
        }
        public void TinhBinhPhuong(object sender,EventArgs e)
        {
            DuLieuNhap duLieuNhap = (DuLieuNhap)e;
            int x = duLieuNhap.data;
            Console.WriteLine($"bình phương của {x} là {Math.Pow(x, 2)}");
        }
    }
    class eventHandle
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding= Encoding.UTF8;
            // bắt sự kiện nhấn ctrl c và gán nó bằng một biểu thức lambda nhận vào đúng 2 tham số sender và e
            Console.CancelKeyPress += (sender, e) => Console.WriteLine("Nhấn ctrl c nhiều hông tốt đâu nha");
            // nếu không ghi object sender, EventArgs e thì nó tự định dạng và hiểu kiểu dữ liệu của mình ở trong biểu thức lamda
            UserInput userInput = new UserInput();
            userInput.suKienNhapSo += (object sender,EventArgs e) =>
            {
                DuLieuNhap duLieuNhap = (DuLieuNhap)e;
                Console.WriteLine("Bạn vừa nhập số " + duLieuNhap.data);
            };
            tinhCanBac2 tinhCan = new tinhCanBac2();
            tinhCan.Sub(userInput); 
            tinhBinhPhuong tinhBinhPhuong = new tinhBinhPhuong();
            tinhBinhPhuong.Sub(userInput);
            userInput.input();
            Console.ReadKey(); 
        }
    }
}
