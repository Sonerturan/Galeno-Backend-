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
    public class LanguageOperationManager : ILanguageOperationService
    {
        ILanguageOperationDal _languageOperationDal;

        public LanguageOperationManager(ILanguageOperationDal languageOperationDal)
        {
            _languageOperationDal = languageOperationDal;
        }

        public LanguageOperationManager()
        {

        }

        [CacheAspect]
        public IDataResult<List<LanguageOperation>> GetAll()
        {
            return new SuccessDataResult<List<LanguageOperation>>(_languageOperationDal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<LanguageOperation>> GetAllByDoctorId(int id)
        {
            return new SuccessDataResult<List<LanguageOperation>>(_languageOperationDal.GetAll(lo => lo.DoctorId == id));
        }

        public IDataResult<List<LanguageOperation>> GetAllByLanguageId(int id)
        {
            return new SuccessDataResult<List<LanguageOperation>>(_languageOperationDal.GetAll(lo => lo.LanguageId == id));
        }

        
        [CacheAspect]
        //bu metodun çalışması 5 sn yi geçerse beni uyar
        //performansaspect yapınca kod çalışmıyor
        //[PerformanceAspect(15)]
        public IDataResult<LanguageOperation> GetById(int id)
        {
            return new SuccessDataResult<LanguageOperation>(_languageOperationDal.Get(d => d.LanguageOperationId == id));
        }


        public IDataResult<List<LanguageOperationDetailDto>> GetLanguageOperationDetails()
        {
            return new SuccessDataResult<List<LanguageOperationDetailDto>>(_languageOperationDal.GetLanguageOperationDetails(), Messages.Listed);
        }

        //dto lu veriler için id ye göre veri getirme
        public IDataResult<List<LanguageOperationDetailDto>> GetAllByDoctorIdDetails(int id)
        {
            return new SuccessDataResult<List<LanguageOperationDetailDto>>(_languageOperationDal.GetLanguageOperationDetails(d => d.DoctorId == id));
        }

        //claim (yetkilendirme işlemlerine denir)
        [SecuredOperation("language.add,admin")]
        [ValidationAspect(typeof(LanguageOperationValidator))]
        [CacheRemoveAspect("ILanguageOperationService.Get")]
        public IResult Add(LanguageOperation languageOperation)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }
            _languageOperationDal.Add(languageOperation);
            return new SuccessResult(Messages.Added);

        }


        [ValidationAspect(typeof(LanguageOperationValidator))]
        //güncelleme olduğunda cache deki veriyi sileriz çünkü değişmiştir yeniden kullanuılırsa yeni hali cache lensin diye
        [CacheRemoveAspect("ILanguageOperationService.Get")]
        public IResult Update(LanguageOperation languageOperation)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }
            _languageOperationDal.Update(languageOperation);
            return new SuccessResult(Messages.Updated);
        }

        //güncelleme olduğunda cache deki veriyi sileriz çünkü değişmiştir yeniden kullanuılırsa yeni hali cache lensin diye
        [CacheRemoveAspect("ILanguageOperationService.Get")]
        public IResult Delete(LanguageOperation languageOperation)
        {
            _languageOperationDal.Delete(languageOperation);
            return new SuccessResult(Messages.Deleted);
        }


        
    }
}
