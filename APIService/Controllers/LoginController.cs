using DomainModels.Context;
using Repository.Abstraction;
using Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.UI.WebControls;

namespace APIService.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
        protected readonly BMSEntities2 _context = null;

        [HttpPost]
        public IEnumerable<Registration> GetAll( LoginUser loginuser)
        {
            IRepository<Registration> _obj = new Repository<Registration>(_context);
            return _obj.GetAll().Where(e => e.UserName == loginuser.username);
        }
    }
}
