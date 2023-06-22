using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelListing.Models.UserDTO;

namespace HotelListing.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(UserLoginDTO userDTO);
        Task<string> CreateToken();
    }
}
