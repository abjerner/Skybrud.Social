using Newtonsoft.Json.Linq;
using Skybrud.Social.Box.Objects.Users;
using Skybrud.Social.Json.Extensions.JObject;
using Skybrud.Social.Time;

namespace Skybrud.Social.Box.Objects.Folders {
    
    public class BoxFolderInfo : BoxObject {

        #region Properties

        /// <summary>
        /// Gets the type of the item.
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// Gets the ID of the folder.
        /// </summary>
        public string Id { get; private set; }

        public string Name { get; private set; }

        public SocialDateTime CreatedAt { get; private set; }

        public SocialDateTime ModifiedAt { get; private set; }

        public string Description { get; private set; }

        public long Size { get; private set; }

        public BoxUserInfo CreatedBy { get; private set; }

        public BoxUserInfo ModifiedBy { get; private set; }

        public SocialDateTime TrashedAt { get; private set; }

        public SocialDateTime PurgedAt { get; private set; }

        public SocialDateTime ContentCreatedAt { get; private set; }

        public SocialDateTime ContentModifiedAt { get; private set; }

        public BoxUserInfo OwnedBy { get; private set; }

        #endregion

        #region Constructors

        private BoxFolderInfo(JObject obj) : base(obj) {
            Type = obj.GetString("type");
            Id = obj.GetString("id");
            Name = obj.GetString("name");
            CreatedAt = obj.GetString("created_at", SocialDateTime.Parse);
            ModifiedAt = obj.GetString("modified_at", SocialDateTime.Parse);
            Description = obj.GetString("description");
            Size = obj.GetInt64("size");
            CreatedBy = obj.GetObject("created_by", BoxUserInfo.Parse);
            ModifiedBy = obj.GetObject("modified_by", BoxUserInfo.Parse);
            TrashedAt = obj.GetString("trashed_at", SocialDateTime.Parse);
            PurgedAt = obj.GetString("purged_at", SocialDateTime.Parse);
            ContentCreatedAt = obj.GetString("content_created_at", SocialDateTime.Parse);
            ContentModifiedAt = obj.GetString("content_modified_at", SocialDateTime.Parse);
            OwnedBy = obj.GetObject("owned_by", BoxUserInfo.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>BoxFolderInfo</code> from the specified <code>JObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JObject</code> to parse.</param>
        public static BoxFolderInfo Parse(JObject obj) {
            return obj == null ? null : new BoxFolderInfo(obj);
        }

        #endregion

    }

}