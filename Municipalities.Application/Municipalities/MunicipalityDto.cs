using System.Collections.Generic;

namespace Municipalities.Application.Municipalities
{
    public class MunicipalityDto
    {
        public int Id { get; set; }

        public List<MunicipalityTaxDto> Taxes { get; set; }

        public string Name { get; set; }
    }
}
