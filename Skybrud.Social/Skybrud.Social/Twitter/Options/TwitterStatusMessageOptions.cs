namespace Skybrud.Social.Twitter.Options {

    public class TwitterStatusMessageOptions {

        /// <summary>
        /// When set to <var>true</var>, each tweet returned in a timeline will include a user object
        /// including only the status authors numerical ID. Omit this parameter to receive
        /// the complete user object.
        /// </summary>
        public bool TrimUser = false;

        /// <summary>
        /// When set to <var>true</var>, any Tweets returned that have been retweeted by the
        /// authenticating user will include an additional <var>current_user_retweet</var>
        /// node, containing the ID of the source status for the retweet.
        /// </summary>
        public bool IncludeMyRetweet = false;

        /// <summary>
        /// The entities node will be disincluded when set to <var>false</var>.
        /// </summary>
        public bool IncludeEntities = false;

    }

}