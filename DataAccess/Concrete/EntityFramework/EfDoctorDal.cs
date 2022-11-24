using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


///dto ile ilgili alınan hatalar için usingleri kopyalayın yeni efdal oluştururken

namespace DataAccess.Concrete.EntityFramework
{
    public class EfDoctorDal : EfEntityRepositoryBase<Doctor, GalenoContext>, IDoctorDal
    {
        public List<DoctorDetailDto> GetDoctorDetails()
        {
            using (GalenoContext context = new GalenoContext())
            {
                var result = from d in context.Doctors
                             join c in context.Cities
                             on d.CityId equals c.CityId
                             join i in context.Institutions
                             on d.InstitutionId equals i.InstitutionId
                             select new DoctorDetailDto
                             {
                                 DoctorId = d.DoctorId,
                                 DoctorName = d.DoctorName,
                                 DoctorSurname = d.DoctorSurname,
                                 Age = d.Age,
                                 MailAddress = d.MailAddress,
                                 PhoneNumber = d.PhoneNumber,
                                 CompanyName = d.CompanyName,
                                 Address = d.Address,
                                 About = d.About,
                                 Other = d.Other,
                                 Photograph = d.Photograph,
                                 CityName = c.CityName,
                                 InstitutionName = i.InstitutionName
                             };
                return result.ToList();
            }
        }
        public List<DoctorDetailDto> GetDoctorSearch(string language, string branch, string city)
        {
            if (language=="*")
            {
                language = " ";
            }
            if (branch=="*")
            {
                branch = " ";
            }
            if (city=="*")
            {
                city = " ";
            }
            using (GalenoContext context = new GalenoContext())
            {
                var result = from d in context.Doctors
                             join c in context.Cities
                             on d.CityId equals c.CityId
                             join i in context.Institutions
                             on d.InstitutionId equals i.InstitutionId
                             join bo in context.BranchOperations
                             on d.DoctorId equals bo.DoctorId
                             join b in context.Branches
                             on bo.BranchId equals b.BranchId
                             join lo in context.LanguageOperations
                             on d.DoctorId equals lo.DoctorId
                             join l in context.Languages
                             on lo.LanguageId equals l.LanguageId
                             where l.LanguageName.Contains(language)&&b.BranchName.Contains(branch)&& c.CityName.Contains(city) 
                             select new DoctorDetailDto
                             {
                                 DoctorId = d.DoctorId,
                                 DoctorName = d.DoctorName,
                                 DoctorSurname = d.DoctorSurname,
                                 Age = d.Age,
                                 MailAddress = d.MailAddress,
                                 PhoneNumber = d.PhoneNumber,
                                 CompanyName = d.CompanyName,
                                 Address = d.Address,
                                 About = d.About,
                                 Other = d.Other,
                                 Photograph = d.Photograph,
                                 CityName = c.CityName,
                                 InstitutionName = i.InstitutionName
                                
                             };
                return result.Distinct().ToList();
            }
        }
    }
}
