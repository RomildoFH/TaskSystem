using System.ComponentModel;

namespace TaskSystem.Enums
{
    public enum TaskStatus
    {
        [Description("Pending task")]
        Pending = 1,
        [Description("In execution task")]
        Ongoing = 2,
        [Description("Finished task")]
        Finished = 3
    }
}
