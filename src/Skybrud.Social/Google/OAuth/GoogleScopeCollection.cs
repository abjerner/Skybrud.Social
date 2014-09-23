using System;
using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Social.Google.OAuth {
    
    public class GoogleScopeCollection {

        private readonly List<GoogleScope> _list = new List<GoogleScope>();

        public GoogleScopeCollection(params GoogleScope[] scopes) {
            _list.AddRange(scopes);
        }
        
        public void Add(GoogleScope scope) {
            _list.Add(scope);
        }

        public GoogleScope[] ToArray() {
            return _list.ToArray();
        }

        public string[] ToStringArray() {
            return (from scope in _list select scope.Name).ToArray();
        }

        public override string ToString() {
            return String.Join(" ", from scope in _list select scope.Name);
        }

        public static implicit operator GoogleScopeCollection(GoogleScope[] array) {
            return new GoogleScopeCollection(array ?? new GoogleScope[0]);
        }

        public static GoogleScopeCollection operator +(GoogleScopeCollection left, GoogleScope right) {
            left.Add(right);
            return left;
        }

    }

}