using Desktop.BaseLib;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class frmPicture : Form, IView
    {
        public frmPicture(string url)
        {
            InitializeComponent();
            picBox.ImageLocation = url;
        }
    }
}
