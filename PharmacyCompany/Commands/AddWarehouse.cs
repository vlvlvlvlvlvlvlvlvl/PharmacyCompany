using System;
using System.Collections.Generic;
using System.Text;
using PharmacyCompany.Data;
using PharmacyCompany.Database;

namespace PharmacyCompany.Commands
{
    internal class AddWarehouse 
        : CommandBase
    {
        protected override List<string> Options { get; } = new List<string>()
        {
            "--title",
            "--pharmacyid"
        };

        public AddWarehouse(DbInteraction dbInteraction, string[] args) : base(args, dbInteraction)
        {
            _data = new Warehouse();

            InitData();
        }

        public override bool Execute()
        {
            if (_data is Warehouse warehouse)
            {
                return _dbInteraction.CreateWarehouse(warehouse);
            }

            return false;
        }
    }
}
