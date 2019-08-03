// Decompiled with JetBrains decompiler
// Type: GumpStudio.ClilocPropEditor
// Assembly: GumpStudioCore, Version=1.8.3024.24259, Culture=neutral, PublicKeyToken=null
// MVID: A77D32E5-7519-4865-AA26-DCCB34429732
// Assembly location: C:\GumpStudio_1_8_R3_quinted-02\GumpStudioCore.dll

using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Security.Permissions;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace GumpStudio
{
  public class ClilocPropEditor : UITypeEditor
  {
    protected IWindowsFormsEditorService edSvc;
    protected int ReturnValue;

    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
    {
      this.edSvc = (IWindowsFormsEditorService) provider.GetService(typeof (IWindowsFormsEditorService));
      if (this.edSvc == null)
        return value;
      ClilocBrowser clilocBrowser = new ClilocBrowser();
      if (this.edSvc.ShowDialog(clilocBrowser) == DialogResult.OK)
        return clilocBrowser.ClilocID;
      return value;
    }

    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
    {
      return UITypeEditorEditStyle.Modal;
    }
  }
}
