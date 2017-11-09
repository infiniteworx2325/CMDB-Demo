using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using AssetManagementSystem.Models;

namespace AssetManagementSystem.DataAccessLayer
{
    public class AssetService
    {
        public int AssetAllocation(int srNo,int assetId)
        {
            //AssetEmployee assetEmployee = new AssetEmployee();
            int result = 0;
            try
            {

                MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();
                string connectionstring = "server=127.0.0.1;uid=root;pwd=root;database=cmdb";

                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = connectionstring;
                MySqlCommand cmd = conn.CreateCommand();
                conn.Open();
                cmd.CommandText = "INSERT  INTO assetallocation (assetId,srNo) values (@assetId,@srNo); UPDATE asset set isAssigned = 1 where assetId = @assetId";
                cmd.Parameters.AddWithValue("@srNo", srNo);
                cmd.Parameters.AddWithValue("@assetId", assetId);
                result = cmd.ExecuteNonQuery();
                conn.Close();
                return result;


            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<Asset> GetAssets()
        {
            List<Asset> assetList = new List<Asset>();
            try
            {
                
                MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();
                string connectionstring = "server=127.0.0.1;uid=root;pwd=root;database=cmdb";

                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = connectionstring;
                MySqlCommand cmd = conn.CreateCommand();
                conn.Open();
                string query = "select * from asset where isAssigned = 0";
                cmd.CommandText = query;
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Asset objAsset = new Asset();
                    objAsset.assetId = Convert.ToInt32(dataReader[0]);
                    objAsset.resourceId = Convert.ToInt32(dataReader[1]);
                    objAsset.assetCode = Convert.ToString(dataReader[2]);
                    objAsset.assetName = Convert.ToString(dataReader[3]);
                    objAsset.shortName = Convert.ToString(dataReader[4]);
                    objAsset.description = Convert.ToString(dataReader[5]);
                    objAsset.serialNo = Convert.ToString(dataReader[6]);
                    objAsset.modelNo = Convert.ToString(dataReader[7]);
                    objAsset.warrantyPeriod = Convert.ToInt32(dataReader[13]);
                    objAsset.vendorName = Convert.ToString(dataReader[14]);
                    objAsset.vendorContact = Convert.ToString(dataReader[15]);
                    objAsset.vendorEmail = Convert.ToString(dataReader[16]);
                    objAsset.createdDate = Convert.ToDateTime(dataReader[17]);
                    objAsset.isActive = (Convert.ToString(dataReader[18])) == "" || (Convert.ToString(dataReader[18])) == "0" || (Convert.ToString(dataReader[18])) == null ? false : true;
                    objAsset.isDeleted = (Convert.ToString(dataReader[19])) == "" || (Convert.ToString(dataReader[19])) == "0" || (Convert.ToString(dataReader[19])) == null ? false : true;

                    assetList.Add(objAsset);

                }
                conn.Close();

            }
            catch (Exception ex) { }
            return assetList;
        }



        public int AddHardwareAsset(Hardware hardware)
        {
            int result = 0;
            try
            {

                MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();
                string connectionstring = "server=127.0.0.1;uid=root;pwd=root;database=cmdb";

                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = connectionstring;
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from asset where serialNo=@serialNo";
                cmd.Parameters.AddWithValue("@serialNo", hardware.serialNo);
                //  cmd.Parameters.AddWithValue("@Name", HModel.Name);
                MySqlDataReader reader = cmd.ExecuteReader();

                //if (hardware.createdDate > DateTime.Today)
                //{
                //    Console.WriteLine("Wronge date");
                //}

                if (Convert.ToInt32(reader.HasRows) > 0)
                {
                    result = 0;
                    conn.Close();

                }
                else if (hardware.createdDate > DateTime.Today)
                {
                    Console.WriteLine("Wronge date");

                }
                else
                {
                    conn.Close();
                    conn.Open();
                    cmd.CommandText = "INSERT INTO asset(assetid,resourceId,assetCode,assetName,shortName,description," +
                        "serialNo,modelNo,softwareVersion,softwareType,licenceClass,licenceNumber,licenceKey," +
                        "warrantyPeriod,vendorName,vendorContact,vendorEmail,createdDate,isActive,isDeleted,isAssigned) values(@assetid,@resourceId,@assetCode,@assetName,@shortName,@description,@serialNo,@modelNo,@softwareVersion,@softwareType,@licenceClass,@licenceNumber,@licenceKey,@warrantyPeriod,@vendorName,@vendorContact,@vendorEmail,@createdDate,@isActive,@isDeleted,@isAssigned)";
                    cmd.Parameters.AddWithValue("@assetid", hardware.assetId);
                    cmd.Parameters.AddWithValue("@resourceId", hardware.resourceId);
                    cmd.Parameters.AddWithValue("@assetCode", hardware.assetCode);
                    cmd.Parameters.AddWithValue("@assetName", hardware.assetName);
                    cmd.Parameters.AddWithValue("@shortName", hardware.shortName);
                    cmd.Parameters.AddWithValue("@description", hardware.description);
                    cmd.Parameters.AddWithValue("@serialNo", hardware.serialNo);
                    cmd.Parameters.AddWithValue("@modelNo", hardware.modelNo);
                    cmd.Parameters.AddWithValue("@softwareVersion", string.Empty);
                    cmd.Parameters.AddWithValue("@softwareType", string.Empty);
                    cmd.Parameters.AddWithValue("@licenceClass", string.Empty);
                    cmd.Parameters.AddWithValue("@licenceNumber", string.Empty);
                    cmd.Parameters.AddWithValue("@licenceKey", string.Empty);
                    cmd.Parameters.AddWithValue("@warrantyPeriod", hardware.warrantyPeriod);
                    cmd.Parameters.AddWithValue("@vendorName", hardware.vendorName);
                    cmd.Parameters.AddWithValue("@vendorContact", hardware.vendorContact);
                    cmd.Parameters.AddWithValue("@vendorEmail", hardware.vendorEmail);
                    cmd.Parameters.AddWithValue("@createdDate", hardware.createdDate);
                    cmd.Parameters.AddWithValue("@isActive", 1);
                    cmd.Parameters.AddWithValue("@isDeleted", 0);
                    cmd.Parameters.AddWithValue("@isAssigned", 0);
                    result = cmd.ExecuteNonQuery();

                    conn.Close();

                }
            }
            catch (Exception ex) { }
            return result;
        }

        //public Hardware  Get(int assetid)
        //{
        //    throw new NotImplementedException();
        //}

        public List<Hardware> GetHardwares()
        {
            List<Hardware> hardwares = new List<Hardware>();
            try
            {
                MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();
                string connectionstring = "server=127.0.0.1;uid=root;pwd=root;database=cmdb";

                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = connectionstring;
                MySqlCommand cmd = conn.CreateCommand();
                conn.Open();
                string query = "select * from asset where resourceId=1 AND IsDeleted = 0";
                cmd.CommandText = query;
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Hardware hardwareAsset = new Hardware();
                    hardwareAsset.assetId = Convert.ToInt32(dataReader[0]);
                    hardwareAsset.resourceId = Convert.ToInt32(dataReader[1]);
                    hardwareAsset.assetCode = Convert.ToString(dataReader[2]);
                    hardwareAsset.assetName = Convert.ToString(dataReader[3]);
                    hardwareAsset.shortName = Convert.ToString(dataReader[4]);
                    hardwareAsset.description = Convert.ToString(dataReader[5]);
                    hardwareAsset.serialNo = Convert.ToString(dataReader[6]);
                    hardwareAsset.modelNo = Convert.ToString(dataReader[7]);
                    hardwareAsset.warrantyPeriod = Convert.ToInt32(dataReader[13]);
                    hardwareAsset.vendorName = Convert.ToString(dataReader[14]);
                    hardwareAsset.vendorContact = Convert.ToString(dataReader[15]);
                    hardwareAsset.vendorEmail = Convert.ToString(dataReader[16]);
                    hardwareAsset.createdDate = Convert.ToDateTime(dataReader[17]);
                    hardwareAsset.isActive = (Convert.ToString(dataReader[18])) == "" || (Convert.ToString(dataReader[18])) == "0" || (Convert.ToString(dataReader[18])) == null ? false : true;
                    hardwareAsset.isDeleted = (Convert.ToString(dataReader[19])) == "" || (Convert.ToString(dataReader[19])) == "0" || (Convert.ToString(dataReader[19])) == null ? false : true;
                    hardwareAsset.isAssigned = (Convert.ToString(dataReader[19])) == "" || (Convert.ToString(dataReader[19])) == "0" || (Convert.ToString(dataReader[19])) == null ? false : true;

                    hardwares.Add(hardwareAsset);

                }
                conn.Close();

            }
            catch (Exception ex) { }
            return hardwares;
        }
        public int UpdateHardware(Hardware hardware)
        {
            int result = 0;
            try
            {

                MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();
                string connectionstring = "server=127.0.0.1;uid=root;pwd=root;database=cmdb";

                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = connectionstring;
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                //  cmd.Parameters.AddWithValue("@Name", HModel.Name);

                cmd.CommandText = "Update asset set assetCode= @assetCode,assetName=@assetName,shortName=@shortName," +
                                    "description = @description,serialNo=@serialNo,modelNo=@modelNo,softwareVersion=@softwareVersion," +
                                    "softwareType=@softwareType,licenceClass=@licenceClass,licenceNumber=@licenceNumber,licenceKey=@licenceKey" +
                                    ",warrantyPeriod=@warrantyPeriod,vendorName=@vendorName,vendorContact=@vendorContact,vendorEmail=@vendorEmail,createdDate=@createdDate where assetid=@assetid";

                //cmd.Parameters.AddWithValue("@assetid", hardware.assetId);
                //cmd.Parameters.AddWithValue("@resourceId", hardware.resourceId);
                cmd.Parameters.AddWithValue("@assetCode", hardware.assetCode);
                cmd.Parameters.AddWithValue("@assetName", hardware.assetName);
                cmd.Parameters.AddWithValue("@shortName", hardware.shortName);
                cmd.Parameters.AddWithValue("@description", hardware.description);
                cmd.Parameters.AddWithValue("@serialNo", hardware.serialNo);
                cmd.Parameters.AddWithValue("@modelNo", hardware.modelNo);
                cmd.Parameters.AddWithValue("@softwareVersion", string.Empty);
                cmd.Parameters.AddWithValue("@softwareType", string.Empty);
                cmd.Parameters.AddWithValue("@licenceClass", string.Empty);
                cmd.Parameters.AddWithValue("@licenceNumber", string.Empty);
                cmd.Parameters.AddWithValue("@licenceKey", string.Empty);
                cmd.Parameters.AddWithValue("@warrantyPeriod", hardware.warrantyPeriod);
                cmd.Parameters.AddWithValue("@vendorName", hardware.vendorName);
                cmd.Parameters.AddWithValue("@vendorContact", hardware.vendorContact);
                cmd.Parameters.AddWithValue("@vendorEmail", hardware.vendorEmail);
                cmd.Parameters.AddWithValue("@createdDate", hardware.createdDate);
                cmd.Parameters.AddWithValue("@assetid", hardware.assetId);
                //cmd.Parameters.AddWithValue("@isActive", 1);
                //cmd.Parameters.AddWithValue("@isDeleted", 0);
                result = cmd.ExecuteNonQuery();

                conn.Close();
                return result;
            }

            catch (Exception ex) { }
            return result;
        }
        public int SoftDeleteHardware(int assetId)
        {
            int result = 0;
            try
            {

                MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();
                string connectionstring = "server=127.0.0.1;uid=root;pwd=root;database=cmdb";

                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = connectionstring;
                MySqlCommand cmd = conn.CreateCommand();
                conn.Open();
                cmd.CommandText = "Update asset set isDeleted = 1 where assetid=@assetid";
                cmd.Parameters.AddWithValue("@assetid", assetId);
                result = cmd.ExecuteNonQuery();
                conn.Close();
                return result;


            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public Hardware GetHardware(int assetId)
        {
            Hardware hardwareAsset = new Hardware();
            try
            {

                MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();
                string connectionstring = "server=127.0.0.1;uid=root;pwd=root;database=cmdb";

                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = connectionstring;
                MySqlCommand cmd = conn.CreateCommand();
                conn.Open();
                string query = "select * from asset where assetid=@assetId ";
                cmd.Parameters.AddWithValue("@assetId", assetId);
                cmd.CommandText = query;
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {

                    hardwareAsset.assetId = Convert.ToInt32(dataReader[0]);
                    hardwareAsset.resourceId = Convert.ToInt32(dataReader[1]);
                    hardwareAsset.assetCode = Convert.ToString(dataReader[2]);
                    hardwareAsset.assetName = Convert.ToString(dataReader[3]);
                    hardwareAsset.shortName = Convert.ToString(dataReader[4]);
                    hardwareAsset.description = Convert.ToString(dataReader[5]);
                    hardwareAsset.serialNo = Convert.ToString(dataReader[6]);
                    hardwareAsset.modelNo = Convert.ToString(dataReader[7]);
                    hardwareAsset.warrantyPeriod = Convert.ToInt32(dataReader[13]);
                    hardwareAsset.vendorName = Convert.ToString(dataReader[14]);
                    hardwareAsset.vendorContact = Convert.ToString(dataReader[15]);
                    hardwareAsset.vendorEmail = Convert.ToString(dataReader[16]);
                    hardwareAsset.createdDate = Convert.ToDateTime(dataReader[17]);
                    hardwareAsset.isActive = (Convert.ToString(dataReader[18])) == "" || (Convert.ToString(dataReader[18])) == "0" || (Convert.ToString(dataReader[18])) == null ? false : true;
                    hardwareAsset.isDeleted = (Convert.ToString(dataReader[19])) == "" || (Convert.ToString(dataReader[19])) == "0" || (Convert.ToString(dataReader[19])) == null ? false : true;



                }
                conn.Close();

            }
            catch (Exception ex) { }

            return hardwareAsset;
        }




        /////////////////////////////////////////////////////////Software Code////////////////////////////



        public int AddSoftwareAsset(Software software)
        {
            int result = 0;
            try
            {

                MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();
                string connectionstring = "server=127.0.0.1;uid=root;pwd=root;database=cmdb";

                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = connectionstring;
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from asset where serialNo=@serialNo";
                cmd.Parameters.AddWithValue("@serialNo", software.serialNo);
                //  cmd.Parameters.AddWithValue("@Name", HModel.Name);
                MySqlDataReader reader = cmd.ExecuteReader();



                if (Convert.ToInt32(reader.HasRows) > 0)
                {
                    result = 0;
                    conn.Close();

                }
                else
                {
                    conn.Close();
                    conn.Open();
                    cmd.CommandText = "INSERT INTO asset(assetid,resourceId,assetCode,assetName,shortName,description," +
                        "serialNo,modelNo,softwareVersion,softwareType,licenceClass,licenceNumber,licenceKey," +
                        "warrantyPeriod,vendorName,vendorContact,vendorEmail,createdDate,isActive,isDeleted,isAssigned) values(@assetid,@resourceId,@assetCode,@assetName,@shortName,@description,@serialNo,@modelNo,@softwareVersion,@softwareType,@licenceClass,@licenceNumber,@licenceKey,@warrantyPeriod,@vendorName,@vendorContact,@vendorEmail,@createdDate,@isActive,@isDeleted,@isAssigned)";
                    cmd.Parameters.AddWithValue("@assetid", software.assetId);
                    cmd.Parameters.AddWithValue("@resourceId", software.resourceId);
                    cmd.Parameters.AddWithValue("@assetCode", software.assetCode);
                    cmd.Parameters.AddWithValue("@assetName", software.assetName);
                    cmd.Parameters.AddWithValue("@shortName", software.shortName);
                    cmd.Parameters.AddWithValue("@description", software.description);
                    cmd.Parameters.AddWithValue("@serialNo", software.serialNo);
                    cmd.Parameters.AddWithValue("@modelNo", string.Empty);
                    cmd.Parameters.AddWithValue("@softwareVersion", software.softwareVersion);
                    cmd.Parameters.AddWithValue("@softwareType", software.softwareType);
                    cmd.Parameters.AddWithValue("@licenceClass", software.licenceClass);
                    cmd.Parameters.AddWithValue("@licenceNumber", software.licenceNumber);
                    cmd.Parameters.AddWithValue("@licenceKey", software.licenceKey);
                    cmd.Parameters.AddWithValue("@warrantyPeriod", software.warrantyPeriod);
                    cmd.Parameters.AddWithValue("@vendorName", software.vendorName);
                    cmd.Parameters.AddWithValue("@vendorContact", software.vendorContact);
                    cmd.Parameters.AddWithValue("@vendorEmail", software.vendorEmail);
                    cmd.Parameters.AddWithValue("@createdDate", software.createdDate);
                    cmd.Parameters.AddWithValue("@isActive", 1);
                    cmd.Parameters.AddWithValue("@isDeleted", 0);
                    cmd.Parameters.AddWithValue("@isAssigned", 0);
                    result = cmd.ExecuteNonQuery();

                    conn.Close();
                    return result;
                }
            }
            catch (Exception ex) { }
            return 0;
        }

        //public Hardware  Get(int assetid)
        //{
        //    throw new NotImplementedException();
        //}

        public List<Software> GetSoftwares()
        {
            List<Software> software = new List<Software>();
            try
            {
                MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();
                string connectionstring = "server=127.0.0.1;uid=root;pwd=root;database=cmdb";

                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = connectionstring;
                MySqlCommand cmd = conn.CreateCommand();
                conn.Open();
                string query = "select * from asset where resourceId=2 AND IsDeleted = 0";
                cmd.CommandText = query;
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Software softwareAsset = new Software();
                    softwareAsset.assetId = Convert.ToInt32(dataReader[0]);
                    softwareAsset.resourceId = Convert.ToInt32(dataReader[1]);
                    softwareAsset.assetCode = Convert.ToString(dataReader[2]);
                    softwareAsset.assetName = Convert.ToString(dataReader[3]);
                    softwareAsset.shortName = Convert.ToString(dataReader[4]);
                    softwareAsset.description = Convert.ToString(dataReader[5]);
                    softwareAsset.serialNo = Convert.ToString(dataReader[6]);
                    softwareAsset.softwareVersion = Convert.ToString(dataReader[8]);
                    softwareAsset.softwareType = Convert.ToString(dataReader[9]);
                    softwareAsset.licenceClass = Convert.ToString(dataReader[10]);
                    softwareAsset.licenceNumber = Convert.ToString(dataReader[11]);
                    softwareAsset.licenceKey = Convert.ToString(dataReader[12]);
                    softwareAsset.warrantyPeriod = Convert.ToInt32(dataReader[13]);
                    softwareAsset.vendorName = Convert.ToString(dataReader[14]);
                    softwareAsset.vendorContact = Convert.ToString(dataReader[15]);
                    softwareAsset.vendorEmail = Convert.ToString(dataReader[16]);
                    softwareAsset.createdDate = Convert.ToDateTime(dataReader[17]);
                    softwareAsset.isActive = (Convert.ToString(dataReader[18])) == "" || (Convert.ToString(dataReader[18])) == "0" || (Convert.ToString(dataReader[18])) == null ? false : true;
                    softwareAsset.isDeleted = (Convert.ToString(dataReader[19])) == "" || (Convert.ToString(dataReader[19])) == "0" || (Convert.ToString(dataReader[19])) == null ? false : true;
                    softwareAsset.isAssigned = (Convert.ToString(dataReader[19])) == "" || (Convert.ToString(dataReader[19])) == "0" || (Convert.ToString(dataReader[19])) == null ? false : true;

                    software.Add(softwareAsset);

                }
                conn.Close();

            }
            catch (Exception ex) { }
            return software;
        }
        public int UpdateSoftware(Software software)
        {
            int result = 0;
            try
            {

                MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();
                string connectionstring = "server=127.0.0.1;uid=root;pwd=root;database=cmdb";

                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = connectionstring;
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                //  cmd.Parameters.AddWithValue("@Name", HModel.Name);

                cmd.CommandText = "Update asset set assetCode= @assetCode,assetName=@assetName,shortName=@shortName," +
                                    "description = @description,serialNo=@serialNo,modelNo=@modelNo,softwareVersion=@softwareVersion," +
                                    "softwareType=@softwareType,licenceClass=@licenceClass,licenceNumber=@licenceNumber,licenceKey=@licenceKey" +
                                    ",warrantyPeriod=@warrantyPeriod,vendorName=@vendorName,vendorContact=@vendorContact,vendorEmail=@vendorEmail,createdDate=@createdDate where assetid=@assetid";

                //cmd.Parameters.AddWithValue("@assetid", hardware.assetId);
                //cmd.Parameters.AddWithValue("@resourceId", hardware.resourceId);
                cmd.Parameters.AddWithValue("@assetCode", software.assetCode);
                cmd.Parameters.AddWithValue("@assetName", software.assetName);
                cmd.Parameters.AddWithValue("@shortName", software.shortName);
                cmd.Parameters.AddWithValue("@description", software.description);
                cmd.Parameters.AddWithValue("@serialNo", software.serialNo);
                cmd.Parameters.AddWithValue("@modelNo", string.Empty);
                cmd.Parameters.AddWithValue("@softwareVersion", software.softwareVersion);
                cmd.Parameters.AddWithValue("@softwareType", software.softwareType);
                cmd.Parameters.AddWithValue("@licenceClass", software.licenceClass);
                cmd.Parameters.AddWithValue("@licenceNumber", software.licenceNumber);
                cmd.Parameters.AddWithValue("@licenceKey", software.licenceKey);
                cmd.Parameters.AddWithValue("@warrantyPeriod", software.warrantyPeriod);
                cmd.Parameters.AddWithValue("@vendorName", software.vendorName);
                cmd.Parameters.AddWithValue("@vendorContact", software.vendorContact);
                cmd.Parameters.AddWithValue("@vendorEmail", software.vendorEmail);
                cmd.Parameters.AddWithValue("@createdDate", software.createdDate);
                cmd.Parameters.AddWithValue("@assetid", software.assetId);
                //cmd.Parameters.AddWithValue("@isActive", 1);
                //cmd.Parameters.AddWithValue("@isDeleted", 0);
                result = cmd.ExecuteNonQuery();

                conn.Close();
                return result;
            }

            catch (Exception ex) { }
            return result;
        }
        public int SoftDeleteSoftware(int assetId)
        {
            int result = 0;
            try
            {

                MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();
                string connectionstring = "server=127.0.0.1;uid=root;pwd=root;database=cmdb";

                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = connectionstring;
                MySqlCommand cmd = conn.CreateCommand();
                conn.Open();
                cmd.CommandText = "Update asset set isDeleted = 1 where assetid=@assetid";
                cmd.Parameters.AddWithValue("@assetid", assetId);
                result = cmd.ExecuteNonQuery();
                conn.Close();
                return result;


            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public Software GetSoftware(int assetId)
        {
            Software softwareAsset = new Software();
            try
            {

                MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();
                string connectionstring = "server=127.0.0.1;uid=root;pwd=root;database=cmdb";

                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = connectionstring;
                MySqlCommand cmd = conn.CreateCommand();
                conn.Open();
                string query = "select * from asset where assetid=@assetId ";
                cmd.Parameters.AddWithValue("@assetId", assetId);
                cmd.CommandText = query;
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {

                    softwareAsset.assetId = Convert.ToInt32(dataReader[0]);
                    softwareAsset.resourceId = Convert.ToInt32(dataReader[1]);
                    softwareAsset.assetCode = Convert.ToString(dataReader[2]);
                    softwareAsset.assetName = Convert.ToString(dataReader[3]);
                    softwareAsset.shortName = Convert.ToString(dataReader[4]);
                    softwareAsset.description = Convert.ToString(dataReader[5]);
                    softwareAsset.serialNo = Convert.ToString(dataReader[6]);
                    softwareAsset.softwareVersion = Convert.ToString(dataReader[8]);
                    softwareAsset.softwareType = Convert.ToString(dataReader[9]);
                    softwareAsset.licenceClass = Convert.ToString(dataReader[10]);
                    softwareAsset.licenceNumber = Convert.ToString(dataReader[11]);
                    softwareAsset.licenceKey = Convert.ToString(dataReader[12]);
                    softwareAsset.warrantyPeriod = Convert.ToInt32(dataReader[13]);
                    softwareAsset.vendorName = Convert.ToString(dataReader[14]);
                    softwareAsset.vendorContact = Convert.ToString(dataReader[15]);
                    softwareAsset.vendorEmail = Convert.ToString(dataReader[16]);
                    softwareAsset.createdDate = Convert.ToDateTime(dataReader[17]);
                    softwareAsset.isActive = (Convert.ToString(dataReader[18])) == "" || (Convert.ToString(dataReader[18])) == "0" || (Convert.ToString(dataReader[18])) == null ? false : true;
                    softwareAsset.isDeleted = (Convert.ToString(dataReader[19])) == "" || (Convert.ToString(dataReader[19])) == "0" || (Convert.ToString(dataReader[19])) == null ? false : true;



                }
                conn.Close();

            }
            catch (Exception ex) { }

            return softwareAsset;
        }

        //////////////////////////////////OTHER CODE


        public int AddOtherAsset(Other other)
        {
            int result = 0;
            try
            {

                MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();
                string connectionstring = "server=127.0.0.1;uid=root;pwd=root;database=cmdb";

                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = connectionstring;
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from asset where serialNo=@serialNo";
                cmd.Parameters.AddWithValue("@serialNo", other.serialNo);
                //  cmd.Parameters.AddWithValue("@Name", HModel.Name);
                MySqlDataReader reader = cmd.ExecuteReader();



                if (Convert.ToInt32(reader.HasRows) > 0)
                {
                    result = 0;
                    conn.Close();

                }
                else
                {
                    conn.Close();
                    conn.Open();
                    cmd.CommandText = "INSERT INTO asset(assetid,resourceId,assetCode,assetName,shortName,description," +
                        "serialNo,modelNo,softwareVersion,softwareType,licenceClass,licenceNumber,licenceKey," +
                        "warrantyPeriod,vendorName,vendorContact,vendorEmail,createdDate,isActive,isDeleted) values(@assetid,@resourceId,@assetCode,@assetName,@shortName,@description,@serialNo,@modelNo,@softwareVersion,@softwareType,@licenceClass,@licenceNumber,@licenceKey,@warrantyPeriod,@vendorName,@vendorContact,@vendorEmail,@createdDate,@isActive,@isDeleted)";
                    cmd.Parameters.AddWithValue("@assetid", other.assetId);
                    cmd.Parameters.AddWithValue("@resourceId", other.resourceId);
                    cmd.Parameters.AddWithValue("@assetCode", other.assetCode);
                    cmd.Parameters.AddWithValue("@assetName", other.assetName);
                    cmd.Parameters.AddWithValue("@shortName", other.shortName);
                    cmd.Parameters.AddWithValue("@description", other.description);
                    cmd.Parameters.AddWithValue("@createdDate", other.createdDate);
                    cmd.Parameters.AddWithValue("@serialNo", other.serialNo);
                    cmd.Parameters.AddWithValue("@modelNo", string.Empty);
                    cmd.Parameters.AddWithValue("@softwareVersion", string.Empty);
                    cmd.Parameters.AddWithValue("@softwareType", string.Empty);
                    cmd.Parameters.AddWithValue("@licenceClass", string.Empty);
                    cmd.Parameters.AddWithValue("@licenceNumber", string.Empty);
                    cmd.Parameters.AddWithValue("@licenceKey", string.Empty);
                    cmd.Parameters.AddWithValue("@warrantyPeriod", other.warrantyPeriod);
                    cmd.Parameters.AddWithValue("@vendorName", other.vendorName);
                    cmd.Parameters.AddWithValue("@vendorContact", other.vendorContact);
                    cmd.Parameters.AddWithValue("@vendorEmail", other.vendorEmail);
                  
                    cmd.Parameters.AddWithValue("@isActive", 1);
                    cmd.Parameters.AddWithValue("@isDeleted", 0);
                    result = cmd.ExecuteNonQuery();

                    conn.Close();
                    return result;
                }
            }
            catch (Exception ex) { }
            return 0;
        }

        //public Hardware  Get(int assetid)
        //{
        //    throw new NotImplementedException();
        //}

        public List<Other> GetOthers()
        {
            List<Other> others = new List<Other>();
            try
            {
                MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();
                string connectionstring = "server=127.0.0.1;uid=root;pwd=root;database=cmdb";

                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = connectionstring;
                MySqlCommand cmd = conn.CreateCommand();
                conn.Open();
                string query = "select * from asset where resourceId=3 AND IsDeleted = 0";
                cmd.CommandText = query;
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Other otherAsset = new Other();
                    otherAsset.assetId = Convert.ToInt32(dataReader[0]);
                    otherAsset.resourceId = Convert.ToInt32(dataReader[1]);
                    otherAsset.assetCode = Convert.ToString(dataReader[2]);
                    otherAsset.assetName = Convert.ToString(dataReader[3]);
                    otherAsset.shortName = Convert.ToString(dataReader[4]);
                    otherAsset.description = Convert.ToString(dataReader[5]);
                    otherAsset.serialNo = Convert.ToString(dataReader[6]);
                    
                    otherAsset.warrantyPeriod = Convert.ToInt32(dataReader[13]);
                    otherAsset.vendorName = Convert.ToString(dataReader[14]);
                    otherAsset.vendorContact = Convert.ToString(dataReader[15]);
                    otherAsset.vendorEmail = Convert.ToString(dataReader[16]);
                    otherAsset.createdDate = Convert.ToDateTime(dataReader[17]);
                    otherAsset.isActive = (Convert.ToString(dataReader[18])) == "" || (Convert.ToString(dataReader[18])) == "0" || (Convert.ToString(dataReader[18])) == null ? false : true;
                    otherAsset.isDeleted = (Convert.ToString(dataReader[19])) == "" || (Convert.ToString(dataReader[19])) == "0" || (Convert.ToString(dataReader[19])) == null ? false : true;

                    others.Add(otherAsset);

                }
                conn.Close();

            }
            catch (Exception ex) { }
            return others;
        }
        public int UpdateOther(Other other)
        {
            int result = 0;
            try
            {

                MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();
                string connectionstring = "server=127.0.0.1;uid=root;pwd=root;database=cmdb";

                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = connectionstring;
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                //  cmd.Parameters.AddWithValue("@Name", HModel.Name);

                cmd.CommandText = "Update asset set assetCode= @assetCode,assetName=@assetName,shortName=@shortName," +
                                    "description = @description,serialNo=@serialNo,modelNo=@modelNo,softwareVersion=@softwareVersion," +
                                    "softwareType=@softwareType,licenceClass=@licenceClass,licenceNumber=@licenceNumber,licenceKey=@licenceKey" +
                                    ",warrantyPeriod=@warrantyPeriod,vendorName=@vendorName,vendorContact=@vendorContact,vendorEmail=@vendorEmail,createdDate=@createdDate where assetid=@assetid";

                //cmd.Parameters.AddWithValue("@assetid", hardware.assetId);
                //cmd.Parameters.AddWithValue("@resourceId", hardware.resourceId);
                cmd.Parameters.AddWithValue("@assetCode", other.assetCode);
                cmd.Parameters.AddWithValue("@assetName", other.assetName);
                cmd.Parameters.AddWithValue("@shortName", other.shortName);
                cmd.Parameters.AddWithValue("@description", other.description);
                cmd.Parameters.AddWithValue("@createdDate", other.createdDate);
                cmd.Parameters.AddWithValue("@serialNo", other.serialNo);
                cmd.Parameters.AddWithValue("@modelNo", string.Empty);
                cmd.Parameters.AddWithValue("@softwareVersion", string.Empty);
                cmd.Parameters.AddWithValue("@softwareType", string.Empty);
                cmd.Parameters.AddWithValue("@licenceClass", string.Empty);
                cmd.Parameters.AddWithValue("@licenceNumber", string.Empty);
                cmd.Parameters.AddWithValue("@licenceKey", string.Empty);
                cmd.Parameters.AddWithValue("@warrantyPeriod", other.warrantyPeriod);
                cmd.Parameters.AddWithValue("@vendorName", other.vendorName);
                cmd.Parameters.AddWithValue("@vendorContact", other.vendorContact);
                cmd.Parameters.AddWithValue("@vendorEmail", other.vendorEmail);
              
                cmd.Parameters.AddWithValue("@assetid", other.assetId);
                //cmd.Parameters.AddWithValue("@isActive", 1);
                //cmd.Parameters.AddWithValue("@isDeleted", 0);
                result = cmd.ExecuteNonQuery();

                conn.Close();
                return result;
            }

            catch (Exception ex) { }
            return result;
        }
        public int SoftDeleteOther(int assetId)
        {
            int result = 0;
            try
            {

                MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();
                string connectionstring = "server=127.0.0.1;uid=root;pwd=root;database=cmdb";

                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = connectionstring;
                MySqlCommand cmd = conn.CreateCommand();
                conn.Open();
                cmd.CommandText = "Update asset set isDeleted = 1 where assetid=@assetid";
                cmd.Parameters.AddWithValue("@assetid", assetId);
                result = cmd.ExecuteNonQuery();
                conn.Close();
                return result;


            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public Other GetOther(int assetId)
        {
            Other otherAsset = new Other();
            try
            {

                MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();
                string connectionstring = "server=127.0.0.1;uid=root;pwd=root;database=cmdb";

                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = connectionstring;
                MySqlCommand cmd = conn.CreateCommand();
                conn.Open();
                string query = "select * from asset where assetid=@assetId ";
                cmd.Parameters.AddWithValue("@assetId", assetId);
                cmd.CommandText = query;
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {

                    otherAsset.assetId = Convert.ToInt32(dataReader[0]);
                    otherAsset.resourceId = Convert.ToInt32(dataReader[1]);
                    otherAsset.assetCode = Convert.ToString(dataReader[2]);
                    otherAsset.assetName = Convert.ToString(dataReader[3]);
                    otherAsset.shortName = Convert.ToString(dataReader[4]);
                    otherAsset.description = Convert.ToString(dataReader[5]);
                    otherAsset.serialNo = Convert.ToString(dataReader[6]);
                 
                    otherAsset.warrantyPeriod = Convert.ToInt32(dataReader[13]);
                    otherAsset.vendorName = Convert.ToString(dataReader[14]);
                    otherAsset.vendorContact = Convert.ToString(dataReader[15]);
                    otherAsset.vendorEmail = Convert.ToString(dataReader[16]);
                    otherAsset.createdDate = Convert.ToDateTime(dataReader[17]);
                    otherAsset.isActive = (Convert.ToString(dataReader[18])) == "" || (Convert.ToString(dataReader[18])) == "0" || (Convert.ToString(dataReader[18])) == null ? false : true;
                    otherAsset.isDeleted = (Convert.ToString(dataReader[19])) == "" || (Convert.ToString(dataReader[19])) == "0" || (Convert.ToString(dataReader[19])) == null ? false : true;



                }
                conn.Close();

            }
            catch (Exception ex) { }

            return otherAsset;
        }


    }

}
 

    

