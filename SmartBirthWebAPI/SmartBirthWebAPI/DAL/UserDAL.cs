using SmartBirthWebAPI.Models;
using System;
using System.Collections.Generic;

namespace SmartBirthWebAPI.DAL
{
    public class UserDAL
    {
        private static Dictionary<long, User> databaseUser = new Dictionary<long, User>();
        private static int databaseCounter = 2;

        static UserDAL()
        {
            User Cathlyn = new User();
            Cathlyn.UserCode = 1;
            Cathlyn.Name = "Cathlyn Watson";
            Cathlyn.Rg = 12345618912;
            Cathlyn.Cpf = 12345678912;
            var date1 = new DateTime(1990, 5, 1, 8, 30, 52);
            Cathlyn.Birth = date1;

            User Carl = new User();
            Carl.UserCode = 2;
            Carl.Name = "Carl Watson";
            Carl.Rg = 12345678912;
            Carl.Cpf = 12345618912;
            var date3 = new DateTime(1990, 2, 1, 10, 30, 11);
            Carl.Birth = date3;

            BirthRegistration Sarah = new BirthRegistration();
            Sarah.BirthRegistrationCode = 800;
            Sarah.NewbornName = "Sarah Watson";
            var date2 = new DateTime(2020, 1, 1, 10, 30, 10);
            Sarah.BirthDate = date2;
            Sarah.Parent1Code = Cathlyn.UserCode = 1;
            Sarah.Parent2Code = Carl.UserCode = 3;

            Cathlyn.AddHeir(Sarah);
            Carl.AddHeir(Sarah);

            User samantha = new User();
            samantha.UserCode = 4;
            samantha.Name = "Samantha Smith";
            samantha.Rg = 12345678911;
            samantha.Cpf = 12345678910;
            var date4 = new DateTime(1980, 2, 2, 10, 20, 11);
            samantha.Birth = date4;

            databaseUser.Add(1, Cathlyn);
            databaseUser.Add(2, Carl);
            databaseUser.Add(3, samantha);
        }

        public void Insert(User User)
        {
            databaseCounter++;
            User.UserCode = databaseCounter;
            databaseUser.Add(databaseCounter, User);
        }

        public User Find(int UserCode)
        {
            return databaseUser[UserCode];
        }

        public IList<User> List()
        {
            return new List<User>(databaseUser.Values);
        }

        public void Delete(int UserCode)
        {
            databaseUser.Remove(UserCode);
        }

        public void Update(User user)
        {
            databaseUser[user.UserCode] = user;
        }
    }
}