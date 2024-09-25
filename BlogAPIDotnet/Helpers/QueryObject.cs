using System;

namespace BlogAPIDotnet.Helpers;

public class QueryObject
{
    public string? CreatedBy { get; set; }
    public bool? IsDesc { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
