using System.Runtime.InteropServices;

namespace PharmacyCompany.Data
{
    internal class Warehouse : IData
    {
        public int? id { get; set; } = null;
        public string Title { get; set; } = string.Empty;
        public int? PharmacyId { get; set; } = null;

        public bool TrySetValueByName(string name, string value)
        {
            switch (name)
            {
                case "--id":
                    int.TryParse(value, out int res);
                    id = res;
                    break;
                case "--title":
                    Title = value;
                    break;
                case "--pharmacyid":
                    int.TryParse(value, out res);
                    PharmacyId = res;
                    break;
                default:
                    return false;
            }

            return true;
        }
    }
}
