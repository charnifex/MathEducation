using System;
using System.Collections.Generic;

namespace MathEducation.ModelsBD;

public partial class AnswerOption
{
    public int AnswerOptionId { get; set; }

    public int TaskId { get; set; }

    public string Answer { get; set; } = null!;

    public bool IsCorrect { get; set; }

    public virtual Task Task { get; set; } = null!;
}
