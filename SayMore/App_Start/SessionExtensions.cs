using SayMore.Logic.Database;
using SayMore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SayMore
{
    public static class SessionExtensions
    {
        public static void Set(this HttpSessionStateBase session, UsersModel value)
        {
            session["user"] = value;
        }
        public static UsersModel Get(this HttpSessionStateBase session)
        {
            return session["user"] as UsersModel;
        }
    }
}