using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_End.Models;

namespace Bank_End
{
    class BankManager
    {
        public List<Account> accounts;
        public List<User> users;
        public List<Transaction> transactions;

        public List<Deposite> deposites;
        public List<Credit> credits;
        
        
        public bool CheckUser(string Name, string Password)
        {
            //Проверяет есть ли такой пользователь
            foreach (User user in users)
            {
                if(user.Name == Name && user.Password == Password)
                {
                    return true;
                }
            }            
            return false;
        }

        public List<Account> GetAccountsByUser(User user)
        {
            var result = new List<Account> { };
            foreach(var acc in accounts)
            {
                if( acc.Owner.Name == user.Name && acc.Owner.Password == user.Password)
                {
                    result.Add(acc);
                }
            }
            return result;            
        }

        public List<Transaction> GetSentTransactionsByAccount(Account account)
        {
            var result = new List<Transaction> { };
            foreach (var trans in transactions)
            {
                if(trans.Sender.Owner.Name == account.Owner.Name 
                    && trans.Sender.Owner.Password == account.Owner.Password)
                {
                    result.Add(trans);
                }
            }
            return result;
        }

        public List<Transaction> GetRecievedTransactionsByAccount(Account account)
        {
            var result = new List<Transaction> { };
            foreach (var trans in transactions)
            {
                if (trans.Reciever.Owner.Name == account.Owner.Name
                    && trans.Reciever.Owner.Password == account.Owner.Password)
                {
                    result.Add(trans);
                }
            }
            return result;
        }

        public bool NewTransaction(Account sender, Account reciever, decimal amount)
        {
            if (sender.Currency == reciever.Currency && CheckUser(sender.Owner.Name, sender.Owner.Password) 
                && CheckUser(reciever.Owner.Name, reciever.Owner.Password) && amount > 0)
            {
                var newtrans = new Transaction()
                {
                    Sender = sender,
                    Reciever = reciever,
                    Amount = amount,
                    TransactionDate = DateTime.Now,
                    TransactionID = transactions.Count + 1 //сомневаюсь в правильности id
                };
                transactions.Add(newtrans);

                sender.Balanse += amount;
                reciever.Balanse -= amount;

                return true;
            }
            else
            {
                return false;
                // false ЕСЛИ ТРАНЗКЦИЯ НЕ ВЫПОЛНЕНА
                //если есть желание, можешь разделить проверку условия на несколько if и узнавать о разных ошибках 
            }
        }

        


        public void LoadData()
        {
            //загрузка данных с базы данных
        }
        public void SaveData()
        {
            //Выгрузка в базу данных
        }
    }
}
