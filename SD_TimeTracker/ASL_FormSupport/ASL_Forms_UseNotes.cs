using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace ASL.Forms
{
  public class UseNotes
  {
    public const string UseNotesFileName = "FSA_Explorer.usenotes.xml";
    private string folderPath;

    public SortedList<string, UseNote> Notes;

    public UseNotes()
    {
      folderPath =
        Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
      Notes = new SortedList<string, UseNote>();
    }

    public void LoadFromXml()
    {
      //string folderPath = Environment.CurrentDirectory;
      string filePath = Path.Combine(folderPath, UseNotesFileName);

      if (!File.Exists(filePath)) SaveAsXml();
      
      XmlDocument xdoc = new XmlDocument();
      xdoc.Load(filePath);
      XmlNodeList xnotes = xdoc.DocumentElement.SelectNodes("Note");
      Notes = new SortedList<string, UseNote>();
      foreach (XmlElement xnote in xnotes)
      {
        string key = xnote.GetAttribute("key");
        string content = xnote.InnerText;
        Notes.Add(key, new UseNote(key, content));
      }
    }

    public string this[string key]
    {
      get
      {
        if (Notes.ContainsKey(key))
          return Notes[key].Content;
        else
          return string.Empty;

      }
      set
      {
        Update(key, value);
      }
    }

    public void Update(string key, string content)
    {
      if (!Notes.ContainsKey(key))
        Notes.Add(key, new UseNote(key, content));
      else
        Notes[key].Content = content;
    }

    public void SaveAsXml()
    {
      XmlDocument xdoc = new XmlDocument();
      XmlElement xroot = xdoc.CreateElement("UseNotes");
      xroot.SetAttribute("Revised", DateTime.Now.ToString());
      xdoc.AppendChild(xroot);

      foreach (UseNote note in Notes.Values)
      {
        XmlElement xnote = xdoc.CreateElement("Note");
        xnote.SetAttribute("key", note.Key);
        XmlCDataSection xcdata = xdoc.CreateCDataSection(note.Content);
        xnote.AppendChild(xcdata);
        xroot.AppendChild(xnote);
      }

      string filePath = Path.Combine(folderPath, UseNotesFileName);
      xdoc.Save(filePath);
    }
  }

  public class UseNote
  {
    public string Key;
    public string Content;

    public UseNote()
    {
    }

    public UseNote(string key, string content)
      : this()
    {
      Key = key;
      Content = content;
    }
  }
}
