using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SD;
using ASL;
using ASL.Forms;

namespace SD.Project
{
  public partial class ProjectMangerForm : Form
  {
    #region main

    private ChildForm cf;

    public ProjectMangerForm()
    {
      InitializeComponent();

      kmMappings.Visible = false;
      kmEdit.ShortcutKeys = Keys.F2;
      kmEdit2.ShortcutKeys = Keys.Alt | Keys.Z;
      kmContext.ShortcutKeys = Keys.Alt | Keys.I;

      // make client forms 500x600
      this.Size = new System.Drawing.Size(1000, 800);

      splitContainer1.FixedPanel = FixedPanel.Panel1;
      splitContainer1.SplitterDistance = 300;
      splitContainer1.IsSplitterFixed = false;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;

      DataStore.OpenDatabase("localhost");

      //AddData();

      this.menuExit.Click += menuExit_Click;
      this.FormClosed += ProjectMangerForm_FormClosed;
      this.tsDocuments.Click += tsDocuments_Click;
      this.tsProject.Click += tsProject_Click;
      this.tsStaff.Click += tsStaff_Click;
      this.tsTime.Click += tsTime_Click;

      toc.AfterSelect += toc_AfterSelect;
      toc.BeforeExpand += toc_BeforeExpand;
      toc.AfterCollapse += toc_AfterCollapse;
      //this.Move += clientFormFrame_Move;

      kmEdit.Click += kmEdit_Click;
      kmEdit2.Click += kmEdit_Click;
      kmContext.Click += kmContext_Click;
    }

    void kmContext_Click(object sender, EventArgs e)
    {
      try
      {
        if (toc.SelectedNode == null) return;
        if (toc.SelectedNode is TnClient)
        {
          TnClient tnc = (TnClient)toc.SelectedNode;
          TnClientFolder tncf = (TnClientFolder)tnc.Parent;
          tncf.Nodes.Clear();
          tncf.Nodes.Add(tnc);
          toc.SelectedNode = tnc;
          tnc.EnsureVisible();
          tnc.Expand();
        }
        else if (toc.SelectedNode is TnProject)
        {
          TnProject tnp = (TnProject)toc.SelectedNode;
          TnProjectFolder tnpf = (TnProjectFolder)tnp.Parent;
          tnpf.Nodes.Clear();
          tnpf.Nodes.Add(tnp);
          toc.SelectedNode = tnp;
          tnp.EnsureVisible();
          tnp.Expand();
        }
        else
        {
          Msg.ShowInfo("Localize context not available at this level");
        }
      }
      catch (Exception exc)
      {
        Msg.ReferToTechSupport(exc);
      }
    }

    void toc_AfterCollapse(object sender, TreeViewEventArgs e)
    {
      if (e.Node is TnClientFolder || e.Node is TnClient)
      {
        e.Node.Nodes.Clear();
        e.Node.Nodes.Add(new TnDummy());
      }
    }

    void toc_BeforeExpand(object sender, TreeViewCancelEventArgs e)
    {
      if (e.Node is TnClientFolder)
      {
        TnClientFolder tnr = (TnClientFolder)e.Node;
        tnr.Nodes.Clear();
        BindingList<DdClientExt> clients = DataStore.GetClientList();
        foreach (DdClientExt client in clients)
        {
          TnClient tnc = new TnClient(client);
          tnc.Nodes.Add(new TnDummy());
          tnr.Nodes.Add(tnc);
        }
      }
      else if (e.Node is TnClient)
      {
        TnClient tnc = (TnClient)e.Node;
        tnc.Nodes.Clear();
        TnProjectFolder tnpf = new TnProjectFolder();
        tnc.Nodes.Add(tnpf);
        tnpf.Nodes.Add(new TnDummy());
      }
      else if(e.Node is TnProjectFolder)
      {
        TnProjectFolder tnpf = (TnProjectFolder)e.Node;
        TnClient tnc = (TnClient)e.Node.Parent;
        tnpf.Nodes.Clear();
        BindingList<DdProjectExt> projects = DataStore.GetProjectList(tnc.Client.Id);
        foreach (DdProjectExt project in projects)
        {
          TnProject tnp = new TnProject(project);
          tnpf.Nodes.Add(tnp);
        }

      }
    }

