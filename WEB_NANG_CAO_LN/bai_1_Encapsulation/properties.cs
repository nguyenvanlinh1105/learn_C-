using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_1_Encapsulation
{
    /* Sử dụng dotnet properties 
     * - .NET thích biểu hiện tính đóng gói dữ liệu thông qua sử dụng các properties
     * - bản chât: là sự kết hợp bằng cách định nghĩa cặp getter/ setter trực tiếp trong bản thân một properties
     * - properties không sử dụng ()
     * - properties có kiểu trả về là kiểu của trường dữ liệu mà nó đóng gói 
     * - Sử dụng keyword value trong khối set
     * 
     * 
     */
    class hocSinh
    {
        private string maSV;
        private string name;
        private string email;
        private int age;
        public hocSinh(string maSV, string name, string email, int age)
        {
            this.maSV = maSV;
            this.name = name;
            this.email = email;
            this.age = age;
        }

        public hocSinh()
        {

        }
        public string MaSV
        {
            set { maSV = value; }
            get { return maSV; }
        }
        public string Name
        {
            set { name = value; }
            get { return name; }
        }
    }
        internal class properties
    {

    }
}
