using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_1_Encapsulation
{
    internal class Student
    {
        private string maSV;
        private string name;
        private string email;
        private int age;
        public Student(string maSV, string name, string email, int age)
        {
            this.maSV = maSV;
            this.name = name;
            this.email = email;
            this.age = age;
        }

        public Student()
        {
                
        }
        // truy cập dữ liệu dùng getter, setter   để đảm bảo tính đóng gói
        public void setMaSV(string maSV)
        {
            this.maSV = maSV;
        }
        public string getMaSV()
        {
            return this.maSV;
        }

        public string getName()
        {
            return this.name;
        }
        public void setName(string name)
        {
            this.name=name;
        }
        public string getEamil()
        {

        return this.email;
        }
        public void setEmail(string email)
        {
            this.email = email;
        }
        public int getAge()
        {
            return this.age;
        }
        public void setAge(int age)
        {

            this.age = age;
        }

    }
}
