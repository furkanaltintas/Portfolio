using Portfolio.Core.Entities.Abstract;

namespace Portfolio.Core.Helpers;

public static class ObjectCastHelper
{
    public static List<object> CastToObj<T>(List<T> values) where T : class, IDto
    {
        List<object> modelAsObject = values.Cast<object>().ToList();
        return modelAsObject;
    }

    public static object CastToObj<T>(T value) where T : class, IDto
    {
        object modelAsObject = (object)value;
        return modelAsObject;
    }

    public static List<object> CastToObjList<T>(T value) where T : class, IDto
    {
        List<object> objectList = new();
        objectList.Add(value);
        return objectList;
    }
}
