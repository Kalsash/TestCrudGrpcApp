using Grpc.Net.Client;
using Crud;
using Grpc.Core;

using var channel = GrpcChannel.ForAddress("https://localhost:7176");
var client = new UserService.UserServiceClient(channel);
try
{
	// удаление объекта с id = 2
	UserReply user = await client.DeleteUserAsync(new DeleteUserRequest { Id = 2 });
	Console.WriteLine($"{user.Id}. {user.Name} - {user.Age}");

	


}
catch (RpcException ex)
{
	Console.WriteLine(ex.Status.Detail);
}
ListReply users = await client.ListUsersAsync(new Google.Protobuf.WellKnownTypes.Empty());
foreach (var u in users.Users)
{
	Console.WriteLine($"{u.Id}. {u.Name} - {u.Age}");
}