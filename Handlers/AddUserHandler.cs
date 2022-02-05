using Company.Function.Messages;
using Company.Function.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Kana.Core.Handlers
{
    public sealed class AddUserHandler : IRequestHandler<AddUserRequest, ApiResponse>
    {
        private readonly IUsersRepository _usersRepository;

        public AddUserHandler(IUsersRepository usersRepository) =>
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));

        public async Task<ApiResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            await _usersRepository.AddUser(request.FirstName, request.LastName, cancellationToken);
            return new ApiResponse();
        }
    }
}