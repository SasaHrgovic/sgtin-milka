using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milka
{
    public class TagLogic
    {
        public List<string> HexTags { get; set; }
        public List<Tag> Tags { get; set; }

        public TagLogic()
        {
            HexTags = new List<string>();
            Tags = new List<Tag>();
        }
        public void GetTags()
        {
            using (StreamReader sr = File.OpenText("tags.txt"))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    HexTags.Add(s);
                }
            }
        }

        public void GenerateTagList()
        {
            foreach (string s in HexTags)
            {
                Tag t = new Tag(s);
                Tags.Add(t);
            }
        }

        public void FindAndPrint(Item i)
        {
            List<Tag> result = Tags.Where(x => x.Reference == i.ItemReference && x.IsValid == true).ToList();
            Console.WriteLine("{0} Count: {1}", i.ItemName, result.Count);

            foreach (Tag tag in result)
            {
                Console.WriteLine("Serial: {0}", tag.Serial);
            }
        }

        public void PrintInvalidCount()
        {
            List<Tag> result = Tags.Where(x => x.IsValid == false).ToList();
            Console.WriteLine("Invalid count: {0}", result.Count);
        }
    }
}
