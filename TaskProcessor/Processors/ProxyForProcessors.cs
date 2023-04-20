namespace TaskProcessor.Processors
{
    public class ProxyForProcessors : IProcessor
    {
        private IProcessor processor;

        public ProxyForProcessors(IProcessor processor)
        {
            this.processor = processor;
        }

        public void Start()
        {
            try
            {
                if (processor == null)
                    throw new ArgumentNullException("Processor not initialized.");
                processor.Start();
                string data = $"Processor: {processor.GetType().Name} start at {DateTime.Now}";
                WriteToFile(data);
            }
            catch(Exception ex)
            {
                WriteToFile($"{ex.GetType()} {ex?.Message}");
            }
        }

        private void WriteToFile(string data)
        {
            using (StreamWriter sw = new StreamWriter(@$"C:\{GetType().Name}.txt", true))
            {
                sw.WriteLine(data);
            }
        }
    }
}