using System;

namespace Skybrud.Social.GitHub.Options {
    
    public class GitHubGetCommitOptions {

        /// <summary>
        /// SHA or branch to start listing commits from.
        /// </summary>
        public string Sha { get; set; }

        /// <summary>
        /// Only commits containing this file path will be returned.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// GitHub login or email address by which to filter by commit author.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Only commits after this date will be returned.
        /// </summary>
        public DateTime? Since { get; set; }

        /// <summary>
        /// Only commits before this date will be returned.
        /// </summary>
        public DateTime? Until { get; set; }

    }

}