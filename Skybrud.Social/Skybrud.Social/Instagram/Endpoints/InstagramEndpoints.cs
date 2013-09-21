namespace Skybrud.Social.Instagram.Endpoints {

    public class InstagramEndpoints {

        public InstagramUsersEndpoint Users { get; private set; }
        public InstagramRelationshipsEndpoint Relationships { get; private set; }
        public InstagramMediaEndpoint Media { get; private set; }
        public InstagramLocationsEndpoint Locations { get; private set; }
        public InstagramTagsEndpoint Tags { get; private set; }

        internal InstagramEndpoints(InstagramService service) {
            Users = new InstagramUsersEndpoint(service);
            Relationships = new InstagramRelationshipsEndpoint(service);
            Media = new InstagramMediaEndpoint(service);
            Locations = new InstagramLocationsEndpoint(service);
            Tags = new InstagramTagsEndpoint(service);
        }
    
    }

}
