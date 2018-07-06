// Decompiled with JetBrains decompiler
// Type: GumpStudio.Elements.ItemElement
// Assembly: GumpStudioCore, Version=1.8.3024.24259, Culture=neutral, PublicKeyToken=null
// MVID: A77D32E5-7519-4865-AA26-DCCB34429732
// Assembly location: C:\GumpStudio_1_8_R3_quinted-02\GumpStudioCore.dll

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.Serialization;
using Ultima;

namespace GumpStudio.Elements
{
  [Serializable]
  public class ItemElement : BaseElement
  {
    protected Image ImageCache;
    protected Hue mHue;
    protected int mItemID;

    [TypeConverter(typeof (HuePropStringConverter))]
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
      }
    }

    [Editor(typeof (ItemIDPropEditor), typeof (UITypeEditor))]
    public int ItemID
    {
      get
      {
        return this.mItemID;
      }
      set
      {
        this.ImageCache = (Image) Art.GetStatic(value);
        if (this.ImageCache == null)
        {
          this.ImageCache = (Image) Art.GetStatic(this.mItemID);
          int num = (int) Interaction.MsgBox((object) "Invalid ItemID", MsgBoxStyle.OkOnly, (object) null);
        }
        else
        {
          this.mItemID = value;
          this.mSize = this.ImageCache.Size;
        }
      }
    }

    public override string Type
    {
      get
      {
        return "Item";
      }
    }

    public ItemElement()
    {
      this.mSize = new Size(50, 50);
      this.ItemID = 0;
      this.mHue = Hues.GetHue(0);
    }

    public ItemElement(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
      info.GetInt32("ItemElementVersion");
      this.mItemID = info.GetInt32(nameof (ItemID));
      this.mHue = Hues.GetHue(info.GetInt32("HueIndex"));
      this.RefreshCache();
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      base.GetObjectData(info, context);
      info.AddValue("ItemElementVersion", 1);
      info.AddValue("ItemID", this.mItemID);
      info.AddValue("HueIndex", this.mHue.Index);
    }

    public override void RefreshCache()
    {
      if (this.ImageCache != null)
        return;
      this.ImageCache = (Image) Art.GetStatic(this.mItemID);
    }

    public override void Render(Graphics Target)
    {
      try
      {
        if (this.mHue.Index != 0)
        {
          Bitmap bmp = (Bitmap) this.ImageCache.Clone();
          if (bmp != null)
          {
            this.mHue.ApplyTo(bmp, false);
            Target.DrawImage((Image) bmp, this.Location);
            bmp.Dispose();
          }
          else
          {
            Target.DrawLine(Pens.Red, this.X, this.Y, this.X + 30, this.Y + 30);
            Target.DrawLine(Pens.Red, this.X + 30, this.Y, this.X, this.Y + 30);
          }
        }
        else
        {
          if (this.ImageCache == null)
            this.RefreshCache();
          if (this.ImageCache != null)
          {
            Target.DrawImage(this.ImageCache, this.Location);
          }
          else
          {
            Target.DrawLine(Pens.Red, this.X, this.Y, this.X + 30, this.Y + 30);
            Target.DrawLine(Pens.Red, this.X + 30, this.Y, this.X, this.Y + 30);
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) Interaction.MsgBox((object) ("Error drawing itemID: " + Conversions.ToString(this.ItemID) + " it has been replaced with the \"no draw\" item."), MsgBoxStyle.OkOnly, (object) null);
        this.ItemID = 1;
        ProjectData.ClearProjectError();
      }
    }
  }
}
