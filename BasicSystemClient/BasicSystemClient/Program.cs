using System.Threading.Tasks;
using Grpc.Net.Client;
// using GrpcService;
using BasicSystemClient;
using System.Net.Http.Headers;

internal class Program
{
    private static async Task Main(string[] args)
    {
        // The port number must match the port of the gRPC server.
        using var channel = GrpcChannel.ForAddress("https://localhost:7128/gRPC");
        var gRPCclient = new Greeter.GreeterClient(channel);

        Console.WriteLine("gRPC Start: " + DateTime.Now.ToString());
        for (int i = 0; i < 10000; i++)
        {
            var reply = await gRPCclient.SayHelloAsync(
                              new HelloRequest { Name = "BasicSystemClient" });
            // Console.WriteLine("Greeting: " + reply.Message);
        }
        Console.WriteLine("gRPC End: " + DateTime.Now.ToString());
        
        // HTTP Rest Setup
        using HttpClient httpClient = new();
        httpClient.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue
        {
            NoCache = true
        };
        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

        Console.WriteLine("REST Start: " + DateTime.Now.ToString());
        for (int i = 0; i < 10000; i++)
        {
            var json = await httpClient.GetStringAsync("https://localhost:7237/REST");

            // Console.Write(json);
        }
        Console.WriteLine("REST End: " + DateTime.Now.ToString());

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}