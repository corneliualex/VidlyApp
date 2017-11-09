using AutoMapper;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using VidlyApp.DTOs;
using VidlyApp.Models;
using System.Data.Entity;

namespace VidlyApp.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        //GET /api/customers
       
        public IHttpActionResult GetCustomers()
        {
            var customerDtos = _context.Customers.Include(c => c.MembershipType).ToList().Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(customerDtos);
        }


        //GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customerDto = _context.Customers.Select(Mapper.Map<Customer, CustomerDto>).SingleOrDefault(c => c.Id == id);

            if (customerDto == null)
                return NotFound();

            return Ok(customerDto);
        }

        //POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        //PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //also we can use an auto mapper
            //customerInDb.Name = customerDto.Name;
            //customerInDb.BirthDate = customerDto.BirthDate;
            //customerInDb.IsSubscribedToNewsletter = customerDto.IsSubscribedToNewsletter;
            //customerInDb.MembershipTypeId = customerDto.MembershipTypeId;

            Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);

            _context.SaveChanges();
        }

        //DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
