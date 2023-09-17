using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BTVN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;



            Console.Write("Nhập số lượng người muốn nhập: ");
            int n = int.Parse(Console.ReadLine());


            // Tạo mảng lưu trữ người với n người
            Person[] persons = new Person[n];


            // Nhập thông tin cho n người rồi nhét vào mảng
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhập thông tin cho người {i+1}");
                Person person = new Person();
                person.Input();
                persons[i] = person;
            }



            // Hiện thị tất cả n người trong mảng
            Console.WriteLine($"| {"Họ tên",-20} | {"Địa chỉ",20} | {"Lương",15} |");
            Console.WriteLine("-----------------------------------------------------------------");
            for (int i = 0; i < n; i++)
            {
                persons[i].Print();
            }
            

            Console.WriteLine();
            Console.WriteLine();


            // Sắp xếp mảng theo lương
            persons = persons[0].sortBySalary(persons);
            // hiển thị sau khi sắp xếp
            Console.WriteLine($"| {"họ tên",-20} | {"địa chỉ",20} | {"lương",15} |");
            Console.WriteLine("-----------------------------------------------------------------");
            for (int i = 0; i < n; i++)
            {
                persons[i].Print();
            }



            Console.ReadKey();
        }
    }
}
