using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Experience:IEntity
    {
        public int ExperienceId { get; set; }
        public string ExperienceName { get; set; }
        public int DoctorId { get; set; }
    }
}
