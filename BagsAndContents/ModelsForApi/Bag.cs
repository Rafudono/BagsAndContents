using System;
using System.Collections.Generic;

namespace BagsAndContents;

public partial class Bag
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public int OwnerId { get; set; }

    public virtual ICollection<Content> Contents { get; set; } = new List<Content>();

    public virtual User Owner { get; set; } = null!;
}