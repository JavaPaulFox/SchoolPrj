using System.Web;

namespace SchoolPrj.ViewModel
{
    public class GoodViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string GoodsTypes { get; set; }
        public HttpPostedFileBase Image { get; set; }
    }
}