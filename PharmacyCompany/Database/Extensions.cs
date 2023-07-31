using System;
using System.Data;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace PharmacyCompany.Database
{
    internal static class Extensions
    {
        public static DbParameter AddWithValue(this IDataParameterCollection collection, string parameterName, object value)
            => collection switch
            {
                SqlParameterCollection sqlParameter => sqlParameter.AddWithValue(parameterName, value),
                _ => throw new NotImplementedException("Данный тип параметра БД не реализован.")
            };
    }
}
