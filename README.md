# Assignment: SOLID principles
### Assignment instructions

You are tasked with designing and implementing a notification system for a messaging application. The system should allow users to send notifications to other users via various channels such as email, SMS, and push notifications.

Your implementation should adhere to SOLID principles, focusing on specific principles relevant to the scenario. It should be implemented in a console application.

The system should support multiple notification channels and be flexible enough to accommodate future changes or additions to notification types and channels.


### Setup
1. Run the following command in the terminal:
```bash
dotnet add package Inferno
```

2. In file `appsettings.json` replace the `Username` placeholder with the email the message will be sent FROM.
3. In case you are using Gmail, enable 2FA and generate an App Password.
4. In file `appsettings.json` replace the `Password` placeholder with your password or 16-digit-app-password in case you are using Gmail.

### When adding a new `Notification Channel`, follow the next steps:
1. Create a `YourNotificationChannel.cs` which would inherit `INotificationChannel` in the **Channels** folder.
2. Add your type to `NotificationChannelType.cs` in the **Channels** folder.

*Optionally*
* If it requires any parameters in `appsettings.json`, create a new `YourSettings.cs` class in the **Configuration** folder. The `ConfigurationLoader` will load the section, you only need to specify it's name and which parameters to load. Add your custom section in the `appsettings.json` file following the structure:

```json
{
    "YourSettings": {
        "YourParam": "paramValue",
    }
}
```

* If it requires a new validatior for the `target` (to whom this message is addressed) create it in the **Validation** folder and inherit `IInputValidator`. You can also use a predefined one (for email, phone number and username).


### Cleanup
```bash
dotnet remove package Inferno
```