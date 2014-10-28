using System;
using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Social.GitHub {

    public class GitHubScopeCollection {

        #region Private fields

        private readonly List<GitHubScope> _list = new List<GitHubScope>();

        #endregion

        #region Properties

        public GitHubScope[] Items {
            get { return _list.ToArray(); }
        }

        #endregion

        #region Constructors

        public GitHubScopeCollection(params GitHubScope[] scopes) {
            _list.AddRange(scopes);
        }

        #endregion

        #region Member methods

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

        #endregion

        #region Operator overloading

        public static implicit operator GitHubScopeCollection(GitHubScope[] array) {
            return new GitHubScopeCollection(array ?? new GitHubScope[0]);
        }

        public static GitHubScopeCollection operator +(GitHubScopeCollection left, GitHubScope right) {
            left.Add(right);
            return left;
        }

        #endregion

    }

}