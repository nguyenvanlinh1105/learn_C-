using System.Text;

namespace bai_28_LINQ
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
            return $"{ID,3} {Name,12} {Price, 5} {Brand,2} {string.Join(",", Colors)}";
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
    internal class Program
    {
        /* LINQ (Language Integrated Query) : Ngôn ngữ truy vấn tích hợp
         * Thực hiện trên nguồn dữ liệu IEnumerable, INumerable<T> (Array, List, Stack, Queue
         * 
         * XML, SQL server, mysql.
         * 
         * 
         * 
         * Các phương thức thường sử dụng 
         * Phương thức SelectMany trong C# được sử dụng để chiếu và làm phẳng các tập hợp con từ mỗi phần tử của một tập hợp. Nó rất hữu ích khi bạn làm việc với các tập hợp có cấu trúc lồng nhau và bạn muốn tạo một tập hợp phẳng từ các tập hợp con.
         * 
         */



        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            product pro = new product(1, "Abc",199, new string[] { "Xanh", "Do" },1);
            Console.WriteLine(pro.ToString());
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

            var query = from p in products
                        where p.Price>0  select p;
            foreach (product p in query)
            {
                Console.WriteLine(p.ToString());
            }
            // select : value
            var sanPHam = products.Select(p => p.Name).ToList();
            foreach(var p in sanPHam)
            {

            Console.WriteLine(p.ToString()); }

            // where: true false
            var SP = products.Select(
                (p) => p.Name.Contains("T") || p.Price>100
                );
            foreach (var p in SP)
            {
                Console.WriteLine(p.ToString() );
            }
            int[] mang = new int[] { 1, 2, 3, 4, 5 };
            // MIn / Max/ SUM/ Average
            Console.WriteLine(mang.Min());
            Console.WriteLine(mang.Max());
            Console.WriteLine(mang.Average());
            // JOIN : nối dữ liệu 
            var joins = products.Join(brands,p=> p.Brand, b => b.ID, (p, b) =>
            {
                return new
                {
                    Ten = p.Name,
                    thuongHieu = b.Name
                };
            });
            foreach (var p in joins)
            {
                Console.WriteLine(p.ToString());
            }
            // GroupJoin : hoạt động == join = > kết quả trả về là một nhóm, nhóm lại theo nguồn ban đầu 
            var groupJoin = brands.GroupJoin(products, b => b.ID, p => p.Brand,
                (b, ps) =>{
                return new
                {
                    TenThuongHieu = b.Name,
                    CacSanPham = ps
                };
            });

            foreach(var p in groupJoin)
            {
                Console.WriteLine(p.TenThuongHieu);
                foreach(var i in p.CacSanPham)
                {
                    Console.WriteLine(i.ToString());
                }
            }
            // Take lấy ra một số sản phẩm đầu tiên Take(số pần tử cần lấy) 
            var soSP = products.Take(3);
            foreach( var p in soSP)
            {
                Console.WriteLine(p.ToString());
            }
            // Skip : bỏ đi những phần tử đầu tiên và lấy ra những phần tử còn lại 
            products.Skip(2).ToList().ForEach(p => Console.WriteLine(p.ToString()));
            Console.WriteLine("\n ORdERBY(tang dan)_ ? ORDERBY Descending- giam dan");

            // Orderby 
            products.OrderBy(p => p.Price).ToList().ForEach(p => Console.WriteLine(p.ToString()));
          // Orderby Descending
            products.OrderByDescending(p => p.Price).ToList().ForEach(p => Console.WriteLine(p.ToString()));
            // reverse : đảo ngược phần tử trong mảng 
            mang.Reverse().ToList().ForEach(p => Console.WriteLine(p));
            // groupby : dữ liệu trả về là 1 nhóm dữ liệu liên quan đến một vấn dề nào đó
            // nhóm sẩn phảm theo giá 
           var kq = products.GroupBy(p => p.Price);// trả về sản phẩm và key là thứ liên quan đến các sản phẩm mà mình muốn trả về
            foreach(var group in kq)
            {
                Console.WriteLine(group.Key);
                foreach(var p in group)
                {
                    Console.WriteLine(p.ToString());
                }
            }
            // Distinct: độc nhất, hay là bỏ các phần tử có cùng giá trị 

             products.SelectMany(p => p.Colors).Distinct().ToList()
                .ForEach(p => Console.WriteLine(p));

            // Single: kiểm tra các phần tử thỏa một điều kiện logic nào đó=> trả về 1 phần tử , ngược lại pát sinh lỗi nếu có nhiều hơn 1 hoặc không có phàn tử nào
            var po  = products.Single(p=>p.Price == 129);
            Console.WriteLine(po.ToString());

            // SingleOrDefault: giải quyết trường hợp không tìm thấy phần tử nào của Single thì nó là null
            var pot = products.SingleOrDefault(p => p.Price == 323);
            Console.WriteLine(pot);

            // Any: trả về true nếu thỏa mãn một logic nào đó, một trong các phần tử thỏa đk thì là true,ngược lại là false
            var ptos = products.Any(p=>p.Price==4);
            Console.WriteLine(ptos);

            // All : tất cả các phần tử phải thỏa mãn 1 đk nào đó, ngược lại là false.
            var pto = products.All(p => p.Price > 4);
            Console.WriteLine(pto);
            // Count  : đếm sốt lượng phần tử
            Console.WriteLine(products.Count());
            Console.WriteLine(products.Count(p=>p.Price>200));
        }
    }
}
