using CoreWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GellAll();
        Task<Employee> GetById(int Id);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(int Id, Employee employee);
        Task<Employee> DeleteEmployee(int Id);

    }
}
