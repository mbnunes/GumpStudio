// Decompiled with JetBrains decompiler
// Type: GumpStudio.GumpArtBrowser
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
  public class GumpArtBrowser : Form
  {
    private static List<WeakReference> __ENCList = new List<WeakReference>();
    [AccessedThroughProperty("cmdCache")]
    private Button _cmdCache;
    [AccessedThroughProperty("cmdOK")]
    private Button _cmdOK;
    [AccessedThroughProperty("lblSize")]
    private Label _lblSize;
    [AccessedThroughProperty("lblWait")]
    private Label _lblWait;
    [AccessedThroughProperty("lstGump")]
    private ListBox _lstGump;
    [AccessedThroughProperty("Panel1")]
    private Panel _Panel1;
    [AccessedThroughProperty("picFullSize")]
    private PictureBox _picFullSize;
    [AccessedThroughProperty("ToolTip1")]
    private ToolTip _ToolTip1;
    protected static GumpCacheEntry[] Cache;
    private IContainer components;
    public int GumpID;

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

    internal virtual ListBox lstGump
    {
      [DebuggerNonUserCode] get
      {
        return this._lstGump;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MeasureItemEventHandler itemEventHandler1 = new MeasureItemEventHandler(this.lstGump_MeasureItem);
        EventHandler eventHandler1 = new EventHandler(this.lstGump_SelectedIndexChanged);
        EventHandler eventHandler2 = new EventHandler(this.lstGump_DoubleClick);
        DrawItemEventHandler itemEventHandler2 = new DrawItemEventHandler(this.lstGump_DrawItem);
        if (this._lstGump != null)
        {
          this._lstGump.MeasureItem -= itemEventHandler1;
          this._lstGump.SelectedIndexChanged -= eventHandler1;
          this._lstGump.DoubleClick -= eventHandler2;
          this._lstGump.DrawItem -= itemEventHandler2;
        }
        this._lstGump = value;
        if (this._lstGump == null)
          return;
        this._lstGump.MeasureItem += itemEventHandler1;
        this._lstGump.SelectedIndexChanged += eventHandler1;
        this._lstGump.DoubleClick += eventHandler2;
        this._lstGump.DrawItem += itemEventHandler2;
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

    public GumpArtBrowser()
    {
      this.Load += new EventHandler(this.GumpArtBrowser_Load);
      lock (GumpArtBrowser.__ENCList)
        GumpArtBrowser.__ENCList.Add(new WeakReference((object) this));
      this.InitializeComponent();
    }

    protected void BuildCache()
    {
      this.lblWait.Text = "Please Wait, Generating Art Cache...";
      this.Show();
      GumpArtBrowser.Cache = (GumpCacheEntry[]) null;
      this.lstGump.Items.Clear();
      this.lblWait.Visible = true;
      Application.DoEvents();
      int index = 0;
      int maxValue = (int) ushort.MaxValue;
      try
      {
        do
        {
          this.lblWait.Text = "Please Wait, Generating Art Cache...  " + Strings.Format((object) (int) ((double) (100 * index) / (double) maxValue), "Fixed") + "%";
          Application.DoEvents();
          Bitmap gump;
          try
          {
            gump = Gumps.GetGump(index);
          }
          catch (Exception ex)
          {
            ++index;
            goto label_7;
          }
          if (gump != null)
          {
            GumpArtBrowser.Cache = GumpArtBrowser.Cache != null ? (GumpCacheEntry[]) Utils.CopyArray((Array) GumpArtBrowser.Cache, (Array) new GumpCacheEntry[GumpArtBrowser.Cache.Length + 1]) : new GumpCacheEntry[1];
            GumpArtBrowser.Cache[GumpArtBrowser.Cache.Length - 1] = new GumpCacheEntry();
            GumpArtBrowser.Cache[GumpArtBrowser.Cache.Length - 1].ID = index;
            GumpArtBrowser.Cache[GumpArtBrowser.Cache.Length - 1].Size = gump.Size;
            gump.Dispose();
          }
          ++index;
label_7:;
        }
        while (index <= maxValue);
        using (FileStream fileStream = new FileStream(Application.StartupPath + "/GumpArt.cache", FileMode.Create))
          new BinaryFormatter().Serialize((Stream) fileStream, (object) GumpArtBrowser.Cache);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) Interaction.MsgBox((object) ("Error creating cache file:\r\n" + ex.Message), MsgBoxStyle.OkOnly, (object) null);
        ProjectData.ClearProjectError();
      }
      finally
      {
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
      this.GumpID = Conversions.ToInteger(this.lstGump.SelectedItem);
      this.DialogResult = DialogResult.OK;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void GumpArtBrowser_Load(object sender, EventArgs e)
    {
      if (GumpArtBrowser.Cache == null)
      {
        FileStream fileStream = (FileStream) null;
        if (!File.Exists(Application.StartupPath + "/GumpArt.cache"))
        {
          this.BuildCache();
        }
        else
        {
          try
          {
            fileStream = new FileStream(Application.StartupPath + "/GumpArt.cache", FileMode.Open);
            GumpArtBrowser.Cache = (GumpCacheEntry[]) new BinaryFormatter().Deserialize((Stream) fileStream);
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            int num = (int) Interaction.MsgBox((object) ("Error Reading cache file:\r\n" + ex.Message), MsgBoxStyle.OkOnly, (object) null);
            ProjectData.ClearProjectError();
          }
          finally
          {
            fileStream?.Close();
          }
        }
      }
      this.PopulateListbox();
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      ResourceManager resourceManager = new ResourceManager(typeof (GumpArtBrowser));
      this.lstGump = new ListBox();
      this.Panel1 = new Panel();
      this.picFullSize = new PictureBox();
      this.lblSize = new Label();
      this.lblWait = new Label();
      this.cmdCache = new Button();
      this.ToolTip1 = new ToolTip(this.components);
      this.cmdOK = new Button();
      this.Panel1.SuspendLayout();
      this.SuspendLayout();
      this.lstGump.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.lstGump.DrawMode = DrawMode.OwnerDrawVariable;
      this.lstGump.IntegralHeight = false;
      this.lstGump.Location = new Point(8, 8);
      this.lstGump.Name = "lstGump";
      this.lstGump.Size = new Size(184, 320);
      this.lstGump.TabIndex = 0;
      this.Panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.Panel1.AutoScroll = true;
      this.Panel1.BackColor = Color.Black;
      this.Panel1.BorderStyle = BorderStyle.Fixed3D;
      this.Panel1.Controls.Add((Control) this.picFullSize);
      this.Panel1.Location = new Point(200, 8);
      this.Panel1.Name = "Panel1";
      this.Panel1.Size = new Size(312, 288);
      this.Panel1.TabIndex = 1;
      this.picFullSize.Location = new Point(0, 0);
      this.picFullSize.Name = "picFullSize";
      this.picFullSize.SizeMode = PictureBoxSizeMode.AutoSize;
      this.picFullSize.TabIndex = 0;
      this.picFullSize.TabStop = false;
      this.lblSize.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblSize.AutoSize = true;
      this.lblSize.Location = new Point(200, 307);
      this.lblSize.Name = "lblSize";
      this.lblSize.Size = new Size(0, 16);
      this.lblSize.TabIndex = 2;
      this.lblWait.BackColor = Color.Transparent;
      this.lblWait.BorderStyle = BorderStyle.Fixed3D;
      this.lblWait.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblWait.Location = new Point(168, 131);
      this.lblWait.Name = "lblWait";
      this.lblWait.Size = new Size(184, 72);
      this.lblWait.TabIndex = 1;
      this.lblWait.Text = "Please Wait, Generating Art Cache...";
      this.lblWait.TextAlign = ContentAlignment.MiddleCenter;
      this.lblWait.Visible = false;
      this.cmdCache.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.cmdCache.FlatStyle = FlatStyle.Flat;
      this.cmdCache.Image = (Image) resourceManager.GetObject("cmdCache.Image");
      this.cmdCache.Location = new Point(480, 304);
      this.cmdCache.Name = "cmdCache";
      this.cmdCache.Size = new Size(32, 23);
      this.cmdCache.TabIndex = 3;
      this.ToolTip1.SetToolTip((Control) this.cmdCache, "Rebuild Cache");
      this.cmdOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.cmdOK.FlatStyle = FlatStyle.System;
      this.cmdOK.Location = new Point(400, 304);
      this.cmdOK.Name = "cmdOK";
      this.cmdOK.TabIndex = 4;
      this.cmdOK.Text = "OK";
      this.AcceptButton = (IButtonControl) this.cmdOK;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.ClientSize = new Size(520, 334);
      this.Controls.Add((Control) this.cmdOK);
      this.Controls.Add((Control) this.cmdCache);
      this.Controls.Add((Control) this.lblWait);
      this.Controls.Add((Control) this.lblSize);
      this.Controls.Add((Control) this.Panel1);
      this.Controls.Add((Control) this.lstGump);
      this.Name = nameof (GumpArtBrowser);
      this.Text = "GumpID Browser";
      this.Panel1.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    private void lstGump_DoubleClick(object sender, EventArgs e)
    {
      this.GumpID = Conversions.ToInteger(this.lstGump.SelectedItem);
      this.DialogResult = DialogResult.OK;
    }

    private void lstGump_DrawItem(object sender, DrawItemEventArgs e)
    {
      try
      {
        if (e.Index == -1)
          return;
        Size size1 = new Size();
        Graphics graphics = e.Graphics;
        Bitmap gump = Gumps.GetGump(GumpArtBrowser.Cache[e.Index].ID);
        Size size2 = GumpArtBrowser.Cache[e.Index].Size;
        size1.Width = size2.Width <= 100 ? size2.Width : 100;
        size1.Height = size2.Height <= 100 ? size2.Height : 100;
        Rectangle rect = new Rectangle(e.Bounds.Location, size1);
        rect.Offset(45, 3);
        if ((e.State & DrawItemState.Selected) > DrawItemState.None)
          graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
        else
          graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
        graphics.DrawString("0x" + GumpArtBrowser.Cache[e.Index].ID.ToString("X"), this.Font, SystemBrushes.WindowText, (float) e.Bounds.X, (float) e.Bounds.Y);
        graphics.DrawImage((Image) gump, rect);
        gump.Dispose();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) Interaction.MsgBox((object) ("There was an error rendering the gump art, try rebuilding the cache.\r\n\r\n" + ex.Message), MsgBoxStyle.OkOnly, (object) null);
        ProjectData.ClearProjectError();
      }
    }

    private void lstGump_MeasureItem(object sender, MeasureItemEventArgs e)
    {
      int height = GumpArtBrowser.Cache[e.Index].Size.Height;
      int num = height <= 100 ? (height >= 15 ? height : 15) : 100;
      e.ItemHeight = num + 5;
    }

    private void lstGump_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.picFullSize.Image != null)
        this.picFullSize.Image.Dispose();
      this.picFullSize.Image = (Image) Gumps.GetGump(Conversions.ToInteger(this.lstGump.SelectedItem));
      this.lblSize.Text = "Width: " + Conversions.ToString(this.picFullSize.Image.Width) + "   Height: " + Conversions.ToString(this.picFullSize.Image.Height);
    }

    private void PopulateListbox()
    {
      this.lstGump.Items.Clear();
      foreach (GumpCacheEntry gumpCacheEntry in GumpArtBrowser.Cache)
        this.lstGump.Items.Add((object) gumpCacheEntry.ID);
      this.lstGump.SelectedItem = (object) this.GumpID;
    }
  }
}
