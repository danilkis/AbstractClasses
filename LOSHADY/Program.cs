using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Threading;

namespace LOSHADY
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.BufferWidth = 1000;
            Console.BufferHeight = 1000;
            Console.Clear();
            // создаем новый поток
            Thread myThread1 = new Thread(BornRandom);
            Thread myThread2 = new Thread(new ThreadStart(BornRandom));
            Thread myThread4 = new Thread(new ThreadStart(MoveDaDog));
            myThread1.Start(); // запускаем поток myThread1
            myThread2.Start(); // запускаем поток myThread2
            if(!myThread1.Join(5000)) { // or an agreed resonable time
                myThread1.Abort();
            }
            if(!myThread2.Join(5000)) { // or an agreed resonable time
                myThread2.Abort();
            }
            if (!myThread1.IsAlive && !myThread2.IsAlive)
            {
                myThread4.Start();
            }
        }

        private static void MoveDaDog()
        {
            while (true)
            {
                foreach (var dog in dogs)
                {
                    var randomrandom = new Random();
                    Thread.Sleep(300);
                    switch (randomrandom.Next(1,5))
                    {
                        case 1: // Right
                        {
                            var randRes = randomrandom.Next(5);
                            Helper.Place('‍', dog.X, dog.Y,ConsoleColor.Black);
                            if (dog.X + randRes <= 200)
                            {
                                int dx = dog.X + randRes;
                                dog.Move(dx, dog.Y);
                            }

                            break;
                        }

                        case 2: // Left
                        {
                            var randRes = randomrandom.Next(5);
                            if (dog.X - randRes >= 200)
                            {
                                int dx = dog.X - randRes;
                                Helper.Place('‍', dog.X, dog.Y,ConsoleColor.Black);
                                dog.Move(dx, dog.Y);
                            }

                            break;
                        }

                        case 3: // Down
                        {
                            var randRes = randomrandom.Next(5);
                            if (dog.Y + randRes <= 200)
                            {
                                int dy = dog.Y + randRes;
                                Helper.Place('‍', dog.X, dog.Y,ConsoleColor.Black);
                                dog.Move(dog.X, dy);
                            }

                            break;
                        }

                        case 4: // Up
                        {
                            var randRes = randomrandom.Next(5);
                            if (dog.Y - randRes >= 200)
                            {
                                int dy = dog.Y - randRes;
                                Helper.Place('‍', dog.X, dog.Y,ConsoleColor.Black);
                                dog.Move(dog.X, dy);
                            }

                            break;
                        }

                        case 0:
                        {
                            break;
                        }
                    }
                }
            }
        }
        public static List<Monster> dogs = new List<Monster>();
        private static void BornRandom()
        {
            for (int i = 0; i < 500; i++)
            {
                Monster monster = null;
                Random rnd = new Random();
                if (rnd.NextDouble() > 0.5) { monster = new Hedgehog(); }
                else { monster = new Dog(); }
                monster.BeBorn(rnd.Next(1, (int)Console.WindowWidth), rnd.Next(1,(int)Console.WindowHeight), rnd.Next(1,60));
                var randomrandom = new Random();
                var type = monster.GetType();
                if (type == typeof(Dog))
                {
                    dogs.Add(monster);
                }
            }
        }
        
    }
}
    