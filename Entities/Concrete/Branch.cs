using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Branch:IEntity
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
    }
}
