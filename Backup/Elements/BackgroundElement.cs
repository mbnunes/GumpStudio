// Decompiled with JetBrains decompiler
// Type: GumpStudio.Elements.BackgroundElement
// Assembly: GumpStudioCore, Version=1.8.3024.24259, Culture=neutral, PublicKeyToken=null
// MVID: A77D32E5-7519-4865-AA26-DCCB34429732
// Assembly location: C:\GumpStudio_1_8_R3_quinted-02\GumpStudioCore.dll

using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.Serialization;
using Ultima;

namespace GumpStudio.Elements
{
  [Serializable]
  public class BackgroundElement : ResizeableElement, IDisposable
  {
    protected int mGumpID;
    protected Image[] mMultImageCache;

    [Editor(typeof (GumpIDPropEditor), typeof (UITypeEditor))]
    public int GumpID
    {
      get
      {
        return this.mGumpID;
      }
      set
      {
        bool flag = true;
        int num1 = 0;
        int num2;
        do
        {
          Bitmap gump = Gumps.GetGump(num1 + value);
          if (gump == null)
            flag = false;
          gump.Dispose();
          ++num1;
          num2 = 8;
        }
        while (num1 <= num2);
        if (!flag)
        {
          int num3 = (int) Interaction.MsgBox((object) "Invalid GumpID", MsgBoxStyle.OkOnly, (object) null);
        }
        else
        {
          this.mGumpID = value;
          this.RefreshCache();
        }
      }
    }

    public override string Type
    {
      get
      {
        return "Background";
      }
    }

    public BackgroundElement()
    {
      this.mMultImageCache = new Image[9];
      this.mSize = new Size(100, 100);
      this.mGumpID = 9200;
      this.RefreshCache();
    }

    public BackgroundElement(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
      this.mMultImageCache = new Image[9];
      info.GetInt32("BackgroundElementVersion");
      this.GumpID = info.GetInt32(nameof (GumpID));
    }

    public void Dispose()
    {
      int index = 0;
      int num;
      do
      {
        if (this.mMultImageCache[index] != null)
          this.mMultImageCache[index].Dispose();
        ++index;
        num = 8;
      }
      while (index <= num);
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      base.GetObjectData(info, context);
      info.AddValue("BackgroundElementVersion", 1);
      info.AddValue("GumpID", this.mGumpID);
    }

    public override void RefreshCache()
    {
      if (this.mMultImageCache == null)
        this.mMultImageCache = new Image[9];
      int index = 0;
      int num;
      do
      {
        if (this.mMultImageCache[index] != null)
          this.mMultImageCache[index].Dispose();
        this.mMultImageCache[index] = (Image) Gumps.GetGump(index + this.mGumpID);
        ++index;
        num = 8;
      }
      while (index <= num);
    }

