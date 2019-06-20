# Skybrud.Social [![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE.md) [![NuGet](https://img.shields.io/nuget/v/Skybrud.Social.svg)](https://www.nuget.org/packages/Skybrud.Social) [![NuGet](https://img.shields.io/nuget/dt/Skybrud.Social.svg)](https://www.nuget.org/packages/Skybrud.Social)

Skybrud.Social in general is a framework in .NET for integration with various social services like Twitter, Facebook and Instagram. The framework will handle all the technical parts and API communication so you don't have to.

**Notice** As of `v1.0`, this repository and the corresponding package (`Skybrud.Social.Core`) will just contain the core functionality, and not the implementation for the individual services. Each supported service will now have it's own repository and package. You can find a list of [supported services](#services) further down this page.





### Installation

To install the core library of Skybrud.Social, simply pick one of the three methods below:

1. [**NuGet Package**][NuGetPackage]  
   Install this NuGet package in your Visual Studio project. Makes updating easy.
2. [**ZIP file**][GitHubRelease]  
   Grab a ZIP file of the latest release; unzip and move `Skybrud.Social.Core.dll` to the bin directory of your project.
3. [**Builds**][DropboxFolder]  
   I may occasional upload a build to Dropbox. These are builds in between releases, and are not tested at the same level as releases. As above, move `Skybrud.Social.Core.dll` to the bin directory of your project.


This will just install the core/base functionality. If you're looking for the implementation for a given service - eg. [Facebook][RepoFacebook] or [Twitter][RepoTwitter], you will have to install a package for each service individually. For more information, have a look at the list of [supported services](#services).

**v0.9.x?**  
For legacy reasons, you can still install the old `Skybrud.Social` NuGet package. As of `v1.0` it's really just a dummy package, but with dependencies for `Skybrud.Social.Core` as well as `Skybrud.Social.Facebook`, `Skybrud.Social.Twitter`, `Skybrud.Social.Instagram`, `Skybrud.Social.Google`, `Skybrud.Social.BitBucket`, `Skybrud.Social.GitHub` and `Skybrud.Social.Vimeo`, which were all supported natively in `v0.9.x`.






### Found a bug? Have a question?

* Please feel free to [**create an issue**][Issues], and I will get back to you ;)





### Changelog

