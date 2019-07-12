using SayMore.Logic.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayMore.Logic.Managers
{
    public class UserManager
    {
        public static Users CreateUser(Users user)
        {
            
            using (var db = new DB())
            {
            if (!db.Users.Any(m => m.Email == user.Email))
            {
                user = db.Users.Add(user);
                db.SaveChanges();
            }
                return user;
            }
            
        }
        public static Users Update(Users user)
        {
            using (var db = new DB())
            {
                var existing = db.Users.Find(user.Id);
                existing.Email = user.Email;
                existing.Name = user.Name;
                existing.Password = user.Password;

                db.SaveChanges();

                return existing;
            }

        }
        public static Users Login(string email, string password)
        {
            using (var db = new DB())
            {
                return db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            }
        }
    }
}
