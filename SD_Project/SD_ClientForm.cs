using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SD;
using ASL;
using ASL.Forms;

namespace SD.Project
{
  public partial class ClientForm : ChildForm
  {
    public ClientForm()
    {
      InitializeComponent();

      CreateFormFields();

    }
    private System.Windows.Forms.TextBox txtClientID;
    private System.Windows.Forms.Label labelClientID;
    private System.Windows.Forms.TextBox txtComment;
    private System.Windows.Forms.Label labelComment;
    private System.Windows.Forms.TextBox txtFullName;
    private System.Windows.Forms.Label labelFullName;

    private void CreateFormFields()
    {
      this.txtClientID = new System.Windows.Forms.TextBox();
      this.labelClientID = new System.Windows.Forms.Label();
      this.txtComment = new System.Windows.Forms.TextBox();
      this.labelComment = new System.Windows.Forms.Label();
      this.txtFullName = new System.Windows.Forms.TextBox();
      this.labelFullName = new System.Windows.Forms.Label();

      int y = 52;

      this.SuspendLayout();
      this.txtClientID.Location = new System.Drawing.Point(126, y);
      this.txtClientID.Name = "txtClientID";
      this.txtClientID.TabIndex = 0;
      this.txtClientID.Size = new System.Drawing.Size(260, 22);
      txtClientID.MaxLength = DdClient.ClientID_L;

      this.labelClientID.AutoSize = false;
      this.labelClientID.Location = new System.Drawing.Point(17, y+1);
      this.labelClientID.Name = "labelClientID";
      this.labelClientID.Size = new System.Drawing.Size(100, 17);
      this.labelClientID.TextAlign = ContentAlignment.MiddleRight;
      this.labelClientID.TabStop = false;
      this.labelClientID.Text = "Client ID";

      y += 24;

      this.txtComment.Location = new System.Drawing.Point(126, y);
      this.txtComment.Name = "txtComment";
      this.txtComment.TabIndex = 1;
      this.txtComment.Multiline = true;
      this.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txtComment.Size = new System.Drawing.Size(348, 138);
      txtComment.MaxLength = 0;

      this.labelComment.AutoSize = false;
      this.labelComment.Location = new System.Drawing.Point(17, y+1);
      this.labelComment.Name = "labelComment";
      this.labelComment.Size = new System.Drawing.Size(100, 17);
      this.labelComment.TextAlign = ContentAlignment.MiddleRight;
      this.labelComment.TabStop = false;
      this.labelComment.Text = "Comment";

      y += 140;

      this.txtFullName.Location = new System.Drawing.Point(126, y);
      this.txtFullName.Name = "txtFullName";
      this.txtFullName.TabIndex = 2;
      this.txtFullName.Size = new System.Drawing.Size(260, 22);
      txtFullName.MaxLength = DdClient.FullName_L;

      this.labelFullName.AutoSize = false;
      this.labelFullName.Location = new System.Drawing.Point(17, y+1);
      this.labelFullName.Name = "labelFullName";
      this.labelFullName.Size = new System.Drawing.Size(100, 17);
      this.labelFullName.TextAlign = ContentAlignment.MiddleRight;
      this.labelFullName.TabStop = false;
      this.labelFullName.Text = "Full Name";

      y += 24;

      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.txtClientID);
      this.Controls.Add(this.labelClientID);
      this.Controls.Add(this.txtComment);
      this.Controls.Add(this.labelComment);
      this.Controls.Add(this.txtFullName);
      this.Controls.Add(this.labelFullName);

      this.Name = "ClientForm";

      this.Controls.SetChildIndex(this.labelClientID, 0);
      this.Controls.SetChildIndex(this.txtClientID, 0);
      this.Controls.SetChildIndex(this.labelComment, 0);
      this.Controls.SetChildIndex(this.txtComment, 0);
      this.Controls.SetChildIndex(this.labelFullName, 0);
      this.Controls.SetChildIndex(this.txtFullName, 0);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public void Show(int clientREF)
    {
      GetAndShow(clientREF);
    }

    public void ShowAndEdit(int clientREF)
    {
      GetAndEdit(clientREF);
    }

    override protected void FillForm()
    {
      DdClientExt ddx = (DdClientExt)dd;
      txtClientID.Text = ddx.ClientID;
      txtComment.Text = ddx.Comment;
      txtFullName.Text = ddx.FullName;
    }

    override protected void ClearForm()
    {
      dd = new DdClientExt();
      FillForm();
    }

    override protected void SetBuffer()
    {
      DdClientExt ddx = (DdClientExt)dd;
      ddx.ClientID = txtClientID.Text;
      ddx.Comment = txtComment.Text;
      ddx.FullName = txtFullName.Text;
    }

    protected override bool DoAdd()
    {
      DdClientExt ddx = (DdClientExt)dd;
      bool ok = DataStore.AddClient(ref ddx, new RevisionInfo());
      dd = (ok) ? ddx : null;
      return ok;
    }

    protected override bool DoDelete()
    {
      return DataStore.DeleteClient((DdClientExt)dd, new RevisionInfo());
    }

    protected override object DoGetInfo(int id)
    {
      return DataStore.GetClientInfo(id);
    }

    protected override object DoGetInfo(string cliendID)
    {
      return DataStore.GetClientInfo(cliendID);
    }

