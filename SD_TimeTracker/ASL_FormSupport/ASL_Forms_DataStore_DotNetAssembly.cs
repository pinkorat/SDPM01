using System;
using System.Reflection;

namespace ASL.Forms
{
  public partial class DataStore
  {
    static public string AssemblyTitle
    {
      get
      {
        object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
        if (attributes.Length > 0)
        {
          AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
          if (titleAttribute.Title != "")
          {
            return titleAttribute.Title;
          }
        }
        return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().CodeBase);
      }
    }

    static public string Release
    {
      get
      {
        Version v = Assembly.GetEntryAssembly().GetName().Version;
        return string.Format("{0}.{1}", v.Major, v.Minor);
      }
    }

    static public string AssemblyName
    {
      get
      {
        return Assembly.GetEntryAssembly().GetName().Name;
      }
    }

    static public string AssemblyVersion
    {
      get
      {
        return Assembly.GetEntryAssembly().GetName().Version.ToString();
      }
    }

    static public string AssemblyDescription
    {
      get
      {
        object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
        if (attributes.Length == 0)
        {
          return "";
        }
        return ((AssemblyDescriptionAttribute)attributes[0]).Description;
      }
    }

    static public string AssemblyProduct
    {
      get
      {
        object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
        if (attributes.Length == 0)
        {
          return "";
        }
        return ((AssemblyProductAttribute)attributes[0]).Product;
      }
    }

    static public string AssemblyCopyright
    {
      get
      {
        object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
        if (attributes.Length == 0)
        {
          return "";
        }
        return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
      }
    }

    static public string AssemblyCompany
    {
      get
      {
        object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
        if (attributes.Length == 0)
        {
          return "";
        }
        return ((AssemblyCompanyAttribute)attributes[0]).Company;
      }
    }

  }
}
