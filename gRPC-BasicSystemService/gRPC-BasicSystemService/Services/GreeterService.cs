using Grpc.Core;
using gRPC_BasicSystemService;
using gRPC_BasicSystemService.BLL;

namespace gRPC_BasicSystemService.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        ServiceBLL serviceBLL = new ServiceBLL();

        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                // Message = "Hello " + request.Name + " Lets Get This Bread."
                // Message = serviceBLL.GetServiceNames() 
                Message = "[\r\n  '{{repeat(5, 7)}}',\r\n  {\r\n    _id: '{{objectId()}}',\r\n    index: '{{index()}}',\r\n    guid: '{{guid()}}',\r\n    isActive: '{{bool()}}',\r\n    balance: '{{floating(1000, 4000, 2, \"$0,0.00\")}}',\r\n    picture: 'http://placehold.it/32x32',\r\n    age: '{{integer(20, 40)}}',\r\n    eyeColor: '{{random(\"blue\", \"brown\", \"green\")}}',\r\n    name: '{{firstName()}} {{surname()}}',\r\n    gender: '{{gender()}}',\r\n    company: '{{company().toUpperCase()}}',\r\n    email: '{{email()}}',\r\n    phone: '+1 {{phone()}}',\r\n    address: '{{integer(100, 999)}} {{street()}}, {{city()}}, {{state()}}, {{integer(100, 10000)}}',\r\n    about: '{{lorem(1, \"paragraphs\")}}',\r\n    registered: '{{date(new Date(2014, 0, 1), new Date(), \"YYYY-MM-ddThh:mm:ss Z\")}}',\r\n    latitude: '{{floating(-90.000001, 90)}}',\r\n    longitude: '{{floating(-180.000001, 180)}}',\r\n    tags: [\r\n      '{{repeat(7)}}',\r\n      '{{lorem(1, \"words\")}}'\r\n    ],\r\n    friends: [\r\n      '{{repeat(3)}}',\r\n      {\r\n        id: '{{index()}}',\r\n        name: '{{firstName()}} {{surname()}}'\r\n      }\r\n    ],\r\n    greeting: function (tags) {\r\n      return 'Hello, ' + this.name + '! You have ' + tags.integer(1, 10) + ' unread messages.';\r\n    },\r\n    favoriteFruit: function (tags) {\r\n      var fruits = ['apple', 'banana', 'strawberry'];\r\n      return fruits[tags.integer(0, fruits.length - 1)];\r\n    }\r\n  }\r\n]"
                // Procedure call above to database for theory test.
            });
        }
    }
}
