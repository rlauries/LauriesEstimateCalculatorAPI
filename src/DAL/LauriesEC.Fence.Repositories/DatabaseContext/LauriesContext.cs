using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;

using LauriesEC.Fences.Repositories.DataModels;
using Security.Models;
using System.Diagnostics;
using System.Net;
using System.Reflection.Emit;
namespace LauriesEC.Fences.Repositories.DatabaseContext
{
    public class LauriesContext : DbContext
    {
        

        SqlConnection connection = new SqlConnection("Server=tcp:lauries-estimate-calculator-db-server.database.windows.net,1433;" +
                                      "Initial Catalog=lauries-estimate-calculator-db;" +
                                      "Persist Security Info=False;" +
                                      "User ID=lauries-estimate-calculator-db;" + 
                                      "Password=Estadosunidos#01;" +
                                      "MultipleActiveResultSets=False;" +
                                      "Encrypt=True;" +
                                      "TrustServerCertificate=False;" +
                                      "Connection Timeout=30;"); 
        public LauriesContext(DbContextOptions<LauriesContext> options)
            : base(options)
        {
            
        }
        public LauriesContext()
        {
            
        }
   


        public MaterialsModel ProcessMaterials(int Id, string Name, decimal Price, int MaterialType)
        {
            //params SqlParameter[] parameters;
            MaterialsModel material = new MaterialsModel();
            try
            {
                connection.Open();
                string storedProcName = "[dbo].[spLauries_ProcessMaterials]";
                var command = new SqlCommand(storedProcName, connection) { CommandType = CommandType.StoredProcedure };
                //command.Parameters.AddRange(parameters);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = Id;
                command.Parameters.Add("@Name", System.Data.SqlDbType.VarChar).Value = Name;
                command.Parameters.Add("@Price", System.Data.SqlDbType.Decimal).Value = Price;
                command.Parameters.Add("@MaterialType", System.Data.SqlDbType.Int).Value = MaterialType;

                var result = new DataSet();
                var dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(result);

                foreach (DataRow dr in result.Tables[0].Rows)
                {
                    material = new MaterialsModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        Price = Convert.ToDecimal(dr["Price"]),
                        MaterialType = Convert.ToInt32(dr["MaterialTypesId"]),
                        IsAvailable = Convert.ToBoolean(dr["Available"]),
                        ResultDescription = "Ok"
                    };
                }

                connection.Close();
                return material;
            }
            catch (Exception e)
            {
                material.ResultDescription = e.Message;
                return material;
            }
        }

