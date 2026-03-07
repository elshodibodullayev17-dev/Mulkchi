namespace Mulkchi.Api.Models.Foundations.Common;

public class PaginationParams
{
    private int pageSize = 20;

    public int Page { get; set; } = 1;

    public int PageSize
    {
        get => pageSize;
        set => pageSize = value > 100 ? 100 : value < 1 ? 1 : value;
    }
}
