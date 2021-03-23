using System;
using System.Collections.Generic;
using System.Text;
using ProjectManagment.Model;

namespace ProjectManagment.Data
{
    class UserManager
    {
        List<User> UserList = new List<User>();
        uint id = 1;
        public void AddUser(string userName,string password)
        {
            User addUser = new User
            {
                Password = password,
                UserName = userName,
                Id = id++,
            };

            UserList.Add(addUser);
        }

        public uint VerifyUser(string userName,string password)
        {
            foreach(var user in UserList)
            {
                if (user.UserName == userName && user.Password==password)
                {
                    return user.Id;
                }
            }
            return 0;
        }
    }
}
