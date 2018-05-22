using Municipalities.Application.Municipalities;
using System.Collections.Generic;

namespace Municipalities.Contracts.Services.Municipalities
{
    public interface IMunicipalitiesService
    {
        void AddMunicipalities(List<MunicipalityDto> municipalitiesDto);
    }
}
