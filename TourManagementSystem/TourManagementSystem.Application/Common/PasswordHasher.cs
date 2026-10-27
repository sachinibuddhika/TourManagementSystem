using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using TourManagementSystem.Application.Common.Interfaces;
using TourManagementSystem.Domain;

namespace TourManagementSystem.Application.Common
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashingPassword(string password)
        {

            if(password != null)
            {
                var hasher = new PasswordHasher<string>();

                var hashedpw = hasher.HashPassword(null, password);
                return hashedpw;
            }
            else
            {
                return "";
            }
   
        }

        public bool VerifyPassword(User loggedUser,string password)
        {
            if (password != null) {

                var hasher=new PasswordHasher<string>();

                var result = hasher.VerifyHashedPassword(null, loggedUser.Password, password);


                if (result == PasswordVerificationResult.Success) { 
                    
                    return true;
                }
                else
                {
                    return false;
                }
            
            }
            else
            {
                return false;
            }
        }
    }
}
