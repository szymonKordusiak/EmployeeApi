using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class ProgramUI
    {
        public void DisplayMenu()
        {
            Console.WriteLine("1. Dodaj pracownika.");
            Console.WriteLine("2. Wyświetl wszystkich pracowników.");
            Console.WriteLine("3. Usuń pracownika.");
            Console.WriteLine("4. Znajdź pracownika.");
            Console.WriteLine("5. Statystyki.");
            Console.WriteLine("6. Koniec.");
            Console.WriteLine();

        }
        

        public Employee GetEmployeeUser()
        {
            Employee employee = new Employee();

            Console.WriteLine("Jakie imię ma pracownik");
            employee.FirstName = Console.ReadLine();

            Console.WriteLine("Jakie nazwisko ma pracownik");
            employee.LastName = Console.ReadLine();

            Console.WriteLine("Ile wynosi pensja pracownika");
            employee.Salary = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine();

            return employee;
        }

        public int GetSelecedOption()
        {
            Console.WriteLine("Podaj wybraną opcję: ");
            int option = Convert.ToInt32((Console.ReadLine()));
            return option;
        }

        public void DisplayEmployeesList(List<Employee> employees)
        {
            if (employees.Any())
            {
                foreach (var item in employees)
                {
                    Console.WriteLine($"Imię użytkownika to: {item.FirstName}");
                    Console.WriteLine($"Nazwisko użytkownika to: {item.LastName}");
                    Console.WriteLine($"Wypłata użytkownika to: {item.Salary}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Brak elementów");
                Console.WriteLine();
            }

        }

        public string GetFirstNameToDelete()
        {
            Console.WriteLine("Podaj imię użytkownika do usunięcia: ");
            string firstName = Console.ReadLine();
            Console.WriteLine();      

            return firstName;
         }
        public string GetLastNameToDelete()
        {
            Console.WriteLine("Podaj nazwisko użytkownika do usunięcia: ");
            string lastName = Console.ReadLine();
            Console.WriteLine();

            return lastName;
        }

        public string GetFirstName()
        {
            Console.WriteLine("Podaj imię szukanego użytkownika: ");
            string firstName = Console.ReadLine();
            Console.WriteLine();

            return firstName;
        }
        public string GetLastName()
        {
            Console.WriteLine("Podaj nazwisko szukanego użytkownika: ");
            string lastName = Console.ReadLine();
            Console.WriteLine();

            return lastName;
        }

        public void IsEmpoyeeExist(Employee employee)
        {
            if (employee is null)
            {
                Console.WriteLine("Użytkownik nie istnieje");
            }
            else
            {
                Console.WriteLine($"Użytkownik istnieje, imię to: {employee.FirstName} nazwisko to: {employee.LastName}, a pensja wynosi: {employee.Salary}");
                Console.WriteLine();

            }
        }

        public void DisplayStats(decimal MaxSalary, decimal MinSalary, decimal AvarageSalary, long NumberOfEmplyees )
        {
            Console.WriteLine($"Maksymalna pensja wynosi: {MaxSalary}");
            Console.WriteLine($"Minimalna pensja wynosi: {MinSalary}");
            Console.WriteLine($"Średnia pensji wynosi: {AvarageSalary}");
            Console.WriteLine($"Liczba pracowników wynosi: {NumberOfEmplyees}");
        }


    }
}
