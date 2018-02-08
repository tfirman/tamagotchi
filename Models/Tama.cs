using System.Collections.Generic;
using System;

namespace Tama.Models
{
    public class Tamagotchi
    {
        private string _name;
        private int _food;
        private int _attention;
        private int _rest;
        private int _id;
        private bool _alive;

        private static int ID = 0;
        private static List<Tamagotchi> _instances = new List<Tamagotchi> {};

        public Tamagotchi(string name, int food, int attention, int rest)
        {
            _name = name;
            _food = food;
            _attention = attention;
            _rest = rest;
            _id = ID++;
            _instances.Add(this);
            _alive = true;
        }

        public string GetName()
        {
            return _name;
        }

        public int GetFood()
        {
            return _food;
        }

        public void SetFood(int newFood)
        {
            _food = newFood;
        }

        public int GetAttention()
        {
            return _attention;
        }

        public void SetAttention(int newAttention)
        {
            _attention = newAttention;
        }

        public int GetRest()
        {
            return _rest;
        }

        public void SetRest(int newRest)
        {
            _rest = newRest;
        }

        public int GetID()
        {
            return _id;
        }

        public bool GetAlive()
        {
            return _alive;
        }

        public void Death()
        {
            _alive = false;
        }


        public static List<Tamagotchi> GetAll()
        {
            Console.WriteLine("1");
            return _instances;
        }

        public static Tamagotchi GetById(int id)
        {
            foreach (Tamagotchi tama in _instances)
            {
                if(tama.GetID() == id)
                {
                    return tama;
                }
            }
            return null;
        }

        public void FeedTama()
        {
            if (_food <=79)
            {
                _food += 20;
            } else
            {
                _food = 100;
            }
        }

        public void PlayTama()
        {
            if (_attention <=74)
            {
                _attention += 25;
            } else
            {
                _attention = 100;
            }
        }

        public void TamaRest()
        {
            _rest = 100;
        }

        public static void TimePass()
        {
            // List<Tamagotchi> NewDeadTamagotchi = new List<Tamagotchi>();
            foreach (Tamagotchi tama in _instances)
            {
                tama.SetFood(tama.GetFood() - 10);
                tama.SetAttention(tama.GetAttention() - 10);
                tama.SetRest(tama.GetRest() - 10);
                if (tama.GetFood() <=0 || tama.GetAttention() <=0 || tama.GetRest() <=0)
                {
                    if (tama.GetAlive())
                    {
                        tama.Death();
                    }
                }
            }
            // return NewDeadTamagotchi;
        }
    }
}
