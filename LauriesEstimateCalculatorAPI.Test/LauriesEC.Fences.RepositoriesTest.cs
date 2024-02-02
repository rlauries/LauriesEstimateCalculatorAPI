using LauriesEC.Fences.Repositories.DatabaseContext;
using Newtonsoft.Json;
using System.Net;
using Xunit;
using Xunit.Sdk;
using Assert = Xunit.Assert;

namespace LauriesEstimateCalculatorAPI.Test
{
    public class LauriesECFencesRepositoriesTest
    {

        protected LauriesContext context;

        public LauriesECFencesRepositoriesTest()
        {
            context = new LauriesContext();
        }
        [Fact]
        public void CreateMaterial()
        {
            int Id = 0;
            string Name = "TestMAterial";
            decimal Price = (decimal)0.50;
            int MaterialType = 2;
            
            var response = context.ProcessMaterials(Id,Name,Price,MaterialType);

            Assert.NotEqual(Id , response.Id);
            Assert.Equal(Price, response.Price);
        
        }

        [Fact]
        public void UpdateMaterial()
        {
            int Id = 10;
            string Name = "TestMAterial";
            decimal Price = 0;
            int MaterialType = 2;

            var response = context.ProcessMaterials(Id, Name, Price, MaterialType);

            Assert.Equal(Id, response.Id);
            Assert.Equal(Price, response.Price);
            Assert.False(response.IsAvailable); 

        }
    }
}