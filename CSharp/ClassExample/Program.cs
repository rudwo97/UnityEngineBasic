using System;

namespace ClassExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Human human1 = new Human();

            human1.age = 100;
            human1.SayAge();
            human1.height = 200.0f;
            human1.gender = 'm';

            Human human2 = new Human();

            human2.age = 50;
            human2.SayAge();
            human2.height = 150.0f;
            human2.gender = 'w';
        }
    }
    class Human
    {
        public int age;
        public float height;
        public char gender;
        public void SayAge()
        {
            Console.WriteLine(age);
        }
    }

    
}


