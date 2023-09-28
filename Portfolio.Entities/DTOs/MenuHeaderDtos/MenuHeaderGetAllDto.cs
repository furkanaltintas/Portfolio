namespace Portfolio.Entities.DTOs;

public class MenuHeaderGetAllDto
{
    public string Header { get; set; } = null!;
    public bool IsActive { get; set; }

    public ICollection<MenuGetDto> MenuGetDtos { get; set; }
}
