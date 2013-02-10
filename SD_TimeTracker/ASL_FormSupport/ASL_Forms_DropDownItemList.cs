using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ASL;
using ASL.SQL;

namespace ASL.Forms
{
  public class DropDownItemList : List<DropDownItem>
  {
    public string ListID { get; private set; }

    public DropDownItemList() : base() { }

    public DropDownItemList(int count) : base(count) { }

    public DropDownItemList(SqlConnection sqx, string sql)
      : base()
    {
      try
      {
        using (SqlCommand sqc = new SqlCommand(sql, sqx))
        using (SqlDataAdapter da = new SqlDataAdapter(sqc))
        {
          DataTable dt = new DataTable();
          da.Fill(dt);
          foreach (DataRow dr in dt.Rows)
          {
            DropDownItem ddi = new DropDownItem(
              (int)dr[0], DataStore.NotDbNull(dr[1]), DataStore.NotDbNull(dr[2]));
            this.Add(ddi);
          }
        }
      }
      catch (Exception exc)
      {
        this.Add(new DropDownItem(1, "ERROR", "ERROR: " + exc.Message));
      }
    }

    public DropDownItemList(string listID)
      : base()
    {
      try
      {
        ListID = listID;
        DaPickList da = DataStore.OpenPickList();
        DnPickList dn = da.FillByListID(listID);
        foreach (DdPickList dd in dn)
          this.Add(new DropDownItem(dd.Id, dd.TextValue, dd.TextValue));
      }
      catch (Exception exc)
      {
        this.Add(new DropDownItem(1, "ERROR", "ERROR: " + exc.Message));
      }
    }

    public DropDownItem AddToPickList(string textValue)
    {
      try
      {
        string keyValue = textValue.Replace("'", "''");
        DaPickList da = DataStore.OpenPickList();
        if (!da.GetByPK(ListID, keyValue))
        {
          da.Clear();
          da.ListID = ListID;
          da.TextValue = textValue;
          if (da.Insert())
          {
            this.Add(new DropDownItem(da.Id, da.TextValue, da.TextValue));
          }
        }
        return GetItem(da.Id);
      }
      catch 
      {
        return null;
      }
    }

    static public void DeleteFromPickList(string listID, DropDownItem ddi)
    {
      DaPickList da = DataStore.OpenPickList();
      da.DeleteByPK(listID, ddi.Code);
    }

    public new DropDownItem[] ToArray() { return this.ToArray<DropDownItem>(); }

    public DropDownItem Add(int id, string code, string description)
    {
      DropDownItem ddi = new DropDownItem(id, code, description);
      this.Add(ddi);
      return ddi;
    }

    public DropDownItem Add(string description)
    {
      DropDownItem ddi = new DropDownItem(this.Count + 100, description, description);
      this.Add(ddi);
      return ddi;
    }

    public string GetDescription(int id)
    {
      foreach (DropDownItem ddi in this)
        if (ddi.Id == id) return ddi.ToString();
      //if (ddi.Id == id) return ddi.Description;
      return string.Empty;
    }

    public DropDownItem GetItem(int id)
    {
      foreach (DropDownItem ddi in this)
        if (ddi.Id == id) return ddi;
      return null;
    }

    public string GetCode(int id)
    {
      foreach (DropDownItem ddi in this)
        if (ddi.Id == id) return ddi.Code;
      return string.Empty;
    }
  }

  public class DropDownItem
  {
    public int Id { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public int ParentREF { get; set; }

    public DropDownItem()
    {
      Id = 1;
      Code = string.Empty;
      Description = string.Empty;
    }

    public DropDownItem(int id, string code, string description, int parentREF)
    {
      Id = id;
      Code = code;
      Description = description;
      ParentREF = parentREF;
    }

    public DropDownItem(int id, string code, string description)
    {
      Id = id;
      Code = code;
      Description = description;
      ParentREF = 0;
    }

    public DropDownItem(string description)
    {
      Id = 1;
      Code = Description = description;
    }

    public override string ToString()
    {
      if ((Code == string.Empty) && (Description == string.Empty)) return " ";
      if (Description == string.Empty || Description == Code) return Code;
      if (Code == string.Empty) return Description;
      return (Code + " - " + Description);
    }
  }
}
