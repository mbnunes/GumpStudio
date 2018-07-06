// Decompiled with JetBrains decompiler
// Type: GumpStudio.Elements.HTMLElement
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
  public class HTMLElement : ResizeableElement
  {
    protected Bitmap imgBack;
    protected Bitmap imgDown;
    protected Bitmap imgLoc;
    protected Bitmap imgUp;
    protected bool mBackground;
    protected BackgroundElement mBGElement;
    protected Bitmap mCache;
    protected int mCliLocID;
    protected Font mFont;
    protected string mHTML;
    protected bool mScrollbar;
    protected HTMLElementType mTextType;

    [Description("The ID of the localized message to display as the text of the HTML Element. Only Valid if TextType is set to Localized.")]
    [Editor(typeof (ClilocPropEditor), typeof (UITypeEditor))]
    public int CliLocID
    {
      get
      {
        return this.mCliLocID;
      }
      set
      {
        this.mCliLocID = value;
      }
    }

    [Editor(typeof (LargeTextPropEditor), typeof (UITypeEditor))]
    [Description("The HTML to display in the Element.  Only valid if TextType is set to HTML.")]
    public string HTML
    {
      get
      {
        return this.mHTML;
      }
      set
      {
        this.mHTML = value;
      }
    }

    [Description("Display a background behind the text of the element.")]
    public bool ShowBackground
    {
      get
      {
        return this.mBackground;
      }
      set
      {
        this.mBackground = value;
      }
    }

    [Description("Display scrollbars along the right side of the element.")]
    public bool ShowScrollbar
    {
      get
      {
        return this.mScrollbar;
      }
      set
      {
        this.mScrollbar = value;
      }
    }

    [Description("Switches between custom HTML, and Localized messages")]
    public HTMLElementType TextType
    {
      get
      {
        return this.mTextType;
      }
      set
      {
        this.mTextType = value;
      }
    }

    public override string Type
    {
      get
      {
        return "HTML";
      }
    }

    public HTMLElement()
    {
      this.mHTML = "";
      this.mCliLocID = 0;
      this.mScrollbar = true;
      this.mBackground = true;
      this.mTextType = HTMLElementType.HTML;
      this.mHTML = "";
      this.mSize = new Size(200, 100);
      this.mFont = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point);
      this.RefreshCache();
    }

    public HTMLElement(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
      info.GetInt32("HTMLElementVersion");
      this.mHTML = info.GetString(nameof (HTML));
      this.mCliLocID = info.GetInt32("ClilocID");
      this.mScrollbar = info.GetBoolean("Scrollbar");
      this.mBackground = info.GetBoolean("Background");
      this.mTextType = (HTMLElementType) info.GetInt32(nameof (TextType));
      this.mFont = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point);
      this.RefreshCache();
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      base.GetObjectData(info, context);
      info.AddValue("HTMLElementVersion", 1);
      info.AddValue("HTML", (object) this.mHTML);
      info.AddValue("ClilocID", this.mCliLocID);
      info.AddValue("Scrollbar", this.mScrollbar);
      info.AddValue("Background", this.mBackground);
      info.AddValue("TextType", (int) this.mTextType);
    }

    public override void RefreshCache()
    {
      this.imgUp = Gumps.GetGump(250);
      this.imgDown = Gumps.GetGump(252);
      this.imgLoc = Gumps.GetGump(254);
      this.imgBack = Gumps.GetGump(256);
      this.mBGElement = new BackgroundElement();
      this.mBGElement.GumpID = 3000;
    }

    public override void Render(Graphics Target)
    {
      SolidBrush solidBrush = new SolidBrush(Color.FromArgb(70, Color.White));
      if (!this.mBackground)
      {
        Target.FillRectangle((Brush) solidBrush, this.Bounds);
        Target.DrawRectangle(Pens.DarkGray, this.Bounds);
      }
      if (this.mScrollbar)
      {
        Target.DrawImage((Image) this.imgUp, this.X + this.Width - this.imgUp.Width, this.Y);
        Target.DrawImage((Image) this.imgLoc, this.X + this.Width - this.imgLoc.Width, this.Y + this.imgUp.Height);
        Region clip = Target.Clip;
        Region region = new Region(new Rectangle(this.X + this.Width - this.imgBack.Width, this.Y + this.imgUp.Height + this.imgLoc.Height, this.imgBack.Width, this.Height - this.imgDown.Height - this.imgUp.Height - this.imgLoc.Height));
        Target.Clip = region;
        int height = this.imgBack.Height;
        int num = this.Y + this.Height - this.imgDown.Height;
        int y = this.Y + this.imgUp.Height + this.imgLoc.Height;
        while ((height >> 31 ^ y) <= (height >> 31 ^ num))
        {
          Target.DrawImage((Image) this.imgBack, this.X + this.Width - this.imgBack.Width, y);
          y += height;
        }
        Target.Clip = clip;
        Target.DrawImage((Image) this.imgDown, this.X + this.Width - this.imgDown.Width, this.Y + this.Height - this.imgDown.Height);
      }
      Rectangle rectangle1 = new Rectangle(this.Location, this.mBGElement.Size);
      Rectangle rectangle2;
      if (this.mBackground)
      {
        this.mBGElement.Location = this.Location;
        rectangle2 = !this.mScrollbar ? new Rectangle(this.Location, this.Size) : new Rectangle(this.Location, new Size(this.Width - this.imgBack.Width, this.Height));
        this.mBGElement.Size = rectangle2.Size;
        this.mBGElement.Render(Target);
      }
      else
        rectangle2 = this.Bounds;
      RectangleF layoutRectangle = new RectangleF((float) rectangle2.X, (float) rectangle2.Y, (float) rectangle2.Width, (float) rectangle2.Height);
      Target.DrawString(this.mHTML, this.mFont, Brushes.Black, layoutRectangle);
      solidBrush.Dispose();
    }
  }
}
