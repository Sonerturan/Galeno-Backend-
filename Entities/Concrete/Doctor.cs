using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Doctor:IEntity
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }
        public int Age { get; set; }
        public string MailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string About { get; set; }
        public string Photograph { get; set; }
        public string Other { get; set; }
        public int CityId { get; set; }
        public int InstitutionId { get; set; }
    }
}
