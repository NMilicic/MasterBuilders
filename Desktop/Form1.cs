using Business.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            KorisnikServices korisnikServices = new KorisnikServices();
            var tmp = korisnikServices.GetAll();
        }
    }
}
