using System.Text;

namespace bai_1_Encapsulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Student student = new Student("MVS 123","Nguyễn Văn Linh","vanlinh@gmail.com",20);
            student.setAge(21);
            Console.WriteLine($"Tổi của {student.getName()} là : {student.getAge()}");
            hocSinh hs = new hocSinh();
            hs.Name = "Linh Nguyễn";
            Console.WriteLine($"ten là: {hs.Name}");
        }
    }
}
