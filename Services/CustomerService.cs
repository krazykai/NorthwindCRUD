using AutoMapper;
using Northwind.Models;
using NorthwindCRUD.Models.Parameters;
using NorthwindCRUD.Repository;
using System.Reflection.Metadata;

namespace NorthwindCRUD.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            this._customerRepository = customerRepository;
            this._mapper = mapper;
        }

        public async Task<List<Customer>> GetAll()
        {
            List<Customer> customers = this._customerRepository.GetAll().ToList();
            return customers;
        }

        public async Task<Customer> GetById(string CustomerId)
        {
            Customer customer = this._customerRepository.GetById(CustomerId);
            return customer;
        }
        public async Task<List<Customer>> Query(CustomerQueryParameters parameters)
        {
            var customerAllData = this._customerRepository.GetAll();
            if (!string.IsNullOrEmpty(parameters.CustomerId))
            {
                customerAllData = customerAllData.Where(d => d.CustomerId == parameters.CustomerId);
            }
            if (!string.IsNullOrEmpty(parameters.CompanyName))
            {
                customerAllData = customerAllData.Where(d => d.CompanyName.Contains(parameters.CompanyName));
            }
            if (!string.IsNullOrEmpty(parameters.ContactName))
            {
                customerAllData = customerAllData.Where(d => d.ContactName.Contains(parameters.ContactName));
            }
            if (!string.IsNullOrEmpty(parameters.Address))
            {
                customerAllData = customerAllData.Where(d => d.Address.Contains(parameters.Address));
            }
            if (!string.IsNullOrEmpty(parameters.City))
            {
                customerAllData = customerAllData.Where(d => d.City == parameters.City);
            }
            if (!string.IsNullOrEmpty(parameters.Region))
            {
                customerAllData = customerAllData.Where(d => d.Region == parameters.Region);
            }
            if (!string.IsNullOrEmpty(parameters.PostalCode))
            {
                customerAllData = customerAllData.Where(d => d.PostalCode == parameters.PostalCode);
            }
            if (!string.IsNullOrEmpty(parameters.Country))
            {
                customerAllData = customerAllData.Where(d => d.Country == parameters.Country);
            }
            if (!string.IsNullOrEmpty(parameters.Phone))
            {
                customerAllData = customerAllData.Where(d => d.Phone == parameters.Phone);
            }
            if (!string.IsNullOrEmpty(parameters.Fax))
            {
                customerAllData = customerAllData.Where(d => d.Fax == parameters.Fax);
            }

            List<Customer> queryCustomers = customerAllData.ToList();

            return queryCustomers;
        }

        public async Task<bool> Create(CustomerCreateParameters parameters)
        {
            Customer createData = _mapper.Map<Customer>(parameters);
            bool createIsSuccess = this._customerRepository.Create(createData);
            return createIsSuccess;
        }

        public async Task<bool> Update(CustomerUpdateParameters parameters)
        {
            Customer updateCustomer = _mapper.Map<Customer>(parameters);
            bool updateIsSuccess = this._customerRepository.Update(updateCustomer);
            return updateIsSuccess;
        }

        public async Task<bool> Delete(string CustomerId)
        {
            bool deleteIsSuccess = this._customerRepository.Delete(CustomerId);
            return deleteIsSuccess;
        }
    }
}
