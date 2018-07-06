// Decompiled with JetBrains decompiler
// Type: GumpStudio.Elements.LabelElement
// Assembly: GumpStudioCore, Version=1.8.3024.24259, Culture=neutral, PublicKeyToken=null
// MVID: A77D32E5-7519-4865-AA26-DCCB34429732
// Assembly location: C:\GumpStudio_1_8_R3_quinted-02\GumpStudioCore.dll

using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Imaging;
using System.Runtime.Serialization;
using Ultima;
using UOFont;

namespace GumpStudio.Elements
{
  [Serializable]
  public class LabelElement : BaseElement
  {
    protected Bitmap mCache;
    protected bool mCropped;
    protected int mFontIndex;
    protected Hue mHue;
    protected string mText;
    protected bool mUnicode;
    protected bool mPartialHue;

    [MergableProperty(true)]
    public bool Cropped
    {
      get
      {
        return this.mCropped;
      }
      set
      {
        this.mCropped = value;
        this.RefreshCache();
      }
    }

    [MergableProperty(true)]
    public bool Unicode
    {
      get
      {
        return this.mUnicode;
      }
      set
      {
        this.mUnicode = value;
        if (!value && this.mFontIndex > 12)
          this.mFontIndex = 12;
        this.RefreshCache();
      }
    }

    [Browsable(true)]
    [MergableProperty(true)]
    [Editor(typeof (FontPropEditor), typeof (UITypeEditor))]
    public int Font
    {
      get
      {
        return this.mFontIndex;
      }
      set
      {
        if (value >= 0 & value < (this.mUnicode ? 13 : 10))
        {
          this.mFontIndex = value;
          this.RefreshCache();
        }
        else
        {
          int num = (int) Interaction.MsgBox((object) "Font much be between 0 and 10 for ansi and upto 12 for unicode.", MsgBoxStyle.OkOnly, (object) null);
        }
      }
    }

    [MergableProperty(true)]
    public bool PartialHue
    {
      get
      {
        return this.mPartialHue;
      }
      set
      {
        this.mPartialHue = value;
        this.RefreshCache();
      }
    }

    [MergableProperty(true)]
    [Browsable(true)]
    [Editor(typeof (HuePropEditor), typeof (UITypeEditor))]
    [TypeConverter(typeof (HuePropStringConverter))]
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

    [Browsable(true)]
    [MergableProperty(true)]
    public override Size Size
    {
      get
      {
        return base.Size;
      }
      set
      {
        if (!this.mCropped)
          throw new ArgumentException("Size may only be changed if the label is cropped.");
        this.mSize = value;
      }
    }

    [MergableProperty(true)]
    public string Text
    {
      get
      {
        return this.mText;
      }
      set
      {
        this.mText = value;
        this.RefreshCache();
      }
    }

    public override string Type
    {
      get
      {
        return "Label";
      }
    }

    public LabelElement()
    {
      this.mFontIndex = 2;
      this.mCropped = false;
      this.mPartialHue = true;
      this.mUnicode = true;
      this.mHue = Hues.GetHue(0);
      this.mText = "New Label";
      try
      {
        this.RefreshCache();
      }
      catch (Exception ex)
      {
      }
    }

    public LabelElement(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
      this.mFontIndex = 2;
      int int32 = info.GetInt32("LabelElementVersion");
      this.mText = info.GetString(nameof (Text));
      this.mHue = Hues.GetHue(info.GetInt32("HueIndex"));
      if (int32 >= 3)
      {
        this.mPartialHue = info.GetBoolean(nameof (PartialHue));
        this.mUnicode = info.GetBoolean(nameof (Unicode));
      }
      else
      {
        this.mPartialHue = true;
        this.mUnicode = true;
      }
      this.mFontIndex = info.GetInt32("FontIndex");
      if (int32 <= 2)
        --this.mFontIndex;
      if (int32 >= 2)
      {
        this.mCropped = info.GetBoolean(nameof (Cropped));
        this.mSize = (Size) info.GetValue(nameof (Size), typeof (Size));
      }
      else
      {
        this.mCropped = false;
        Bitmap stringImage = UnicodeFonts.GetStringImage(this.mFontIndex, this.mText + " ");
        this.mSize = stringImage.Size;
        stringImage.Dispose();
      }
      this.RefreshCache();
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      base.GetObjectData(info, context);
      info.AddValue("LabelElementVersion", 3);
      info.AddValue("Text", (object) this.mText);
      info.AddValue("HueIndex", this.mHue.Index);
      info.AddValue("PartialHue", this.mPartialHue);
      info.AddValue("Unicode", this.mUnicode);
      info.AddValue("FontIndex", this.mFontIndex);
      info.AddValue("Cropped", this.mCropped);
    }

    public override void RefreshCache()
    {
      if (this.mCache != null)
        this.mCache.Dispose();
      this.mCache = this.mUnicode ? UnicodeFonts.GetStringImage(this.mFontIndex, this.mText + " ") : Fonts.GetStringImage(this.mFontIndex, this.mText + " ");
      if ((this.mHue == null || this.mHue.Index == 0 ? 0 : 1) != 0)
        this.mHue.ApplyTo(this.mCache, this.mPartialHue);
      if (this.mCropped)
      {
        Bitmap bitmap = new Bitmap(this.mSize.Width, this.mSize.Height, PixelFormat.Format32bppArgb);
        Graphics graphics = Graphics.FromImage((Image) bitmap);
        graphics.Clear(Color.Transparent);
        graphics.DrawImage((Image) this.mCache, 0, 0);
        graphics.Dispose();
        this.mCache.Dispose();
        this.mCache = bitmap;
      }
      this.mSize = this.mCache.Size;
    }

    public override void Render(Graphics Target)
    {
      if (this.mCache == null)
        this.RefreshCache();
      Target.DrawImage((Image) this.mCache, this.Location);
    }
  }
}
