﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BLApi;
using BO;
using PL;
using PR_PL.Manager_Buses;
using PR_PL.Manager_Simulation;

namespace PR_PL.Manager_Stations
{
    /// <summary>
    /// Interaction logic for StationsViewPage.xaml
    /// </summary>
    public partial class StationsViewPage : Page
    {
        private readonly IBL _bl;
        MainWindow wnd = (MainWindow)Application.Current.MainWindow;
        private SimulationPage _simulationPage;
        private bool simulation;
        public StationsViewPage(IBL b, SimulationPage sp)
        {
            InitializeComponent();

            _bl = b;
            _simulationPage = sp;

            refresh();
        }

        private void StationsDataGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (_bl.IsSimulatorRunning())
            {
                var sds = new StationDetailsSimulator(_bl, StationsDataGrid.SelectedItem as BusStation, _simulationPage);
                sds.ShowDialog();
            }
            else
            {
                var sd = new StationDetails(_bl, StationsDataGrid.SelectedItem as BusStation, _simulationPage);
                sd.ShowDialog();
            }
        }

        private void Remove_OnClick(object sender, RoutedEventArgs e)
        {
            if (StationsDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Please choose at least one station and then click remove!", "Selection Error");
            }
            else
            {
                foreach (var s in StationsDataGrid.SelectedItems)
                {
                    try
                    {
                        _bl.DeleteBusStation(((BusStation)s).Code);
                    }
                    catch (BO.StationBelongsToActiveBusLine ex)
                    {
                        MessageBox.Show(ex.Message, "Station deleting Error!");
                    }
                    catch (BO.DoesNotExistException ex)
                    {
                        MessageBox.Show(ex.Message, "Station deleting Error!");
                    }
                }

                refresh();
            }
        }

        private void InActive_OnClick(object sender, RoutedEventArgs e)
        {
            wnd.DataDisplay.Content = new InActiveStationsViewPage(_bl, _simulationPage);
        }

        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
            var ast = new AddStation(_bl);
            ast.ShowDialog();
        }
        private void refresh()
        {
            try
            {
                StationsDataGrid.DataContext = _bl.GetAllBusStations().ToList();
            }
            catch (BO.EmptyListException e)
            {
                MessageBox.Show(e.Message, "Station Loading Error!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unknown ERROR!" + ex.Message, "Station Loading Error!");
            }
        }
    }
}
