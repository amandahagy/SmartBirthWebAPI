using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartBirthWebAPI.Models
{
    public class User
    {
        public int UserCode { get; set; }
        public string Name { get; set; }
        public long Rg { get; set; }
        public long Cpf { get; set; }
        public DateTime Birth { get; set; }

        public List<BirthRegistration> Heirs { get; set; }

        public User()
        {
            this.Heirs = new List<BirthRegistration>();
        }

        public void AddHeir(BirthRegistration birthRegistration)
		{
            this.Heirs.Add(birthRegistration);
		}

        public void Delete(long id)
		{
            BirthRegistration birthRegistration = Heirs.FirstOrDefault(p => p.BirthRegistrationCode == id);
            Heirs.Remove(birthRegistration);
		}

        public void Update(BirthRegistration birthRegistration)
		{
            Delete(birthRegistration.BirthRegistrationCode);
            AddHeir(birthRegistration);
		}
    }
}