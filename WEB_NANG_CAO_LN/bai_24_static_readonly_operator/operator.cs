using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_24_static_readonly_operator
{

    class Vector
    {
        private double x;
        private double y;
        public Vector(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public void Info()
        {
            Console.WriteLine($"x={x}, y={y}");
        }

        // toán tử cộng  : dậu + sau operator là kí hiệu của phép toán sẽ sử dụng
        public static Vector operator+(Vector v1, Vector v2)
        {
            double x1 = v1.x + v2.x;
            double y1 = v1.y + v2.y;
            Vector v= new Vector(x1,y1);
            return v;
        }
        public double this[int index]
        {
            set
            {
                switch (index) {
                    case 0:
                        x = value;
                        break;
                    case 1:
                        y = value;
                        break;
                    default:
                        throw new ArgumentException("chỉ số sai");
                } }
            get
            {
                    switch (index)
                    {
                        case 0:
                            return x;
                        case 1:
                            return y;
                        default:
                            throw new ArgumentException("chỉ số sai");
                    }
                }

        }
    }
    internal class @operator
    {

        static void Main(string[] args)
        {
            Vector v1 = new Vector(3, 2);
            Vector v2 = new Vector(2, 1);
            Vector v3 = v1 + v2;
            v1.Info();
            v2.Info();
            v3.Info();
            // tạo indexer
            v1[0] = 5;
            v1[1] = 0;
            v1.Info();

        }
    }
}
