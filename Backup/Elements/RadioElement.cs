// Decompiled with JetBrains decompiler
// Type: GumpStudio.Elements.RadioElement
// Assembly: GumpStudioCore, Version=1.8.3024.24259, Culture=neutral, PublicKeyToken=null
// MVID: A77D32E5-7519-4865-AA26-DCCB34429732
// Assembly location: C:\GumpStudio_1_8_R3_quinted-02\GumpStudioCore.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace GumpStudio.Elements
{
  [Serializable]
  public class RadioElement : CheckboxElement
  {
    protected int mValue;

    public override bool Checked
    {
      get
      {
        return base.Checked;
      }
      set
      {
        this.mChecked = value;
        if (!this.mChecked)
          return;
        IEnumerator enumerator = (IEnumerator) null;
        try
        {
          foreach (object obj in this.mParent.GetElementsRecursive())
          {
            object objectValue = RuntimeHelpers.GetObjectValue(obj);
            if (objectValue is RadioElement)
            {
              RadioElement radioElement = (RadioElement) objectValue;
              if (radioElement != this && radioElement.Checked & radioElement.Group == this.Group)
                radioElement.Checked = false;
            }
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
      }
    }

    [Description("The Group that the radio buttons belongs to.  Only one button in a group may be selected at a time.")]
    public override int Group
    {
      get
      {
        return this.mGroupID;
      }
      set
      {
        this.mGroupID = value;
      }
    }

    public override string Type
    {
      get
      {
        return "Radio Button";
      }
    }

    [MergableProperty(false)]
    [Description("The value fo this radio button returned to the script")]
    public int Value
    {
      get
      {
        return this.mValue;
      }
      set
      {
        this.mValue = value;
      }
    }

    public RadioElement()
    {
      this.CheckedID = 208;
      this.UnCheckedID = 209;
    }

    public RadioElement(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
      if (info.GetInt32("RadioElementVersion") >= 2)
        this.mValue = info.GetInt32(nameof (Value));
      this.RefreshCache();
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      base.GetObjectData(info, context);
      info.AddValue("RadioElementVersion", 2);
      info.AddValue("Value", this.mValue);
    }
  }
}
