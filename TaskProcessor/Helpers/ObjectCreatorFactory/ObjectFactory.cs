using TaskProcessor.Processors;

namespace TaskProcessor.Helpers.ObjectCreatorFactory
{
    public class ObjectFactory
    {
        public static IProcessor GetInstance(string? className)
        {
            string objectToInstantiate = $"TaskProcessor.Processors.{className}, TaskProcessor";
            var objectType = Type.GetType(objectToInstantiate);
            var instantiatedObject = Activator.CreateInstance(objectType);
            return (IProcessor)instantiatedObject;
        }
    }
}