using System;
using System.Collections.Generic;

namespace MathEducation.ModelsBD;

public partial class Topic
{
    public int TopicId { get; set; }

    public int SectionId { get; set; }

    public string Title { get; set; } = null!;

    public string DocName { get; set; } = null!;

    public virtual Section Section { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
