using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserViewModel>
    {
        private readonly DevFreelaDbContext _dbContext;

        public GetUserQueryHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users!.SingleOrDefaultAsync(x => x.Id == request.Id);

            if (user == null) return null!;

            return new UserViewModel(user.FulName, user.Email);
        }
    }
}
