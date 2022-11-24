using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IDoctorService
    {
        IDataResult<List<Doctor>> GetAll();
        IDataResult<List<Doctor>> GetAllByCityId(int id);
        IDataResult<Doctor> GetById(int id);
        IResult Add(Doctor doctor);
        IResult Update(Doctor doctor);
        IResult Delete(Doctor doctor);

        IDataResult<List<DoctorDetailDto>> GetDoctorDetails();
        IDataResult<List<DoctorDetailDto>> GetDoctorSearch(string language, string branch, string city);

        //Transaction yönetimi : uygulamalarda  tutarlılığı korumak için yapılan bir yöntemdir .
        //Örneğin: hesaplar arası para transferinde aynı süreçte iki veri tabanı işlemi var biri azalırken biri artacak
        //gönderirken güncelledi para eksildi fakat alıcı hesapta hata olursa güncellemezse gönderen hesapta iade olması lazım işlem geri alınmalıdır
        IResult AddTransactionalTest(Doctor doctor);
    }
}
