// Decompiled with JetBrains decompiler
// Type: GumpStudio.LargeTextEditor
// Assembly: GumpStudioCore, Version=1.8.3024.24259, Culture=neutral, PublicKeyToken=null
// MVID: A77D32E5-7519-4865-AA26-DCCB34429732
// Assembly location: C:\GumpStudio_1_8_R3_quinted-02\GumpStudioCore.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace GumpStudio
{
  public class LargeTextEditor : Form
  {
    private static List<WeakReference> __ENCList = new List<WeakReference>();
    [AccessedThroughProperty("cmdCancel")]
    private Button _cmdCancel;
    [AccessedThroughProperty("cmdOK")]
    private Button _cmdOK;
    [AccessedThroughProperty("txtText")]
    private TextBox _txtText;
    private IContainer components;

    internal virtual Button cmdCancel
    {
      [DebuggerNonUserCode] get
      {
        return this._cmdCancel;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cmdCancel_Click);
        if (this._cmdCancel != null)
          this._cmdCancel.Click -= eventHandler;
        this._cmdCancel = value;
        if (this._cmdCancel == null)
          return;
        this._cmdCancel.Click += eventHandler;
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

    public virtual TextBox txtText
    {
      [DebuggerNonUserCode] get
      {
        return this._txtText;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._txtText = value;
      }
    }

    public LargeTextEditor()
    {
      lock (LargeTextEditor.__ENCList)
        LargeTextEditor.__ENCList.Add(new WeakReference((object) this));
      this.InitializeComponent();
    }

    private void cmdCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    private void cmdOK_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.txtText = new TextBox();
      this.cmdCancel = new Button();
      this.cmdOK = new Button();
      this.SuspendLayout();
      this.txtText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      Point point = new Point(8, 8);
      this.txtText.Location = point;
      this.txtText.Multiline = true;
      this.txtText.Name = "txtText";
      Size size = new Size(280, 224);
      this.txtText.Size = size;
      this.txtText.TabIndex = 0;
      this.cmdCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.cmdCancel.DialogResult = DialogResult.Cancel;
      point = new Point(212, 240);
      this.cmdCancel.Location = point;
      this.cmdCancel.Name = "cmdCancel";
      size = new Size(75, 23);
      this.cmdCancel.Size = size;
      this.cmdCancel.TabIndex = 1;
      this.cmdCancel.Text = "Cancel";
      this.cmdOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      point = new Point(124, 240);
      this.cmdOK.Location = point;
      this.cmdOK.Name = "cmdOK";
      size = new Size(75, 23);
      this.cmdOK.Size = size;
      this.cmdOK.TabIndex = 2;
      this.cmdOK.Text = "OK";
      size = new Size(5, 13);
      this.AutoScaleBaseSize = size;
      this.CancelButton = (IButtonControl) this.cmdCancel;
      size = new Size(296, 270);
      this.ClientSize = size;
      this.Controls.Add((Control) this.cmdOK);
      this.Controls.Add((Control) this.cmdCancel);
      this.Controls.Add((Control) this.txtText);
      this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
      this.Name = nameof (LargeTextEditor);
      this.Text = "Text Editor";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
