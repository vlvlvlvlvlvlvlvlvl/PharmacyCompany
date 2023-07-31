using System;
using System.Collections.Generic;
using System.Text;
using PharmacyCompany.Data;
using PharmacyCompany.Database;

namespace PharmacyCompany.Commands
{
    internal class RemovePharmacy
        : CommandBase
    {
        protected override List<string> Options { get; } = new List<string>()
        {
            "--title",
            "--address",
            "--phone"
        };

        public RemovePharmacy(DbInteraction dbInteraction, string[] args) : base(args, dbInteraction)
        {
            _data = new Pharmacy();

            InitData();
        }

        public override bool Execute()
        {
            if (_data is Pharmacy pharmacy)
            {
                return _dbInteraction.DeleteProduct((int)pharmacy.Id);
            }

            return false;
        }
    }
}
