using BAF.UseCases.Auth.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAF.UseCases.Auth
{
    public class AuthQuery: IRequest
    {
        public UserDto userDto;
        public AuthQuery(UserDto _userDto)
        {
            userDto = _userDto;
        }
    }
}
