using System;
using System.Linq;
using System.Windows.Forms;

namespace CinemaCitySeatsReservationApp
{
    public partial class SeatsForm : Form
    {
        public event Action<string, string[]> Order;
        private string _row;
        private string[] _seats;

        public SeatsForm()
        {
            InitializeComponent();
        }

        private void order_btn_Click(object sender, EventArgs e)
        {
            _row = row_textbox.Text;
            _seats = seats_textbox.Text.Split(',');
            this.Hide();
            Order?.Invoke(_row, _seats);
        }

        private void seats_textbox_TextChanged(object sender, EventArgs e)
        {
            order_btn.Enabled = true;
        }
    }
}
