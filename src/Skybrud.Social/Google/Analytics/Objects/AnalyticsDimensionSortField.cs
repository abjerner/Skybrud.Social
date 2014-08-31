using System;
using Skybrud.Social.Google.Analytics.Interfaces;

namespace Skybrud.Social.Google.Analytics.Objects {
    
    public class AnalyticsDimensionSortField : IAnalyticsSortField {

        #region Properties

        public AnalyticsSortOrder Order { get; set; }

        public IAnalyticsField Field {
            get { return Dimension; }
        }

        public AnalyticsDimension Dimension { get; set; }

        #endregion

        #region Constructors

        public AnalyticsDimensionSortField() {
            // Default constructor
        }

        public AnalyticsDimensionSortField(AnalyticsDimension dimension, AnalyticsSortOrder order) {
            if (dimension == null) throw new ArgumentNullException("dimension");
            Dimension = dimension;
            Order = order;
        }

        #endregion

    }

}