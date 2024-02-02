using LauriesEC.Fences.Repositories.DataModels;
using LauriesEC.Fences.Repositories.DatabaseContext;
using LauriesEC.Fences.Repositories.Interfaces;
namespace LauriesEC.Fences.Repositories
{
    public class Fences 
    {
        //builder.Services.AddDbContext<FenceModel>(options => 
        //{
        //    options.UseSqlServer("Server=JEVISPC\\MSSQLSERVERLOCAL;Database=Lauries;Trusted_Connection=True;");
        //});
        
        
        LauriesContext _lauriesContext;
        List<MaterialsModel> materialsModels;

        //public List<FenceModel> GetFences()
        //{
        //    materialsModels =  _lauriesContext.GetFences();
        //}

    }
}
