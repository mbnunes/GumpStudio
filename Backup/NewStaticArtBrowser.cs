// Decompiled with JetBrains decompiler
// Type: GumpStudio.NewStaticArtBrowser
// Assembly: GumpStudioCore, Version=1.8.3024.24259, Culture=neutral, PublicKeyToken=null
// MVID: A77D32E5-7519-4865-AA26-DCCB34429732
// Assembly location: C:\GumpStudio_1_8_R3_quinted-02\GumpStudioCore.dll

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Ultima;

namespace GumpStudio
{
  public class NewStaticArtBrowser : Form
  {
    private static List<WeakReference> __ENCList = new List<WeakReference>();
    private bool SearchSomething;
    [AccessedThroughProperty("cmdCache")]
    private Button _cmdCache;
    [AccessedThroughProperty("cmdSearch")]
    private Button _cmdSearch;
    [AccessedThroughProperty("lblID")]
    private Label _lblID;
    [AccessedThroughProperty("lblName")]
    private Label _lblName;
    [AccessedThroughProperty("lblSize")]
    private Label _lblSize;
    [AccessedThroughProperty("lblWait")]
    private Label _lblWait;
    [AccessedThroughProperty("picCanvas")]
    private PictureBox _picCanvas;
    [AccessedThroughProperty("ToolTip1")]
    private ToolTip _ToolTip1;
    [AccessedThroughProperty("txtSearch")]
    private TextBox _txtSearch;
    [AccessedThroughProperty("vsbScroller")]
    private VScrollBar _vsbScroller;
    protected static Bitmap BlankCache;
    protected bool BuildingCache;
    protected static GumpCacheEntry[] Cache;
    private IContainer components;
    protected Size DisplaySize;
    protected Point HoverPos;
    protected int NumX;
    protected int NumY;
    protected static Bitmap[] RowCache;
    protected int SelectedIndex;
    protected int StartIndex;

    internal virtual Button cmdCache
    {
      [DebuggerNonUserCode] get
      {
        return this._cmdCache;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cmdCache_Click);
        if (this._cmdCache != null)
          this._cmdCache.Click -= eventHandler;
        this._cmdCache = value;
        if (this._cmdCache == null)
          return;
        this._cmdCache.Click += eventHandler;
      }
    }