        //--------------------------------------------------------------------------------------------
        public List<MaterialsModel> GetMaterialListFromDB()
        {
            //params SqlParameter[] parameters;
            List<MaterialsModel> materialList = new List<MaterialsModel>();
            MaterialsModel material;
            try
            {
                connection.Open();
                string storedProcName = "[dbo].[spLauries_GetMaterialList]";
                var command = new SqlCommand(storedProcName, connection) { CommandType = CommandType.StoredProcedure };
                //command.Parameters.AddRange(parameters);



                command.ExecuteNonQuery();
                var result = new DataSet();
                var dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(result);

                foreach (DataRow dr in result.Tables[0].Rows)
                {
                    material = new MaterialsModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        Price = Convert.ToDecimal(dr["Price"]),
                        MaterialType = Convert.ToInt32(dr["MaterialTypesId"]),
                        IsAvailable = Convert.ToBoolean(dr["Available"]),
                        ResultDescription = "Ok"
                    };
                    materialList.Add(material);
                }

                connection.Close();
                return materialList;
            }
            catch { return materialList; }

        }
        //-------------------------------------------------------------------------


        public List<FenceModel> GetFenceListFromDB()
        {
            List<FenceModel> fenceList = new List<FenceModel>();
            FenceModel fence = new FenceModel();

            try
            {
                connection.Open();
                string storedProcName = "[dbo].[spLauries_GetServiceTypeList]";
                var command = new SqlCommand(storedProcName, connection) { CommandType = CommandType.StoredProcedure };
                //command.Parameters.AddRange(parameters);



                command.ExecuteNonQuery();
                var result = new DataSet();
                var dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(result);


                foreach (DataRow dr in result.Tables[0].Rows)
                {
                    fence = new FenceModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        Size = Convert.ToString(dr["Size"]),
                        Installation = Convert.ToString(dr["Installation"]),
                        NameId = Convert.ToString(dr["NameId"]),
                        ResultDescription = "Ok"
                    };
                    fenceList.Add(fence);
                }
                connection.Close (); 
                return fenceList;
            }
            catch(Exception e)
            {
                fence.ResultDescription = e.Message;
                return fenceList;
            }
        }

        //--------------------------------------------------------------------------
        public MaterialsModel GetMaterialById(int materialsId)
        {
            //params SqlParameter[] parameters;
            MaterialsModel material = new MaterialsModel();
            try
            {
                connection.Open();
                string storedProcName = "[dbo].[spLauries_GetMaterialById]";
                var command = new SqlCommand(storedProcName, connection) { CommandType = CommandType.StoredProcedure };
                //command.Parameters.AddRange(parameters);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = materialsId;

                command.ExecuteNonQuery();
                var result = new DataSet();
                var dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(result);

                foreach (DataRow dr in result.Tables[0].Rows)
                {
                    material = new MaterialsModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        Price = Convert.ToDecimal(dr["Price"]),
                        MaterialType = Convert.ToInt32(dr["MaterialTypesId"]),
                        IsAvailable = Convert.ToBoolean(dr["Available"]),
                        ResultDescription = "Ok"
                    };
                }

                connection.Close();
                return material;
            }
            catch (Exception e)
            {
                material.ResultDescription = e.Message;
                return material;
            }
        }
        //--------------------------------------------------
        public decimal GetTaxRateByStateName(string stateName)
        {
            StateTaxRateModel statetaxRate = new StateTaxRateModel();

            try
            {
                connection.Open();
                string storedProcName = "[dbo].[spLauries_GetTaxRateByState]";
                var command = new SqlCommand(storedProcName, connection) { CommandType = CommandType.StoredProcedure };
                //command.Parameters.AddRange(parameters);
                command.Parameters.Add("@State", System.Data.SqlDbType.VarChar).Value = stateName;





                command.ExecuteNonQuery();
                var result = new DataSet();
                var dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(result);

                foreach (DataRow dr in result.Tables[0].Rows)
                {
                    statetaxRate = new StateTaxRateModel
                    {
                        Id = Convert.ToInt32(dr["ID"]),
                        StateName = Convert.ToString(dr["state"]),
                        TaxRate = Convert.ToDecimal(dr["tax_rates"]),
                        ResultDescription = "Ok"
                    };
                }

                connection.Close();
                return statetaxRate.TaxRate;
            }
            catch (Exception e)
            {
                statetaxRate.ResultDescription = e.Message;
                return statetaxRate.TaxRate;
            }
        }
        //---------------------------------------------------------------------------------
        public List<string> GetStateShortener(string stateShortName)
        {
            List<string> states = new List<string>();
            try
            {
                connection.Open();
                string storedProcName = "[dbo].[spLauries_GetStatesByShortener]";
                var command = new SqlCommand(storedProcName, connection) { CommandType = CommandType.StoredProcedure };
                //command.Parameters.AddRange(parameters);
                command.Parameters.Add("@shortener", System.Data.SqlDbType.VarChar).Value = stateShortName;

                command.ExecuteNonQuery();
                var result = new DataSet();
                var dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(result);

                foreach (DataRow dr in result.Tables[0].Rows)
                {
                    states.Add(Convert.ToString(dr["state"]));

                }

                connection.Close();
                return states;
            }
            catch (Exception e)
            {
                states.Add(e.Message);
                return states;
            }

        }
        //-------------------------------------------------------------------------------
        public CustomerModel GetCustomerByEmail(string email)
        {
            CustomerModel customerModel = new CustomerModel();
            try
            {
                connection.Open();
                string functionName = "SELECT * FROM [dbo].[spLauries_GetCustomerByEmail](@email)";
                var command = new SqlCommand(functionName, connection);
                //command.Parameters.AddRange(parameters);
                command.Parameters.AddWithValue("@email", email);

                command.ExecuteNonQuery();
                var result = new DataSet();
                var dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(result);

                foreach (DataRow dr in result.Tables[0].Rows)
                {
                    customerModel = new CustomerModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        CompanyName = Convert.ToString(dr["CompanyName"]),
                        Email = Convert.ToString(dr["Email"]),
                        PhoneNumber = Convert.ToString(dr["PhoneNumber"]),
                        Address = Convert.ToString(dr["Address"]),
                        City = Convert.ToString(dr["City"]),
                        State = Convert.ToString(dr["State"]),
                        ZipCode = Convert.ToInt32(dr["ZipCode"]),
                        ResultDescription = "Ok"
                    };
                }

                connection.Close();
                return customerModel;

            }
            catch (Exception ex)
            {
                customerModel.ResultDescription = ex.Message;

            }
            return customerModel;
        }
        //------------------------------------------------------------------------------
        public CustomerModel ProcessCustomer(int id, string name, string lastName, string email,string phoneNumber, 
                                             string address, string city, string state, int zipCode)
        {
            CustomerModel customerModel = new CustomerModel();
            try
            {
             
                connection.Open();
                string storedProcName = "[dbo].[spLauries_ProcessCustomer]";
                var command = new SqlCommand(storedProcName, connection) { CommandType = CommandType.StoredProcedure };
                //command.Parameters.AddRange(parameters);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
                command.Parameters.Add("@Name", System.Data.SqlDbType.VarChar).Value = name;
                command.Parameters.Add("@CompanyName", System.Data.SqlDbType.VarChar).Value = lastName;
                command.Parameters.Add("@Email", System.Data.SqlDbType.VarChar).Value = email;
                command.Parameters.Add("@PhoneNumber", System.Data.SqlDbType.VarChar).Value = phoneNumber;
                command.Parameters.Add("@Address", System.Data.SqlDbType.VarChar).Value = address;
                command.Parameters.Add("@City", System.Data.SqlDbType.VarChar).Value = city;
                command.Parameters.Add("@State", System.Data.SqlDbType.VarChar).Value = state;
                command.Parameters.Add("@ZipCode", System.Data.SqlDbType.Int).Value = zipCode;

                command.ExecuteNonQuery();
                var result = new DataSet();
                var dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(result);

                foreach (DataRow dr in result.Tables[0].Rows)
                {
                    customerModel = new CustomerModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        CompanyName = Convert.ToString(dr["CompanyName"]),
                        Email = Convert.ToString(dr["Email"]),
                        PhoneNumber = Convert.ToString(dr["PhoneNumber"]),
                        Address = Convert.ToString(dr["Address"]),
                        City = Convert.ToString(dr["City"]),
                        State = Convert.ToString(dr["State"]),
                        ZipCode = Convert.ToInt32(dr["ZipCode"]),
                        ResultDescription = "Ok"
                    };
                }

                connection.Close();
                return customerModel;

            }
            catch (Exception ex)
            {
                customerModel.ResultDescription = ex.Message;

            }
            return customerModel;
        }

        //-----------------------------------------------------------------------------
        public UserModel SignUp(UserModel newUserModel)
        {
            UserModel userModel = new UserModel();
            try
            {
                connection.Open();
                string storedProcName = "[dbo].[spLauries_SignUpUser]";
                var command = new SqlCommand(storedProcName, connection) { CommandType = CommandType.StoredProcedure };
                //command.Parameters.AddRange(parameters);

                command.Parameters.Add("@userName", System.Data.SqlDbType.VarChar).Value = newUserModel.UserName;
                command.Parameters.Add("@hashPassword", System.Data.SqlDbType.VarChar).Value = newUserModel.HashPassword;
                command.Parameters.Add("@salty", System.Data.SqlDbType.VarBinary).Value = newUserModel.Salty;
                command.Parameters.Add("@customerId", System.Data.SqlDbType.Int).Value = newUserModel.CustomerId;
                command.Parameters.Add("@roleId", System.Data.SqlDbType.Int).Value = newUserModel.RoleId;

                //command.ExecuteNonQuery();
                var result = new DataSet();
                var dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(result);
                foreach (DataRow dr in result.Tables[0].Rows)
                {
                    userModel = new UserModel
                    {
                        UserName = Convert.ToString(dr["UserName"]),
                        HashPassword = Convert.ToString(dr["HashPassword"]),
                        
                        Salty = (byte[])dr["Salty"],
                        CreatedDate = Convert.ToDateTime(dr["CreatedDate"]),
                        CustomerId = Convert.ToInt32(dr["CustomerId"]),
                        RoleId = (int)dr["RoleId"],
                        ResultDescription = "Ok"
                    };
                }

                connection.Close();
                return userModel;

            }
            catch (Exception ex)
            {
                userModel.ResultDescription = ex.Message;
            }
            return userModel;
            
        }

        //-----------------------------------------------------------------------------------
        public LoginModel GetPasswordAndSaltByUserName(string userName)
        {
            LoginModel userModel = new LoginModel();
            try
            {
                connection.Open();
                string functionName = "SELECT * FROM [dbo].[spLauries_GetPasswordAndSaltByUserName](@userName)";
                var command = new SqlCommand(functionName, connection);
                //command.Parameters.AddRange(parameters);
                command.Parameters.AddWithValue("@userName", userName);

                command.ExecuteNonQuery();
                var result = new DataSet();
                var dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(result);
                foreach (DataRow dr in result.Tables[0].Rows)
                {
                    userModel = new LoginModel
                    {
                        HashPassword = Convert.ToString(dr["HashPassword"]),
                        Salty = (byte[])dr["Salty"]
                    };
                }
                connection.Close();
                return userModel;
            }
            catch (Exception ex)
            {
                userModel.ResultDescription = ex.Message;
            }
            return userModel;
        }


    }
}
