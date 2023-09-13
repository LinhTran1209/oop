using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
    class Student
    {
        private int id;
        private string name;

        public Student(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public void Print()
        {
            Console.WriteLine($"Id sinh viên: {id}\nHọ tên sinh viên: {name}");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Student st = new Student(12522060, "Trần Hồng Lĩnh");
            st.Print();

            Console.ReadKey();
        }
    }
}
