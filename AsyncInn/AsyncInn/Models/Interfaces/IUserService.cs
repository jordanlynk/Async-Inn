using AsyncInn.Models.DTOs;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IUserService
    {
        public Task<UserDTO> Register(RegisterUser data, ModelStateDictionary modelState);

        public Task<UserDTO> Authenticate(string username, string password);
    }
}
