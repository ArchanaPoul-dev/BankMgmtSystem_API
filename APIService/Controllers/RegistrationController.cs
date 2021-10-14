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
    public class RegistrationController : ApiController
    {
        protected readonly BMSEntities2 _context = null;


      
        public IEnumerable<Registration> get()
        {            
            IRepository<Registration> _obj = new Repository<Registration>(_context);
            var data=_obj.GetAll();
            return data;
        }
        [HttpPost]
        public void Add(Registration reg)
        {
            IRepository<Registration> _obj = new Repository<Registration>(_context);
            _obj.Add(reg);
            _obj.Save();

        }

       
    }
}