The [**releases page**](https://github.com/abjerner/Skybrud.Social/releases) lists all releases since v0.1.1, where there will be some information for each release on the most significant changes.





### Documentation

Improving the code has higher priority than documentation, so I'm currently a bit behind on the documentation. For the small amount of documentation already written, have a look at the [**Skybrud.Social website**][Website]. The website will contain documentation for the core functionality as well as the implementation of the individual services.





### Services

| Package                                       | NuGet                                                                                                                                        | .NET Standard 1.3 | .NET Framework 4.5 | .NET Framework 4.6 |
|-----------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------|:-------------:|:------------------:|:------------------:|
| Skybrud.Social.Core                           | [![Install via NuGet](https://img.shields.io/nuget/v/Skybrud.Social.Core.svg)](https://www.nuget.org/packages/Skybrud.Social.Core)           | ✓ | ✓ | ✓ |
| [Skybrud.Social.**BitBucket**][RepoBitBucket] | [![Install via NuGet](https://img.shields.io/nuget/v/Skybrud.Social.BitBucket.svg)](https://www.nuget.org/packages/Skybrud.Social.BitBucket)      |   | ✓ |   |
| [Skybrud.Social.**Facebook**][RepoFacebook]   | [![Install via NuGet](https://img.shields.io/nuget/v/Skybrud.Social.Facebook.svg)](https://www.nuget.org/packages/Skybrud.Social.Facebook)       | ✓ | ✓ | ✓ |
| [Skybrud.Social.**GitHub**][RepoGitHub]       | [![Install via NuGet](https://img.shields.io/nuget/v/Skybrud.Social.GitHub.svg)](https://www.nuget.org/packages/Skybrud.Social.GitHub)         |   | ✓ |   |
| [Skybrud.Social.**Google**][RepoGoogle]       | [![Install via NuGet](https://img.shields.io/nuget/v/Skybrud.Social.Google.svg)](https://www.nuget.org/packages/Skybrud.Social.Google)         | ✓ | ✓ | ✓ |
| [Skybrud.Social.**Instagram**][RepoInstagram] | [![Install via NuGet](https://img.shields.io/nuget/v/Skybrud.Social.Instagram.svg)](https://www.nuget.org/packages/Skybrud.Social.Instagram)      | ✓ | ✓ | ✓ |
| [Skybrud.Social.**LinkedIn**][RepoLinkedIn]   | [![Install via NuGet](https://img.shields.io/nuget/v/Skybrud.Social.LinkedIn.svg)](https://www.nuget.org/packages/Skybrud.Social.LinkedIn)       |   | ✓ |   |
| [Skybrud.Social.**Meetup**][RepoMeetup] | [![Install via NuGet](https://img.shields.io/nuget/v/Skybrud.Social.Meetup.svg)](https://www.nuget.org/packages/Skybrud.Social.Meetup)      | ✓ | ✓ | ✓ |
| [Skybrud.Social.**Microsoft**][RepoMicrosoft] | [![Install via NuGet](https://img.shields.io/nuget/v/Skybrud.Social.Microsoft.svg)](https://www.nuget.org/packages/Skybrud.Social.Microsoft)      |   | ✓ |   |
| [Skybrud.Social.**Pinterest**][RepoPinterest] | [![Install via NuGet](https://img.shields.io/nuget/v/Skybrud.Social.Pinterest.svg)](https://www.nuget.org/packages/Skybrud.Social.Pinterest)      |   | ✓ |   |
| [Skybrud.Social.**Slack**][RepoSlack]         | [![Install via NuGet](https://img.shields.io/nuget/v/Skybrud.Social.Slack.svg)](https://www.nuget.org/packages/Skybrud.Slack.Slack)           |   | ✓ |   |
| [Skybrud.Social.**Spotify**][RepoSpotify]     | [![Install via NuGet](https://img.shields.io/nuget/v/Skybrud.Social.Spotify.svg)](https://www.nuget.org/packages/Skybrud.Social.Spotify)     |   | ✓ |   |
| [Skybrud.Social.**Twitter**][RepoTwitter]     | [![Install via NuGet](https://img.shields.io/nuget/v/Skybrud.Social.Twitter.svg)](https://www.nuget.org/packages/Skybrud.Social.Twitter)     | ✓ | ✓ | ✓ |
| [Skybrud.Social.**Vimeo**][RepoVimeo]         | [![Install via NuGet](https://img.shields.io/nuget/v/Skybrud.Social.Vimeo.svg)](https://www.nuget.org/packages/Skybrud.Social.Vimeo)         | ✓ | ✓ | ✓ |



[Website]: http://social.skybrud.dk/
[WebsiteBitBucket]: http://social.skybrud.dk/bitbucket/
[WebsiteFacebook]: http://social.skybrud.dk/facebook/
[WebsiteGitHub]: http://social.skybrud.dk/github/
[WebsiteGoogle]: http://social.skybrud.dk/google/
[WebsiteAnalytics]: http://social.skybrud.dk/google/analytics/
[WebsiteYouTube]: http://social.skybrud.dk/google/youtube/
[WebsiteInstagram]: http://social.skybrud.dk/instagram/
[WebsiteTwitter]: http://social.skybrud.dk/twitter/
[WebsiteVimeo]: http://social.skybrud.dk/vimeo/
[WebsiteLinkedIn]: http://social.skybrud.dk/linkedin/
[WebsiteMicrosoft]: http://social.skybrud.dk/microsoft/
[WebsitePinterest]: http://social.skybrud.dk/pinterest/
[WebsiteSlack]: http://social.skybrud.dk/slack/
[WebsiteSpotify]: http://social.skybrud.dk/spotify/






[RepoBitBucket]: https://github.com/abjerner/Skybrud.Social.BitBucket
[RepoFacebook]: https://github.com/abjerner/Skybrud.Social.Facebook
[RepoGitHub]: https://github.com/abjerner/Skybrud.Social.GitHub
[RepoGoogle]: https://github.com/abjerner/Skybrud.Social.Google
[RepoInstagram]: https://github.com/abjerner/Skybrud.Social.Instagram
[RepoLinkedIn]: https://github.com/abjerner/Skybrud.Social.LinkedIn
[RepoMeetup]: https://github.com/abjerner/Skybrud.Social.Meetup
[RepoMicrosoft]: https://github.com/abjerner/Skybrud.Social.Microsoft
[RepoPinterest]: https://github.com/abjerner/Skybrud.Social.Pinterest
[RepoSlack]: https://github.com/abjerner/Skybrud.Social.Slack
[RepoSpotify]: https://github.com/abjerner/Skybrud.Social.Spotify
[RepoTwitter]: https://github.com/abjerner/Skybrud.Social.Twitter
[RepoVimeo]: https://github.com/abjerner/Skybrud.Social.Vimeo


[NuGetCore]: https://www.nuget.org/packages/Skybrud.Social.Core
[NuGetBitBucket]: https://www.nuget.org/packages/Skybrud.Social.BitBucket
[NuGetFacebook]: https://www.nuget.org/packages/Skybrud.Social.Facebook
[NuGetGitHub]: https://www.nuget.org/packages/Skybrud.Social.GitHub
[NuGetGoogle]: https://www.nuget.org/packages/Skybrud.Social.Google
[NuGetInstagram]: https://www.nuget.org/packages/Skybrud.Social.Instagram
[NuGetLinkedIn]: https://www.nuget.org/packages/Skybrud.Social.LinkedIn
[NuGetMeetup]: https://www.nuget.org/packages/Skybrud.Social.Meetup
[NuGetMicrosoft]: https://www.nuget.org/packages/Skybrud.Social.Microsoft
[NuGetPinterest]: https://www.nuget.org/packages/Skybrud.Social.Pinterest
[NuGetSlack]: https://www.nuget.org/packages/Skybrud.Social.Slack
[NuGetTwitter]: https://www.nuget.org/packages/Skybrud.Social.Twitter
[NuGetVimeo]: https://www.nuget.org/packages/Skybrud.Social.Vimeo
[NuGetSpotify]: https://www.nuget.org/packages/Skybrud.Social.Spotify

[NuGetPackage]: https://www.nuget.org/packages/Skybrud.Social
[GitHubRelease]: https://github.com/abjerner/Skybrud.Social/releases/latest
[DropboxFolder]: https://www.dropbox.com/sh/ubak1qionvji8mf/AACq5X5b2Ic6MPPZznrzfsl2a?dl=0
[Changelog]: https://github.com/abjerner/Skybrud.Social/releases
[Issues]: https://github.com/abjerner/Skybrud.Social/issues
