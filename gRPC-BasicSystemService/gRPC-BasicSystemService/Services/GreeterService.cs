using Grpc.Core;
using gRPC_BasicSystemService;
using gRPC_BasicSystemService.BLL;

namespace gRPC_BasicSystemService.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name + " Lets Get This Bread."
            });
        }
    }
}
