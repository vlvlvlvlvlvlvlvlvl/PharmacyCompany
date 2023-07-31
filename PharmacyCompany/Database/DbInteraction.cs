using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using PharmacyCompany.Data;

namespace PharmacyCompany.Database
{
    internal abstract class DbInteraction
    {
        public string ConnectionString { get; private set; } = string.Empty;

        public DbInteraction(string connectionString)
        {
            ConnectionString = connectionString;
        }

        #region Create
        public bool CreateProduct(Product product)
        {
            try
            {
                string query = "INSERT INTO Product (Title) VALUES (@title)";

                using (var connection = Connection())
                {
                    connection.Open();

                    var command = CreateCommand(query, connection);
                    command.Parameters.AddWithValue("@title", product.Title);

                    command.ExecuteNonQuery();
                }

                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool CreatePharmacy(Pharmacy pharmacy)
        {
            try
            {
                string query = "INSERT INTO Pharmacy (Title, Address, Phone) VALUES (@title, @address, @phone)";

                using (var connection = Connection())
                {
                    connection.Open();

                    var command = CreateCommand(query, connection);
                    command.Parameters.AddWithValue("@title", pharmacy.Title);
                    command.Parameters.AddWithValue("@address", pharmacy.Address);
                    command.Parameters.AddWithValue("@phone", pharmacy.Phone);

                    command.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

            return true;
        }

        public bool CreateWarehouse(Warehouse warehouse)
        {
            try
            {
                string query = "INSERT INTO Warehouse (Title, PharmacyId) VALUES (@title, @pharmacyId)";

                using (var connection = Connection())
                {
                    connection.Open();

                    var command = CreateCommand(query, connection);
                    command.Parameters.AddWithValue("@title", warehouse.Title);
                    command.Parameters.AddWithValue("@pharmacyId", warehouse.PharmacyId);

                    command.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

            return true;
        }

        public bool CreateConsignment(Consignment consignment)
        {
            try
            {
                string query = "INSERT INTO Consignment (WarehouseId, ProductId, Quantity) VALUES (@warehouseId, @productId, @quantity)";

                using (var connection = Connection())
                {
                    connection.Open();

                    var command = CreateCommand(query, connection);
                    command.Parameters.AddWithValue("@warehouseId", consignment.WarehouseId);
                    command.Parameters.AddWithValue("@productId", consignment.ProductId);
                    command.Parameters.AddWithValue("@quantity", consignment.Quantity);

                    command.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region Delete

        public bool DeleteProduct(int ProductId)
        {
            try
            {
                string query = "DELETE FROM Product WHERE Id = @id";

                using (var connection = Connection())
                {
                    connection.Open();

                    var command = CreateCommand(query, connection);
                    command.Parameters.AddWithValue("@id", ProductId);

                    command.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

            return true;
        }

        public bool DeletePharmacy(int PharmacyId)
        {
            try
            {
                string query = "DELETE FROM Pharmacy WHERE Id = @id";

                using (var connection = Connection())
                {
                    connection.Open();

                    var command = CreateCommand(query, connection);
                    command.Parameters.AddWithValue("@id", PharmacyId);

                    command.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

            return true;
        }

        public bool DeleteWarehouse(int WarehouseId)
        {
            try
            {
                string query = "DELETE FROM Warehouse WHERE Id = @id";

                using (var connection = Connection())
                {
                    connection.Open();

                    var command = CreateCommand(query, connection);
                    command.Parameters.AddWithValue("@id", WarehouseId);

                    command.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

            return true;
        }

        public bool DeleteConsignment(int ConsignmentId)
        {
            try
            {
                string query = "DELETE FROM Consignment WHERE Id = @id";

                using (var connection = Connection())
                {
                    connection.Open();

                    var command = CreateCommand(query, connection);
                    command.Parameters.AddWithValue("@id", ConsignmentId);

                    command.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

            return true;
        }

        #endregion

        public bool GetAllProductsFromPharmacy(int PharmacyId, out List<(Product, int)> productsAndQuantity)
        {
            productsAndQuantity = new List<(Product, int)>();

            try
            {
                string query = 
                    "SELECT ProductId, Product.Title, Quantity FROM Warehouse " +
                    "INNER JOIN Consignment on WarehouseId = Warehouse.Id " +
                    "INNER JOIN Product on Product.Id = ProductId " +
                    "WHERE PharmacyId = @id";

                using (var connection = Connection())
                {
                    connection.Open();

                    var command = CreateCommand(query, connection);
                    command.Parameters.AddWithValue("@id", PharmacyId);

                    using (var reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string title = reader.GetString(1);
                            int quantity = reader.GetInt32(2);

                            productsAndQuantity.Add((new Product() { Id = id, Title = title }, quantity));
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

            return true;
        }

        protected abstract DbConnection Connection();

        protected abstract DbCommand CreateCommand(string query, DbConnection connection);
    }
}
