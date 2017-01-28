using Data.Domain;
using Desktop.BaseLib;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Desktop.Controllers
{
    class PartlistController
    {
        private IPartlistView _view;
        
        public PartlistController(IPartlistView view)
        {
            _view = view;
        }

        public void Load(IEnumerable<SetoviDijelovi> parts) 
        {
            var data = from p in parts
                       select new
                       {
                           Color = p.Boja.Ime,
                           Quantity = p.Broj,
                           Name = p.Kockica.Ime
                       };

            _view.DataGridView.DataSource = data.ToList();
            _view.DataGridView.Columns["Color"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            _view.DataGridView.Columns["Quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
    }
}
