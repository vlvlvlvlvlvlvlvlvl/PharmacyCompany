namespace PharmacyCompany.Data
{
    internal interface IData
    {
        bool TrySetValueByName(string name, string value);
    }
}
