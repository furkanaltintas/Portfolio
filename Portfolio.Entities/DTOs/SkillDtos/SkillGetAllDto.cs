using Portfolio.Core.Entities.Abstract;

namespace Portfolio.Entities.DTOs;

public record SkillGetAllDto(int Id, string Name = null!, string IconName = null!, short Point = 0) : IDto;

/*
     public string Name { get; set; } = null!;
    public string IconName { get; set; } = null!;
    public short Point { get; set; } = 0;
*/