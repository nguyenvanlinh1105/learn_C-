using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_30_LINQ
{
    /*
     * 1.Xác định nguồn: form tenPhanTu in IEnumrable
     *   ... where, order by
     * 2. Lấy dữ liệu : Select,group by
     * 
     * 
     * 
     * group by : kết quả trả về là một collection các nhóm. Mỗi nhóm là một IGrouping<TKey, TElement>,
     * trong đó TKey là kiểu của khóa bạn đã sử dụng để nhóm các phần tử và TElement là kiểu của các phần tử trong nhóm.
     */
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
    internal class syntax_LINQ
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

            // Caau truy vấn linq : 
            //lấy ra tên của các sản phẩm : select 
            var kq = from i in products
                         //select i.Name;// select i.Name là duyệt qua tất cả phần tử mà nó duyệt qua là lấy Name 
                     select $"{i.Name}: {i.Price}";
            kq.ToList().ForEach(p => Console.WriteLine(p));// có thể sử dụng như thế này
            var qr = from i in products where i.Price == 199
                     select new
                     {
                         Ten = i.Name,
                         Gia = i.Price,

                     };
            qr.ToList().ForEach(p => Console.WriteLine(p));// có thể sử dụng như thế này
            // from: giá <500 màu: xanh
            var ketQua = from i in products
                         from color in i.Colors
                         where i.Price <= 400 && color == "Xanh" 
                         orderby i.Price
                         
                         select new
                         {
                             Ten = i.Name,
                             Gia = i.Price,
                             Colors = i.Colors
                         };// lấy ra thông tin nào?

            foreach (var item in ketQua)
            {
                Console.Write($"Ten: {item.Ten}, Gia: {item.Gia}-");
                Console.WriteLine(string.Join(",", item.Colors));
            }

            // nhóm sản phẩm theo giá // có thể lưu nó trên một biến tạm rồi thực hiện các hành động trên biến tạm đó
            var kqua = from i in products
                       group i by i.Price;
            kqua.ToList().ForEach(p =>
            {
                Console.WriteLine("KEY "+p.Key);
                foreach (var item in p)
                {
                    Console.WriteLine(item.ToString());
                }
            });


            var ketqua = from i in products
                         group i by i.Price into gr// key === giá trị muốn group 
                         orderby gr.Key
                         // select gr;// gr: chứa tất cả thuộc tính mà nó select 
                         let sl = $"Số lượng là : " + gr.Count()
                         select new
                         {
                             Gia = gr.Key,
                             CacSanPham = gr.ToList(),
                             soLuong = sl
                         };
             Console.WriteLine("--------------------");
            ketqua.ToList().ForEach(i =>
            {
                Console.WriteLine($"Giá ={i.Gia}");
                Console.WriteLine($"Số lượng= {i.soLuong}");
                foreach(var item in i.CacSanPham)
                {
                    Console.WriteLine(item.ToString());
                }
            });

            // kết hợp các nguồn dữ liệu sử dụng join : 
            // liệt kê ra các sản phẩm,hãng , giá.


            var query = from product in products
                        join b in brands on product.Brand equals b.ID
                        select new
                        {
                            Ten = product.Name,
                            Gia = product.Price,
                            ThuongHieu = b.Name
                        };
            query.ToList().ForEach(i =>
            {
                Console.WriteLine(i);
            });

        }
    }
}
