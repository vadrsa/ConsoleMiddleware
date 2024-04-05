namespace MiddlewareDemo2;

public delegate Task ConsoleRequestDelegate(ConsoleContext context);

public class ConsoleApplicationBuilder
{
    private List<Func<ConsoleRequestDelegate, ConsoleRequestDelegate>> _middlewares = new();
    
    public ConsoleApplicationBuilder Use(Func<ConsoleRequestDelegate, ConsoleRequestDelegate> middleware)
    {
        _middlewares.Add(middleware);
        return this;
    }

    public ConsoleRequestDelegate Build()
    {
        ConsoleRequestDelegate app = _ => throw new Exception("Request not handled");
        for (var i = _middlewares.Count - 1; i >= 0; i--)
        {
            app = _middlewares[i](app);
        }

        return app;
    }
}