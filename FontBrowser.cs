// Decompiled with JetBrains decompiler
// Type: GumpStudio.FontBrowser
// Assembly: GumpStudioCore, Version=1.8.3024.24259, Culture=neutral, PublicKeyToken=null
// MVID: A77D32E5-7519-4865-AA26-DCCB34429732
// Assembly location: C:\GumpStudio_1_8_R3_quinted-02\GumpStudioCore.dll

using GumpStudio.Elements;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using UOFont;

namespace GumpStudio
{
  public class FontBrowser : UserControl
  {
    private bool fntunicode = true;
    private static List<WeakReference> __ENCList = new List<WeakReference>();
    private const int fntshift = 0;
    [AccessedThroughProperty("lstFont")]
    private ListBox _lstFont;
    private IContainer components;
    public int Value;

    internal virtual ListBox lstFont
    {
      [DebuggerNonUserCode] get
      {
        return this._lstFont;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.lstFont_DoubleClick);
        DrawItemEventHandler itemEventHandler1 = new DrawItemEventHandler(this.lstFont_DrawItem);
        MeasureItemEventHandler itemEventHandler2 = new MeasureItemEventHandler(this.lstFont_MeasureItem);
        if (this._lstFont != null)
        {
          this._lstFont.DoubleClick -= eventHandler;
          this._lstFont.DrawItem -= itemEventHandler1;
          this._lstFont.MeasureItem -= itemEventHandler2;
        }
        this._lstFont = value;
        if (this._lstFont == null)
          return;
        this._lstFont.DoubleClick += eventHandler;
        this._lstFont.DrawItem += itemEventHandler1;
        this._lstFont.MeasureItem += itemEventHandler2;
      }
    }

    public event FontBrowser.ValueChangedEventHandler ValueChanged;

    public FontBrowser()
    {
      this.Load += new EventHandler(this.FontBrowser_Load);
      lock (FontBrowser.__ENCList)
        FontBrowser.__ENCList.Add(new WeakReference((object) this));
      this.InitializeComponent();
    }

    public FontBrowser(int Value)
      : this()
    {
      this.Value = Value;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void FontBrowser_Load(object sender, EventArgs e)
    {
      this.fntunicode = true;
      ArrayList arrayList = GlobalObjects.DesignerForm == null || GlobalObjects.DesignerForm.ElementStack == null ? (ArrayList) null : GlobalObjects.DesignerForm.ElementStack.GetSelectedElements();
      if (arrayList != null)
      {
        foreach (object obj in arrayList)
        {
          if (obj is LabelElement && !((LabelElement) obj).Unicode)
          {
            this.fntunicode = false;
            break;
          }
        }
      }
      for (int index = 0; index < (this.fntunicode ? 13 : 10); ++index)
      {
        if (index >= 0)
          this.lstFont.Items.Add((object) index);
      }
      this.lstFont.SelectedIndex = this.Value;
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.lstFont = new ListBox();
      this.SuspendLayout();
      this.lstFont.Dock = DockStyle.Fill;
      this.lstFont.DrawMode = DrawMode.OwnerDrawVariable;
      this.lstFont.IntegralHeight = false;
      this.lstFont.Location = new Point(0, 0);
      this.lstFont.Name = "lstFont";
      Size size = new Size(326, 282);
      this.lstFont.Size = size;
      this.lstFont.TabIndex = 0;
      this.Controls.Add((Control) this.lstFont);
      this.Name = nameof (FontBrowser);
      size = new Size(326, 282);
      this.Size = size;
      this.ResumeLayout(false);
    }

    private void lstFont_DoubleClick(object sender, EventArgs e)
    {
      this.Value = this.lstFont.SelectedIndex;
      FontBrowser.ValueChangedEventHandler valueChanged = this.ValueChanged;
      if (valueChanged == null)
        return;
      valueChanged(this.Value);
    }

    private void lstFont_DrawItem(object sender, DrawItemEventArgs e)
    {
      if ((e.State & DrawItemState.Selected) > DrawItemState.None)
        e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
      else
        e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
      if (e.Index > (this.fntunicode ? 12 : 9))
        return;
      Bitmap bitmap = this.fntunicode ? UnicodeFonts.GetStringImage(e.Index, "ABCabc123!@#$АБВабв") : Fonts.GetStringImage(e.Index, "ABCabc123 */ АБВабв");
      e.Graphics.DrawImage((Image) bitmap, e.Bounds.Location);
      bitmap.Dispose();
    }

    private void lstFont_MeasureItem(object sender, MeasureItemEventArgs e)
    {
      if (e.Index > (this.fntunicode ? 12 : 9))
      {
        e.ItemHeight = 0;
      }
      else
      {
        Bitmap bitmap = this.fntunicode ? UnicodeFonts.GetStringImage(e.Index, "ABCabc123!@#$АБВабв") : Fonts.GetStringImage(e.Index, "ABCabc123 */ АБВабв");
        e.ItemHeight = bitmap.Height;
        bitmap.Dispose();
      }
    }

    public delegate void ValueChangedEventHandler(int Value);
  }
}
