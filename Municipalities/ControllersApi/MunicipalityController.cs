using Microsoft.AspNetCore.Mvc;
using Municipalities.Application.Municipalities;
using Municipalities.Contracts.Services.Municipalities;
using System;
using System.Collections.Generic;

namespace Municipalities.ControllersApi
{
    public class MunicipalityController : Controller
    {
        private readonly IMunicipalitiesService _municipalitiesService;
        private readonly IMunicipalityTaxesService _municipalityTaxesService;

        public MunicipalityController(IMunicipalitiesService municipalitiesService,
            IMunicipalityTaxesService municipalityTaxesService)
        {
            _municipalitiesService = municipalitiesService;
            _municipalityTaxesService = municipalityTaxesService;
        }

        [HttpGet("[action]")]
        public IActionResult GetTax(string municipality, DateTime date)
        {
            var tax = _municipalityTaxesService.GetTax(municipality, date);

            return Ok(tax);
        }

        [HttpPost("[action]")]
        public IActionResult AddOrUpdateTax(int municipalityId, MunicipalityTaxDto municipalityTaxDto)
        {
            _municipalityTaxesService.AddOrUpdateTax(municipalityId, municipalityTaxDto);

            return Ok(municipalityTaxDto);
        }

        [HttpPost("[action]")]
        public IActionResult ImportMunicipalities()
        {
            // Lets say that this is our import from file
            var municipalities = new List<MunicipalityDto>()
            {
                new MunicipalityDto()
                {
                    Name = "Vilnius",
                    Taxes = new List<MunicipalityTaxDto>()
                    {
                        new MunicipalityTaxDto()
                        {
                            EndDate = new DateTime(2016, 12, 31),
                            StartDate = new DateTime(2016, 01, 01),
                            Value = 0.2M
                        },
                        new MunicipalityTaxDto()
                        {
                            EndDate = new DateTime(2016, 05, 31),
                            StartDate = new DateTime(2016, 05, 01),
                            Value = 0.4M
                        },
                        new MunicipalityTaxDto()
                        {
                            EndDate = new DateTime(2016, 01, 01),
                            StartDate = new DateTime(2016, 01, 01),
                            Value = 0.1M
                        },
                        new MunicipalityTaxDto()
                        {
                            EndDate = new DateTime(2016, 12, 25),
                            StartDate = new DateTime(2016, 12, 25),
                            Value = 0.1M
                        }
                    }
                }
            };

            _municipalitiesService.AddMunicipalities(municipalities);

            return Ok(municipalities);
        }
    }
}
