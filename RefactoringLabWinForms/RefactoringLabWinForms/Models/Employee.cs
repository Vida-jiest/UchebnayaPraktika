using System;

namespace RefactoringLabWinForms.Models
{
    /// <summary>
    /// Класс для представления сотрудника
    /// </summary>
    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }

        public Employee(string name, int age, decimal salary)
        {
            Name = name;
            Age = age;
            Salary = salary;
        }

        /// <summary>
        /// Валидация данных сотрудника
        /// </summary>
        public bool IsValid(out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                errorMessage = "Имя не может быть пустым";
                return false;
            }

            if (Age < 18 || Age > 100)
            {
                errorMessage = "Возраст должен быть от 18 до 100 лет";
                return false;
            }

            if (Salary <= 0)
            {
                errorMessage = "Зарплата должна быть положительным числом";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        public override string ToString()
        {
            return $"{Name}, {Age} лет, {Salary:C}";
        }
    }
}
