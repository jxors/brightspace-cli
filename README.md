# brighspace-cli

`brightspace-cli` is a CLI interface for the [Brightspace API](https://docs.valence.desire2learn.com/reference.html).

# Usage
The following verbs are avaiable (`brightspace-cli <verb> <arguments>`):
```
  auth

  classlist

  course

  courses

  grade

  grades

  interactive

  platform-version

  student

  submit-grade

  whoami

  help                Display more information on a specific command.

  version             Display version information.
```

# Authentication
The Brightspace API is built for webapps, some magic is needed to make it work for a CLI tool. First, run

```
brightspace-cli auth
```

to get an authentication URL. Open this URL in your favorite webbrowser, and log in. After logging in, you'll be redirected to a page that **does not exist.** Copy the URL of this page, and run:

```
brightspace-cli auth --url <URL>
```

to finish the authentication sequence.

# Building
This tool needs at least .NET core to build, which can be downloaded for Windows, Linux or Mac from [here](https://www.microsoft.com/net/download). If you're running Windows, you might want to install Visual Studio instead.

To run the tool directly from source, you can cd to the project directory, and invoke [`dotnet run`](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-run?tabs=netcore21).

For publishing self-contained binaries, there are two publishing profiles available under `brightspace-cli/Properties/PublishProfiles`. These are set up to build self-contained binaries for Windows (x64) and Linux (x64). If you're lucky, you can publish using the following command:

```
dotnet publish brightspace-cli/brightspace-cli.csproj /p:PublishProfile=Linux
```

This currently appears to be broken on some dotnet versions, so you might need to manually copy the parameters from the `*.pubxml` file into the command. If you're using Visual Studio, you can publish directly from the UI by right-clicking the project and choosing "Publish".
