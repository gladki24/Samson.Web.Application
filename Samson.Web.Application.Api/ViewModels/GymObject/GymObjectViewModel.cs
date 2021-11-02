using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samson.Web.Application.Api.ViewModels.GymObject
{
    /// <summary>
    /// GymObject view model
    /// </summary>
    public class GymObjectViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public CovidConfigurationViewModel CovidConfiguration { get; set; }
        public IEnumerable<GymRoomViewModel> Rooms { get; set; }
    }
}
