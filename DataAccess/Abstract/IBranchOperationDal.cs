using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IBranchOperationDal : IEntityRepository<BranchOperation>
    {
        List<BranchOperationDetailDto> GetBranchOperationDetails(Expression<Func<BranchOperationDetailDto, bool>> filter = null);
    }
}
