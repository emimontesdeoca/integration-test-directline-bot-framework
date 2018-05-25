# Integration test for Microsoft's Bot Framework using Direct Line channel

This repository has a test solution in Visual Studio that does integration test for Microsoft's Bot Framework using the DirectLine channel.

## Table of contents

- [Working flow](https://github.com/emimontesdeoca/integration-test-directline-bot-framework#working-flow)
- [Project tree](https://github.com/emimontesdeoca/integration-test-directline-bot-framework#project-tree)
  - [Auth](https://github.com/emimontesdeoca/integration-test-directline-bot-framework#auth)
  - [Collections](https://github.com/emimontesdeoca/integration-test-directline-bot-framework#collections)
  - [Objects](https://github.com/emimontesdeoca/integration-test-directline-bot-framework#objects)
  - [Tests](https://github.com/emimontesdeoca/integration-test-directline-bot-framework#tests)
  - [Utils](https://github.com/emimontesdeoca/integration-test-directline-bot-framework#utils)
- [JSON structure](https://github.com/emimontesdeoca/integration-test-directline-bot-framework#json-structure)
- [Building the JSON](https://github.com/emimontesdeoca/integration-test-directline-bot-framework#working-flow)
  - [Requirements](https://github.com/emimontesdeoca/integration-test-directline-bot-framework#requirements)
  - [Build the main structure of the JSON](https://github.com/emimontesdeoca/integration-test-directline-bot-framework#build-the-main-structure-of-the-json)
  - [Building an entry](https://github.com/emimontesdeoca/integration-test-directline-bot-framework#building-an-entry)
  - [Filling the steps](https://github.com/emimontesdeoca/integration-test-directline-bot-framework#filling-the-steps)
    - [Sending a message and getting the Activity](https://github.com/emimontesdeoca/integration-test-directline-bot-framework#sending-a-message-and-getting-the-activity)
    - [Receiving a message and getting the Activity](https://github.com/emimontesdeoca/integration-test-directline-bot-framework#receiving-a-message-and-getting-the-activity)
    - [Building the assert](https://github.com/emimontesdeoca/integration-test-directline-bot-framework#building-the-assert)
    - [Not asserting the message](https://github.com/emimontesdeoca/integration-test-directline-bot-framework#filling-the-steps)
- [Contributing](https://github.com/emimontesdeoca/integration-test-directline-bot-framework#contributing)
- [License](https://github.com/emimontesdeoca/integration-test-directline-bot-framework#license)


## Working flow

[![https://gyazo.com/1203e163e730af4f1b3dcbf2af649a05](https://i.gyazo.com/1203e163e730af4f1b3dcbf2af649a05.png)](https://gyazo.com/1203e163e730af4f1b3dcbf2af649a05)

## Project tree

I've separated the classes by folders as you can see in the following tree.

```
│
├───Auth
│       DirectLineAuth.cs
│
├───Collections
│       TestEntriesCollection.cs
│
├───Objects
│       TestEntry.cs
│       TestSteps.cs
│
├───Tests
│       DirectLineTests.cs
│       FileTests.cs
│       IntegrationTests.cs
│
└───Utils
        ActivityResponse.cs
        API.cs
        Data.cs
        Globals.cs
```

#### Auth

* `DirectLineAuth.cs` contains the object for the received json in the authorization process.

#### Collections

* `TestEntriesCollection.cs` contains the object for the json that contains the information and the entries.

#### Objects

* `TestEntry.cs` contains the object for the json that contains the entry to test.
* `TestSteps.cs` contains the object for the json that contains the step that will be made by the bot.

#### Tests

* `DirectLineTests.cs` contains the testing cases for the authetication.
* `FileTests.cs` contains the testing cases for the file.
* `IntegrationTests.cs` contains thetesting for the integration test cases.

#### Utils

* `ActivityResponse.cs` contains the object for the reveiced json when asking for all the messages in a determined conversation.
* `Globals.cs` contains the object for loading the objects in the CodeAnalysis evaluator.
* `Data.cs` contains the string for the cases file path.
* `API.cs` contains functions for API calls.

## JSON structure

The json structure contains all the information necessary for the bot.

* **_`string`_** `secret`: DirectLine secret
* **_`string`_** `directlineGenerateTokenEndpoint`: DirectLine endpoint to get the token
* **_`string`_** `directlineConversationEndpoint`: DirectLine endpoint to get the conversation
* **_`List<TestEntry>`_** `entries`: Cases
  * **_`string`_** `name`: Case name
  * **_`string`_** `description`: Case description
  * **_`bool`_** `mute`: Enable or disable the case, set this to true to not test the case
  * **_`List<TestSteps>`_** `steps`: Steps to do in the case
    * **_`Activity`_** `request`: Request to the bot as `Activity`
    * **_`Activity`_** `response`: Request to the bot as `Activity`
    * **_`bool`_** `assert`: Assert string to do, have to return a boolean.

```json
{
  "secret": "YourDirectLineChatSecret",
  "directlineGenerateTokenEndpoint": "https://directline.botframework.com/v3/directline/tokens/generate",
  "directlineConversationEndpoint": "https://directline.botframework.com/v3/directline/conversations/",
  "entries": [
    {
      "name": "CaseName",
      "description": "CaseDescription",
      "mute":  false ,
      "steps": [
        {
          "request": {
           /* Request as activity */
          },
          "response": {
            /* Response as activity*/
          },
          "assert": /* Assert as string, have to return boolean */
        },
         {
          "request": {
           /* Request as activity */
          },
          "response": {
             /* Response as activity*/
          },
          "assert": /* Assert as string, have to return boolean */
        },
         {
          "request": {
           /* Request as activity */
          },
          "response": {
             /* Response as activity*/
          },
          "assert": /* Assert as string, have to return boolean */
        }
      ]
    }
  ]
}
```

## Building the JSON

### Requirements

1.  [Microsoft Bot Framework Emulator (V4 PREVIEW)](https://github.com/Microsoft/BotFramework-Emulator)
2.  [DirectLine Secret](https://docs.microsoft.com/en-us/azure/bot-service/rest-api/bot-framework-rest-direct-line-3-0-authentication?view=azure-bot-service-3.0#get-a-direct-line-secret)
3.  [DirectLine token generation endpoint](https://docs.microsoft.com/en-us/azure/bot-service/rest-api/bot-framework-rest-direct-line-3-0-authentication?view=azure-bot-service-3.0#generate-token), at the moment of this guide is `https://directline.botframework.com/v3/directline/tokens/generate`.
4.  [DirectLine conversation creation endpoint](https://directline.botframework.com/v3/directline/conversations), at the moment of this guide is `https://directline.botframework.com/v3/directline/conversations`.
5.  Any text editor to build the JSON.

### Build the main structure of the JSON

Here will be the main configuration for the JSON file.

```json
{
  "secret": /* Secret from DirectLine */,
  "directlineGenerateTokenEndpoint": /* DirectLine token endpoint from above */,
  "directlineConversationEndpoint": /* DirectLine conversation token from above */,
  "entries": [
    /* Here will be the cases */
  ]
}
```

### Building an entry

An entry contains some information about it: `name`, `description`, `mute` and `steps`.

```
{
    "name": /* Here will be the case name */,
    "description": /* Here will be the case description */,
    "mute":  /* Here will be if the case is enabled or not*/,
    "steps": [
      {
        "request": {
          /* Request as activity */
        },
        "response": {
          /* Response as activity*/
        },
        "assert": /* Assert as string, have to return boolean */
      },
        {
        "request": {
          /* Request as activity */
        },
        "response": {
            /* Response as activity*/
        },
        "assert": /* Assert as string, have to return boolean */
      },
        {
        "request": {
          /* Request as activity */
        },
        "response": {
            /* Response as activity*/
        },
        "assert": /* Assert as string, have to return boolean */
      }
    ]
  }
```

### Filling the steps

In order to fill the steps, we need to use the [Microsoft Bot Framework Emulator (V4 PREVIEW)](https://github.com/Microsoft/BotFramework-Emulator), using this application we can easily read all the serialized `Activity` that we are sending/receiving.

#### Sending a message and getting the `Activity`

Pick the message you want, to send and add it to the `request`.

<a href="https://gyazo.com/043c789136942c028cd6d30799f9a0ec"><img align="center" src="https://i.gyazo.com/043c789136942c028cd6d30799f9a0ec.png" alt="https://gyazo.com/043c789136942c028cd6d30799f9a0ec" width="1141"/></a>

So far the `step` looks like this:

```
{
  "request": {
    "channelData": {
      "clientActivityId": "112983719237123798"
    },
    "entities": [
      {
        "requiresBotState": true,
        "supportsListening": true,
        "supportsTts": true,
        "type": "ClientCapabilities"
      }
    ],
    "from": {
      "id": "default-user",
      "name": "User"
    },
    "id": "7b2c9300-6002131313131317830d951",
    "locale": "es",
    "text": "Hola",
    "textFormat": "plain",
    "timestamp": "2018-05-25T10:00:40.747Z",
    "type": "message"
  },
  "response": {},
  "assert": ""
}
```

#### Receiving a message and getting the `Activity`

Pick the message that you will be comparing and add it to the `response`.

**Message should be the last message you will receive, for example: if you ask `hi` and the bot returns `3` messages, you have to add the last one**

<a href="https://gyazo.com/df58224b4205d014f0bc5fe921f6a5e4"><img  align="center" src="https://i.gyazo.com/df58224b4205d014f0bc5fe921f6a5e4.png" alt="https://gyazo.com/df58224b4205d014f0bc5fe921f6a5e4" width="1137"/></a>

We have the respone now, o far the `step` looks like this:

```
{
  "request": {
    "channelData": {
      "clientActivityId": "112983719237123798"
    },
    "entities": [
      {
        "requiresBotState": true,
        "supportsListening": true,
        "supportsTts": true,
        "type": "ClientCapabilities"
      }
    ],
    "from": {
      "id": "default-user",
      "name": "User"
    },
    "id": "7b2c9300-6002131313131317830d951",
    "locale": "es",
    "text": "Hola",
    "textFormat": "plain",
    "timestamp": "2018-05-25T10:00:40.747Z",
    "type": "message"
  },
  "response": {
    "attachments": [],
    "channelId": "emulator",
    "conversation": {
      "id": "74a9db50-600asdasdadb28|livechat"
    },
    "entities": [],
    "from": {
      "id": "ba2e1c30-asdasd54fafccc92",
      "name": "Bot"
    },
    "id": "7be079b0-6002-11e8-b284-ffdb7830d951",
    "localTimestamp": "2018-05-25T11:00:41+01:00",
    "locale": "es",
    "membersAdded": [],
    "membersRemoved": [],
    "reactionsAdded": [],
    "reactionsRemoved": [],
    "recipient": {
      "id": "default-user",
      "role": "user"
    },
    "replyToId": "7b2c93asdasdasddb7830d951",
    "serviceUrl": "https://aaae2b27.ngrok.io",
    "text": "Selecciona una de las siguientes opciones:",
    "timestamp": "2018-05-25T10:00:41.931Z",
    "type": "message"
  },
  "assert": ""
}
```

#### Building the assert

In order to make the assert, the string evaluation has to return a `boolean`, a few examples:

1.  `"Response.Attachments.Count >= 3"`
2.  `"Response.Text == \"Message\""`
3.  `"Response.Attachments[0].Text == "Hello""`

In this case we will be comparing to the text, so our `assert` value will be:

`"assert": Response.Text == \"Selecciona una de las siguientes opciones:\""`.

In the end, our step will be like this:

```
{
  "request": {
    "channelData": {
      "clientActivityId": "112983719237123798"
    },
    "entities": [
      {
        "requiresBotState": true,
        "supportsListening": true,
        "supportsTts": true,
        "type": "ClientCapabilities"
      }
    ],
    "from": {
      "id": "default-user",
      "name": "User"
    },
    "id": "7b2c9300-6002131313131317830d951",
    "locale": "es",
    "text": "Hola",
    "textFormat": "plain",
    "timestamp": "2018-05-25T10:00:40.747Z",
    "type": "message"
  },
  "response": {
    "attachments": [],
    "channelId": "emulator",
    "conversation": {
      "id": "74a9db50-6asdasdasdb28|livechat"
    },
    "entities": [],
    "from": {
      "id": "ba2e1c30-5360-1asdasdasdfafccc92",
      "name": "Bot"
    },
    "id": "7be079b0-60asdasdasddb7830d951",
    "localTimestamp": "2018-05-25T11:00:41+01:00",
    "locale": "es",
    "membersAdded": [],
    "membersRemoved": [],
    "reactionsAdded": [],
    "reactionsRemoved": [],
    "recipient": {
      "id": "default-user",
      "role": "user"
    },
    "replyToId": "7b2c9300-60asdasdasdffdb7830d951",
    "serviceUrl": "https://aaae2b27.ngrok.io",
    "text": "Selecciona una de las siguientes opciones:",
    "timestamp": "2018-05-25T10:00:41.931Z",
    "type": "message"
  },
  "assert": Response.Text == \"Selecciona una de las siguientes opciones:\""
}
```

So with this example, you can add more steps to the main JSON and make a flow conversation.

#### Not asserting the message

If you just want to send a message without testing it, all you have to do is to leave empty the `assert`.

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
