using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milka
{
    class Program
    {
        static void Main(string[] args)
        {
            TagLogic tagLogic = new TagLogic();
            tagLogic.GetTags();
            tagLogic.GenerateTagList();

            ItemLogic itemLogic = new ItemLogic();
            itemLogic.GetItems();
            Item i = itemLogic.GetByName("Milka Oreo");

            tagLogic.FindAndPrint(i);
            tagLogic.PrintInvalidCount();
        }
    }
}
