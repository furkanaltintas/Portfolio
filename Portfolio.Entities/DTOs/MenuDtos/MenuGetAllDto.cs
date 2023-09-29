using Portfolio.Core.Entities.Abstract;

namespace Portfolio.Entities.DTOs;

public class MenuGetAllDto : IDto
{
    public int Id { get; set; }
    public string ComponentName { get; set; } = null!;
    public string Header { get; set; } = null!;
    public string Slug { get; set; } = null!;
    public string IconName { get; set; } = null!;
    public short Queue { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
}