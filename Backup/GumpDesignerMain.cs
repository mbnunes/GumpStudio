// Decompiled with JetBrains decompiler
// Type: GumpStudio.GumpDesignerMain
// Assembly: GumpStudioCore, Version=1.8.3024.24259, Culture=neutral, PublicKeyToken=null
// MVID: A77D32E5-7519-4865-AA26-DCCB34429732
// Assembly location: C:\GumpStudio_1_8_R3_quinted-02\GumpStudioCore.dll

using Microsoft.VisualBasic.CompilerServices;
using System.Windows.Forms;

namespace GumpStudio
{
  [StandardModule]
  internal sealed class GumpDesignerMain
  {
    public static void main()
    {
      Application.EnableVisualStyles();
      Application.Run((Form) new DesignerForm());
    }
  }
}
