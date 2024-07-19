using System;
using System.Collections.Generic;

public class RentalAgency
{
    private List<Vehicle> Fleet { get; set; }
    public decimal TotalRevenue { get; private set; }

    public RentalAgency()
    {
        Fleet = new List<Vehicle>();
        TotalRevenue = 0;
    }

    public void AddVehicle(Vehicle vehicle)
    {
        Fleet.Add(vehicle);
    }

    public void RemoveVehicle(Vehicle vehicle)
    {
        Fleet.Remove(vehicle);
    }

    public void RentVehicle(Vehicle vehicle)
    {
        Fleet.Remove(vehicle); // Remove from available fleet
        TotalRevenue += vehicle.RentalPrice; // Update total revenue
    }

    // Method to display all vehicles in fleet
    public void DisplayFleet()
    {
        Console.WriteLine("\nCurrent Fleet:");
        foreach (var vehicle in Fleet)
        {
            vehicle.DisplayDetails();
            Console.WriteLine(); // Blank line for separation
        }
    }
}
