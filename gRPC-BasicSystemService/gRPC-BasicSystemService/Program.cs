using gRPC_BasicSystemService.Services;

// gRPC
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGrpc(); 
var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();

// Config gRPC
app.MapGet("/gRPC", () => "Communication with gRPC Service");
app.Run("https://localhost:7128/");