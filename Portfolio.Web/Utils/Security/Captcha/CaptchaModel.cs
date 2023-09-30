using System.ComponentModel.DataAnnotations;

namespace Portfolio.Web.Utils.Security.Captcha;

public class CaptchaModel
{
    [Required]
    [StringLength(4)]
    public string CaptchaCode { get; set; } = null!;
}
