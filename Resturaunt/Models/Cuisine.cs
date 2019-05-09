using System;

namespace Resturaunt.Models
{
    public class Cuisine
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
