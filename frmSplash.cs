// Decompiled with JetBrains decompiler
// Type: GumpStudio.frmSplash
// Assembly: GumpStudioCore, Version=1.8.3024.24259, Culture=neutral, PublicKeyToken=null
// MVID: A77D32E5-7519-4865-AA26-DCCB34429732
// Assembly location: C:\GumpStudio_1_8_R3_quinted-02\GumpStudioCore.dll

using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace GumpStudio
{
  public class frmSplash : Form
  {
    private static List<WeakReference> __ENCList = new List<WeakReference>();
    private IContainer components;
    private static frmSplash f;
    private static Thread t;

    public frmSplash()
    {
      this.Load += new EventHandler(this.frmSplash_Load);
      this.Click += new EventHandler(this.frmSplash_Click);
      lock (frmSplash.__ENCList)
        frmSplash.__ENCList.Add(new WeakReference((object) this));
      this.InitializeComponent();
    }

    public static void DisplaySplash()
    {
      frmSplash.t = new Thread(new ThreadStart(frmSplash.ThreadStartDisplay));
      frmSplash.t.Start();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private static void FadeOut(Form f)
    {
      f.Dispose();
    }

    private void frmSplash_Click(object sender, EventArgs e)
    {
      frmSplash.FadeOut((Form) this);
    }

    private void frmSplash_Load(object sender, EventArgs e)
    {
      this.CenterToScreen();
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      ResourceManager resourceManager = new ResourceManager(typeof (frmSplash));
      Size size = new Size(5, 13);
      this.AutoScaleBaseSize = size;
      this.BackgroundImage = (Image) resourceManager.GetObject("$this.BackgroundImage");
      size = new Size(453, 154);
      this.ClientSize = size;
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (frmSplash);
      this.Text = nameof (frmSplash);
      this.TopMost = true;
    }

    private static void ThreadStartDisplay()
    {
      frmSplash.f = new frmSplash();
      frmSplash.f.Show();
      DateTime now = DateAndTime.Now;
      while (DateTime.Compare(DateAndTime.Now, DateAndTime.DateAdd(DateInterval.Second, 2.0, now)) <= 0)
      {
        Thread.Sleep(100);
        Application.DoEvents();
      }
      frmSplash.FadeOut((Form) frmSplash.f);
    }
  }
}
