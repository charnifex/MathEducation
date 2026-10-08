using System;
using System.Collections.Generic;

namespace MathEducation.ModelsBD;

public partial class LearningProgress
{
    public int ProgressId { get; set; }

    public int UserId { get; set; }

    public int TaskId { get; set; }

    public double ReceivedScore { get; set; }

    public string Status { get; set; } = null!;

    public virtual Task Task { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
