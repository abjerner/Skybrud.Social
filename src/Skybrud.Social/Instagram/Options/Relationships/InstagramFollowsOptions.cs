using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Instagram.Options.Relationships {

    public class InstagramFollowsOptions : IGetOptions {

        #region Properties

        public int Count { get; set; }

        #endregion

        #region Constructors

        public InstagramFollowsOptions() { }

        public InstagramFollowsOptions(int count) {
            Count = count;
        }

        #endregion

        #region Member methods

        public SocialQueryString GetQueryString() {
            SocialQueryString qs = new SocialQueryString();
            if (Count > 0) qs.Add("count", Count);
            return qs;
        }

        #endregion

    }

}