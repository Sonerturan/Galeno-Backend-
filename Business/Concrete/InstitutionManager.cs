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
    public class InstitutionManager : IInstitutionService
    {
        IInstitutionDal _institutionDal;

        public InstitutionManager(IInstitutionDal institutionDal)
        {
            _institutionDal = institutionDal;
        }

        public InstitutionManager()
        {

        }

        [CacheAspect]
        public IDataResult<List<Institution>> GetAll()
        {
            return new SuccessDataResult<List<Institution>>(_institutionDal.GetAll(), Messages.Listed);
        }


    }
}
