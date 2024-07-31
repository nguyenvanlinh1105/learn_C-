namespace bai_28_LINQ
{
    public class product
    {
        private int ID { get; set; }
        private string Name { set; get; }
        private double Price { set; get; }
        private string[] Colors { set; get; }
        private int Brand { set; get; }

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
        private string Name { get; set; }
        private int ID { get; set; }
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
         */



        static void Main(string[] args)
        {
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
                new product(2, "Ghế sofa", 299, new string[] {"Đen", "Nâu"}, 2),
                new product(3, "Tủ sách", 199, new string[] {"Trắng", "Gỗ"}, 1),
                new product(4, "Giường ngủ", 499, new string[] {"Xanh", "Trắng"}, 1),
                new product(5, "Tủ quần áo", 399, new string[] {"Gỗ", "Trắng"}, 1)
            };

            var query = from p in products
                       // where p.Price >0 select p;

        }
    }
}
