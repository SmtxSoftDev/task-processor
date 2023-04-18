namespace TaskProcessor;
using System.Configuration;

public class Program
{
    public static void Main(string [] args)
    {   
        
    }

    #region GetInstance

    public static object GetInstance(string? className)
    {
        var classess = ConfigurationManager.AppSettings.AllKeys.ToList();
        string objectToInstantiate = $"TaskProcessor.Processors.{className}, TaskProcessor";
        var objectType = Type.GetType(objectToInstantiate);
        var instantiatedObject = Activator.CreateInstance(objectType);
        return instantiatedObject;
    }

    #endregion
}