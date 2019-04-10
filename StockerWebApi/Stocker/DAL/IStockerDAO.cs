using Stocker.Models;
using Stockr;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;


namespace Stocker.DAL
{
    public interface IStockerDAO
    {
        IList<Portfolio> GetPortfolio(int id);

        bool AddTransaction(int userId, string symbol, int numberOfShares, decimal price, string buyOrSell);

        int AddUserItem(UserItem item);

        UserItem GetUserItem(int userId);

        UserItem GetUserItem(string username);

        List<UserItem> GetUserItems();

        int AddRoleItem(RoleItem item);

        RoleItem GetRoleItem(int id);

        List<RoleItem> GetRoleItems();

        bool UpdateRoleItem(RoleItem item);

        void DeleteRoleItem(int id);
    }
}
