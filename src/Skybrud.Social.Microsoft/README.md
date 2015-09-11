Skybrud.Social.Microsoft
========================

As this is an experimental project, it won't be released on NuGet or similar for now. You can however [**grab a build from Dropbox**](https://www.dropbox.com/sh/ubak1qionvji8mf/AACpWl98c0k8bYhoNGBBvMJsa/Skybrud.Social.Microsft%20-%20Build%200.0.1.2%20(2015-09-12)?dl=0) or download the repository and build the `Skybrud.Social.Microsoft` project.

## Usage

**Initializing a new OAuth client**<br />

The `MicrosoftOAuthClient` class is responsible for the raw communication with the various Microsoft APIs as well as authentication with Windows Live. The class can be initialized with one of the constructors, or simply by setting the properties like in the examples below:

```C#
// Initialize and configure the OAuth client
MicrosoftOAuthClient client = new MicrosoftOAuthClient {
    AccessToken = "Insert your access token here"
};
```

or:

```C#
// Initialize and configure the OAuth client
MicrosoftOAuthClient client = new MicrosoftOAuthClient {
    ClientId = "Insert your client ID here",
    ClientSecret = "Insert your client secret here",
    RedirectUri = "http://social.abjerner/microsoft/oauth/"
};
```

Authentication requires that you specify the client ID, client secret and redirect URI of your app (client).

* [**Create a new app** *at account.live.com*](https://account.live.com/developers/applications/create)
* [**List of existing app** *at account.live.com*](https://account.live.com/developers/applications/index)

<br />
<br />
**Generating the authorization URL / getting an authorization code**<br />

To start authenticating the user, you should generate and redirect the user to the authorization URL. The authorization URL is constructed of the client ID, client secret and redirect URI of the OAuth client as well as a state (random value for security purposes) and the scope (permissions) which your user should grant your app:

```C#
// Construct the authorization URL
string url = client.GetAuthorizationUrl(state, WindowsLiveScopes.Emails + WindowsLiveScopes.Birthday);
```

When redirecting the user to the auhtorization URL, the user will be given the option to grant your app access to the specified scope. After a successful login, the user is redirected back to the specified redirect URI, where the `state` and authorization `code` parameters are specified in the query string.

<br />
<br />
**Obtaining an access token**<br />

The authorization code can be obtained using the `GetAccessTokenFromAuthCode` method, where the response body will reveil the access token as well as some other information - eg. like the amount of seconds to when the access token will expire, or the refresh token if the `WindowsLiveScopes.OfflineAccess` scope has been specified.

```C#
// Exchange the authorization code for an access token
MicrosoftTokenResponse response = client.GetAccessTokenFromAuthCode(input.Code);

// Get the access token from the response body
string accessToken = response.Body.AccessToken;
```

<br />
<br />
**Initializing an instance of MicrosoftService**<br />

The `MicrosoftService` class can be initialized in a few different ways. Eg. from an access token:

```C#
// Initialize a new service instance from an access token
MicrosoftService service = MicrosoftService.CreateFromAccessToken("Insert your access token here");
```

Or from a refresh token:


```C#
// Initialize a new service instance from a refresh token
MicrosoftService service = MicrosoftService.CreateFromRefreshToken("client id", "client secret", "refresh token");
```

If you already have configured a `MicrosoftOAuthClient`, you can also specify that to the constructor instead:

```C#
// Initialize a new service instance from an existing OAuth client
MicrosoftService service = MicrosoftService.CreateFromOAuthClient(client);
```

<br />
<br />
**Getting information about the authenticated user**<br />

User information can be access through the Windows Live endpoint and the `GetSelf` method. Some properties depends on the scope specified - eg. information about emails of the user is only returned when the user has granted the `WindowsLiveScopes.Emails` scope.

```C#
WindowsLiveUserResponse response = service.WindowsLive.GetSelf();
    
<p>@response.Body.Id</p>
<p>@response.Body.Name</p>
<p>@response.Body.Locale</p>
<p>@(response.Body.Emails == null ? "Not available" : response.Body.Emails.Preferred)</p>
```
