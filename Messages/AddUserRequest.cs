using MediatR;

namespace Company.Function.Messages
{
    public class AddUserRequest : IRequest<ApiResponse>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}