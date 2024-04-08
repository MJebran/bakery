using Bakery.ClassLibrary.Services;
using Bakery.WebApp.Data;

namespace Bakery.ClassLibrary.Services
{
    public interface IMenuContentsLogic
    {
        public List<Size> sizes {get; set;}
        public List<Category> categories {get; set;}
        public List<Itemtype> items {get; set;}
        public List<Itemtype> filterItems {get; set;}
        public void FilterSelection(string category);
    }
}