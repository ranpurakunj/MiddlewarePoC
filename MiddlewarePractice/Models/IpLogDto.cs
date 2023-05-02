using System;
using System.Collections.Generic;

namespace MiddlewarePractice.Models;

public partial class IpLogDto
{
    public int Id { get; set; }

    public string IpAddress { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTime TimeStamp { get; set; }
}
