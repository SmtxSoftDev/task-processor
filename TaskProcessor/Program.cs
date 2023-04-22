namespace TaskProcessor
{
    using System.Configuration;
    using TaskProcessor.Processors;

    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                var classess = ConfigurationManager.AppSettings.AllKeys.ToList();
                classess.ForEach(name =>
                {
                    IProcessor processor = GetInstance<IProcessor>(name);
                    processor = new ProxyForProcessors(processor);
                    processor.Start();
                });
            }
        }

        #region GetInstance

        public static T GetInstance<T>(string? className)
        {
            string objectToInstantiate = $"TaskProcessor.Processors.{className}, TaskProcessor";
            var objectType = Type.GetType(objectToInstantiate);
            var instantiatedObject = Activator.CreateInstance(objectType);
            return (T)instantiatedObject;
        }

        #endregion
    }
}