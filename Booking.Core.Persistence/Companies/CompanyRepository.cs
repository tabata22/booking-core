using Booking.Core.Application.Companies;
using Booking.Core.Domain.CompanyAggregate;

namespace Booking.Core.Persistence.Companies;

public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
{
    public CompanyRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}