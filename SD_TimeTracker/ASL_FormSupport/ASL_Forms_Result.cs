using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Linq;
using System.Text;

namespace ASL.Forms
{
  [Serializable]
  public class Result
  {
    static long _SerialNumber = 0;
    public long SerialNumber;
    public bool HasError = false;
    public int ErrorCode = 0;
    public string ErrorMessage = string.Empty;

    static Result()
    {
      {
        Success = new Result();
        Success.HasError = false;
        Success.ErrorCode = 0;
        Success.ErrorMessage = "Success";
      }
      {
        InvalidEntry = new Result();
        InvalidEntry.HasError = true;
        InvalidEntry.ErrorCode = -3;
        InvalidEntry.ErrorMessage = "Invalid entry";
      }
      {
        NoAction = new Result();
        NoAction.HasError = false;
        NoAction.ErrorCode = 2;
        NoAction.ErrorMessage = "No action taken";
      }
    }

    static public readonly Result Success;
    static public readonly Result InvalidEntry;
    static public readonly Result NoAction;

    public Result()
    {
      SerialNumber = ++_SerialNumber;
    }

    public Result(Exception exc)
    {
      HasError = true;
      ErrorCode = -1;
      ErrorMessage = exc.Message;
    }

    public Result(string errorMessage)
    {
      HasError = true;
      ErrorCode = -2;
      ErrorMessage = errorMessage;
    }

  }


}
