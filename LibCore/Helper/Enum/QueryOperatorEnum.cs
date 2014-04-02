using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysPro.Core.Helper.Enum
{
    /// <summary>
    /// Query Operator ID enum
    /// </summary>
    /// <author>PhuongNT</author>
    public enum QueryOperatorEnum
    {
        // String
        TextEqualTo  =  2,
        TextNotEqualTo  =  3,
        TextContains  =  29,
        TextDoesNotContain  =  30,
        TextStartWith  =  31,
        TextEndWith  =  32,
        TextIsEmpty = 17,
        TextNotIsEmpty = 20,
        TextIsNull = 23,
        TextNotIsNull  =  26,
        
        // Number
        NumberNotIsNull  =  27,
        NumberIsNull  =  24,
        NumberEqualTo  =  6,
        NumberLessthanOrEqual  =  7,
        NumberNotEqualTo  =  8,
        NumberGreaterthan  =  9,
        NumberGreaterthanorEqual  =  10,
        NumberLessthan  =  11,

        // Datetime
        DatetimeOn  =  12,
        DatetimeBefore  =  13,
        DatetimeAfter  =  14,
        DatetimeOnandBefore  =  15,
        DatetimeOnandAfter  =  16,
        DatetimeIsNull  =  25,
        DatetimeNotIsNull  =  28
    }
}
