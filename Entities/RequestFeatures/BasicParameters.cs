using System;

namespace Entities.RequestFeatures
{
    public abstract class BasicParameters
    {
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
    }
}
