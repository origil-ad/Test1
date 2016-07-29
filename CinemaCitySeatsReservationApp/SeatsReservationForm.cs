using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CinemaCitySeatsReservation;

namespace CinemaCitySeatsReservationApp
{
    public partial class SeatsReservationForm : Form
    {
        private readonly ReservationManager _reservationManager;
        private SeatsForm _seatsForm;
        private CancelForm _cancelForm;

        public SeatsReservationForm()
        {
            InitializeComponent();
            _cancelForm = new CancelForm();
            _cancelForm.Hide();
            _cancelForm.Cancel += Cancel;

            _reservationManager = new ReservationManager();
            _reservationManager.CancelProgram += Close;
            
        }


        private void Theater_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clear(new[] {movies_combobox, dates_combobox, times_combobox });
            UpdateMovies(_reservationManager.GetMoviesByCinema(Theater_combobox.Text));
        }

        private void movies_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clear(new[] {dates_combobox, times_combobox });
            UpdateDates(_reservationManager.GetDatesByMovie(movies_combobox.Text));
        }

        private void dates_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clear(new []{times_combobox});
            UpdateTimes(_reservationManager.GetTimesByDate(dates_combobox.Text));
        }

        private void times_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _reservationManager.SetTime(times_combobox.Text);
            order_btn.Enabled = true;
        }

        private void order_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            _seatsForm = new SeatsForm();
            _seatsForm.Order += MonitorSeatsForm;
            _reservationManager.CancelProgram += _seatsForm.Close;
            _reservationManager.FinishRound += ShowCancelForm;
            _seatsForm.ShowDialog();
        }

        private void ShowCancelForm()
        {
            _cancelForm.ShowDialog();
        }

        private void Cancel()
        {
            _cancelForm.Dispose();
            _cancelForm?.Close();
            _reservationManager.Cancel();
        }

        private void MonitorSeatsForm(string row, string[] seats)
        {
            _reservationManager.OrderTickets(row, seats);
        }

        private void Clear(IEnumerable<ComboBox> comboboxes)
        {
            order_btn.Enabled = false;
            foreach (var combobox in comboboxes)
            {
                combobox.Text = "בחר ערך";
                combobox.Items.Clear();
            }
        }

        private void UpdateMovies(IEnumerable<string> movies)
        {
            movies_combobox.Items.Clear();
            movies_combobox.Items.AddRange(movies.ToArray());
        }

        private void UpdateDates(IEnumerable<string> dates)
        {
            dates_combobox.Items.Clear();
            dates_combobox.Items.AddRange(dates.ToArray());
        }

        private void UpdateTimes(IEnumerable<string> times)
        {
            times_combobox.Items.Clear();
            times_combobox.Items.AddRange(times.ToArray());
        }
    }
}
