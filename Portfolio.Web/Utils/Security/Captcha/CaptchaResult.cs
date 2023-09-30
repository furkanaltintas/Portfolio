namespace Portfolio.Web.Utils.Security.Captcha;

public class CaptchaResult
{
    public string CaptchaCode { get; set; } = null!;
    public byte[] CaptchaByteData { get; set; } = null!;
    public string CaptchaBase64Data => Convert.ToBase64String(CaptchaByteData);
    public DateTime TimeStamp { get; set; }
}