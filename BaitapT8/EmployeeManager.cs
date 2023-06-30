using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BaitapT8
{
    public class EmployeeManager : Manager
    {
        public List<Employee> emps = new List<Employee>();


        public EmployeeManager()
        {
            emps.Add(new Employee("0", "admin", "admin@npcetc.vn", "123", true));
        }
        public override Employee Login()
        {
            while (true)
            {
                Console.Write("Nhap Name: ");
                String name = Console.ReadLine();
                Console.Write("Nhap Password: ");
                String password = Console.ReadLine();
                foreach (Employee emp in emps)
                {
                    if (emp.name.Equals(name) & emp.password.Equals(password))
                    {
                        Console.WriteLine("Dang nhap thanh cong");
                        return emp;
                    }
                }
                Console.WriteLine("Name hoac Password khong dung");
            }
        }
        public override void Find()
        {
            Console.Write("Nhap User hoac Id: ");
            String searchInfo = Console.ReadLine();
            while (string.IsNullOrEmpty(searchInfo))
            {
                Console.WriteLine("Ban chua nhap gi");
                Console.Write("Nhap User hoac Id: ");
                searchInfo = Console.ReadLine();
            }
            List<Employee> foundList = new List<Employee>();
            foreach (Employee emp in this.emps)
            {
                if (emp.no == searchInfo || emp.name == searchInfo)
                {
                    foundList.Add(emp);
                }
            }
            if(foundList.Count > 0)
            {
                foreach (Employee emp in foundList)
                {
                    Console.WriteLine(emp);
                }
            }
            if(foundList.Count == 0)
            {
                Console.WriteLine("Khong tim thay");
            }
        }
        public override void AddNew()
        {
            Console.Write("Nhap Number: ");
            String no = Console.ReadLine();
            Console.Write("Nhap Ten: ");
            String name = Console.ReadLine();
            Console.Write("Nhap Email: ");
            String email = Console.ReadLine();
            Console.Write("La quan ly y/n:");
            Boolean isManager = false;
            if (Console.ReadLine().ToUpper() == "Y") { isManager = true; }
            Console.Write("Nhap Password:");
            String password = Console.ReadLine();
            emps.Add(new Employee(no, name, email, password, isManager));
        }
        public override void Update() 
        {
            Find();
            Console.Write("Lua chon ID tai khoan can Update: ");
            String idUpdate = Console.ReadLine();
            int indexUpdate = -1;
            foreach (Employee emp in this.emps)
            {
                if(emp.no == idUpdate)
                {
                    indexUpdate = this.emps.IndexOf(emp);
                }
            }     
            Console.WriteLine("Chon truong thong tin ban muon Update");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Email");
            Console.WriteLine("3. Manager");
            Console.Write("Select (1-3): ");
            int fieldSelect = Convert.ToInt32(Console.ReadLine());
            switch (fieldSelect)
            {
                case 1:
                    Console.Write("Nhap Name moi: ");
                    emps[indexUpdate].name = Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Nhap Email moi: ");
                    emps[indexUpdate].email = Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("La quan ly hay khong (y/n): ");
                    Boolean isManager = false;
                    if (Console.ReadLine().ToUpper() == "Y") { isManager = true; }
                    emps[indexUpdate].isManager = isManager;
                    break;
            }
        }
        public override void Remove()
        {
            Find();
            Console.Write("Lua chon ID tai khoan can xoa: ");
            String idRemove = Console.ReadLine();
            int indexRemove = -1;
            foreach (Employee emp in this.emps)
            {
                if (emp.no == idRemove)
                {
                    indexRemove = this.emps.IndexOf(emp);
                }
            }
            this.emps.RemoveAt(indexRemove);
        }
        public override void Export()
        {
            StreamWriter streamWriter = new StreamWriter("C:\\Users\\TRUNGTV\\T8.csv", false, System.Text.Encoding.UTF8);
            try
            {
                foreach (Employee e in emps)
                {
                    streamWriter.WriteLine(e);
                    streamWriter.Flush();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                streamWriter.Close();
            }
        }
        public override void Import()
        {
            String path = "C:\\Users\\TRUNGTV\\T8import.csv";
            StreamReader reader = new StreamReader(path) ;
            try
            {
                string line;
                while ((line = reader.ReadLine()) !=null)
                {
                    //tách chuỗi gán vào mảng 
                    string[] strings = line.Split(',');

                    //
                    String no = strings[0];
                    String name = strings[1];
                    String email = strings[2];
                    String password = strings[3];
                    Boolean isManager = false;
                    if (strings[4].ToUpper() == "TRUE")
                    {
                        isManager = true;
                    }
                    emps.Add(new Employee(no, name, email, password, isManager));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                reader.Close();
            }
        }

    }
}
