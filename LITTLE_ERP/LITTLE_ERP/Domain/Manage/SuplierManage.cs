using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain.Manage
{
    class SuplierManage
    {
        public List<Suplier> list { get; set; }
        public List<Suplier> selectedList { get; set; }

        public SuplierManage()
        {
            list = new List<Suplier>();
            selectedList = new List<Suplier>();
        }

        public void ReadAll()
        {
            String json = File.ReadAllText(@"Supliers.json");
            list = JsonConvert.DeserializeObject<List<Suplier>>(json);
        }

        public void setSelectedList(string pattern)
        {
            selectedList.Clear();

            ReadAll();

            foreach (Suplier suplier in list)
            {
                if (suplier.ToString().Contains(pattern))
                {
                    selectedList.Add(suplier);
                }
            }
        }

    }
}
