namespace PharmacyCompany.Data
{
    internal class Pharmacy : IData
    {
        public int? Id { get; set; } = null;
        public string Title { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

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
                case "--address":
                    Address = value;
                    break;
                case "--phone":
                    Phone = value;
                    break;
                default:
                    return false;
            }

            return true;
        }
    }
}
