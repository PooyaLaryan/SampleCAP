**1. Default Credentials**

By default, RabbitMQ creates a user with the following credentials:
Username: guest
Password: guest
The guest user can only connect to RabbitMQ when running on the same machine (localhost).

**2. Locating the Host**

The host for RabbitMQ depends on where the service is running:
If running on the same machine, use:
csharp
Copy code
var host = "localhost";
If connecting remotely, use the machine's IP address or hostname where RabbitMQ is installed.

**3. Changing or Creating a New User**

To set up a custom username and password, follow these steps:

Open RabbitMQ Command Prompt:

Open the RabbitMQ Command Prompt (you can find it in the Start Menu under RabbitMQ installation).
Add a New User: Run the following command:

cmd
Copy code
rabbitmqctl add_user <username> <password>
Example:

cmd
Copy code
rabbitmqctl add_user myuser mypassword
Set Permissions for the User: Grant permissions to the user:

cmd
Copy code
rabbitmqctl set_permissions -p / <username> ".*" ".*" ".*"
Example:

cmd
Copy code
rabbitmqctl set_permissions -p / myuser ".*" ".*" ".*"
Delete Default guest User (Optional): For security reasons, you can remove the default guest user:

cmd
Copy code
rabbitmqctl delete_user guest

**4. Configuration in C#**
To connect your C# project to RabbitMQ, use the RabbitMQ.Client library. Here's an example of setting up the connection:

csharp
Copy code
using RabbitMQ.Client;

var factory = new ConnectionFactory()
{
    HostName = "localhost", // or IP address of RabbitMQ server
    UserName = "myuser",    // your custom username
    Password = "mypassword" // your custom password
};

using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    // Your RabbitMQ logic here
    channel.QueueDeclare(queue: "hello",
                         durable: false,
                         exclusive: false,
                         autoDelete: false,
                         arguments: null);

    string message = "Hello World!";
    var body = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish(exchange: "",
                         routingKey: "hello",
                         basicProperties: null,
                         body: body);
    Console.WriteLine(" [x] Sent {0}", message);
}

**5. Checking Configuration in RabbitMQ Management Plugin**
The RabbitMQ Management Plugin allows you to manage RabbitMQ users and settings through a web interface.

Enable the Management Plugin: Run this command in the RabbitMQ Command Prompt:

cmd
Copy code
rabbitmq-plugins enable rabbitmq_management
Access the Management Interface: Open a browser and go to:

arduino
Copy code
http://localhost:15672
Default username: guest
Default password: guest
Create/Modify Users:

Go to the "Admin" tab to add or edit users.

**6. Testing the Connection**
Ensure RabbitMQ is running and your credentials work by testing them through the Management UI or a simple script.

Let me know if you need further assistance!
