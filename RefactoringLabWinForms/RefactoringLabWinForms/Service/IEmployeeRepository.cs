using System.Collections.Generic;
using RefactoringLabWinForms.Models;

namespace RefactoringLabWinForms.Services
{
    /// <summary>
    /// Интерфейс для работы с хранилищем сотрудников
    /// </summary>
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        void Remove(Employee employee);
        List<Employee> GetAll();
        void Clear();
    }
}
