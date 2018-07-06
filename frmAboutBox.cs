// Decompiled with JetBrains decompiler
// Type: GumpStudio.frmAboutBox
// Assembly: GumpStudioCore, Version=1.8.3024.24259, Culture=neutral, PublicKeyToken=null
// MVID: A77D32E5-7519-4865-AA26-DCCB34429732
// Assembly location: C:\GumpStudio_1_8_R3_quinted-02\GumpStudioCore.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace GumpStudio
{
  public class frmAboutBox : Form
  {
    private static List<WeakReference> __ENCList = new List<WeakReference>();
    [AccessedThroughProperty("cmdClose")]
    private Button _cmdClose;
    [AccessedThroughProperty("Label1")]
    private Label _Label1;
    [AccessedThroughProperty("lblHomepage")]
    private LinkLabel _lblHomepage;
    [AccessedThroughProperty("lblVersion")]
    private Label _lblVersion;
    [AccessedThroughProperty("PictureBox1")]
    private PictureBox _PictureBox1;
    [AccessedThroughProperty("txtAbout")]
    private TextBox _txtAbout;
    private IContainer components;

    internal virtual Button cmdClose
    {
      [DebuggerNonUserCode] get
      {
        return this._cmdClose;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cmdClose_Click);
        if (this._cmdClose != null)
          this._cmdClose.Click -= eventHandler;
        this._cmdClose = value;
        if (this._cmdClose == null)
          return;
        this._cmdClose.Click += eventHandler;
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

    internal virtual LinkLabel lblHomepage
    {
      [DebuggerNonUserCode] get
      {
        return this._lblHomepage;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        LinkLabelLinkClickedEventHandler clickedEventHandler = new LinkLabelLinkClickedEventHandler(this.lblHomepage_LinkClicked);
        if (this._lblHomepage != null)
          this._lblHomepage.LinkClicked -= clickedEventHandler;
        this._lblHomepage = value;
        if (this._lblHomepage == null)
          return;
        this._lblHomepage.LinkClicked += clickedEventHandler;
      }
    }

    internal virtual Label lblVersion
    {
      [DebuggerNonUserCode] get
      {
        return this._lblVersion;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._lblVersion = value;
      }
    }

    internal virtual PictureBox PictureBox1
    {
      [DebuggerNonUserCode] get
      {
        return this._PictureBox1;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._PictureBox1 = value;
      }
    }

    internal virtual TextBox txtAbout
    {
      [DebuggerNonUserCode] get
      {
        return this._txtAbout;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._txtAbout = value;
      }
    }

    public frmAboutBox()
    {
      this.Load += new EventHandler(this.frmAboutBox_Load);
      lock (frmAboutBox.__ENCList)
        frmAboutBox.__ENCList.Add(new WeakReference((object) this));
      this.InitializeComponent();
    }

    private void cmdClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void frmAboutBox_Load(object sender, EventArgs e)
    {
      this.lblVersion.Text = "Core Version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmAboutBox));
      this.PictureBox1 = new PictureBox();
      this.txtAbout = new TextBox();
      this.cmdClose = new Button();
      this.Label1 = new Label();
      this.lblVersion = new Label();
      this.lblHomepage = new LinkLabel();
      this.SuspendLayout();
      this.PictureBox1.Image = (Image) componentResourceManager.GetObject("PictureBox1.Image");
      Point point = new Point(0, 0);
      this.PictureBox1.Location = point;
      this.PictureBox1.Name = "PictureBox1";
      Size size = new Size(454, 158);
      this.PictureBox1.Size = size;
      this.PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
      this.PictureBox1.TabIndex = 0;
      this.PictureBox1.TabStop = false;
      point = new Point(192, 80);
      this.txtAbout.Location = point;
      this.txtAbout.Multiline = true;
      this.txtAbout.Name = "txtAbout";
      this.txtAbout.ReadOnly = true;
      this.txtAbout.ScrollBars = ScrollBars.Vertical;
      size = new Size(248, 152);
      this.txtAbout.Size = size;
      this.txtAbout.TabIndex = 1;
      this.txtAbout.Text = "Gump Studio was written by Bradley Uffner in January of 2003.";
      point = new Point(368, 240);
      this.cmdClose.Location = point;
      this.cmdClose.Name = "cmdClose";
      size = new Size(75, 23);
      this.cmdClose.Size = size;
      this.cmdClose.TabIndex = 0;
      this.cmdClose.Text = "Close";
      point = new Point(8, 168);
      this.Label1.Location = point;
      this.Label1.Name = "Label1";
      size = new Size(176, 23);
      this.Label1.Size = size;
      this.Label1.TabIndex = 3;
      this.Label1.Text = "(C) Bradley Uffner, 2004";
      this.lblVersion.AutoSize = true;
      point = new Point(8, 248);
      this.lblVersion.Location = point;
      this.lblVersion.Name = "lblVersion";
      size = new Size(42, 13);
      this.lblVersion.Size = size;
      this.lblVersion.TabIndex = 4;
      this.lblVersion.Text = "Version";
      point = new Point(8, 192);
      this.lblHomepage.Location = point;
      this.lblHomepage.Name = "lblHomepage";
      size = new Size(168, 23);
      this.lblHomepage.Size = size;
      this.lblHomepage.TabIndex = 5;
      this.lblHomepage.TabStop = true;
      this.lblHomepage.Text = "http://www.gumpstudio.com";
      size = new Size(5, 13);
      this.AutoScaleBaseSize = size;
      size = new Size(450, 272);
      this.ClientSize = size;
      this.Controls.Add((Control) this.lblHomepage);
      this.Controls.Add((Control) this.lblVersion);
      this.Controls.Add((Control) this.Label1);
      this.Controls.Add((Control) this.cmdClose);
      this.Controls.Add((Control) this.txtAbout);
      this.Controls.Add((Control) this.PictureBox1);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (frmAboutBox);
      this.Text = "About Gump Studio.NET";
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void lblHomepage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start(new ProcessStartInfo()
      {
        UseShellExecute = true,
        FileName = "http://www.orbsydia.net"
      });
    }

    public void SetText(string Text)
    {
      this.txtAbout.Text = "Gump Studio was designed and written by Bradley Uffner in 2004. It makes extensive use of a modified version of the UOSDK written by Krrios, available at www.RunUO.com. Artwork was created by Melanius, and several more ideas were contributed by the RunUO community.  Special thanks go to DarkStorm of the Wolfpack emulator for helping me to decode unifont.mul, allowing me to displaying UO fonts correctly.\r\n\r\n====Plugin Specific Information====\r\n" + Text;
    }
  }
}
