﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.BaseLib
{
    public interface IDatabasePartsView : IView
    {
        ComboBox Category { get; }
        string SearchName { get; }

        DataGridView DataGridView { get; }
    }
}
