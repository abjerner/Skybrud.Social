Skybrud.Social Changelog
========================

### Skybrud.Social 0.9.0
_13th of February, 2015_

__Download__
-   <a href="https://github.com/abjerner/Skybrud.Social/releases/download/v0.9.0/Skybrud.Social.v0.9.0.zip">Download ZIP</a>
-   <a href="https://www.nuget.org/packages/Skybrud.Social/0.9.0" target="_blank">Get on NuGet</a>

Since it has been more than a year since `v0.1.2`, there is a lot of (breaking) changes in `v0.9.0`, and it will take too long time to address them here. I'm working on a new website for Skybrud.Social, that also will contain a long awaited and improved documentation, that will address some of these changes, or at least contain samples on how to use the most recent code.

The changes since `v0.9.0-alpha` mostly consist of improvements to the Twitter implementation, which also has lead to some breaking changes. Here is a small summary of what was changed.

**Twitter**

* All methods in the various Twitter endpoints now return an object representing the entire response, rather than just the response body. Eg. the `GetStatusMessage` will now return an instance of `TwitterStatusMessageResponse` rather than `TwitterStatusMessage` as before.

*  The structure of the `TwitterReverseGeocodeResponse` class (which was introduced in `v0.9.0-alpha`) has now been updated to more closely follow the names and structure of the JSON returned by the Twitter API.

* The `TwitterMethodAttribute` class was removed. This class was probably only used internally, and used for documentation purposes.

* Until now the `TwitterStatusMessage` class has had a property named `Contributors`. The `contributors` property is still present in the returned JSON, but is has been empty in all cases that I have encountered, and Twitter has very limited documentation on the property. It has therefore been removed for now.

* As of `v0.9.0-alpha` the old `TwitterException` was renamed to `TwitterDeprecatedException` since a new and improved `TwitterException` was added instead. The remaining code still using `TwitterDeprecatedException` has now been removed, and the class has therefore been removed as well.

* The `GetTweet` methods in the `Statuses` endpoint has now been removed since they we're really just aliases of the `GetStatusMessage` methods.

### Skybrud.Social 0.9.0-alpha1
_7th of February, 2015_

__Download__
-   <a href="https://github.com/abjerner/Skybrud.Social/releases/download/v0.9.0-alpha1/Skybrud.Social.v0.9.0-alpha1.zip">Download ZIP</a>
-   <a href="https://www.nuget.org/packages/Skybrud.Social/0.9.0-alpha1">Get on NuGet</a>

Skybrud.Social 0.9.0-alpha1 is - as suggested by it's name - is an alpha release. This means that things are not as heavily tested, and that there therefore is a higher risk of experiencing bugs. If you encounter any bugs, or simply things you feel should be different, please make sure to [create an issue][Issues]. That would help me a lot.

A lot has changed with this release, so I'm not going to list all breaking changes here. However one of the most signicant changes is what is returned by the calls to the various APIs.

**Raw endpoints**  
Skybrud.Social has a lot of raw endpoints for the various services. These endpoint deal with the raw communication, and are probably not used by much users. In earlier releases, a call with a method in a raw endpoint would typically return a string representing the response body. Some services/APIs specify extra information in the response headers. Some return an empty response body if an error occurs, but only set a HTTP status code in the response informing about the error. So since it wasn't possible to gather these information from the response body, methods in the raw endpoints will now return an instance of `SocialHttpResponse` instead. This class will have properties like `StatusCode` returning an instance of `HttpStatusCode`, and `Body` returning the response body as a string. Not all methods have been updated to return an instance of `SocialHttpResponse`, but this will be fixed in v1.0 or before.

**Object-oriented endpoint**  
Some of the normal endpoints (solid or object-oriented endpoints if you will) have also been updated. Where a call for information about a given Twitter user previously would return an instance of `TwitterUser` representing the response body, that same method will now return an instance of `TwitterUserResponse` more widely representing the entire response. The `Body` property will then return the `TwitterUser` object parsed from the response body. The `Response` property will in a similar way return the underlying instance of `SocialHttpResponse`.

This release also features a lot of other fixes and additions. But this being an alpha release, they will be left somewhat undocumented for now. Along with my work towards v1.0, I'm also taking the time to finally writing some proper documentation, so there will be plenty of examples on how to use and utilize Skybrud.Social v1.0. An optimistic plan is to have v1.0 released in one of the upcoming weeks.

**Facebook**  
In earlier versions, all methods in the Facebook API were exposed through the `Methods` endpoint. As of this release, methods are now located in a relevant endpoint - eg. a `Posts` endpoint for dealing with posts, and a `Pages` endpoint for dealing with pages.

### Skybrud.Social 0.1.2
_20th of January, 2014_

__Download__
-   <a href="https://github.com/abjerner/Skybrud.Social/releases/download/v0.1.2/Skybrud.Social.v0.1.2.zip">Download ZIP</a>
-   <a href="https://www.nuget.org/packages/Skybrud.Social/0.1.2">Get on NuGet</a>

__Google Analytics__

-   Skybrud.Social 0.1.2 primarily focuses on improved support for Google Analytics - including sorting and filtering when fetching data from a profile.
-   Google has introduced a Realtime API for accessing live data from Google Analytics. Skybrud.Social 0.1.2 now also has support for this API, and live data can noew be retrieved in a similar manner to how regular data is retrieved. The Realtime API is however still in closed beta, so developers must request access by Google in order to use it.
-   In v0.1.1 metrics and dimensions were defined by string constants. To allow for some more powerful logic, these constants have now been turned into instances of <var>AnalyticsMetric</var> and <var>AnalyticsDimension</var> respectively. The two classes now use operator overloading to play nicely with strings, but may still break your existing code in some scenarious if you're using the string constants.

__Facebook__

-   Version 0.1.0 introduced the class <var>FacebookOAuthClient</var> to replace <var>FacebookApplication</var>. However the <var>GetAppAccessToken</var> method was still only available in <var>FacebookApplication</var>. The method is now also been added to <var>FacebookOAuthClient</var>, which is the recommended way to use the method from now on. The method is still available in <var>FacebookApplication</var>, but the entire class is marked as deprecated.

<br /><br />

### Skybrud.Social 0.1.1
_15th of November, 2013_

__Download__
-   <a href="https://github.com/abjerner/Skybrud.Social/releases/download/v0.1.1/Skybrud.Social.v0.1.1.zip">Download ZIP</a>
-   <a href="https://www.nuget.org/packages/Skybrud.Social/0.1.1">Get on NuGet</a>

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


[Issues]: https://github.com/abjerner/Skybrud.Social/issues
