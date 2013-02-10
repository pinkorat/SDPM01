using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SD_Manager
{
  public partial class MainForm : Form
  {
    ListView alist;

    public MainForm()
    {
      InitializeComponent();

      ShowSomething();
    }

    private void ShowSomething()
    {
      TreeNode t0 = new TreeNode("Applications");
      TreeNode t1 = AddApplication(t0, "FDM041");
      for (int i = 0; i < 10; i++)
      {
        TreeNode tx = new TreeNode("Filler " + i.ToString());
        t1.Nodes.Add(tx);
      }

      TreeNode t2 = AddApplication(t0, "FSSA041");

      TreeNode t3 = AddApplication(t0, "FSA042");

      for (int i = 0; i < 10; i++)
      {
        TreeNode tx = new TreeNode("Filler " + i.ToString());
        t3.Nodes.Add(tx);
      }

      this.atree.Nodes.Add(t0);

      alist = new ListView();
      alist.LargeImageList = this.imageList1;
      alist.View = View.Tile;
      {
        ListViewItem lvi = new ListViewItem(new string[] { "the king", "b" }, 0);
        alist.Items.Add(lvi);
      }
      {
        ListViewItem lvi = new ListViewItem(new string[] { "the dog", "b" }, 1);
        alist.Items.Add(lvi);
      }
      {
        ListViewItem lvi = new ListViewItem(new string[] { "the me", "b" }, 2);
        alist.Items.Add(lvi);
      }
    }

    TreeNode AddApplication(TreeNode tn, string text)
    {
      TreeNode t1 = new TreeNode(text);
      tn.Nodes.Add(t1);
      return t1;
    }
  }
}
