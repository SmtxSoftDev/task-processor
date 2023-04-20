namespace TaskProcessor.Processors
{
    public class EmailSenderProcessor : IProcessor
    {
        public string Start()
        {
            return $"send message: {Guid.NewGuid()}";
        }
    }
}