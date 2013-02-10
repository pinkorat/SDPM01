using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SD.Project
{
  public class TnDummy : TreeNode
  {
    public TnDummy()
    {
      Text = "?";
    }
  }

  public class TnRoot : TreeNode
  {
    public TnRoot()
    {
      Text = "Manager";
    }
  }

  public class TnClientFolder : TreeNode
  {
    public TnClientFolder()
    {
      Text = "Clients";
    }
  }

  public class TnClient : TreeNode
  {
    static private Font font = new Font(FontFamily.GenericSansSerif, 9);

    public DdClientExt Client { get; set; }

    public TnClient(DdClientExt client)
    {
      Text = client.FullName.PadRight(30);
      Client = client;
      this.NodeFont = font;
      this.ForeColor = Color.Blue;
    }
  }

  public class TnProjectFolder : TreeNode
  {
    public TnProjectFolder()
    {
      Text = "Projects";
    }
  }
  public class TnProject : TreeNode
  {
    public DdProjectExt Project { get; set; }

    public TnProject(DdProjectExt project)
    {
      Text = project.Title;
      Project = project;
    }
  }

  public class TnTaskHeading : TreeNode
  {
    public DdTaskHeadingExt TaskHeading { get; set; }

    public TnTaskHeading(DdTaskHeadingExt taskHeading)
    {
      Text = taskHeading.Title;
      TaskHeading = taskHeading;
    }
  }

  public class TnTask : TreeNode
  {
    public DdTaskExt Task { get; set; }

    public TnTask(DdTaskExt task)
    {
      Text = task.Title;
      Task = task;
    }
  }

  public class TnStep : TreeNode
  {
    public DdStepExt Step { get; set; }

    public TnStep(DdStepExt step)
    {
      Text = step.Title;
      Step = step;
    }
  }
}
