using Northwind.Models;
using NorthwindCRUD.Models.Parameters;

namespace NorthwindCRUD.Services
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAll();
        Task<Customer> GetById(string CustomerId);
        Task<List<Customer>> Query(CustomerQueryParameters parameters);
        Task<bool> Create(CustomerCreateParameters parameters);
        Task<bool> Update(CustomerUpdateParameters parameters);
        Task<bool> Delete(string CustomerId);
    }
}
