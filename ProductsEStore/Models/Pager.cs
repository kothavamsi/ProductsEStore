using ProductsEStore.PagerHandler.Config;

namespace ProductsEStore.Models
{

    public class Pager
    {
        public bool IsRenderable { get; set; }
        public int PageSize { get; set; }
        public int ItemsCount { get; set; }
        public int TotalPages { get; set; }
        public int PagerDisplayLength { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        public int CurrentIndex { get; set; }
        public bool IsPreviousEnabled { get; set; }
        public bool IsNextEnabled { get; set; }
        public bool IsFirstEnabled { get; set; }
        public bool IsLastEnabled { get; set; }

        public Pager(int itemsCount, int currentPageNumber, int pageSize)
        {
            PagerDisplayLength = PagerSettings.PagerDisplayLength;
            PageSize = pageSize;
            IsNextEnabled = false;
            IsPreviousEnabled = false;
            IsRenderable = false;
            ConstructPager(itemsCount, currentPageNumber);
        }

        public int GetPageCount(int itemsCount)
        {
            return (itemsCount / PageSize) + ((itemsCount % PageSize) > 0 ? 1 : 0);
        }

        private void ConstructPager(int itemsCount, int currentPageNumber)
        {
            CurrentIndex = currentPageNumber;
            ItemsCount = itemsCount;

            TotalPages = GetPageCount(itemsCount);
            if (TotalPages > 1)
                IsRenderable = true;
            else
                IsRenderable = false;

            // If pager can move right wards
            if (TotalPages > PagerDisplayLength)
            {
                // if pageNo can be placed at center of our pager
                if (IsPageNumberCenter(currentPageNumber))
                {
                    var center = currentPageNumber;
                    StartIndex = center - PagerDisplayLength / 2;
                    EndIndex = center + PagerDisplayLength / 2;
                }
                else
                {
                    //if pageNo is towrads left side of pager
                    if (currentPageNumber <= PagerDisplayLength / 2)
                    {
                        StartIndex = 1;
                        EndIndex = StartIndex + PagerDisplayLength - 1;
                    }
                    //if pageNo is towrads right side of pager
                    else
                    {
                        EndIndex = TotalPages;
                        StartIndex = EndIndex - PagerDisplayLength + 1;
                    }
                }
            }
            // If pager can't move right wards and is a static pager
            else
            {
                StartIndex = 1;
                EndIndex = TotalPages;
            }

            // nextButton enable or disable ?
            if (IsPageAtEnd(currentPageNumber))
            {
                IsNextEnabled = false;
            }
            else
            {
                IsNextEnabled = true;
            }

            // prevButton enable or disable ?
            if (IsPageAtStart(currentPageNumber))
            {
                IsPreviousEnabled = false;
            }
            else
            {
                IsPreviousEnabled = true;
            }


            // firstButton enable or disable ?
            if (IsPageAffinityTowardsStart(currentPageNumber))
            {
                IsFirstEnabled = false;
            }
            else
            {
                IsFirstEnabled = true;
            }

            // lastButton enable or disable ?
            if (IsPageAffinityTowardsEnd(currentPageNumber))
            {
                IsLastEnabled = false;
            }
            else
            {
                IsLastEnabled = true;
            }
        }

        private bool IsPageNumberCenter(int pageNo)
        {
            return ((pageNo > PagerDisplayLength / 2) && ((pageNo + (PagerDisplayLength / 2)) <= TotalPages));
        }

        private bool IsPageAtStart(int pageNo)
        {
            if (pageNo == 1)
                return true;
            else
                return false;
        }

        private bool IsPageAffinityTowardsStart(int pageNo)
        {
            if (pageNo == 1)
                return true;
            else
                return false;
        }

        private bool IsPageAtEnd(int pageNo)
        {
            if (pageNo == TotalPages)
                return true;
            else
                return false;
        }

        private bool IsPageAffinityTowardsEnd(int pageNo)
        {
            if (pageNo == TotalPages)
                return true;
            else
                return false;
        }
    }
}