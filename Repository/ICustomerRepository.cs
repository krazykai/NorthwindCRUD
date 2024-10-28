using Northwind.Models;

namespace NorthwindCRUD.Repository
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> GetAll();
        Customer GetById(string CustomerId);
        bool Create(Customer customer);
        bool Update(Customer customer);
        bool Delete(string CustomerId);
        bool SaveChanges();
    }
}
