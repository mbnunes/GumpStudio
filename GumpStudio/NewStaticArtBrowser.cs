// Decompiled with JetBrains decompiler
// Type: GumpStudio.NewStaticArtBrowser
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
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Ultima;

namespace GumpStudio
{
    public class NewStaticArtBrowser : Form
    {
        private static List<WeakReference> __ENCList = new List<WeakReference>();
        private bool SearchSomething;
        [AccessedThroughProperty( "cmdCache" )]
        private Button _cmdCache;
        [AccessedThroughProperty( "cmdSearch" )]
        private Button _cmdSearch;
        [AccessedThroughProperty( "lblID" )]
        private Label _lblID;
        [AccessedThroughProperty( "lblName" )]
        private Label _lblName;
        [AccessedThroughProperty( "lblSize" )]
        private Label _lblSize;
        [AccessedThroughProperty( "lblWait" )]
        private Label _lblWait;
        [AccessedThroughProperty( "picCanvas" )]
        private PictureBox _picCanvas;
        [AccessedThroughProperty( "ToolTip1" )]
        private ToolTip _ToolTip1;
        [AccessedThroughProperty( "txtSearch" )]
        private TextBox _txtSearch;
        [AccessedThroughProperty( "vsbScroller" )]
        private VScrollBar _vsbScroller;
        protected static Bitmap BlankCache;
        protected bool BuildingCache;
        protected static GumpCacheEntry[] Cache;
        private IContainer components;
        protected Size DisplaySize;
        protected Point HoverPos;
        protected int NumX;
        protected int NumY;
        protected static Bitmap[] RowCache;
        protected int SelectedIndex;
        protected int StartIndex;

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

        public int ItemID
        {
            get => Cache[SelectedIndex].ID;
            set
            {
                if ( Cache == null )
                    return;
                int num = Information.UBound( Cache, 1 );
                for ( int index = 0 ; index <= num ; ++index )
                {
                    if ( Cache[index].ID == value )
                    {
                        SelectedIndex = index;
                        lblName.Text = "Name: " + TileData.ItemTable[ItemID].Name;
                        lblSize.Text = "Size: " + Conversions.ToString( Art.GetStatic( ItemID ).Width ) + " x " + Conversions.ToString( Art.GetStatic( ItemID ).Height );
                    }
                }
            }
        }

        internal virtual Label lblID
        {
            [DebuggerNonUserCode]
            get => _lblID;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _lblID = value;
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

        internal virtual PictureBox picCanvas
        {
            [DebuggerNonUserCode]
            get => _picCanvas;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                EventHandler eventHandler1 = new EventHandler( picCanvas_DoubleClick );
                MouseEventHandler mouseEventHandler1 = new MouseEventHandler( picCanvas_MouseUp );
                EventHandler eventHandler2 = new EventHandler( picCanvas_MouseLeave );
                MouseEventHandler mouseEventHandler2 = new MouseEventHandler( picCanvas_MouseMove );
                PaintEventHandler paintEventHandler = new PaintEventHandler( picCanvas_Paint );
                if ( _picCanvas != null )
                {
                    _picCanvas.DoubleClick -= eventHandler1;
                    _picCanvas.MouseUp -= mouseEventHandler1;
                    _picCanvas.MouseLeave -= eventHandler2;
                    _picCanvas.MouseMove -= mouseEventHandler2;
                    _picCanvas.Paint -= paintEventHandler;
                }
                _picCanvas = value;
                if ( _picCanvas == null )
                    return;
                _picCanvas.DoubleClick += eventHandler1;
                _picCanvas.MouseUp += mouseEventHandler1;
                _picCanvas.MouseLeave += eventHandler2;
                _picCanvas.MouseMove += mouseEventHandler2;
                _picCanvas.Paint += paintEventHandler;
            }
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

        internal virtual VScrollBar vsbScroller
        {
            [DebuggerNonUserCode]
            get => _vsbScroller;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                ScrollEventHandler scrollEventHandler = new ScrollEventHandler( vsbScroller_Scroll );
                if ( _vsbScroller != null )
                    _vsbScroller.Scroll -= scrollEventHandler;
                _vsbScroller = value;
                if ( _vsbScroller == null )
                    return;
                _vsbScroller.Scroll += scrollEventHandler;
            }
        }

