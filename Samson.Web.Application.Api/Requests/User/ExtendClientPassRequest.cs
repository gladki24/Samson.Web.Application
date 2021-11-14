using System;
using System.Collections.Generic;
namespace Samson.Web.Application.Api.Requests.User
{
    /// <summary>
    /// Request to extend Client pass.
    /// </summary>
    public class ExtendClientPassRequest
    {
        public string ClientId { get; set; }
        public string GymPassTypeId { get; set; }
    }
}
