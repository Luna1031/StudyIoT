using Bogus;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogusTestApp
{
    public class SampleCustomerRepository
    {
        public IEnumerable<Customer> GetCustomers()
        {
            Randomizer.Seed = new Random(123456);
            var genOrder = new Faker<Order>()
                .RuleFor(o => o.Id, Guid.NewGuid)
                .RuleFor(o => o.Date, f => f.Date.Past(1))
                .RuleFor(o => o.OrderValue, f => f.Finance.Amount(10, 10000))
                .RuleFor(O => O.Shipped, f => f.Random.Bool(0.5f));

            var getCustomer = new Faker<Customer>()
                .RuleFor(o => o.Id, Guid.NewGuid)
                .RuleFor(o => o.Name, f => f.Company.CompanyName())     /* 가상의 회사 이름들이 나옴 */
                .RuleFor(o => o.Address, f => f.Address.StreetAddress())
                .RuleFor(o => o.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(o => o.ContactName, f => f.Name.FullName())
                .RuleFor(o => o.Orders, f => genOrder.Generate(f.Random.Number(1, 2)));

            return getCustomer.Generate(10);    // 가상의 데이터 10개 생성
        }
    }
}
