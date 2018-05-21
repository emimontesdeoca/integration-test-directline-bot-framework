# OUTDATED DOCUMENTATION!

# Integration test for Microsoft's Bot Framework using Direct Line channel

This repository has a test solution in Visual Studio that does integration test for Microsoft's Bot Framework using the DirectLine channel.
This solution works for single and flow cases, single cases being where the user ask for something and the bot returns a single activity, and flow clases where there is a conversation with more than 1 reply.

## Guide

For a guide about all the working flow for this integration test, objects explanation and how everything is done, check out my blog posts.

[Integration test using Microsoft's Bot Framework and DirectLine (1)](https://emimontesdeoca.github.io/2018/04/24/integration-test-bot-framework-1/)<br>
[Integration test using Microsoft's Bot Framework and DirectLine (2)](https://emimontesdeoca.github.io/2018/04/24/integration-test-bot-framework-2/)<br>
[Integration test using Microsoft's Bot Framework and DirectLine (3)](https://emimontesdeoca.github.io/2018/04/24/integration-test-bot-framework-3/)<br>
[Integration test using Microsoft's Bot Framework and DirectLine for flow cases](https://emimontesdeoca.github.io/2018/04/25/integration-test-bot-framework-with-flow-cases/)

## Set up the enviorment

1. Be sure that your bot is published.
2. Get the DirectLine `secret` from the bot framework panel.
2. Set the `secret`, `directLineAuthEndpoint`, `directLineConversationEndpoint` and the `entry` or `entries` in the `.json` file.
4. Modify the path of the single/flow cases in the `IntegrationTest.cs`.

## Logic tree

I've separated the classes by folders as you can see in the following tree.

```
src
│   app.config
│   IntegrationTest.cs
│   IntegrationTestBotFramework.csproj
│   packages.config
│
├───Auth
│       DirectLineAuth.cs
│
├───Objects
│       ActivityResponse.cs
│       Globals.cs
│       TestEntriesCollection.cs
│       TestEntry.cs
│       TestEntryFlow.cs
│       TestEntryFlowCollection.cs
│
├───Properties
│       AssemblyInfo.cs
│
└───Utils
        Utils.cs
```

 - `DirectLineAuth.cs` contains the object for the received json in the authorization process.
- `ActivityResponse.cs` contains the object for the reveiced json when asking for all the messages in a determined conversation.
- `Globals.cs` contains the object for loading the objects in the CodeAnalysis evaluator.
- `TestEntriesCollection.cs` contains the object for the json that contains the information and the entries for single cases.
- `TestEntryFlow.cs` contains the object for the json that contains the entry to test for flow cases.
- `TestEntry.cs` contains the object for the json that contains the entry to test for single cases.
=`TestEntTestEntryFlowCollectionriesCollection.cs` contains the object for the json that contains the information and the entries for flow cases.
- `Utils.cs` contains functions for API calls.

## JSON files 

### Single cases

```json
{
  "secret": "alksjadfhkajshdfSECRETHEREalksdjaslkjd",
  "directlineGenerateTokenEndpoint": "https://directline.botframework.com/v3/directline/tokens/generate",
  "directlineConversationEndpoint": "https://directline.botframework.com/v3/directline/conversations/",
  "entries": [
    {
      "name": "DecirHola",
      "request": {
        "type": "message",
        "text": "Hola",
        "from": {
          "id": "default-user",
          "name": "User"
        },
        "locale": "es",
        "textFormat": "plain",
        "timestamp": "2018-04-09T08:04:37.195Z",
        "channelData": {
          "clientActivityId": "1523261059363.6264723268323733.0"
        },
        "entities": [
          {
            "type": "ClientCapabilities",
            "requiresBotState": true,
            "supportsTts": true,
            "supportsListening": true
          }
        ],
        "id": "61hacck8j6jg"
      },
      "response": {
        "type": "message",
        "timestamp": "2018-04-09T08:04:37.901Z",
        "localTimestamp": "2018-04-09T09:04:37+01:00",
        "serviceUrl": "http://localhost:50629",
        "channelId": "emulator",
        "from": {
          "id": "j98bbdf097a",
          "name": "Bot"
        },
        "conversation": {
          "id": "eabcie4be8ak"
        },
        "recipient": {
          "id": "default-user"
        },
        "locale": "es",
        "text": "No tengo respuesta para eso.",
        "attachments": [],
        "entities": [],
        "replyToId": "61hacck8j6jg",
        "id": "47me557ikbf7"
      },
      "assert": "Request.Text == Response.Text"
    },
    {
      "name": "EnviarEspacios",
      "request": {
        "type": "message",
        "text": "",
        "from": {
          "id": "default-user",
          "name": "User"
        },
        "locale": "es",
        "textFormat": "plain",
        "timestamp": "2018-04-12T08:59:15.242Z",
        "channelData": {
          "clientActivityId": "1523523552273.48329133336136265.0"
        },
        "entities": [
          {	
            "type": "ClientCapabilities",
            "requiresBotState": true,
            "supportsTts": true,
            "supportsListening": true
          }
        ],
        "id": "g78j7ljflk47"
      },
      "response": {
        "type": "message",
        "timestamp": "2018-04-12T08:59:15.607Z",
        "localTimestamp": "2018-04-12T09:59:15+01:00",
        "serviceUrl": "http://localhost:57003",
        "channelId": "emulator",
        "from": {
          "id": "cfl5k90gl893",
          "name": "Bot"
        },
        "conversation": {
          "id": "3h4gc1n3b2dl"
        },
        "recipient": {
          "id": "default-user"
        },
        "locale": "es",
        "text": "No tengo respuesta para eso.",
        "attachments": [],
        "entities": [],
        "replyToId": "g78j7ljflk47",
        "id": "220ebn3l84nf9"
      },
      "assert": "Request.Text == Response.Text"
    },
    {
      "name": "DecirAdios",
      "request": {
        "type": "message",
        "text": "Adios",
        "from": {
          "id": "default-user",
          "name": "User"
        },
        "locale": "es",
        "textFormat": "plain",
        "timestamp": "2018-04-12T08:59:15.242Z",
        "channelData": {
          "clientActivityId": "1523523552273.48329133336136265.0"
        },
        "entities": [
          {
            "type": "ClientCapabilities",
            "requiresBotState": true,
            "supportsTts": true,
            "supportsListening": true
          }
        ],
        "id": "g78j7ljflk47"
      },
      "response": {
        "type": "message",
        "timestamp": "2018-04-12T08:59:15.607Z",
        "localTimestamp": "2018-04-12T09:59:15+01:00",
        "serviceUrl": "http://localhost:57003",
        "channelId": "emulator",
        "from": {
          "id": "cfl5k90gl893",
          "name": "Bot"
        },
        "conversation": {
          "id": "3h4gc1n3b2dl"
        },
        "recipient": {
          "id": "default-user"
        },
        "locale": "es",
        "text": "Nos vemos!",
        "attachments": [],
        "entities": [],
        "replyToId": "g78j7ljflk47",
        "id": "220ebn3l84nf9"
      },
      "assert": "Request.Text == Response.Text"
    },
    {
      "name": "PedirCoche",
      "request": {
        "type": "message",
        "text": "Coche",
        "from": {
          "id": "default-user",
          "name": "User"
        },
        "locale": "es",
        "textFormat": "plain",
        "timestamp": "2018-04-12T08:59:15.242Z",
        "channelData": {
          "clientActivityId": "1523523552273.48329133336136265.0"
        },
        "entities": [
          {
            "type": "ClientCapabilities",
            "requiresBotState": true,
            "supportsTts": true,
            "supportsListening": true
          }
        ],
        "id": "g78j7ljflk47"
      },
      "response": {
        "type": "message",
        "timestamp": "2018-04-12T09:05:22.340Z",
        "localTimestamp": "2018-04-12T10:05:22+01:00",
        "serviceUrl": "http://localhost:57003",
        "channelId": "emulator",
        "from": {
          "id": "cfl5k90gl893",
          "name": "Bot"
        },
        "conversation": {
          "id": "3h4gc1n3b2dl"
        },
        "recipient": {
          "id": "default-user"
        },
        "locale": "es",
        "text": "attachment",
        "attachments": [
          {
            "contentType": "image/png",
            "contentUrl": "https://media.ed.edmunds-media.com/subaru/impreza/2006/oem/2006_subaru_impreza_sedan_sti_fq_oem_1_500.jpg",
            "name": "Subaru_Impreza.png"
          }
        ],
        "entities": [],
        "replyToId": "fmcgeaaj32ie",
        "id": "33lalg1lk5dd"
      },
      "assert": "Response.Attachments.Count > 0"
    }
  ]
}

```

### Flow cases

```json
{
  "secret": "alsdkjalsdkjSECRETHERElkasjdlakjsdlkasjdlaksjd",
  "directlineGenerateTokenEndpoint": "https://directline.botframework.com/v3/directline/tokens/generate",
  "directlineConversationEndpoint": "https://directline.botframework.com/v3/directline/conversations/",
  "entries": [
    {
      "name": "DecirHola",
      "requests": [
        {
          "type": "message",
          "text": "Ayuda",
          "from": {
            "id": "default-user",
            "name": "User"
          },
          "locale": "es",
          "textFormat": "plain",
          "timestamp": "2018-04-09T08:04:37.195Z",
          "channelData": {
            "clientActivityId": "1523261059363.6264723268323733.0"
          },
          "entities": [
            {
              "type": "ClientCapabilities",
              "requiresBotState": true,
              "supportsTts": true,
              "supportsListening": true
            }
          ],
          "id": "61hacck8j6jg"
        },
        {
          "type": "message",
          "text": "Telefono",
          "from": {
            "id": "default-user",
            "name": "User"
          },
          "locale": "es",
          "textFormat": "plain",
          "timestamp": "2018-04-09T08:04:37.195Z",
          "channelData": {
            "clientActivityId": "1523261059363.6264723268323733.0"
          },
          "entities": [
            {
              "type": "ClientCapabilities",
              "requiresBotState": true,
              "supportsTts": true,
              "supportsListening": true
            }
          ],
          "id": "61hacck8j6jg"
        },
        {
          "type": "message",
          "text": "Oficina",
          "from": {
            "id": "default-user",
            "name": "User"
          },
          "locale": "es",
          "textFormat": "plain",
          "timestamp": "2018-04-09T08:04:37.195Z",
          "channelData": {
            "clientActivityId": "1523261059363.6264723268323733.0"
          },
          "entities": [
            {
              "type": "ClientCapabilities",
              "requiresBotState": true,
              "supportsTts": true,
              "supportsListening": true
            }
          ],
          "id": "61hacck8j6jg"
        },
        {
          "type": "message",
          "text": "Tenerife",
          "from": {
            "id": "default-user",
            "name": "User"
          },
          "locale": "es",
          "textFormat": "plain",
          "timestamp": "2018-04-09T08:04:37.195Z",
          "channelData": {
            "clientActivityId": "1523261059363.6264723268323733.0"
          },
          "entities": [
            {
              "type": "ClientCapabilities",
              "requiresBotState": true,
              "supportsTts": true,
              "supportsListening": true
            }
          ],
          "id": "61hacck8j6jg"
        }
      ],
      "response": {
        "type": "message",
        "timestamp": "2018-04-09T08:04:37.901Z",
        "localTimestamp": "2018-04-09T09:04:37+01:00",
        "serviceUrl": "http://localhost:50629",
        "channelId": "emulator",
        "from": {
          "id": "j98bbdf097a",
          "name": "Bot"
        },
        "conversation": {
          "id": "eabcie4be8ak"
        },
        "recipient": {
          "id": "default-user"
        },
        "locale": "es",
        "text": "922920252",
        "attachments": [],
        "entities": [],
        "replyToId": "61hacck8j6jg",
        "id": "47me557ikbf7"
      },
      "assert": "Request.Text == Response.Text"
    }
  ]
}
```
## Contributing

As a developer, if you feel like helping, any contribution is welcome.

And as user, if youy have any bug, issue, feature request or question, feel free to open a [ticket issue](https://github.com/emimontesdeoca/integration-test-directline-bot-framework/issues).

## License

MIT License

Copyright (c) 2018 Emiliano Montesdeoca del Puerto

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
