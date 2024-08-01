using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_30_LINQ
{
    public class product
    {
        public int ID { get; set; }
        public string Name { set; get; }
        public double Price { set; get; }
        public string[] Colors { set; get; }
        public int Brand { set; get; }

        public product(int iD, string name, double price, string[] colors, int brand)
        {
            ID = iD;
            Name = name;
            Price = price;
            Colors = colors;
            Brand = brand;
        }
        public override string ToString()
        {
            return $"{ID,3} {Name,12} {Price,5} {Brand,2} {string.Join(",", Colors)}";
        }
    }
    public class Brand
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public Brand(string name, int id)
        {
            this.Name = name;
            this.ID = id;
        }
    }
    internal class Th_LINQ
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var brands = new List<Brand>()
            {
                new Brand("CTY Linh NGuyễn",1),
                new Brand("CT An Nguyễn", 2),
                new Brand ("Ct Kim Ngân", 3)
            };
            List<product> products = new List<product>()
            {
                new product(1, "Bàn trà", 129, new string[] {"Xám", "Xanh"}, 1),
                new product(2, "Ghế sofa", 199, new string[] {"Đen", "Nâu"}, 2),
                new product(3, "Tủ sách", 199, new string[] {"Trắng", "Gỗ"}, 1),
                new product(4, "Giường ngủ", 499, new string[] {"Xanh", "Trắng"}, 4),
                new product(5, "Tủ quần áo", 399, new string[] {"Gỗ", "Trắng"}, 1)
            };


            // Bài 1: in ra tên sản phẩm, tên thương hiệu có giả tự 300-400 kết quả sắp xếp tăng dần
           var sp= products.Where(p => p.Price >= 100 && p.Price <= 400).OrderByDescending(p=>p.Price)
                .Join(brands,p=>p.Brand, b => b.ID,(sp, th) =>
                {
                    return new
                    {
                        tenSp = sp.Name,
                        tenTH = th.Name,
                        Gia = sp.Price

                    };
                });
            foreach(var p in sp)
            {
                Console.WriteLine($"Tên ={p.tenSp}- Gia={p.Gia}- TenTh={p.tenTH} \n");
            }
        }
    }
}
