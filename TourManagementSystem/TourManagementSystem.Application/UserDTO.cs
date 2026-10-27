using System;
using System.Collections.Generic;
using System.Text;

namespace TourManagementSystem.Application
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }
}
