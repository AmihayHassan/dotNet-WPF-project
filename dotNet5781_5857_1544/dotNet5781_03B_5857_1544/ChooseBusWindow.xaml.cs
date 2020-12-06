﻿using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace dotNet5781_03B_5857_1544
{
    /// <summary>
    /// Interaction logic for ChooseBusWindow.xaml
    /// </summary>
    public partial class ChooseBusWindow : Window
    {
        private Bus b;
        MainWindow wnd = (MainWindow)Application.Current.MainWindow;

        public ChooseBusWindow(Bus bus)
        {
            InitializeComponent();
            this.b = bus;
        }


        // BONUS
        private async void ChooseMileage_OnKeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Return)
            {
                int.TryParse(ChooseMileage.Text, out var mileage);

                if (b.MILEAGE - b.lastMaintMileage + mileage > 20000)
                {
                    Close();
                    MessageBox.Show("this bus is not qualified for a ride\ntake it to maintenance");
                }

                else if (mileage > 1200)
                {
                    Close();
                    MessageBox.Show("ride cannot be over 1200KM");
                }

                else if (mileage > b.Fuel)
                {
                    Close();
                    MessageBox.Show("not enough fuel\nplease refuel");
                }

                else
                {


                    Close();

                    int mil = mileage / 10;

                    b.MaxRide = mileage;

                    await RideAsync(mil);

                    wnd.LbBuses.Items.Refresh();
                }
            }
        }

        private async Task RideAsync(int mil)
        {

            for (int i = 0; i < 10; i++)
            {
                b.BUSSTATE = Status.During;
                await Task.Run(() => b.Ride(mil));
                wnd.LbBuses.Items.Refresh();
            }
            b.RIDE = 0;
            b.setStatus();
            wnd.LbBuses.Items.Refresh();
        }


        // BONUS
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
            if (e.Handled)
            {
                MessageBox.Show($"digits only\n'{e.Text}' is not a digit");
            }
        }
    }
}
