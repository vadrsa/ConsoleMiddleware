using MiddlewareDemo2;

var builder = new ConsoleApplicationBuilder();

builder.Use(async (next, ctx) =>
{
    Console.WriteLine($"Hello to console server");
    await next(ctx);
    Console.WriteLine($"Bye from console server");
});
builder.Use(async (next, ctx) =>
{
    Console.WriteLine($"[Console] Input Received : {ctx.Input}");
    await next(ctx);
    Console.WriteLine($"[Console] Output Received : {ctx.Output}");
});

builder.Run((ctx) =>
{
    ctx.Output = string.Join("", ctx.Input.Reverse());
    return Task.CompletedTask;
});

var app = builder.Build();

var server = new ConsoleServer(app);

await server.Run();