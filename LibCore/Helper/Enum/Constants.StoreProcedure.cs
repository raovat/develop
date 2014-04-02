using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysPro.Core.Helper.Enum
{
    /// <summary>
    /// All Store Procedure
    /// </summary>
    /// <createdby>KietNQ</createdby>
    /// <modifiedby></modifiedby>
    /// <notes></notes>
    public partial class Constants
    {
        #region Postal Code

        public const string SP_POSTALCODE_GETALL = "spPostalCode_GetAll";
        public const string SP_POSTALCODE_GETBYZIPCODE = "spPostalCode_GetByZipCode";
        public const string SP_POSTAL_GET_BY_POSTAL_CODE = "spPostal_GetByPostalCode";
        public const string SP_COUNTRY_SEARCH = "spCountry_Search";
        public const string SP_STATE_SEARCH = "spState_Search";

        #endregion

    }
}
