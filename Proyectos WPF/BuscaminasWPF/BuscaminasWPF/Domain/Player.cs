using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaminasWPF
{
    class Player
    {
        public int idPlayer { get; set; }
        public String name { get; set; }
        public int score { get; set; }

        public ManagePlayer manage { get; set; }

        public Player()
        {
            this.manage = new ManagePlayer();
        }

        public Player(int idPlayer)
        {
            this.manage = new ManagePlayer();
            this.idPlayer = idPlayer;
        }

        public void ReadAll()
        {
            manage.ReadAll();
        }

        public void ReadPlayer()
        {
            manage.ReadPlayer(this);
        }

        public void Insert()
        {
            manage.InsertPlayer(this);
        }

    }

    
}
