using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AdoDAL
{
    public class Logic
    {

        public static void Create(System.Object myObj, Guid myObjGuid)
        {
            using (new SqlConnection())
            {             
                SqlCommand cmd = new SqlCommand("Insert into "+myObj.GetType().ToString()+
                    "(Value) Values (@Value)", new SqlConnection());
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Value";
                param.Value = myObj;
                param.SqlDbType = SqlDbType.Variant;
                cmd.Parameters.Add(param);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    return;
                }

            }
        }
        


        static public void Update(System.Object myChangedObj, Guid myObjGuid)
        {
            using (new SqlConnection())
            {
                var cmd = new SqlCommand("Update " + myChangedObj.GetType().ToString() +
                    "set Value = @Value where ID = @ID", new SqlConnection());

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@ID";
                param.Value = myChangedObj;
                param.SqlDbType = SqlDbType.UniqueIdentifier;
                cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@Value";
                param.Value = myChangedObj;
                param.SqlDbType = SqlDbType.Variant;
                cmd.Parameters.Add(param);
            }
        }

        static public System.Object Read(System.Type myType, Guid myObjGuid)
        {
            using (new SqlConnection())
            {

                var cmd = new SqlCommand("Select * From " + myType.ToString() +
                    " where ID = @ID", new SqlConnection());

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@ID";
                param.Value = myObjGuid;
                param.SqlDbType = SqlDbType.UniqueIdentifier;
                cmd.Parameters.Add(param);


                using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        return dr.GetValue(1);
                    }
                    return null;
                }
            }
        }


        static public List<System.Object> ReadAll(System.Type myType)
        {
            List<System.Object> items = new List<System.Object>();

            using (new SqlConnection())
            {               

                var cmd = new SqlCommand("Select * From "+ myType.ToString(), new SqlConnection());

                using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (dr.Read())
                    {
                        items.Add(dr.GetValue(1));
                    }
                    return items;
                }
            }
        }


        static public void Delete(System.Type myType, Guid myGuid)
        {
            using (new SqlConnection())
            {


                SqlCommand cmd = new SqlCommand("Delete from " + myType.ToString() +
                    " where ID = @ID", new SqlConnection());

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@ID";
                param.Value = myGuid;
                param.SqlDbType = SqlDbType.UniqueIdentifier;
                cmd.Parameters.Add(param);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    return;
                }
            }
        }
    }
}
