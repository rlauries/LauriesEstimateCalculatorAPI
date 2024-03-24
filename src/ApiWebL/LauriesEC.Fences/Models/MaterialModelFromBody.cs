using LauriesEC.Fences.Repositories;

namespace LauriesEC.Fence.Models
{
    public class MaterialModelFromBody
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int MaterialType { get; set; }
    }
}
