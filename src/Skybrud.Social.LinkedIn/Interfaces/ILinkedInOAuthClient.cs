namespace Skybrud.Social.LinkedIn.Interfaces {
    
    public interface ILinkedInOAuthClient {

        string GetGroupPosts(long groupId);

        string GetGroupPosts(long groupId, string[] fields);

        string GetBasicProfile();
        string GetBasicProfile(string[] fields);

    }

}
