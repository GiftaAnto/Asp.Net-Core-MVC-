using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAndRegister.Models
{
    public class DbOperations : IDbOperations
    {
        private readonly AppDbContext context;
        private Account account = new Account();
        public DbOperations(AppDbContext context)
        {
            this.context = context;
        }
        public Account AddAccount(string Name, string Email, string Password)
        {
            account.Email = Email;
            account.Name = Name;
            account.Password = Password;
            context.Add(account);
            context.SaveChanges();
            return account;
        }


        public Account GetAccount(string Email, string Password)
        {
            account = context.AccountTable.Find(Email);
            if (account != null && account.Password.Equals(Password))
            {
                return account;
            }
            else
            {
                return null;
            }

        }
    }
}
