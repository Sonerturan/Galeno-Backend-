using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBranchOperationService
    {
        IDataResult<List<BranchOperation>> GetAll();
        IDataResult<List<BranchOperation>> GetAllByDoctorId(int id);
        IDataResult<List<BranchOperation>> GetAllByBranchId(int id);
        IResult Add(BranchOperation branchOperation);
        IResult Update(BranchOperation branchOperation);
        IResult Delete(BranchOperation branchOperation);

        IDataResult<List<BranchOperationDetailDto>> GetBranchOperationDetails();
        IDataResult<List<BranchOperationDetailDto>> GetAllByDoctorIdDetails(int id);
    }
}
