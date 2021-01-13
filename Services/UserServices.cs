using Microsoft.Extensions.Configuration;
using TYNH_server.Models;

namespace TYNH_server.Services
{
    public class UserService : BaseService<User>
    {
        public UserService(IConfiguration config) : base(config, nameof(User))
        {

        }
    }
}