using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigEncoder.Data
{
    public class CustomerConfiguration<TConfiguration> : ICustomerConfiguration<TConfiguration> where TConfiguration : class
    {
        public TConfiguration Configuration { get; set; }

        public IEnumerable<ISection> Sections { get; set; }
    }
}
