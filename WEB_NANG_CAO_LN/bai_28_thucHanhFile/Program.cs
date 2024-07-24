using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace bai_28_thucHanhFile
{
    class Product
    {
        public int ID { set; get; }
        public double Price { set; get; }
        public string Name { set; get; }
        public Product(int id , double pric, string name)
        {
            this.ID = id;
            this.Price = pric;
            this.Name = name;
        }
        public void Save(Stream stream)
        {
            var byteId = BitConverter.GetBytes(ID);
            stream.Write(byteId,0,4);

            var byte_price = BitConverter.GetBytes(Price);
            stream.Write(byte_price, 0, 8);

            var byte_name = Encoding.UTF8.GetBytes(Name);
            var byte_length = BitConverter.GetBytes(byte_name.Length);
            stream.Write(byte_length, 0, 4);
            stream.Write(byte_name, 0, byte_name.Length);




        }
        public void Restore(Stream stream)
        {

        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            string path = "data.txt";
            var stream = new FileStream(path: path, FileMode.OpenOrCreate);
            Product pro = new Product(10,12345,"sanphan1");
            pro.Save(stream);
        }
    }
}
