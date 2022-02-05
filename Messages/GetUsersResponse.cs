using System.Collections.Generic;
using Company.Function.Models;

namespace Company.Function.Messages
{
    public class GetUsersResponse
    {
        public GetUsersResponse(List<User> users)
        {
            Users = users;
        }
        
        public List<User> Users { get; }
    }
}