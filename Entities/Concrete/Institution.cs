using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Institution:IEntity
    {
        public int InstitutionId { get; set; }
        public string InstitutionName { get; set; }
    }
}
