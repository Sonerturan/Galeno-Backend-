using Business.Abstract;
using Business.Constans;
using Core.Aspects.AutoFac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BranchManager : IBranchService
    {
        IBranchDal _branchDal;

        public BranchManager(IBranchDal branchDal)
        {
            _branchDal = branchDal;
        }

        public BranchManager()
        {

        }

        [CacheAspect]
        public IDataResult<List<Branch>> GetAll()
        {
            return new SuccessDataResult<List<Branch>>(_branchDal.GetAll(), Messages.Listed);
        }


    }
}
