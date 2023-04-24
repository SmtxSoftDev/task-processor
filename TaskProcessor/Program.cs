namespace TaskProcessor
{
    using System.Configuration;
    using TaskProcessor.Helpers.ObjectCreatorFactory;
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
                    IProcessor processor = ObjectFactory.GetInstance(name);
                    processor = new ProxyForProcessors(processor);
                    processor.Start();
                });
            }
        }
    }
}