using System;
using System.Collections.Generic;

namespace MathEducation.ModelsBD;

public partial class Section
{
    public int SectionId { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Topic> Topics { get; set; } = new List<Topic>();
}
