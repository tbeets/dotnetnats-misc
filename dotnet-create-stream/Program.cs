// See https://aka.ms/new-console-template for more information

using NATS.Client;
using NATS.Client.JetStream;

namespace dotnet_create_stream
{

    internal static class CreateStream
    {
        public static void Main(string[] args)
        {
            ConnectionFactory factory = new ConnectionFactory();
            string subject = Guid.NewGuid().ToString().Replace("-", ".");

            string stream = Guid.NewGuid().ToString();

            using (IConnection connection = factory.CreateConnection(ConnectionFactory.GetDefaultOptions()))
            {
                IJetStreamManagement jetStreamManagement = connection.CreateJetStreamManagementContext();

                StreamConfiguration config = StreamConfiguration.Builder()
                    .WithName(stream)
                    .Build();

                jetStreamManagement.AddStream(config);

                config.Subjects.Add(subject);

                jetStreamManagement.UpdateStream(config);
            }

            Thread.Sleep(TimeSpan.FromSeconds(1)); //Wait for background dispose processes to complete. 

            string stream2 = Guid.NewGuid().ToString();

            using (IConnection connection = factory.CreateConnection(ConnectionFactory.GetDefaultOptions()))
            {
                IJetStreamManagement jetStreamManagement = connection.CreateJetStreamManagementContext();

                StreamConfiguration config = StreamConfiguration.Builder()
                    .WithName(stream2)
                    .Build();

                jetStreamManagement.AddStream(config);

                config.Subjects.Add(subject);

                jetStreamManagement.UpdateStream(config);
            }

            Console.WriteLine("Hello, World!");

            Thread.Sleep(TimeSpan.FromSeconds(1));
        }
    }
}