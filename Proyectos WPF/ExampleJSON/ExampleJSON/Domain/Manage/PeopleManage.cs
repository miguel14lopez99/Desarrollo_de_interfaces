using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace ExampleJSON.Domain.Manage
{
    class PeopleManage
    {
        public List<People> list { get; set; }

        public PeopleManage()
        {
            list = new List<People>();
        }

        public void ReadAll()
        {
            String json = File.ReadAllText(@"People.json");
            list = JsonConvert.DeserializeObject<List<People>>(json);
        }
    }
}
