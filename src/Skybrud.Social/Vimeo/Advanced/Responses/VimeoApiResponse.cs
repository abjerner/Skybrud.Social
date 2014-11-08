using Skybrud.Social.Json;

namespace Skybrud.Social.Vimeo.Advanced.Responses {
    
    public class VimeoApiResponse {
    
        /// <summary>
        /// The amount of seconds the Vimeo Advanced API used to generate the
        /// response.
        /// </summary>
        public double GeneratedIn { get; protected set; }

        /// <summary>
        /// The state of the response. If no exceptions have been thrown, this
        /// property will most likely be set to "ok".
        /// </summary>
        public string Stat { get; protected set; }

        /// <summary>
        /// All responses received from the Vimeo Advanced API has some meta
        /// data telling whether the request was successful or failed. This
        /// method will parse these meta data and throw an exception if an
        /// error has occured.
        /// </summary>
        protected void ParseResponse(JsonObject obj) {

            GeneratedIn = obj.GetDouble("generated_in");
            Stat = obj.GetString("stat");

            if (Stat == "ok") return;

            if (Stat == "fail") {
                JsonObject err = obj.GetObject("err");
                if (err != null) {
                    int code = err.GetInt32("code");
                    string expl = err.GetString("expl");
                    string msg = err.GetString("msg");
                    throw new VimeoException(code, expl, msg);
                }
            }

            // TODO: Any other scenarios?

        }
    
    }

}