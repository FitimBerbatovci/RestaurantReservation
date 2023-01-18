namespace RestaurantReservation
{
    internal class Reservation
    {
        private string? name;
        private Table table;

        public Reservation(string? name, Table table)
        {
            this.name = name;
            this.table = table;
        }

        public object Table { get; internal set; }
        public object Name { get; internal set; }
    }
}