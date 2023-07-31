namespace PharmacyCompany.Data
{
    internal class Consignment : IData
    {
        public int? Id { get; set; } = null;
        public int? WarehouseId { get; set; } = null;
        public int? ProductId { get; set; } = null;
        public int Quantity { get; set; } = 0;

        public bool TrySetValueByName(string name, string value)
        {
            int.TryParse(value, out int res);

            switch (name)
            {
                case "--id":
                    Id = res;
                    break;
                case "--warehouseid":
                    WarehouseId = res;
                    break;
                case "--productid":
                    ProductId = res;
                    break;
                case "--quantity":
                    Quantity = res;
                    break;
                default:
                    return false;
            }

            return true;
        }
    }
}
