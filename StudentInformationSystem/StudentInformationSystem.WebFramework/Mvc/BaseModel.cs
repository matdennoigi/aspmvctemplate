using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace StudentInformationSystem.WebFramework.Mvc
{
    [ModelBinder(typeof(AppModelBinder))]
    public class BaseModel
    {
        public BaseModel()
        {
            this.CustomProperties = new Dictionary<string, object>();
            PostInitialize();
        }

        public virtual void BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
        }

        protected virtual void PostInitialize()
        {
        }

        public IDictionary<string, object> CustomProperties { set; get; }
    }
}
