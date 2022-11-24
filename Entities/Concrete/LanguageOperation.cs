using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class LanguageOperation:IEntity
    {
        public int LanguageOperationId { get; set; }
        public int LanguageId { get; set; }
        public int DoctorId { get; set; }
    }
}
