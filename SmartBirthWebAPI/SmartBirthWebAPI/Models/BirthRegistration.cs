using System;

using SmartBirthWebAPI.Models;

namespace SmartBirthWebAPI.Models
{
    public class BirthRegistration
    {
        public int BirthRegistrationCode { get; set; }
        public string NewbornName { get; set; }
        public DateTime BirthDate { get; set; }

        public int Parent1Code { get; set; }
        public int Parent2Code { get; set; }

        public User Parent1 { get; set; }
        public User Parent2 { get; set; }

        public BirthRegistration()
        {
        }

        public BirthRegistration(int BirthRegistrationCode, string NewbornName, DateTime BirthDate, int Parent1Code, int Parent2Code)
        {
            this.BirthRegistrationCode = BirthRegistrationCode;
            this.NewbornName = NewbornName;
            this.BirthDate = BirthDate;
            this.Parent1Code = Parent1Code;
            this.Parent2Code = Parent2Code;
        }
    }
}