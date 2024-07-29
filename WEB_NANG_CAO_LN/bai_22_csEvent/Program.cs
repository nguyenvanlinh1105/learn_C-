using System.Text;

namespace bai_22_csEvent
{
    internal class Program
    {
        /*
         * publisher: lớp phát đi những sự kiện.
         * subcriber: lớp đăng kí những sự kiện.
         */
        delegate void suKienNhapSo(int x);
        // publisher
        class UserInput
        {
            // public  suKienNhapSo suKienNhapSo { set; get; }// như này thì ta có thể set hoạc get dữ liệu của thuộc tính
            public event  suKienNhapSo suKienNhapSo;// sau khi thêm sự kiện event vào thì ta không thể set hoặc get mà ta phải thực hiện với toán tự += hoặc -=
            public void input()
            {
                do
                {
                    Console.WriteLine("Nhập vào số nguyên dương");
                    string s = Console.ReadLine();
                    int i = Int32.Parse(s);

                    // phát đi sự kiện
                    suKienNhapSo?.Invoke(i);
                } while (true);// nhận ctrl +C để thoát đối tượng 
            }
                
        }
        // class subcriber
        class tinhCanBac2
        {
            // đăng kí nhận phương thứ sự kiện nhập số
            public void Sub(UserInput input)
            {
                //input.suKienNhapSo = Can; nếu như khai báo delegate theo kiểu thông thường.
                input.suKienNhapSo += Can;
            }
            public void Can(int x)
            {
                Console.WriteLine($"Căn bậc 2 của số {x} là {Math.Sqrt(x)}");
            }
        }
        class tinhBinhPhuong
        {
            public void Sub(UserInput input)
            {
                input.suKienNhapSo += TinhBinhPhuong;
            }
            public void TinhBinhPhuong(int x)
            {
                Console.WriteLine($"bình phương của {x} là {Math.Pow(x, 2)}");
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            UserInput userInput = new UserInput();
            tinhCanBac2 tinhCan = new tinhCanBac2();
            tinhCan.Sub(userInput);

            tinhBinhPhuong tinhBinhPhuong = new tinhBinhPhuong(); 
            tinhBinhPhuong.Sub(userInput);

            // delegate có thể gán bằng một biểu thức lambda 
            userInput.suKienNhapSo += (int x) => Console.WriteLine($"bạn vừa nhập số{x}"); ;
            // để đăng kí nhiều sự kiện thì ta thực hiện khai báo biến delegate thì ta thêm từ khóa event
            userInput.input();
        }
    }
}
