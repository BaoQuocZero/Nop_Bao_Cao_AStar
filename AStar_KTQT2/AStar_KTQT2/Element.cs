using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar_KTQT2
{
    class Element : IComparable<Element>


    {
        private int tendinh;
        private int g; // Tiêu chí để ưu tiên chọn phần tử xem xét trước
        private double f; // Ước lượng tổng chi phí
        private int pre;

        //Hàm khởi tạo thông số
        public Element()
        {
            tendinh = -1;
            g = -2;
            pre = -1;
            f = 0.0; // Khởi tạo f là 0.0
        }

        //Khởi tạo element với 4 tham số
        public Element(int dinh, int cp, double f, int dt)
        {
            tendinh = dinh;
            g = cp;
            pre = dt;
            this.f = f; // Sử dụng this để tránh mâu thuẫn với biến f trong class
        }

        public void printElmt()
        {
            Console.WriteLine("({0}, {1}, {2}, {3})", tendinh, g, f, pre);
        }

        public int Tendinh
        {
            get
            {
                return tendinh;
            }

            set
            {
                tendinh = value;
            }
        }

        public int G
        {
            get
            {
                return g;
            }

            set
            {
                g = value;
            }
        }

        public double F
        {
            get
            {
                return f;
            }

            set
            {
                f = value;
            }
        }

        public int Pre
        {
            get
            {
                return pre;
            }

            set
            {
                pre = value;
            }
        }

        // Phương thức so sánh để sắp xếp các Element dựa trên chi phí f
        public int CompareTo(Element other)
        {
            return this.f.CompareTo(other.f);
        }

        // Phương thức Equals để so sánh hai Element
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Element other = (Element)obj;
            return this.tendinh == other.tendinh;
        }

        // Phương thức GetHashCode
        public override int GetHashCode()
        {
            return this.tendinh.GetHashCode();
        }
    }


}
