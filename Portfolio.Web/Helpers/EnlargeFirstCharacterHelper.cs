namespace Portfolio.Web.Helpers
{
    public static class EnlargeFirstCharacterHelper
    {
        public static string EnlargeFirstCharacter(string name)
        {
            name = name[0].ToString().ToUpper() + name.Substring(1);
            // name[0].ToString().ToUpper() ilk karakterin harfi büyütüldü
            // name.Substring(1) ilk karakter silindi
            return name;
        }
    }
}
