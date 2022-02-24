using AdsAPI.DataAccess.ValidationRules;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdsAPI.DataAccess.Entity
{
    public class Advertisement
    {
        [Key]
        public int ID { get; set; }
        public string Path { get; set; }
        public string Path2 { get; set; }
        public string Path3 { get; set; }
        public string AdName { get; set; }
        public string Descriptoin { get; set; }
        public double Price { get; set; }
        public DateTime DateCreated { get; set; }

       
    }
}
