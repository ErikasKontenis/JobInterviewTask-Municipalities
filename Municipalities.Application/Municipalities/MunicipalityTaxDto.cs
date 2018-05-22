using System;

namespace Municipalities.Application.Municipalities
{
    public class MunicipalityTaxDto
    {
        public DateTime EndDate { get; set; }

        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public decimal Value { get; set; }
    }
}
