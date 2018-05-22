using Municipalities.Application.Municipalities;
using Municipalities.Contracts.Repositories;
using Municipalities.Contracts.Services.Municipalities;
using Municipalities.Domain.Municipalities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Municipalities.Services.Municipalities
{
    public class MunicipalitiesService : IMunicipalitiesService
    {
        private readonly IRepository<Municipality> _municipalitiesRepository;

        public MunicipalitiesService(IRepository<Municipality> municipalitiesRepository)
        {
            _municipalitiesRepository = municipalitiesRepository;
        }

        public void AddMunicipalities(List<MunicipalityDto> municipalitiesDto)
        {
            foreach (var municipalityDto in municipalitiesDto)
            {
                try
                {
                    var municipality = _municipalitiesRepository.Query(o => o.Name == municipalityDto.Name).FirstOrDefault();
                    if (municipality != null)
                    {
                        foreach (var municipalityTaxDto in municipalityDto.Taxes)
                            municipality.AddMunicipalityTax(new MunicipalityTax(municipality.Id, municipalityTaxDto.StartDate, municipalityTaxDto.EndDate, municipalityTaxDto.Value));
                        _municipalitiesRepository.Update(municipality);
                    }
                    else
                    {
                        var newMunicipality = new Municipality(municipalityDto.Name);
                        foreach (var municipalityTaxDto in municipalityDto.Taxes)
                            newMunicipality.AddMunicipalityTax(new MunicipalityTax(municipality.Id, municipalityTaxDto.StartDate, municipalityTaxDto.EndDate, municipalityTaxDto.Value));

                        _municipalitiesRepository.Insert(newMunicipality);
                    }
                }
                catch (Exception)
                {
                    // TOOD: Record results which caused exceptions
                }
            }
        }
    }
}
