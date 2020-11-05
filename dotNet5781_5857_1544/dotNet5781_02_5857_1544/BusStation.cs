﻿using System;
using System.Collections.Generic;

namespace dotNet5781_02_5857_1544
{
    class BusStation
    {
        static List<int> unique = new List<int>();
        protected int BusStationKey;
        public int BUSSTATIONKEY
        {
            get { return BusStationKey; }
        }

        protected double Latitude;
        protected double Longitude;
        //protected string address;

        /// <summary>
        /// this ctor randomly assigns coordinates and bus station key
        /// </summary>
        public BusStation()
        {
            Random r = new Random(DateTime.Now.Millisecond);
            Latitude = r.NextDouble() * (33.3 - 31) + 31;
            Longitude = r.NextDouble() * 35.5 - 34.3 + 34.3;
            do
            {
                BusStationKey = r.Next(999999);
            }
            while (unique.Contains(BUSSTATIONKEY));
            unique.Add(BusStationKey);
        }

        /// <summary>
        /// print out the station details in an orderly fashion
        /// </summary>
        /// <returns>
        /// a string that represents the current bus station
        /// </returns>
        public override string ToString()
        {
            return "Bus Station Code: " + BusStationKey + ", " + Latitude + "°N " + Longitude + "°E";
        }
    }
}
