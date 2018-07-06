// Decompiled with JetBrains decompiler
// Type: GumpStudio.Elements.TiledElement
// Assembly: GumpStudioCore, Version=1.8.3024.24259, Culture=neutral, PublicKeyToken=null
// MVID: A77D32E5-7519-4865-AA26-DCCB34429732
// Assembly location: C:\GumpStudio_1_8_R3_quinted-02\GumpStudioCore.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.Serialization;
using System.Windows.Forms;
using Ultima;

namespace GumpStudio.Elements
{
  [Serializable]
  public class TiledElement : ResizeableElement
  {
    protected bool DoingRenderRetry;
    protected Bitmap ImageCache;
    protected int mGumpID;
    protected Hue mHue;
    protected Size mTileSize;

    [Editor(typeof (GumpIDPropEditor), typeof (UITypeEditor))]
    public virtual int GumpID
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
    [Browsable(true)]
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

    [Description("The size of the image being tiled")]
    public Size TileSize
    {
      get
      {
        return this.mTileSize;
      }
    }

    public override string Type
    {
      get
      {
        return "Tiled Image";
      }
    }

    public TiledElement()
      : this(30089)
    {
      this.GumpID = 30089;
      this.RefreshCache();
    }

    public TiledElement(int GumpID)
    {
      this.DoingRenderRetry = false;
      this.mHue = Hues.GetHue(0);
      this.GumpID = GumpID;
      this.mSize = this.mTileSize;
    }

    public TiledElement(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
      this.DoingRenderRetry = false;
      this.mHue = Hues.GetHue(0);
      int int32 = info.GetInt32("TiledElementVersion");
      this.GumpID = info.GetInt32(nameof (GumpID));
      this.mHue = int32 < 2 ? Hues.GetHue(0) : Hues.GetHue(info.GetInt32("HueIndex"));
      this.RefreshCache();
    }

    public override void AddContextMenus(ref MenuItem GroupMenu, ref MenuItem PositionMenu, ref MenuItem OrderMenu, ref MenuItem MiscMenu)
    {
      base.AddContextMenus(ref GroupMenu, ref PositionMenu, ref OrderMenu, ref MiscMenu);
      if (PositionMenu.MenuItems.Count > 1)
        PositionMenu.MenuItems.Add(new MenuItem("-"));
      PositionMenu.MenuItems.Add(new MenuItem("Reset Size", new EventHandler(this.DoResetSizeMenu)));
    }

    protected virtual void DoResetSizeMenu(object sender, EventArgs e)
    {
      this.mSize = this.mTileSize;
      this.RaiseUpdateEvent((BaseElement) this, false);
      GlobalObjects.DesignerForm.CreateUndoPoint();
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      base.GetObjectData(info, context);
      info.AddValue("TiledElementVersion", 2);
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
      this.mTileSize = this.ImageCache.Size;
    }

    public override void Render(Graphics Target)
    {
      if (this.ImageCache != null)
      {
        Region clip = Target.Clip;
        Region region = new Region(this.Bounds);
        Target.Clip = region;
        int width1 = this.mTileSize.Width;
        int width2 = this.Width;
        int dx = 0;
        while ((width1 >> 31 ^ dx) <= (width1 >> 31 ^ width2))
        {
          int height1 = this.mTileSize.Height;
          int height2 = this.Height;
          int dy = 0;
          while ((height1 >> 31 ^ dy) <= (height1 >> 31 ^ height2))
          {
            Point location = this.Location;
            location.Offset(dx, dy);
            Target.DrawImage((Image) this.ImageCache, location);
            dy += height1;
          }
          dx += width1;
        }
        Target.Clip = clip;
        region.Dispose();
      }
      else if (!this.DoingRenderRetry)
      {
        this.DoingRenderRetry = true;
        this.GumpID = this.mGumpID;
        this.Render(Target);
      }
      else
      {
        Graphics graphics1 = Target;
        Pen red1 = Pens.Red;
        int x1 = this.Location.X;
        int y1 = this.Location.Y;
        Point location = this.Location;
        int x2 = location.X + this.Size.Width;
        location = this.Location;
        int y2_1 = location.Y + this.Size.Height;
        graphics1.DrawLine(red1, x1, y1, x2, y2_1);
        Graphics graphics2 = Target;
        Pen red2 = Pens.Red;
        location = this.Location;
        int x1_1 = location.X + this.Size.Width;
        location = this.Location;
        int y2 = location.Y;
        location = this.Location;
        int x3 = location.X;
        location = this.Location;
        int y2_2 = location.Y + this.Size.Height;
        graphics2.DrawLine(red2, x1_1, y2, x3, y2_2);
      }
    }
  }
}
