Skybrud.Social.Microsoft
========================

As this is an experimental project, it won't be released on NuGet or similar for now. You can however [**grab a build from Dropbox**](https://www.dropbox.com/sh/ubak1qionvji8mf/AACY2DjhldUXVhTpc3X8b8oXa/Skybrud.Social.Microsoft%20-%20Build%200.0.1.2%20%282015-09-12%29?dl=0) or download the repository and build the `Skybrud.Social.Microsoft` project.

## Usage

##### Initializing a new OAuth client

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
##### Generating the authorization URL / getting an authorization code

To start authenticating the user, you should generate and redirect the user to the authorization URL. The authorization URL is constructed of the client ID, client secret and redirect URI of the OAuth client as well as a state (random value for security purposes) and the scope (permissions) which your user should grant your app:

```C#
// Construct the authorization URL
string url = client.GetAuthorizationUrl(state, WindowsLiveScopes.Emails + WindowsLiveScopes.Birthday);
```

When redirecting the user to the auhtorization URL, the user will be given the option to grant your app access to the specified scope. After a successful login, the user is redirected back to the specified redirect URI, where the `state` and authorization `code` parameters are specified in the query string.

<br />
<br />
##### Obtaining an access token

The access token can be obtained using the `GetAccessTokenFromAuthCode` method, where the response body will reveil the access token as well as some other information - eg. like the amount of seconds to when the access token will expire, or the refresh token if the `WindowsLiveScopes.OfflineAccess` scope has been specified.

For the example below, the `authCode` parameter is the authorization code received when the user has succesfully logged in through the Windows Live login dialog, and been redirected back to your site. At this point, the `code` parameter in the query string will contain the authorization code.

```C#
// Exchange the authorization code for an access token
MicrosoftTokenResponse response = client.GetAccessTokenFromAuthCode(authCode);

// Get the access token from the response body
string accessToken = response.Body.AccessToken;
```

<br />
<br />
##### Initializing an instance of MicrosoftService

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
##### Getting information about the authenticated user

User information can be accessed through the Windows Live endpoint and the `GetSelf` method. Some properties depends on the scope specified - eg. information about emails of the user is only returned when the user has granted the `WindowsLiveScopes.Emails` scope.

```C#
WindowsLiveUserResponse response = service.WindowsLive.GetSelf();
    
<p>@response.Body.Id</p>
<p>@response.Body.Name</p>
<p>@response.Body.Locale</p>
<p>@(response.Body.Emails == null ? "Not available" : response.Body.Emails.Preferred)</p>
```

<br />
<br />
##### Complete example

In the example below, I've tried to demonstrate how a login page can be implemented (involving the steps explained above).

```C#
@using Skybrud.Social.Microsoft
@using Skybrud.Social.Microsoft.OAuth
@using Skybrud.Social.Microsoft.Responses.Authentication
@using Skybrud.Social.Microsoft.Scopes
@using Skybrud.Social.Microsoft.WindowsLive.Objects.Users
@using Skybrud.Social.Microsoft.WindowsLive.Responses
@using Skybrud.Social.Microsoft.WindowsLive.Scopes

@inherits System.Web.Mvc.WebViewPage

@{

    // Gets the arguments from the query string
    var input = new {
        Code = Request.QueryString["code"],
        State = Request.QueryString["state"],
        Error = new {
            HasError = !String.IsNullOrWhiteSpace(Request.QueryString["error"]),
            Text = Request.QueryString["error"],
            ErrorDescription = Request.QueryString["error_description"]  
        }
    };

    // Configure the OAuth client
    MicrosoftOAuthClient client = new MicrosoftOAuthClient {
        ClientId = "Insert your client ID here",
        ClientSecret = "Insert your client secret here",
        RedirectUri = "Insert your redirect URI here"
    };

    // Session expired?
    if (input.State != null && Session["Skybrud.Social_" + input.State] == null) {
        <div class="error">Session expired?</div>
        return;
    }

    // Check whether an error response was received from Microsoft
    if (input.Error.HasError) {
        Session.Remove("Skybrud.Social_" + input.State);
        <div class="error">
            Error: @input.Error.Text<br />
            @input.Error.ErrorDescription
        </div>
        return;
    }

    // Redirect the user to the Microsoft login dialog
    if (String.IsNullOrWhiteSpace(input.Code)) {

        // Generate a new unique/random state
        string state = Guid.NewGuid().ToString();

        // Save the state in the current user session
        Session["Skybrud.Social_" + state] = "/";

        // Construct the authorization URL
        string url = client.GetAuthorizationUrl(state, WindowsLiveScopes.Emails + WindowsLiveScopes.Birthday);

        // Redirect the user
        Response.Redirect(url);
        return;

    }
    
    <h2>Access Token</h2>

    // Exchange the authorization code for an access token
    MicrosoftTokenResponse accessTokenResponse;
    try {
        Session.Remove("Skybrud.Social_" + input.State);
        accessTokenResponse = client.GetAccessTokenFromAuthCode(input.Code);
    } catch (Exception ex) {
        <div class="error">
            <b>Unable to acquire access token</b><br />
            <pre>@ex.Message</pre>
        </div>
        return;
    }

    <h5>Access Token</h5>
    <div>@accessTokenResponse.Body.AccessToken</div>

    <h5>Scope</h5>
    foreach (MicrosoftScope scope in accessTokenResponse.Body.Scope.Items) {
        <div>@scope</div>
    }
    
    <h5>Raw response</h5>
    <pre>@accessTokenResponse.Response.Body</pre>
    
    <h2>Information about the authenticated user</h2>
    
    // Initialize a new MicrosoftService so we can make calls to the API
    MicrosoftService service = MicrosoftService.CreateFromAccessToken(accessTokenResponse.Body.AccessToken);
    
    // Make the call to the Windows Live API / endpoint
    WindowsLiveUserResponse response = service.WindowsLive.GetSelf();
    
    // Get a reference to the response body
    WindowsLiveUser user = response.Body;
    
    <h5>ID</h5>
    <div>@user.Id</div>
    
    <h5>Name</h5>
    <div>@user.Name</div>
    
    <h5>Email</h5>
    <div>
        @if (user.Emails != null && !String.IsNullOrWhiteSpace(user.Emails.Preferred)) {
            @user.Emails.Preferred
        } else {
            <em>Not availble</em>
        }
    </div>
    
    <h5>Raw response</h5>
    <pre>@response.Response.Body</pre>
    
}
```
