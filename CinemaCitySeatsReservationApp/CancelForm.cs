using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaCitySeatsReservationApp
{
    public partial class CancelForm : Form
    {
        public event Action Cancel;
        public CancelForm()
        {
            InitializeComponent();
        }

        private void cancel_ctn_Click(object sender, EventArgs e)
        {
            Cancel?.Invoke();
            this.Dispose();
            this?.Close();
        }
    }
}
