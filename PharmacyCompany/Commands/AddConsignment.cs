using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using PharmacyCompany.Data;
using PharmacyCompany.Database;

namespace PharmacyCompany.Commands
{
    internal class AddConsignment 
        : CommandBase
    {
        protected override List<string> Options { get; } = new List<string>()
        {
            "--warehouseid",
            "--productid",
            "--quantity"
        };

        public AddConsignment(DbInteraction dbInteraction, string[] args) : base(args, dbInteraction)
        {
            _data = new Consignment();

            InitData();
        }

        public override bool Execute()
        {
            if (_data is Consignment consignment)
            {
                return _dbInteraction.CreateConsignment(consignment);
            }

            return false;
        }
    }
}
