// Decompiled with JetBrains decompiler
// Type: GumpStudio.GumpIDPropEditor
// Assembly: GumpStudioCore, Version=1.8.3024.24259, Culture=neutral, PublicKeyToken=null
// MVID: A77D32E5-7519-4865-AA26-DCCB34429732
// Assembly location: C:\GumpStudio_1_8_R3_quinted-02\GumpStudioCore.dll

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Security.Permissions;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Ultima;

namespace GumpStudio
{
  public class GumpIDPropEditor : UITypeEditor
  {
    protected IWindowsFormsEditorService edSvc;
    protected int ReturnValue;

    protected static Color Convert555ToARGB(short Col)
    {
      return Color.FromArgb(((int) (short) ((int) Col >> 10) & 31) * 8, ((int) (short) ((int) Col >> 5) & 31) * 8, ((int) Col & 31) * 8);
    }

    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
    {
      this.edSvc = (IWindowsFormsEditorService) provider.GetService(typeof (IWindowsFormsEditorService));
      if (this.edSvc != null)
      {
        GumpArtBrowser gumpArtBrowser = new GumpArtBrowser();
        gumpArtBrowser.GumpID = Conversions.ToInteger(value);
        if (this.edSvc.ShowDialog((Form) gumpArtBrowser) == DialogResult.OK)
        {
          Image gump = (Image) Gumps.GetGump(gumpArtBrowser.GumpID);
          if (gump != null)
          {
            gump.Dispose();
            this.ReturnValue = gumpArtBrowser.GumpID;
            gumpArtBrowser.Dispose();
            return (object) this.ReturnValue;
          }
          int num = (int) Interaction.MsgBox((object) "invalid GumpID", MsgBoxStyle.OkOnly, (object) null);
          return value;
        }
        gumpArtBrowser.Dispose();
      }
      return value;
    }

    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
    {
      return UITypeEditorEditStyle.Modal;
    }
  }
}
