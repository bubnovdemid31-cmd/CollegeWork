using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main()
        {
            Employee[] employees = { new Manager(), new Developer(), new Cleaner() };
            employees[0].Name = "john";
            employees[1].Name = "jane";
            employees[2].Name = "Tom";
            for(int i=0; i < employees.Length; i++)
            {

                employees[i].CalculateSalary(50000);
                Console.WriteLine(employees[i].ToString());
            }
            Console.ReadLine();
        }
    }
    abstract class Employee: ICalculate
    {
        protected string name;
        protected decimal salary;
        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value)) Console.WriteLine("Name cannot be empty");
                else name = value;
            }
        }

        public decimal Salary
        {
            get => salary;
            private set => salary = value;

        }
        public override string ToString()
        {
            return $"Name: {name}, Salary: {salary}";
        }

        abstract public void CalculateSalary(decimal value);
    }

    public interface ICalculate
    {
        void CalculateSalary(decimal value);
    }

    class Manager: Employee, ICalculate
    {
        public override void CalculateSalary(decimal value)
        {
            salary = value * 0.8m;
        }
    }
    class Developer : Employee, ICalculate
    {
        public override void CalculateSalary(decimal value)
        {
            salary = value * 0.5m;
        }
    }
    class Cleaner: Employee, ICalculate
    {
        public override void CalculateSalary(decimal value)
        {
            salary = value * 0.1m;
        }
    }
}
