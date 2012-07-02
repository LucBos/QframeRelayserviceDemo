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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ServiceBus;
using System.ServiceModel;
using ServiceBusRelay.Console;
using System.Threading;

namespace ServiceBusRelay.Web.Services
{
    public class CustomerService
    {
        static ChannelFactory<ICustomerChannel> channelFactory;
        static ICustomerChannel channel;
        static string serviceNamespace = "sharedqframebus";
        
        public static IEnumerable<Customer> GetCustomers()
        {
            if (channelFactory == null)
            {
                Uri serviceUri = ServiceBusEnvironment.CreateServiceUri("https", serviceNamespace, "Customer");
                channelFactory = new ChannelFactory<ICustomerChannel>("RelayEndpoint", new EndpointAddress(serviceUri));
            }

            int tries = 0;
            while (tries++ < 3)
            {
                try
                {
                    if (channel == null)
                    {
                        channel = channelFactory.CreateChannel();
                        channel.Open();
                    }

                    return channel.GetCustomers();
                }
                catch (CommunicationException)
                {
                    channel.Abort();
                    channel = null;

                    Thread.Sleep(500);
                }
            }

            return new List<Customer>();
        }

        public static Customer GetCustomerById(string id)
        {
            if (channelFactory == null)
            {
                Uri serviceUri = ServiceBusEnvironment.CreateServiceUri("https", serviceNamespace, "Customer");
                channelFactory = new ChannelFactory<ICustomerChannel>("RelayEndpoint", new EndpointAddress(serviceUri));
            }

            int tries = 0;
            while (tries++ < 3)
            {
                try
                {
                    if (channel == null)
                    {
                        channel = channelFactory.CreateChannel();
                        channel.Open();
                    }

                    return channel.GetCustomerById(id);
                }
                catch (CommunicationException)
                {
                    channel.Abort();
                    channel = null;

                    Thread.Sleep(500);
                }
            }

            return new Customer();
        }
    }
}