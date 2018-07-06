// Decompiled with JetBrains decompiler
// Type: GumpStudio.Settings
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

namespace GumpStudio
{
  [DesignerGenerated]
  public class Settings : Form
  {
    private static List<WeakReference> __ENCList = new List<WeakReference>();
    [AccessedThroughProperty("Button1")]
    private Button _Button1;
    [AccessedThroughProperty("Cancel_Button")]
    private Button _Cancel_Button;
    [AccessedThroughProperty("CheckBox1")]
    private CheckBox _CheckBox1;
    [AccessedThroughProperty("Label1")]
    private Label _Label1;
    [AccessedThroughProperty("Label2")]
    private Label _Label2;
    [AccessedThroughProperty("Label3")]
    private Label _Label3;
    [AccessedThroughProperty("NumericUpDown1")]
    private NumericUpDown _NumericUpDown1;
    [AccessedThroughProperty("OK_Button")]
    private Button _OK_Button;
    [AccessedThroughProperty("TableLayoutPanel1")]
    private TableLayoutPanel _TableLayoutPanel1;
    [AccessedThroughProperty("TrackBar1")]
    private TrackBar _TrackBar1;
    [AccessedThroughProperty("txtClientPath")]
    private TextBox _txtClientPath;
    private IContainer components;

    internal virtual Button Button1
    {
      [DebuggerNonUserCode] get
      {
        return this._Button1;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Button1 = value;
      }
    }

    internal virtual Button Cancel_Button
    {
      [DebuggerNonUserCode] get
      {
        return this._Cancel_Button;
      }
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

    internal virtual CheckBox CheckBox1
    {
      [DebuggerNonUserCode] get
      {
        return this._CheckBox1;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._CheckBox1 = value;
      }
    }

    internal virtual Label Label1
    {
      [DebuggerNonUserCode] get
      {
        return this._Label1;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label1 = value;
      }
    }

    internal virtual Label Label2
    {
      [DebuggerNonUserCode] get
      {
        return this._Label2;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label2 = value;
      }
    }

    internal virtual Label Label3
    {
      [DebuggerNonUserCode] get
      {
        return this._Label3;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label3 = value;
      }
    }

    internal virtual NumericUpDown NumericUpDown1
    {
      [DebuggerNonUserCode] get
      {
        return this._NumericUpDown1;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._NumericUpDown1 = value;
      }
    }

    internal virtual Button OK_Button
    {
      [DebuggerNonUserCode] get
      {
        return this._OK_Button;
      }
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
      [DebuggerNonUserCode] get
      {
        return this._TableLayoutPanel1;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._TableLayoutPanel1 = value;
      }
    }

    internal virtual TrackBar TrackBar1
    {
      [DebuggerNonUserCode] get
      {
        return this._TrackBar1;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._TrackBar1 = value;
      }
    }

    internal virtual TextBox txtClientPath
    {
      [DebuggerNonUserCode] get
      {
        return this._txtClientPath;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._txtClientPath = value;
      }
    }

    [DebuggerNonUserCode]
    public Settings()
    {
      lock (Settings.__ENCList)
        Settings.__ENCList.Add(new WeakReference((object) this));
      this.InitializeComponent();
    }

    private void Cancel_Button_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
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
      this.txtClientPath = new TextBox();
      this.Label1 = new Label();
      this.NumericUpDown1 = new NumericUpDown();
      this.Label2 = new Label();
      this.TrackBar1 = new TrackBar();
      this.Label3 = new Label();
      this.Button1 = new Button();
      this.CheckBox1 = new CheckBox();
      this.TableLayoutPanel1.SuspendLayout();
      this.NumericUpDown1.BeginInit();
      this.TrackBar1.BeginInit();
      this.SuspendLayout();
      this.TableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.TableLayoutPanel1.ColumnCount = 2;
      this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.TableLayoutPanel1.Controls.Add((Control) this.OK_Button, 0, 0);
      this.TableLayoutPanel1.Controls.Add((Control) this.Cancel_Button, 1, 0);
      Point point = new Point(277, 274);
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
      this.txtClientPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      point = new Point(85, 12);
      this.txtClientPath.Location = point;
      this.txtClientPath.Name = "txtClientPath";
      size = new Size(314, 20);
      this.txtClientPath.Size = size;
      this.txtClientPath.TabIndex = 1;
      this.Label1.AutoSize = true;
      point = new Point(12, 15);
      this.Label1.Location = point;
      this.Label1.Name = "Label1";
      size = new Size(58, 13);
      this.Label1.Size = size;
      this.Label1.TabIndex = 2;
      this.Label1.Text = "Client Path";
      point = new Point(85, 38);
      this.NumericUpDown1.Location = point;
      Decimal num = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.NumericUpDown1.Minimum = num;
      this.NumericUpDown1.Name = "NumericUpDown1";
      size = new Size(52, 20);
      this.NumericUpDown1.Size = size;
      this.NumericUpDown1.TabIndex = 3;
      num = new Decimal(new int[4]{ 1, 0, 0, 0 });
      this.NumericUpDown1.Value = num;
      this.Label2.AutoSize = true;
      point = new Point(12, 45);
      this.Label2.Location = point;
      this.Label2.Name = "Label2";
      size = new Size(67, 13);
      this.Label2.Size = size;
      this.Label2.TabIndex = 4;
      this.Label2.Text = "Undo Levels";
      this.TrackBar1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      point = new Point(15, 94);
      this.TrackBar1.Location = point;
      this.TrackBar1.Maximum = 100;
      this.TrackBar1.Name = "TrackBar1";
      size = new Size(405, 45);
      this.TrackBar1.Size = size;
      this.TrackBar1.TabIndex = 5;
      this.TrackBar1.Value = 6;
      this.Label3.AutoSize = true;
      point = new Point(12, 78);
      this.Label3.Location = point;
      this.Label3.Name = "Label3";
      size = new Size(115, 13);
      this.Label3.Size = size;
      this.Label3.TabIndex = 6;
      this.Label3.Text = "Arrow key acceleration";
      this.Button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      point = new Point(396, 11);
      this.Button1.Location = point;
      this.Button1.Name = "Button1";
      size = new Size(27, 20);
      this.Button1.Size = size;
      this.Button1.TabIndex = 7;
      this.Button1.Text = "...";
      this.Button1.UseVisualStyleBackColor = true;
      this.CheckBox1.AutoSize = true;
      point = new Point(15, 145);
      this.CheckBox1.Location = point;
      this.CheckBox1.Name = "CheckBox1";
      size = new Size(132, 17);
      this.CheckBox1.Size = size;
      this.CheckBox1.TabIndex = 8;
      this.CheckBox1.Text = "Pixel Perfect Selection";
      this.CheckBox1.UseVisualStyleBackColor = true;
      this.AcceptButton = (IButtonControl) this.OK_Button;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.Cancel_Button;
      size = new Size(435, 315);
      this.ClientSize = size;
      this.Controls.Add((Control) this.CheckBox1);
      this.Controls.Add((Control) this.Button1);
      this.Controls.Add((Control) this.Label3);
      this.Controls.Add((Control) this.TrackBar1);
      this.Controls.Add((Control) this.Label2);
      this.Controls.Add((Control) this.NumericUpDown1);
      this.Controls.Add((Control) this.Label1);
      this.Controls.Add((Control) this.txtClientPath);
      this.Controls.Add((Control) this.TableLayoutPanel1);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (Settings);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = nameof (Settings);
      this.TableLayoutPanel1.ResumeLayout(false);
      this.NumericUpDown1.EndInit();
      this.TrackBar1.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void OK_Button_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
      this.Close();
    }
  }
}
