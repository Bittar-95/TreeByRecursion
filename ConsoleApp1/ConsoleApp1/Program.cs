using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace ConsoleApp1
{
    public class ListItem
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
    }

    public class Node
    {
        public int Id { get; set; }
        public List<Node> Children { get; set; }
    }


    public class Program
    {
        public static void Main()
        {
            var data = new List<ListItem>() {
                    new  ListItem {Id = 1 , ParentId = null},
                    new  ListItem{Id = 2 , ParentId = 1},
                    new  ListItem{Id = 3 , ParentId = 1},
                    new  ListItem{Id = 4 , ParentId = 2},
                    new  ListItem {Id = 5 , ParentId = 3},
                    new  ListItem {Id = 6 , ParentId = 4},
                    new  ListItem {Id = 7 , ParentId = 2},
                    new  ListItem {Id = 8 , ParentId = 4},
                    new  ListItem {Id = 9 , ParentId = 1},
            };
            var tree = GetTree(data);
        }
        public static List<Node> GetTree(List<ListItem> All, int? ParentId = null)
        {
            var items = All.Where(p => p.ParentId == ParentId).ToList();
            if (items.Count == 0)
            {
                return null;
            }
            List<Node> n = new List<Node>();
            foreach (var item in items)
            {
                var node = new Node();
                node.Id = item.Id;
                var result = GetTree(All, item.Id);
                if (result is not null)
                {
                    node.Children = new List<Node>();
                    node.Children = result;
                }
                n.Add(node);
            }
            return n;
        }

    }
}
