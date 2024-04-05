namespace MiddlewareDemo2;

public class ConsoleContext
{
    public ConsoleContext(string input)
    {
        Input = input;
    }

    public string Input { get; }
    public string? Output { get; set; }
}