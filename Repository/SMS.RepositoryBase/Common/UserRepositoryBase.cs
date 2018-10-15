using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SMS.Repository.Contract.Common;
using SMS.Repository.Models.Common;

namespace SMS.RepositoryBase.Common
{
    public class UserRepositoryBase : IUserRepository
    {
        SMSContext dbContext = new SMSContext();
        public User AddUser(User user)
        {
            using (dbContext)
            {
                try
                {
                    var usr = dbContext.Users.Add(user);
                    dbContext.SaveChanges();
                    return usr;
                }
                catch (Exception e)
                {
                    string msg = e.Message;
                    return null;
                }
            }
        }

        public User DeleteUser(User user)
        {
            using (dbContext)
            {
                try
                {
                    var usr = dbContext.Users.Where(x => x.Code == user.Code).Single();
                    if (usr != null)
                    {
                        dbContext.Users.Remove(usr);
                    }

                    dbContext.SaveChanges();
                    return usr;
                }
                catch (Exception e)
                {
                    string msg = e.Message;
                    return null;
                }
            }
        }

        public IList<User> GetAllUsers()
        {
            using (dbContext)
            {
                try
                {
                    return dbContext.Users.ToList();
                }
                catch (Exception e)
                {
                    string msg = e.Message;
                    return null;
                }
            }
        }

        public User GetUser(string code)
        {
            using (dbContext)
            {
                try
                {
                    return dbContext.Users.FirstOrDefault(x => x.Code == code);
                }
                catch (Exception e)
                {
                    string msg = e.Message;
                    return null;
                }
            }
        }

        public User UpdateUser(User user)
        {
            var existingUser = dbContext.Users.FirstOrDefault(x => x.Code == user.Code);
            if (existingUser != null)
            {
                dbContext.Entry(existingUser).State = EntityState.Detached;
            }

            var usr = dbContext.Users.Attach(user);
            dbContext.Entry(user).State = EntityState.Modified;
            dbContext.SaveChanges();
            return usr;
        }
    }
}