    void toc_AfterSelect(object sender, TreeViewEventArgs e)
    {
      try
      {
        if (e.Node is TnClient)
        {
          ShowClientForm(((TnClient)e.Node).Client.Id, editMode: false);
        }
        else
        {
          cf = null;
          clientFormFrame.Controls.Clear();
          //Msg.ReferToTechSupport("Unrecognized node in tree: {0}", e.Node.Text);
        }
      }
      catch (Exception exc)
      {
        Msg.ReferToTechSupport(exc);
      }
    }

    void kmEdit_Click(object sender, EventArgs e)
    {
      try
      {
        if (toc.SelectedNode == null) return;
        if (toc.SelectedNode is TnClient)
        {
          ClientForm cf = 
            ShowClientForm(((TnClient)toc.SelectedNode).Client.Id, editMode: true);
          if (cf != null) cf.Focus();
        }
        else
        {
          cf = null;
          clientFormFrame.Controls.Clear();
        }
      }
      catch (Exception exc)
      {
        Msg.ReferToTechSupport(exc);
      }
    }


    void menuExit_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    void ProjectMangerForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      DataStore.Close();
    }

    void tsTime_Click(object sender, EventArgs e)
    {
      try
      {
        Msg.ShowInfo("Not yet implemented");
      }
      catch (Exception exc)
      {
        Msg.ReferToTechSupport(exc);
      }
    }

    void tsStaff_Click(object sender, EventArgs e)
    {
      try
      {
        PersonForm personForm = new PersonForm();
        cf = personForm;
        cf.Dock = DockStyle.Fill;
        clientFormFrame.Controls.Clear();
        clientFormFrame.Controls.Add(cf);      
      }
      catch (Exception exc)
      {
        Msg.ReferToTechSupport(exc);
      }
    }

    void tsProject_Click(object sender, EventArgs e)
    {
      try
      {
      ShowProjectView();
      }
      catch (Exception exc)
      {
        Msg.ReferToTechSupport(exc);
      }
    }

    void tsDocuments_Click(object sender, EventArgs e)
    {
      try
      {
      }
      catch (Exception exc)
      {
        Msg.ReferToTechSupport(exc);
      }
    }

    #endregion

    private void AddData()
    {
      int proNum = 1031;
      for (int cix = 6; cix < 10; cix++)
      {
        DdClientExt ddc = new DdClientExt();
        ddc.ClientID = "Client-" + cix.ToString();
        ddc.FullName = "Client Named " + cix.ToString();
        DataStore.AddClient(ref ddc, new RevisionInfo());
        for (int pix = 1; pix < 4; pix++)
        {
          DdTaskHeadingExt ddh = new DdTaskHeadingExt();
          ddh.ProjectREF = DataStore.NullId;
          ddh.TaskHeadingID = DateTime.Now.ToString("yyyyMMddHHmmssffff");
          ddh.Title = "General";
          DataStore.AddTaskHeading(ref ddh, new RevisionInfo());

          DdProjectExt ddp = new DdProjectExt();
          ddp.ClientREF = ddc.Id;
          ddp.Description = "Project Number " + pix.ToString();
          ddp.ProjectID = "P" + proNum.ToString("0000");
          ddp.TaskHeadingREF = ddh.Id;
          DataStore.AddProject(ref ddp, new RevisionInfo());
          proNum += 1;

          ddh.ProjectREF = ddp.Id;
          ddh.TaskHeadingID = "General";
          DataStore.SaveTaskHeading(ref ddh, new RevisionInfo());
        }
      }
    }

    private void ShowProjectView()
    {
      toc.Nodes.Clear();
      TnRoot root = new TnRoot();
      TnClientFolder clients = new TnClientFolder();
      clients.Nodes.Add(new TnDummy());
      root.Nodes.Add(clients);
      toc.Nodes.Add(root);
      root.Expand();
    }

    private ClientForm ShowClientForm(int clientREF, bool editMode = false)
    {
      try
      {
        ClientForm clientForm;
        if (!(cf is ClientForm))
        {
          clientForm = new ClientForm();
          cf = clientForm;
          cf.Dock = DockStyle.Fill;
          clientFormFrame.Controls.Clear();
          clientFormFrame.Controls.Add(cf);
        }
        else
        {
          clientForm = (ClientForm)cf;
        }

        if (editMode)
          clientForm.ShowAndEdit(clientREF);
        else
          clientForm.Show(clientREF);

        return clientForm;
      }
      catch (Exception exc)
      {
        Msg.ReferToTechSupport(exc);
        return null;
      }
    }
  }
}
