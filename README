# Telegram Sender

This is a .NET class library that provides a simple API for sending messages via Telegram. The library uses the TLSharp library to interact with the Telegram API.

## Getting Started

To use this library in your .NET project, you will need to add a reference to the `TelegramSender` project and include the following using statement in your code:

```csharp
using System;
using System.Linq;
using System.Threading.Tasks;
using TL;
using WTelegram;
```

Once you have done this, you can call the `SendMessageAsync` method in the `Telegram` class to send a message to a phone number. The method takes two parameters: the phone number and the message to send.

# Usage

To send a message to a phone number, simply call the `SendMessageAsync` method in the Telegram class with the phone number and message as parameters.
```csharp
await Telegram.SendMessageAsync("+6283849995719", "Hello, world!");
```

## Configuration

The library uses the TLSharp library to interact with the Telegram API. You will need to include this package in your project in order to use the library.

The `Config` method in the `Telegram` class is used to configure the client. You will need to replace the API ID, API hash, and phone number values with your own values.

```csharp
static string Config(string what)
{
    switch (what)
    {
        case "api_id": return "YOUR_API_ID";
        case "api_hash": return "YOUR_API_HASH";
        case "phone_number": return "YOUR_PHONE_NUMBER";
        // IMPORTANT!
        default: return null;
    }
}
```

## Dependencies
This library has the following dependencies:

- .NET Standard 2.0
- TLSharp (version 1.1.1 or higher)
- WTelegram (version 1.1.1 or higher)
