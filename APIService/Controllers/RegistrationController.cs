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
        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        [HttpPost]        
        public string Add(Registration _reg)
        {

            int RndCustId = RandomNumber(1, 1000);
            _reg.Id = "R" + RndCustId;
           
            _obj.Add(_reg);
            _obj.Save();
            var id = _reg.Id;
            return id.ToString();
        }

        [HttpPost]
        [ActionName("Update")]
        public string Update(Registration _reg)
        {
            _obj.Update(_reg);
            _obj.Save();
            var id = _reg.Id;
            return id.ToString();
        }
            public Registration getbyId(string id)
        {
           var data=_obj.GetById(id);
            return data;
        }

       
        [ActionName("GetbyUser")]
        public IEnumerable<Registration> GetbyUser(string uname)
        {          
            var data= _obj.GetAll().Where(e => e.UserName == uname);
            return data;
        }

    }
}
