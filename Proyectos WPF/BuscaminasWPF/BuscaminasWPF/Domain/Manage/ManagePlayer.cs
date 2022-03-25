using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaminasWPF
{
    class ManagePlayer
    {

        public List<Player> list { get; set; }

        public ManagePlayer()
        {
            this.list = new List<Player>();
        }

        public void ReadAll()
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("SELECT idPlayer FROM players where deleted=0 order by score", "players"); //all users who are not deleted or aren't the root user are recovered

            DataTable table = data.Tables["players"];

            Player aux;

            foreach (DataRow row in table.Rows)
            {
                aux = new Player(Convert.ToInt32(row["idPlayer"]));
                ReadPlayer(aux);         
                list.Add(aux);
            }
        }

        public void ReadPlayer(Player player)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("SELECT * FROM players where idPlayer=" + player.idPlayer, "players");

            DataTable table = data.Tables["players"];

            DataRow row = table.Rows[0];
            player.name = Convert.ToString(row["name"]);
            player.score = Convert.ToInt32(row["score"]);
        }

        public void InsertPlayer(Player player)
        {
            ConnectOracle Search = new ConnectOracle();

            int maximun = Convert.ToInt32("0" + Search.DLookUp("max(idPlayer)", "players", "")) + 1;

            player.idPlayer = maximun;

            Search.setData("INSERT INTO players VALUES(" + player.idPlayer + ",'" + player.name + "','" + player.score + "',0)");
        }
    }
}
