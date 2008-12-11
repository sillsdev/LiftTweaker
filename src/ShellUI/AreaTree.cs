using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Autofac;
using Rhino.Commons;

namespace Tweaker
{


    public partial class AreaTree : UserControl
    {
        public event EventHandler<Rhino.Commons.EventArgs<AreaFormCommand>> LoadTweakControl;

        public AreaTree()
        {
            InitializeComponent();
        }

        private void AreaTree_Load(object sender, EventArgs e)
        {
            
         //   LoadTweakChoices();
        }

        public void LoadTweakChoices()
        {
            treeView1.Nodes.Clear();
            var nodes = new List<TreeNode>();
            var heading = AddHeadingNode(nodes, "Entry Filters");
            AddNode<FilterByPartsOfSpeechControl>(heading, "Parts Of Speech");
            heading = AddHeadingNode(nodes, "Relations Pruning");
            var selectOnStartup = AddNode<PruneRelationsControl>(heading, "All");

            treeView1.Nodes.AddRange(nodes.ToArray());
            
            treeView1.ExpandAll();
            treeView1.SelectedNode = selectOnStartup;
        }

        private static TreeNode AddHeadingNode(ICollection<TreeNode> nodes, string label)
        {
            var heading = new TreeNode(label);
            
            nodes.Add(heading);
            return heading;
        }

        private static TreeNode AddNode<T>(TreeNode parent, string label) where T: UserControl
        {
            var node = new TreeNode(label);
            node.Tag = new AreaFormCommand() { Label = label, ControlFactory = service=> service.Resolve<T>()  };
            parent.Nodes.Add(node);
            return node;
        }

        public class AreaFormCommand
        {
            public string Label { get; set; }
            public Func<IContext, UserControl> ControlFactory { get; set; }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(e.Node.Tag ==null)
                return;
           if(LoadTweakControl !=null)
           {
               LoadTweakControl.Invoke(this, new EventArgs<AreaFormCommand>((AreaFormCommand) e.Node.Tag));
           }

        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
