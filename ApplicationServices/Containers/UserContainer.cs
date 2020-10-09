using DomainModels;
using System.Collections.Generic;
using System.Linq;
namespace ApplicationServices.Containers
{
    public static class UserContainer
    {
        private static int currentPrimaryId = 1;

        private static List<User> users { get; set; }

        static UserContainer()
        {
            initUsers();
        }

        //todo: optional pagination
        public static IEnumerable<User> GetAll() => users;

        public static User GetById(int userId)
        {
            return users.First(x => x.ID == userId);
        }

        public static User AddUser(User user)
        {
            var savingUser = new User(currentPrimaryId)
            {
                StoreID = user.StoreID,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsActive = true
            };

            users.Add(savingUser);
            currentPrimaryId++;
            return savingUser;
        }

        public static User UpdateUser(User user)
        {
            var updatingUser = users.First(x => x.ID == user.ID);

            updatingUser.StoreID = user.StoreID;
            updatingUser.Email = user.Email;
            updatingUser.FirstName = user.FirstName;
            updatingUser.LastName = user.LastName;
            updatingUser.IsActive = user.IsActive;
            return updatingUser;
        }

        public static void RemoveUser(int userId)
        {
            var removingUser = users.First(x => x.ID == userId);
            users.Remove(removingUser);
        }

        public static IEnumerable<User> GetStoreUsers(int storeId)
        {
            return users.Where(x => x.StoreID == storeId);
        }

        private static void initUsers()
        {
            users = new List<User>();

            users.AddRange(
                new List<User>() {
                    new User(currentPrimaryId++)
                    {
                        Email = "test@test.com",
                        FirstName = "Dan",
                        LastName = "Nouer",
                        IsActive = true,
                        StoreID = 1
                    },
                    new User(currentPrimaryId++)
                    {
                        Email = "nick@gmail.com",
                        FirstName = "Nick",
                        LastName = "Johnson",
                        IsActive = true,
                        StoreID = 1
                    },
                    new User(currentPrimaryId++)
                    {
                        Email = "Fred@mail.com",
                        FirstName = "Fred",
                        LastName = "Trump",
                        IsActive = true,
                        StoreID = 1
                    },
                    new User(currentPrimaryId++)
                    {
                        Email = "vasya@gmail.com",
                        FirstName = "Vasya",
                        LastName = "Petrov",
                        IsActive = true,
                        StoreID = 1
                    },
                    new User(currentPrimaryId++)
                    {
                        Email = "test5@gmail.com",
                        FirstName = "Luke",
                        LastName = "Zurge",
                        IsActive = true,
                        StoreID = 2
                    }
                }
                );
        }
    }
}
