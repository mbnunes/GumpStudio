// Decompiled with JetBrains decompiler
// Type: GumpStudio.ItemIDPropEditor
// Assembly: GumpStudioCore, Version=1.8.3024.24259, Culture=neutral, PublicKeyToken=null
// MVID: A77D32E5-7519-4865-AA26-DCCB34429732
// Assembly location: C:\GumpStudio_1_8_R3_quinted-02\GumpStudioCore.dll

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Security.Permissions;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Ultima;

namespace GumpStudio
{
  public class ItemIDPropEditor : UITypeEditor
  {
    protected IWindowsFormsEditorService edSvc;
    protected int ReturnValue;

    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
    {
      this.edSvc = (IWindowsFormsEditorService) provider.GetService(typeof (IWindowsFormsEditorService));
      if (this.edSvc != null)
      {
        NewStaticArtBrowser staticArtBrowser = new NewStaticArtBrowser();
        staticArtBrowser.ItemID = Conversions.ToInteger(value);
        if (this.edSvc.ShowDialog((Form) staticArtBrowser) == DialogResult.OK)
        {
          if (Art.GetStatic(staticArtBrowser.ItemID) != null)
          {
            this.ReturnValue = staticArtBrowser.ItemID;
            staticArtBrowser.Dispose();
            return (object) this.ReturnValue;
          }
          int num = (int) Interaction.MsgBox((object) "invalid ItemID", MsgBoxStyle.OkOnly, (object) null);
        }
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
