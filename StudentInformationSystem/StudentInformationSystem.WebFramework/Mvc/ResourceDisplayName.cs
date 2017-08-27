using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.WebFramework.Mvc
{
    public class ResourceDisplayName : DisplayNameAttribute
    {
        public ResourceDisplayName(string resourceKey)
            : base(resourceKey)
        {
            this.ResourceKey = resourceKey;
        }

        public string ResourceKey { set; get; }

        public override string DisplayName
        {
            get
            {
                return "hello";
            }
        }
    }
}