    public override void Render(Graphics Target)
    {
      if (this.mMultImageCache == null)
        this.RefreshCache();
      int index = 0;
      int num1;
      do
      {
        if (this.mMultImageCache[index] == null)
          this.RefreshCache();
        ++index;
        num1 = 8;
      }
      while (index <= num1);
      Region clip = Target.Clip;
      Rectangle rect = new Rectangle(this.X, this.Y, this.mMultImageCache[0].Width, this.mMultImageCache[0].Height);
      Region region1 = new Region(rect);
      Target.Clip = region1;
      Target.DrawImage(this.mMultImageCache[0], this.Location);
      region1.Dispose();
      rect = new Rectangle(this.X, this.Y, this.Width - this.mMultImageCache[2].Width, this.Height);
      Region region2 = new Region(rect);
      Target.Clip = region2;
      int width1 = this.mMultImageCache[1].Width;
      int num2 = this.Width - this.mMultImageCache[2].Width;
      int width2 = this.mMultImageCache[0].Width;
      Point point;
      while ((width1 >> 31 ^ width2) <= (width1 >> 31 ^ num2))
      {
        point = new Point(this.X + width2, this.Y);
        Target.DrawImage(this.mMultImageCache[1], point);
        width2 += width1;
      }
      region2.Dispose();
      rect = new Rectangle(this.X + this.Width - this.mMultImageCache[0].Width, this.Y, this.mMultImageCache[0].Width, this.Height);
      Region region3 = new Region(rect);
      Target.Clip = region3;
      point = new Point(this.X + this.Width - this.mMultImageCache[2].Width, this.Y);
      Target.DrawImage(this.mMultImageCache[2], point);
      region3.Dispose();
      rect = new Rectangle(this.X, this.Y, this.mMultImageCache[0].Width, this.Height - this.mMultImageCache[6].Height);
      Region region4 = new Region(rect);
      Target.Clip = region4;
      int height1 = this.mMultImageCache[3].Height;
      int num3 = this.Height - this.mMultImageCache[6].Height;
      int height2 = this.mMultImageCache[0].Height;
      while ((height1 >> 31 ^ height2) <= (height1 >> 31 ^ num3))
      {
        point = new Point(this.X, this.Y + height2);
        Target.DrawImage(this.mMultImageCache[3], point);
        height2 += height1;
      }
      region4.Dispose();
      rect = new Rectangle(this.X, this.Y + this.Height - this.mMultImageCache[6].Height, this.mMultImageCache[6].Width, this.mMultImageCache[6].Height);
      Region region5 = new Region(rect);
      Target.Clip = region5;
      point = new Point(this.X, this.Y + this.Height - this.mMultImageCache[6].Height);
      Target.DrawImage(this.mMultImageCache[6], point);
      region5.Dispose();
      rect = new Rectangle(this.X, this.Y + this.Height - this.mMultImageCache[7].Height, this.Width - this.mMultImageCache[6].Width, this.mMultImageCache[7].Height);
      Region region6 = new Region(rect);
      Target.Clip = region6;
      int width3 = this.mMultImageCache[7].Width;
      int num4 = this.Width - this.mMultImageCache[8].Width;
      int width4 = this.mMultImageCache[6].Width;
      while ((width3 >> 31 ^ width4) <= (width3 >> 31 ^ num4))
      {
        point = new Point(this.X + width4, this.Y + this.Height - this.mMultImageCache[7].Height);
        Target.DrawImage(this.mMultImageCache[7], point);
        width4 += width3;
      }
      region6.Dispose();
      rect = new Rectangle(this.X + this.Width - this.mMultImageCache[8].Width, this.Y + this.Height - this.mMultImageCache[8].Height, this.mMultImageCache[8].Width, this.mMultImageCache[8].Height);
      Region region7 = new Region(rect);
      Target.Clip = region7;
      point = new Point(this.X + this.Width - this.mMultImageCache[8].Width, this.Y + this.Height - this.mMultImageCache[8].Height);
      Target.DrawImage(this.mMultImageCache[8], point);
      region7.Dispose();
      rect = new Rectangle(this.X + this.Width - this.mMultImageCache[5].Width, this.Y + this.mMultImageCache[2].Height, this.mMultImageCache[5].Width, this.Height - this.mMultImageCache[8].Height - this.mMultImageCache[2].Height);
      Region region8 = new Region(rect);
      Target.Clip = region8;
      int height3 = this.mMultImageCache[5].Height;
      int num5 = this.Height - this.mMultImageCache[6].Height;
      int height4 = this.mMultImageCache[0].Height;
      while ((height3 >> 31 ^ height4) <= (height3 >> 31 ^ num5))
      {
        point = new Point(this.X + this.Width - this.mMultImageCache[5].Width, this.Y + height4);
        Target.DrawImage(this.mMultImageCache[5], point);
        height4 += height3;
      }
      region8.Dispose();
      rect = new Rectangle(this.X + this.mMultImageCache[3].Width, this.Y + this.mMultImageCache[1].Height, this.Width - this.mMultImageCache[3].Width - this.mMultImageCache[5].Width, this.Height - this.mMultImageCache[7].Height - this.mMultImageCache[1].Height);
      Region region9 = new Region(rect);
      Target.Clip = region9;
      int width5 = this.mMultImageCache[4].Width;
      int num6 = this.Width - this.mMultImageCache[3].Width;
      int width6 = this.mMultImageCache[3].Width;
      while ((width5 >> 31 ^ width6) <= (width5 >> 31 ^ num6))
      {
        int height5 = this.mMultImageCache[4].Height;
        int num7 = this.Height - this.mMultImageCache[7].Height;
        int height6 = this.mMultImageCache[1].Height;
        while ((height5 >> 31 ^ height6) <= (height5 >> 31 ^ num7))
        {
          point = new Point(this.X + width6, this.Y + height6);
          Target.DrawImage(this.mMultImageCache[4], point);
          height6 += height5;
        }
        width6 += width5;
      }
      region9.Dispose();
      Target.Clip = clip;
    }
  }
}
