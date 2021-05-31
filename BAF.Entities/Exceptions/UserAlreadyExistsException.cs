using System;
using System.Collections.Generic;
using System.Text;

namespace BAF.Entities.Exceptions
{
    public class UserAlreadyExistsException: Exception
    {
        public UserAlreadyExistsException() : base($"The user already exists")
        {
        }
    }
}
