using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    class Enemy
    {

        public int speed { get; set; }
        public int maxHealth { get; set; }
        public int health { get; set; }
        public int Serial { get; set; }
        public point location {get; set; }
        public int tracker { get; set; }
        public int Value { get; set; }
        public int level { get; set; }
        public Enemy(int pspeed, int phealth)
        {
            speed = pspeed;
            maxHealth = phealth;
            health = maxHealth;
            tracker = 0;
            location = new point(0, 0);
            Value = 1;
            level = 1;
        }
        public void move(route way, out int gold) 
        {
            gold = 0;
            if (health > 0)
            {

                for (int i = 0; i < speed; i++)
                {
                    tracker++;
                    if (tracker >= way.myRoute.Length)
                    {
                        break;
                    }
                    location = way.myRoute[tracker];
                }
            }
            else
            {
                location = way.myRoute[0];
                maxHealth = (int)(maxHealth * 1.25);
                health = maxHealth;
                tracker = 0;
                Serial += 10;
                gold = Value;
                Value++;
                level++;

            }

        }
    }
}
