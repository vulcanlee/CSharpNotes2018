using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Unity;

namespace ASPNETCoreIoCDI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMyDependency myDependency1;
        private readonly IMyDependency myDependency2;
        private readonly IServiceProvider serviceProvider;
        private readonly IUnityContainer container;
        private readonly IDefaultDependency defaultDependency1;
        private readonly IDefaultDependency defaultDependency2;

        public ValuesController(IMyDependency myDependency1, IMyDependency myDependency2,
            IServiceProvider serviceProvider, IUnityContainer container,
            IDefaultDependency defaultDependency1, IDefaultDependency defaultDependency2)
        {
            this.myDependency1 = myDependency1;
            this.myDependency1.InstanceFrom = "控制器的建構式注入";
            this.myDependency1.InstanceName = "myDependency1";
            this.myDependency2 = myDependency2;
            this.myDependency2.InstanceFrom = "控制器的建構式注入";
            this.myDependency2.InstanceName = "myDependency2";
            this.serviceProvider = serviceProvider;
            this.container = container;
            this.defaultDependency1 = defaultDependency1;
            this.defaultDependency1.InstanceFrom = "控制器的建構式注入";
            this.defaultDependency1.InstanceName = "defaultDependency1";
            this.defaultDependency2 = defaultDependency2;
            this.defaultDependency2.InstanceFrom = "控制器的建構式注入";
            this.defaultDependency2.InstanceName = "defaultDependency2";
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<object>> Get()
        {
            IServiceProvider contextServiceProvider = HttpContext.RequestServices;
            IMyDependency myDependency3 = contextServiceProvider.GetService<IMyDependency>();
            myDependency3.InstanceFrom = "由 HttpContext 取得 IServiceProvider 進而手動解析";
            myDependency3.InstanceName = "myDependency3";

            IMyDependency myDependency4 = serviceProvider.GetService<IMyDependency>();
            myDependency4.InstanceFrom = "由 建構式注入 取得 IServiceProvider 進而手動解析";
            myDependency4.InstanceName = "myDependency4";

            IMyDependency myDependency5 = container.Resolve<IMyDependency>();
            myDependency5.InstanceFrom = "由 建構式注入 取得 IUnityContainer 進而手動解析(預設匿名解析)";
            myDependency5.InstanceName = "myDependency5";
            IMyDependency myDependency6 = container.Resolve<IMyDependency>("MyClass1");
            myDependency6.InstanceFrom = "由 建構式注入 取得 IUnityContainer 進而手動解析(具名解析，指定 MyClass1)";
            myDependency6.InstanceName = "myDependency6";

            IMyDependency myDependency7 = container.Resolve<IMyDependency>();
            myDependency7.InstanceFrom = "由 Startup 靜態屬性 Container 取得 IUnityContainer 進而手動解析(預設匿名解析)";
            myDependency7.InstanceName = "myDependency7";
            IMyDependency myDependency8 = Startup.Container.Resolve<IMyDependency>("MyClass1");
            myDependency8.InstanceFrom = "由 Startup 靜態屬性 Container 取得 IUnityContainer 進而手動解析(具名解析，指定 MyClass1)";
            myDependency8.InstanceName = "myDependency8";
            IMyDependency myDependency9 = Startup.Container.Resolve<IMyDependency>("MyClass1");
            myDependency9.InstanceFrom = "再一次，由 Startup 靜態屬性 Container 取得 IUnityContainer 進而手動解析(具名解析，指定 MyClass1)";
            myDependency9.InstanceName = "myDependency9";

            return new object[] { myDependency1, myDependency2, myDependency3, myDependency4,
            myDependency5, myDependency6, myDependency7, myDependency8, myDependency9,defaultDependency1,defaultDependency2};
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
