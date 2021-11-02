using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samson.Web.Application.Api.ViewModels.GymObject
{
    /// <summary>
    /// Covid configuration view model
    /// </summary>
    public class CovidConfigurationViewModel
    {
        public string Id { get; set; }
        public decimal PersonFactorPerMeter { get; set; }
        public bool IsActive { get; set; }
    }
}
