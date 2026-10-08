using System;
using System.Collections.Generic;

namespace MathEducation.ModelsBD;

public partial class Error
{
    public int ErrorId { get; set; }

    public int TaskId { get; set; }

    public string ErrorText { get; set; } = null!;

    public string Error1 { get; set; } = null!;

    public double Rate { get; set; }

    public string Hint { get; set; } = null!;

    public virtual Task Task { get; set; } = null!;
}
