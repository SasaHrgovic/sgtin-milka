using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milka
{
    public class ItemLogic
    {
        public List<Item> Items { get; set; }
        public ItemLogic()
        {
            Items = new List<Item>();
        }
        public void GetItems()
        {
            using (StreamReader sr = new StreamReader("data.csv"))
            {
                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    var itemsArray = line.Split(';');

                    Item i = new Item()
                    {
                        CompanyPrefix = itemsArray[0],
                        CompanyName = itemsArray[1],
                        ItemReference = int.Parse(itemsArray[2]),
                        ItemName = itemsArray[3]
                    };

                    Items.Add(i);
                }
            }
        }

        public Item GetByName(string name)
        {
            return Items.Where(x => x.ItemName == name).FirstOrDefault();
        }
    }
}
