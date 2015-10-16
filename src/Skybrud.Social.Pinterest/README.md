Skybrud.Social.Pinterest
========================

As this is an experimental project, it won't be released on NuGet or similar for now. You can however [**grab a build from Dropbox**](https://www.dropbox.com/sh/ubak1qionvji8mf/AADqHLr0GuvlLhPGACaA7hOMa/Skybrud.Social.Pinterest%20-%20Build%200.0.2.10%20(2015-10-16)?dl=0) or download the repository and build the `Skybrud.Social.Pinterest` project.

## Usage

##### Initializing a new OAuth client

The `PinterestOAuthClient` class is responsible for the raw communication with the Pinterest API as well as authentication. The class can be initialized with one of the constructors, or simply by setting the properties like in the examples below:

```C#
// Initialize and configure the OAuth client
PinterestOAuthClient client = new PinterestOAuthClient {
    AccessToken = "Insert your access token here"
};
```

or:

```C#
// Initialize and configure the OAuth client
PinterestOAuthClient client = new PinterestAuthClient {
    ClientId = "Insert your client ID here",
    ClientSecret = "Insert your client secret here",
    RedirectUri = "http://social.abjerner/pinterest/oauth/"
};
```

Authentication requires that you specify the client ID, client secret and redirect URI of your app (client).

* [**List of existing app** *at developers.pinterest.com*](https://developers.pinterest.com/apps/)


## Documentation

Although still a bit limited, further documentation can be found at the [Skybrud.Social website](http://social.skybrud.dk/pinterest/).
