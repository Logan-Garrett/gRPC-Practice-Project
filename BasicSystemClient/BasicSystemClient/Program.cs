using System.Threading.Tasks;
using Grpc.Net.Client;
using BasicSystemClient;
using System.Net.Http.Headers;

internal class Program
{
    private static void Main(string[] args)
    {
        // HTTP2 gRPC Setup
        using var channel = GrpcChannel.ForAddress("https://localhost:7128/gRPC", new GrpcChannelOptions
        {
            HttpHandler = new SocketsHttpHandler
            {
                EnableMultipleHttp2Connections = true,
            }
        });
        var gRPCclient = new Greeter.GreeterClient(channel);

        Console.WriteLine("gRPC Start: " + DateTime.Now.ToString());
        Parallel.For(0, 100000, async i =>
        {
            var reply = await gRPCclient.SayHelloAsync(new HelloRequest { Name = "BasicSystemClient" });
        });
        Console.WriteLine("gRPC End: " + DateTime.Now.ToString());

        // HTTP Rest Setup
        using HttpClient httpClient = new();
        httpClient.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue
        {
            NoCache = true
        };
        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

        Console.WriteLine("REST Start: " + DateTime.Now.ToString());
        Parallel.For(0, 100000, async i =>
        {
            var json = await httpClient.GetStringAsync("https://localhost:7237/REST");
        });
        Console.WriteLine("REST End: " + DateTime.Now.ToString());

        // Other Prints
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}