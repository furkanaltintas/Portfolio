using Portfolio.Core.Entities.Abstract;

namespace Portfolio.Business.Constants;

public static class Messages<T> where T : IEntity
{
    public static class GenericMessage
    {
        private static string TypeName => typeof(T).TypeNameExtensions();
        public static string TAdded = $"{TypeName} eklendi";
        public static string TUpdated = $"{TypeName} güncellendi";
        public static string TDeleted = $"{TypeName} silindi";
        public static string TUnDeleted = $"{TypeName} silinen öğe geri alındı";
        public static string TNameAlreadyExists = $"Böyle bir kullanıcı sistemde bulunmamaktadır";
        public static string NoT = $"Böyle bir {TypeName} bulunmamaktadır";
    }
}