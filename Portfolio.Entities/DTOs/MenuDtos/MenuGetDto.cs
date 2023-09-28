namespace Portfolio.Entities.DTOs;

public class MenuGetDto : MenuGetAllDto
{

    public ICollection<MenuHeaderGetDto> MenuHeaders { get; set; }
}
