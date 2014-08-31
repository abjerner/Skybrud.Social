namespace Skybrud.Social.Instagram.Endpoints {

    public class InstagramEndpoints {

        public InstagramService Service { get; private set; }

        public InstagramLocationsEndpoint Locations {
            get { return Service.Locations; }
        }

        public InstagramMediaEndpoint Media {
            get { return Service.Media; }
        }

        public InstagramRelationshipsEndpoint Relationships {
            get { return Service.Relationships; }
        }

        public InstagramTagsEndpoint Tags {
            get { return Service.Tags; }
        }

        public InstagramUsersEndpoint Users {
            get { return Service.Users; }
        }

        internal InstagramEndpoints(InstagramService service) {
            Service = service;
        }

    }

}
