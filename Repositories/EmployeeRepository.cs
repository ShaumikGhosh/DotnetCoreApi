using CoreWebApi.Data;
using DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _dataContext;



        public EmployeeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }



        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await _dataContext.Employes.AddAsync(employee);
            await _dataContext.SaveChangesAsync();

            return result.Entity;
        }




        public async Task<Employee> DeleteEmployee(int Id)
        {
            var result = await _dataContext.Employes.Where(x=>x.Id==Id).FirstOrDefaultAsync();
            if(result != null)
            {
                _dataContext.Employes.Remove(result);
                await _dataContext.SaveChangesAsync();

                return result;
            }

            return null;
        }




        public async Task<IEnumerable<Employee>> GellAll()
        {
            return await _dataContext.Employes.ToListAsync();
        }




        public async Task<Employee> GetById(int Id)
        {
            return await _dataContext.Employes.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }




        public async Task<Employee> UpdateEmployee(int id, Employee employee)
        {
            var result = await _dataContext.Employes.Where(z=>z.Id == id).FirstOrDefaultAsync();
            if(result != null)
            {
                result.Name = employee.Name;
                result.City = employee.City;
                _dataContext.Employes.Update(result);
                return result;
            }
            return null;
        }
    }
}
