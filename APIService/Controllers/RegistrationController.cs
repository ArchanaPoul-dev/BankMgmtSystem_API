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
        private IRepository<Registration> _obj;
        public RegistrationController()
        {
            this._obj = new Repository<Registration>();
        }

        public IEnumerable<Registration> get()
        {   
            var data=_obj.GetAll();
            return data;
        }

        [HttpPost]
        public string Add(Registration _reg)
        {           
            _obj.Add(_reg);
            _obj.Save();
            var id = _reg.Id;
            return id.ToString();
        }
        public Registration getbyId(int id)
        {
           var data=_obj.GetById(id);
            return data;
        }

    }
}
