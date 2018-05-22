using Municipalities.Application.Municipalities;
using Municipalities.Contracts.Repositories;
using Municipalities.Contracts.Services.Municipalities;
using Municipalities.Core.Resources;
using Municipalities.Domain.Municipalities;
using System;
using System.Linq;

namespace Municipalities.Services.Municipalities
{
    public class MunicipalityTaxesService : IMunicipalityTaxesService
    {
        private readonly IRepository<MunicipalityTax> _municipalityTaxesRepository;
        private readonly IRepository<Municipality> _municipalitiesRepository;

        public MunicipalityTaxesService(IRepository<MunicipalityTax> municipalityTaxesRepository,
            IRepository<Municipality> municipalitiesRepository)
        {
            _municipalityTaxesRepository = municipalityTaxesRepository;
            _municipalitiesRepository = municipalitiesRepository;
        }

        public decimal? GetTax(string municipality, DateTime date)
        {
            var tax = _municipalityTaxesRepository
                .Query(filter: o => o.Municipality.Name == municipality && o.StartDate <= date && o.EndDate >= date,
                    orderBy: o => o.OrderBy(x => x.EndDate - x.StartDate),
                    includeProperties: "Municipality")
                .FirstOrDefault()
                ?.Value;

            return tax;
        }

        public void AddOrUpdateTax(int municipalityId, MunicipalityTaxDto municipalityTaxDto)
        {
            var municipality = _municipalitiesRepository.Query(o => o.Id == municipalityId, includeProperties: "MunicipalityTaxes").FirstOrDefault();
            if (municipality == null)
                throw new Exception(Errors.MunicipalityByIdNotFound);

            if (municipalityTaxDto.Id > 0)
            {
                var municipalityTax = municipality.GetMunicipalityTax(municipalityTaxDto.Id);
                municipalityTax.StartDate = municipalityTaxDto.StartDate;
                municipalityTax.EndDate = municipalityTaxDto.EndDate;
                municipalityTax.Value = municipalityTaxDto.Value;
                _municipalityTaxesRepository.Update(municipalityTax);
            }
            else
            {
                municipality.AddMunicipalityTax(new MunicipalityTax(municipality.Id, municipalityTaxDto.StartDate, municipalityTaxDto.EndDate, municipalityTaxDto.Value));
                _municipalitiesRepository.Update(municipality);
            }
        }
    }
}
