using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAF.UseCases.Auth.Dto
{
    public class UserDto
    {
        public string AuthId { get; set; }
        public string ApiKeyHash { get; set; }
        public string ApiSecretValueHash { get; set; }
    }
}
