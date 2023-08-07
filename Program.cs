using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Assignment24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee()
            {
                Id = 12,
                FirstName = "Aishu",
                LastName = "Divi",
                Salary = 90000
            };
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("D:\\Training\\day21\\Assignment24\\Employee.bin", FileMode.Create))
            {
                formatter.Serialize(fs, employee);
            }
            Console.WriteLine("Binary serialization completed!!!!!\n\n");

            //Reading the binary  file
            using (FileStream fs1 = new FileStream("D:\\Training\\day21\\Assignment24\\Employee.bin", FileMode.Open))
            {
                Employee employee1 = (Employee)formatter.Deserialize(fs1);
                Console.WriteLine("********Deserialized Data (Binary)***********");
                Console.WriteLine("Employee ID:" + employee1.Id);
                Console.WriteLine("Employee First Name:" + employee1.FirstName);
                Console.WriteLine("Employee Last Name:" + employee1.LastName);
                Console.WriteLine("Employee Salary:" + employee1.Salary);
            }
            Console.WriteLine("\n");

            //XML serialization and deserialization

            XmlSerializer serializer = new XmlSerializer(typeof(Employee));
            using (TextWriter textWriter = new StreamWriter("D:\\Training\\day21\\Assignment24\\employee.Xml"))
            {
                serializer.Serialize(textWriter, employee);

            }
            Console.WriteLine("XML Serialization completed!!!!!\n\n");

            using (TextReader textReader = new StreamReader("D:\\Training\\day21\\Assignment24\\employee.Xml"))
            {
                Employee emp = (Employee)serializer.Deserialize(textReader);
                Console.WriteLine("********Deserialized Data in (XML)***********");
                Console.WriteLine("Employee ID:" + emp.Id);
                Console.WriteLine("Employee First Name:" + emp.FirstName);
                Console.WriteLine("Employee Last Name:" + emp.LastName);
                Console.WriteLine("Employee Salary:" + emp.Salary);
            }
            Console.ReadKey();
        }
    }
}