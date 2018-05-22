using Municipalities.Application.Municipalities;
using System;

namespace Municipalities.Contracts.Services.Municipalities
{
    public interface IMunicipalityTaxesService
    {
        decimal? GetTax(string municipality, DateTime date);

        void AddOrUpdateTax(int municipalityId, MunicipalityTaxDto municipalityTaxDto);
    }
}
