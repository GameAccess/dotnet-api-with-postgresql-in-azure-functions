using Company.Function.Messages;
using Company.Function.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Kana.Core.Handlers
{
    public sealed class GetUsersRequestHandler : IRequestHandler<GetUsersRequest, GetUsersResponse>
    {
        private readonly IUsersRepository _usersRepository;

        public GetUsersRequestHandler(IUsersRepository usersRepository) =>
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));

        public async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken) =>
            new GetUsersResponse(await _usersRepository.GetUsers(cancellationToken));
    }
}