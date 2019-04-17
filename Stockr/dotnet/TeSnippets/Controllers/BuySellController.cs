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
    [Route("api/[controller]")]
    [ApiController]
    public class BuySellController : Controller
    {
        private IUserDAO userDao;
        private ITransactionDAO transactionDao;
        private IPasswordHasher passwordHasher;

        private int GetCurrentUserId()
        {
            return userDao.GetUser(base.User.Identity.Name).Id;
        }


        public BuySellController(IUserDAO userDao, ITransactionDAO transactionDAO, IPasswordHasher passwordHasher)
        {
            this.userDao = userDao;
            this.transactionDao = transactionDAO;
            this.passwordHasher = passwordHasher;
            
        }

        /// <summary>
        /// Pulls the portfolio for the user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public IEnumerable<Portfolio> List()
        {
            return transactionDao.GetPortfolio(GetCurrentUserId());
        }

        /// <summary>
        /// Pulls the portfolio for the user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [Route("AllTransactions")]
        public IEnumerable<PastTransaction> Transactions()
        {
            List<PastTransaction> pastTransactions = new List<PastTransaction>();

            pastTransactions = transactionDao.GetPastTransactions(GetCurrentUserId());


            return pastTransactions;
            //return transactionDao.GetPortfolio(GetCurrentUserId());
        }

        [HttpPost]
        [Authorize]
        public ActionResult<HttpResponse> ExecuteTransaction(Transaction transaction)
        {
            transaction.UserId = GetCurrentUserId();

            bool isSuccessful = transactionDao.ExecuteTransaction(transaction);

            if (isSuccessful)
            {
                return new OkResult();
            }

            return new BadRequestResult();
        }


    }
}
