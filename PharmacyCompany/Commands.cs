//using System;
//using System.Collections.Generic;
//using System.Data.Common;
//using System.Text;
//using System.Data.SqlClient;
//using PharmacyCompany.Data;
//using PharmacyCompany.Database;

//namespace PharmacyCompany
//{
//    internal class Commands
//    {
//        private DbInteraction _dbInteraction = null;

//        public Commands()
//        {
//            SqlConnectionStringBuilder dbConnectionStringBuilder = new SqlConnectionStringBuilder
//            {
//                UserID = "sa",
//                Password = "1234",
//                InitialCatalog = "PharmacyCompany",
//                DataSource = "WINDOWS-LAPTOP\\SQLEXPRESS"
//            };

//            _dbInteraction = new MsSqlDbInteraction(dbConnectionStringBuilder.ToString());
//        }

//        #region Create
//        public void CreateProduct(string title)
//        {
//            _dbInteraction.CreateProduct(new Product() { Title = title });
//        }

//        public void CreatePharmacy(string title, string address, string phone)
//        {
//            _dbInteraction.CreatePharmacy(new Pharmacy() { Title = title, Address = address, Phone = phone });
//        }

//        public void CreateWarehouse(string title, int? pharmacyId) 
//        {
//            _dbInteraction.CreateWarehouse(new Warehouse() { Title = title, PharmacyId = pharmacyId });
//        }

//        public void CreateConsignment(int warehouseId, int productId, int quantity)
//        {
//            _dbInteraction.CreateConsignment(new Consignment() { WarehouseId = warehouseId, ProductId = productId, Quantity = quantity });
//        }
//        #endregion

//        #region Delete
//        public void DeleteProduct(int ProductId)
//        {
//            _dbInteraction.DeleteProduct(ProductId);
//        }

//        public void DeletePharmacy(int PharmacyId)
//        {
//            _dbInteraction.DeletePharmacy(PharmacyId);
//        }

//        public void DeleteWarehouse(int WarehouseId)
//        {
//            _dbInteraction.DeleteWarehouse(WarehouseId);
//        }

//        public void DeleteConsignment(int ConsignmentId)
//        {
//            _dbInteraction.DeleteConsignment(ConsignmentId);
//        }
//        #endregion

//        public List<Dictionary<Product, int>> GetAllProductsFromPharmacy(int PharmacyId)
//        {
//            _dbInteraction.GetAllProductsFromPharmacy(PharmacyId, out List<Dictionary<Product, int>> products);
//            return products;
//        }
//    }
//}
