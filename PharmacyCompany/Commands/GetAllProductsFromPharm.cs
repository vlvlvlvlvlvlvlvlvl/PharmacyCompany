using System;
using System.Collections.Generic;
using System.Text;
using PharmacyCompany.Database;
using PharmacyCompany.Data;

namespace PharmacyCompany.Commands
{
    internal class GetAllProductsFromPharm
        : CommandBase
    {
        public List<(Product, int)> Result { get; private set; } = null;

        protected override List<string> Options { get; } = new List<string>()
        {
            "--id"
        };

        public GetAllProductsFromPharm(DbInteraction dbInteraction, string[] args) : base(args, dbInteraction)
        {
            _data = new Pharmacy();

            InitData();
        }

        public override bool Execute()
        {
            if (_data is Pharmacy pharmacy)
            {
                bool success = _dbInteraction.GetAllProductsFromPharmacy((int)pharmacy.Id, out List<(Product, int)> productsAndQuantity);
                Result = productsAndQuantity;

                return success;
            }

            return false;
        }
    }
}
