
using System;

namespace BTVN
{

    //Tạo class Person
    class Person
    {
        private string name;
        private string address;
        private double salary;

        //Phương thức khởi tạo có tham số
        public Person (string name, string address, double salary)
        {
            this.name = name;
            this.address = address;
            this.salary = salary;
        }

        // Phương thức khởi tạo không tham số
        public Person() { }


        // Tạo hàm get set cho thuộc tính
        public string Name
        {
            get { return name; }
            set
            {
                if (name != null)
                {
                    name = value;
                }
            }
        }

        public string Address
        {
            get { return address; }
            set
            {
                if (address != null)
                {
                    address = value;
                }
            }
        }

        public double  Salary
        {
            get { return salary; }
            set
            {
                if (10 >= salary && salary >= 0)
                {
                    salary = value;
                }
            }
        }



        // Phương thức nhập thông tin người 
        public void Input()
        {
            while (true)
            {
                Console.WriteLine("Nhập tên: ");
                string name = Console.ReadLine();
                if (name != "")
                {
                    this.name = name;
                    break;
                }
                else Console.WriteLine("Tên không hợp lệ. Nhập lại!");
            }

            while (true)
            {
                Console.WriteLine("Nhập địa chỉ: ");
                string address = Console.ReadLine();
                if (address != "")
                {
                    this.address = address;
                    break;
                }

                else Console.WriteLine("Địa chỉ không hợp lệ. Nhập lại!");
            }

            while (true)
            {
                double x;
                Console.WriteLine("Nhập lương: ");
                string salary = Console.ReadLine();
                if (double.TryParse(salary, out x) && double.Parse(salary) > 0)
                {
                    this.salary = double.Parse(salary);
                    break;
                }
                else Console.WriteLine("Tiền lương không hợp lệ. Nhập lại!");
            }

        }


        // Phương thức sắp xếp theo lương tăng dần (bằng thuật toán nổi bọt)
        public Person[] sortBySalary(Person[] persons)
        {
            if (persons[0] == null)
            {
                Console.WriteLine("Mảng không có người không thể sắp xếp");
                return null;
            }
            else
            {
                for (int i = 0; i < persons.Length; i++)
                {
                    for (int j = i + 1; j < persons.Length; j++)
                    {
                        if (persons[i].salary > persons[j].salary)
                        {
                            Person temp = persons[i];
                            persons[i] = persons[j];
                            persons[j] = temp;
                        }
                    }
                }
                return persons;
            }
        }




        // Phương thức hiển thị 1 người
        public void Print()
        {
            Console.WriteLine($"| {name,-20} | {address,20} | {salary,15} |");
        }



    }



}
