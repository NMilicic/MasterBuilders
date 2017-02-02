using Data.Domain;
using Desktop.BaseLib;
using System.Linq;

namespace Desktop.Controllers
{
    class SetlistController
    {
        private IListView _view;
        
        public SetlistController(IListView view)
        {
            _view = view;
        }

        public void Load(IQueryable<LSet> sets) 
        {
            var data = from s in sets
                       select new
                       {
                           Name = s.Name,
                           Theme = s.Theme.BaseTheme.Name,
                           Subtheme = s.Theme.Name,
                           
                       };

            _view.DataGridView.DataSource = data.ToList().Distinct().ToList();
        }
    }
}
