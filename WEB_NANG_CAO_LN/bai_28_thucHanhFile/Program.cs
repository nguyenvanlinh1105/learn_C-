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
        void Save(Stream stream)
        {
            var byteId = BitConverter.GetBytes(ID);
            stream.Write(byteId,0,4);
            var byte_price = BitConverter.GetBytes(Price);
            stream.Write(byte_price, 0, 8);
            var byte_name = Encoding.UTF8.GetBytes(Name);
            stream.Write(byte_name, 0, byte_name.Length);
        }
        void Restore(Stream stream)
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
