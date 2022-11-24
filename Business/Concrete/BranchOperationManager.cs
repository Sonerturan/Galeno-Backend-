using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Caching;
using Core.Aspects.AutoFac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BranchOperationManager : IBranchOperationService
    {
        IBranchOperationDal _branchOperationDal;

        public BranchOperationManager(IBranchOperationDal branchOperationDal)
        {
            _branchOperationDal = branchOperationDal;
        }

        public BranchOperationManager()
        {

        }

        [CacheAspect]
        public IDataResult<List<BranchOperation>> GetAll()
        {
            return new SuccessDataResult<List<BranchOperation>>(_branchOperationDal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<BranchOperation>> GetAllByDoctorId(int id)
        {
            return new SuccessDataResult<List<BranchOperation>>(_branchOperationDal.GetAll(lo => lo.DoctorId == id));
        }

        public IDataResult<List<BranchOperation>> GetAllByBranchId(int id)
        {
            return new SuccessDataResult<List<BranchOperation>>(_branchOperationDal.GetAll(lo => lo.BranchId == id));
        }


        [CacheAspect]
        //bu metodun çalışması 5 sn yi geçerse beni uyar
        //performansaspect yapınca kod çalışmıyor
        //[PerformanceAspect(15)]
        public IDataResult<BranchOperation> GetById(int id)
        {
            return new SuccessDataResult<BranchOperation>(_branchOperationDal.Get(d => d.BranchOperationId == id));
        }


        public IDataResult<List<BranchOperationDetailDto>> GetBranchOperationDetails()
        {
            return new SuccessDataResult<List<BranchOperationDetailDto>>(_branchOperationDal.GetBranchOperationDetails(), Messages.Listed);
        }

        //dto lu veriler için id ye göre veri getirme
        public IDataResult<List<BranchOperationDetailDto>> GetAllByDoctorIdDetails(int id)
        {
            return new SuccessDataResult<List<BranchOperationDetailDto>>(_branchOperationDal.GetBranchOperationDetails(d => d.DoctorId == id));
        }

        //claim (yetkilendirme işlemlerine denir)
        [SecuredOperation("branch.add,admin")]
        [ValidationAspect(typeof(LanguageOperationValidator))]
        [CacheRemoveAspect("IBranchOperationService.Get")]
        public IResult Add(BranchOperation branchOperation)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }
            _branchOperationDal.Add(branchOperation);
            return new SuccessResult(Messages.Added);

        }


        [ValidationAspect(typeof(LanguageOperationValidator))]
        //güncelleme olduğunda cache deki veriyi sileriz çünkü değişmiştir yeniden kullanuılırsa yeni hali cache lensin diye
        [CacheRemoveAspect("ILanguageOperationService.Get")]
        public IResult Update(BranchOperation branchOperation)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }
            _branchOperationDal.Update(branchOperation);
            return new SuccessResult(Messages.Updated);
        }

        //güncelleme olduğunda cache deki veriyi sileriz çünkü değişmiştir yeniden kullanuılırsa yeni hali cache lensin diye
        [CacheRemoveAspect("ILanguageOperationService.Get")]
        public IResult Delete(BranchOperation branchOperation)
        {
            _branchOperationDal.Delete(branchOperation);
            return new SuccessResult(Messages.Deleted);
        }



    }
}
