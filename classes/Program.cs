using System;

namespace ConsoleApplication
{
    //Make sure to include the Vehicle class separate from the Program class
    public class Vehicle
    {
        public double distance = 0.0;
        //Accessibility of variables is defaulted to private
        //so we must add the public keyword to anything we
        //want to allow outside access to.
        
        //Notice the Constructor function doesn't need
        //a return type or the static keyword
        public Vehicle(int val)
        {
             numPassengers = val;
        }
        
        //The second for preowned with milage already
        public Vehicle(int val, double odo)
        {
            numPassengers = val;
            distance = odo;
        }
 
        //Method can also be overloaded for handling different parameters
        public int Move(double miles)
        {
            distance += miles;
            return (int)distance;
        }


        //If a boolean is included in this version of the method call
        //it may be measuring in km rather than miles.
        public int Move(double miles, bool km)
        {
            //Convert the KM measurement to miles
            if (km == true)
            {
                miles = miles * 0.62;
            }
            distance += miles;
            // Here is the DRY principle call to the other Move function
            return Move(miles);
        }
        
        // Using the .NET built-in property Getter and Setter Methods. Easily add code for access and updating of variable fields while also obscuring the methods of doing so from the rest of our code. 
        private _numPassengers = 5;
        public int numPassengers {
            get { return _numPassengers }
            set { _numPassengers = value;}
        }
        
        // To implement as pure accessors (perhaps as future placeholders) with no current additional lines, they can be shortened even further
        public int numPassenger { get; set; }
        // This is the most typical usage, as it standardizes implementation and allows for the easy extension as needed
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            // Notice the type for the new object reference
            // is the same as the class. name
            // Declared myVehicle to be an instance or object of the class Vehicle. We also added an attribute of numPassengers to the class, that becomes part of the object variable when it is created.
            // If we wanted to pass a variable to this object when creating it to change some of its attributes, such as the numPassengers variable, we need to include a funciton inside the class called constructor.
            // A constructor is called the moment an object is created using the "new" keyword and just requires adding a function with the same name as the Class.
            Vehicle myVehicle = new Vehicle(7);
            Console.WriteLine($"My vehicle can hold {myVehicle.numPassengers} people");

            //We create two separate objects of class-Vehicle
            Vehicle car = new Vehicle(5);
            Vehicle bike = new Vehicle(1);

            //Notice they both have the same starting distance travelled
            Console.WriteLine(car.distance); //Prints 0
            Console.WriteLine(bike.distance); //Also Prints 0

            //The Move method however only effects the distance of the object it is referencing!!
            car.Move(70.8);
            Console.WriteLine(car.distance); //Now is printing 70.8
            Console.WriteLine(bike.distance); //Still prints 0
        }
    }
}
