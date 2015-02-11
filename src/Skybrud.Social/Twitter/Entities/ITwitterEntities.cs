using System.Collections.Generic;

namespace Skybrud.Social.Twitter.Entities {
    
    public interface ITwitterEntities {

        /// <summary>
        /// Gets a collection of all entities in an ascending order.
        /// </summary>
        IEnumerable<TwitterBaseEntity> GetAll();

        /// <summary>
        /// Gets a collection of all entities in a descending order.
        /// </summary>
        IEnumerable<TwitterBaseEntity> GetAllReversed();
    
    }

}