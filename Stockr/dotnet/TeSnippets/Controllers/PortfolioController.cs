using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stockr.DAL;
using Stockr.Providers.Security;
using StockrWebApi.DAL;
using StockrWebApi.Models;

namespace StockrWebApi.Controllers
{
    [Route("api/portfolio")]
    [ApiController]
    public class PortfolioController : Controller
    {
        private IUserDAO userDao;
        private IPortfolioDAO portfolioDao;
        private IPasswordHasher passwordHasher;

        private int GetCurrentUserId()
        {
            return userDao.GetUser(base.User.Identity.Name).Id;
        }


        public PortfolioController(IUserDAO userDao, IPortfolioDAO portfolioDAO, IPasswordHasher passwordHasher)
        {
            this.userDao = userDao;
            this.portfolioDao = portfolioDAO;
            this.passwordHasher = passwordHasher;
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<Portfolio> List()
        {
            return portfolioDao.GetPortfolio(GetCurrentUserId());
        }

        [HttpGet("{id}", Name = "GetPortfolio")]
        [Authorize]
        public ActionResult<Portfolio> GetPortfolio(int id)
        {
            var portfolio = portfolioDao.FindById(id, GetCurrentUserId());
            if (portfolio == null)
            {
                return NotFound("The portfolio you are looking for was not found.");
            }

            return portfolio;
        }

        [HttpPost]
        [Authorize]
        public ActionResult<Portfolio> CreatePortfolio(Portfolio portfolio)
        {
            portfolio.UserId = GetCurrentUserId();
            portfolio = portfolioDao.CreatePortfolio(portfolio);
            return portfolio;
        }

        [HttpPut("{id}", Name = "UpdatePortfolio")]
        [Authorize]
        public Portfolio Update(Portfolio portfolio, [FromRoute]int id)
        {
            portfolio.Id = id;
            portfolio.UserId = GetCurrentUserId();
            return portfolioDao.UpdatePortfolio(portfolio);
        }

        [HttpDelete("{id}", Name = "DeletePortfolio")]
        [Authorize]
        public ActionResult<int> Delete([FromRoute]int id)
        {
            portfolioDao.Delete(id, GetCurrentUserId());
            return new OkResult();
        }
    }
}