        public NewStaticArtBrowser()
        {
            Load += new EventHandler( NewStaticArtBrowser_Load );
            Resize += new EventHandler( NewStaticArtBrowser_Resize );
            lock ( __ENCList )
                __ENCList.Add( new WeakReference( this ) );
            DisplaySize = new Size( 45, 45 );
            HoverPos = new Point( -1, -1 );
            SelectedIndex = 0;
            BuildingCache = false;
            InitializeComponent();
        }

        protected void BuildCache()
        {
            if ( BuildingCache )
                return;
            BuildingCache = true;
            lblWait.Text = "Please Wait, Generating Art Cache...";
            Show();
            FileStream fileStream = null;
            try
            {
                Cache = null;
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
                MessageBox.Show( "Error creating cache file:\r\n" + ex.Message );
                ProjectData.ClearProjectError();
            }
            finally
            {
                fileStream?.Close();
                lblWait.Visible = false;
                Application.DoEvents();
                BuildingCache = false;
            }
        }

        private void cmdCache_Click( object sender, EventArgs e )
        {
            //if ( Interaction.MsgBox( (object) "Rebuilding the cache may take several minutes debending on the speed of your computer.\r\nAre you sure you want to continue?", MsgBoxStyle.YesNo | MsgBoxStyle.Information, (object) "Rebuild Cache" ) != MsgBoxResult.Yes )
            //    return;

            DialogResult result = MessageBox.Show( "Rebuilding the cache may take several minutes debending on the speed of your computer.\r\nAre you sure you want to continue?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question );

            if ( result != DialogResult.OK )
                return;

            BuildCache();
            RowCache = new Bitmap[(int) Math.Round( Cache.Length / (double) NumX ) + 1 + 1];
            ItemID = 0;
            picCanvas.Invalidate();
        }

        private void cmdSearch_Click( object sender, EventArgs e )
        {
            int index1 = -1;
            int index2 = SelectedIndex == -1 ? 0 : SelectedIndex;
            while ( index1 == -1 & index2 < Cache.Length - 1 )
            {
                ++index2;
                if ( Strings.InStr( Cache[index2].Name, txtSearch.Text, CompareMethod.Text ) > 0 )
                    index1 = index2;
            }
            if ( index1 != -1 )
                ItemID = Cache[index1].ID;
            if ( index1 == -1 & index2 > 0 && !SearchSomething )
            {
                SelectedIndex = 0;
                SearchSomething = true;
                cmdSearch_Click( RuntimeHelpers.GetObjectValue( sender ), e );
            }
            vsbScroller.Value = SelectedIndex / NumX;
            vsbScroller_Scroll( vsbScroller, null );
            SearchSomething = false;
        }

        protected override void Dispose( bool disposing )
        {
            if ( disposing && components != null )
                components.Dispose();
            base.Dispose( disposing );
        }

        protected void DrawGrid( Graphics g )
        {
            int numX = NumX;
            for ( int index = 0 ; index <= numX ; ++index )
                g.DrawLine( Pens.Black, index * DisplaySize.Width, 0, index * DisplaySize.Width, ( NumY + 1 ) * DisplaySize.Height );
            int num = NumY + 1;
            for ( int index = 0 ; index <= num ; ++index )
                g.DrawLine( Pens.Black, 0, index * DisplaySize.Height, NumX * DisplaySize.Width, index * DisplaySize.Height );
        }

        protected void DrawHover( Graphics g )
        {
            int x = HoverPos.X;
            int y = HoverPos.Y;
            int index = StartIndex + x + y * NumX;
            if ( index >= Cache.Length )
                return;
            int id = Cache[index].ID;
            Bitmap bitmap = Art.GetStatic( id );
            Point point = new Point();
            point.X = (int) Math.Round( x * DisplaySize.Width + DisplaySize.Width / 2.0 ) - (int) Math.Round( bitmap.Width / 2.0 ) - 3;
            if ( point.X < 0 )
                point.X = 0;
            if ( point.X + bitmap.Width > picCanvas.Width )
                point.X = picCanvas.Width - bitmap.Width - 3;
            point.Y = (int) Math.Round( y * DisplaySize.Height + DisplaySize.Height / 2.0 ) - (int) Math.Round( bitmap.Height / 2.0 ) - 3;
            if ( point.Y < 0 )
                point.Y = 0;
            if ( point.Y + bitmap.Height > picCanvas.Height )
                point.Y = picCanvas.Height - bitmap.Height - 3;
            Rectangle rect = new Rectangle( point, bitmap.Size );
            SolidBrush solidBrush = new SolidBrush( Color.FromArgb( sbyte.MaxValue, Color.Black ) );
            g.FillRectangle( solidBrush, point.X + 5, point.Y + 5, rect.Width, rect.Height );
            g.FillRectangle( Brushes.White, rect );
            g.DrawRectangle( Pens.Black, rect );
            g.DrawImage( bitmap, point );
            lblName.Text = "Name: " + TileData.ItemTable[id].Name;
            lblSize.Text = "Size: " + Conversions.ToString( bitmap.Width ) + " x " + Conversions.ToString( bitmap.Height );
            lblID.Text = "ID: " + Conversions.ToString( id ) + " - hex:" + Conversion.Hex( id );
            bitmap.Dispose();
            solidBrush.Dispose();
        }

        protected Bitmap GetRowImage( int Row )
        {
            if ( Row >= RowCache.Length )
            {
                if ( BlankCache != null )
                    return BlankCache;
                Bitmap bitmap = new Bitmap( NumX * DisplaySize.Width, DisplaySize.Height, PixelFormat.Format16bppRgb565 );
                Graphics graphics = Graphics.FromImage( bitmap );
                graphics.Clear( Color.Gray );
                graphics.Dispose();
                BlankCache = bitmap;
                return bitmap;
            }
            if ( RowCache[Row] != null )
                return RowCache[Row];
            Bitmap bitmap1 = new Bitmap( NumX * DisplaySize.Width, DisplaySize.Height, PixelFormat.Format16bppRgb565 );
            Graphics graphics1 = Graphics.FromImage( bitmap1 );
            graphics1.Clear( Color.Gray );
            Region clip = graphics1.Clip;
            Rectangle rect = new Rectangle( 0, 0, NumX * DisplaySize.Width, NumY * DisplaySize.Height );
            Region region1 = new Region( rect );
            graphics1.Clip = region1;
            int num = NumX - 1;
            for ( int index1 = 0 ; index1 <= num ; ++index1 )
            {
                int index2 = Row * NumX + index1;
                if ( index2 < Cache.Length )
                {
                    Bitmap bitmap2 = Art.GetStatic( Cache[index2].ID );
                    rect = new Rectangle( index1 * DisplaySize.Width, 0, DisplaySize.Width, DisplaySize.Height );
                    Region region2 = new Region( rect );
                    graphics1.Clip = region2;
                    graphics1.FillRectangle( Brushes.White, index1 * DisplaySize.Width, 0, DisplaySize.Width, DisplaySize.Height );
                    graphics1.DrawImage( bitmap2, index1 * DisplaySize.Width + 1, 0 );
                    bitmap2.Dispose();
                    region2.Dispose();
                }
            }
            graphics1.Clip = clip;
            graphics1.Dispose();
            RowCache[Row] = bitmap1;
            return bitmap1;
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            components = new Container();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager( typeof( NewStaticArtBrowser ) );
            picCanvas = new PictureBox();
            vsbScroller = new VScrollBar();
            txtSearch = new TextBox();
            cmdSearch = new Button();
            lblName = new Label();
            lblSize = new Label();
            cmdCache = new Button();
            lblWait = new Label();
            ToolTip1 = new ToolTip( components );
            lblID = new Label();
            SuspendLayout();
            picCanvas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            Point point = new Point( 0, 0 );
            picCanvas.Location = point;
            picCanvas.Name = "picCanvas";
            Size size = new Size( 488, 396 );
            picCanvas.Size = size;
            picCanvas.TabIndex = 0;
            picCanvas.TabStop = false;
            vsbScroller.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            point = new Point( 488, 0 );
            vsbScroller.Location = point;
            vsbScroller.Name = "vsbScroller";
            size = new Size( 17, 396 );
            vsbScroller.Size = size;
            vsbScroller.TabIndex = 3;
            txtSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            point = new Point( 56, 403 );
            txtSearch.Location = point;
            txtSearch.Name = "txtSearch";
            size = new Size( 100, 20 );
            txtSearch.Size = size;
            txtSearch.TabIndex = 4;
            cmdSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            point = new Point( 160, 403 );
            cmdSearch.Location = point;
            cmdSearch.Name = "cmdSearch";
            size = new Size( 50, 20 );
            cmdSearch.Size = size;
            cmdSearch.TabIndex = 5;
            cmdSearch.Text = "Search";
            lblName.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblName.AutoSize = true;
            point = new Point( 216, 405 );
            lblName.Location = point;
            lblName.Name = "lblName";
            size = new Size( 38, 13 );
            lblName.Size = size;
            lblName.TabIndex = 6;
            lblName.Text = "Name:";
            lblSize.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblSize.AutoSize = true;
            point = new Point( 408, 405 );
            lblSize.Location = point;
            lblSize.Name = "lblSize";
            size = new Size( 30, 13 );
            lblSize.Size = size;
            lblSize.TabIndex = 7;
            lblSize.Text = "Size:";
            cmdCache.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cmdCache.FlatStyle = FlatStyle.Flat;
            cmdCache.Image = (Image) componentResourceManager.GetObject( "cmdCache.Image" );
            point = new Point( 0, 402 );
            cmdCache.Location = point;
            cmdCache.Name = "cmdCache";
            size = new Size( 32, 23 );
            cmdCache.Size = size;
            cmdCache.TabIndex = 9;
            ToolTip1.SetToolTip( cmdCache, "Rebuild Art Cache" );
            lblWait.BackColor = Color.Transparent;
            lblWait.BorderStyle = BorderStyle.Fixed3D;
            lblWait.Font = new Font( "Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0 );
            point = new Point( 164, 159 );
            lblWait.Location = point;
            lblWait.Name = "lblWait";
            size = new Size( 184, 104 );
            lblWait.Size = size;
            lblWait.TabIndex = 10;
            lblWait.Text = "Please Wait, Generating Static Art Cache...";
            lblWait.TextAlign = ContentAlignment.MiddleCenter;
            lblWait.Visible = false;
            lblID.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblID.AutoSize = true;
            point = new Point( 216, 429 );
            lblID.Location = point;
            lblID.Name = "lblID";
            size = new Size( 21, 13 );
            lblID.Size = size;
            lblID.TabIndex = 11;
            lblID.Text = "ID:";
            size = new Size( 5, 13 );
            AutoScaleBaseSize = size;
            size = new Size( 505, 451 );
            ClientSize = size;
            Controls.Add( lblID );
            Controls.Add( lblWait );
            Controls.Add( cmdCache );
            Controls.Add( lblSize );
            Controls.Add( lblName );
            Controls.Add( cmdSearch );
            Controls.Add( txtSearch );
            Controls.Add( vsbScroller );
            Controls.Add( picCanvas );
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            size = new Size( 521, 3000 );
            MaximumSize = size;
            size = new Size( 521, 200 );
            MinimumSize = size;
            Name = nameof( NewStaticArtBrowser );
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Static Art Browser";
            ResumeLayout( false );
            PerformLayout();
        }

        private void NewStaticArtBrowser_Load( object sender, EventArgs e )
        {
            if ( Cache == null )
            {
                FileStream fileStream = null;
                if ( !File.Exists( Application.StartupPath + "/StaticArt.cache" ) )
                {
                    BuildCache();
                }
                else
                {
                    try
                    {
                        fileStream = new FileStream( Application.StartupPath + "/StaticArt.cache", FileMode.Open );
                        Cache = (GumpCacheEntry[]) new BinaryFormatter().Deserialize( fileStream );
                    }
                    catch ( Exception ex )
                    {
                        ProjectData.SetProjectError( ex );
                        //int num = (int) Interaction.MsgBox( (object) ( "Error reading cache file:\r\n" + ex.Message ), MsgBoxStyle.OkOnly, (object) null );
                        MessageBox.Show( "Error reading cache file:\r\n" + ex.Message );
                        ProjectData.ClearProjectError();
                    }
                    finally
                    {
                        fileStream?.Close();
                    }
                }
            }
            picCanvas.Width = ClientSize.Width - vsbScroller.Width;
            Show();
            vsbScroller.Maximum = (int) Math.Round( Cache.Length / (double) NumX ) + 1;
            vsbScroller.LargeChange = NumY - 1;
            if ( RowCache == null )
                RowCache = new Bitmap[(int) Math.Round( Cache.Length / (double) NumX ) + 1 + 1];
            vsbScroller.Value = SelectedIndex / NumX;
            vsbScroller_Scroll( vsbScroller, null );
            lblName.Text = "Name: " + TileData.ItemTable[Cache[SelectedIndex].ID].Name;
            lblSize.Text = "Size: " + Conversions.ToString( Cache[SelectedIndex].Size.Width ) + " x " + Conversions.ToString( Cache[SelectedIndex].Size.Height );
        }

        private void NewStaticArtBrowser_Resize( object sender, EventArgs e )
        {
            int num1 = 11;
            int num2 = picCanvas.Height / DisplaySize.Height;
            if ( !( num1 != NumX | num2 != NumY ) )
                return;
            NumX = num1;
            NumY = num2;
            if ( Cache == null )
                return;
            vsbScroller.Maximum = (int) Math.Round( Cache.Length / (double) NumX ) + 1;
            vsbScroller.LargeChange = NumY - 1;
            picCanvas.Invalidate();
        }

        private void picCanvas_DoubleClick( object sender, EventArgs e )
        {
            if ( BuildingCache )
                return;
            DialogResult = DialogResult.OK;
        }

        private void picCanvas_MouseLeave( object sender, EventArgs e )
        {
            HoverPos = new Point( -1, -1 );
            picCanvas.Invalidate();
            lblName.Text = "Name: " + TileData.ItemTable[Cache[SelectedIndex].ID].Name;
            lblSize.Text = "Size: " + Conversions.ToString( Cache[SelectedIndex].Size.Width ) + " x " + Conversions.ToString( Cache[SelectedIndex].Size.Height );
            lblID.Text = "ID: " + Conversions.ToString( Cache[SelectedIndex].ID ) + "(0x" + Conversion.Hex( Cache[SelectedIndex].ID ) + ")";
        }

        private void picCanvas_MouseMove( object sender, MouseEventArgs e )
        {
            Point point = new Point( e.X / DisplaySize.Width, e.Y / DisplaySize.Height );
            if ( point.X >= 11 || !( point.X != HoverPos.X | point.Y != HoverPos.Y ) )
                return;
            HoverPos = point;
            picCanvas.Invalidate();
        }

        private void picCanvas_MouseUp( object sender, MouseEventArgs e )
        {
            int index = e.X / DisplaySize.Width + e.Y / DisplaySize.Height * NumX + StartIndex;
            if ( index >= Cache.Length )
                return;
            ItemID = Cache[index].ID;
            picCanvas.Invalidate();
        }

        private void picCanvas_Paint( object sender, PaintEventArgs e )
        {
            try
            {
                Render( e.Graphics );
                if ( HoverPos.Equals( (object) new Point( -1, -1 ) ) )
                    return;
                DrawHover( e.Graphics );
            }
            catch ( Exception ex )
            {
            }
        }

        public void Render( Graphics g )
        {
            if ( Cache == null | RowCache == null )
                return;
            Rectangle rect = new Rectangle();
            g.Clear( Color.Gray );
            DrawGrid( g );
            Region clip = g.Clip;
            int num = StartIndex / NumX;
            bool flag = false;
            int numY = NumY;
            for ( int index = 0 ; index <= numY ; ++index )
            {
                g.DrawImage( GetRowImage( index + num ), 0, index * DisplaySize.Height );
                if ( ( flag || index + num != SelectedIndex / NumX ? 0 : 1 ) != 0 )
                {
                    flag = true;
                    rect = new Rectangle( SelectedIndex % NumX * DisplaySize.Width, index * DisplaySize.Height, DisplaySize.Width, DisplaySize.Height );
                }
            }
            DrawGrid( g );
            if ( flag )
            {
                Region region = new Region( rect );
                rect.Inflate( 5, 5 );
                SolidBrush solidBrush = new SolidBrush( Color.FromArgb( sbyte.MaxValue, Color.Blue ) );
                g.FillRectangle( solidBrush, rect );
                g.DrawRectangle( Pens.Blue, rect );
                solidBrush.Dispose();
                rect.Inflate( -5, -5 );
                g.Clip = region;
                g.DrawImage( Art.GetStatic( Cache[SelectedIndex].ID ), rect.Location );
                g.Clip = clip;
                region.Dispose();
            }
            g.Clip = clip;
        }

        private void vsbScroller_Scroll( object sender, ScrollEventArgs e )
        {
            StartIndex = vsbScroller.Value * NumX;
            picCanvas.Invalidate();
        }
    }
}
