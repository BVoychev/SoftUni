using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Zones
{
    class Zone
    {
        public string Colour { get; set; }
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
        public double Price { get; set; }

        public Zone(string colour,int x1,int y1,int width,int height,double price)
        {
            this.Colour = colour;
            this.X1 = x1;
            this.Y1 = y1;
            this.X2 = x1+width;
            this.Y2 = y1+height;
            this.Price = price;
        }

        public bool IsFoundInTheZone(int x,int y)
        {
            return x>=this.X1 && x<this.X2 && y>=this.Y1 && y<this.Y2;
        }
    }

    class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x,int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int zoneCount = int.Parse(Console.ReadLine());
            List<Zone> zones = new List<Zone>();
            for (int i = 0; i < zoneCount; i++)
            {
                string[] zoneInput = Console.ReadLine()
               .Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
               .ToArray();
                string[] zoneInfo = zoneInput[1]
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)                    
                    .ToArray();
                int x1 = int.Parse(zoneInfo[0]);
                int y1 = int.Parse(zoneInfo[1]);
                int x2 = int.Parse(zoneInfo[2]);
                int y2 = int.Parse(zoneInfo[3]);
                double price = double.Parse(zoneInfo[4]);
                Zone zone = new Zone(zoneInput[0], x1, y1, x2, y2, price);
                zones.Add(zone);
            }

            string[] inputInfo = Console.ReadLine()
                    .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)                    
                    .ToArray();

            List<Coordinate> parkingSpots = new List<Coordinate>();
            for (int i = 0; i < inputInfo.Length; i++)
            {
                int[] coordInfo = inputInfo[i]
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(n=>int.Parse(n))
                    .ToArray();
                int x = coordInfo[0];
                int y = coordInfo[1];
                Coordinate coordinate = new Coordinate(x, y);
                parkingSpots.Add(coordinate);
            }

            int[] targetInfo = Console.ReadLine()
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(n => int.Parse(n))
                    .ToArray();
            Coordinate targetSpot = new Coordinate(targetInfo[0], targetInfo[1]);
            int timeInSecForASingleBlock = int.Parse(Console.ReadLine());

            double minPrice = Double.MaxValue;
            string zoneName = "";
            int xFinal = 0;
            int yFinal = 0;
            foreach (var parkingSpot  in parkingSpots)
            {
                foreach (var zone in zones)
                {
                    if (zone.IsFoundInTheZone(parkingSpot.X, parkingSpot.Y))
                    {
                        int distance = Math.Abs(parkingSpot.X-targetSpot.X)+Math.Abs(parkingSpot.Y-targetSpot.Y)-1;
                        double distanceDoubled = distance * 2 * timeInSecForASingleBlock;
                        double timeInMinutes = distanceDoubled/ 60;
                        double timeInMinutesRounded = Math.Ceiling(timeInMinutes);
                        double price = timeInMinutesRounded * zone.Price;
                        if (price < minPrice)
                        {
                            minPrice = price;
                            zoneName = zone.Colour;
                            xFinal = parkingSpot.X;
                            yFinal = parkingSpot.Y;
                        }
                    }
                }               
            }
            Console.WriteLine($"Zone Type: {zoneName}; X: {xFinal}; Y: {yFinal}; Price: {minPrice:F2}");
        }
    }
}
