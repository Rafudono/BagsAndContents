using System;
using System.Collections.Generic;

namespace BagsAndContents;

public partial class Content
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int BagId { get; set; }

    public virtual Bag Bag { get; set; } = null!;
}
