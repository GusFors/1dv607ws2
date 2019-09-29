using System;

namespace _1dv607_ws2
{
    class Boat
    {
        private int _length;
        public int Length
        {
            get => _length;
            private set
            {
                if (value > 0)
                {
                    _length = value;
                }
                else
                {
                    throw new ArgumentException("Boat length must be atleast 1 meter");
                }

            }
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