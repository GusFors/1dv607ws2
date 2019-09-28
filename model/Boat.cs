using System;

namespace _1dv607_ws2
{
    class Boat
    {
        public int Length
        {
            get;
            set;
        }

        public BoatType Type
        {
            get;
            set;
        }

        public Boat(BoatType type, int length)
        {
            Type = type;
            Length = length;
        }

        /* 
        public override string ToString() // mostly for ease of access right now, moving to view in some way later
        {
            return $"Type: {Type} Length: {Length}";
        } */
    }
}