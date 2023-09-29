using Portfolio.Core.Entities.Enums;

namespace Portfolio.Web.Helpers
{
    public static class DtoNameRemoveHelper
    {
        public static string DtoNameRemove(string name)
        {
            name = name.Replace(DtoTagNameEnum.GetAllDto.ToString(), "");
            name = name.Replace(DtoTagNameEnum.GetDto.ToString(), "");
            name = name.Replace(DtoTagNameEnum.CreateDto.ToString(), "");
            name = name.Replace(DtoTagNameEnum.UpdateDto.ToString(), "");
            return name;
        }
    }
}
