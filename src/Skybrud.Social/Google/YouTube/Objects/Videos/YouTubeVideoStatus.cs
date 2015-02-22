using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Objects.Videos {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/videos#status</cref>
    /// </see>
    public class YouTubeVideoStatus : GoogleApiObject {

        #region Properties

        public YouTubeVideoUploadStatus UploadStatus { get; private set; }

        public YouTubeVideoFailureReason? FailureReason { get; private set; }

        public YouTubeVideoRejectionReason? RejectionReason { get; private set; }

        public YouTubePrivacyStatus PrivacyStatus { get; private set; }

        public YouTubeVideoLicense License { get; private set; }

        public bool IsEmbeddable { get; private set; }

        public bool PublicStatsViewable { get; private set; }

        #endregion

        #region Constructor

        protected YouTubeVideoStatus(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>YouTubeVideoStatus</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static YouTubeVideoStatus Parse(JsonObject obj) {

            if (obj == null) return null;

            // Parse the upload status
            YouTubeVideoUploadStatus uploadStatus;
            string strUploadStatus = obj.GetString("uploadStatus");
            if (!Enum.TryParse(strUploadStatus, true, out uploadStatus)) {
                throw new Exception("Unknown upload status \"" + strUploadStatus + "\" - please create an issue so it can be fixed https://github.com/abjerner/Skybrud.Social/issues/new");
            }

            YouTubeVideoFailureReason? failureReason = null;
            if (obj.HasValue("failureReason")) {
                YouTubeVideoFailureReason reason;
                string strReason = obj.GetString("failureReason");
                if (Enum.TryParse(strReason, out reason)) {
                    failureReason = reason;
                } else {
                    throw new Exception("Unknown failure reason \"" + strReason + "\" - please create an issue so it can be fixed https://github.com/abjerner/Skybrud.Social/issues/new");
                }
            }

            YouTubeVideoRejectionReason? rejectionReason = null;
            if (obj.HasValue("rejectionReason")) {
                YouTubeVideoRejectionReason reason;
                string strReason = obj.GetString("rejectionReason");
                if (Enum.TryParse(strReason, out reason)) {
                    rejectionReason = reason;
                } else {
                    throw new Exception("Unknown rejection reason \"" + strReason + "\" - please create an issue so it can be fixed https://github.com/abjerner/Skybrud.Social/issues/new");
                }
            }

            // Parse the privacy status
            YouTubePrivacyStatus privacyStatus;
            string strPrivacyStatus = obj.GetString("privacyStatus");
            if (!Enum.TryParse(strPrivacyStatus, true, out privacyStatus)) {
                throw new Exception("Unknown privacy status \"" + strPrivacyStatus + "\" - please create an issue so it can be fixed https://github.com/abjerner/Skybrud.Social/issues/new");
            }

            // Parse the privacy status
            YouTubeVideoLicense videoLicense;
            string strLicense = obj.GetString("license");
            if (!Enum.TryParse(strLicense, true, out videoLicense)) {
                throw new Exception("Unknown license \"" + strLicense + "\" - please create an issue so it can be fixed https://github.com/abjerner/Skybrud.Social/issues/new");
            }
            
            return new YouTubeVideoStatus(obj) {
                UploadStatus = uploadStatus,
                PrivacyStatus = privacyStatus,
                FailureReason = failureReason,
                RejectionReason = rejectionReason,
                License = videoLicense,
                IsEmbeddable = obj.GetBoolean("embeddable"),
                PublicStatsViewable = obj.GetBoolean("publicStatsViewable")
            };
        
        }

        #endregion

    }

}