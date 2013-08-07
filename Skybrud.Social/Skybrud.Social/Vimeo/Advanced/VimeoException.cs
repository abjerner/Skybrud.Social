using System;

namespace Skybrud.Social.Vimeo.Advanced {
    
    public class VimeoException : Exception {

        public int Code { get; private set; }
        public string Explanation { get; private set; }

        public VimeoException(int code, string explanation, string message) : base(message) {
            Code = code;
            Explanation = explanation;
        }

    }

}
