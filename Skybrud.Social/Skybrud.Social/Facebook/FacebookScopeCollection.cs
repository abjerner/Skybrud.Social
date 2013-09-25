using System;
using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Social.Facebook {
    
    public class FacebookScopeCollection {

        private List<FacebookScope> _list = new List<FacebookScope>();

        public FacebookScopeCollection(params FacebookScope[] scopes) {
            _list.AddRange(scopes);
        }
        
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

        public static FacebookScopeCollection operator +(FacebookScopeCollection left, FacebookScope right) {
            left.Add(right);
            return left;
        }

    }

}