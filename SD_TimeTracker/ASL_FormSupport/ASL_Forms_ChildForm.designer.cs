namespace ASL.Forms
{
  partial class ChildForm
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.panControl = new System.Windows.Forms.Panel();
      this.label4 = new System.Windows.Forms.Label();
      this.cmdCancel = new System.Windows.Forms.Button();
      this.cmdDelete = new System.Windows.Forms.Button();
      this.cmdSave = new System.Windows.Forms.Button();
      this.cmdAddNew = new System.Windows.Forms.Button();
      this.panControl.SuspendLayout();
      this.SuspendLayout();
      // 
      // panControl
      // 
      this.panControl.Controls.Add(this.label4);
      this.panControl.Controls.Add(this.cmdCancel);
      this.panControl.Controls.Add(this.cmdDelete);
      this.panControl.Controls.Add(this.cmdSave);
      this.panControl.Controls.Add(this.cmdAddNew);
      this.panControl.Dock = System.Windows.Forms.DockStyle.Top;
      this.panControl.Location = new System.Drawing.Point(0, 0);
      this.panControl.Name = "panControl";
      this.panControl.Size = new System.Drawing.Size(644, 28);
      this.panControl.TabIndex = 9;
      // 
      // label4
      // 
      this.label4.BackColor = System.Drawing.Color.White;
      this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.ForeColor = System.Drawing.Color.SteelBlue;
      this.label4.Location = new System.Drawing.Point(304, 0);
      this.label4.Margin = new System.Windows.Forms.Padding(3);
      this.label4.Name = "label4";
      this.label4.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
      this.label4.Size = new System.Drawing.Size(340, 28);
      this.label4.TabIndex = 7;
      this.label4.Text = "Client";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // cmdCancel
      // 
      this.cmdCancel.AutoSize = true;
      this.cmdCancel.BackColor = System.Drawing.Color.SteelBlue;
      this.cmdCancel.Dock = System.Windows.Forms.DockStyle.Left;
      this.cmdCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSlateBlue;
      this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cmdCancel.ForeColor = System.Drawing.Color.White;
      this.cmdCancel.Location = new System.Drawing.Point(228, 0);
      this.cmdCancel.Name = "cmdCancel";
      this.cmdCancel.Size = new System.Drawing.Size(76, 28);
      this.cmdCancel.TabIndex = 6;
      this.cmdCancel.Text = "Cancel";
      this.cmdCancel.UseVisualStyleBackColor = false;
      // 
      // cmdDelete
      // 
      this.cmdDelete.AutoSize = true;
      this.cmdDelete.BackColor = System.Drawing.Color.SteelBlue;
      this.cmdDelete.Dock = System.Windows.Forms.DockStyle.Left;
      this.cmdDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSlateBlue;
      this.cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cmdDelete.ForeColor = System.Drawing.Color.White;
      this.cmdDelete.Location = new System.Drawing.Point(152, 0);
      this.cmdDelete.Name = "cmdDelete";
      this.cmdDelete.Size = new System.Drawing.Size(76, 28);
      this.cmdDelete.TabIndex = 5;
      this.cmdDelete.Text = "Delete";
      this.cmdDelete.UseVisualStyleBackColor = false;
      // 
      // cmdSave
      // 
      this.cmdSave.AutoSize = true;
      this.cmdSave.BackColor = System.Drawing.Color.SteelBlue;
      this.cmdSave.Dock = System.Windows.Forms.DockStyle.Left;
      this.cmdSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSlateBlue;
      this.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cmdSave.ForeColor = System.Drawing.Color.White;
      this.cmdSave.Location = new System.Drawing.Point(76, 0);
      this.cmdSave.Name = "cmdSave";
      this.cmdSave.Size = new System.Drawing.Size(76, 28);
      this.cmdSave.TabIndex = 4;
      this.cmdSave.Text = "Save";
      this.cmdSave.UseVisualStyleBackColor = false;
      // 
      // cmdAddNew
      // 
      this.cmdAddNew.AutoSize = true;
      this.cmdAddNew.BackColor = System.Drawing.Color.SteelBlue;
      this.cmdAddNew.Dock = System.Windows.Forms.DockStyle.Left;
      this.cmdAddNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSlateBlue;
      this.cmdAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cmdAddNew.ForeColor = System.Drawing.Color.White;
      this.cmdAddNew.Location = new System.Drawing.Point(0, 0);
      this.cmdAddNew.Name = "cmdAddNew";
      this.cmdAddNew.Size = new System.Drawing.Size(76, 28);
      this.cmdAddNew.TabIndex = 3;
      this.cmdAddNew.Text = "Add New";
      this.cmdAddNew.UseVisualStyleBackColor = false;
      // 
      // ChildForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.SlateGray;
      this.Controls.Add(this.panControl);
      this.ForeColor = System.Drawing.Color.White;
      this.Name = "ChildForm";
      this.Size = new System.Drawing.Size(644, 636);
      this.panControl.ResumeLayout(false);
      this.panControl.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panControl;
    private System.Windows.Forms.Label label4;
    public System.Windows.Forms.Button cmdCancel;
    public System.Windows.Forms.Button cmdDelete;
    public System.Windows.Forms.Button cmdSave;
    public System.Windows.Forms.Button cmdAddNew;
  }
}
