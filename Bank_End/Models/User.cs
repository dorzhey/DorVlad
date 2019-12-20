using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_End.Models
{
    public class User
    {
        public int UserID { get; private set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Password { get; set; }

        //НАДО ПОДУМАТЬ КАК СДЕЛАТЬ PASSWORD PRIVATE

        //public string GetPassword()
        //{
        //    //Хочу сделать что-то тип сохранности пароля.
        //    //Думаю, с помощью метода, запрашивающего кодовое слово
        //    Console.WriteLine("Введите кодовое слово");
        //    var kword = Console.ReadLine();
        //    //пусть будет 11
        //    if (kword == "11")
        //    {
        //        return Password;
        //    }
        //    else
        //    { 
        //        throw new Exception();
        //        // в gui можно реализовать через trycatch
        //    } 
        //}
        ////Тут тоже
        //public void SetPassword(string pswrd)
        //{
        //    Console.WriteLine("Введите кодовое слово");
        //    var kword = Console.ReadLine();
        //    if (kword == "11")
        //    {
        //        Password = pswrd;
        //    }
        //    else
        //    {
        //        Console.WriteLine("НЕ то");
        //        throw new Exception();
        //    }
        //}
    }
}
