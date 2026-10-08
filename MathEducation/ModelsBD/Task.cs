using System;
using System.Collections.Generic;

namespace MathEducation.ModelsBD;

public partial class Task
{
    public int TaskId { get; set; }

    public int TopicId { get; set; }

    public string QuestionText { get; set; } = null!;

    public string CorrectAnswer { get; set; } = null!;

    public int MaxScore { get; set; }

    public string? Image { get; set; }

    public virtual ICollection<AnswerOption> AnswerOptions { get; set; } = new List<AnswerOption>();

    public virtual ICollection<Error> Errors { get; set; } = new List<Error>();

    public virtual ICollection<LearningProgress> LearningProgresses { get; set; } = new List<LearningProgress>();

    public virtual Topic Topic { get; set; } = null!;
}
