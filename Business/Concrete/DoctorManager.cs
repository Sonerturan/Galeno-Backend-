using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Caching;
using Core.Aspects.AutoFac.Performance;
using Core.Aspects.AutoFac.Transaction;
using Core.Aspects.AutoFac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    class DoctorManager : IDoctorService
    {
        IDoctorDal _doctorDal;

        public DoctorManager(IDoctorDal doctorDal)
        {
            _doctorDal = doctorDal;
        }

        public DoctorManager()
        {

        }

        //Key,value
        [CacheAspect]
        public IDataResult<List<Doctor>> GetAll()
        {
            return new SuccessDataResult<List<Doctor>>(_doctorDal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<Doctor>> GetAllByCityId(int id)
        {
            return new SuccessDataResult<List<Doctor>>(_doctorDal.GetAll(d => d.CityId == id));
        }

        [CacheAspect]
        //bu metodun çalışması 5 sn yi geçerse beni uyar
        //performansaspect yapınca kod çalışmıyor
        //[PerformanceAspect(15)]
        public IDataResult<Doctor> GetById(int id)
        {
            return new SuccessDataResult<Doctor>(_doctorDal.Get(d => d.DoctorId == id));
        }


        public IDataResult<List<DoctorDetailDto>> GetDoctorDetails()
        {
            return new SuccessDataResult<List<DoctorDetailDto>>(_doctorDal.GetDoctorDetails(), Messages.Listed);
        }

        public IDataResult<List<DoctorDetailDto>> GetDoctorSearch(string language, string branch, string city)
        {
            return new SuccessDataResult<List<DoctorDetailDto>>(_doctorDal.GetDoctorSearch(language,branch,city), Messages.Listed);
        }

        //claim (yetkilendirme işlemlerine denir)
        [SecuredOperation("doctor.add,admin")]
        [ValidationAspect(typeof(DoctorValidator))]
        [CacheRemoveAspect("IDoctorService.Get")]
        public IResult Add(Doctor doctor)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }
            _doctorDal.Add(doctor);
            return new SuccessResult(Messages.Added);

        }


        [ValidationAspect(typeof(DoctorValidator))]
        //güncelleme olduğunda cache deki veriyi sileriz çünkü değişmiştir yeniden kullanuılırsa yeni hali cache lensin diye
        [CacheRemoveAspect("IDoctorService.Get")]
        public IResult Update(Doctor doctor)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }
            _doctorDal.Update(doctor);
            return new SuccessResult(Messages.Updated);
        }

        //güncelleme olduğunda cache deki veriyi sileriz çünkü değişmiştir yeniden kullanuılırsa yeni hali cache lensin diye
        [CacheRemoveAspect("IDoctorService.Get")]
        public IResult Delete(Doctor doctor)
        {
            _doctorDal.Delete(doctor);
            return new SuccessResult(Messages.Deleted);
        }


        //'bir kategoride en fazla 10 ürün olabilir'? kodu nasıl yazılır?
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            //select (*) from products Where categoryid=1  alttaki yazılı kod bunu çalıştırır
            var result = _doctorDal.GetAll(p => p.CityId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.CountOfCategoryError);
            }
            return new SuccessResult();
        }
        //aynı isimde ürün eklenemez kodu nasıl yazılır
        private IResult CheckIfProductExists(string doctorName)
        {
            var result = _doctorDal.GetAll(p => p.DoctorName == doctorName).Any();
            if (result)
            {
                return new ErrorResult(Messages.NameAlreadyExists);
            }
            return new SuccessResult();
        }
        //mevcut kategori sayısı 15i geçtiyse sisteme yeni ürün eklenemez kodu nasıl yazılır


        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Doctor doctor)
        {
            return null;
        }
    }
}
