using System;
using System.Collections.Generic;

namespace MathEducation.ModelsBD;

public partial class User
{
    public int UserId { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<LearningProgress> LearningProgresses { get; set; } = new List<LearningProgress>();
}
