using AdsAPI.DataAccess.ValidationRules;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdsAPI.DTOs
{
    [Validator(typeof(AdsValidator))]
    public class AdvertisementDTO
    {
        public string Path { get; set; }
        public string Path2 { get; set; }
        public string Path3 { get; set; }
        public string AdName { get; set; }
        public string Descriptoin { get; set; }
        public double Price { get; set; }
    }
}
