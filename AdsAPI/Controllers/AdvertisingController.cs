using AdsAPI.DataAccess;
using AdsAPI.DataAccess.Entity;
using AdsAPI.DataAccess.ValidationRules;
using AdsAPI.DTOs;
using AdsAPI.Helper;
using AdsAPI.Models;
using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdsAPI.Controllers
{
    [Route("api/Advertising/")]
    [ApiController]
    public class AdvertisingController : ControllerBase
    {

        private readonly Context context;
        private readonly IMapper mapping;

        public AdvertisingController(Context _context, IMapper _mapping)
        {
            context = _context;
            mapping = _mapping;       
        }


        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll([FromQuery] PaginationParams pagination)
        {
            if (context.Advertisements.Count() == 0)
                return NotFound("There isnt information");

            if (string.IsNullOrEmpty(pagination.FieldName))
                pagination.FieldName = "id";

            var lists = context.Advertisements.AsQueryable().OrderByPropertyName(pagination.FieldName, pagination.Sort).ToList();
        
            var values = lists.Skip((pagination.PageIndex - 1) * pagination.PageSize).Take(pagination.PageSize).ToList();

            var count = context.Advertisements.Count();

            var result = new Pagination<Advertisement>(pagination.PageIndex, pagination.PageSize, count, values);

            return Ok(result);
        }

      


        [HttpPost]
        [Route("Add")]
        public IActionResult Add(AdvertisementDTO advertisementDTO)
        {
            AdsValidator validatior = new AdsValidator();
            ValidationResult results = validatior.Validate(advertisementDTO);
            
            if (results.IsValid)
            {
                Advertisement advertisement = mapping.Map<Advertisement>(advertisementDTO);
                advertisement.DateCreated = DateTime.Now;

                context.Advertisements.Add(advertisement);
                context.SaveChanges();
                return Ok(advertisement.ID);
            }
            else
                return BadRequest("Error");
        }

        [HttpGet("GetByID{id}")]
        public IActionResult GetByID(int id)
        {
            var value = context.Advertisements.FirstOrDefault(x => x.ID == id);

            if (value == null)
                return NotFound("There isnt one");
            else
                return Ok(value);
        }

    }
}
