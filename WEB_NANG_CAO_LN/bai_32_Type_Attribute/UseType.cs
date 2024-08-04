using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_32_Type_Attribute
{
    class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
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
    }
    internal class Attribute
    {
        static void Main(string[] args)
        {

            User user = new User("Nguyen Linh",21,"043523433","vanlinh@gmail.com");

            // kiểm tra trong user có những đối tượng trong user
            var properties = user.GetType().GetProperties();
            foreach (var property in properties)
            {
                string name = property.Name;
                //Console.WriteLine(property.Name);// thuộc tính
                var value = property.GetValue(user);
                Console.WriteLine($"{name} :{value}");
            }
        }
    }
}
