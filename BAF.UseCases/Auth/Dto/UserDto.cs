using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAF.UseCases.Auth.Dto
{
    public class UserDto
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string ApiKeyHash { get; set; }
        public string ApiSecretValueHash { get; set; }
    }
}
