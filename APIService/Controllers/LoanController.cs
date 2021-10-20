using DomainModels.Context;
using Repository.Abstraction;
using Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIService.Controllers
{
    public class LoanController : ApiController
    {
        private IRepository<Loan> _obj;

        public LoanController()
        {
            this._obj = new Repository<Loan>();
        }
        [HttpPost]
        public int LoanApplication(Loan _loan)  
        {            
            _obj.Add(_loan);
            _obj.Save();
            var id = _loan.Id;
            return id;
        }
    }
}
