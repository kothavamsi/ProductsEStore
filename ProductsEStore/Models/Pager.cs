using ProductsEStore.PagerHandler.Config;

namespace ProductsEStore.Models
{

    public class Pager
    {
        public bool IsRenderable { get; set; }
        public int PageSize { get; set; }
        public int ItemsCount { get; set; }
        public int TotalPages { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        public int CurrentPageIndex { get; set; }
        public bool IsPreviousEnabled { get; set; }
        public bool IsNextEnabled { get; set; }
        public bool IsFirstEnabled { get; set; }
        public bool IsLastEnabled { get; set; }
        private int PagerSize { get; set; }

        public Pager(int itemsCount, int currentPageIndex, int pageSize, int pagerSize)
        {
            PageSize = pageSize;
            IsNextEnabled = false;
            IsPreviousEnabled = false;
            IsRenderable = false;
            ItemsCount = itemsCount;
            CurrentPageIndex = currentPageIndex;
            PagerSize = pagerSize;
            ConstructPager();
        }

        private void ConstructPager()
        {
            TotalPages = (ItemsCount / PageSize) + ((ItemsCount % PageSize) > 0 ? 1 : 0);
            if (TotalPages > 1)
                IsRenderable = true;
            else
                IsRenderable = false;

            // If pager can move right wards
            if (TotalPages > PagerSize)
            {
                // if pageNo can be placed at center of our pager
                if (IsPageNumberCenter(CurrentPageIndex))
                {
                    var center = CurrentPageIndex;
                    StartIndex = center - PagerSize / 2;
                    EndIndex = center + PagerSize / 2;
                }
                else
                {
                    //if pageNo is towrads left side of pager
                    if (CurrentPageIndex <= PagerSize / 2)
                    {
                        StartIndex = 1;
                        EndIndex = StartIndex + PagerSize - 1;
                    }
                    //if pageNo is towrads right side of pager
                    else
                    {
                        EndIndex = TotalPages;
                        StartIndex = EndIndex - PagerSize + 1;
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
            if (IsPageAtEnd(CurrentPageIndex))
            {
                IsNextEnabled = false;
            }
            else
            {
                IsNextEnabled = true;
            }

            // prevButton enable or disable ?
            if (IsPageAtStart(CurrentPageIndex))
            {
                IsPreviousEnabled = false;
            }
            else
            {
                IsPreviousEnabled = true;
            }


            // firstButton enable or disable ?
            if (IsPageAffinityTowardsStart(CurrentPageIndex))
            {
                IsFirstEnabled = false;
            }
            else
            {
                IsFirstEnabled = true;
            }

            // lastButton enable or disable ?
            if (IsPageAffinityTowardsEnd(CurrentPageIndex))
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
            return ((pageNo > PagerSize / 2) && ((pageNo + (PagerSize / 2)) <= TotalPages));
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