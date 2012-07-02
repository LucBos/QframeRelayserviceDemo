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
    using System.ServiceModel;
    
    [ServiceContract(Name = "ICustomerContract", Namespace = "http://samples.microsoft.com/ServiceModel/Relay/")]

    public interface ICustomerContract
    {
        [OperationContract(IsOneWay = false)]
        IEnumerable<Customer> GetCustomers();

        [OperationContract(IsOneWay = false)]
        Customer GetCustomerById(string id);
    }

    public interface ICustomerChannel : ICustomerContract, IClientChannel { }
}
