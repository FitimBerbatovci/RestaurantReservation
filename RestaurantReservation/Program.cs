using RestaurantReservation;
using System;
using System.Collections.Generic;

namespace RestaurantReservation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize a list of tables
            List<Table> tables = new List<Table>();
            tables.Add(item: new Table(1, 2));
            tables.Add(new Table(2, 4));
            tables.Add(new Table(3, 6));
            tables.Add(new Table(4, 8));

            // Initialize a list of reservations
            List<Reservation> reservations = new List<Reservation>();

            // Start the reservation system loop
            while (true)
            {
                Console.WriteLine("Welcome to the restaurant reservation system!");
                Console.WriteLine("1. Make a reservation");
                Console.WriteLine("2. Cancel a reservation");
                Console.WriteLine("3. View all reservations");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (choice == 1)
                {
                    // Make a reservation
                    Console.Write("Enter your name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter the number of people in your party: ");
                    int numPeople = int.Parse(Console.ReadLine());

                    // Find a table that fits the party size
                    Table table = GetAvailableTable(tables, numPeople);
                    if (table != null)
                    {
                        // Create a new reservation
                        Reservation reservation = new Reservation(name, table);
                        reservations.Add(reservation);
                        Console.WriteLine($"Reservation created for {name} at table {table.Number}");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, we don't have a table available for that party size.");
                    }
                }
                else if (choice == 2)
                {
                    // Cancel a reservation
                    Console.Write("Enter the name on the reservation: ");
                    string name = Console.ReadLine();

                    // Find the reservation and remove it
                    Reservation reservation = FindReservation(reservations, name);
                    if (reservation != null)
                    {
                        reservations.Remove(reservation);
                        Console.WriteLine(value: $"Reservation for {name} at table {reservation.Table.Number} has been cancelled.");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, we couldn't find a reservation with that name.");
                    }
                }
                else if (choice == 3)
                {
                    // View all reservations
                    Console.WriteLine("All reservations:");
                    foreach (Reservation reservation in reservations)
                    {
                        Console.WriteLine(value: $"{reservation.Name} at table {reservation.Table.Number}");
                    }
                }
                else if (choice == 4)
                {
                    // Exit the program
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }

                Console.WriteLine();
            }
        }

        private static Reservation FindReservation(List<Reservation> reservations, string name)
        {
            foreach (Reservation reservation in reservations)
            {
                if (reservation.Name == name)
                {
                    return reservation;
                }
            }
            return null;
        }


        private static Table GetAvailableTable(List<Table> tables, int numPeople)
        {
            foreach (Table table in tables)
            {
                if (table.Capacity >= numPeople)
                {
                    return table;
                }
            }
            return null;
        }

        class Reservation
        {
            public string Name { get; set; }
            public Table Table { get; set; }

            public Reservation(string name, Table table)
            {
                Name = name;
                Table = table;
            }
        }

        class Table
        {
            public int Number { get; set; }
            public int Capacity { get; set; }
            public bool IsAvailable { get; set; }

            public Table(int number, int capacity)
            {
                Number = number;
                Capacity = capacity;
                IsAvailable = true;
            }
        }

    }

}

