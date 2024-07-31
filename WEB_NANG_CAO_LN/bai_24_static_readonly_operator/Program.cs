using System.Text;

namespace bai_24_static_readonly_operator
{
    /*
     * static : thuộc tính và phương thức tĩnh được truy cập qua lớp ví nó là dữ liệu của lớp không phải của đổi tượng
     * 
     * 
     * 
     * 
     */
    class CountNumber
    {
        public static readonly string maSo="57656";
        public static int number { set; get; }
        public static void Info()
        {
            Console.WriteLine($"số lần truy cập là: {number}");
        }
        public void Count()
        {
            CountNumber.number++;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            CountNumber.number = 3;
            CountNumber.Info();
            Console.WriteLine(CountNumber.maSo);
        }
    }
}
