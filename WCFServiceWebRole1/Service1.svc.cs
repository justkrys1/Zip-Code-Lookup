using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;

namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IZip2City1
    {
        public string GetCity(string value)
        {
            try
            {
                string myCon = "Data Source=134.39.173.35;Initial Catalog=contributions;User id=demoGuest;Password=sp0kan3;";
                string myCommandString = "select city+', '+state as CityState from tblZipCodes where zip = @zip";
                SqlConnection conn = new SqlConnection(myCon);
                SqlCommand myCommand = new SqlCommand(myCommandString, conn);
                SqlDataReader myReader; ;
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@zip";
                parameter.SqlDbType = System.Data.SqlDbType.NVarChar;
                parameter.Direction = System.Data.ParameterDirection.Input;
                parameter.Value = value;
                myCommand.Parameters.Add(parameter);
                conn.Open();
                myReader = myCommand.ExecuteReader();
                myReader.Read();
                if (myReader.HasRows)
                {
                    return myReader["citystate"].ToString();
                }
                return "NO ZIP";
            }

            catch (Exception ex)
            {
                return "Error";
            }
        }
    }
}


       