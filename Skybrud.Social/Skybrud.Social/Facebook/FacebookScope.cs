namespace Skybrud.Social.Facebook {
    
    public class FacebookScope {

        public static readonly FacebookScope ManagePages = new FacebookScope("manage_pages");

        public static readonly FacebookScope ReadStream = new FacebookScope("read_stream");

        public static readonly FacebookScope ReadFriendlists = new FacebookScope("read_friendlists");

        public string Name { get; private set; }

        private FacebookScope(string name) {
            Name = name;
        }

        public override string ToString() {
            return Name;
        }

        public static FacebookScopeCollection operator +(FacebookScope left, FacebookScope right) {
            return new FacebookScopeCollection(left, right);
        }

    }

}
