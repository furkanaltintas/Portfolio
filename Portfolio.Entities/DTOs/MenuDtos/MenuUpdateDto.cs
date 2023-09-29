namespace Portfolio.Entities.DTOs;

public class MenuUpdateDto : MenuGetAllDto
{
    public short OldQueue { get; set; }
    public List<string> Queues { get; set; }
}
