using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace Day_22.Models
{
    class AccountRepository
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Faridun\\Allif Academy\\Day 22\\Day 22\\App_Data\\accounts.mdf\";Integrated Security=True";
        public int Create(Account account)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "insert into Account (Login, Name, Surname) values(@Login, @Name, @Surname); select cast(SCOPE_IDENTITY() as int)";
                int newAccoountId = db.Query<int>(sqlQuery, account).FirstOrDefault();
                return newAccoountId;
            }
        }
        public List<Account> Read()
        {
            List<Account> accounts = new List<Account>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string sqlQuery = "select * from Account";
                accounts = db.Query<Account>(sqlQuery).ToList();
            }
            return accounts;
        }
        public void Update(Account account)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string sqlQuery = "update Account set Login = @Login, Name = @Name, Surname = @Surname where Id = @Id";
                db.Execute(sqlQuery, account);
            }
        }
        public void Delete(int Id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string sqlQuery = "delete from Account where Id = @id";
                db.Execute(sqlQuery, new { Id });
            }
        }
    }
}
