namespace TaskProcessor.Processors
{
    public class SmsSenderProcessor : IProcessor
    {
        public void Start()
        {
            using (StreamWriter sw = new StreamWriter($@"D:\{this.GetType().Name}.txt", true))
            {
                sw.WriteLine($"Start {this.GetType().Name} at {DateTime.Now} and send message: {Guid.NewGuid()}");
            }
        }
    }
}