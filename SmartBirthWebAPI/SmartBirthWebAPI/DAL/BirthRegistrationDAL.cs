using SmartBirthWebAPI.Models;
using System;
using System.Collections.Generic;

namespace SmartBirthWebAPI.DAL
{
    public class BirthRegistrationDAL
    {
        private static Dictionary<long, BirthRegistration> databaseBirthRegistration = new Dictionary<long, BirthRegistration>();
        private static int databaseCounter = 2;

        static BirthRegistrationDAL()
        {
            BirthRegistration Martin = new BirthRegistration();
            Martin.BirthRegistrationCode = 400;
            Martin.NewbornName = "Martin Watson";
            var date10 = new DateTime(2020, 1, 1, 10, 40, 00);
            Martin.BirthDate = date10;
            Martin.Parent1Code = 1;
            Martin.Parent2Code = 3;

            databaseBirthRegistration.Add(1, Martin);
        }

        public void Insert(BirthRegistration BirthRegistration)
        {
            databaseCounter++;
            BirthRegistration.BirthRegistrationCode = databaseCounter;
            databaseBirthRegistration.Add(databaseCounter, BirthRegistration);
        }

        public BirthRegistration Find(int BirthRegistrationCode)
        {
            return databaseBirthRegistration[BirthRegistrationCode];
        }

        public IList<BirthRegistration> List()
        {
            return new List<BirthRegistration>(databaseBirthRegistration.Values);
        }

        public void Delete(int BirthRegistrationCode)
        {
            databaseBirthRegistration.Remove(BirthRegistrationCode);
        }

        public void Update(BirthRegistration birthRegistration)
        {
            databaseBirthRegistration[birthRegistration.BirthRegistrationCode] = birthRegistration;
        }
    }
}