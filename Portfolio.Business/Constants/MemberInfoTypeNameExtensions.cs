using System.Reflection;

namespace Portfolio.Business.Constants;
public static class MemberInfoTypeNameExtensions
{
    public static string TypeNameExtensions(this MemberInfo memberInfo)
    {
        switch (memberInfo.Name)
        {
            case "About":
                return "Hakkında";
            case "Contact":
                return "İletişim";
            case "Introduce":
                return "Tanıtım";
            case "Menu":
                return "Menü";
            case "Resume":
                return "Özgeçmiş";
            case "Skill":
                return "Yetenek";
            case "SocialMedia":
                return "Sosyal Medya";
            case "Specialization":
                return "Uzmanlık";
            case "Testimonial":
                return "Referans";
            default:
                return memberInfo.Name;
        }
    }
}