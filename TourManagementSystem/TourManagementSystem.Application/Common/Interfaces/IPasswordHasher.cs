using System;
using System.Collections.Generic;
using System.Text;
using TourManagementSystem.Domain;

namespace TourManagementSystem.Application.Common.Interfaces
{
    public interface IPasswordHasher
    {
        public String HashingPassword(String password);

        public bool VerifyPassword(User loggedUser,String password);
    }
}
