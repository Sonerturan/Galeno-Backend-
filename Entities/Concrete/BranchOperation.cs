using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class BranchOperation:IEntity
    {
        public int BranchOperationId { get; set; }
        public int BranchId { get; set; }
        public int DoctorId { get; set; }
    }
}
