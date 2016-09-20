using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    private List<TreeNode> _matchingNodes;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateCarTypes();
        }
    }

    private void PopulateCarTypes()
    {
        List<VehicleType> allTypes = new List<VehicleType>();
        using (MyDatabaseEntities dc = new MyDatabaseEntities())
        {
            allTypes = dc.VehicleTypes.ToList();
        }
        foreach (VehicleType c in allTypes)
        {
            TreeNode t = new TreeNode(
                $"Node Name:{c.Name} " +
                $"Node Id:{c.Id} " +
                $"Created on:{c.TimeStamp} " +
                $"Description{c.Description}",
                c.Id.ToString());
            t.PopulateOnDemand = true;
            TreeView1.Nodes.Add(t);
        }
    }

    protected void TreeView1_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        // This code is for populate Child nodes
        TreeNode main = e.Node;
        int carTypeId = Convert.ToInt32(main.Value);
        List<VehicleSubType> subTypes = new List<VehicleSubType>();
        using (MyDatabaseEntities dc = new MyDatabaseEntities())
        {
            subTypes = dc.VehicleSubTypes.Where(a => a.VehicleTypeId.Equals(carTypeId)).OrderBy(a => a.Name).ToList();
        }
        foreach (VehicleSubType s in subTypes)
        {
            TreeNode sub = new TreeNode($"Node Name:{s.Name} " +
                                        $"Node Id:{s.Id} " +
                                        $"Created on:{s.TimeStamp} " +
                                        $"Description{s.Description}", 
                                        s.Id.ToString());
            main.ChildNodes.Add(sub);
        }
    }

    protected void Button_Click(object sender, EventArgs e)
    {

        ProcessTreeView(TreeView1, ValueText.Text.ToString());
        if (_matchingNodes.Count != 0)
            foreach (var node in _matchingNodes)
            {
                node.Select();
                node.Expand();
                ValueText.Text = "Found";

            }
        else
        {
            ValueText.Text = "Not found";
        }
    }
    private void ProcessTreeView(TreeView treeView, String FindText)
    {
        _matchingNodes = new List<TreeNode>();

        // Process each node recursively.
        foreach (TreeNode n in treeView.Nodes)
        {
            if (n.Text.Contains(FindText))
                _matchingNodes.Add(n);
            ProcessRecursive(n, FindText);
        }

    }

    private void ProcessRecursive(TreeNode treeNode, String FindText)
    {
        // Process each node recursively.
        foreach (TreeNode n in treeNode.ChildNodes)
        {
            if (n.Text.Contains(FindText))
                _matchingNodes.Add(n);
            ProcessRecursive(n, FindText);
        }
    }

}