using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_End.Models;

namespace Bank_End
{
    public class BankManager
    {
        public List<Account> accounts;
        public List<User> users;
        public List<Transaction> transactions;
        public List<Manager> managers;
        public List<Card> cards;

        public List<Deposit> deposits;
        public List<Credit> credits;
        public BankManager()
        {
            LoadData();
        }
        
        
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

        private string UsersFileName = "Data\\userid_and_names.csv";
        private string AccountFileName = "Data\\account.csv";
        private string CardFileName = "Data\\card.csv";
        private string CreditFileName = "Data\\credit_type.csv";
        private string DepositFileName = "Data\\deposit_type.csv";
        private string TransactionFileName = "Data\\transactions.csv";
        private string ManagerFileName = "Data\\manager.csv";

        public List<List<string>> Desirialize(string filename)
        {
            List<List<string>> result = new List<List<string>> { };
            using (var reader = new StreamReader(filename))
            {

                var iterator = 0;
                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (iterator > 0)
                    {
                        result.Add(new List<string>(values));
                    }

                    iterator++;

                }

                




                return result;
            }
        }


        public List<User> GetUsers()
        {
            var temp = Desirialize(UsersFileName);
            var result = new List<User> { };
            foreach (var line in temp)
            {
                var user = new User
                {
                    UserID = long.Parse(line[0]),
                    Name = line[1],
                    SecondName = line[2],
                    Password = line[3]
                };
                result.Add(user);
            }
            return result;
        }

        public List<Manager> GetManagers()
        {
            var temp = Desirialize(ManagerFileName);
            var result = new List<Manager> { };
            foreach (var line in temp)
            {
                var manager = new Manager
                {
                    ManagerID = long.Parse(line[0]),
                    Password = line[1]
                };
                result.Add(manager);
            }
            return result;
        }
        public List<Account> GetAccounts()
        {
            var temp = Desirialize(AccountFileName);
            var result = new List<Account> { };
            var owner = new User();
            foreach (var line in temp)
            {
                var Owner = long.Parse(line[3]);
                foreach(var user in users)
                {
                    if(user.UserID == Owner)
                    {
                        owner = user;
                    }
                }
                var account = new Account
                {
                    AccountID = long.Parse(line[0]),
                    Balanse = long.Parse(line[1]),
                    Currency = int.Parse(line[2]),
                    Owner = owner
                };
                result.Add(account);
            }
            return result;
        }


        public List<Card> GetCards()
        {
            var temp = Desirialize(CardFileName);
            var result = new List<Card> { };
            var acc = new Account();
            foreach (var line in temp)
            {
                var CardAccount = long.Parse(line[1]);
                foreach (var account in accounts)
                {
                    if (account.AccountID == CardAccount)
                    {
                        acc = account;
                    }
                }


                var card = new Card
                {
                    CardNumber = long.Parse(line[0]),
                    CardAccount = acc,

                };
                result.Add(card);
            }
            return result;

        }

        public List<Credit> GetCredits()
        {
            var temp = Desirialize(CreditFileName);
            var result = new List<Credit> { };
            var borrower = new User();
            foreach (var line in temp)
            {
                var _Borrower = long.Parse(line[0]);
                foreach (var user in users)
                {
                    if (user.UserID == _Borrower)
                    {
                        borrower = user;
                    }
                }
                var credit = new Credit
                {
                    
                    CreditID = long.Parse(line[1]),
                    Regularity = int.Parse(line[2]),
                    CreditRate  = int.Parse(line[3]),
                    IssuanceDate = DateTime.Parse(line[4]),
                    ExpireDate = DateTime.Parse(line[5]),
                    Borrower =  borrower
                };
                
                result.Add(credit);
            }
            return result;
        }



        public List<Deposit> GetDeposits()
        {
            var temp = Desirialize(DepositFileName);
            var result = new List<Deposit> { };
            var borrower = new User();
            foreach (var line in temp)
            {
                var Borrower = long.Parse(line[0]);
                foreach (var user in users)
                {
                    if (user.UserID == Borrower)
                    {
                        borrower = user;
                    }
                }
                var deposit = new Deposit
                {

                    DepositID = long.Parse(line[1]),
                    Regularity = int.Parse(line[2]),
                    DepositRate = int.Parse(line[3]),
                    IssuanceDate = DateTime.Parse(line[4]),
                    ExpireDate = DateTime.Parse(line[5]),
                    Investor = borrower
                };

                result.Add(deposit);
            }
            return result;
        }

        public List<Transaction> GetTransactions()
        {
            var temp = Desirialize(TransactionFileName);
            var result = new List<Transaction> { };
            var sender = new Account();
            var reciever = new Account();
  
            foreach (var line in temp)
            {


                var _Sender = long.Parse(line[0]);
                foreach (var account in accounts)
                {
                    if (account.AccountID == _Sender)
                    {
                        sender = account;
                    }
                }


                var _Reciever = long.Parse(line[1]);
                foreach (var account in accounts)
                {
                    if (account.AccountID == _Reciever)
                    {
                        reciever = account;
                    }
                }


                var transaction = new Transaction
                {
                    Amount = long.Parse(line[2]),
                    TransactionDate = DateTime.Parse(line[3]),
                    Sender  = sender,
                    Reciever = reciever

                };
                result.Add(transaction);
            }
            return result;

        }






        
        public void LoadData()
        {
            //загрузка данных с базы данных
          users=  GetUsers();
          accounts=  GetAccounts();
          cards = GetCards();
           credits = GetCredits();
           transactions= GetTransactions();
           deposits= GetDeposits();
           managers= GetManagers();
        }
            public void SaveData()
        {
            //Выгрузка в базу данных
        }
    }
}
