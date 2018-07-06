// Decompiled with JetBrains decompiler
// Type: GumpStudio.Elements.ImageElement
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
  public class ImageElement : BaseElement
  {
    protected Bitmap ImageCache;
    protected int mGumpID;
    protected Hue mHue;

    [Editor(typeof (GumpIDPropEditor), typeof (UITypeEditor))]
    public int GumpID
    {
      get
      {
        return this.mGumpID;
      }
      set
      {
        this.mGumpID = value;
        this.RefreshCache();
      }
    }

    [Editor(typeof (HuePropEditor), typeof (UITypeEditor))]
    [TypeConverter(typeof (HuePropStringConverter))]
    [Browsable(true)]
    public Hue Hue
    {
      get
      {
        return this.mHue;
      }
      set
      {
        this.mHue = value;
        this.RefreshCache();
      }
    }

    public override string Type
    {
      get
      {
        return "Image";
      }
    }

    public ImageElement()
      : this(1)
    {
    }

    public ImageElement(int GumpID)
    {
      this.mHue = Hues.GetHue(0);
      this.GumpID = GumpID;
    }

    public ImageElement(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
      this.mHue = Hues.GetHue(0);
      int int32 = info.GetInt32("ImageElementVersion");
      this.mGumpID = info.GetInt32(nameof (GumpID));
      if (int32 >= 2)
        this.mHue = Hues.GetHue(info.GetInt32("HueIndex"));
      else
        this.mHue = Hues.GetHue(0);
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      base.GetObjectData(info, context);
      info.AddValue("ImageElementVersion", 2);
      info.AddValue("GumpID", this.mGumpID);
      info.AddValue("HueIndex", this.mHue.Index);
    }

    public override void RefreshCache()
    {
      if (this.ImageCache != null)
        this.ImageCache.Dispose();
      this.ImageCache = Gumps.GetGump(this.mGumpID);
      if (this.ImageCache == null)
        this.GumpID = 0;
      if (this.mHue.Index != 0)
        this.mHue.ApplyTo(this.ImageCache, false);
      this.mSize = this.ImageCache.Size;
    }

    public override void Render(Graphics Target)
    {
      if (this.ImageCache == null)
        this.RefreshCache();
      if (this.ImageCache != null)
      {
        Target.DrawImage((Image) this.ImageCache, this.Location);
      }
      else
      {
        Target.DrawLine(Pens.Red, this.X, this.Y, this.X + 30, this.Y + 30);
        Target.DrawLine(Pens.Red, this.X + 30, this.Y, this.X, this.Y + 30);
      }
    }
  }
}
