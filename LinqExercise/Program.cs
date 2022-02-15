using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            Console.WriteLine($"Sum of numbers: {numbers.Sum()}");
            Console.WriteLine($"Average of numbers: {numbers.Average()}");
            //Order numbers in ascending order and decsending order. Print each to console.
            var ascOrder = numbers.OrderBy(num => num);
            var descOrder = numbers.OrderByDescending(num => num);

            Console.WriteLine("Numbers Go Up");
            foreach(var num in ascOrder)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine();

            Console.WriteLine("Numbers Go Down");
            foreach(var num in descOrder)
            {
                Console.WriteLine(num);
            }
            //Print to the console only the numbers greater than 6
            var greaterThanSix = numbers.Where(num => num > 6);
            Console.WriteLine();
            Console.WriteLine("Greater than 6");
            
            foreach(var num in greaterThanSix)
            {
                Console.WriteLine(num);
            }

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("4 Numbers, Any Order");
            foreach(var num in ascOrder.Take(4))
            {
                Console.WriteLine(num);
            }


            //Change the value at index 4 to your age, then print the numbers in decsending order
            //numbers[4] = 32;
            numbers.SetValue(32, 4);

            Console.WriteLine("Index 4 Changed");
            foreach (var num in numbers)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("Index4 Changed on Desc List");
            foreach (var num in numbers.OrderByDescending(x => x))
            {
                Console.WriteLine(num);
            }

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            var filtered = employees.Where(person => person.FirstName.ToLower()[0] == 'c' ||
            person.FirstName.ToLower()[0] == 'r');
            Console.WriteLine();
            Console.WriteLine("Employees start with C or R");

            foreach(var employee in filtered.OrderBy(x => x.FirstName))
            {
                Console.WriteLine(employee.FullName);
            }
            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            var twentySix = employees.Where(x => x.Age > 26).OrderByDescending(x => x.Age)
                .ThenBy(x => x.FirstName);

            Console.WriteLine();
            Console.WriteLine("Over 26");
            foreach (var person in twentySix)
            {
                Console.WriteLine($"Name: {person.FullName}, Age: {person.Age}");
            }


            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            var experience = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            Console.WriteLine($"Years of Experience: {experience.Sum(x => x.YearsOfExperience)}");
            Console.WriteLine($"Average Experience: {experience.Average(x => x.YearsOfExperience)}");

            //Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Ronaldo", "McDonald", 28, 10)).ToList();

            Console.WriteLine();
            Console.WriteLine("Added the New Employee to the Roster!");
            foreach(var person in employees)
            {
                Console.WriteLine(person.FullName);
            }

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
