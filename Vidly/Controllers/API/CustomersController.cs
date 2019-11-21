using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context { get; set; }

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/customers
        [HttpGet]
        public IEnumerable<CustomerDto> GetCustomers() {
        //delegate Mapper.map
          return  _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>);
        
         }

        [HttpGet]
        public  CustomerDto GetCustomer(int id) {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            
            if(customer == null) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Mapper.Map<Customer,CustomerDto>(customer);     
        
         }
         //web api framework will intitalize the action parameter her customer
         //Post /api/Post
        
        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerDto) {

            if (!ModelState.IsValid) {

               throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return customerDto;
        }
       
         [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {

            if (!ModelState.IsValid) {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customerInDb = _context.Customers.SingleOrDefault(c=>c.Id ==id);
            Mapper.Map(customerDto, customerInDb);

            //if (customerInDb != null) {

            //    customerInDb.Name = customer.Name;
            //    customerInDb.Birthdate = customer.Birthdate;
            //    customerInDb.MembershipType = customer.MembershipType;
            //    customerInDb.MembershipTypeId = customer.MembershipTypeId;
            //}
            _context.SaveChanges();

        }
        //delete /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id) {

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
    
}
