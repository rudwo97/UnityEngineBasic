using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Person : IAttackable
    {
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public Person(string name, int phoneNumber, string emailAddress)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
        }

        public void PurchaseParkingPass()
        {
            Console.WriteLine($"{Name} : 주차권 구매 완료");
        }

        public void Attack()
        {
            Console.WriteLine($"{Name} (이)가 공격했다.");
        }
    }
}
