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
            private set;
        }

        public Boat(BoatType type, int length)
        {
            Type = type;
            Length = length;
        }

        public void Update(BoatType type, int length)
        {
            Type = type;
            Length = length;
        }

    }
}