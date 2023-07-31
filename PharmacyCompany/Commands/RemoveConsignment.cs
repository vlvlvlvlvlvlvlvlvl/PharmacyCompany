using System;
using System.Collections.Generic;
using System.Text;
using PharmacyCompany.Data;
using PharmacyCompany.Database;

namespace PharmacyCompany.Commands
{
    internal class RemoveConsignment 
        : CommandBase
    {
        protected override List<string> Options { get; } = new List<string>()
        {
            "--id"
        };

        public RemoveConsignment(DbInteraction dbInteraction, string[] args) : base(args, dbInteraction)
        {
            _data = new Consignment();
            InitData();
        }

        public override bool Execute()
        {
            if (_data is Consignment consignment)
            {
                return _dbInteraction.DeleteProduct((int)consignment.Id);
            }

            return false;
        }
    }
}
