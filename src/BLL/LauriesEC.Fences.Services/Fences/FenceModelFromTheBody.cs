using LauriesEC.Fence;

namespace LauriesEC.Fences.Services.Fences
{
    public class FenceModelFromTheBody
    {
        public FenceType TypeOfFence { get; set; }
        public int SqFeet { get; set; }
        public int HorizontalTubes { get; set; }
        public int TubeWidth { get; set; }
        public int Gap { get; set; }
        public string? StateName { get; set; }
    }
}
