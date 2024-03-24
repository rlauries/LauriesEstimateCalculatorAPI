using LauriesEC.Fence;

namespace LauriesEC.Fence.Models
{
    public class FenceModelFromBody
    {
        public FenceType TypeOfFence { get; set; }
        public int SqFeet { get; set; }
        public int HorizontalTubes { get; set; }
        public int TubeWidth { get; set; }
        public int Gap { get; set; }
    }
}
