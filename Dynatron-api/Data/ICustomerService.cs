using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dynatron_api.Models;

namespace Dynatron_api.Data
{
    public interface ICustomerService
    {
        Task AddAsync(Customer customer);
        Task DeleteAsync(int id);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<IEnumerable<Customer>> GetAllAsync(params Expression<Func<Customer, object>>[] includeProperties);
        Task<Customer> GetByIdAsync(int id);
        Task<Customer> GetByIdAsync(int id, params Expression<Func<Customer, object>>[] includeProperties);
        Task UpdateAsync(int id, Customer entity);

    }
}