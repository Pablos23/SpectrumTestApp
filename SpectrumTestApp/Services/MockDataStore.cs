using SpectrumTestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpectrumTestApp.Services
{
    public class MockDataStore : IDataStore<Service>
    {
        readonly List<Service> items;

        public MockDataStore()
        {
            items = new List<Service>()
            {
                new Service { Id = Guid.NewGuid().ToString(), Text = "High speed Internet up to 100 Mbps", Description="Shop now only $60/mo", ServiceType = ServiceTypeEnum.Internet, Price = 60 },
                new Service { Id = Guid.NewGuid().ToString(), Text = "High speed Internet up to 150 Mbps", Description="Shop now only $80/mo", ServiceType = ServiceTypeEnum.Internet, Price = 80 },
                new Service { Id = Guid.NewGuid().ToString(), Text = "High speed Internet up to 200 Mbps", Description="Shop now only $100/mo", ServiceType = ServiceTypeEnum.Internet, Price = 100 },
                new Service { Id = Guid.NewGuid().ToString(), Text = "High speed Internet up to 300 Mbps", Description="Shop now only $110/mo", ServiceType = ServiceTypeEnum.Internet, Price = 110 },
                new Service { Id = Guid.NewGuid().ToString(), Text = "High speed Internet up to 500 Mbps", Description="Shop now only $130/mo", ServiceType = ServiceTypeEnum.Internet, Price = 1300 },
                new Service { Id = Guid.NewGuid().ToString(), Text = "High speed Internet up to 1000 Mbps", Description="Shop now only $230/mo", ServiceType = ServiceTypeEnum.Internet, Price = 230 },
                new Service { Id = Guid.NewGuid().ToString(), Text = "High speed Internet up to 100 Mbps + 125 channels", Description="Shop now only $80/mo", ServiceType = ServiceTypeEnum.DoublePack, Price = 80 },
                new Service { Id = Guid.NewGuid().ToString(), Text = "High speed Internet up to 150 Mbps + 125 channels", Description="Shop now only $100/mo", ServiceType = ServiceTypeEnum.DoublePack, Price = 100 },
                new Service { Id = Guid.NewGuid().ToString(), Text = "High speed Internet up to 200 Mbps + 125 channels", Description="Shop now only $120/mo", ServiceType = ServiceTypeEnum.DoublePack, Price = 120 },
                new Service { Id = Guid.NewGuid().ToString(), Text = "High speed Internet up 300 Mbps + 125 channels", Description="Shop now only $140/mo", ServiceType = ServiceTypeEnum.DoublePack, Price = 140 },
                new Service { Id = Guid.NewGuid().ToString(), Text = "High speed Internet up 500 Mbps + 125 channels", Description="Shop now only $150/mo", ServiceType = ServiceTypeEnum.DoublePack, Price = 150 },
                new Service { Id = Guid.NewGuid().ToString(), Text = "High speed Internet up 1000 Mbps + 125 channels", Description="Shop now only $250/mo", ServiceType = ServiceTypeEnum.DoublePack, Price = 250 },
                new Service { Id = Guid.NewGuid().ToString(), Text = "High speed Internet up 100 Mbps + 125 channels + Voice", Description="Shop now only $100/mo", ServiceType = ServiceTypeEnum.TriplePack, Price = 100 },
                new Service { Id = Guid.NewGuid().ToString(), Text = "High speed Internet up 150 Mbps + 125 channels + Voice", Description="Shop now only $120/mo", ServiceType = ServiceTypeEnum.TriplePack, Price = 120 },
                new Service { Id = Guid.NewGuid().ToString(), Text = "High speed Internet up 200 Mbps + 125 channels + Voice", Description="Shop now only $140/mo", ServiceType = ServiceTypeEnum.TriplePack, Price = 140 },
                new Service { Id = Guid.NewGuid().ToString(), Text = "High speed Internet up 300 Mbps + 125 channels + Voice", Description="Shop now only $160/mo", ServiceType = ServiceTypeEnum.TriplePack, Price = 160 },
                new Service { Id = Guid.NewGuid().ToString(), Text = "High speed Internet up 500 Mbps + 125 channels + Voice", Description="Shop now only $180/mo", ServiceType = ServiceTypeEnum.TriplePack, Price = 180 },
                new Service { Id = Guid.NewGuid().ToString(), Text = "High speed Internet up 1000 Mbps + 125 channels + Voice", Description="Shop now only $300/mo", ServiceType = ServiceTypeEnum.TriplePack, Price = 300 },
            };
        }

        public async Task<bool> AddItemAsync(Service item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Service item)
        {
            var oldItem = items.Where((Service arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Service arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Service> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Service>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}