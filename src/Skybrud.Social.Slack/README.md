Skybrud.Social.Slack
====================

As this is an experimental project, it won't be released on NuGet or similar for now. You can however [**grab a build from Dropbox**](https://www.dropbox.com/sh/ubak1qionvji8mf/AAD_Zgebg0g1Yr6wJx7X64C9a/Skybrud.Social.Slack%20-%20Build%200.0.1.4%20(2015-09-13)?dl=0) or download the repository and build the `Skybrud.Social.Slack` project.

## Usage

##### Initializing a new OAuth client

The `SlackOAuthClient` class is responsible for the raw communication with the Slack API as well as authentication (using OAuth 2.0). The class can be initialized with one of the constructors, or simply by setting the properties like in the examples below:

```C#
// Initialize and configure the OAuth client
SlackOAuthClient client = new SlackOAuthClient {
    AccessToken = "Insert your access token here"
};
```

or:

```C#
// Initialize and configure the OAuth client
SlackOAuthClient client = new SlackOAuthClient {
    ClientId = "Insert your client ID here",
    ClientSecret = "Insert your client secret here",
    RedirectUri = "Insert your redirect URI here"
};
```

Authentication requires that you specify the client ID, client secret and redirect URI of your application.

* [**Create a new application** *at api.slack.com*](https://api.slack.com/applications/new)
* [**List of existing applications** *at api.slack.com*](https://api.slack.com/applications)


<br />
<br />
##### Generating the authorization URL / getting an authorization code

To start authenticating the user, you should generate and redirect the user to the authorization URL. The authorization URL is constructed of the client ID, client secret and redirect URI of the OAuth client as well as a state (random value for security purposes).

As a developer, you can either choose not to specify a scope (the permissions that the user should grant your app). By not specifying a scope, it seems that Slack automatically will request the user to grant `SlackScopes.Identify`, `SlackScopes.Read` and `SlackScopes.Post` scopes.

```C#
// Construct the authorization URL (without scope)
string url = client.GetAuthorizationUrl(state);
```

Or you can specify one or more scopes that the user should grant your app:

```C#
// Construct the authorization URL (with scope)
string url = client.GetAuthorizationUrl(state, SlackScopes.Identify + SlackScopes.Read);
```

When redirecting the user to the auhtorization URL, the user will be given the option to grant your app access to the specified scope. After a successful login, the user is redirected back to the specified redirect URI, where the `state` and authorization `code` parameters are specified in the query string.



<br />
<br />
##### Obtaining an access token

The authorization code can be obtained using the `GetAccessTokenFromAuthCode` method, where the response body will reveil the access token as well as some other information - eg. like which scopes were granted and which team the user has selected.

```C#
// Exchange the authorization code for an access token
SlackTokenResponse response = client.GetAccessTokenFromAuthCode(input.Code);

// Get the access token from the response body
string accessToken = response.Body.AccessToken;
```


<br />
<br />
##### Initializing an instance of SlackService

The `SlackService` class can be initialized in a few different ways. Eg. from an access token:

```C#
// Initialize a new service instance from an access token
SlackService service = SlackService.CreateFromAccessToken("Insert your access token here");
```

If you already have configured a `SlackOAuthClient`, you can also specify that to the constructor instead:

```C#
// Initialize a new service instance from an existing OAuth client
SlackService service = SlackService.CreateFromOAuthClient(client);
```


<br />
<br />
##### Complete example

In the example below, I've tried to demonstrate how a login page can be implemented (involving the steps explained above).

```C#
@using Skybrud.Social.Slack
@using Skybrud.Social.Slack.Exceptions
@using Skybrud.Social.Slack.OAuth
@using Skybrud.Social.Slack.Objects.Authentication
@using Skybrud.Social.Slack.Objects.Users
@using Skybrud.Social.Slack.Responses.Authentication
@using Skybrud.Social.Slack.Responses.Users
@using Skybrud.Social.Slack.Scopes

@inherits System.Web.Mvc.WebViewPage

@{

    // Gets the arguments from the query string
    var input = new {
        Code = Request.QueryString["code"],
        State = Request.QueryString["state"],
        Error = new {
            HasError = !String.IsNullOrWhiteSpace(Request.QueryString["error"]),
            Text = Request.QueryString["error"]
        }
    };

    // Configure the OAuth client
    SlackOAuthClient client = new SlackOAuthClient {
        ClientId = "Insert your client ID here",
        ClientSecret = "Insert your client secret here",
        RedirectUri = "Insert your redirect URI here"
    };

    // Session expired?
    if (input.State != null && Session["Skybrud.Social_" + input.State] == null) {
        <div class="error">Session expired?</div>
        return;
    }

    // Check whether an error response was received from Slack
    if (input.Error.HasError) {
        Session.Remove("Skybrud.Social_" + input.State);
        <div class="error">
            Error: @input.Error.Text
        </div>
        return;
    }

    // Redirect the user to the Slack login dialog
    if (String.IsNullOrWhiteSpace(input.Code)) {

        // Generate a new unique/random state
        string state = Guid.NewGuid().ToString();

        // Save the state in the current user session
        Session["Skybrud.Social_" + state] = "/";

        // Construct the authorization URL
        string url = client.GetAuthorizationUrl(state, SlackScopes.Identify + SlackScopes.Read);

        // Redirect the user
        Response.Redirect(url);
        return;

    }
    
    <h2>Access Token</h2>

    // Exchange the authorization code for an access token
    SlackTokenResponse accessTokenResponse;
    try {
        Session.Remove("Skybrud.Social_" + input.State);
        accessTokenResponse = client.GetAccessTokenFromAuthCode(Request.QueryString["code"]);
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
    foreach (SlackScope scope in accessTokenResponse.Body.Scope.Items) {
        <div>@scope</div>
    }
    
    <h5>Raw response</h5>
    <pre>@accessTokenResponse.Response.Body</pre>
    
    // Initialize a new SlackService so we can make calls to the API
    SlackService service = SlackService.CreateFromAccessToken(accessTokenResponse.Body.AccessToken);
    
    <h2>Test the authentication</h2>

    string userId;
    
    try {
        
        // Make the call to the authentication endpoint
        SlackAuthenticationTestResponse authTestResponse = service.Authentication.GetTest();

        // Get the response body
        SlackAuthenticationTest test = authTestResponse.Body;

        // Set the user ID so we can use it later
        userId = test.UserId;
    
        <h5>ID</h5>
        <div>@test.UserId</div>
    
        <h5>Name</h5>
        <div>@test.User</div>
    
        <h5>Raw response</h5>
        <pre>@authTestResponse.Response.Body</pre>
        
    } catch (Exception ex) {
        <div class="error">
            <b>Failed to get authentication test</b><br />
            <pre>@ex.Message</pre>
            <pre>@ex.StackTrace</pre>
        </div>
        return;
    }
    
    <h2>Get information about a user</h2>
    
    try {
        
        // Make the call to the users endpoint
        SlackGetUserInfoResponse getUserResponse = service.Users.GetInfo(userId);

        // Get the user object
        SlackUser user = getUserResponse.Body.User;
    
        <h5>ID</h5>
        <div>@user.Id</div>
    
        <h5>Name</h5>
        <div>@user.RealName</div>
    
        <h5>Email</h5>
        <div>@user.Profile.Email</div>
    
        <h5>Raw response</h5>
        <pre>@getUserResponse.Response.Body</pre>
        
    } catch (SlackException ex) {
        <div class="error">
            <b>Failed to get user information</b><br />
            <pre>@ex.Message</pre>
            <pre>@ex.StackTrace</pre>
    
            <h5>Raw response</h5>
            <pre>@ex.Response.Body</pre>
        </div>
        return;
    } catch (Exception ex) {
        <div class="error">
            <b>Failed to get user information</b><br />
            <pre>@ex.Message</pre>
            <pre>@ex.StackTrace</pre>
        </div>
        return;
    }
    
}
```