    protected override bool DoSave()
    {
      DdClientExt ddx = (DdClientExt)dd;
      bool ok = DataStore.SaveClient(ref ddx, new RevisionInfo());
      dd = (ok) ? ddx : null;
      return ok;
    }
  }
}

#if false
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SD;
using ASL;

namespace SD.Project
{
  public partial class ClientForm : ChildForm
  {
    public ClientForm()
    {
      InitializeComponent();

      CreateFormFields();

    }

#if true
    private void CreateFormFields()
    {
      this.txtClientID = new System.Windows.Forms.TextBox();
      this.labelClientID = new System.Windows.Forms.Label();
      this.txtFullName = new System.Windows.Forms.TextBox();
      this.labelFullName = new System.Windows.Forms.Label();
      this.txtComment = new System.Windows.Forms.TextBox();
      this.labelComment = new System.Windows.Forms.Label();

      this.SuspendLayout();
      this.txtClientID.Location = new System.Drawing.Point(136, 52);
      this.txtClientID.Name = "txtClientID";
      this.txtClientID.TabIndex = 0;
      this.txtClientID.Size = new System.Drawing.Size(260, 22);

      this.labelClientID.AutoSize = true;
      this.labelClientID.Location = new System.Drawing.Point(17, 53);
      this.labelClientID.Name = "labelClientID";
      this.labelClientID.Size = new System.Drawing.Size(21, 17);
      this.labelClientID.TabStop = false;
      this.labelClientID.Text = "Client ID";

      this.txtFullName.Location = new System.Drawing.Point(136, 80);
      this.txtFullName.Name = "txtFullName";
      this.txtFullName.TabIndex = 1;
      this.txtFullName.Size = new System.Drawing.Size(260, 22);

      this.labelFullName.AutoSize = true;
      this.labelFullName.Location = new System.Drawing.Point(17, 81);
      this.labelFullName.Name = "labelFullName";
      this.labelFullName.Size = new System.Drawing.Size(21, 17);
      this.labelFullName.TabStop = false;
      this.labelFullName.Text = "Full Name";

      this.txtComment.Location = new System.Drawing.Point(136, 108);
      this.txtComment.Name = "txtComment";
      this.txtComment.TabIndex = 2;
      this.txtComment.Multiline = true;
      this.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txtComment.Size = new System.Drawing.Size(448, 138);

      this.labelComment.AutoSize = true;
      this.labelComment.Location = new System.Drawing.Point(17, 109);
      this.labelComment.Name = "labelComment";
      this.labelComment.Size = new System.Drawing.Size(21, 17);
      this.labelComment.TabStop = false;
      this.labelComment.Text = "Comment";


      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.txtClientID);
      this.Controls.Add(this.labelClientID);
      this.Controls.Add(this.txtFullName);
      this.Controls.Add(this.labelFullName);
      this.Controls.Add(this.txtComment);
      this.Controls.Add(this.labelComment);

      this.Name = "SDForm";

      this.Controls.SetChildIndex(this.labelClientID, 0);
      this.Controls.SetChildIndex(this.txtClientID, 0);
      this.Controls.SetChildIndex(this.labelFullName, 0);
      this.Controls.SetChildIndex(this.txtFullName, 0);
      this.Controls.SetChildIndex(this.labelComment, 0);
      this.Controls.SetChildIndex(this.txtComment, 0);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private System.Windows.Forms.TextBox txtClientID;
    private System.Windows.Forms.Label labelClientID;
    private System.Windows.Forms.TextBox txtFullName;
    private System.Windows.Forms.Label labelFullName;
    private System.Windows.Forms.TextBox txtComment;
    private System.Windows.Forms.Label labelComment;
#endif

    public void Show(int clientREF)
    {
      LoadBuffer(clientREF);
    }

    override protected void FillForm()
    {
      DdClientExt ddx = (DdClientExt)dd;
      txtClientID.Text = ddx.ClientID;
      txtFullName.Text = ddx.FullName;
      txtComment.Text = ddx.Comment;
    }

    override protected void ClearForm()
    {
      dd = new DdClientExt();
      FillForm();
    }

    override protected void SetBuffer()
    {
      DdClientExt ddx = (DdClientExt)dd;
      ddx.ClientID = txtClientID.Text;
      ddx.FullName = txtFullName.Text;
      ddx.Comment = txtComment.Text;
    }

    protected override bool DoAdd()
    {
      DdClientExt ddx = (DdClientExt)dd;
      bool ok = DataStore.AddClient(ref ddx, new RevisionInfo());
      dd = (ok) ? ddx : null;
      return ok;
    }

    protected override bool DoDelete()
    {
      return DataStore.DeleteClient((DdClientExt)dd, new RevisionInfo());
    }

    protected override object DoGetInfo(int id)
    {
      return DataStore.GetClientInfo(id);
    }

    protected override object DoGetInfo(string clientID)
    {
      return DataStore.GetClientInfo(clientID);
    }

    protected override bool DoSave()
    {
      DdClientExt ddx = (DdClientExt)dd;
      bool ok = DataStore.SaveClient(ref ddx, new RevisionInfo());
      dd = (ok) ? ddx : null;
      return ok;
    }
  }
}
#endif