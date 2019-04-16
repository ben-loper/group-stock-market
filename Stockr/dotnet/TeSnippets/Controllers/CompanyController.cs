using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stockr.Providers.Security;
using StockrWebApi.DAL;
using StockrWebApi.Models;

namespace StockrWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private IPortfolioDAO portfolioDao;
        private IPasswordHasher passwordHasher;

        public CompanyController(IPortfolioDAO portfolioDAO, IPasswordHasher passwordHasher)
        {
            this.portfolioDao = portfolioDAO;
            this.passwordHasher = passwordHasher;
        }


        // GET: api/Company
        [HttpGet]
        public IEnumerable<Company> Get()
        {
            return portfolioDao.GetCompanyNames();
        }

    }
}
