﻿/***
 * Interface BCryptUtil, define method to EnCript and DeEnCript password
 * 
 * Created by : PhuongNT
 * Created date : 31 July 2013
 */

namespace LibCore.Security.Crypt
{
    public interface IBCriptUtil
    {
        string EnCrypt(string strNormal);
        string EnCrypt(string strNormal, int WorkFactor);
        bool CheckEnCrypt(string strNormal, string strEnCrypt);
    }
}
