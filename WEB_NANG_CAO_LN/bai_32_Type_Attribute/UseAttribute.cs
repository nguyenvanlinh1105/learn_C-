using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_32_Type_Attribute
{
    // AttributeName
    //[AttributeName(thamSo)]/ khởi tạo attribute 
    /*
     * Để khởi tạo attribute cho thuộc tính nào đó của đối tượng thì ta thực hiện gõ tên thuộc tính cần bổ sung 
     * ObsolateAttribute: đc sử dụng class, cấu trúc, method,.. 
     * khi một thành phần nào đó sử dụng obsoletAttribute thì nó sẽ được đánh dấu đã lối thời không được sử dụng nữa   
     */

    [Mota("Lớp chứa thông tin về user trên hệ thống ")]
    class User
    {
        [Mota("Tên người dùng")]
        public string Name { get; set; }
        [Mota("Tuổi của người dùng")]
        public int Age { get; set; }
        [Mota("Số điện thoại của người dùng")]
        public string PhoneNumber { get; set; }
        [Mota("Email của người dùng")]
        public string Email { get; set; }
        public User()
        {

        }
        public User(string name, int age, string phoneNumber, string email)
        {
            Name = name;
            Age = age;
            PhoneNumber = phoneNumber;
            Email = email;
        }
       // [Obsolete("Phương thức này không nên sử dụng nữa, cần thay bởi Showinfo",true)]// đánh dấu phương thức đã lổi thời và cần phải thay bằng một method khác
        public  void PrintInfo()
        {
            Console.WriteLine(this.Name);
        }
    }
    /* 
     * - MOTA:
     *      + Thông tin chi tiết của đối tượng
     */
    [AttributeUsage(AttributeTargets.Class| AttributeTargets.Property|AttributeTargets.Method)]// Mota được sử dụng ở đâu (lớp, properties, method...
    class MotaAttribute : Attribute
    {
        public string ThongTinChiTiet { get; set; }
        public MotaAttribute() { }

        public MotaAttribute(string thongTinChiTiet)
        {
            ThongTinChiTiet = thongTinChiTiet;
        }
    }
    internal class UseAttribute
    {
        //svm+tab
        static void Main(string[] args)
        {
           Console.OutputEncoding = Encoding.UTF8;
                User user  = new User();
            user.Name = "Nguyễn Văn Linh";
             var properties = user.GetType().GetProperties();
            foreach (var property in properties)
            {
                // lấy attribute ở properties 
                foreach(var attri in property.GetCustomAttributes(false))
                {
                    MotaAttribute mota=attri as MotaAttribute;
                    if(mota != null)
                    {
                        Console.WriteLine(mota.ThongTinChiTiet);
                        string name = property.Name;
                        var value = property.GetValue(user);
                        Console.WriteLine($"Thông tin : {name}: {value}");
                    }
                }

            }
        }
    }
}
