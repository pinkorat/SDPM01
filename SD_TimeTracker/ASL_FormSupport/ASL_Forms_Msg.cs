using System;
using System.Drawing;

namespace ASL.Forms
{
  public static class Msg
  {
    private static ASL.WinFormInterface.MessageWindow msg;

    static Msg()
    {
      msg = new ASL.WinFormInterface.MessageWindow(DataStore.ProductName, Color.Blue, false);
    }

    public static void ShowInfo(string format, params object[] args)
    {
      msg.ShowInfo(string.Format(format, args));
    }

    public static void ShowWarning(string format, params object[] args)
    {
      msg.ShowWarning(string.Format(format, args));
    }

    public static void ReferToTechSupport(Exception exc)
    {
      msg.ReferToTechSupport(exc, "INTERNAL ERROR");
      ActivityLog.AddLogEntry("RTTS", exc.ToString());
    }

    public static void ReferToTechSupport(string format, params object[] args)
    {
      msg.ReferToTechSupport(format, args);
      ActivityLog.AddLogEntry("RTTS", string.Format(format, args));
    }

    public static void ReferToTechSupport(Exception exc, string format, params object[] args)
    {
      msg.ReferToTechSupport(exc, format, args);
      ActivityLog.AddLogEntry("RTTS", string.Format(format, args) + "|" + exc.ToString());
    }

    public static bool AskYesNo(string message, bool defaultYes = false)
    {
      return msg.AskYesNo(message, defaultYes);
    }

    public static string AskText(string prompt = "", string message = "", string content = "")
    {
      try
      {
        return msg.InputText(prompt, message, content);
      }
      catch
      {
        return null;
      }
    }
  }

}
