using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YZM_2116_PROJE
{
    public class TreeNode
    {
        public Mezun Veri;
        public TreeNode Sol;
        public TreeNode Sag;

        public TreeNode()
        {
        }

        public TreeNode(Mezun veri)
        {
            this.Veri = veri;
            Sol = null;
            Sag = null;
        }
    }
}
