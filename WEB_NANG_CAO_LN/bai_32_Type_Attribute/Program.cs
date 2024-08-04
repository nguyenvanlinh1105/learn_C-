namespace bai_32_Type_Attribute
{
    /*
     * Type : là một kiểu chứ thông tin của một kiểu dữ liệu nào đó là class, struct , int , bool 
     * Type được dùng trogn reflection : Lấy Thông tin của kiểu dữ liệu ở thời điểmt thực thi  
     * Attribute : là một phần của siêu dữ liệu, cung cấp thông tin bổ sung cho một lớp các thành viên của lớp
     * Attribute: sử dụng lib , frame, 
     * sử dụng attribute: 
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            int a=1;
            Type type = typeof(int);// khai báo biến type chứa tông tin về kiểu dữ liệu int 
            Type type1 = typeof(string);
            Type type2 = typeof(Array);

            Type type3 = a.GetType();// có thể getType bằng cách như thế này ,
            int[] b = { 1, 2, 3 };
            Type type4 = b.GetType();
            Console.WriteLine("------------Các thuộc tính");
            // lấy các thuộc tính
            type4.GetProperties().ToList().ForEach(
                ( a) =>
                {
                    Console.WriteLine(a.Name);
                }
                );
            // lấy các trường dữ liệu 
            Console.WriteLine("------------Các trường dữ liệu");

            type4.GetFields().ToList().ForEach(
                (a) => {
                    Console.WriteLine(a.Name);
                }
                );
            Console.WriteLine("------------Các phương thức");
            type4.GetMethods().ToList().ForEach(
               (a) => {
                   Console.WriteLine(a.Name);
               }
               );
        }
    }
}
