using LauriesEC.Gate.Services.Interfaces;

namespace LauriesEC.Gate.Services.Models
{
    public class StandardDoorModel : IGate
    {
        public int Hinges { get;  } = 2;
        public int Latche { get; } = 1;
        public Dictionary<int, int> MaterialList { get; set; }

        //Constructor para puertas standard
        public StandardDoorModel()
        {
            GetMaterialList();
        }

        //constructor para puertas diferentes
        
        public Dictionary<int, int> GetMaterialList()
        {
            MaterialList = new Dictionary<int, int>()
            {
                {6, Latche},
                {5, Hinges},
                
            };
            return MaterialList;
        }
    }
}
