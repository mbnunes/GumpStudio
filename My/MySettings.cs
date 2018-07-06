// Decompiled with JetBrains decompiler
// Type: GumpStudio.My.MySettings
// Assembly: GumpStudioCore, Version=1.8.3024.24259, Culture=neutral, PublicKeyToken=null
// MVID: A77D32E5-7519-4865-AA26-DCCB34429732
// Assembly location: C:\GumpStudio_1_8_R3_quinted-02\GumpStudioCore.dll

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace GumpStudio.My
{
  [CompilerGenerated]
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
  [EditorBrowsable(EditorBrowsableState.Advanced)]
  internal sealed class MySettings : ApplicationSettingsBase
  {
    private static MySettings defaultInstance = (MySettings) SettingsBase.Synchronized((SettingsBase) new MySettings());

    [DebuggerNonUserCode]
    [UserScopedSetting]
    [DefaultSettingValue("1.05")]
    public Decimal ArrowKeyAccelerationRate
    {
      get
      {
        return Conversions.ToDecimal(this[nameof (ArrowKeyAccelerationRate)]);
      }
      set
      {
        this[nameof (ArrowKeyAccelerationRate)] = (object) value;
      }
    }

    [DefaultSettingValue("")]
    [DebuggerNonUserCode]
    [UserScopedSetting]
    public string ClientPath
    {
      get
      {
        return Conversions.ToString(this[nameof (ClientPath)]);
      }
      set
      {
        this[nameof (ClientPath)] = (object) value;
      }
    }

    public static MySettings Default
    {
      get
      {
        MySettings defaultInstance = MySettings.defaultInstance;
        return defaultInstance;
      }
    }

    [DefaultSettingValue("920, 602")]
    [UserScopedSetting]
    [DebuggerNonUserCode]
    public Size DesignerFormSize
    {
      get
      {
        return (Size) this[nameof (DesignerFormSize)];
      }
      set
      {
        this[nameof (DesignerFormSize)] = (object) value;
      }
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("25")]
    public int UndoLevels
    {
      get
      {
        return Conversions.ToInteger(this[nameof (UndoLevels)]);
      }
      set
      {
        this[nameof (UndoLevels)] = (object) value;
      }
    }

    [UserScopedSetting]
    [DefaultSettingValue("False")]
    [DebuggerNonUserCode]
    public bool UsePixelPerfectSelection
    {
      get
      {
        return Conversions.ToBoolean(this[nameof (UsePixelPerfectSelection)]);
      }
      set
      {
        this[nameof (UsePixelPerfectSelection)] = (object) value;
      }
    }
  }
}
