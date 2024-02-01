using AutoMapper;
using BlazorInvoiceApp.Data;
using BlazorInvoiceApp.DTOS;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BlazorInvoiceApp.Repository
{
    public class CustomerRepository : GenericOwnedRepository<Customer, CustomerDTO>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context, IMapper mapepr)
            : base(context, mapepr) { }

        public async Task Seed(ClaimsPrincipal User)
        {
            string? userid = getMyUserId(User);
            if(userid is not null)
            {
                int count = await context.Customers.Where(c => c.UserId == userid).CountAsync();
                if(count == 0)
                {
                    CustomerDTO defaultCustomer = new CustomerDTO
                    {
                        Name = "My First Customer"
                    };
                    await AddMine(User, defaultCustomer);
                }
            }
        }
    }
}
