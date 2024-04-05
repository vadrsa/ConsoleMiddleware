namespace MiddlewareDemo2;

public static class ConsoleApplicationBuilderExtensions
{
    public static ConsoleApplicationBuilder Use(this ConsoleApplicationBuilder builder, Func<ConsoleRequestDelegate, ConsoleContext, Task> middleware)
    {
        return builder.Use((next) => async (ctx) =>
        {
            await middleware(next, ctx);
        });
    }
    
    public static ConsoleApplicationBuilder Run(this ConsoleApplicationBuilder builder, Func<ConsoleContext, Task> middleware)
    {
        return builder.Use((_) => async (ctx) =>
        {
            await middleware(ctx);
        });
    }
}