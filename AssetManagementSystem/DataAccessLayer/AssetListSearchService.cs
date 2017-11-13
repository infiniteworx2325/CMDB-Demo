using AssetManagementSystem.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssetManagementSystem.DataAccessLayer
{
    public class AssetListSearchService
    {
        public List<AssetSearch> GetAllAssetsList()
        {
            List<AssetSearch> assetListSearch = new List<AssetSearch>();
            try
            {
                
                MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();
                string connectionstring = "server=127.0.0.1;uid=root;pwd=root;database=cmdb";

                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = connectionstring;
                MySqlCommand cmd = conn.CreateCommand();
                conn.Open();
                string query = "select * from cmdb_view";
                cmd.CommandText = query;
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    AssetSearch objAssetSearch = new AssetSearch();
                    objAssetSearch.assetId = Convert.ToInt32(dataReader[0]);

                    objAssetSearch.assetCode = Convert.ToString(dataReader[1]);
                    objAssetSearch.assetName = Convert.ToString(dataReader[2]);
                    objAssetSearch.shortName = Convert.ToString(dataReader[3]);
                    //objAssetSearch.description = Convert.ToString(dataReader[4]);
                    objAssetSearch.serialNo = Convert.ToString(dataReader[4]);
                    objAssetSearch.modelNo = Convert.ToString(dataReader[5]).ToString();
                    objAssetSearch.warrantyPeriod = Convert.ToInt32(dataReader[6]);
                    objAssetSearch.vendorName = Convert.ToString(dataReader[7]);
                    objAssetSearch.vendorContact = Convert.ToString(dataReader[8]);
                    objAssetSearch.vendorEmail = Convert.ToString(dataReader[9]);
                    objAssetSearch.createdDate = Convert.ToDateTime(dataReader[10]);
                    // objAssetSearch.isActive = (Convert.ToString(dataReader[12])) == "" || (Convert.ToString(dataReader[12])) == "0" || (Convert.ToString(dataReader[12])) == null ? false : true;
                    //objAssetSearch.isDeleted = (Convert.ToString(dataReader[13])) == "" || (Convert.ToString(dataReader[13])) == "0" || (Convert.ToString(dataReader[13])) == null ? false : true;
                    objAssetSearch.isconfig = (Convert.ToString(dataReader[11])) == "" || (Convert.ToString(dataReader[11])) == "0" || (Convert.ToString(dataReader[11])) == null ? false : true;
                    objAssetSearch.isAssigned = (Convert.ToString(dataReader[12])) == "" || (Convert.ToString(dataReader[12])) == "0" || (Convert.ToString(dataReader[12])) == null ? false : true;
                    objAssetSearch.empId = Convert.ToString(dataReader[13]).ToString(null);
                    objAssetSearch.empName = Convert.ToString(dataReader[14]).ToString(null);
                    objAssetSearch.cubicalNo = Convert.ToInt32(dataReader[15] == DBNull.Value ? 0 : Convert.ToInt32(dataReader[15]));
                    objAssetSearch.contactNo = Convert.ToString(dataReader[16]).ToString(null);
                    objAssetSearch.emailId = Convert.ToString(dataReader[17]).ToString(null);

                    assetListSearch.Add(objAssetSearch);

                }
                conn.Close();

            }
            catch (Exception ex) { }
            return assetListSearch;
        }

    }
}