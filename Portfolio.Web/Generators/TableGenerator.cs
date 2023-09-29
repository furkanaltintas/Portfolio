using Portfolio.Entities.Concrete;

namespace Portfolio.Web.Generators;

public static class TableGenerator
{
    public static object Entity(string usingName)
    {
        object? value = usingName switch
        {
            nameof(About) => new About(),
            nameof(Contact) => new Contact(),
            nameof(Introduce) => new Introduce(),
            nameof(Menu) => new Menu(),
            nameof(Resume) => new Resume(),
            nameof(Skill) => new Skill(),
            nameof(SocialMedia) => new SocialMedia(),
            nameof(Specialization) => new Specialization(),
            nameof(Testimonial) => new Testimonial(),
            _ => null
        };

        return value!;
    }
}