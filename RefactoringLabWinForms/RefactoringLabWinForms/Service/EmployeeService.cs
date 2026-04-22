using System;
using System.Linq;
using RefactoringLabWinForms.Models;

namespace RefactoringLabWinForms.Services
{
    /// <summary>
    /// Сервис для работы с бизнес-логикой сотрудников
    /// </summary>
    public class EmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Добавление нового сотрудника с валидацией
        /// </summary>
        public bool AddEmployee(string name, int age, decimal salary, out string errorMessage)
        {
            var employee = new Employee(name, age, salary);

            if (!employee.IsValid(out errorMessage))
            {
                return false;
            }

            _repository.Add(employee);
            errorMessage = string.Empty;
            return true;
        }

        /// <summary>
        /// Удаление сотрудника
        /// </summary>
        public void RemoveEmployee(Employee employee)
        {
            _repository.Remove(employee);
        }

        /// <summary>
        /// Получение всех сотрудников
        /// </summary>
        public System.Collections.Generic.List<Employee> GetAllEmployees()
        {
            return _repository.GetAll();
        }

        /// <summary>
        /// Расчет средней зарплаты
        /// </summary>
        public decimal CalculateAverageSalary()
        {
            var employees = _repository.GetAll();

            if (employees.Count == 0)
            {
                return 0;
            }

            return employees.Average(e => e.Salary);
        }

        /// <summary>
        /// Поиск самого молодого сотрудника
        /// </summary>
        public Employee FindYoungestEmployee()
        {
            var employees = _repository.GetAll();
            return employees.OrderBy(e => e.Age).FirstOrDefault();
        }

        /// <summary>
        /// Получение количества сотрудников
        /// </summary>
        public int GetEmployeeCount()
        {
            return _repository.GetAll().Count;
        }
    }
}
