using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_19_virtual_method_abstract_interface
{
    class Program
    {
        // virtual method : 
        /*
         *  là phương thức được định nghĩa ở trong lớp cơ sở
         *  Có thể được ghi đè bởi lớp kế thừa
         *  ở lớp con muốn định nghĩa lại một phương thức đã có ở lớp cở sở thì ở lớp cơ sở sau từ khóa giới hạn phạm vi truy cập bạn thêm từ khóa " virtual" và ở lớp con thì phải thêm từ khóa override
         *   muốn gọi lại hàm ở lớp cơ sở thì sử dụng từ khóa base để truy cập
         */
        // abstract : dùng làm cơ sở cho các lớp kế thừa, không dùng để tạo ra đối tượng 
        /*
         * để khai báo một lớp hay một phương thức abstract thì ta phải thêm từ khóa abstract vào đầu class và sau từ khóa giới hạn phạm vi nếu nó là phương thức
         * Ở lớp con khi kế thừa lớp cơ sở phải thực hiện các phương thức đã được định nghĩa trong class abstract và phương thức khi định nghĩa phải có từ khóa là override sau từ khóa giới hạn phạm vi truy cập.
         * 
         */
        //interface: không dùng để tạo ra đối tượng chỉ đùng để làm cơ sở cho các lớp kế thừa.
        /*
         * để khai báo lớp interface thì ta thêm từa khóa " interface" trươc class.
         *  class interface chứa các phương thức không có thân và chứa các thuộc tính nhưng không phải là triển khai 
            - Nếu có nhiều hơn 1 giao diện để kế thừa thì ta thực hiện thêm dấu phẩy và ghi cac interface ở phía sau 
         */




        // virtual method
        class Product
        {
            protected double Price { set; get; }
            public virtual void productInfo()
            {
                Console.WriteLine($"gia của sản phẩm là{this.Price}");
            }
        }
        class Iphone : Product
        {
            public Iphone() => Price = 500;
            void Abc()
            {
                Console.WriteLine($"gà lắm ha");
            }

            public void Test()
            {
                productInfo();
            }
            public override void productInfo()
            {
                Console.WriteLine("Nạp chồng phương thức của lớp product  ");
            }
        }

        // abstract
        abstract class sanPham {
                protected double Price { set; get; }
            public void info()
            {
                Console.WriteLine("Giá của sản phẩm là: "+this.Price);
            }
            public abstract void thongTinSP();
            }
        class samSung : sanPham
        {
            public override void thongTinSP()
            {
                Console.WriteLine("Sản phẩm được nhập chính hãng từ trung quốc");
            }
        }

        // interface
        interface IHinhHoc
        {
             double tinhChuVi();
             double tinhDienTich();
        }
        class HinhChuNhat: IHinhHoc
        {
            private double A { set; get; }
            private double B { set; get; }

           public HinhChuNhat(double a, double b)
            {
                this.A = a;
                this.B = b;
            }
            public double tinhChuVi()
            {
                return 2 * (this.A + this.B);
            }

            public double tinhDienTich()
            {
                return this.A * this.B;
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //virtual method
           //   Iphone ip = new Iphone();
          //    ip.Test();


            //abstract
            samSung p = new samSung();
            p.thongTinSP();

            // interface

            IHinhHoc hcn = new HinhChuNhat(2,3);
            Console.WriteLine("Chu vi hình chữ nhật là:"+hcn.tinhChuVi() );
            Console.WriteLine($"Diện tích hình chữ nhật là: {hcn.tinhDienTich()}");

        }
    }
}
