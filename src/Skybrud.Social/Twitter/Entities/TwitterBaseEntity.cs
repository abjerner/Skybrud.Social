namespace Skybrud.Social.Twitter.Entities {

    public class TwitterBaseEntity {

        #region Properties

        public int StartIndex { get; protected set; }
        public int EndIndex { get; protected set; }

        public int[] Indices {
            get { return new[] { StartIndex, EndIndex }; }
        }

        #endregion

        #region Constructors

        protected TwitterBaseEntity() { }

        #endregion

    }

}