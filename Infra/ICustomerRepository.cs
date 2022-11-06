namespace Infra;

public interface ICustomerRepository
{
    string GetConnection();

    Task<ICollection<dynamic>> GetEmployees();
}