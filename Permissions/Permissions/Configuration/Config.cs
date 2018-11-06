namespace Permissions.Configuration
{
    public class Config
    {
        public int View { get; set; }

        public int IndexView { get; set; }

        public int FirstPageView { get; set; }

        public int SecondPageView { get; set; }

        public int ThirdPageView { get; set; }

        public int ViewComponent { get; set; }

        public int IndexLinkFirstPageComponent { get; set; }

        public int IndexLinkThirdPageComponent { get; set; }

        public int FirstPageButtonCreateComponent { get; set; }

        public int FirstPageButtonAddCommentComponent { get; set; }

        public int SecondPageButtonApproveComponent { get; set; }

        public int SecondPageButtonRejectComponent { get; set; }

        public int SecondPageButtonRejectApprovedComponent { get; set; }

        public int SecondPageButtonApproveRejectedComponent { get; set; }

        public int Controller { get; set; }
               
        public int Action { get; set; }
    }
}