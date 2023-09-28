namespace Portfolio.Entities.DTOs;

public record SkillGetDto(int Id, string Name, string IconName, short Point) : SkillGetAllDto(Id, Name, IconName, Point);