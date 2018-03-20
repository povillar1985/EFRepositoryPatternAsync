using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using XYZCorp.Core.Domain;

namespace XYZCorp.WebApi.Controllers
{
    public interface IValuesController
    {
        Task<IHttpActionResult> Get();
        Task<IHttpActionResult> Get(bool isAdmin);
        Task<IHttpActionResult> Get(int id);
        Task<IHttpActionResult> Post(User user);
        Task<IHttpActionResult> Put(User user);
    }
}