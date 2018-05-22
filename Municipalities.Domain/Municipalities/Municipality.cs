using Municipalities.Core.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Municipalities.Domain.Municipalities
{
    public class Municipality : Entity
    {
        private Municipality()
        { }

        public Municipality(string name)
        {
            Name = name;
            MunicipalityTaxes = new HashSet<MunicipalityTax>();
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception(Errors.MunicipalityNameCannotBeEmpty);

                _name = value;
            }
        }

        public ICollection<MunicipalityTax> MunicipalityTaxes { get; set; }

        public void AddMunicipalityTax(MunicipalityTax municipalityTax)
        {
            if (MunicipalityTaxes == null)
                MunicipalityTaxes = new List<MunicipalityTax>();

            municipalityTax.MunicipalityId = Id;

            MunicipalityTaxes.Add(municipalityTax);
        }

        public MunicipalityTax GetMunicipalityTax(int municipalityTaxId)
        {
            var municipalityTax = MunicipalityTaxes.FirstOrDefault(o => o.Id == municipalityTaxId);
            if (municipalityTax == null)
                throw new Exception(Errors.MunicipalityTaxByIdNotFound);

            return municipalityTax;
        }
    }
}
