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
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalSystemContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalSystemContext context = new CarRentalSystemContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join cbt in context.CarBodyTypes on c.CarBodyTypeId equals cbt.Id
                             join cl in context.Colors on c.ColorId equals cl.Id
                             join ft in context.FuelTypes on c.FuelTypeId equals ft.Id
                             join gt in context.GearTypes on c.GearTypeId equals gt.Id
                             join m in context.Models on c.ModelId equals m.Id
                             join ci in context.CarImages on c.Id equals ci.CarId

                             select new CarDetailDto
                             {
                                 CarId = c.Id, BrandName = b.BrandName, CarBodyTypeName = cbt.CarBodyTypeName,
                                 ColorName = cl.ColorName, FuelTypeName = ft.FuelTypeName, GearTypeName = gt.GearTypeName,
                                 ModelName = m.ModelName, ModelYear = c.ModelYear, DailyPrice= c.DailyPrice, 
                                 Description = c.Description, ImagePath = ci.ImagePath
                             };
                return result.ToList();
            }
        }
    }
}
