using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabDriver
{
     public  class RideType
    {
        //Dictionary to store UserId and Rides int List.
        Dictionary<string, List<Ride>> userRides = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="RideRepository"/> class.
        /// </summary>
        public RideType()
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }

        /// <summary>
        /// Adds ride of a customer in list and then to a dictionary with user id as a key.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="rides">The rides array with datatype ride</param>
        /// <exception cref="CabInvoiceDay23.CabInvoiceException">Rides are null</exception>
        public void AddRide(string userId, Ride[] rides)
        {
            bool rideList = this.userRides.ContainsKey(userId);
            try
            {
                if (!rideList)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    this.userRides.Add(userId, list);
                }
            }
            catch
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Rides are null");
            }
        }

        /// <summary>
        /// Gets the rides for specific user id.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns> retruns the array of all the rides of user in form of array</returns>
        /// <exception cref="CabInvoiceDay23.CabInvoiceException">Invalid User id</exception>
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