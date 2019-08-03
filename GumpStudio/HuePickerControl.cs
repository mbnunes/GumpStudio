// Decompiled with JetBrains decompiler
// Type: GumpStudio.HuePickerControl
// Assembly: GumpStudioCore, Version=1.8.3024.24259, Culture=neutral, PublicKeyToken=null
// MVID: A77D32E5-7519-4865-AA26-DCCB34429732
// Assembly location: C:\GumpStudio_1_8_R3_quinted-02\GumpStudioCore.dll

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Ultima;

namespace GumpStudio
{
  public class HuePickerControl : UserControl
  {
    private static List<WeakReference> __ENCList = new List<WeakReference>();
    [AccessedThroughProperty("cboQuick")]
    private ComboBox _cboQuick;
    [AccessedThroughProperty("lstHue")]
    private ListBox _lstHue;
    [AccessedThroughProperty("StatusBar")]
    private StatusBar _StatusBar;
    [AccessedThroughProperty("ToolTip1")]
    private ToolTip _ToolTip1;
    private IContainer components;
    protected Hue mHue;

    internal virtual ComboBox cboQuick
    {
      [DebuggerNonUserCode] get => this._cboQuick;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboQuick_SelectedIndexChanged);
        if (this._cboQuick != null)
          this._cboQuick.SelectedIndexChanged -= eventHandler;
        this._cboQuick = value;
        if (this._cboQuick == null)
          return;
        this._cboQuick.SelectedIndexChanged += eventHandler;
      }
    }

    public Hue Hue
    {
      get => this.mHue;
      set => this.mHue = value;
    }

    internal virtual ListBox lstHue
    {
      [DebuggerNonUserCode] get => this._lstHue;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.lstHue_DoubleClick);
        EventHandler eventHandler2 = new EventHandler(this.lstHue_SelectedIndexChanged);
        DrawItemEventHandler itemEventHandler = new DrawItemEventHandler(this.lstHue_DrawItem);
        if (this._lstHue != null)
        {
          this._lstHue.DoubleClick -= eventHandler1;
          this._lstHue.SelectedIndexChanged -= eventHandler2;
          this._lstHue.DrawItem -= itemEventHandler;
        }
        this._lstHue = value;
        if (this._lstHue == null)
          return;
        this._lstHue.DoubleClick += eventHandler1;
        this._lstHue.SelectedIndexChanged += eventHandler2;
        this._lstHue.DrawItem += itemEventHandler;
      }
    }

    internal virtual StatusBar StatusBar
    {
      [DebuggerNonUserCode] get => this._StatusBar;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._StatusBar = value;
    }

    internal virtual ToolTip ToolTip1
    {
      [DebuggerNonUserCode] get => this._ToolTip1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._ToolTip1 = value;
    }

    public event HuePickerControl.ValueChangedEventHandler ValueChanged;

    public HuePickerControl()
    {
      this.Load += new EventHandler(this.HuePickerControl_Load);
      lock (HuePickerControl.__ENCList)
        HuePickerControl.__ENCList.Add(new WeakReference(this));
      this.InitializeComponent();
    }

    public HuePickerControl(Hue InitialHue)
      : this()
    {
      this.mHue = InitialHue;
    }

    private void cboQuick_SelectedIndexChanged(object sender, EventArgs e)
    {
      string s = "0";
      switch (this.cboQuick.Text)
      {
        case "Colors":
          s = "0";
          break;
        case "Skin":
          s = "1001";
          break;
        case "Hair":
          s = "1101";
          break;
        case "Interesting #1":
          s = "1049";
          break;
        case "Pinks":
          s = "1200";
          break;
        case "Elemental Weapons":
          s = "1254";
          break;
        case "Interesting #2":
          s = "1278";
          break;
        case "Blues":
          s = "1300";
          break;
        case "Elemental Wear":
          s = "1354";
          break;
        case "Greens":
          s = "1400";
          break;
        case "Oranges":
          s = "1500";
          break;
        case "Reds":
          s = "1600";
          break;
        case "Yellows":
          s = "1700";
          break;
        case "Neutrals":
          s = "1800";
          break;
        case "Snakes":
          s = "2000";
          break;
        case "Birds":
          s = "2100";
          break;
        case "Slimes":
          s = "2200";
          break;
        case "Animals":
          s = "2300";
          break;
        case "Metals":
          s = "2400";
          break;
      }
      this.lstHue.SelectedIndex = this.lstHue.FindString(s);
      this.lstHue.Focus();
    }

    protected static Color Convert555ToARGB(short Col)
    {
      return Color.FromArgb(((short) (Col >> 10) & 31) * 8, ((short) (Col >> 5) & 31) * 8, (Col & 31) * 8);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void HuePickerControl_Load(object sender, EventArgs e)
    {
      this.lstHue.Items.Clear();
      foreach (Hue hue in Hues.List)
      {
        if (hue.Index == this.mHue.Index)
          this.lstHue.SelectedIndex = this.lstHue.Items.Add(hue);
        else
          this.lstHue.Items.Add(hue);
      }
      this.StatusBar.Text = Conversions.ToString(this.mHue.Index) + ": " + this.mHue.Name;
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.lstHue = new ListBox();
      this.StatusBar = new StatusBar();
      this.cboQuick = new ComboBox();
      this.ToolTip1 = new ToolTip(this.components);
      this.SuspendLayout();
      this.lstHue.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.lstHue.DrawMode = DrawMode.OwnerDrawFixed;
      this.lstHue.IntegralHeight = false;
      Point point = new Point(0, 0);
      this.lstHue.Location = point;
      this.lstHue.Name = "lstHue";
      Size size = new Size(208, 244);
      this.lstHue.Size = size;
      this.lstHue.TabIndex = 0;
      point = new Point(0, 242);
      this.StatusBar.Location = point;
      this.StatusBar.Name = "StatusBar";
      size = new Size(208, 22);
      this.StatusBar.Size = size;
      this.StatusBar.SizingGrip = false;
      this.StatusBar.TabIndex = 1;
      this.cboQuick.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboQuick.DropDownWidth = 120;
      this.cboQuick.Items.AddRange(new object[19]
      {
        "Colors",
        "Skin",
        "Hair",
        "Interesting #1",
        "Pinks",
        "Elemental Weapons",
        "Interesting #2",
        "Blues",
        "Elemental Wear",
        "Greens",
        "Oranges",
        "Reds",
        "Yellows",
        "Neutrals",
        "Snakes",
        "Birds",
        "Slimes",
        "Animals",
        "Metals"
      });
      point = new Point(144, 243);
      this.cboQuick.Location = point;
      this.cboQuick.Name = "cboQuick";
      size = new Size(64, 21);
      this.cboQuick.Size = size;
      this.cboQuick.TabIndex = 2;
      this.ToolTip1.SetToolTip(this.cboQuick, "Bookmarks");
      this.Controls.Add(this.cboQuick);
      this.Controls.Add(this.StatusBar);
      this.Controls.Add(this.lstHue);
      this.Name = nameof (HuePickerControl);
      size = new Size(208, 264);
      this.Size = size;
      this.ResumeLayout(false);
    }

    private void lstHue_DoubleClick(object sender, EventArgs e)
    {
      HuePickerControl.ValueChangedEventHandler valueChanged = this.ValueChanged;
      if (valueChanged == null)
        return;
      valueChanged(this.mHue);
    }

    private void lstHue_DrawItem(object sender, DrawItemEventArgs e)
    {
      Graphics graphics1 = e.Graphics;
      graphics1.FillRectangle(Brushes.White, e.Bounds);
      if ((e.State & DrawItemState.Selected) > DrawItemState.None)
      {
        Rectangle rect = new Rectangle(e.Bounds.X, e.Bounds.Y, 50, this.lstHue.ItemHeight);
        graphics1.FillRectangle(SystemBrushes.Highlight, rect);
      }
      else
      {
        Rectangle rect = new Rectangle(e.Bounds.X, e.Bounds.Y, 50, this.lstHue.ItemHeight);
        graphics1.FillRectangle(SystemBrushes.Window, rect);
      }
      float num1 = (e.Bounds.Width - 35) / 32f;
      Hue hue = (Hue) this.lstHue.Items[e.Index];
      Graphics graphics2 = graphics1;
      string s = hue.Index.ToString();
      Font font = e.Font;
      Brush black = Brushes.Black;
      Rectangle bounds1 = e.Bounds;
      double num2 = bounds1.X + 3;
      bounds1 = e.Bounds;
      double y1 = bounds1.Y;
      graphics2.DrawString(s, font, black, (float) num2, (float) y1);
      int num3 = 0;
      foreach (short color in hue.Colors)
      {
        Rectangle bounds2 = e.Bounds;
        int x = bounds2.X + 35 + (int) Math.Round(num3 * (double) num1);
        bounds2 = e.Bounds;
        int y2 = bounds2.Y;
        int width = (int) Math.Round(num1 + 1.0);
        bounds2 = e.Bounds;
        int height = bounds2.Height;
        Rectangle rect = new Rectangle(x, y2, width, height);
        graphics1.FillRectangle(new SolidBrush(HuePickerControl.Convert555ToARGB(color)), rect);
        ++num3;
      }
    }

    private void lstHue_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.mHue = (Hue) this.lstHue.SelectedItem;
      if (this.mHue == null)
        return;
      this.StatusBar.Text = Conversions.ToString(this.mHue.Index) + ": " + this.mHue.Name;
    }

    public delegate void ValueChangedEventHandler(Hue Hue);
  }
}
