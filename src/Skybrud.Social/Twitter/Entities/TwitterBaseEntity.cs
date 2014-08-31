namespace Skybrud.Social.Twitter.Entities {

    public class TwitterBaseEntity {

        protected TwitterBaseEntity() {
            // make constructor protected
        }

        public int StartIndex { get; protected set; }
        public int EndIndex { get; protected set; }

        public int[] Indices {
            get { return new[] { StartIndex, EndIndex }; }
        }

    }

}
