using System;
using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Social.Facebook {
    
    public class FacebookScopeCollection {

        #region Private fields

        private readonly List<FacebookScope> _list = new List<FacebookScope>();

        #endregion

        #region Properties

        public FacebookScope[] Items {
            get { return _list.ToArray(); }
        }

        #endregion

        #region Constructors

        public FacebookScopeCollection(params FacebookScope[] scopes) {
            _list.AddRange(scopes);
        }

        #endregion

        #region Member methods

        public void Add(FacebookScope scope) {
            _list.Add(scope);
        }

        public FacebookScope[] ToArray() {
            return _list.ToArray();
        }

        public string[] ToStringArray() {
            return (from scope in _list select scope.Name).ToArray();
        }

        public override string ToString() {
            return String.Join(",", from scope in _list select scope.Name);
        }

        #endregion

        #region Operator overloading

        public static implicit operator FacebookScopeCollection(FacebookScope scope) {
            return new FacebookScopeCollection(scope);
        }

        public static implicit operator FacebookScopeCollection(FacebookScope[] array) {
            return new FacebookScopeCollection(array ?? new FacebookScope[0]);
        }

        public static FacebookScopeCollection operator +(FacebookScopeCollection left, FacebookScope right) {
            left.Add(right);
            return left;
        }

        #endregion

    }

}