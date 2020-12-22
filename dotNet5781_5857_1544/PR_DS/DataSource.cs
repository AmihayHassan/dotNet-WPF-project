﻿using System.Collections.Generic;
using System.ComponentModel;
using DO;

namespace DS
{
    public static class DataSource
    {
        public static List<Bus> BusesList;
        public static List<BusLine> BusLinesList;
        public static List<BusStation> BusStationsList;
        public static List<ConsecutiveStations> ConsecutiveStationsList;
        public static List<Driver> DriversList;
        public static List<LineExit> LineExitsList;
        public static List<LineStation> LineStationsList;
        public static List<TravelingBus> TravelingBusesList;
        public static List<User> UsersList;
        public static List<UserTravel> UserTravelsList;

        static DataSource()
        {
            InitializeLists();
        }

        private static void InitializeLists()
        {
            BusesList = new List<Bus>();

            BusLinesList = new List<BusLine>();

            BusStationsList = new List<BusStation>();

            ConsecutiveStationsList = new List<ConsecutiveStations>();

            DriversList = new List<Driver>();

            LineExitsList = new List<LineExit>();

            LineStationsList = new List<LineStation>();

            TravelingBusesList = new List<TravelingBus>();

            UsersList = new List<User>();

            UserTravelsList = new List<UserTravel>();
        }
    }
}
