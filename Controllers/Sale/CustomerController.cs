using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreWebAPI.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineStoreWebAPI.Models;
using System.Collections.Generic;

namespace OnlineStoreWebAPI.Controllers.Sale
{
    public class CustomerController : BaseController
    {
        private readonly OnlineStoreContext contex;

        public CustomerController(OnlineStoreContext context)
        {
            this.contex=context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page=1, int itemCount=5)
        {
            var customers=await contex.Customers.OrderBy(q=>q.CustomerCode)
                .Skip((page - 1) * itemCount).Take(itemCount)
                .Select(q=>new CustomerModel
                {
                    FirstName=q.FirstName,
                    LastName=q.LastName,
                    CustomerCode=q.CustomerCode,
                    Id=q.Id,
                    Mobile=q.Mobile,
                    CityId=q.CityId,
                    CityName=q.City.CityName,
                    ProvinceName=q.City.Province.Title
                }).ToListAsync();
            return Ok(customers);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CustomerModel model)
        {
            var customer = new Customer
            {
                FirstName=model.FirstName,
                LastName =model.LastName,
                Address=model.Address,
                CustomerCode=model.CustomerCode,
                Mobile=model.Mobile,
                CityId=model.CityId,
                Email=model.Email,
            };
            await contex.AddAsync(customer);
            await contex.SaveChangesAsync();
            return Ok(customer);
        }
    }
}

 