using MediatR;
using Modules.Auth.Shared.DTOs;
using ErrorOr;
using Modules.Auth.Application.Interface;
using Modules.Auth.Application.Mappings;

namespace Modules.Auth.Application.Users.Commands.Handlers
{
    public class CreateUserProfileCommandHandler : IRequestHandler<CreateUserProfileCommand, ErrorOr<UserDto>>
    {
        
        private readonly IAuthDbContext _dbContext;

        public CreateUserProfileCommandHandler(IAuthDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ErrorOr<UserDto>> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var userId = request.CreateUserProfileDto.Id;
            var createUserProfileDto = request.CreateUserProfileDto;

            var user = await _dbContext.Users.FindAsync(userId);

            if (user == null)
            {
                throw new Exception("User not found.");
            }

            user.FirstName = createUserProfileDto.FirstName; 
            user.MiddleName = createUserProfileDto.MiddleName;
            user.LastName = createUserProfileDto.LastName;
            user.Job = createUserProfileDto.Job;
            user.ProfilePicture = createUserProfileDto.ProfilePicture;
          
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return UserMapper.UserToUserDto(user);
        }    
      
    }
}

