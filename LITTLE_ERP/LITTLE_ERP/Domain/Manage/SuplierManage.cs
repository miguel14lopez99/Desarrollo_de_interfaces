using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain.Manage
{
    /// <summary>
    /// Class for manage suplier objects
    /// </summary>
    class SuplierManage
    {
        public List<Suplier> list { get; set; }
        public List<Suplier> selectedList { get; set; }

        /// <summary>
        /// Initializes all the lists of the <see cref="SuplierManage"/> class.
        /// </summary>
        public SuplierManage()
        {
            list = new List<Suplier>();
            selectedList = new List<Suplier>();
        }

        /// <summary>
        /// Reads all supliers from a Json file.
        /// </summary>
        public void ReadAll()
        {
            String json = File.ReadAllText(@"Supliers.json");
            list = JsonConvert.DeserializeObject<List<Suplier>>(json);
        }

        /// <summary>
        /// Adds to a list all supliers that meet a pattern.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
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
