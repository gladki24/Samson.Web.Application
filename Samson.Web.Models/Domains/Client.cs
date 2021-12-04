using System;
using MongoDB.Bson;
using Samson.Web.Application.Models.DataStructures.User.Client;

namespace Samson.Web.Application.Models.Domains
{
    /// <summary>
    /// Client domain to represent gym client.
    /// </summary>
    public class Client : User
    {
        public Subscription Subscription { get; private set; }
        public bool HasActiveSubscription => Subscription is {IsActive: true};

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="id">Key</param>
        /// <param name="password">Hashed password</param>
        /// <param name="dataStructure">Data structure to create Client</param>
        public Client(ObjectId id, string password, RegisterClientDataStructure dataStructure)
            : base(id, password, dataStructure)
        {
            Roles.Add("Client");
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Client()
        {
        }

        /// <summary>
        /// Extension of the gym client's card
        /// </summary>
        /// <param name="gymPassType"></param>
        public void ExtendPass(GymPassType gymPassType)
        {
            if (Subscription == null)
            {
                Subscription = new Subscription(
                    ObjectId.GenerateNewId(),
                    DateTime.Now,
                    DateTime.Now.AddDays(gymPassType.Duration),
                    gymPassType.Id
                );
            }
            else
            {
                Subscription.Extend(gymPassType);
            }
        }
    }
}
