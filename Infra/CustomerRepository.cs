using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Infra;

public class CustomerRepository : ICustomerRepository
{
    IConfiguration _configuration;

    public CustomerRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetConnection()
    {
        var connection = _configuration.GetSection("ConnectionStrings").
            GetSection("DefaultConnection").Value;

        return connection;
    }

    public async Task<ICollection<dynamic>> GetEmployees()
    {
        var connectionString = this.GetConnection();
        using (var con = new SqlConnection(connectionString))
            try
            {
                List<dynamic> customers = new List<dynamic>();
                var query = @"select	C.CustomerId, 
		                                C.CompanyName, 
		                                O.OrderId,
		                                TotalOrderAmount = Sum(Quantity * UnitPrice)

                                from	Customers as C

                                join	Orders as O 
		                                on O.CustomerId = C.CustomerId
                                join	[Order Details] as OD
		                                on O.OrderId = OD.OrderId

                                where	O.OrderDate >= '19970101'
	                                and OrderDate < '19980101'

                                group by	C.CustomerId,
			                                C.CompanyName,
			                                O.OrderId

                                having		sum(quantity*unitPrice) > 10000
                                order by	TotalOrderAmount Desc;";

                customers = con.Query(query).ToList();
                return customers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
    }
}