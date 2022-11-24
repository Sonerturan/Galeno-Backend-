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
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ExperienceManager : IExperienceService
    {
        IExperienceDal _experienceDal;

        public ExperienceManager(IExperienceDal experienceDal)
        {
            _experienceDal = experienceDal;
        }

        public ExperienceManager()
        {

        }

        //Key,value
        [CacheAspect]
        public IDataResult<List<Experience>> GetAll()
        {
            return new SuccessDataResult<List<Experience>>(_experienceDal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<Experience>> GetAllByDoctorId(int id)
        {
            return new SuccessDataResult<List<Experience>>(_experienceDal.GetAll(p => p.DoctorId == id));
        }
        
        //claim (yetkilendirme işlemlerine denir)
        [SecuredOperation("Experience.add,admin")]
        [ValidationAspect(typeof(ExperienceValidator))]
        [CacheRemoveAspect("IExperienceService.Get")]
        public IResult Add(Experience experience)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }
            _experienceDal.Add(experience);
            return new SuccessResult(Messages.Added);

        }


        [ValidationAspect(typeof(ExperienceValidator))]
        //güncelleme olduğunda cache deki veriyi sileriz çünkü değişmiştir yeniden kullanuılırsa yeni hali cache lensin diye
        [CacheRemoveAspect("IExperienceService.Get")]
        public IResult Update(Experience experience)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }
            _experienceDal.Update(experience);
            return new SuccessResult(Messages.Updated);
        }

        //güncelleme olduğunda cache deki veriyi sileriz çünkü değişmiştir yeniden kullanuılırsa yeni hali cache lensin diye
        [CacheRemoveAspect("IExperienceService.Get")]
        public IResult Delete(Experience experience)
        {
            _experienceDal.Delete(experience);
            return new SuccessResult(Messages.Deleted);
        }

    }
}
