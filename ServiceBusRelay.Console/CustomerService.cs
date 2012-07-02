// ----------------------------------------------------------------------------------
// Microsoft Developer & Platform Evangelism
// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// ----------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
// ----------------------------------------------------------------------------------

namespace ServiceBusRelay.Console
{
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;

    [ServiceBehavior(Name = "CustomerService", Namespace = "http://samples.microsoft.com/ServiceModel/Relay/")]
    public class CustomerService : ICustomerContract
    {
        public IEnumerable<Customer> GetCustomers()
        {
            System.Console.WriteLine("Received GetCustomers() request.");

            var db = new NorthwindEntities();
            return db.Customers.Take(5).ToList();
        }

        public Customer GetCustomerById(string id)
        {
            System.Console.WriteLine("Received GetCustomerById() request.");

            var db = new NorthwindEntities();
            return db.Customers.FirstOrDefault(c => c.CustomerID == id);
        }
    }
}
