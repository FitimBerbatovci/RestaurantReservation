namespace RestaurantReservation
{
    internal class Table
    {
        private int v1;
        private int v2;

        public Table(int v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public object Number { get; internal set; }
    }
}