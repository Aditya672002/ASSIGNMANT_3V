using System;
using System.Collections.Generic;

public class Vehicle
{
    
    public string Model { get; set; }
    public string Manufacturer { get; set; }
    public int Year { get; set; }
    public decimal RentalPrice { get; set; }

    
    public Vehicle(string model, string manufacturer, int year, decimal rentalPrice)
    {
        Model = model;
        Manufacturer = manufacturer;
        Year = year;
        RentalPrice = rentalPrice;
    }

    
    public virtual void DisplayDetails()
    {
        Console.WriteLine($"MANUFACTURE: {Manufacturer}, MODEL: {Model}, YEAR: {Year}, RENTAL PRICE: {RentalPrice:C}");
    }
}

public class Car : Vehicle
{
    
    public int Seats { get; set; }
    public string EngineType { get; set; }
    public string Transmission { get; set; }
    public bool Convertible { get; set; }

    
    public Car(string model, string manufacturer, int year, decimal rentalPrice,
               int seats, string engineType, string transmission, bool convertible)
               : base(model, manufacturer, year, rentalPrice)
    {
        Seats = seats;
        EngineType = engineType;
        Transmission = transmission;
        Convertible = convertible;
    }

    
    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"SEATS: {Seats}, ENGINE TYPE: {EngineType}, TRANSMISSION: {Transmission}, CONVERTIBLE: {Convertible}");
    }
}

public class Truck : Vehicle
{
    
    public int Capacity { get; set; }
    public string TruckType { get; set; }
    public bool FourWheelDrive { get; set; }

    
    public Truck(string model, string manufacturer, int year, decimal rentalPrice,
                 int capacity, string truckType, bool fourWheelDrive)
                 : base(model, manufacturer, year, rentalPrice)
    {
        Capacity = capacity;
        TruckType = truckType;
        FourWheelDrive = fourWheelDrive;
    }

    
    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"CAPACITY: {Capacity}, TRUCK TYPE: {TruckType}, FOUR WHEEL DRIVE: {FourWheelDrive}");
    }
}

public class Motorcycle : Vehicle
{
    
    public int EngineCapacity { get; set; }
    public string FuelType { get; set; }
    public bool HasFairing { get; set; }

    
    public Motorcycle(string model, string manufacturer, int year, decimal rentalPrice,
                      int engineCapacity, string fuelType, bool hasFairing)
                      : base(model, manufacturer, year, rentalPrice)
    {
        EngineCapacity = engineCapacity;
        FuelType = fuelType;
        HasFairing = hasFairing;
    }

    
    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"ENGINE CAPACITY: {EngineCapacity}, FULE TYPE: {FuelType}, HAS FAIRING: {HasFairing}");
    }
}

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
        Fleet.Remove(vehicle);
        TotalRevenue += vehicle.RentalPrice; 
    }

   
    public void DisplayFleet()
    {
        Console.WriteLine("\nCURRENT FLEET:");
        foreach (var vehicle in Fleet)
        {
            vehicle.DisplayDetails();
            Console.WriteLine(); 
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        Car car1 = new Car("X2", "BMW", 2024, 80, 5, "Petrol", "Automatic", false);
        Truck truck1 = new Truck("F-250", "FORD", 2022, 120, 5, "Pickup", true);
        Motorcycle bike1 = new Motorcycle("ACTIVA", "HONDA", 2021, 60, 100, "Petrol", true);

        
        RentalAgency agency = new RentalAgency();
        agency.AddVehicle(car1);
        agency.AddVehicle(truck1);
        agency.AddVehicle(bike1);

        
        agency.DisplayFleet();

        
        agency.RentVehicle(truck1);
        Console.WriteLine("\nVEHICLE RENTED. TOTAL REVENUE: " + agency.TotalRevenue);

       
        agency.DisplayFleet();
    }
}
