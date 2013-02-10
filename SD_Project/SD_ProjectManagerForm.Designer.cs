namespace SD.Project
{
  partial class ProjectMangerForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectMangerForm));
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
      this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.tsProject = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
      this.tsProjectFilter = new System.Windows.Forms.ToolStripComboBox();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.tsStaff = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.tsTime = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
      this.tsDocuments = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.tsSchedule = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
      this.tsBilling = new System.Windows.Forms.ToolStripButton();
      this.panel1 = new System.Windows.Forms.Panel();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.toc = new System.Windows.Forms.TreeView();
      this.clientFormFrame = new System.Windows.Forms.Panel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.kmMappings = new System.Windows.Forms.ToolStripMenuItem();
      this.kmEdit = new System.Windows.Forms.ToolStripMenuItem();
      this.kmEdit2 = new System.Windows.Forms.ToolStripMenuItem();
      this.kmContext = new System.Windows.Forms.ToolStripMenuItem();
      this.menuStrip1.SuspendLayout();
      this.toolStrip1.SuspendLayout();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.kmMappings});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(1193, 28);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // menuFile
      // 
      this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExit});
      this.menuFile.Name = "menuFile";
      this.menuFile.Size = new System.Drawing.Size(44, 24);
      this.menuFile.Text = "&File";
      // 
      // menuExit
      // 
      this.menuExit.Name = "menuExit";
      this.menuExit.Size = new System.Drawing.Size(102, 24);
      this.menuExit.Text = "E&xit";
      // 
      // statusStrip1
      // 
      this.statusStrip1.Location = new System.Drawing.Point(0, 656);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(1193, 22);
      this.statusStrip1.TabIndex = 1;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // toolStrip1
      // 
      this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsProject,
            this.toolStripSeparator4,
            this.toolStripLabel1,
            this.tsProjectFilter,
            this.toolStripSeparator3,
            this.tsStaff,
            this.toolStripSeparator2,
            this.tsTime,
            this.toolStripSeparator5,
            this.tsDocuments,
            this.toolStripSeparator1,
            this.tsSchedule,
            this.toolStripSeparator6,
            this.tsBilling});
      this.toolStrip1.Location = new System.Drawing.Point(0, 28);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(1193, 28);
      this.toolStrip1.TabIndex = 3;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // tsProject
      // 
      this.tsProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.tsProject.Image = ((System.Drawing.Image)(resources.GetObject("tsProject.Image")));
      this.tsProject.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsProject.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
      this.tsProject.Name = "tsProject";
      this.tsProject.Size = new System.Drawing.Size(123, 25);
      this.tsProject.Text = "Clients / Projects";
      // 
      // toolStripSeparator4
      // 
      this.toolStripSeparator4.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new System.Drawing.Size(6, 28);
      // 
      // toolStripLabel1
      // 
      this.toolStripLabel1.Name = "toolStripLabel1";
      this.toolStripLabel1.Size = new System.Drawing.Size(42, 25);
      this.toolStripLabel1.Text = "Filter";
      // 
      // tsProjectFilter
      // 
      this.tsProjectFilter.AutoSize = false;
      this.tsProjectFilter.Items.AddRange(new object[] {
            "Project 1",
            "Project 2",
            "Project 3"});
      this.tsProjectFilter.Name = "tsProjectFilter";
      this.tsProjectFilter.Size = new System.Drawing.Size(200, 28);
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(6, 28);
      // 
      // tsStaff
      // 
      this.tsStaff.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.tsStaff.Image = ((System.Drawing.Image)(resources.GetObject("tsStaff.Image")));
      this.tsStaff.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsStaff.Name = "tsStaff";
      this.tsStaff.Size = new System.Drawing.Size(44, 25);
      this.tsStaff.Text = "Staff";
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
      // 
      // tsTime
      // 
      this.tsTime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.tsTime.Image = ((System.Drawing.Image)(resources.GetObject("tsTime.Image")));
      this.tsTime.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsTime.Name = "tsTime";
      this.tsTime.Size = new System.Drawing.Size(116, 25);
      this.tsTime.Text = "Time Reporting";
      // 
      // toolStripSeparator5
      // 
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      this.toolStripSeparator5.Size = new System.Drawing.Size(6, 28);
      // 
      // tsDocuments
      // 
      this.tsDocuments.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.tsDocuments.Image = ((System.Drawing.Image)(resources.GetObject("tsDocuments.Image")));
      this.tsDocuments.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsDocuments.Name = "tsDocuments";
      this.tsDocuments.Size = new System.Drawing.Size(88, 25);
      this.tsDocuments.Text = "Documents";
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
      // 
      // tsSchedule
      // 
      this.tsSchedule.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.tsSchedule.Image = ((System.Drawing.Image)(resources.GetObject("tsSchedule.Image")));
      this.tsSchedule.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsSchedule.Name = "tsSchedule";
      this.tsSchedule.Size = new System.Drawing.Size(73, 25);
      this.tsSchedule.Text = "Schedule";
      // 
      // toolStripSeparator6
      // 
      this.toolStripSeparator6.Name = "toolStripSeparator6";
      this.toolStripSeparator6.Size = new System.Drawing.Size(6, 28);
      // 
      // tsBilling
      // 
      this.tsBilling.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.tsBilling.Image = ((System.Drawing.Image)(resources.GetObject("tsBilling.Image")));
      this.tsBilling.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsBilling.Name = "tsBilling";
      this.tsBilling.Size = new System.Drawing.Size(55, 25);
      this.tsBilling.Text = "Billing";
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.splitContainer1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(0, 56);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(1193, 600);
      this.panel1.TabIndex = 4;
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.toc);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.panel2);
      this.splitContainer1.Panel2.Controls.Add(this.clientFormFrame);
      this.splitContainer1.Size = new System.Drawing.Size(1193, 600);
      this.splitContainer1.SplitterDistance = 300;
      this.splitContainer1.TabIndex = 0;
      // 
      // toc
      // 
      this.toc.BackColor = System.Drawing.Color.Gainsboro;
      this.toc.Dock = System.Windows.Forms.DockStyle.Fill;
      this.toc.Location = new System.Drawing.Point(0, 0);
      this.toc.Name = "toc";
      this.toc.Size = new System.Drawing.Size(300, 600);
      this.toc.TabIndex = 0;
      // 
      // clientFormFrame
      // 
      this.clientFormFrame.BackColor = System.Drawing.Color.SlateGray;
      this.clientFormFrame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.clientFormFrame.Dock = System.Windows.Forms.DockStyle.Left;
      this.clientFormFrame.ForeColor = System.Drawing.Color.Gold;
      this.clientFormFrame.Location = new System.Drawing.Point(0, 0);
      this.clientFormFrame.MaximumSize = new System.Drawing.Size(500, 2000);
      this.clientFormFrame.MinimumSize = new System.Drawing.Size(500, 600);
      this.clientFormFrame.Name = "clientFormFrame";
      this.clientFormFrame.Size = new System.Drawing.Size(500, 600);
      this.clientFormFrame.TabIndex = 4;
      // 
      // panel2
      // 
      this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel2.Location = new System.Drawing.Point(500, 0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(389, 600);
      this.panel2.TabIndex = 5;
      // 
      // kmMappings
      // 
      this.kmMappings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kmEdit,
            this.kmEdit2,
            this.kmContext});
      this.kmMappings.Name = "kmMappings";
      this.kmMappings.Size = new System.Drawing.Size(111, 24);
      this.kmMappings.Text = "KeyMappings";
      // 
      // kmEdit
      // 
      this.kmEdit.Name = "kmEdit";
      this.kmEdit.Size = new System.Drawing.Size(152, 24);
      this.kmEdit.Text = "Edit";
      // 
      // kmEdit2
      // 
      this.kmEdit2.Name = "kmEdit2";
      this.kmEdit2.Size = new System.Drawing.Size(152, 24);
      this.kmEdit2.Text = "Edit2";
      // 
      // kmContext
      // 
      this.kmContext.Name = "kmContext";
      this.kmContext.Size = new System.Drawing.Size(152, 24);
      this.kmContext.Text = "Context";
      // 
      // ProjectMangerForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1193, 678);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.toolStrip1);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "ProjectMangerForm";
      this.Text = "Project Manager";
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripComboBox tsProjectFilter;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.ToolStripMenuItem menuFile;
    private System.Windows.Forms.ToolStripMenuItem menuExit;
    private System.Windows.Forms.ToolStripButton tsStaff;
    private System.Windows.Forms.ToolStripButton tsProject;
    private System.Windows.Forms.ToolStripButton tsTime;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.TreeView toc;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    private System.Windows.Forms.ToolStripButton tsDocuments;
    private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    private System.Windows.Forms.ToolStripButton tsSchedule;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    private System.Windows.Forms.ToolStripButton tsBilling;
    private System.Windows.Forms.Panel clientFormFrame;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.ToolStripMenuItem kmMappings;
    private System.Windows.Forms.ToolStripMenuItem kmEdit;
    private System.Windows.Forms.ToolStripMenuItem kmEdit2;
    private System.Windows.Forms.ToolStripMenuItem kmContext;
  }
}

