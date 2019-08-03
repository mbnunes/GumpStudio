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
        [AccessedThroughProperty( "cmdClose" )]
        private Button _cmdClose;
        [AccessedThroughProperty( "Label1" )]
        private Label _Label1;
        [AccessedThroughProperty( "lblHomepage" )]
        private LinkLabel _lblHomepage;
        [AccessedThroughProperty( "lblVersion" )]
        private Label _lblVersion;
        [AccessedThroughProperty( "PictureBox1" )]
        private PictureBox _PictureBox1;
        [AccessedThroughProperty( "txtAbout" )]
        private TextBox _txtAbout;
        private IContainer components;

        internal virtual Button cmdClose
        {
            [DebuggerNonUserCode]
            get => _cmdClose;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                EventHandler eventHandler = new EventHandler( cmdClose_Click );
                if ( _cmdClose != null )
                    _cmdClose.Click -= eventHandler;
                _cmdClose = value;
                if ( _cmdClose == null )
                    return;
                _cmdClose.Click += eventHandler;
            }
        }

        internal virtual Label Label1
        {
            [DebuggerNonUserCode]
            get => _Label1;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _Label1 = value;
        }

        internal virtual LinkLabel lblHomepage
        {
            [DebuggerNonUserCode]
            get => _lblHomepage;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                LinkLabelLinkClickedEventHandler clickedEventHandler = new LinkLabelLinkClickedEventHandler( lblHomepage_LinkClicked );
                if ( _lblHomepage != null )
                    _lblHomepage.LinkClicked -= clickedEventHandler;
                _lblHomepage = value;
                if ( _lblHomepage == null )
                    return;
                _lblHomepage.LinkClicked += clickedEventHandler;
            }
        }

        internal virtual Label lblVersion
        {
            [DebuggerNonUserCode]
            get => _lblVersion;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _lblVersion = value;
        }

        internal virtual PictureBox PictureBox1
        {
            [DebuggerNonUserCode]
            get => _PictureBox1;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _PictureBox1 = value;
        }

        internal virtual TextBox txtAbout
        {
            [DebuggerNonUserCode]
            get => _txtAbout;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _txtAbout = value;
        }

        public frmAboutBox()
        {
            Load += new EventHandler( frmAboutBox_Load );
            lock ( __ENCList )
                __ENCList.Add( new WeakReference( this ) );
            InitializeComponent();
        }

        private void cmdClose_Click( object sender, EventArgs e )
        {
            Close();
        }

        protected override void Dispose( bool disposing )
        {
            if ( disposing && components != null )
                components.Dispose();
            base.Dispose( disposing );
        }

        private void frmAboutBox_Load( object sender, EventArgs e )
        {
            lblVersion.Text = "Core Version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ComponentResourceManager componentResourceManager = new ComponentResourceManager( typeof( frmAboutBox ) );
            PictureBox1 = new PictureBox();
            txtAbout = new TextBox();
            cmdClose = new Button();
            Label1 = new Label();
            lblVersion = new Label();
            lblHomepage = new LinkLabel();
            SuspendLayout();
            PictureBox1.Image = (Image) componentResourceManager.GetObject( "PictureBox1.Image" );
            Point point = new Point( 0, 0 );
            PictureBox1.Location = point;
            PictureBox1.Name = "PictureBox1";
            Size size = new Size( 454, 158 );
            PictureBox1.Size = size;
            PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            PictureBox1.TabIndex = 0;
            PictureBox1.TabStop = false;
            point = new Point( 192, 80 );
            txtAbout.Location = point;
            txtAbout.Multiline = true;
            txtAbout.Name = "txtAbout";
            txtAbout.ReadOnly = true;
            txtAbout.ScrollBars = ScrollBars.Vertical;
            size = new Size( 248, 152 );
            txtAbout.Size = size;
            txtAbout.TabIndex = 1;
            txtAbout.Text = "Gump Studio was written by Bradley Uffner in January of 2003.";
            point = new Point( 368, 240 );
            cmdClose.Location = point;
            cmdClose.Name = "cmdClose";
            size = new Size( 75, 23 );
            cmdClose.Size = size;
            cmdClose.TabIndex = 0;
            cmdClose.Text = "Close";
            point = new Point( 8, 168 );
            Label1.Location = point;
            Label1.Name = "Label1";
            size = new Size( 176, 23 );
            Label1.Size = size;
            Label1.TabIndex = 3;
            Label1.Text = "(C) Bradley Uffner, 2004";
            lblVersion.AutoSize = true;
            point = new Point( 8, 248 );
            lblVersion.Location = point;
            lblVersion.Name = "lblVersion";
            size = new Size( 42, 13 );
            lblVersion.Size = size;
            lblVersion.TabIndex = 4;
            lblVersion.Text = "Version";
            point = new Point( 8, 192 );
            lblHomepage.Location = point;
            lblHomepage.Name = "lblHomepage";
            size = new Size( 168, 23 );
            lblHomepage.Size = size;
            lblHomepage.TabIndex = 5;
            lblHomepage.TabStop = true;
            lblHomepage.Text = "http://www.gumpstudio.com";
            size = new Size( 5, 13 );
            AutoScaleBaseSize = size;
            size = new Size( 450, 272 );
            ClientSize = size;
            Controls.Add( lblHomepage );
            Controls.Add( lblVersion );
            Controls.Add( Label1 );
            Controls.Add( cmdClose );
            Controls.Add( txtAbout );
            Controls.Add( PictureBox1 );
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon) componentResourceManager.GetObject( "$this.Icon" );
            Name = nameof( frmAboutBox );
            Text = "About Gump Studio.NET";
            ResumeLayout( false );
            PerformLayout();
        }

        private void lblHomepage_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            Process.Start( new ProcessStartInfo()
            {
                UseShellExecute = true,
                FileName = "http://www.orbsydia.net"
            } );
        }

        public void SetText( string Text )
        {
            txtAbout.Text = "Gump Studio was designed and written by Bradley Uffner in 2004. It makes extensive use of a modified version of the UOSDK written by Krrios, available at www.RunUO.com. Artwork was created by Melanius, and several more ideas were contributed by the RunUO community.  Special thanks go to DarkStorm of the Wolfpack emulator for helping me to decode unifont.mul, allowing me to displaying UO fonts correctly.\r\n\r\n====Plugin Specific Information====\r\n" + Text;
        }
    }
}
