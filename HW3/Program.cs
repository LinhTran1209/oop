using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HW3
{
    class Employee
    {
        public string name;
        public Employee() { }
        public Employee(string name) => this.name = name;
    }
    class Item
    {
        private string name;
        private double price;
        private double discount;
        public Item() { }
        public Item(string name, double price, double discount)
        {
            this.name = name;
            this.price = price;
            this.discount = discount;
        }
        public Item(string name, double price)
        {
            this.name = name;
            this.price = price;
            this.discount = 0;
        }
        public void Intput()
        {
            Console.Write("Tên sản phẩm: ");
            this.name = Console.ReadLine();
            Console.Write("Giá sản phẩm: ");
            this.price = double.Parse(Console.ReadLine());
            Console.Write("Mã giảm giá sản phẩm: ");
            this.discount = double.Parse(Console.ReadLine());
        }
        public double getPrice()
        {
            return price;
        }
        public double getDiscount()
        {
            return discount;
        }
        public string getName()
        {
            return name;
        }
        public string printItem()
        {
            return $"| {name,8} | {price,10} | {discount,15} |";
        }
    }
    class GroceryBill
    {
        private Employee employee;
        private List<BillLine> billLines;
        public GroceryBill() { }
        public GroceryBill(Employee employee)
        {
            this.employee = employee;
            this.billLines = new List<BillLine>();
        }
        public virtual void Add(BillLine i)
        {
            billLines.Add(i);
        }
        public double getTotal()
        {
            double total = 0;
            foreach (var billLine in billLines)
            {
                double price = billLine.getItem().getPrice();
                total += price;
            }
            return total;
        }
        public virtual void printReceipt()
        {
            Console.WriteLine($"Khách hàng: {employee.name}");
            Console.WriteLine($"| {"STT", 4} | {"Tên sp",8} | {"Giá bán",10} | {"Mã giảm giá",15} |");
            foreach (var billLine in billLines)
            {
                Console.WriteLine($"| {billLine.getQuantity(), 4} {billLine.getItem().printItem()}");
            }
            Console.WriteLine($"Tổng tiền: {getTotal()}USD");
        }
    }
    class DiscountBill : GroceryBill
    {
        private bool preferred;
        private int discountcount;
        private double discountamount;
        public DiscountBill(Employee employee, bool preferred)
            : base(employee)
        {
            this.preferred = preferred;
            discountcount = 0;
            discountamount = 0;
        }
        public int getDiscountCount()
        {
            return discountcount;
        }
        public double getDiscountAmount()
        {
            return discountamount;
        }
        public double getDiscountPercent()
        {
            return (discountamount/getTotal()) * 100;
        }
        public override void Add(BillLine billLine)
        {
            base.Add(billLine);
            if (preferred && billLine.getItem().getDiscount() > 0)
            {
                discountcount++;
            }
            discountamount += billLine.getItem().getDiscount();
        }
        public override void printReceipt()
        {
            base.printReceipt();
            Console.WriteLine($"Số lượng mã giảm giá: {getDiscountCount()}");
            Console.WriteLine($"Phần trăm chiết khấu: {getDiscountPercent()}%");
            Console.WriteLine($"Tổng tiền chiết khấu: {getDiscountAmount()}");
            Console.WriteLine($"Tổng tiền cần trả: {base.getTotal() - getDiscountAmount()}");
        }
    }
    class BillLine
    {
        private Item item;
        private int quantity;

        public BillLine(Item item, int quantity)
        {
            this.item = item;
            this.quantity = quantity;
        }

        public void setQuantity(int quantity)
        {
            this.quantity = quantity;
        }

        public int getQuantity()
        {
            return quantity;
        }

        public void setItem(Item item)
        {
            this.item = item;
        }

        public Item getItem()
        {
            return item;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Employee employee = new Employee("Lĩnh");
            Console.Write("Số lượng item muốn mua: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Khách hàng này có được ưu tiên khuyến mãi?      1.true      2.false: ");
            int ut = int.Parse(Console.ReadLine());
            GroceryBill bill;
            if (n == 1) bill = new DiscountBill(employee, true);
            else bill = new GroceryBill(employee);
            for (int i = 0; i < n; i++)
            {
                Item item = new Item();
                item.Intput();
                BillLine billLine = new BillLine(item, i + 1);
                bill.Add(billLine);
            }
            //Hiển thị
            bill.printReceipt();
            Console.ReadKey();
        }
    }
}
