// Decompiled with JetBrains decompiler
// Type: GumpStudio.StaticArtBrowser
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
    public class StaticArtBrowser : Form
    {
        private static List<WeakReference> __ENCList = new List<WeakReference>();
        [AccessedThroughProperty( "cmdCache" )]
        private Button _cmdCache;
        [AccessedThroughProperty( "cmdOK" )]
        private Button _cmdOK;
        [AccessedThroughProperty( "cmdSearch" )]
        private Button _cmdSearch;
        [AccessedThroughProperty( "lblName" )]
        private Label _lblName;
        [AccessedThroughProperty( "lblSize" )]
        private Label _lblSize;
        [AccessedThroughProperty( "lblWait" )]
        private Label _lblWait;
        [AccessedThroughProperty( "lstStatic" )]
        private ListBox _lstStatic;
        [AccessedThroughProperty( "Panel1" )]
        private Panel _Panel1;
        [AccessedThroughProperty( "picFullSize" )]
        private PictureBox _picFullSize;
        [AccessedThroughProperty( "ToolTip1" )]
        private ToolTip _ToolTip1;
        [AccessedThroughProperty( "txtSearch" )]
        private TextBox _txtSearch;
        protected static GumpCacheEntry[] Cache;
        private IContainer components;
        public int ItemID;

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

        internal virtual Button cmdSearch
        {
            [DebuggerNonUserCode]
            get => _cmdSearch;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                EventHandler eventHandler = new EventHandler( cmdSearch_Click );
                if ( _cmdSearch != null )
                    _cmdSearch.Click -= eventHandler;
                _cmdSearch = value;
                if ( _cmdSearch == null )
                    return;
                _cmdSearch.Click += eventHandler;
            }
        }

        internal virtual Label lblName
        {
            [DebuggerNonUserCode]
            get => _lblName;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _lblName = value;
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

        internal virtual ListBox lstStatic
        {
            [DebuggerNonUserCode]
            get => _lstStatic;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                EventHandler eventHandler1 = new EventHandler( lstGump_SelectedIndexChanged );
                EventHandler eventHandler2 = new EventHandler( lstGump_DoubleClick );
                DrawItemEventHandler itemEventHandler1 = new DrawItemEventHandler( lstGump_DrawItem );
                MeasureItemEventHandler itemEventHandler2 = new MeasureItemEventHandler( lstStatic_MeasureItem );
                if ( _lstStatic != null )
                {
                    _lstStatic.SelectedIndexChanged -= eventHandler1;
                    _lstStatic.DoubleClick -= eventHandler2;
                    _lstStatic.DrawItem -= itemEventHandler1;
                    _lstStatic.MeasureItem -= itemEventHandler2;
                }
                _lstStatic = value;
                if ( _lstStatic == null )
                    return;
                _lstStatic.SelectedIndexChanged += eventHandler1;
                _lstStatic.DoubleClick += eventHandler2;
                _lstStatic.DrawItem += itemEventHandler1;
                _lstStatic.MeasureItem += itemEventHandler2;
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

        internal virtual TextBox txtSearch
        {
            [DebuggerNonUserCode]
            get => _txtSearch;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _txtSearch = value;
        }

        public StaticArtBrowser()
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
            FileStream fileStream = null;
            try
            {
                Cache = null;
                lstStatic.Items.Clear();
                lblWait.Visible = true;
                Application.DoEvents();
                int upperBound = TileData.ItemTable.GetUpperBound( 0 );
                for ( int index = 0 ; index <= upperBound ; ++index )
                {
                    if ( index / 128.0 == Conversion.Int( index / 128.0 ) )
                    {
                        lblWait.Text = "Please Wait, Generating Static Art Cache...  \r\n" + Strings.Format( index / (double) TileData.ItemTable.GetUpperBound( 0 ) * 100.0, "Fixed" ) + "%";
                        Application.DoEvents();
                    }
                    Bitmap bitmap = Art.GetStatic( index );
                    if ( bitmap != null )
                    {
                        Cache = Cache != null ? (GumpCacheEntry[]) Utils.CopyArray( Cache, new GumpCacheEntry[Cache.Length + 1] ) : new GumpCacheEntry[1];
                        Cache[Cache.Length - 1] = new GumpCacheEntry();
                        Cache[Cache.Length - 1].ID = index;
                        Cache[Cache.Length - 1].Size = bitmap.Size;
                        Cache[Cache.Length - 1].Name = TileData.ItemTable[index].Name;
                    }
                }
                fileStream = new FileStream( Application.StartupPath + "/StaticArt.cache", FileMode.Create );
                new BinaryFormatter().Serialize( fileStream, Cache );
            }
            catch ( Exception ex )
            {
                ProjectData.SetProjectError( ex );
                //int num = (int) Interaction.MsgBox((object) ("Error creating cache file:\r\n" + ex.Message), MsgBoxStyle.OkOnly, (object) null);
                MessageBox.Show( "Error creating cache file:\r\n" + ex.Message );
                ProjectData.ClearProjectError();
            }
            finally
            {
                fileStream?.Close();
                lblWait.Visible = false;
                Application.DoEvents();
            }
        }

        private void cmdCache_Click( object sender, EventArgs e )
        {
            cmdOK.Enabled = false;
            //      if (Interaction.MsgBox((object) "Rebuilding the cache may take several minutes debending on the speed of your computer.\r\nAre you sure you want to continue?", MsgBoxStyle.YesNo | MsgBoxStyle.Information, (object) "Rebuild Cache") == MsgBoxResult.Yes)
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
            ItemID = Cache[lstStatic.SelectedIndex].ID;
            DialogResult = DialogResult.OK;
        }

        private void cmdSearch_Click( object sender, EventArgs e )
        {
            int num = -1;
            int index = lstStatic.SelectedIndex == -1 ? 0 : lstStatic.SelectedIndex;
            while ( num == -1 & index < Cache.Length - 1 )
            {
                ++index;
                if ( Strings.InStr( Cache[index].Name, txtSearch.Text, CompareMethod.Text ) > 0 )
                    num = index;
            }
            if ( num != -1 )
            {
                lstStatic.SelectedIndex = num;
                ItemID = num;
            }
            if ( !( num == -1 & index > 0 ) )
                return;
            lstStatic.SelectedIndex = 0;
            cmdSearch_Click( RuntimeHelpers.GetObjectValue( sender ), e );
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
                if ( !File.Exists( Application.StartupPath + "/StaticArt.cache" ) )
                {
                    BuildCache();
                }
                else
                {
                    try
                    {
                        Cache = (GumpCacheEntry[]) new BinaryFormatter().Deserialize( new FileStream( Application.StartupPath + "/StaticArt.cache", FileMode.Open ) );
                    }
                    catch ( Exception ex )
                    {
                        ProjectData.SetProjectError( ex );
                        //int num = (int) Interaction.MsgBox( (object) ( "Error Reading cache file:\r\n" + ex.Message ), MsgBoxStyle.OkOnly, (object) null );
                        MessageBox.Show( "Error Reading cache file:\r\n" + ex.Message );
                        ProjectData.ClearProjectError();
                    }
                }
            }
            PopulateListbox();
            picFullSize.Image = Art.GetStatic( ItemID );
            lblName.Text = "Name: " + TileData.ItemTable[ItemID].Name;
            lblSize.Text = "Size: " + Conversions.ToString( picFullSize.Image.Width ) + " x " + Conversions.ToString( picFullSize.Image.Height );
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            components = new Container();
            ResourceManager resourceManager = new ResourceManager( typeof( StaticArtBrowser ) );
            lstStatic = new ListBox();
            Panel1 = new Panel();
            lblSize = new Label();
            lblName = new Label();
            picFullSize = new PictureBox();
            lblWait = new Label();
            cmdCache = new Button();
            ToolTip1 = new ToolTip( components );
            cmdOK = new Button();
            txtSearch = new TextBox();
            cmdSearch = new Button();
            Panel1.SuspendLayout();
            SuspendLayout();
            lstStatic.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lstStatic.DrawMode = DrawMode.OwnerDrawVariable;
            lstStatic.IntegralHeight = false;
            Point point = new Point( 8, 8 );
            lstStatic.Location = point;
            lstStatic.Name = "lstStatic";
            Size size = new Size( 184, 320 );
            lstStatic.Size = size;
            lstStatic.TabIndex = 0;
            Panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Panel1.AutoScroll = true;
            Panel1.BackColor = Color.Black;
            Panel1.BorderStyle = BorderStyle.Fixed3D;
            Panel1.Controls.Add( lblSize );
            Panel1.Controls.Add( lblName );
            Panel1.Controls.Add( picFullSize );
            point = new Point( 200, 8 );
            Panel1.Location = point;
            Panel1.Name = "Panel1";
            size = new Size( 312, 288 );
            Panel1.Size = size;
            Panel1.TabIndex = 1;
            lblSize.AutoSize = true;
            lblSize.Font = new Font( "Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0 );
            lblSize.ForeColor = Color.White;
            point = new Point( 8, 256 );
            lblSize.Location = point;
            lblSize.Name = "lblSize";
            size = new Size( 32, 17 );
            lblSize.Size = size;
            lblSize.TabIndex = 5;
            lblSize.Text = "Size:";
            lblName.AutoSize = true;
            lblName.Font = new Font( "Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0 );
            lblName.ForeColor = Color.White;
            point = new Point( 8, 224 );
            lblName.Location = point;
            lblName.Name = "lblName";
            size = new Size( 41, 17 );
            lblName.Size = size;
            lblName.TabIndex = 7;
            lblName.Text = "Name:";
            point = new Point( 0, 0 );
            picFullSize.Location = point;
            picFullSize.Name = "picFullSize";
            picFullSize.SizeMode = PictureBoxSizeMode.AutoSize;
            picFullSize.TabIndex = 0;
            picFullSize.TabStop = false;
            lblWait.BackColor = Color.Transparent;
            lblWait.BorderStyle = BorderStyle.Fixed3D;
            lblWait.Font = new Font( "Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0 );
            point = new Point( 168, 115 );
            lblWait.Location = point;
            lblWait.Name = "lblWait";
            size = new Size( 184, 104 );
            lblWait.Size = size;
            lblWait.TabIndex = 1;
            lblWait.Text = "Please Wait, Generating Static Art Cache...";
            lblWait.TextAlign = ContentAlignment.MiddleCenter;
            lblWait.Visible = false;
            cmdCache.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cmdCache.FlatStyle = FlatStyle.Flat;
            cmdCache.Image = (Image) resourceManager.GetObject( "cmdCache.Image" );
            point = new Point( 480, 304 );
            cmdCache.Location = point;
            cmdCache.Name = "cmdCache";
            size = new Size( 32, 23 );
            cmdCache.Size = size;
            cmdCache.TabIndex = 3;
            ToolTip1.SetToolTip( cmdCache, "Rebuild Cache" );
            cmdOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cmdOK.FlatStyle = FlatStyle.System;
            point = new Point( 400, 304 );
            cmdOK.Location = point;
            cmdOK.Name = "cmdOK";
            cmdOK.TabIndex = 4;
            cmdOK.Text = "OK";
            txtSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            point = new Point( 200, 304 );
            txtSearch.Location = point;
            txtSearch.Name = "txtSearch";
            size = new Size( 136, 20 );
            txtSearch.Size = size;
            txtSearch.TabIndex = 5;
            txtSearch.Text = "";
            cmdSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            point = new Point( 336, 304 );
            cmdSearch.Location = point;
            cmdSearch.Name = "cmdSearch";
            size = new Size( 48, 23 );
            cmdSearch.Size = size;
            cmdSearch.TabIndex = 6;
            cmdSearch.Text = "Search";
            AcceptButton = cmdOK;
            size = new Size( 5, 13 );
            AutoScaleBaseSize = size;
            size = new Size( 520, 334 );
            ClientSize = size;
            Controls.Add( cmdSearch );
            Controls.Add( txtSearch );
            Controls.Add( cmdOK );
            Controls.Add( cmdCache );
            Controls.Add( lblWait );
            Controls.Add( Panel1 );
            Controls.Add( lstStatic );
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = nameof( StaticArtBrowser );
            Text = "GumpID Browser";
            Panel1.ResumeLayout( false );
            ResumeLayout( false );
        }

        private void lstGump_DoubleClick( object sender, EventArgs e )
        {
            ItemID = Cache[lstStatic.SelectedIndex].ID;
            DialogResult = DialogResult.OK;
        }

        private void lstGump_DrawItem( object sender, DrawItemEventArgs e )
        {
            try
            {
                if ( e.Index == -1 )
                    return;
                Graphics graphics = e.Graphics;
                Bitmap bitmap = Art.GetStatic( Cache[e.Index].ID );
                if ( bitmap == null )
                    return;
                Size size1 = new Size();
                Size size2 = Cache[e.Index].Size;
                size1.Width = size2.Width <= 100 ? size2.Width : 100;
                size1.Height = size2.Height <= 100 ? size2.Height : 100;
                Rectangle rect = new Rectangle( e.Bounds.Location, size1 );
                rect.Offset( 45, 3 );
                if ( ( e.State & DrawItemState.Selected ) > DrawItemState.None )
                    graphics.FillRectangle( SystemBrushes.Highlight, e.Bounds );
                else
                    graphics.FillRectangle( SystemBrushes.Window, e.Bounds );
                graphics.DrawString( Cache[e.Index].ID.ToString(), Font, SystemBrushes.WindowText, e.Bounds.X, e.Bounds.Y );
                graphics.DrawImage( bitmap, rect );
            }
            catch ( Exception ex )
            {
                ProjectData.SetProjectError( ex );
                ProjectData.ClearProjectError();
            }
        }

        private void lstGump_SelectedIndexChanged( object sender, EventArgs e )
        {
            if ( picFullSize.Image != null )
            {
                Image image = picFullSize.Image;
            }
            ItemID = Cache[lstStatic.SelectedIndex].ID;
            picFullSize.Image = Art.GetStatic( ItemID );
            lblName.Text = "Name: " + TileData.ItemTable[ItemID].Name;
            lblSize.Text = "Size: " + Conversions.ToString( picFullSize.Image.Width ) + " x " + Conversions.ToString( picFullSize.Image.Height );
        }

        private void lstStatic_MeasureItem( object sender, MeasureItemEventArgs e )
        {
            int height = Cache[e.Index].Size.Height;
            int num = height <= 100 ? height : 100;
            e.ItemHeight = num + 5;
        }

        private void PopulateListbox()
        {
            lstStatic.Items.Clear();
            lstStatic.Items.AddRange( Cache );
            lstStatic.SelectedItem = ItemID;
        }
    }
}
