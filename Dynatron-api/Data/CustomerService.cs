using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dynatron_api.Models;

namespace Dynatron_api.Data
{
    public class CustomerService : ICustomerService
    {
        private readonly DataContext _context;

        public CustomerService(DataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Set<Customer>().AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<Customer>().FirstOrDefaultAsync(n => n.Id == id);
            EntityEntry entityEntry = _context.Entry<Customer>(entity);
            entityEntry.State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllAsync() => await _context.Set<Customer>().ToListAsync();

        public async Task<IEnumerable<Customer>> GetAllAsync(params Expression<Func<Customer, object>>[] includeProperties)
        {
            IQueryable<Customer> query = _context.Set<Customer>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(int id) => await _context.Set<Customer>().FirstOrDefaultAsync(n => n.Id == id);

        public async Task<Customer> GetByIdAsync(int id, params Expression<Func<Customer, object>>[] includeProperties)
        {
            IQueryable<Customer> query = _context.Set<Customer>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task UpdateAsync(int id, Customer entity)
        {
            EntityEntry entityEntry = _context.Entry<Customer>(entity);
            entityEntry.State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

    }
}