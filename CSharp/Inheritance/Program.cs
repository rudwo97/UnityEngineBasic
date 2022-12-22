using System;

namespace Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("아무개", 01012341234, "B@AC.com");
            Student student = new Student("학생1", 01043214321, "A@BC.com");
            Professor professor = new Professor("교수", 01011112222, "C@AB.com");

            person.PurchaseParkingPass();
            student.PurchaseParkingPass();
            professor.PurchaseParkingPass();

            Console.WriteLine(student.TakenSeminsar);

            // 공변성
            // 자식 타입으로 캐스팅, 참조할 수 있는 성질
            //
            // 반공변성
            // 부모 타입으로 캐스팅, 참조할 수 있는 성질
            //
            // 불공변성
            // 다른 타입으로 참조 불가능

            Person P_student = student;
            Person P_professor = professor;

            Person[] people = new Person[] { student, professor };
            for (int i = 0; i < people.Length; i++)
            {
                people[i].PurchaseParkingPass();
            }

            Cat cat = new Cat();
            student.Attack();
            cat.Attack();

            IAttackable[] attackables = new IAttackable[] { cat, student };
            for (int i = 0; i < attackables.Length; i++)
            {
                attackables[i].Attack();
            }


        }
    }
}
