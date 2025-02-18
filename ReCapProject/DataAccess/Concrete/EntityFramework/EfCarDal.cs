﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarsContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarsContext context = new CarsContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands 
                             on c.BrandId equals b.Id
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 BrandName = b.Name,
                                 Description = c.Description
                             };
                return result.ToList();
            }
        }
    }
}
