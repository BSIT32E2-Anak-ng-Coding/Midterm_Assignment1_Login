using Login.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Infrastructure
{
    public User GetUserByUsername(string username)
    {
        // In a real application, you would fetch the user from a database
        // For demonstration purposes, let's create a mock user
        if (username == "admin")
        {
            return new User { Id = 1, Username = "admin", Password = "admin" };
        }
        return null;
    }
