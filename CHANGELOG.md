Skybrud.Social Changelog
========================

### Skybrud.Social 0.1.1
_15th of November, 2013_

__Facebook__

-   Testing uncovered an issue in <var>v0.1.0</var> with the OAuth authentication flow in the Facebook client. The release of <var>v0.1.1</var> fixes this issue.

<br /><br />

### Skybrud.Social 0.1.0
_13th of November, 2013_

__Download__
-   <a href="https://github.com/abjerner/Skybrud.Social/releases/download/0.1.0/Skybrud.Social.v0.1.0.zip">Download ZIP</a>
-   <a href="https://www.nuget.org/packages/Skybrud.Social/0.1.0">Get on NuGet</a>

This is the first public release since 0.0.0.7 from back in June, so there is a lot of new changes and additions to Skybrud.Social, which includes a number for breaking changes. I have tried to list these changes as best as possible below. 

The implementation of all services have been rewritten to follow a specific structure so that they work in a similar manner.

All services using OAuth will have a class called <var>ExampleOAuthClient</var> for authentication purposes and raw communication with that service. Most of these services divide their methods into a couple of endpoints - for instance the class <var>TwitterOAuthClient</var> will have a property called <var>Users</var> for methods in the API that are related to users, while a property called <var>Statuses</var> for API methods related to status messages.

Similar there will be a class called <var>ExampleService</var> for a more object-oriented approach. This class will use the corresponding <var>ExampleOAuthClient</var> class internally. The <var>ExampleService</var> class will also have similar properties like the <var>ExampleOAuthClient</var> class - but now with object-obriented access to the API methods.

Due to the changes since version 0.0.0.7 there will be some breaking changes.

__Json__

-   Skybrud.Social has a custom build JSON parser that is used for the various API's returning JSON content. This parser has been improved a bit since the release of Skybrud.Social 0.0.0.7. These changes affects most objects troughout the various implementations.

    -   Most obects that are returned by API calls now have methods for JSON serialization/deserialization. These objects will have:
    
        -   A property called <var>JsonObject</var> for storing the instance of <var>JsonObject</var> the object was originally parsed from.
        -   A <var>ToJson</var> method for generating a JSON string representing the object.
        -   <var>SaveJson</var> method that saves a JSON representation of the object to a specified path.
        -   Static <var>LoadJson</var> method for loading and parsing the JSON file at the specified path.
        -   Static <var>ParseJson</var> for parsing a JSON string representation of the object.
        -   Static <var>Parse</var> method for parsing an instance of <var>JsonObject</var>.

__OAuth__

-   Added classes for OAauth authentication and communication. These classes are mostly for use with OAuth 1.0a.

__BitBucket__

-   Added implementation of the BitBucket API. This is however still not a complete implementation.

__Facebook__

-   Introduction of the <var>FacebookOAuthClient</var> for OAuth authentication and raw communication with the Facebook API.
-   Class <var>FacebookApplication</var> was made obsolete. Use the class <var>FacebookOAuthClient</var> instead.
-   A lot of API methods in class <var>FacebookService</var> was made obsolete. Use the methods by the <var>Methods</var> endpoint in classes <var>FacebookService</var> and <var>FacebookOAuthClient</var> - for an object-oriented or raw approach respectively.
-   Class <var>FacebookIdName</var> was renamed to <var>FacebookObject</var>.
 
__GitHub__

-   Added very basic implementation of the GitHub API.

__Google__

-   Added very basic implementation of the Google API's with authentication support.
-   Implemented endpoint for Google Analytics

__Twitter__

-   Introduction of the <var>TwitterOAuthClient</var> for OAuth authentication and raw communication with the Twitter API.
-   Class <var>TwitterAccessInformation</var> was made obsolete. Use the class <var>TwitterOAuthClient</var> instead.
-   The class <var>TwitterRestApi</var> used for the secure OAuth communication in Skybrud.Social 0.0.0.7 had some flaws. This class has now been replaced by <var>TwitterOAuthClient</var>.
-   Class <var>TwitterUtils</var> were added with various helper methods.
-   Class <var>TwitterUserTimeline</var> was renamed <var>TwitterTimeline</var> since it can be applied to several types of timelines. In a similar manner, the class <var>TwitterUserTimelineOptions</var> has now been renamed to <var>TwitterTimelineOptions</var>.
-   General improvements of the Twitter implementation

__Instagram__

-   The authorization logic in class <var>InstagramService</var> has now been removed. Use <var>InstagramOAuthClient</var> instead.
-   Various endpoint methods have been renamed and/or moved around so they follow the same structure as described in the begeinning of this changelog.
-   Objects no longer has methods for converting to XML. Since the Instagram API returns contents as JSON, the objects can now instead be converted back to JSON.

__Vimeo__

-   Skybrud.Social 0.0.0.7 featured an implementation for Vimeo's Simple API. Since there is both a simple and an advanced API, the namespace <var>Skybrud.Social.Vimeo</var> has now been moved to <var>Skybrud.Social.Vimeo.Simple</var>.
-   Added implementation of the Vimeo Advanced API. This is however still not a complete implementation.






















