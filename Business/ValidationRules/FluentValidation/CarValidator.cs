﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(car => car.BrandId).NotEmpty();
            RuleFor(car=> car.ColorId).NotEmpty();
            RuleFor(car => car.DailyPrice).NotEmpty();
           
            RuleFor(car => car.ModelYear).NotEmpty();
            RuleFor(car => car.Description).NotEmpty();
            
        }
    }
}
