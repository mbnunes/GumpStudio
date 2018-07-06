// Decompiled with JetBrains decompiler
// Type: GumpStudio.Elements.TextEntryElement
// Assembly: GumpStudioCore, Version=1.8.3024.24259, Culture=neutral, PublicKeyToken=null
// MVID: A77D32E5-7519-4865-AA26-DCCB34429732
// Assembly location: C:\GumpStudio_1_8_R3_quinted-02\GumpStudioCore.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.Serialization;
using Ultima;
using UOFont;

namespace GumpStudio.Elements
{
  [Serializable]
  public class TextEntryElement : ResizeableElement
  {
    protected Bitmap mCache;
    protected Hue mHue;
    protected int mID;
    protected string mInitialText;
    protected int mMaxLength;

    [TypeConverter(typeof (HuePropStringConverter))]
    [Description("The Hue of the text, Only the right-most color of the Hue is used.")]
    [Browsable(true)]
    [Editor(typeof (HuePropEditor), typeof (UITypeEditor))]
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

    [Description("The ID of this text entry element returned to script.")]
    [MergableProperty(false)]
    public int ID
    {
      get
      {
        return this.mID;
      }
      set
      {
        this.mID = value;
      }
    }

    [Description("The text in the text entry area when the gump is initially opened.")]
    public string InitialText
    {
      get
      {
        return this.mInitialText;
      }
      set
      {
        this.mInitialText = value;
        this.RefreshCache();
      }
    }

    [Description("MaxLength sets the maximum number of characters allowed in this TextEntry element. Set to 0 for no limit.")]
    [MergableProperty(true)]
    public int MaxLength
    {
      get
      {
        return this.mMaxLength;
      }
      set
      {
        this.mMaxLength = value;
      }
    }

    public override string Type
    {
      get
      {
        return "Text Entry";
      }
    }

    public TextEntryElement()
    {
      this.mSize = new Size(200, 20);
      this.mHue = Hues.GetHue(0);
    }

    public TextEntryElement(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
      int int32 = info.GetInt32("TextEntryElementVersion");
      this.mInitialText = info.GetString("Text");
      this.mHue = Hues.GetHue(info.GetInt32("HueIndex"));
      if (int32 >= 2)
      {
        this.mID = info.GetInt32(nameof (ID));
        this.mMaxLength = info.GetInt32(nameof (MaxLength));
      }
      this.RefreshCache();
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      base.GetObjectData(info, context);
      info.AddValue("TextEntryElementVersion", 2);
      info.AddValue("Text", (object) this.mInitialText);
      info.AddValue("HueIndex", this.mHue.Index);
      info.AddValue("ID", this.mID);
      info.AddValue("MaxLength", this.mMaxLength);
    }

    public override void RefreshCache()
    {
      if (this.mHue == null)
        this.mHue = Hues.GetHue(0);
      if (this.mCache != null)
        this.mCache.Dispose();
      this.mCache = UnicodeFonts.GetStringImage(2, this.mInitialText + " ");
      if ((this.mHue == null || this.mHue.Index == 0 ? 0 : 1) == 0)
        return;
      this.mHue.ApplyTo(this.mCache, false);
    }

    public override void Render(Graphics Target)
    {
      if (this.mCache == null)
        this.RefreshCache();
      Region clip = Target.Clip;
      Region region = new Region(this.Bounds);
      Target.Clip = region;
      SolidBrush solidBrush = new SolidBrush(Color.FromArgb(50, Color.Yellow));
      Target.FillRectangle((Brush) solidBrush, this.Bounds);
      Target.DrawImage((Image) this.mCache, this.Location);
      solidBrush.Dispose();
      Target.Clip = clip;
      region.Dispose();
    }
  }
}
