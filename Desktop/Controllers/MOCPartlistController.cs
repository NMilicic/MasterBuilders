﻿using Data.Domain;
using Desktop.BaseLib;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Desktop.Controllers
{
    class MOCPartlistController
    {
        private IListView _view;
        
        public MOCPartlistController(IListView view)
        {
            _view = view;
        }

        public void Load(IEnumerable<MocPart> parts) 
        {
            var data = from p in parts
                       select new
                       {
                           Color = p.Color.Name,
                           Quantity = p.Number,
                           Name = p.Part.Name,
                           Category = p.Part.Category.Name
                       };

            _view.DataGridView.DataSource = data.ToList();
            _view.DataGridView.Columns["Color"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            _view.DataGridView.Columns["Quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
    }
}
