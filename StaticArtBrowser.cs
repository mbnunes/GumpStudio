// Decompiled with JetBrains decompiler
// Type: GumpStudio.StaticArtBrowser
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
using System.IO;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Ultima;

namespace GumpStudio
{
  public class StaticArtBrowser : Form
  {
    private static List<WeakReference> __ENCList = new List<WeakReference>();
    [AccessedThroughProperty("cmdCache")]
    private Button _cmdCache;
    [AccessedThroughProperty("cmdOK")]
    private Button _cmdOK;
    [AccessedThroughProperty("cmdSearch")]
    private Button _cmdSearch;
    [AccessedThroughProperty("lblName")]
    private Label _lblName;
    [AccessedThroughProperty("lblSize")]
    private Label _lblSize;
    [AccessedThroughProperty("lblWait")]
    private Label _lblWait;
    [AccessedThroughProperty("lstStatic")]
    private ListBox _lstStatic;
    [AccessedThroughProperty("Panel1")]
    private Panel _Panel1;
    [AccessedThroughProperty("picFullSize")]
    private PictureBox _picFullSize;
    [AccessedThroughProperty("ToolTip1")]
    private ToolTip _ToolTip1;
    [AccessedThroughProperty("txtSearch")]
    private TextBox _txtSearch;
    protected static GumpCacheEntry[] Cache;
    private IContainer components;
    public int ItemID;

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

    internal virtual Button cmdOK
    {
      [DebuggerNonUserCode] get
      {
        return this._cmdOK;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cmdOK_Click);
        if (this._cmdOK != null)
          this._cmdOK.Click -= eventHandler;
        this._cmdOK = value;
        if (this._cmdOK == null)
          return;
        this._cmdOK.Click += eventHandler;
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

    internal virtual ListBox lstStatic
    {
      [DebuggerNonUserCode] get
      {
        return this._lstStatic;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.lstGump_SelectedIndexChanged);
        EventHandler eventHandler2 = new EventHandler(this.lstGump_DoubleClick);
        DrawItemEventHandler itemEventHandler1 = new DrawItemEventHandler(this.lstGump_DrawItem);
        MeasureItemEventHandler itemEventHandler2 = new MeasureItemEventHandler(this.lstStatic_MeasureItem);
        if (this._lstStatic != null)
        {
          this._lstStatic.SelectedIndexChanged -= eventHandler1;
          this._lstStatic.DoubleClick -= eventHandler2;
          this._lstStatic.DrawItem -= itemEventHandler1;
          this._lstStatic.MeasureItem -= itemEventHandler2;
        }
        this._lstStatic = value;
        if (this._lstStatic == null)
          return;
        this._lstStatic.SelectedIndexChanged += eventHandler1;
        this._lstStatic.DoubleClick += eventHandler2;
        this._lstStatic.DrawItem += itemEventHandler1;
        this._lstStatic.MeasureItem += itemEventHandler2;
      }
    }

    internal virtual Panel Panel1
    {
      [DebuggerNonUserCode] get
      {
        return this._Panel1;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Panel1 = value;
      }
    }

    internal virtual PictureBox picFullSize
    {
      [DebuggerNonUserCode] get
      {
        return this._picFullSize;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._picFullSize = value;
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

    public StaticArtBrowser()
    {
      this.Load += new EventHandler(this.GumpArtBrowser_Load);
      lock (StaticArtBrowser.__ENCList)
        StaticArtBrowser.__ENCList.Add(new WeakReference((object) this));
      this.InitializeComponent();
    }

    protected void BuildCache()
    {
      this.lblWait.Text = "Please Wait, Generating Art Cache...";
      this.Show();
      FileStream fileStream = (FileStream) null;
      try
      {
        StaticArtBrowser.Cache = (GumpCacheEntry[]) null;
        this.lstStatic.Items.Clear();
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
            StaticArtBrowser.Cache = StaticArtBrowser.Cache != null ? (GumpCacheEntry[]) Utils.CopyArray((Array) StaticArtBrowser.Cache, (Array) new GumpCacheEntry[StaticArtBrowser.Cache.Length + 1]) : new GumpCacheEntry[1];
            StaticArtBrowser.Cache[StaticArtBrowser.Cache.Length - 1] = new GumpCacheEntry();
            StaticArtBrowser.Cache[StaticArtBrowser.Cache.Length - 1].ID = index;
            StaticArtBrowser.Cache[StaticArtBrowser.Cache.Length - 1].Size = bitmap.Size;
            StaticArtBrowser.Cache[StaticArtBrowser.Cache.Length - 1].Name = TileData.ItemTable[index].Name;
          }
        }
        fileStream = new FileStream(Application.StartupPath + "/StaticArt.cache", FileMode.Create);
        new BinaryFormatter().Serialize((Stream) fileStream, (object) StaticArtBrowser.Cache);
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
      }
    }

