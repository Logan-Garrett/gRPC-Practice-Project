using System.Threading.Tasks;
using Grpc.Net.Client;
// using GrpcService;
using BasicSystemClient;

internal class Program
{
    private static async Task Main(string[] args)
    {
        // The port number must match the port of the gRPC server.
        using var channel = GrpcChannel.ForAddress("https://localhost:7128");
        var client = new Greeter.GreeterClient(channel);
        var reply = await client.SayHelloAsync(
                          new HelloRequest { Name = "BasicSystemClient" });
        Console.WriteLine("Greeting: " + reply.Message);
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}