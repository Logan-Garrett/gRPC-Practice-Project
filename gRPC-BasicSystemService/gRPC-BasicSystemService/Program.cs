using gRPC_BasicSystemService.BLL;
using gRPC_BasicSystemService.Services;

// var Message = "[\r\n  '{{repeat(5, 7)}}',\r\n  {\r\n    _id: '{{objectId()}}',\r\n    index: '{{index()}}',\r\n    guid: '{{guid()}}',\r\n    isActive: '{{bool()}}',\r\n    balance: '{{floating(1000, 4000, 2, \"$0,0.00\")}}',\r\n    picture: 'http://placehold.it/32x32',\r\n    age: '{{integer(20, 40)}}',\r\n    eyeColor: '{{random(\"blue\", \"brown\", \"green\")}}',\r\n    name: '{{firstName()}} {{surname()}}',\r\n    gender: '{{gender()}}',\r\n    company: '{{company().toUpperCase()}}',\r\n    email: '{{email()}}',\r\n    phone: '+1 {{phone()}}',\r\n    address: '{{integer(100, 999)}} {{street()}}, {{city()}}, {{state()}}, {{integer(100, 10000)}}',\r\n    about: '{{lorem(1, \"paragraphs\")}}',\r\n    registered: '{{date(new Date(2014, 0, 1), new Date(), \"YYYY-MM-ddThh:mm:ss Z\")}}',\r\n    latitude: '{{floating(-90.000001, 90)}}',\r\n    longitude: '{{floating(-180.000001, 180)}}',\r\n    tags: [\r\n      '{{repeat(7)}}',\r\n      '{{lorem(1, \"words\")}}'\r\n    ],\r\n    friends: [\r\n      '{{repeat(3)}}',\r\n      {\r\n        id: '{{index()}}',\r\n        name: '{{firstName()}} {{surname()}}'\r\n      }\r\n    ],\r\n    greeting: function (tags) {\r\n      return 'Hello, ' + this.name + '! You have ' + tags.integer(1, 10) + ' unread messages.';\r\n    },\r\n    favoriteFruit: function (tags) {\r\n      var fruits = ['apple', 'banana', 'strawberry'];\r\n      return fruits[tags.integer(0, fruits.length - 1)];\r\n    }\r\n  }\r\n]";
// ServiceBLL serviceBLL = new();
// var Message = serviceBLL.GetServiceNames();

// gRPC
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGrpc(); 
var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();

// Config gRPC
app.MapGet("/gRPC", () => "Communication with gRPC Service");
app.Run("https://localhost:7128/");