using System;
using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Social.GitHub {

    public class GitHubScopeCollection {

        private readonly List<GitHubScope> _list = new List<GitHubScope>();

        public GitHubScope[] Items {
            get { return _list.ToArray(); }
        }

        public GitHubScopeCollection(params GitHubScope[] scopes) {
            _list.AddRange(scopes);
        }

        public void Add(GitHubScope scope) {
            _list.Add(scope);
        }

        public GitHubScope[] ToArray() {
            return _list.ToArray();
        }

        public string[] ToStringArray() {
            return (from scope in _list where scope.Name.Length > 0 select scope.Name).ToArray();
        }

        public override string ToString() {
            return String.Join(",", ToStringArray());
        }

        public static GitHubScopeCollection operator +(GitHubScopeCollection left, GitHubScope right) {
            left.Add(right);
            return left;
        }

    }

}