namespace MiddlewareDemo2;

public class ConsoleServer
{
    private readonly ConsoleRequestDelegate _app;

    public ConsoleServer(ConsoleRequestDelegate app)
    {
        _app = app;
    }

    public async Task Run()
    {
        while (true)
        {
            Console.Write("Input: ");
            var input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                var context = new ConsoleContext(input);
                await _app(context);
                Console.WriteLine($"Output: {context.Output ?? "No response"}");
            }
        }
    }
}