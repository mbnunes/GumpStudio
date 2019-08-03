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
        [AccessedThroughProperty( "cmdCache" )]
        private Button _cmdCache;
        [AccessedThroughProperty( "cmdOK" )]
        private Button _cmdOK;
        [AccessedThroughProperty( "lblSize" )]
        private Label _lblSize;
        [AccessedThroughProperty( "lblWait" )]
        private Label _lblWait;
        [AccessedThroughProperty( "lstGump" )]
        private ListBox _lstGump;
        [AccessedThroughProperty( "Panel1" )]
        private Panel _Panel1;
        [AccessedThroughProperty( "picFullSize" )]
        private PictureBox _picFullSize;
        [AccessedThroughProperty( "ToolTip1" )]
        private ToolTip _ToolTip1;
        protected static GumpCacheEntry[] Cache;
        private IContainer components;
        public int GumpID;

        internal virtual Button cmdCache
        {
            [DebuggerNonUserCode]
            get => _cmdCache;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                EventHandler eventHandler = new EventHandler( cmdCache_Click );
                if ( _cmdCache != null )
                    _cmdCache.Click -= eventHandler;
                _cmdCache = value;
                if ( _cmdCache == null )
                    return;
                _cmdCache.Click += eventHandler;
            }
        }

        internal virtual Button cmdOK
        {
            [DebuggerNonUserCode]
            get => _cmdOK;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                EventHandler eventHandler = new EventHandler( cmdOK_Click );
                if ( _cmdOK != null )
                    _cmdOK.Click -= eventHandler;
                _cmdOK = value;
                if ( _cmdOK == null )
                    return;
                _cmdOK.Click += eventHandler;
            }
        }

        internal virtual Label lblSize
        {
            [DebuggerNonUserCode]
            get => _lblSize;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _lblSize = value;
        }

        internal virtual Label lblWait
        {
            [DebuggerNonUserCode]
            get => _lblWait;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _lblWait = value;
        }

        internal virtual ListBox lstGump
        {
            [DebuggerNonUserCode]
            get => _lstGump;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                MeasureItemEventHandler itemEventHandler1 = new MeasureItemEventHandler( lstGump_MeasureItem );
                EventHandler eventHandler1 = new EventHandler( lstGump_SelectedIndexChanged );
                EventHandler eventHandler2 = new EventHandler( lstGump_DoubleClick );
                DrawItemEventHandler itemEventHandler2 = new DrawItemEventHandler( lstGump_DrawItem );
                if ( _lstGump != null )
                {
                    _lstGump.MeasureItem -= itemEventHandler1;
                    _lstGump.SelectedIndexChanged -= eventHandler1;
                    _lstGump.DoubleClick -= eventHandler2;
                    _lstGump.DrawItem -= itemEventHandler2;
                }
                _lstGump = value;
                if ( _lstGump == null )
                    return;
                _lstGump.MeasureItem += itemEventHandler1;
                _lstGump.SelectedIndexChanged += eventHandler1;
                _lstGump.DoubleClick += eventHandler2;
                _lstGump.DrawItem += itemEventHandler2;
            }
        }

        internal virtual Panel Panel1
        {
            [DebuggerNonUserCode]
            get => _Panel1;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _Panel1 = value;
        }

        internal virtual PictureBox picFullSize
        {
            [DebuggerNonUserCode]
            get => _picFullSize;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _picFullSize = value;
        }

        internal virtual ToolTip ToolTip1
        {
            [DebuggerNonUserCode]
            get => _ToolTip1;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _ToolTip1 = value;
        }

        public GumpArtBrowser()
        {
            Load += new EventHandler( GumpArtBrowser_Load );
            lock ( __ENCList )
                __ENCList.Add( new WeakReference( this ) );
            InitializeComponent();
        }

        protected void BuildCache()
        {
            lblWait.Text = "Please Wait, Generating Art Cache...";
            Show();
            Cache = null;
            lstGump.Items.Clear();
            lblWait.Visible = true;
            Application.DoEvents();
            int index = 0;
            int maxValue = ushort.MaxValue;
            try
            {
                do
                {
                    lblWait.Text = "Please Wait, Generating Art Cache...  " + Strings.Format( (int) ( 100 * index / (double) maxValue ), "Fixed" ) + "%";
                    Application.DoEvents();
                    Bitmap gump;
                    try
                    {
                        gump = Gumps.GetGump( index );
                    }
                    catch ( Exception ex )
                    {
                        ++index;
                        goto label_7;
                    }
                    if ( gump != null )
                    {
                        Cache = Cache != null ? (GumpCacheEntry[]) Utils.CopyArray( Cache, new GumpCacheEntry[Cache.Length + 1] ) : new GumpCacheEntry[1];
                        Cache[Cache.Length - 1] = new GumpCacheEntry();
                        Cache[Cache.Length - 1].ID = index;
                        Cache[Cache.Length - 1].Size = gump.Size;
                        gump.Dispose();
                    }
                    ++index;
                label_7:;
                }
                while ( index <= maxValue );
                using ( FileStream fileStream = new FileStream( Application.StartupPath + "/GumpArt.cache", FileMode.Create ) )
                    new BinaryFormatter().Serialize( fileStream, Cache );
            }
            catch ( Exception ex )
            {
                ProjectData.SetProjectError( ex );
                //int num = (int) Interaction.MsgBox( (object) ( "Error creating cache file:\r\n" + ex.Message ), MsgBoxStyle.OkOnly, (object) null );
                MessageBox.Show( "Error creating cache file:\r\n" + ex.Message );
                ProjectData.ClearProjectError();
            }
            finally
            {
                lblWait.Visible = false;
                Application.DoEvents();
            }
        }

        private void cmdCache_Click( object sender, EventArgs e )
        {
            cmdOK.Enabled = false;

            DialogResult result = MessageBox.Show( "Rebuilding the cache may take several minutes debending on the speed of your computer.\r\nAre you sure you want to continue?", "Rebuild Cache", MessageBoxButtons.OKCancel, MessageBoxIcon.Information );

            if ( result == DialogResult.OK )
            {
                BuildCache();
                PopulateListbox();
            }
            cmdOK.Enabled = true;
        }

        private void cmdOK_Click( object sender, EventArgs e )
        {
            GumpID = Conversions.ToInteger( lstGump.SelectedItem );
            DialogResult = DialogResult.OK;
        }

        protected override void Dispose( bool disposing )
        {
            if ( disposing && components != null )
                components.Dispose();
            base.Dispose( disposing );
        }

        private void GumpArtBrowser_Load( object sender, EventArgs e )
        {
            if ( Cache == null )
            {
                FileStream fileStream = null;
                if ( !File.Exists( Application.StartupPath + "/GumpArt.cache" ) )
                {
                    BuildCache();
                }
                else
                {
                    try
                    {
                        fileStream = new FileStream( Application.StartupPath + "/GumpArt.cache", FileMode.Open );
                        Cache = (GumpCacheEntry[]) new BinaryFormatter().Deserialize( fileStream );
                    }
                    catch ( Exception ex )
                    {
                        ProjectData.SetProjectError( ex );
                        //int num = (int) Interaction.MsgBox( (object) ( "Error Reading cache file:\r\n" + ex.Message ), MsgBoxStyle.OkOnly, (object) null );
                        MessageBox.Show( "Error Reading cache file:\r\n" + ex.Message );
                        ProjectData.ClearProjectError();
                    }
                    finally
                    {
                        fileStream?.Close();
                    }
                }
            }
            PopulateListbox();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            components = new Container();
            ResourceManager resourceManager = new ResourceManager( typeof( GumpArtBrowser ) );
            lstGump = new ListBox();
            Panel1 = new Panel();
            picFullSize = new PictureBox();
            lblSize = new Label();
            lblWait = new Label();
            cmdCache = new Button();
            ToolTip1 = new ToolTip( components );
            cmdOK = new Button();
            Panel1.SuspendLayout();
            SuspendLayout();
            lstGump.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lstGump.DrawMode = DrawMode.OwnerDrawVariable;
            lstGump.IntegralHeight = false;
            lstGump.Location = new Point( 8, 8 );
            lstGump.Name = "lstGump";
            lstGump.Size = new Size( 184, 320 );
            lstGump.TabIndex = 0;
            Panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Panel1.AutoScroll = true;
            Panel1.BackColor = Color.Black;
            Panel1.BorderStyle = BorderStyle.Fixed3D;
            Panel1.Controls.Add( picFullSize );
            Panel1.Location = new Point( 200, 8 );
            Panel1.Name = "Panel1";
            Panel1.Size = new Size( 312, 288 );
            Panel1.TabIndex = 1;
            picFullSize.Location = new Point( 0, 0 );
            picFullSize.Name = "picFullSize";
            picFullSize.SizeMode = PictureBoxSizeMode.AutoSize;
            picFullSize.TabIndex = 0;
            picFullSize.TabStop = false;
            lblSize.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblSize.AutoSize = true;
            lblSize.Location = new Point( 200, 307 );
            lblSize.Name = "lblSize";
            lblSize.Size = new Size( 0, 16 );
            lblSize.TabIndex = 2;
            lblWait.BackColor = Color.Transparent;
            lblWait.BorderStyle = BorderStyle.Fixed3D;
            lblWait.Font = new Font( "Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0 );
            lblWait.Location = new Point( 168, 131 );
            lblWait.Name = "lblWait";
            lblWait.Size = new Size( 184, 72 );
            lblWait.TabIndex = 1;
            lblWait.Text = "Please Wait, Generating Art Cache...";
            lblWait.TextAlign = ContentAlignment.MiddleCenter;
            lblWait.Visible = false;
            cmdCache.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cmdCache.FlatStyle = FlatStyle.Flat;
            cmdCache.Image = (Image) resourceManager.GetObject( "cmdCache.Image" );
            cmdCache.Location = new Point( 480, 304 );
            cmdCache.Name = "cmdCache";
            cmdCache.Size = new Size( 32, 23 );
            cmdCache.TabIndex = 3;
            ToolTip1.SetToolTip( cmdCache, "Rebuild Cache" );
            cmdOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cmdOK.FlatStyle = FlatStyle.System;
            cmdOK.Location = new Point( 400, 304 );
            cmdOK.Name = "cmdOK";
            cmdOK.TabIndex = 4;
            cmdOK.Text = "OK";
            AcceptButton = cmdOK;
            AutoScaleBaseSize = new Size( 5, 13 );
            ClientSize = new Size( 520, 334 );
            Controls.Add( cmdOK );
            Controls.Add( cmdCache );
            Controls.Add( lblWait );
            Controls.Add( lblSize );
            Controls.Add( Panel1 );
            Controls.Add( lstGump );
            Name = nameof( GumpArtBrowser );
            Text = "GumpID Browser";
            Panel1.ResumeLayout( false );
            ResumeLayout( false );
        }

        private void lstGump_DoubleClick( object sender, EventArgs e )
        {
            GumpID = Conversions.ToInteger( lstGump.SelectedItem );
            DialogResult = DialogResult.OK;
        }

        private void lstGump_DrawItem( object sender, DrawItemEventArgs e )
        {
            try
            {
                if ( e.Index == -1 )
                    return;
                Size size1 = new Size();
                Graphics graphics = e.Graphics;
                Bitmap gump = Gumps.GetGump( Cache[e.Index].ID );
                Size size2 = Cache[e.Index].Size;
                size1.Width = size2.Width <= 100 ? size2.Width : 100;
                size1.Height = size2.Height <= 100 ? size2.Height : 100;
                Rectangle rect = new Rectangle( e.Bounds.Location, size1 );
                rect.Offset( 45, 3 );
                if ( ( e.State & DrawItemState.Selected ) > DrawItemState.None )
                    graphics.FillRectangle( SystemBrushes.Highlight, e.Bounds );
                else
                    graphics.FillRectangle( SystemBrushes.Window, e.Bounds );
                graphics.DrawString( "0x" + Cache[e.Index].ID.ToString( "X" ), Font, SystemBrushes.WindowText, e.Bounds.X, e.Bounds.Y );
                graphics.DrawImage( gump, rect );
                gump.Dispose();
            }
            catch ( Exception ex )
            {
                ProjectData.SetProjectError( ex );
                //int num = (int) Interaction.MsgBox( (object) ( "There was an error rendering the gump art, try rebuilding the cache.\r\n\r\n" + ex.Message ), MsgBoxStyle.OkOnly, (object) null );
                MessageBox.Show( "There was an error rendering the gump art, try rebuilding the cache.\r\n\r\n" + ex.Message );
                ProjectData.ClearProjectError();
            }
        }

        private void lstGump_MeasureItem( object sender, MeasureItemEventArgs e )
        {
            int height = Cache[e.Index].Size.Height;
            int num = height <= 100 ? ( height >= 15 ? height : 15 ) : 100;
            e.ItemHeight = num + 5;
        }

        private void lstGump_SelectedIndexChanged( object sender, EventArgs e )
        {
            if ( picFullSize.Image != null )
                picFullSize.Image.Dispose();
            picFullSize.Image = Gumps.GetGump( Conversions.ToInteger( lstGump.SelectedItem ) );
            lblSize.Text = "Width: " + Conversions.ToString( picFullSize.Image.Width ) + "   Height: " + Conversions.ToString( picFullSize.Image.Height );
        }

        private void PopulateListbox()
        {
            lstGump.Items.Clear();
            foreach ( GumpCacheEntry gumpCacheEntry in Cache )
                lstGump.Items.Add( gumpCacheEntry.ID );
            lstGump.SelectedItem = GumpID;
        }
    }
}
