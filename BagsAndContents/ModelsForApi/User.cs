using System;
using System.Collections.Generic;

namespace BagsAndContents.ModelsForApi;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int IdRole { get; set; } = 2;

    public virtual Bag? Bag { get; set; }

    public virtual Role IdRoleNavigation { get; set; } = null!;
}
