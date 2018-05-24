# Integration test for Microsoft's Bot Framework using Direct Line channel

This repository has a test solution in Visual Studio that does integration test for Microsoft's Bot Framework using the DirectLine channel.

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
  "entries":[
    {
      "name": "CaseName",
      "description": "CaseDescription",
      "mute":  false ,
      "steps": [
        {
          "request": {
           // Request as activity
          },
          "response": {
            /// Response as activity
          },
          "assert": /// Assert as boolean
        },
         {
          "request": {
           // Request as activity
          },
          "response": {
            /// Response as activity
          },
          "assert": /// Assert as boolean
        },
         {
          "request": {
           // Request as activity
          },
          "response": {
            /// Response as activity
          },
          "assert": /// Assert as boolean
        }
      ]
    }
]
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
