// Decompiled with JetBrains decompiler
// Type: GumpStudio.ClilocBrowser
// Assembly: GumpStudioCore, Version=1.8.3024.24259, Culture=neutral, PublicKeyToken=null
// MVID: A77D32E5-7519-4865-AA26-DCCB34429732
// Assembly location: C:\GumpStudio_1_8_R3_quinted-02\GumpStudioCore.dll

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Ultima;

namespace GumpStudio
{
  [DesignerGenerated]
  public class ClilocBrowser : Form
  {
    private static List<WeakReference> __ENCList = new List<WeakReference>();
    protected static ListBox ClilocCache = null;
    [AccessedThroughProperty("Cancel_Button")]
    private Button _Cancel_Button;
    [AccessedThroughProperty("cboLanguage")]
    private ComboBox _cboLanguage;
    [AccessedThroughProperty("Label1")]
    private Label _Label1;
    [AccessedThroughProperty("lstCliloc")]
    private ListBox _lstCliloc;
    [AccessedThroughProperty("OK_Button")]
    private Button _OK_Button;
    [AccessedThroughProperty("TableLayoutPanel1")]
    private TableLayoutPanel _TableLayoutPanel1;
    private IContainer components;
    protected int mClilocID;

    internal virtual Button Cancel_Button
    {
      [DebuggerNonUserCode] get => this._Cancel_Button;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Cancel_Button_Click);
        if (this._Cancel_Button != null)
          this._Cancel_Button.Click -= eventHandler;
        this._Cancel_Button = value;
        if (this._Cancel_Button == null)
          return;
        this._Cancel_Button.Click += eventHandler;
      }
    }

    internal virtual ComboBox cboLanguage
    {
      [DebuggerNonUserCode] get => this._cboLanguage;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._cboLanguage = value;
    }

    public int ClilocID
    {
      get => this.mClilocID;
      set => this.mClilocID = value;
    }

    internal virtual Label Label1
    {
      [DebuggerNonUserCode] get => this._Label1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._Label1 = value;
    }

    internal virtual ListBox lstCliloc
    {
      [DebuggerNonUserCode] get => this._lstCliloc;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        DrawItemEventHandler itemEventHandler = new DrawItemEventHandler(this.lstCliloc_DrawItem);
        if (this._lstCliloc != null)
          this._lstCliloc.DrawItem -= itemEventHandler;
        this._lstCliloc = value;
        if (this._lstCliloc == null)
          return;
        this._lstCliloc.DrawItem += itemEventHandler;
      }
    }

    internal virtual Button OK_Button
    {
      [DebuggerNonUserCode] get => this._OK_Button;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.OK_Button_Click);
        if (this._OK_Button != null)
          this._OK_Button.Click -= eventHandler;
        this._OK_Button = value;
        if (this._OK_Button == null)
          return;
        this._OK_Button.Click += eventHandler;
      }
    }

    internal virtual TableLayoutPanel TableLayoutPanel1
    {
      [DebuggerNonUserCode] get => this._TableLayoutPanel1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._TableLayoutPanel1 = value;
    }

    [DebuggerNonUserCode]
    public ClilocBrowser()
    {
      this.Load += new EventHandler(this.ClilocBrowser_Load);
      lock (ClilocBrowser.__ENCList)
        ClilocBrowser.__ENCList.Add(new WeakReference(this));
      this.InitializeComponent();
    }

    private void Cancel_Button_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private void ClilocBrowser_Load(object sender, EventArgs e)
    {
      foreach (string file in Directory.GetFiles(XMLSettings.CurrentOptions.ClientPath, "Cliloc.*"))
        this.cboLanguage.Items.Add(Path.GetExtension(file).Substring(1));
      if (ClilocBrowser.ClilocCache == null)
      {
        this.lstCliloc.SuspendLayout();
        foreach (object entry in new StringList("enu").Entries)
          this.lstCliloc.Items.Add(entry);
        this.lstCliloc.ResumeLayout();
        ClilocBrowser.ClilocCache = this.lstCliloc;
      }
      else
        this.lstCliloc = ClilocBrowser.ClilocCache;
    }

    [DebuggerNonUserCode]
    protected override void Dispose(bool disposing)
    {
      try
      {
        if ((!disposing || this.components == null ? 0 : 1) == 0)
          return;
        this.components.Dispose();
      }
      finally
      {
        base.Dispose(disposing);
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.TableLayoutPanel1 = new TableLayoutPanel();
      this.OK_Button = new Button();
      this.Cancel_Button = new Button();
      this.lstCliloc = new ListBox();
      this.Label1 = new Label();
      this.cboLanguage = new ComboBox();
      this.TableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      this.TableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.TableLayoutPanel1.ColumnCount = 2;
      this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
      this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
      Point point = new Point(451, 392);
      this.TableLayoutPanel1.Location = point;
      this.TableLayoutPanel1.Name = "TableLayoutPanel1";
      this.TableLayoutPanel1.RowCount = 1;
      this.TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
      Size size = new Size(146, 29);
      this.TableLayoutPanel1.Size = size;
      this.TableLayoutPanel1.TabIndex = 0;
      this.OK_Button.Anchor = AnchorStyles.None;
      point = new Point(3, 3);
      this.OK_Button.Location = point;
      this.OK_Button.Name = "OK_Button";
      size = new Size(67, 23);
      this.OK_Button.Size = size;
      this.OK_Button.TabIndex = 0;
      this.OK_Button.Text = "OK";
      this.Cancel_Button.Anchor = AnchorStyles.None;
      this.Cancel_Button.DialogResult = DialogResult.Cancel;
      point = new Point(76, 3);
      this.Cancel_Button.Location = point;
      this.Cancel_Button.Name = "Cancel_Button";
      size = new Size(67, 23);
      this.Cancel_Button.Size = size;
      this.Cancel_Button.TabIndex = 1;
      this.Cancel_Button.Text = "Cancel";
      this.lstCliloc.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.lstCliloc.DrawMode = DrawMode.OwnerDrawFixed;
      this.lstCliloc.FormattingEnabled = true;
      point = new Point(12, 12);
      this.lstCliloc.Location = point;
      this.lstCliloc.Name = "lstCliloc";
      size = new Size(585, 368);
      this.lstCliloc.Size = size;
      this.lstCliloc.TabIndex = 1;
      this.Label1.AutoSize = true;
      point = new Point(12, 400);
      this.Label1.Location = point;
      this.Label1.Name = "Label1";
      size = new Size(55, 13);
      this.Label1.Size = size;
      this.Label1.TabIndex = 2;
      this.Label1.Text = "Language";
      this.cboLanguage.FormattingEnabled = true;
      point = new Point(73, 397);
      this.cboLanguage.Location = point;
      this.cboLanguage.Name = "cboLanguage";
      size = new Size(121, 21);
      this.cboLanguage.Size = size;
      this.cboLanguage.TabIndex = 3;
      this.AcceptButton = this.OK_Button;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = this.Cancel_Button;
      size = new Size(609, 433);
      this.ClientSize = size;
      this.Controls.Add(this.cboLanguage);
      this.Controls.Add(this.Label1);
      this.Controls.Add(this.lstCliloc);
      this.Controls.Add(this.TableLayoutPanel1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (ClilocBrowser);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Cliloc Browser";
      this.TableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void lstCliloc_DrawItem(object sender, DrawItemEventArgs e)
    {
      StringEntry stringEntry = (StringEntry) this.lstCliloc.Items[e.Index];
      e.DrawBackground();
      e.Graphics.DrawString(stringEntry.Number.ToString(), this.lstCliloc.Font, Brushes.Black, e.Bounds.X, e.Bounds.Top);
      e.Graphics.DrawString(stringEntry.Text.ToString(), this.lstCliloc.Font, Brushes.Black, e.Bounds.X + 100, e.Bounds.Top);
    }

    private void OK_Button_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
      this.Close();
    }
  }
}
