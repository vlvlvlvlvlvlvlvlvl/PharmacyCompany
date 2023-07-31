using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data.SqlClient;
using PharmacyCompany.Data;
using PharmacyCompany.Database;

namespace PharmacyCompany.Commands
{
    internal class AddProduct
        : CommandBase
    {
        protected override List<string> Options { get; } = new List<string>()
        {
            "--title"
        };

        public AddProduct(DbInteraction dbInteraction, string[] args) : base(args, dbInteraction)
        {
            _data = new Product();

            InitData();
        }

        public override bool Execute() 
        {
            if (_data is Product product)
            {
                return _dbInteraction.CreateProduct(product);
            }

            return false;
        }
    }
}