    internal virtual Button cmdSearch
    {
      [DebuggerNonUserCode] get
      {
        return this._cmdSearch;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cmdSearch_Click);
        if (this._cmdSearch != null)
          this._cmdSearch.Click -= eventHandler;
        this._cmdSearch = value;
        if (this._cmdSearch == null)
          return;
        this._cmdSearch.Click += eventHandler;
      }
    }

    public int ItemID
    {
      get
      {
        return NewStaticArtBrowser.Cache[this.SelectedIndex].ID;
      }
      set
      {
        if (NewStaticArtBrowser.Cache == null)
          return;
        int num = Information.UBound((Array) NewStaticArtBrowser.Cache, 1);
        for (int index = 0; index <= num; ++index)
        {
          if (NewStaticArtBrowser.Cache[index].ID == value)
          {
            this.SelectedIndex = index;
            this.lblName.Text = "Name: " + TileData.ItemTable[this.ItemID].Name;
            this.lblSize.Text = "Size: " + Conversions.ToString(Art.GetStatic(this.ItemID).Width) + " x " + Conversions.ToString(Art.GetStatic(this.ItemID).Height);
          }
        }
      }
    }

    internal virtual Label lblID
    {
      [DebuggerNonUserCode] get
      {
        return this._lblID;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._lblID = value;
      }
    }

    internal virtual Label lblName
    {
      [DebuggerNonUserCode] get
      {
        return this._lblName;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._lblName = value;
      }
    }

    internal virtual Label lblSize
    {
      [DebuggerNonUserCode] get
      {
        return this._lblSize;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._lblSize = value;
      }
    }

    internal virtual Label lblWait
    {
      [DebuggerNonUserCode] get
      {
        return this._lblWait;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._lblWait = value;
      }
    }

    internal virtual PictureBox picCanvas
    {
      [DebuggerNonUserCode] get
      {
        return this._picCanvas;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.picCanvas_DoubleClick);
        MouseEventHandler mouseEventHandler1 = new MouseEventHandler(this.picCanvas_MouseUp);
        EventHandler eventHandler2 = new EventHandler(this.picCanvas_MouseLeave);
        MouseEventHandler mouseEventHandler2 = new MouseEventHandler(this.picCanvas_MouseMove);
        PaintEventHandler paintEventHandler = new PaintEventHandler(this.picCanvas_Paint);
        if (this._picCanvas != null)
        {
          this._picCanvas.DoubleClick -= eventHandler1;
          this._picCanvas.MouseUp -= mouseEventHandler1;
          this._picCanvas.MouseLeave -= eventHandler2;
          this._picCanvas.MouseMove -= mouseEventHandler2;
          this._picCanvas.Paint -= paintEventHandler;
        }
        this._picCanvas = value;
        if (this._picCanvas == null)
          return;
        this._picCanvas.DoubleClick += eventHandler1;
        this._picCanvas.MouseUp += mouseEventHandler1;
        this._picCanvas.MouseLeave += eventHandler2;
        this._picCanvas.MouseMove += mouseEventHandler2;
        this._picCanvas.Paint += paintEventHandler;
      }
    }

    internal virtual ToolTip ToolTip1
    {
      [DebuggerNonUserCode] get
      {
        return this._ToolTip1;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._ToolTip1 = value;
      }
    }

    internal virtual TextBox txtSearch
    {
      [DebuggerNonUserCode] get
      {
        return this._txtSearch;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._txtSearch = value;
      }
    }

    internal virtual VScrollBar vsbScroller
    {
      [DebuggerNonUserCode] get
      {
        return this._vsbScroller;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        ScrollEventHandler scrollEventHandler = new ScrollEventHandler(this.vsbScroller_Scroll);
        if (this._vsbScroller != null)
          this._vsbScroller.Scroll -= scrollEventHandler;
        this._vsbScroller = value;
        if (this._vsbScroller == null)
          return;
        this._vsbScroller.Scroll += scrollEventHandler;
      }
    }

    public NewStaticArtBrowser()
    {
      this.Load += new EventHandler(this.NewStaticArtBrowser_Load);
      this.Resize += new EventHandler(this.NewStaticArtBrowser_Resize);
      lock (NewStaticArtBrowser.__ENCList)
        NewStaticArtBrowser.__ENCList.Add(new WeakReference((object) this));
      this.DisplaySize = new Size(45, 45);
      this.HoverPos = new Point(-1, -1);
      this.SelectedIndex = 0;
      this.BuildingCache = false;
      this.InitializeComponent();
    }

    protected void BuildCache()
    {
      if (this.BuildingCache)
        return;
      this.BuildingCache = true;
      this.lblWait.Text = "Please Wait, Generating Art Cache...";
      this.Show();
      FileStream fileStream = (FileStream) null;
      try
      {
        NewStaticArtBrowser.Cache = (GumpCacheEntry[]) null;
        this.lblWait.Visible = true;
        Application.DoEvents();
        int upperBound = TileData.ItemTable.GetUpperBound(0);
        for (int index = 0; index <= upperBound; ++index)
        {
          if ((double) index / 128.0 == Conversion.Int((double) index / 128.0))
          {
            this.lblWait.Text = "Please Wait, Generating Static Art Cache...  \r\n" + Strings.Format((object) ((double) index / (double) TileData.ItemTable.GetUpperBound(0) * 100.0), "Fixed") + "%";
            Application.DoEvents();
          }
          Bitmap bitmap = Art.GetStatic(index);
          if (bitmap != null)
          {
            NewStaticArtBrowser.Cache = NewStaticArtBrowser.Cache != null ? (GumpCacheEntry[]) Utils.CopyArray((Array) NewStaticArtBrowser.Cache, (Array) new GumpCacheEntry[NewStaticArtBrowser.Cache.Length + 1]) : new GumpCacheEntry[1];
            NewStaticArtBrowser.Cache[NewStaticArtBrowser.Cache.Length - 1] = new GumpCacheEntry();
            NewStaticArtBrowser.Cache[NewStaticArtBrowser.Cache.Length - 1].ID = index;
            NewStaticArtBrowser.Cache[NewStaticArtBrowser.Cache.Length - 1].Size = bitmap.Size;
            NewStaticArtBrowser.Cache[NewStaticArtBrowser.Cache.Length - 1].Name = TileData.ItemTable[index].Name;
          }
        }
        fileStream = new FileStream(Application.StartupPath + "/StaticArt.cache", FileMode.Create);
        new BinaryFormatter().Serialize((Stream) fileStream, (object) NewStaticArtBrowser.Cache);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) Interaction.MsgBox((object) ("Error creating cache file:\r\n" + ex.Message), MsgBoxStyle.OkOnly, (object) null);
        ProjectData.ClearProjectError();
      }
      finally
      {
        fileStream?.Close();
        this.lblWait.Visible = false;
        Application.DoEvents();
        this.BuildingCache = false;
      }
    }

    private void cmdCache_Click(object sender, EventArgs e)
    {
      if (Interaction.MsgBox((object) "Rebuilding the cache may take several minutes debending on the speed of your computer.\r\nAre you sure you want to continue?", MsgBoxStyle.YesNo | MsgBoxStyle.Information, (object) "Rebuild Cache") != MsgBoxResult.Yes)
        return;
      this.BuildCache();
      NewStaticArtBrowser.RowCache = new Bitmap[(int) Math.Round((double) NewStaticArtBrowser.Cache.Length / (double) this.NumX) + 1 + 1];
      this.ItemID = 0;
      this.picCanvas.Invalidate();
    }

    private void cmdSearch_Click(object sender, EventArgs e)
    {
      int index1 = -1;
      int index2 = this.SelectedIndex == -1 ? 0 : this.SelectedIndex;
      while (index1 == -1 & index2 < NewStaticArtBrowser.Cache.Length - 1)
      {
        ++index2;
        if (Strings.InStr(NewStaticArtBrowser.Cache[index2].Name, this.txtSearch.Text, CompareMethod.Text) > 0)
          index1 = index2;
      }
      if (index1 != -1)
        this.ItemID = NewStaticArtBrowser.Cache[index1].ID;
      if (index1 == -1 & index2 > 0 && !this.SearchSomething)
      {
        this.SelectedIndex = 0;
        this.SearchSomething = true;
        this.cmdSearch_Click(RuntimeHelpers.GetObjectValue(sender), e);
      }
      this.vsbScroller.Value = this.SelectedIndex / this.NumX;
      this.vsbScroller_Scroll((object) this.vsbScroller, (ScrollEventArgs) null);
      this.SearchSomething = false;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    protected void DrawGrid(Graphics g)
    {
      int numX = this.NumX;
      for (int index = 0; index <= numX; ++index)
        g.DrawLine(Pens.Black, index * this.DisplaySize.Width, 0, index * this.DisplaySize.Width, (this.NumY + 1) * this.DisplaySize.Height);
      int num = this.NumY + 1;
      for (int index = 0; index <= num; ++index)
        g.DrawLine(Pens.Black, 0, index * this.DisplaySize.Height, this.NumX * this.DisplaySize.Width, index * this.DisplaySize.Height);
    }

    protected void DrawHover(Graphics g)
    {
      int x = this.HoverPos.X;
      int y = this.HoverPos.Y;
      int index = this.StartIndex + x + y * this.NumX;
      if (index >= NewStaticArtBrowser.Cache.Length)
        return;
      int id = NewStaticArtBrowser.Cache[index].ID;
      Bitmap bitmap = Art.GetStatic(id);
      Point point = new Point();
      point.X = (int) Math.Round((double) (x * this.DisplaySize.Width) + (double) this.DisplaySize.Width / 2.0) - (int) Math.Round((double) bitmap.Width / 2.0) - 3;
      if (point.X < 0)
        point.X = 0;
      if (point.X + bitmap.Width > this.picCanvas.Width)
        point.X = this.picCanvas.Width - bitmap.Width - 3;
      point.Y = (int) Math.Round((double) (y * this.DisplaySize.Height) + (double) this.DisplaySize.Height / 2.0) - (int) Math.Round((double) bitmap.Height / 2.0) - 3;
      if (point.Y < 0)
        point.Y = 0;
      if (point.Y + bitmap.Height > this.picCanvas.Height)
        point.Y = this.picCanvas.Height - bitmap.Height - 3;
      Rectangle rect = new Rectangle(point, bitmap.Size);
      SolidBrush solidBrush = new SolidBrush(Color.FromArgb((int) sbyte.MaxValue, Color.Black));
      g.FillRectangle((Brush) solidBrush, point.X + 5, point.Y + 5, rect.Width, rect.Height);
      g.FillRectangle(Brushes.White, rect);
      g.DrawRectangle(Pens.Black, rect);
      g.DrawImage((Image) bitmap, point);
      this.lblName.Text = "Name: " + TileData.ItemTable[id].Name;
      this.lblSize.Text = "Size: " + Conversions.ToString(bitmap.Width) + " x " + Conversions.ToString(bitmap.Height);
      this.lblID.Text = "ID: " + Conversions.ToString(id) + " - hex:" + Conversion.Hex(id);
      bitmap.Dispose();
      solidBrush.Dispose();
    }

    protected Bitmap GetRowImage(int Row)
    {
      if (Row >= NewStaticArtBrowser.RowCache.Length)
      {
        if (NewStaticArtBrowser.BlankCache != null)
          return NewStaticArtBrowser.BlankCache;
        Bitmap bitmap = new Bitmap(this.NumX * this.DisplaySize.Width, this.DisplaySize.Height, PixelFormat.Format16bppRgb565);
        Graphics graphics = Graphics.FromImage((Image) bitmap);
        graphics.Clear(Color.Gray);
        graphics.Dispose();
        NewStaticArtBrowser.BlankCache = bitmap;
        return bitmap;
      }
      if (NewStaticArtBrowser.RowCache[Row] != null)
        return NewStaticArtBrowser.RowCache[Row];
      Bitmap bitmap1 = new Bitmap(this.NumX * this.DisplaySize.Width, this.DisplaySize.Height, PixelFormat.Format16bppRgb565);
      Graphics graphics1 = Graphics.FromImage((Image) bitmap1);
      graphics1.Clear(Color.Gray);
      Region clip = graphics1.Clip;
      Rectangle rect = new Rectangle(0, 0, this.NumX * this.DisplaySize.Width, this.NumY * this.DisplaySize.Height);
      Region region1 = new Region(rect);
      graphics1.Clip = region1;
      int num = this.NumX - 1;
      for (int index1 = 0; index1 <= num; ++index1)
      {
        int index2 = Row * this.NumX + index1;
        if (index2 < NewStaticArtBrowser.Cache.Length)
        {
          Bitmap bitmap2 = Art.GetStatic(NewStaticArtBrowser.Cache[index2].ID);
          rect = new Rectangle(index1 * this.DisplaySize.Width, 0, this.DisplaySize.Width, this.DisplaySize.Height);
          Region region2 = new Region(rect);
          graphics1.Clip = region2;
          graphics1.FillRectangle(Brushes.White, index1 * this.DisplaySize.Width, 0, this.DisplaySize.Width, this.DisplaySize.Height);
          graphics1.DrawImage((Image) bitmap2, index1 * this.DisplaySize.Width + 1, 0);
          bitmap2.Dispose();
          region2.Dispose();
        }
      }
      graphics1.Clip = clip;
      graphics1.Dispose();
      NewStaticArtBrowser.RowCache[Row] = bitmap1;
      return bitmap1;
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (NewStaticArtBrowser));
      this.picCanvas = new PictureBox();
      this.vsbScroller = new VScrollBar();
      this.txtSearch = new TextBox();
      this.cmdSearch = new Button();
      this.lblName = new Label();
      this.lblSize = new Label();
      this.cmdCache = new Button();
      this.lblWait = new Label();
      this.ToolTip1 = new ToolTip(this.components);
      this.lblID = new Label();
      this.SuspendLayout();
      this.picCanvas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      Point point = new Point(0, 0);
      this.picCanvas.Location = point;
      this.picCanvas.Name = "picCanvas";
      Size size = new Size(488, 396);
      this.picCanvas.Size = size;
      this.picCanvas.TabIndex = 0;
      this.picCanvas.TabStop = false;
      this.vsbScroller.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      point = new Point(488, 0);
      this.vsbScroller.Location = point;
      this.vsbScroller.Name = "vsbScroller";
      size = new Size(17, 396);
      this.vsbScroller.Size = size;
      this.vsbScroller.TabIndex = 3;
      this.txtSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      point = new Point(56, 403);
      this.txtSearch.Location = point;
      this.txtSearch.Name = "txtSearch";
      size = new Size(100, 20);
      this.txtSearch.Size = size;
      this.txtSearch.TabIndex = 4;
      this.cmdSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      point = new Point(160, 403);
      this.cmdSearch.Location = point;
      this.cmdSearch.Name = "cmdSearch";
      size = new Size(50, 20);
      this.cmdSearch.Size = size;
      this.cmdSearch.TabIndex = 5;
      this.cmdSearch.Text = "Search";
      this.lblName.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.lblName.AutoSize = true;
      point = new Point(216, 405);
      this.lblName.Location = point;
      this.lblName.Name = "lblName";
      size = new Size(38, 13);
      this.lblName.Size = size;
      this.lblName.TabIndex = 6;
      this.lblName.Text = "Name:";
      this.lblSize.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.lblSize.AutoSize = true;
      point = new Point(408, 405);
      this.lblSize.Location = point;
      this.lblSize.Name = "lblSize";
      size = new Size(30, 13);
      this.lblSize.Size = size;
      this.lblSize.TabIndex = 7;
      this.lblSize.Text = "Size:";
      this.cmdCache.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.cmdCache.FlatStyle = FlatStyle.Flat;
      this.cmdCache.Image = (Image) componentResourceManager.GetObject("cmdCache.Image");
      point = new Point(0, 402);
      this.cmdCache.Location = point;
      this.cmdCache.Name = "cmdCache";
      size = new Size(32, 23);
      this.cmdCache.Size = size;
      this.cmdCache.TabIndex = 9;
      this.ToolTip1.SetToolTip((Control) this.cmdCache, "Rebuild Art Cache");
      this.lblWait.BackColor = Color.Transparent;
      this.lblWait.BorderStyle = BorderStyle.Fixed3D;
      this.lblWait.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      point = new Point(164, 159);
      this.lblWait.Location = point;
      this.lblWait.Name = "lblWait";
      size = new Size(184, 104);
      this.lblWait.Size = size;
      this.lblWait.TabIndex = 10;
      this.lblWait.Text = "Please Wait, Generating Static Art Cache...";
      this.lblWait.TextAlign = ContentAlignment.MiddleCenter;
      this.lblWait.Visible = false;
      this.lblID.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.lblID.AutoSize = true;
      point = new Point(216, 429);
      this.lblID.Location = point;
      this.lblID.Name = "lblID";
      size = new Size(21, 13);
      this.lblID.Size = size;
      this.lblID.TabIndex = 11;
      this.lblID.Text = "ID:";
      size = new Size(5, 13);
      this.AutoScaleBaseSize = size;
      size = new Size(505, 451);
      this.ClientSize = size;
      this.Controls.Add((Control) this.lblID);
      this.Controls.Add((Control) this.lblWait);
      this.Controls.Add((Control) this.cmdCache);
      this.Controls.Add((Control) this.lblSize);
      this.Controls.Add((Control) this.lblName);
      this.Controls.Add((Control) this.cmdSearch);
      this.Controls.Add((Control) this.txtSearch);
      this.Controls.Add((Control) this.vsbScroller);
      this.Controls.Add((Control) this.picCanvas);
      this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
      size = new Size(521, 3000);
      this.MaximumSize = size;
      size = new Size(521, 200);
      this.MinimumSize = size;
      this.Name = nameof (NewStaticArtBrowser);
      this.SizeGripStyle = SizeGripStyle.Hide;
      this.Text = "Static Art Browser";
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void NewStaticArtBrowser_Load(object sender, EventArgs e)
    {
      if (NewStaticArtBrowser.Cache == null)
      {
        FileStream fileStream = (FileStream) null;
        if (!File.Exists(Application.StartupPath + "/StaticArt.cache"))
        {
          this.BuildCache();
        }
        else
        {
          try
          {
            fileStream = new FileStream(Application.StartupPath + "/StaticArt.cache", FileMode.Open);
            NewStaticArtBrowser.Cache = (GumpCacheEntry[]) new BinaryFormatter().Deserialize((Stream) fileStream);
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            int num = (int) Interaction.MsgBox((object) ("Error reading cache file:\r\n" + ex.Message), MsgBoxStyle.OkOnly, (object) null);
            ProjectData.ClearProjectError();
          }
          finally
          {
            fileStream?.Close();
          }
        }
      }
      this.picCanvas.Width = this.ClientSize.Width - this.vsbScroller.Width;
      this.Show();
      this.vsbScroller.Maximum = (int) Math.Round((double) NewStaticArtBrowser.Cache.Length / (double) this.NumX) + 1;
      this.vsbScroller.LargeChange = this.NumY - 1;
      if (NewStaticArtBrowser.RowCache == null)
        NewStaticArtBrowser.RowCache = new Bitmap[(int) Math.Round((double) NewStaticArtBrowser.Cache.Length / (double) this.NumX) + 1 + 1];
      this.vsbScroller.Value = this.SelectedIndex / this.NumX;
      this.vsbScroller_Scroll((object) this.vsbScroller, (ScrollEventArgs) null);
      this.lblName.Text = "Name: " + TileData.ItemTable[NewStaticArtBrowser.Cache[this.SelectedIndex].ID].Name;
      this.lblSize.Text = "Size: " + Conversions.ToString(NewStaticArtBrowser.Cache[this.SelectedIndex].Size.Width) + " x " + Conversions.ToString(NewStaticArtBrowser.Cache[this.SelectedIndex].Size.Height);
    }

    private void NewStaticArtBrowser_Resize(object sender, EventArgs e)
    {
      int num1 = 11;
      int num2 = this.picCanvas.Height / this.DisplaySize.Height;
      if (!(num1 != this.NumX | num2 != this.NumY))
        return;
      this.NumX = num1;
      this.NumY = num2;
      if (NewStaticArtBrowser.Cache == null)
        return;
      this.vsbScroller.Maximum = (int) Math.Round((double) NewStaticArtBrowser.Cache.Length / (double) this.NumX) + 1;
      this.vsbScroller.LargeChange = this.NumY - 1;
      this.picCanvas.Invalidate();
    }

    private void picCanvas_DoubleClick(object sender, EventArgs e)
    {
      if (this.BuildingCache)
        return;
      this.DialogResult = DialogResult.OK;
    }

    private void picCanvas_MouseLeave(object sender, EventArgs e)
    {
      this.HoverPos = new Point(-1, -1);
      this.picCanvas.Invalidate();
      this.lblName.Text = "Name: " + TileData.ItemTable[NewStaticArtBrowser.Cache[this.SelectedIndex].ID].Name;
      this.lblSize.Text = "Size: " + Conversions.ToString(NewStaticArtBrowser.Cache[this.SelectedIndex].Size.Width) + " x " + Conversions.ToString(NewStaticArtBrowser.Cache[this.SelectedIndex].Size.Height);
      this.lblID.Text = "ID: " + Conversions.ToString(NewStaticArtBrowser.Cache[this.SelectedIndex].ID) + "(0x" + Conversion.Hex(NewStaticArtBrowser.Cache[this.SelectedIndex].ID) + ")";
    }

    private void picCanvas_MouseMove(object sender, MouseEventArgs e)
    {
      Point point = new Point(e.X / this.DisplaySize.Width, e.Y / this.DisplaySize.Height);
      if (point.X >= 11 || !(point.X != this.HoverPos.X | point.Y != this.HoverPos.Y))
        return;
      this.HoverPos = point;
      this.picCanvas.Invalidate();
    }

    private void picCanvas_MouseUp(object sender, MouseEventArgs e)
    {
      int index = e.X / this.DisplaySize.Width + e.Y / this.DisplaySize.Height * this.NumX + this.StartIndex;
      if (index >= NewStaticArtBrowser.Cache.Length)
        return;
      this.ItemID = NewStaticArtBrowser.Cache[index].ID;
      this.picCanvas.Invalidate();
    }

    private void picCanvas_Paint(object sender, PaintEventArgs e)
    {
      try
      {
        this.Render(e.Graphics);
        if (this.HoverPos.Equals((object) new Point(-1, -1)))
          return;
        this.DrawHover(e.Graphics);
      }
      catch (Exception ex)
      {
      }
    }

    public void Render(Graphics g)
    {
      if (NewStaticArtBrowser.Cache == null | NewStaticArtBrowser.RowCache == null)
        return;
      Rectangle rect = new Rectangle();
      g.Clear(Color.Gray);
      this.DrawGrid(g);
      Region clip = g.Clip;
      int num = this.StartIndex / this.NumX;
      bool flag = false;
      int numY = this.NumY;
      for (int index = 0; index <= numY; ++index)
      {
        g.DrawImage((Image) this.GetRowImage(index + num), 0, index * this.DisplaySize.Height);
        if ((flag || index + num != this.SelectedIndex / this.NumX ? 0 : 1) != 0)
        {
          flag = true;
          rect = new Rectangle(this.SelectedIndex % this.NumX * this.DisplaySize.Width, index * this.DisplaySize.Height, this.DisplaySize.Width, this.DisplaySize.Height);
        }
      }
      this.DrawGrid(g);
      if (flag)
      {
        Region region = new Region(rect);
        rect.Inflate(5, 5);
        SolidBrush solidBrush = new SolidBrush(Color.FromArgb((int) sbyte.MaxValue, Color.Blue));
        g.FillRectangle((Brush) solidBrush, rect);
        g.DrawRectangle(Pens.Blue, rect);
        solidBrush.Dispose();
        rect.Inflate(-5, -5);
        g.Clip = region;
        g.DrawImage((Image) Art.GetStatic(NewStaticArtBrowser.Cache[this.SelectedIndex].ID), rect.Location);
        g.Clip = clip;
        region.Dispose();
      }
      g.Clip = clip;
    }

    private void vsbScroller_Scroll(object sender, ScrollEventArgs e)
    {
      this.StartIndex = this.vsbScroller.Value * this.NumX;
      this.picCanvas.Invalidate();
    }
  }
}
