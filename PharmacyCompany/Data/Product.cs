namespace PharmacyCompany.Data
{
    internal class Product
        : IData
    {
        public int? Id { get; set; } = null;
        public string Title { get; set; } = string.Empty;

        public bool TrySetValueByName(string name, string value)
        {
            switch (name)
            {
                case "--id":
                    int.TryParse(value, out int res);
                    Id = res;
                    break;
                case "--title":
                    Title = value; 
                    break;
                default:
                    return false;
            }

            return true;
        }
    }
}
