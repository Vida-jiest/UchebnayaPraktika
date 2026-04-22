using System.Collections.Generic;
using RefactoringLabWinForms.Models;

namespace RefactoringLabWinForms.Services
{
    /// <summary>
    /// Репозиторий для управления коллекцией сотрудников
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees;

        public EmployeeRepository()
        {
            _employees = new List<Employee>();
        }

        public void Add(Employee employee)
        {
            _employees.Add(employee);
        }

        public void Remove(Employee employee)
        {
            _employees.Remove(employee);
        }

        public List<Employee> GetAll()
        {
            return new List<Employee>(_employees);
        }

        public void Clear()
        {
            _employees.Clear();
        }
    }
}
