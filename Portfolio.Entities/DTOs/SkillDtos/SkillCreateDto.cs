namespace Portfolio.Entities.DTOs;

public record SkillCreateDto(int Id, string Name, string IconName, short Point) : SkillGetAllDto(Id, Name, IconName, Point);