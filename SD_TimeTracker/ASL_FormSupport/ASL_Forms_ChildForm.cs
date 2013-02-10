using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ASL.Forms;

namespace ASL.Forms
{
  public partial class ChildForm : UserControl
  {
    protected bool editMode = false;

    public ChildForm()
    {
      InitializeComponent();

      this.Load += SD_ChildForm_Load;
      this.cmdAddNew.Click += cmdAddNew_Click;
      this.cmdCancel.Click += cmdCancel_Click;
      this.cmdDelete.Click += cmdDelete_Click;
      this.cmdSave.Click += cmdSave_Click;
    }

    void SD_ChildForm_Load(object sender, EventArgs e)
    {
      editMode = false;
      //cmdAddNew.Enabled = cmdDelete.Enabled = cmdSave.Enabled = editMode;
      cmdCancel.Text = (editMode) ? "Cancel" : "Edit";
    }


    virtual protected bool DoAdd() { return false; }
    virtual protected object DoGetInfo(string clientID) { return null; }
    virtual protected object DoGetInfo(int id) { return null; }
    virtual protected bool DoDelete() { return false; }
    virtual protected bool DoSave() { return false; }
    virtual protected void SetBuffer() { }
    virtual protected void FillForm() { }
    virtual protected void ClearForm() { }

    protected object dd;

    protected void GetAndShow(int id)
    {
      editMode = false;
      LoadBuffer(id);
    }

    protected void GetAndEdit(int id)
    {
      editMode = true;
      LoadBuffer(id);

      this.SelectNextControl(panControl, forward: true, 
        tabStopOnly: true, nested: false, wrap: false);
    }

    private void LoadBuffer(int id)
    {
      dd = DoGetInfo(id);
      DdBase ddb = (ASL.Forms.DdBase)dd;
      if (dd == null || ddb.Id == DataStore.NullId)
      {
        cmdAddNew.Enabled = editMode;
        cmdSave.Enabled = false;
        cmdDelete.Enabled = false;
        ClearForm();
      }
      else
      {
        cmdAddNew.Enabled = editMode;
        cmdSave.Enabled = editMode;
        cmdSave.Text = "Save";
        cmdDelete.Enabled = editMode;
        FillForm();
      }
      foreach (Control ctl in this.Controls)
      {
        if (ctl is TextBox)
        {
          ((TextBox)ctl).ReadOnly = !editMode;
        }
      }

      cmdCancel.Text = (editMode) ? "Cancel" : "Edit";
    }

    void cmdSave_Click(object sender, EventArgs e)
    {
      try
      {
        DdBase ddb = (DdBase)dd;
        if (ddb.Id == 0)
        {
          ddb.Clear();
          SetBuffer();
          if (DoAdd())
          {
            cmdAddNew.Enabled = false;
            cmdSave.Enabled = editMode;
            cmdSave.Text = "Save";
            cmdDelete.Enabled = editMode;
          }
          else
          {
            Msg.ShowWarning("Could not add");
          }
        }
        else
        {
          if (DoGetInfo(ddb.Id) != null)
          {
            SetBuffer();
            if (DoSave())
            {
              cmdAddNew.Enabled = editMode;
              cmdSave.Enabled = editMode;
              cmdSave.Text = "Save";
              cmdDelete.Enabled = editMode;
              FillForm();
            }
            else
            {
              ddb.Id = 0;
              Msg.ShowWarning("Could not save");
            }
          }
          else
          {
            Msg.ShowWarning("Could not find");
          }
        }
      }
      catch (Exception exc)
      {
        Msg.ReferToTechSupport(exc);
      }
    }

    void cmdDelete_Click(object sender, EventArgs e)
    {
      try
      {
        DdBase ddb = (DdBase)dd;
        if (DoDelete())
        {
          cmdSave.Enabled = editMode;
          cmdSave.Text = "Add";
          cmdDelete.Enabled = false;
          ddb.Clear();
        }
        else
          Msg.ShowWarning("Could not delete");
      }
      catch (Exception exc)
      {
        Msg.ReferToTechSupport(exc);
      }
    }

    void cmdCancel_Click(object sender, EventArgs e)
    {
      try
      {
        DdBase ddb = (DdBase)dd;
        editMode = !editMode;
        LoadBuffer(ddb.Id);
      }
      catch (Exception exc)
      {
        Msg.ReferToTechSupport(exc);
      }
    }

    void cmdAddNew_Click(object sender, EventArgs e)
    {
      try
      {
        ClearForm();
        cmdAddNew.Enabled = false;
        cmdDelete.Enabled = false;
        cmdSave.Enabled = editMode;
        cmdSave.Text = "Add";
      }
      catch (Exception exc)
      {
        Msg.ReferToTechSupport(exc);
      }
    }

  }
}
