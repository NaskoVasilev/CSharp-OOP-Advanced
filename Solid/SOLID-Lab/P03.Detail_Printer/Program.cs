using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            Manager manager = new Manager("Atanas", new List<string>() { "book", "note" });
            Employee employee = new Employee("Pesho");

            List<Employee> employees = new List<Employee>();
            employees.Add(manager);
            employees.Add(employee);

            DetailsPrinter detailsPrinter = new DetailsPrinter(employees);
            detailsPrinter.PrintDetails();
        }
    }
}
