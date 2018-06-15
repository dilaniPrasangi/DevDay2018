using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TIQRI.Devday.Context;
using TIQRI.Devday.Models;

namespace TIQRI.Devday.Data
{
    public class ExampleData
    {
        public static List<TShirtSize> GetTShirtSizes()
        {
            List<TShirtSize> tshirtSizes = new List<TShirtSize>()
            {
                new TShirtSize
                {
                    Size="XXL"
                },
                new TShirtSize
                {
                    Size="XL"
                },
                new TShirtSize
                {
                    Size="L"
                }
            };
            return tshirtSizes;
        }
        
        public static List<UserType> GetUserTypes()
        {
            List<UserType> userTypes = new List<UserType>()
            {
                new UserType
                {
                    UserTypeName="Student"
                }
            };
            return userTypes;
        }

        public static List<UserStatus> GetUserStatuses()
        {
            List<UserStatus> userStatuses = new List<UserStatus>()
            {
                new UserStatus
                {
                    UserStatusName="Enrolled"
                }
            };
            return userStatuses;
        }

        public static List<User> GetUsers(AppContext context)
        {
            List<User> userList = new List<User>()
            {
                new User
                {
                    FirstName="Shawanthi",
                    LastName="Gunadasa",
                    UserEmail="srg@tiqri.com",
                    Company ="TIQRI(Pvt) Ltd",
                    SecurityCode =000001,
                    Gender ="F",
                    ContactNumber ="0776285168",
                    UserDescription="",
                    TShirtSizeId=context.TShirtSizes.Find(2).TShirtSizeId,
                    UserStatusId=context.UserStatuses.Find(1).UserStatusId,
                    UserTypeId=context.UserTypes.Find(1).UserTypeId,

                }
            };
            return userList;
        }

    }
}