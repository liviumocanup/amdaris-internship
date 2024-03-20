# Assignment: Disposal and Garbage collection
### Assignment instructions

You are tasked with developing a console application for sending email notifications to users. The application should allow users to provide their email address as console input and send them an email thanking them for subscribing to the newsletter. Proper resource management and cleanup are crucial to ensure efficient handling of SMTP connections and prevent memory leaks.


### Setup
1. Run the following command in the terminal:
```bash
dotnet add package Microsoft.Extensions.Configuration.Json
dotnet add package Inferno
```

2. In file `appsettings.json` replace the `Username` placeholder with the email the message will be sent FROM.
3. In case you are using Gmail, enable 2FA and generate an App Password.
4. In file `appsettings.json` replace the `Password` placeholder with your password or 16-digit-app-password in case you are using Gmail.


### Cleanup
```bash
dotnet remove package Microsoft.Extensions.Configuration.Json
dotnet remove package Inferno
```