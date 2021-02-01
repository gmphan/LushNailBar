using System.Collections.Generic;
using System.Linq;
using LushNailBar.Models;

namespace LushNailBar.ViewModels
{
    public class HomeViewModel
    {
        private readonly List<Service> _serviceList;
        private ILookup<string, Service> _serviceLookup;
        public ILookup<string, Service> ServiceLookup
        {
            get { return _serviceLookup; }
        }
        
        public HomeViewModel()
        {
            
        }
        public HomeViewModel(List<Service> serviceList)
        {
            _serviceList = serviceList;
            _serviceLookup = _serviceList.ToLookup(type => type.ServiceType);
        }

        public Service Service { get; set; }
    }
}