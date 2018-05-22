using Municipalities.Core.Resources;
using System;

namespace Municipalities.Domain.Municipalities
{
    public class MunicipalityTax : Entity
    {
        private MunicipalityTax()
        { }

        public MunicipalityTax(int municipalityId, DateTime startDate, DateTime endDate, decimal value)
        {
            MunicipalityId = municipalityId;
            StartDate = startDate;
            EndDate = endDate;
            Value = value;
        }

        private DateTime _endDate;
        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                if (value < StartDate)
                    throw new Exception(Errors.EndDateCannotBeLowerThanStartDate);

                _endDate = value;
            }
        }

        public Municipality Municipality { get; set; }

        public int MunicipalityId { get; set; }

        public DateTime StartDate { get; set; }

        public decimal Value { get; set; }
    }
}
