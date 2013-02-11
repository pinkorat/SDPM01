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
// change number 1
namespace SD.Project
{
  public partial class PersonForm : ChildForm
  {
    public PersonForm()
    {
      InitializeComponent();

      CreateFormFields();

    }
    private System.Windows.Forms.TextBox txtPersonID;
    private System.Windows.Forms.Label labelPersonID;
    private System.Windows.Forms.TextBox txtFullName;
    private System.Windows.Forms.Label labelFullName;
    private System.Windows.Forms.TextBox txtCredentials;
    private System.Windows.Forms.Label labelCredentials;
    private System.Windows.Forms.TextBox txtTitle;
    private System.Windows.Forms.Label labelTitle;
    private System.Windows.Forms.TextBox txtComment;
    private System.Windows.Forms.Label labelComment;
    private System.Windows.Forms.TextBox txtInactive;
    private System.Windows.Forms.Label labelInactive;

    private void CreateFormFields()
    {
      this.txtPersonID = new System.Windows.Forms.TextBox();
      this.labelPersonID = new System.Windows.Forms.Label();
      this.txtFullName = new System.Windows.Forms.TextBox();
      this.labelFullName = new System.Windows.Forms.Label();
      this.txtCredentials = new System.Windows.Forms.TextBox();
      this.labelCredentials = new System.Windows.Forms.Label();
      this.txtTitle = new System.Windows.Forms.TextBox();
      this.labelTitle = new System.Windows.Forms.Label();
      this.txtComment = new System.Windows.Forms.TextBox();
      this.labelComment = new System.Windows.Forms.Label();
      this.txtInactive = new System.Windows.Forms.TextBox();
      this.labelInactive = new System.Windows.Forms.Label();

      this.SuspendLayout();
      int top = 52;
      int fieldYStep;
      this.txtPersonID.Tag = "PersonID";
      this.txtPersonID.Location = new System.Drawing.Point(126, top);
      this.txtPersonID.Name = "txtPersonID";
      this.txtPersonID.TabIndex = 0;
      this.txtPersonID.ReadOnly = true;
      this.txtPersonID.Size = new System.Drawing.Size(260, 22);
      this.txtPersonID.MaxLength = DdPerson.PersonID_L;
      fieldYStep = 24;

      this.labelPersonID.AutoSize = false;
      this.labelPersonID.Location = new System.Drawing.Point(17, top + 1);
      this.labelPersonID.Name = "labelPersonID";
      this.labelPersonID.Size = new System.Drawing.Size(100, 17);
      this.labelPersonID.TextAlign = ContentAlignment.MiddleRight;
      this.labelPersonID.TabStop = false;
      this.labelPersonID.Text = "Person ID";

      top += fieldYStep;
      this.txtFullName.Tag = "FullName";
      this.txtFullName.Location = new System.Drawing.Point(126, top);
      this.txtFullName.Name = "txtFullName";
      this.txtFullName.TabIndex = 1;
      this.txtFullName.ReadOnly = true;
      this.txtFullName.Size = new System.Drawing.Size(260, 22);
      this.txtFullName.MaxLength = DdPerson.FullName_L;
      fieldYStep = 24;

      this.labelFullName.AutoSize = false;
      this.labelFullName.Location = new System.Drawing.Point(17, top + 1);
      this.labelFullName.Name = "labelFullName";
      this.labelFullName.Size = new System.Drawing.Size(100, 17);
      this.labelFullName.TextAlign = ContentAlignment.MiddleRight;
      this.labelFullName.TabStop = false;
      this.labelFullName.Text = "Full Name";

      top += fieldYStep;
      this.txtCredentials.Tag = "Credentials";
      this.txtCredentials.Location = new System.Drawing.Point(126, top);
      this.txtCredentials.Name = "txtCredentials";
      this.txtCredentials.TabIndex = 2;
      this.txtCredentials.ReadOnly = true;
      this.txtCredentials.Size = new System.Drawing.Size(260, 22);
      this.txtCredentials.MaxLength = DdPerson.Credentials_L;
      fieldYStep = 24;

      this.labelCredentials.AutoSize = false;
      this.labelCredentials.Location = new System.Drawing.Point(17, top + 1);
      this.labelCredentials.Name = "labelCredentials";
      this.labelCredentials.Size = new System.Drawing.Size(100, 17);
      this.labelCredentials.TextAlign = ContentAlignment.MiddleRight;
      this.labelCredentials.TabStop = false;
      this.labelCredentials.Text = "Credentials";

      top += fieldYStep;
      this.txtTitle.Tag = "Title";
      this.txtTitle.Location = new System.Drawing.Point(126, top);
      this.txtTitle.Name = "txtTitle";
      this.txtTitle.TabIndex = 3;
      this.txtTitle.ReadOnly = true;
      this.txtTitle.Size = new System.Drawing.Size(260, 22);
      this.txtTitle.MaxLength = DdPerson.Title_L;
      fieldYStep = 24;

      this.labelTitle.AutoSize = false;
      this.labelTitle.Location = new System.Drawing.Point(17, top + 1);
      this.labelTitle.Name = "labelTitle";
      this.labelTitle.Size = new System.Drawing.Size(100, 17);
      this.labelTitle.TextAlign = ContentAlignment.MiddleRight;
      this.labelTitle.TabStop = false;
      this.labelTitle.Text = "Title";

      top += fieldYStep;
      this.txtComment.Tag = "Comment";
      this.txtComment.Location = new System.Drawing.Point(126, top);
      this.txtComment.Name = "txtComment";
      this.txtComment.TabIndex = 4;
      this.txtComment.ReadOnly = true;
      this.txtComment.Multiline = true;
      this.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txtComment.Size = new System.Drawing.Size(348, 138);
      this.txtComment.MaxLength = 0;
      fieldYStep = 140;

      this.labelComment.AutoSize = false;
      this.labelComment.Location = new System.Drawing.Point(17, top + 1);
      this.labelComment.Name = "labelComment";
      this.labelComment.Size = new System.Drawing.Size(100, 17);
      this.labelComment.TextAlign = ContentAlignment.MiddleRight;
      this.labelComment.TabStop = false;
      this.labelComment.Text = "Comment";

      top += fieldYStep;
      this.txtInactive.Tag = "Inactive";
      this.txtInactive.Location = new System.Drawing.Point(126, top);
      this.txtInactive.Name = "txtInactive";
      this.txtInactive.TabIndex = 5;
      this.txtInactive.ReadOnly = true;
      this.txtInactive.Size = new System.Drawing.Size(260, 22);
      fieldYStep = 24;

      this.labelInactive.AutoSize = false;
      this.labelInactive.Location = new System.Drawing.Point(17, top + 1);
      this.labelInactive.Name = "labelInactive";
      this.labelInactive.Size = new System.Drawing.Size(100, 17);
      this.labelInactive.TextAlign = ContentAlignment.MiddleRight;
      this.labelInactive.TabStop = false;
      this.labelInactive.Text = "Inactive";

      top += fieldYStep;

      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.txtPersonID);
      this.Controls.Add(this.labelPersonID);
      this.Controls.Add(this.txtFullName);
      this.Controls.Add(this.labelFullName);
      this.Controls.Add(this.txtCredentials);
      this.Controls.Add(this.labelCredentials);
      this.Controls.Add(this.txtTitle);
      this.Controls.Add(this.labelTitle);
      this.Controls.Add(this.txtComment);
      this.Controls.Add(this.labelComment);
      this.Controls.Add(this.txtInactive);
      this.Controls.Add(this.labelInactive);

