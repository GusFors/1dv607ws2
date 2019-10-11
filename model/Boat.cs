using System;

namespace Model
{
    class Boat
    {
        private int _length;

        public int Length
        {
            get => _length;
            private set => _length = value > 0 ? value : throw new ArgumentException("Boat length must be atleast 1 meter");

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