using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabDriver
{
     public  class RideRepository
    {
        //Dictionary to store UserId and Rides int List.
        Dictionary<string, List<Ride>> userRides = null;
        /// Initializes a new instance of the  class.
       // for getting element
        public RideRepository()
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }

        //Adding Method AddRide
        // Adding ride of a customer in list and then to a dictionary with user id as a key.
        public void AddRide(string userId, Ride[] rides)
        {
            //Boolean variable for ridelist
            bool rideList = this.userRides.ContainsKey(userId);
            try
            {
                //If there is not ridelist 
                if (!rideList)
                {
                    //Creating list of having name list 
                    //creating list of class ride
                    List<Ride> list = new List<Ride>();
                    //Adds collection of element in list
                    list.AddRange(rides);
                    //getting D
                    this.userRides.Add(userId, list);
                }
            }
            catch
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Rides are null");
            }
        }

        // Gets the rides for specific user id.     
        //The user identifier userID
        //retruns the array of all the rides of user in form of array
        public Ride[] GetRides(string userId)
        {
            try
            {
                return this.userRides[userId].ToArray();
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USER_ID, "Invalid User id");
            }
        }
    }
}