using Booking.Core.Application.Branches;
using Booking.Core.Domain.BranchAggregate;

namespace Booking.Core.Persistence.Branches;

public class BranchRepository : BaseRepository<Branch>, IBranchRepository
{
    public BranchRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}