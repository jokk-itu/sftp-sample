using Renci.SshNet;

var arguments = new [] {"upload", "delete"};
using var sftpClient = new SftpClient(new ConnectionInfo("localhost", 5010, "demo", new PasswordAuthenticationMethod("demo", "demo")));
await sftpClient.ConnectAsync(CancellationToken.None);
Console.WriteLine(sftpClient.WorkingDirectory);

if (args.Length != 1 || !arguments.Contains(args[0]))
{
  throw new InvalidOperationException($"Expected one valid argument from {arguments}");
}
else if (args[0] == "upload")
{
  sftpClient.UploadFile(new MemoryStream("12345678"u8.ToArray()), "file.txt");
}
else if (args[0] == "delete")
{
  await sftpClient.DeleteFileAsync("file.txt", CancellationToken.None);
}