      this.Name = "PersonForm";

      this.Controls.SetChildIndex(this.labelPersonID, 0);
      this.Controls.SetChildIndex(this.txtPersonID, 0);
      this.Controls.SetChildIndex(this.labelFullName, 0);
      this.Controls.SetChildIndex(this.txtFullName, 0);
      this.Controls.SetChildIndex(this.labelCredentials, 0);
      this.Controls.SetChildIndex(this.txtCredentials, 0);
      this.Controls.SetChildIndex(this.labelTitle, 0);
      this.Controls.SetChildIndex(this.txtTitle, 0);
      this.Controls.SetChildIndex(this.labelComment, 0);
      this.Controls.SetChildIndex(this.txtComment, 0);
      this.Controls.SetChildIndex(this.labelInactive, 0);
      this.Controls.SetChildIndex(this.txtInactive, 0);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public void Show(int personREF)
    {
      GetAndShow(personREF);
    }

    public void ShowAndEdit(int personREF)
    {
      GetAndEdit(personREF);
    }

    override protected void FillForm()
    {
      DdPersonExt ddx = (DdPersonExt)dd;
      txtPersonID.Text = ddx.PersonID.ToString();
      txtFullName.Text = ddx.FullName.ToString();
      txtCredentials.Text = ddx.Credentials.ToString();
      txtTitle.Text = ddx.Title.ToString();
      txtComment.Text = ddx.Comment.ToString();
      txtInactive.Text = ddx.Inactive.ToString();
    }

    override protected void ClearForm()
    {
      dd = new DdPersonExt();
      FillForm();
    }

    override protected void SetBuffer()
    {
      DdPersonExt ddx = (DdPersonExt)dd;
      ddx.PersonID = txtPersonID.Text;
      ddx.FullName = txtFullName.Text;
      ddx.Credentials = txtCredentials.Text;
      ddx.Title = txtTitle.Text;
      ddx.Comment = txtComment.Text;
      ddx.Inactive = bool.Parse(txtInactive.Text);
    }

    protected override bool DoAdd()
    {
      DdPersonExt ddx = (DdPersonExt)dd;
      bool ok = DataStore.AddPerson(ref ddx, new RevisionInfo());
      dd = (ok) ? ddx : null;
      return ok;
    }

    protected override bool DoDelete()
    {
      return DataStore.DeletePerson((DdPersonExt)dd, new RevisionInfo());
    }

    protected override object DoGetInfo(int id)
    {
      return DataStore.GetPersonInfo(id);
    }

    protected override object DoGetInfo(String personID)
    {
      return DataStore.GetPersonInfo(1);
    }

    protected override bool DoSave()
    {
      DdPersonExt ddx = (DdPersonExt)dd;
      bool ok = DataStore.SavePerson(ref ddx, new RevisionInfo());
      dd = (ok) ? ddx : null;
      return ok;
    }
  }
}
// Generated: Wednesday 2013.01.30-20.02.24
// Generated by: ASLGEN_CsCodeGen 1.0.0.0
// Arguments: /macro=TableForm /table=Person /K=PersonID
// Current directory: C:\__Q1\KGRS042\Main\ASLGEN\ASLGEN_CsCodeGen\bin\x86\Debug
