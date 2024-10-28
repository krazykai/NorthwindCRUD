using Microsoft.EntityFrameworkCore;
using Northwind.Models;

namespace NorthwindCRUD.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly NorthwindContext _context;

        public CustomerRepository(NorthwindContext context)
        {
            this._context = context;
        }


        public IQueryable<Customer> GetAll()
        {
            return _context.Customers.AsQueryable();
        }

        public Customer GetById(string CustomerId)
        {
            return _context.Customers.Find(CustomerId);
        }

        public bool Create(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            else
            {
                this._context.Customers.Add(customer);
                return this.SaveChanges();
            }
        }

        public bool Update(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            else
            {
                this._context.Entry(customer).State = EntityState.Modified;
                return this.SaveChanges();
            }
        }

        public bool Delete(string CustomerId)
        {
            var deleteCustomer = _context.Customers.Find(CustomerId);
            if (deleteCustomer != null)
            {
                _context.Customers.Remove(deleteCustomer);
            }
            return this.SaveChanges();
        }

        public bool SaveChanges()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
