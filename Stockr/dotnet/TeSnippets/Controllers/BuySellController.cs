﻿using System;
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

        public BuySellController(IUserDAO userDao, ITransactionDAO transactionDAO, IPasswordHasher passwordHasher)
        {
            this.userDao = userDao;
            this.transactionDao = transactionDAO;
            this.passwordHasher = passwordHasher;
            
        }

        
    }
}