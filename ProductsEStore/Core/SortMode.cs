using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyEBooks.Core;

namespace MyEBooks.Core
{
    public enum DBSortColumnValues
    {
        PostDate=1,
        UploadDate=2,
        PublicationdDate=3,
        MostReviews=4,
        AvgCustomerReview=5,
        MostDownloads=6
    }

    public class SortMode
    {
        Dictionary<DBSortColumnValues,string> sortMappings = new Dictionary<DBSortColumnValues,string>();
        public SortMode()
        {
            MapDBSortColumnToDropDown();
        }

        void MapDBSortColumnToDropDown()
        {
            sortMappings[DBSortColumnValues.UploadDate] = "upload";
            sortMappings[DBSortColumnValues.PublicationdDate] = "upload";
            sortMappings[DBSortColumnValues.UploadDate] = "upload";
            sortMappings[DBSortColumnValues.UploadDate] = "upload";
        }
    }
}