using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {

    public class FacebookComments {

        public int Count { get; private set; }
        public FacebookCommentSummary[] Data { get; private set; }

        public static FacebookComments Parse(JsonObject obj) {
            if (obj == null) return new FacebookComments { Data = new FacebookCommentSummary[0] };
            return new FacebookComments {
                Count = obj.GetInt("count"),
                Data = obj.GetArray("data", FacebookCommentSummary.Parse) ?? new FacebookCommentSummary[0]
            };
        }

    }

}
