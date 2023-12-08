using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHSLibrarySystem
{
    internal class TreeNode : IEnumerable<TreeNode>
    {
        //variables
        private readonly Dictionary<string, TreeNode> _children = new Dictionary<string, TreeNode>();
        public readonly string ID;

        public TreeNode Parent { get; private set; }

        public TreeNode(string id)
        {
            this.ID = id;
        }

        public TreeNode GetChild(string id)
        {
            return this._children[id];
        }

        public void Add(TreeNode item)
        {
            if (item.Parent != null)
            {
                item.Parent._children.Remove(item.ID);
            }

            item.Parent = this;
            this._children.Add(item.ID, item);
        }

        public int Count
        {
            get { return this._children.Count; }
        }

        public static TreeNode BuildTree(string[] tree)
        {
            var result = new TreeNode("TreeRoot");
            var list = new List<TreeNode> { result };


            foreach (var line in tree)
            {
                var trimmedLine = line.Trim();
                var indent = line.Length - trimmedLine.Length;

                var child = new TreeNode(trimmedLine);
                list[indent].Add(child);

                if (indent + 1 < list.Count)
                {
                    list[indent + 1] = child;
                }
                else
                {
                    list.Add(child);
                }
            }
            return result;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<TreeNode> GetEnumerator()
        {
            return this._children.Values.GetEnumerator();
        }
    }
}
