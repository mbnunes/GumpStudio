// Decompiled with JetBrains decompiler
// Type: GumpStudio.Elements.CheckboxElement
// Assembly: GumpStudioCore, Version=1.8.3024.24259, Culture=neutral, PublicKeyToken=null
// MVID: A77D32E5-7519-4865-AA26-DCCB34429732
// Assembly location: C:\GumpStudio_1_8_R3_quinted-02\GumpStudioCore.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.Serialization;
using Ultima;

namespace GumpStudio.Elements
{
  [Serializable]
  public class CheckboxElement : BaseElement
  {
    protected Image Image1Cache;
    protected Image Image2Cache;
    protected bool mChecked;
    protected int mCheckedID;
    protected int mGroupID;
    protected int mUncheckedID;

    [Description("Sets the initial state of the checkbox.")]
    public virtual bool Checked
    {
      get
      {
        return this.mChecked;
      }
      set
      {
        this.mChecked = value;
        this.RefreshCache();
      }
    }

    [Editor(typeof (GumpIDPropEditor), typeof (UITypeEditor))]
    public virtual int CheckedID
    {
      get
      {
        return this.mCheckedID;
      }
      set
      {
        this.mCheckedID = value;
        this.RefreshCache();
      }
    }

    [Description("The Value of the checkbox returned to the script.")]
    public virtual int Group
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
        return "Checkbox";
      }
    }

    [Editor(typeof (GumpIDPropEditor), typeof (UITypeEditor))]
    public virtual int UnCheckedID
    {
      get
      {
        return this.mUncheckedID;
      }
      set
      {
        this.mUncheckedID = value;
        this.RefreshCache();
      }
    }

    public CheckboxElement()
    {
      this.mUncheckedID = 210;
      this.mCheckedID = 211;
      this.RefreshCache();
    }

    public CheckboxElement(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
      info.GetInt32("CheckboxVersion");
      this.mChecked = info.GetBoolean(nameof (Checked));
      this.mCheckedID = info.GetInt32(nameof (CheckedID));
      this.mUncheckedID = info.GetInt32("UncheckedID");
      this.mGroupID = info.GetInt32("GroupID");
      this.RefreshCache();
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      base.GetObjectData(info, context);
      info.AddValue("CheckboxVersion", 1);
      info.AddValue("Checked", this.mChecked);
      info.AddValue("CheckedID", this.mCheckedID);
      info.AddValue("UncheckedID", this.mUncheckedID);
      info.AddValue("GroupID", this.mGroupID);
    }

    public override void RefreshCache()
    {
      if (this.Image1Cache != null)
        this.Image1Cache.Dispose();
      if (this.Image2Cache != null)
        this.Image1Cache.Dispose();
      this.Image1Cache = (Image) Gumps.GetGump(this.mUncheckedID);
      if (this.Image1Cache == null)
        this.UnCheckedID = 210;
      this.Image2Cache = (Image) Gumps.GetGump(this.mCheckedID);
      if (this.Image2Cache == null)
        this.CheckedID = 211;
      if (this.mChecked)
        this.mSize = this.Image2Cache.Size;
      else
        this.mSize = this.Image1Cache.Size;
    }

    public override void Render(Graphics Target)
    {
      if (this.Image1Cache == null | this.Image2Cache == null)
        this.RefreshCache();
      if (this.mChecked)
        Target.DrawImage(this.Image2Cache, this.Location);
      else
        Target.DrawImage(this.Image1Cache, this.Location);
    }
  }
}
