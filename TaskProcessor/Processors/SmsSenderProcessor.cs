namespace TaskProcessor.Processors
{
    public class SmsSenderProcessor : IProcessor
    {
        public string Start()
        {
            return $"send message: {Guid.NewGuid()}";
        }
    }
}