    private void cmdCache_Click(object sender, EventArgs e)
    {
      this.cmdOK.Enabled = false;
      if (Interaction.MsgBox((object) "Rebuilding the cache may take several minutes debending on the speed of your computer.\r\nAre you sure you want to continue?", MsgBoxStyle.YesNo | MsgBoxStyle.Information, (object) "Rebuild Cache") == MsgBoxResult.Yes)
      {
        this.BuildCache();
        this.PopulateListbox();
      }
      this.cmdOK.Enabled = true;
    }

    private void cmdOK_Click(object sender, EventArgs e)
    {
      this.ItemID = StaticArtBrowser.Cache[this.lstStatic.SelectedIndex].ID;
      this.DialogResult = DialogResult.OK;
    }

    private void cmdSearch_Click(object sender, EventArgs e)
    {
      int num = -1;
      int index = this.lstStatic.SelectedIndex == -1 ? 0 : this.lstStatic.SelectedIndex;
      while (num == -1 & index < StaticArtBrowser.Cache.Length - 1)
      {
        ++index;
        if (Strings.InStr(StaticArtBrowser.Cache[index].Name, this.txtSearch.Text, CompareMethod.Text) > 0)
          num = index;
      }
      if (num != -1)
      {
        this.lstStatic.SelectedIndex = num;
        this.ItemID = num;
      }
      if (!(num == -1 & index > 0))
        return;
      this.lstStatic.SelectedIndex = 0;
      this.cmdSearch_Click(RuntimeHelpers.GetObjectValue(sender), e);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void GumpArtBrowser_Load(object sender, EventArgs e)
    {
      if (StaticArtBrowser.Cache == null)
      {
        if (!File.Exists(Application.StartupPath + "/StaticArt.cache"))
        {
          this.BuildCache();
        }
        else
        {
          try
          {
            StaticArtBrowser.Cache = (GumpCacheEntry[]) new BinaryFormatter().Deserialize((Stream) new FileStream(Application.StartupPath + "/StaticArt.cache", FileMode.Open));
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            int num = (int) Interaction.MsgBox((object) ("Error Reading cache file:\r\n" + ex.Message), MsgBoxStyle.OkOnly, (object) null);
            ProjectData.ClearProjectError();
          }
        }
      }
      this.PopulateListbox();
      this.picFullSize.Image = (Image) Art.GetStatic(this.ItemID);
      this.lblName.Text = "Name: " + TileData.ItemTable[this.ItemID].Name;
      this.lblSize.Text = "Size: " + Conversions.ToString(this.picFullSize.Image.Width) + " x " + Conversions.ToString(this.picFullSize.Image.Height);
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      ResourceManager resourceManager = new ResourceManager(typeof (StaticArtBrowser));
      this.lstStatic = new ListBox();
      this.Panel1 = new Panel();
      this.lblSize = new Label();
      this.lblName = new Label();
      this.picFullSize = new PictureBox();
      this.lblWait = new Label();
      this.cmdCache = new Button();
      this.ToolTip1 = new ToolTip(this.components);
      this.cmdOK = new Button();
      this.txtSearch = new TextBox();
      this.cmdSearch = new Button();
      this.Panel1.SuspendLayout();
      this.SuspendLayout();
      this.lstStatic.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.lstStatic.DrawMode = DrawMode.OwnerDrawVariable;
      this.lstStatic.IntegralHeight = false;
      Point point = new Point(8, 8);
      this.lstStatic.Location = point;
      this.lstStatic.Name = "lstStatic";
      Size size = new Size(184, 320);
      this.lstStatic.Size = size;
      this.lstStatic.TabIndex = 0;
      this.Panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.Panel1.AutoScroll = true;
      this.Panel1.BackColor = Color.Black;
      this.Panel1.BorderStyle = BorderStyle.Fixed3D;
      this.Panel1.Controls.Add((Control) this.lblSize);
      this.Panel1.Controls.Add((Control) this.lblName);
      this.Panel1.Controls.Add((Control) this.picFullSize);
      point = new Point(200, 8);
      this.Panel1.Location = point;
      this.Panel1.Name = "Panel1";
      size = new Size(312, 288);
      this.Panel1.Size = size;
      this.Panel1.TabIndex = 1;
      this.lblSize.AutoSize = true;
      this.lblSize.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblSize.ForeColor = Color.White;
      point = new Point(8, 256);
      this.lblSize.Location = point;
      this.lblSize.Name = "lblSize";
      size = new Size(32, 17);
      this.lblSize.Size = size;
      this.lblSize.TabIndex = 5;
      this.lblSize.Text = "Size:";
      this.lblName.AutoSize = true;
      this.lblName.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblName.ForeColor = Color.White;
      point = new Point(8, 224);
      this.lblName.Location = point;
      this.lblName.Name = "lblName";
      size = new Size(41, 17);
      this.lblName.Size = size;
      this.lblName.TabIndex = 7;
      this.lblName.Text = "Name:";
      point = new Point(0, 0);
      this.picFullSize.Location = point;
      this.picFullSize.Name = "picFullSize";
      this.picFullSize.SizeMode = PictureBoxSizeMode.AutoSize;
      this.picFullSize.TabIndex = 0;
      this.picFullSize.TabStop = false;
      this.lblWait.BackColor = Color.Transparent;
      this.lblWait.BorderStyle = BorderStyle.Fixed3D;
      this.lblWait.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      point = new Point(168, 115);
      this.lblWait.Location = point;
      this.lblWait.Name = "lblWait";
      size = new Size(184, 104);
      this.lblWait.Size = size;
      this.lblWait.TabIndex = 1;
      this.lblWait.Text = "Please Wait, Generating Static Art Cache...";
      this.lblWait.TextAlign = ContentAlignment.MiddleCenter;
      this.lblWait.Visible = false;
      this.cmdCache.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.cmdCache.FlatStyle = FlatStyle.Flat;
      this.cmdCache.Image = (Image) resourceManager.GetObject("cmdCache.Image");
      point = new Point(480, 304);
      this.cmdCache.Location = point;
      this.cmdCache.Name = "cmdCache";
      size = new Size(32, 23);
      this.cmdCache.Size = size;
      this.cmdCache.TabIndex = 3;
      this.ToolTip1.SetToolTip((Control) this.cmdCache, "Rebuild Cache");
      this.cmdOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.cmdOK.FlatStyle = FlatStyle.System;
      point = new Point(400, 304);
      this.cmdOK.Location = point;
      this.cmdOK.Name = "cmdOK";
      this.cmdOK.TabIndex = 4;
      this.cmdOK.Text = "OK";
      this.txtSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      point = new Point(200, 304);
      this.txtSearch.Location = point;
      this.txtSearch.Name = "txtSearch";
      size = new Size(136, 20);
      this.txtSearch.Size = size;
      this.txtSearch.TabIndex = 5;
      this.txtSearch.Text = "";
      this.cmdSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      point = new Point(336, 304);
      this.cmdSearch.Location = point;
      this.cmdSearch.Name = "cmdSearch";
      size = new Size(48, 23);
      this.cmdSearch.Size = size;
      this.cmdSearch.TabIndex = 6;
      this.cmdSearch.Text = "Search";
      this.AcceptButton = (IButtonControl) this.cmdOK;
      size = new Size(5, 13);
      this.AutoScaleBaseSize = size;
      size = new Size(520, 334);
      this.ClientSize = size;
      this.Controls.Add((Control) this.cmdSearch);
      this.Controls.Add((Control) this.txtSearch);
      this.Controls.Add((Control) this.cmdOK);
      this.Controls.Add((Control) this.cmdCache);
      this.Controls.Add((Control) this.lblWait);
      this.Controls.Add((Control) this.Panel1);
      this.Controls.Add((Control) this.lstStatic);
      this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
      this.Name = nameof (StaticArtBrowser);
      this.Text = "GumpID Browser";
      this.Panel1.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    private void lstGump_DoubleClick(object sender, EventArgs e)
    {
      this.ItemID = StaticArtBrowser.Cache[this.lstStatic.SelectedIndex].ID;
      this.DialogResult = DialogResult.OK;
    }

    private void lstGump_DrawItem(object sender, DrawItemEventArgs e)
    {
      try
      {
        if (e.Index == -1)
          return;
        Graphics graphics = e.Graphics;
        Bitmap bitmap = Art.GetStatic(StaticArtBrowser.Cache[e.Index].ID);
        if (bitmap == null)
          return;
        Size size1 = new Size();
        Size size2 = StaticArtBrowser.Cache[e.Index].Size;
        size1.Width = size2.Width <= 100 ? size2.Width : 100;
        size1.Height = size2.Height <= 100 ? size2.Height : 100;
        Rectangle rect = new Rectangle(e.Bounds.Location, size1);
        rect.Offset(45, 3);
        if ((e.State & DrawItemState.Selected) > DrawItemState.None)
          graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
        else
          graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
        graphics.DrawString(StaticArtBrowser.Cache[e.Index].ID.ToString(), this.Font, SystemBrushes.WindowText, (float) e.Bounds.X, (float) e.Bounds.Y);
        graphics.DrawImage((Image) bitmap, rect);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    private void lstGump_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.picFullSize.Image != null)
      {
        Image image = this.picFullSize.Image;
      }
      this.ItemID = StaticArtBrowser.Cache[this.lstStatic.SelectedIndex].ID;
      this.picFullSize.Image = (Image) Art.GetStatic(this.ItemID);
      this.lblName.Text = "Name: " + TileData.ItemTable[this.ItemID].Name;
      this.lblSize.Text = "Size: " + Conversions.ToString(this.picFullSize.Image.Width) + " x " + Conversions.ToString(this.picFullSize.Image.Height);
    }

    private void lstStatic_MeasureItem(object sender, MeasureItemEventArgs e)
    {
      int height = StaticArtBrowser.Cache[e.Index].Size.Height;
      int num = height <= 100 ? height : 100;
      e.ItemHeight = num + 5;
    }

    private void PopulateListbox()
    {
      this.lstStatic.Items.Clear();
      this.lstStatic.Items.AddRange((object[]) StaticArtBrowser.Cache);
      this.lstStatic.SelectedItem = (object) this.ItemID;
    }
  }
}
