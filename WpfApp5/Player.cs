using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp5
{
    public class Player
    {
        public string Name = "";
        public int Health = 0;
        public int Stamina = 0;
        public int Mana = 0;
        public List<Item> Items = new List<Item>();

        public Player (string Iname, int IHealth, int IStamina, int IMana)
        {
            Name = Iname;
            Health = IHealth;
            Stamina = IStamina;
            Mana = IMana;
        }
        
    }
}
