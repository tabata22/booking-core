using Booking.Core.Application.Employees;
using Booking.Core.Domain.EmployeeAggregate;

namespace Booking.Core.Persistence.Employees;

public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}