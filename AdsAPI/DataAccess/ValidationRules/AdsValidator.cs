using AdsAPI.DataAccess.Entity;
using AdsAPI.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdsAPI.DataAccess.ValidationRules
{
    public class AdsValidator:AbstractValidator<AdvertisementDTO>
    {
        public AdsValidator()
        {
            RuleFor(x => x.AdName).NotNull().NotEmpty().WithMessage("Not Empty").Length(0, 200).WithMessage("Length must be under 200 symbols");


            RuleFor(x => x.Descriptoin).Length(0, 1000).WithMessage("Over 1000 symbols");


            RuleFor(x => x.Path).NotNull().NotEmpty().WithMessage("Not Null or Empty").Must(x => x.Contains("jpeg") || x.Contains("jpg") || x.Contains("png") );
            RuleFor(x => x.Path2).Must(x => x.Contains("jpeg") || x.Contains("jpg") || x.Contains("png") );
            RuleFor(x => x.Path3).Must(x => x.Contains("jpeg") || x.Contains("jpg") || x.Contains("png") );


        }
    }
}
