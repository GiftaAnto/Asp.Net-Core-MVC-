using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAndRegister.Models
{
    public interface IDbOperations
    {
        Account GetAccount(string Email, string Password);
        Account AddAccount(string Name, string Email, string Password);
    }
}
