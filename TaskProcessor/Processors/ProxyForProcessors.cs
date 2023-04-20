namespace TaskProcessor.Processors
{
    public class ProxyForProcessors : IProcessor
    {
        private IProcessor processor;

        public ProxyForProcessors(IProcessor processor)
        {
            this.processor = processor;
        }

        public string Start()
        {
            string result;
            try
            {
                if (processor == null)
                    throw new ArgumentNullException("Processor not initialized.");
                result = processor.Start();
                result = $"Processor: {processor.GetType().Name} start at {DateTime.Now} information: {result}";
            }
            catch(Exception ex)
            {
                result = $"{ex.GetType()} {ex?.Message}";
            }
            WriteToFile(result);
            return result;
        }

        private void WriteToFile(string data)
        {
            using (StreamWriter sw = new StreamWriter(@$"D:\{GetType().Name}.txt", true))
            {
                sw.WriteLine(data);
            }
        }
    }
}