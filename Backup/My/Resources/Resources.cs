// Decompiled with JetBrains decompiler
// Type: GumpStudio.My.Resources.Resources
// Assembly: GumpStudioCore, Version=1.8.3024.24259, Culture=neutral, PublicKeyToken=null
// MVID: A77D32E5-7519-4865-AA26-DCCB34429732
// Assembly location: C:\GumpStudio_1_8_R3_quinted-02\GumpStudioCore.dll

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace GumpStudio.My.Resources
{
  [StandardModule]
  [CompilerGenerated]
  [DebuggerNonUserCode]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
  [HideModuleName]
  internal sealed class Resources
  {
    private static CultureInfo resourceCulture;
    private static ResourceManager resourceMan;

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return GumpStudio.My.Resources.Resources.resourceCulture;
      }
      set
      {
        GumpStudio.My.Resources.Resources.resourceCulture = value;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals((object) GumpStudio.My.Resources.Resources.resourceMan, (object) null))
          GumpStudio.My.Resources.Resources.resourceMan = new ResourceManager("GumpStudio.Resources", typeof (GumpStudio.My.Resources.Resources).Assembly);
        return GumpStudio.My.Resources.Resources.resourceMan;
      }
    }
  }
}
