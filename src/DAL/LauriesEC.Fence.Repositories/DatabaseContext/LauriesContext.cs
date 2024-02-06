using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

using LauriesEC.Fences.Repositories.DataModels;
namespace LauriesEC.Fences.Repositories.DatabaseContext
{
    public class LauriesContext : DbContext
    {
       
        SqlConnection connection = new SqlConnection("Data Source=JEVISPC\\MSSQLSERVERLOCAL; Initial Catalog = Lauries; Integrated security=true");
        
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



                command.ExecuteNonQuery();
                var result = new DataSet();
                var result2 = new DataTable();
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
                                    ResultDescription ="Ok"
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

        public MaterialsModel GetMaterialById(MaterialsName materialsName)
        {
            //params SqlParameter[] parameters;
            MaterialsModel material = new MaterialsModel();
            try
            {
                connection.Open();
                string storedProcName = "[dbo].[spLauries_GetMaterialById]";
                var command = new SqlCommand(storedProcName, connection) { CommandType = CommandType.StoredProcedure };
                //command.Parameters.AddRange(parameters);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = materialsName;
                


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
    }
}
