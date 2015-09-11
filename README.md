Skybrud.Social
==============

Skybrud.Social is a framework in .NET for integration with various social services like Twitter, Facebook and Instagram. The framework will handle all the technical parts and API communication so you don't have to.

### Installation

1. [**NuGet Package**][NuGetPackage]  
Install this NuGet package in your Visual Studio project. Makes updating easy.

2. [**ZIP file**][GitHubRelease]  
Grab a ZIP file of the latest release; unzip and move `Skybrud.Social.dll` to the bin directory of your project.

2. [**Builds**][DropboxFolder]  
I may occasional upload a build to Dropbox. These are builds in between releases, and are not tested at the same level as releases. As above, move `Skybrud.Social.dll` to the bin directory of your project.

### Found a bug? Have a question?

* Please feel free to [**create an issue**][Issues], and I will get back to you ;)

### Changelog

The [**releases page**](https://github.com/abjerner/Skybrud.Social/releases) lists all releases since v0.1.1, and each there will be some information for each release on the most significant changes.

### Documentation

Improving the code has higher priority than documentation, so I'm currently a bit behind on the documentation. For the small amount of documentation already written, have a look at the [Skybrud.Social website][Website].

### Experimantal

Supporting and maintaining the implementation for each service takes up a lot of time. I have played around with a few other services than whats officially supported in Skybrud.Social, but haven't had the time to finish these. They should therefore be treated as experimental and under development:

* [**LinkedIn**](https://github.com/abjerner/Skybrud.Social/tree/master/src/Skybrud.Social.LinkedIn)<br />Adds support for both OAuth 1.0a and OAuth 2 authenticcation as well as limited access to the LinkedIn API.

* [**Microsoft**](https://github.com/abjerner/Skybrud.Social/tree/master/src/Skybrud.Social.Microsoft)<br />Lets users authenticate using their Microsoft / Windows Live account (user), as well as getting information about that user.


[Website]: http://social.skybrud.dk/
[NuGetPackage]: https://www.nuget.org/packages/Skybrud.Social
[GitHubRelease]: https://github.com/abjerner/Skybrud.Social/releases/latest
[DropboxFolder]: https://www.dropbox.com/sh/ubak1qionvji8mf/AACq5X5b2Ic6MPPZznrzfsl2a?dl=0
[Changelog]: https://github.com/abjerner/Skybrud.Social/blob/master/CHANGELOG.md
[Issues]: https://github.com/abjerner/Skybrud.Social/issues
