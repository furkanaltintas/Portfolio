using Portfolio.Web.ViewComponents;

namespace Portfolio.Web.Helpers
{
    public static class HasViewComponentHelper
    {
        public static bool Init(string viewComponentName)
        {
            viewComponentName = viewComponentName + "ViewComponent";
            var hasViewComponent = viewComponentName switch
            {
                nameof(AboutViewComponent) => true,
                nameof(ContactViewComponent) => true,
                nameof(IntroduceViewComponent) => true,
                nameof(LeftSideBarViewComponent) => true,
                nameof(MenuViewComponent) => true,
                nameof(PortfolioViewComponent) => true,
                nameof(ResumeViewComponent) => true,
                nameof(SideBarMenuViewComponent) => true,
                nameof(SkillViewComponent) => true,
                nameof(SpecializationViewComponent) => true,
                nameof(TestimonialViewComponent) => true,
                _ => false
            };

            return hasViewComponent;
        }
    }
}