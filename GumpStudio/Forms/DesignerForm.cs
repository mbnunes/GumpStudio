// Decompiled with JetBrains decompiler
// Type: GumpStudio.DesignerForm
// Assembly: GumpStudioCore, Version=1.8.3024.24259, Culture=neutral, PublicKeyToken=null
// MVID: A77D32E5-7519-4865-AA26-DCCB34429732
// Assembly location: C:\GumpStudio_1_8_R3_quinted-02\GumpStudioCore.dll

using GumpStudio.Elements;
using GumpStudio.Plugins;
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Ultima;
// ReSharper disable RedundantDelegateCreation

namespace GumpStudio.Forms
{
    public class DesignerForm : Form
    {
        private TextBox m_CanvasFocus;
        private ComboBox m_cboElements;
        private PropertyGrid m_ElementProperties;
        private Label m_Label1;
        
        private MenuStrip m_MainMenu;
        
        private ToolStripSeparator m_MenuItem1;
        
        private ToolStripSeparator m_MenuItem10;
        
        private ToolStripSeparator m_MenuItem3;
        
        private ToolStripSeparator m_MenuItem4;
        
        private ToolStripSeparator m_MenuItem5;
        
        private ToolStripSeparator m_MenuItem9;
        
        private ContextMenuStrip m_mnuContextMenu;
        
        private ToolStripMenuItem m_mnuCopy;
        
        private ToolStripMenuItem _mnuCut;
        
        private ToolStripMenuItem _mnuDataFile;
        
        private ToolStripMenuItem _mnuDelete;
        
        private ToolStripMenuItem _mnuEdit;
        
        private ToolStripMenuItem _mnuEditRedo;
        
        private ToolStripMenuItem _mnuEditUndo;
        
        private ToolStripMenuItem _mnuFile;
        
        private ToolStripMenuItem _mnuFileExit;
        
        private ToolStripMenuItem _mnuFileExport;
        
        private ToolStripMenuItem _mnuFileImport;
        
        private ToolStripMenuItem _mnuFileNew;
        
        private ToolStripMenuItem _mnuFileOpen;
        
        private ToolStripMenuItem _mnuFileSave;
        
        private ToolStripMenuItem _mnuGumplingAddFolder;
        
        private ToolStripMenuItem _mnuGumplingAddGumpling;
        
        private ContextMenuStrip _mnuGumplingContext;
        
        private ToolStripMenuItem _mnuGumplingDelete;
        
        private ToolStripMenuItem _mnuGumplingMove;
        
        private ToolStripMenuItem _mnuGumplingRename;
        
        private ToolStripMenuItem _mnuHelp;
        
        private ToolStripMenuItem _mnuHelpAbout;
        
        private ToolStripMenuItem _mnuImportGumpling;
        
        private ToolStripMenuItem _mnuMisc;
        
        private ToolStripMenuItem _mnuMiscLoadGumpling;
        
        private ToolStripMenuItem _mnuPage;
        
        private ToolStripMenuItem _mnuPageAdd;
        
        private ToolStripMenuItem _mnuPageClear;
        
        private ToolStripMenuItem _mnuPageDelete;
        
        private ToolStripMenuItem _mnuPageInsert;
        
        private ToolStripMenuItem _mnuPaste;
        
        private ToolStripMenuItem _mnuPluginManager;
        
        private ToolStripMenuItem _mnuPlugins;
        
        private ToolStripMenuItem _mnuSelectAll;
        
        private ToolStripMenuItem _mnuShow0;
        private OpenFileDialog _OpenDialog;
        private Panel _Panel1;
        private Panel _Panel2;
        private Panel _Panel3;
        private Panel _Panel4;
        private PictureBox _picCanvas;
        private Panel _pnlCanvasScroller;
        private Panel _pnlToolbox;
        private Panel _pnlToolboxHolder;
        private SaveFileDialog _SaveDialog;
        private Splitter _Splitter1;
        private Splitter _Splitter2;
        
        private StatusStrip _StatusBar;
        private TabPage _TabPage1;
        private TabControl _TabPager;
        private TabControl _tabToolbox;
        private TabPage _tpgCustom;
        private TabPage _tpgStandard;
        private TreeView _treGumplings;
        protected string AboutElementAppend;
        public BaseElement ActiveElement;
        public string AppPath;
        public decimal ArrowKeyDelta;
        protected ArrayList AvailablePlugins;
        protected Bitmap Canvas;
        private IContainer components;
        protected ClipBoardMode CopyMode;
        protected int CurrentUndoPoint;
        protected bool ElementChanged;
        public GroupElement ElementStack;
        protected string FileName;
        public TreeFolder GumplingsFolder;
        public TreeFolder GumplingTree;
        public GumpProperties GumpProperties;
        protected Point LastPos;
        protected ArrayList LoadedPlugins;
        protected Point mAnchor;
        protected Size mAnchorOffset;
        public int MaxUndoPoints;
        protected int MoveCount;
        protected MoveModeType MoveMode;
        public bool PluginClearsCanvas;
        public PluginInfo[] PluginTypesToLoad;
        protected ArrayList RegisteredTypes;
        protected Point ScrollPos;
        protected LinearGradientBrush SelBG;
        protected Rectangle SelectionRect;
        protected Pen SelFG;
        public bool ShouldClearActiveElement;
        protected bool ShowGrid;
        protected bool ShowPage0;
        protected bool ShowSelectionRect;
        public ArrayList Stacks;
        public bool SuppressUndoPoints;
        public TreeFolder UncategorizedFolder;
        private ToolStripContainer toolStripContainer1;
        protected ArrayList UndoPoints;

        public virtual TextBox CanvasFocus
        {

            get => m_CanvasFocus;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => m_CanvasFocus = value;
        }



        public virtual 
ToolStripMenuItem mnuFileExport
        {
            get => _mnuFileExport;
            set => _mnuFileExport = value;
        }

        public virtual 
ToolStripMenuItem mnuFileImport
        {
            get => _mnuFileImport;
            set => _mnuFileImport = value;
        }

        public 
ToolStripMenuItem mnuPlugins
        {
            get => _mnuPlugins;
            set => _mnuPlugins = value;
        }

        public PictureBox picCanvas
        {
            get => _picCanvas;
            set => _picCanvas = value;
        }

        public event HookKeyDownEventHandler HookKeyDown;
        public event HookPostRenderEventHandler HookPostRender;
        public event HookPreRenderEventHandler HookPreRender;

        public DesignerForm()
        {
            Closed += new EventHandler( DesignerForm_Closed );
            Closing += new CancelEventHandler( DesignerForm_Closing );
            ElementStack = new GroupElement( null, null, "CanvasStack", true );
            Stacks = new ArrayList();
            ShouldClearActiveElement = false;
            PluginClearsCanvas = false;
            AppPath = Application.StartupPath;
            ArrowKeyDelta = new decimal( 1 );
            ShowSelectionRect = false;
            MoveMode = MoveModeType.None;
            ShowGrid = false;
            ShowPage0 = true;
            ElementChanged = false;
            UndoPoints = new ArrayList();
            CurrentUndoPoint = -1;
            MaxUndoPoints = 25;
            SuppressUndoPoints = false;
            RegisteredTypes = new ArrayList();
            AvailablePlugins = new ArrayList();
            LoadedPlugins = new ArrayList();
            InitializeComponent();
            GlobalObjects.DesignerForm = this;
        }

        public void AddElement( BaseElement Element )
        {
            ElementStack.AddElement( Element );
            Element.Selected = true;
            SetActiveElement( Element, true );
            _picCanvas.Invalidate();
            CreateUndoPoint( Element.Name + " added" );
        }

        public int AddPage()
        {
            Stacks.Add( new GroupElement( null, null, "CanvasStack", true ) );
            _TabPager.TabPages.Add( new TabPage( Convert.ToString( Stacks.Count - 1 ) ) );
            _TabPager.SelectedIndex = Stacks.Count - 1;
            ChangeActiveStack( Stacks.Count - 1 );
            return Stacks.Count - 1;
        }

        public void BuildGumplingTree()
        {
            _treGumplings.Nodes.Clear();
            BuildGumplingTree( GumplingTree, null );
        }

        public void BuildGumplingTree( TreeFolder Item, TreeNode Node )
        {
            foreach ( object child in Item.GetChildren() )
            {
                TreeItem objectValue = (TreeItem) RuntimeHelpers.GetObjectValue( child );
                TreeNode treeNode = new TreeNode();
                treeNode.Text = objectValue.Text;
                treeNode.Tag = objectValue;
                if ( Node == null )
                    _treGumplings.Nodes.Add( treeNode );
                else
                    Node.Nodes.Add( treeNode );
                if ( objectValue is TreeFolder )
                    BuildGumplingTree( (TreeFolder) objectValue, treeNode );
            }
        }

        protected void BuildToolbox()
        {
            IEnumerator enumerator1 = null;
            _pnlToolbox.Controls.Clear();
            try
            {
                enumerator1 = RegisteredTypes.GetEnumerator();
                int y = 0;
                while ( enumerator1.MoveNext() )
                {
                    Type objectValue = (Type) RuntimeHelpers.GetObjectValue( enumerator1.Current );
                    BaseElement instance = (BaseElement) Activator.CreateInstance( objectValue );
                    Button button = new Button();
                    button.Text = instance.Type;
                    Point point = new Point( 0, y );
                    button.Location = point;
                    button.FlatStyle = FlatStyle.System;
                    button.Width = _pnlToolbox.Width;
                    button.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    button.Tag = objectValue;
                    y += button.Height - 1;
                    _pnlToolbox.Controls.Add( button );
                    button.Click += new EventHandler( CreateElementFromToolbox );
                    if ( instance.DispayInAbout() )
                        AboutElementAppend = AboutElementAppend + "\r\n\r\n" + instance.Type + ": " + instance.GetAboutText();
                    foreach ( object loadedPlugin in LoadedPlugins )
                        ( (BasePlugin) RuntimeHelpers.GetObjectValue( loadedPlugin ) ).InitializeElementExtenders( instance );
                }
            }
            catch ( Exception ex )
            {
                MessageBox.Show( $"Error\r\n{ex.Message}\n{ex.StackTrace}" );
            }
            finally
            {
                if ( enumerator1 is IDisposable disposable )
                    disposable.Dispose();
            }
            BaseElement.ResetID();
            GumplingTree = new TreeFolder( "Root" );
            GumplingsFolder = new TreeFolder( "My Gumplings" );
            UncategorizedFolder = new TreeFolder( "Uncategorized" );
            GumplingTree.AddItem( GumplingsFolder );
            GumplingTree.AddItem( UncategorizedFolder );
            BuildGumplingTree();
        }

        private void cboElements_Click( object sender, EventArgs e )
        {
            foreach ( object element in ElementStack.GetElements() )
                ( (BaseElement) RuntimeHelpers.GetObjectValue( element ) ).Selected = false;
            ActiveElement = null;
        }

        private void cboElements_SelectedIndexChanged( object sender, EventArgs e )
        {
            SetActiveElement( (BaseElement) m_cboElements.SelectedItem, false );
            _picCanvas.Invalidate();
        }

        protected void ChangeActiveElementEventHandler( BaseElement e, bool DeselectOthers )
        {
            SetActiveElement( e, DeselectOthers );
            _picCanvas.Invalidate();
        }

        public void ChangeActiveStack( int StackID )
        {
            if ( StackID > Stacks.Count - 1 )
                return;
            SetActiveElement( null, true );
            if ( ElementStack != null )
            {
                ElementStack.UpdateParent -= new BaseElement.UpdateParentEventHandler( ChangeActiveElementEventHandler );
                ElementStack.Repaint -= new BaseElement.RepaintEventHandler( RefreshView );
            }
            ElementStack = (GroupElement) Stacks[StackID];
            ElementStack.UpdateParent += new BaseElement.UpdateParentEventHandler( ChangeActiveElementEventHandler );
            ElementStack.Repaint += new BaseElement.RepaintEventHandler( RefreshView );
            _picCanvas.Invalidate();
        }

        public void ClearContextMenu( 
ToolStripDropDown menu )
        {
            int num = menu.Items.Count - 1;
            for ( int index = 0 ; index <= num ; ++index )
            {
                
                ToolStripMenuItem menuItem = (ToolStripMenuItem) menu.Items[0];
                menu.Items.RemoveAt( 0 );
            }
        }

        public void ClearGump()
        {
            _TabPager.TabPages.Clear();
            _TabPager.TabPages.Add( new TabPage( "0" ) );
            Stacks.Clear();
            BaseElement.ResetID();
            ElementStack = new GroupElement( null, null, "Element Stack", true );
            Stacks.Add( ElementStack );
            GumpProperties = new GumpProperties();
            ElementStack.UpdateParent += new BaseElement.UpdateParentEventHandler( ChangeActiveElementEventHandler );
            ElementStack.Repaint += new BaseElement.RepaintEventHandler( RefreshView );
            SetActiveElement( null );
            _picCanvas.Invalidate();
            FileName = "";
            Text = @"Gump Studio (-Unsaved Gump-)";
            ChangeActiveStack( 0 );
            UndoPoints = new ArrayList();
            CreateUndoPoint( "Blank" );
            _mnuEditUndo.Enabled = false;
            _mnuEditRedo.Enabled = false;
        }

        public void Copy()
        {
            ArrayList arrayList = new ArrayList();

            foreach ( object selectedElement in ElementStack.GetSelectedElements() )
                arrayList.Add( ( (BaseElement) RuntimeHelpers.GetObjectValue( selectedElement ) ).Clone() );

            Clipboard.SetDataObject( arrayList );
            CopyMode = ClipBoardMode.Copy;
        }

        public void CreateElementFromToolbox( object sender, EventArgs e )
        {
            AddElement( (BaseElement) Activator.CreateInstance( (Type) ( (Control) sender ).Tag ) );
            _picCanvas.Invalidate();
            _picCanvas.Focus();
        }

        public void CreateUndoPoint()
        {
            CreateUndoPoint( "Unknown Action" );
        }

        public void CreateUndoPoint( string Action )
        {
            if ( SuppressUndoPoints )
                return;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while ( CurrentUndoPoint < UndoPoints.Count - 1 )
            {
                UndoPoint undoPoint = (UndoPoint) UndoPoints[CurrentUndoPoint + 1];
                UndoPoints.RemoveAt( CurrentUndoPoint + 1 );
            }
            UndoPoint undoPoint1 = new UndoPoint( this );
            undoPoint1.Text = Action;
            if ( UndoPoints.Count > MaxUndoPoints )
                UndoPoints.RemoveAt( 0 );
            UndoPoints.Add( undoPoint1 );
            CurrentUndoPoint = UndoPoints.Count - 1;
            _mnuEditUndo.Enabled = true;
            _mnuEditRedo.Enabled = false;
            stopwatch.Stop();
        }

        public void Cut()
        {
            IEnumerator enumerator = null;
            ArrayList arrayList = new ArrayList();
            try
            {
                foreach ( object selectedElement in ElementStack.GetSelectedElements() )
                {
                    BaseElement objectValue = (BaseElement) RuntimeHelpers.GetObjectValue( selectedElement );
                    arrayList.Add( objectValue );
                }
            }
            finally
            {
                ( enumerator as IDisposable )?.Dispose();
            }
            Clipboard.SetDataObject( arrayList );
            DeleteSelectedElements();
            CopyMode = ClipBoardMode.Cut;
        }

        protected void DeleteSelectedElements()
        {
            IEnumerator enumerator = null;
            ArrayList arrayList = new ArrayList();
            arrayList.AddRange( ElementStack.GetElements() );
            bool flag = false;
            try
            {
                foreach ( object obj in arrayList )
                {
                    object objectValue = RuntimeHelpers.GetObjectValue( obj );
                    flag = true;
                    BaseElement e = (BaseElement) objectValue;
                    if ( e.Selected )
                        ElementStack.RemoveElement( e );
                }
            }
            finally
            {
                ( enumerator as IDisposable )?.Dispose();
            }
            SetActiveElement( GetLastSelectedControl() );
            _picCanvas.Invalidate();
            if ( !flag )
                return;
            CreateUndoPoint( "Delete Elements" );
        }

        private void DesignerForm_Closed( object sender, EventArgs e )
        {
            SelFG?.Dispose();
            SelBG?.Dispose();
            WritePluginsToLoad();
        }

        private void DesignerForm_Closing( object sender, CancelEventArgs e )
        {
            IEnumerator enumerator = null;
            try
            {
                foreach ( object availablePlugin in AvailablePlugins )
                {
                    BasePlugin objectValue = (BasePlugin) RuntimeHelpers.GetObjectValue( availablePlugin );
                    if ( objectValue.IsLoaded )
                        objectValue.Unload();
                }
            }
            finally
            {
                ( enumerator as IDisposable )?.Dispose();
            }
        }

        private void DesignerForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            XMLSettings.CurrentOptions.DesignerFormSize = WindowState != FormWindowState.Normal ? RestoreBounds.Size : Size;
            XMLSettings.Save( this, XMLSettings.CurrentOptions );
        }

        private void DesignerForm_KeyDown( object sender, KeyEventArgs e )
        {
            HookKeyDownEventHandler hookKeyDown = HookKeyDown;

            hookKeyDown?.Invoke( ActiveControl, ref e );

            if ( e.Handled || ActiveControl != CanvasFocus )
                return;

            bool flag = false;
            if ( ( e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back ? 1 : 0 ) != 0 )
            {
                DeleteSelectedElements();
                e.Handled = true;
                flag = true;
            }
            else if ( e.KeyCode == Keys.Up )
            {
                IEnumerator enumerator = null;
                try
                {
                    foreach ( object selectedElement in ElementStack.GetSelectedElements() )
                    {
                        BaseElement objectValue = (BaseElement) RuntimeHelpers.GetObjectValue( selectedElement );
                        Point location = objectValue.Location;
                        location.Offset( 0, -Convert.ToInt32( ArrowKeyDelta ) );
                        objectValue.Location = location;
                    }
                }
                finally
                {
                    ( enumerator as IDisposable )?.Dispose();
                }
                ArrowKeyDelta = Decimal.Multiply( ArrowKeyDelta, new Decimal( 106, 0, 0, false, 2 ) );
                flag = true;
            }
            else if ( e.KeyCode == Keys.Down )
            {
                IEnumerator enumerator = null;
                try
                {
                    foreach ( object selectedElement in ElementStack.GetSelectedElements() )
                    {
                        BaseElement objectValue = (BaseElement) RuntimeHelpers.GetObjectValue( selectedElement );
                        Point location = objectValue.Location;
                        location.Offset( 0, Convert.ToInt32( ArrowKeyDelta ) );
                        objectValue.Location = location;
                    }
                }
                finally
                {
                    ( enumerator as IDisposable )?.Dispose();
                }
                ArrowKeyDelta = Decimal.Multiply( ArrowKeyDelta, new Decimal( 106, 0, 0, false, 2 ) );
                flag = true;
            }
            else if ( e.KeyCode == Keys.Left )
            {
                IEnumerator enumerator = null;
                try
                {
                    foreach ( object selectedElement in ElementStack.GetSelectedElements() )
                    {
                        BaseElement objectValue = (BaseElement) RuntimeHelpers.GetObjectValue( selectedElement );
                        Point location = objectValue.Location;
                        location.Offset( -Convert.ToInt32( ArrowKeyDelta ), 0 );
                        objectValue.Location = location;
                    }
                }
                finally
                {
                    ( enumerator as IDisposable )?.Dispose();
                }
                ArrowKeyDelta = Decimal.Multiply( ArrowKeyDelta, new Decimal( 106, 0, 0, false, 2 ) );
                flag = true;
            }
            else if ( e.KeyCode == Keys.Right )
            {
                IEnumerator enumerator = null;
                try
                {
                    foreach ( object selectedElement in ElementStack.GetSelectedElements() )
                    {
                        BaseElement objectValue = (BaseElement) RuntimeHelpers.GetObjectValue( selectedElement );
                        Point location = objectValue.Location;
                        location.Offset( Convert.ToInt32( ArrowKeyDelta ), 0 );
                        objectValue.Location = location;
                    }
                }
                finally
                {
                    ( enumerator as IDisposable )?.Dispose();
                }
                ArrowKeyDelta = Decimal.Multiply( ArrowKeyDelta, new Decimal( 106, 0, 0, false, 2 ) );
                flag = true;
            }
            else if ( e.KeyCode == Keys.Next )
            {
                int index = ( ActiveElement == null ? ElementStack.GetElements().Count - 1 : ActiveElement.Z ) - 1;
                if ( index < 0 )
                    index = ElementStack.GetElements().Count - 1;
                if ( index >= 0 & index <= ElementStack.GetElements().Count - 1 )
                    SetActiveElement( (BaseElement) ElementStack.GetElements()[index], true );
            }
            else if ( e.KeyCode == Keys.Prior )
            {
                int index = ( ActiveElement == null ? ElementStack.GetElements().Count - 1 : ActiveElement.Z ) + 1;
                if ( index > ElementStack.GetElements().Count - 1 )
                    index = 0;
                SetActiveElement( (BaseElement) ElementStack.GetElements()[index], true );
            }
            if ( Decimal.Compare( ArrowKeyDelta, new Decimal( 10 ) ) > 0 )
                ArrowKeyDelta = new Decimal( 10 );
            if ( !flag )
                return;
            _picCanvas.Invalidate();
            m_ElementProperties.SelectedObjects = m_ElementProperties.SelectedObjects;
        }

        private void DesignerForm_KeyUp( object sender, KeyEventArgs e )
        {
            if ( e.KeyCode != Keys.Up && e.KeyCode != Keys.Down )
            {
                int keyCode = (int) e.KeyCode;
            }
            if ( ( e.KeyCode == Keys.Right ? 1 : 0 ) == 0 )
                return;
            CreateUndoPoint( "Move element" );
            ArrowKeyDelta = new Decimal( 1 );
        }

        private void DesignerForm_Load( object sender, EventArgs e )
        {
            XMLSettings.CurrentOptions = XMLSettings.Load( this );

            if ( !File.Exists( Path.Combine( XMLSettings.CurrentOptions.ClientPath, "art.mul" ) ) && !File.Exists( Path.Combine( XMLSettings.CurrentOptions.ClientPath, "artLegacyMUL.uop" ) ) )
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog { SelectedPath = Environment.SpecialFolder.ProgramFiles.ToString(), Description = @"Select the folder that contains the UO data (.mul) files you want to use." };

                if ( folderBrowserDialog.ShowDialog() == DialogResult.OK )
                {
                    if ( File.Exists( Path.Combine( folderBrowserDialog.SelectedPath, "art.mul" ) ) || File.Exists( Path.Combine( folderBrowserDialog.SelectedPath, "artLegacyMUL.uop" ) ) )
                    {
                        XMLSettings.CurrentOptions.ClientPath = folderBrowserDialog.SelectedPath;
                        XMLSettings.Save( this, XMLSettings.CurrentOptions );
                    }
                    else
                    {
                        MessageBox.Show( @"This path does not contain a file named ""art.mul"", it is most likely not the correct path. Gump Studio can not run without valid client data files.", "Data Files" );
                        Close();
                        return;
                    }
                }
                else
                {
                    Close();
                    return;
                }
            }
            //Client.Directories.Add( XMLSettings.CurrentOptions.ClientPath );
            Files.CacheData = false;
            Files.SetMulPath( XMLSettings.CurrentOptions.ClientPath );
            Size = XMLSettings.CurrentOptions.DesignerFormSize;
            MaxUndoPoints = XMLSettings.CurrentOptions.UndoLevels;
            _picCanvas.Width = 1600;
            _picCanvas.Height = 1200;
            CenterToScreen();
            frmSplash.DisplaySplash();
            EnumeratePlugins();
            Canvas = new Bitmap( _picCanvas.Width, _picCanvas.Height, PixelFormat.Format32bppRgb );
            Activate();
            GumpProperties = new GumpProperties();
            ElementStack.UpdateParent += new BaseElement.UpdateParentEventHandler( ChangeActiveElementEventHandler );
            ElementStack.Repaint += new BaseElement.RepaintEventHandler( RefreshView );
            Stacks.Clear();
            Stacks.Add( ElementStack );
            ChangeActiveStack( 0 );
            RegisteredTypes.Clear();
            RegisteredTypes.Add( typeof( LabelElement ) );
            RegisteredTypes.Add( typeof( ImageElement ) );
            RegisteredTypes.Add( typeof( TiledElement ) );
            RegisteredTypes.Add( typeof( BackgroundElement ) );
            RegisteredTypes.Add( typeof( AlphaElement ) );
            RegisteredTypes.Add( typeof( CheckboxElement ) );
            RegisteredTypes.Add( typeof( RadioElement ) );
            RegisteredTypes.Add( typeof( ItemElement ) );
            RegisteredTypes.Add( typeof( TextEntryElement ) );
            RegisteredTypes.Add( typeof( ButtonElement ) );
            RegisteredTypes.Add( typeof( HTMLElement ) );
            BuildToolbox();
            SelFG = new Pen( Color.Blue, 2f );
            SelBG = new LinearGradientBrush( new Rectangle( 0, 0, 50, 50 ), Color.FromArgb( 90, Color.Blue ), Color.FromArgb( 110, Color.Blue ), LinearGradientMode.ForwardDiagonal );
            SelBG.WrapMode = WrapMode.TileFlipXY;
            CreateUndoPoint( "Blank" );
            _mnuEditUndo.Enabled = false;
        }

        protected void DrawBoundingBox( Graphics Target, BaseElement Element )
        {
            Rectangle bounds = Element.Bounds;
            Target.DrawRectangle( Pens.Red, bounds );
            bounds.Offset( 1, 1 );
            Target.DrawRectangle( Pens.Black, bounds );
        }

        private void ElementProperties_PropertyValueChanged( object s, PropertyValueChangedEventArgs e )
        {
            if ( e.ChangedItem.PropertyDescriptor.Name == "Name" )
            {
                m_cboElements.Items.Clear();
                m_cboElements.Items.AddRange( ElementStack.GetElements().ToArray() );
                m_cboElements.SelectedItem = RuntimeHelpers.GetObjectValue( m_ElementProperties.SelectedObject );
            }
            _picCanvas.Invalidate();
            CreateUndoPoint( "Property Changed" );
        }

        protected void EnumeratePlugins()
        {
            if ( !Directory.Exists( Application.StartupPath + "\\Plugins" ) )
                Directory.CreateDirectory( Application.StartupPath + "\\Plugins" );
            PluginTypesToLoad = GetPluginsToLoad();
            foreach ( string file in Directory.GetFiles( Application.StartupPath + "\\Plugins", "*.dll" ) )
            {
                foreach ( Type type in Assembly.LoadFile( file ).GetTypes() )
                {
                    try
                    {
                        if ( type.IsSubclassOf( typeof( BasePlugin ) ) & !type.IsAbstract )
                        {
                            BasePlugin instance = (BasePlugin) Activator.CreateInstance( type );
                            PluginInfo pluginInfo = instance.GetPluginInfo();
                            AboutElementAppend = AboutElementAppend + "\r\n" + pluginInfo.PluginName + ": " + pluginInfo.Description + "\r\nAuthor: " + pluginInfo.AuthorName + "  (" + pluginInfo.AuthorEmail + ")\r\nVersion: " + pluginInfo.Version + "\r\n";
                            AvailablePlugins.Add( instance );
                        }
                        if ( type.IsSubclassOf( typeof( BaseElement ) ) )
                            RegisteredTypes.Add( type );
                    }
                    catch ( Exception ex )
                    {
                        Exception exception = ex;
                        MessageBox.Show( "Error loading plugin: " + type.Name + "(" + file + ")\r\n\r\n" + exception.Message );
                    }
                }
            }
            if ( PluginTypesToLoad == null )
                return;
            foreach ( PluginInfo pluginInfo1 in PluginTypesToLoad )
            {
                IEnumerator enumerator = null;
                try
                {
                    foreach ( object availablePlugin in AvailablePlugins )
                    {
                        BasePlugin objectValue = (BasePlugin) RuntimeHelpers.GetObjectValue( availablePlugin );
                        PluginInfo pluginInfo2 = objectValue.GetPluginInfo();
                        if ( pluginInfo1.Equals( pluginInfo2 ) )
                        {
                            objectValue.Load( this );
                            LoadedPlugins.Add( objectValue );
                        }
                    }
                }
                finally
                {
                    ( enumerator as IDisposable )?.Dispose();
                }
            }
        }

        protected void GetContextMenu( ref BaseElement Element, 
ContextMenuStrip Menu )
        {
            
            ToolStripMenuItem GroupMenu = new ToolStripMenuItem( "Grouping" );
            
            ToolStripMenuItem PositionMenu = new ToolStripMenuItem( "Positioning" );
            
            ToolStripMenuItem OrderMenu = new ToolStripMenuItem( "Order" );
            
            ToolStripMenuItem MiscMenu = new ToolStripMenuItem( "Misc" );
            
            ToolStripMenuItem menuItem = new ToolStripMenuItem( "Edit" );
            
            menuItem.DropDownItems.Add( new ToolStripMenuItem( "Cut", null, new EventHandler( mnuCut_Click ) ) );
            
            menuItem.DropDownItems.Add( new ToolStripMenuItem( "Copy", null, new EventHandler( mnuCopy_Click ) ) );
            
            menuItem.DropDownItems.Add( new ToolStripMenuItem( "Paste", null, new EventHandler( mnuPaste_Click ) ) );
            
            menuItem.DropDownItems.Add( new ToolStripMenuItem( "Delete", null, new EventHandler( mnuDelete_Click ) ) );
            Menu.Items.Add( menuItem );
            
            Menu.Items.Add( new ToolStripSeparator());
            Menu.Items.Add( GroupMenu );
            Menu.Items.Add( PositionMenu );
            Menu.Items.Add( OrderMenu );
            
            Menu.Items.Add( new ToolStripSeparator());
            Menu.Items.Add( MiscMenu );
            if ( ElementStack.GetSelectedElements().Count >= 2 )
                
                GroupMenu.DropDownItems.Add( new ToolStripMenuItem( "Create Group", null, new EventHandler( mnuGroupCreate_Click ) ) );

            Element?.AddContextMenus( ref GroupMenu, ref PositionMenu, ref OrderMenu, ref MiscMenu );
            if ( GroupMenu.DropDownItems.Count == 0 )
                GroupMenu.Enabled = false;
            if ( PositionMenu.DropDownItems.Count == 0 )
                PositionMenu.Enabled = false;
            if ( OrderMenu.DropDownItems.Count == 0 )
                OrderMenu.Enabled = false;
            if ( MiscMenu.DropDownItems.Count != 0 )
                return;
            MiscMenu.Enabled = false;
        }

        public BaseElement GetLastSelectedControl()
        {
            BaseElement baseElement = null;
            IEnumerator enumerator = null;
            try
            {
                foreach ( object element in ElementStack.GetElements() )
                    baseElement = (BaseElement) RuntimeHelpers.GetObjectValue( element );
            }
            finally
            {
                ( enumerator as IDisposable )?.Dispose();
            }
            return baseElement;
        }

        protected PluginInfo[] GetPluginsToLoad()
        {
            PluginInfo[] pluginInfoArray = null;
            if ( File.Exists( Application.StartupPath + "\\Plugins\\LoadInfo" ) )
            {
                FileStream fileStream = new FileStream( Application.StartupPath + "\\Plugins\\LoadInfo", FileMode.Open );
                pluginInfoArray = (PluginInfo[]) new BinaryFormatter().Deserialize( fileStream );
                fileStream.Close();
            }
            return pluginInfoArray;
        }

        protected Rectangle GetPositiveRect( Rectangle Rect )
        {
            if ( Rect.Height < 0 )
            {
                Rect.Height = Math.Abs( Rect.Height );
                Rect.Y -= Rect.Height;
            }
            if ( Rect.Width < 0 )
            {
                Rect.Width = Math.Abs( Rect.Width );
                Rect.X -= Rect.Width;
            }
            return Rect;
        }

        protected override void Dispose( bool disposing )
        {
            if ( disposing )
                components?.Dispose();
            base.Dispose( disposing );
        }


        private void InitializeComponent()
        {
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(DesignerForm));
            _pnlToolboxHolder = new Panel();
            _Panel4 = new Panel();
            _tabToolbox = new TabControl();
            _tpgStandard = new TabPage();
            _pnlToolbox = new Panel();
            _tpgCustom = new TabPage();
            _treGumplings = new TreeView();
            m_Label1 = new Label();
            _StatusBar = new StatusStrip();
            _Splitter1 = new Splitter();
            _Panel1 = new Panel();
            _Panel2 = new Panel();
            _pnlCanvasScroller = new Panel();
            _picCanvas = new PictureBox();
            _TabPager = new TabControl();
            _TabPage1 = new TabPage();
            _Splitter2 = new Splitter();
            _Panel3 = new Panel();
            m_cboElements = new ComboBox();
            m_ElementProperties = new PropertyGrid();
            m_CanvasFocus = new TextBox();
            _OpenDialog = new OpenFileDialog();
            _SaveDialog = new SaveFileDialog();
            m_mnuContextMenu = new ContextMenuStrip(components);
            m_MainMenu = new MenuStrip();
            _mnuFile = new ToolStripMenuItem();
            _mnuFileNew = new ToolStripMenuItem();
            m_MenuItem9 = new ToolStripSeparator();
            _mnuFileOpen = new ToolStripMenuItem();
            _mnuFileSave = new ToolStripMenuItem();
            _mnuFileImport = new ToolStripMenuItem();
            _mnuFileExport = new ToolStripMenuItem();
            m_MenuItem5 = new ToolStripSeparator();
            _mnuFileExit = new ToolStripMenuItem();
            _mnuEdit = new ToolStripMenuItem();
            _mnuEditUndo = new ToolStripMenuItem();
            _mnuEditRedo = new ToolStripMenuItem();
            m_MenuItem3 = new ToolStripSeparator();
            _mnuCut = new ToolStripMenuItem();
            m_mnuCopy = new ToolStripMenuItem();
            _mnuPaste = new ToolStripMenuItem();
            _mnuDelete = new ToolStripMenuItem();
            m_MenuItem4 = new ToolStripSeparator();
            _mnuSelectAll = new ToolStripMenuItem();
            _mnuMisc = new ToolStripMenuItem();
            _mnuMiscLoadGumpling = new ToolStripMenuItem();
            _mnuImportGumpling = new ToolStripMenuItem();
            _mnuDataFile = new ToolStripMenuItem();
            _mnuPage = new ToolStripMenuItem();
            _mnuPageAdd = new ToolStripMenuItem();
            _mnuPageInsert = new ToolStripMenuItem();
            _mnuPageDelete = new ToolStripMenuItem();
            _mnuPageClear = new ToolStripMenuItem();
            m_MenuItem10 = new ToolStripSeparator();
            _mnuShow0 = new ToolStripMenuItem();
            _mnuPlugins = new ToolStripMenuItem();
            _mnuPluginManager = new ToolStripMenuItem();
            _mnuHelp = new ToolStripMenuItem();
            _mnuHelpAbout = new ToolStripMenuItem();
            _mnuGumplingContext = new ContextMenuStrip(components);
            _mnuGumplingRename = new ToolStripMenuItem();
            _mnuGumplingMove = new ToolStripMenuItem();
            _mnuGumplingDelete = new ToolStripMenuItem();
            m_MenuItem1 = new ToolStripSeparator();
            _mnuGumplingAddGumpling = new ToolStripMenuItem();
            _mnuGumplingAddFolder = new ToolStripMenuItem();
            toolStripContainer1 = new ToolStripContainer();
            _pnlToolboxHolder.SuspendLayout();
            _Panel4.SuspendLayout();
            _tabToolbox.SuspendLayout();
            _tpgStandard.SuspendLayout();
            _tpgCustom.SuspendLayout();
            _Panel1.SuspendLayout();
            _Panel2.SuspendLayout();
            _pnlCanvasScroller.SuspendLayout();
            ((ISupportInitialize)_picCanvas).BeginInit();
            _TabPager.SuspendLayout();
            _Panel3.SuspendLayout();
            m_MainMenu.SuspendLayout();
            _mnuGumplingContext.SuspendLayout();
            toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            toolStripContainer1.ContentPanel.SuspendLayout();
            toolStripContainer1.TopToolStripPanel.SuspendLayout();
            toolStripContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // _pnlToolboxHolder
            // 
            _pnlToolboxHolder.BorderStyle = BorderStyle.Fixed3D;
            _pnlToolboxHolder.Controls.Add(_Panel4);
            _pnlToolboxHolder.Controls.Add(m_Label1);
            _pnlToolboxHolder.Dock = DockStyle.Left;
            _pnlToolboxHolder.Location = new Point(0, 0);
            _pnlToolboxHolder.Name = "_pnlToolboxHolder";
            _pnlToolboxHolder.Size = new Size(179, 658);
            _pnlToolboxHolder.TabIndex = 0;
            // 
            // _Panel4
            // 
            _Panel4.Controls.Add(_tabToolbox);
            _Panel4.Dock = DockStyle.Fill;
            _Panel4.Location = new Point(0, 25);
            _Panel4.Name = "_Panel4";
            _Panel4.Size = new Size(175, 629);
            _Panel4.TabIndex = 1;
            // 
            // _tabToolbox
            // 
            _tabToolbox.Controls.Add(_tpgStandard);
            _tabToolbox.Controls.Add(_tpgCustom);
            _tabToolbox.Dock = DockStyle.Fill;
            _tabToolbox.Location = new Point(0, 0);
            _tabToolbox.Multiline = true;
            _tabToolbox.Name = "_tabToolbox";
            _tabToolbox.SelectedIndex = 0;
            _tabToolbox.Size = new Size(175, 629);
            _tabToolbox.TabIndex = 1;
            // 
            // _tpgStandard
            // 
            _tpgStandard.Controls.Add(_pnlToolbox);
            _tpgStandard.Location = new Point(4, 29);
            _tpgStandard.Name = "_tpgStandard";
            _tpgStandard.Size = new Size(167, 596);
            _tpgStandard.TabIndex = 0;
            _tpgStandard.Text = "Standard";
            // 
            // _pnlToolbox
            // 
            _pnlToolbox.AutoScroll = true;
            _pnlToolbox.Dock = DockStyle.Fill;
            _pnlToolbox.Location = new Point(0, 0);
            _pnlToolbox.Name = "_pnlToolbox";
            _pnlToolbox.Size = new Size(167, 596);
            _pnlToolbox.TabIndex = 1;
            // 
            // _tpgCustom
            // 
            _tpgCustom.Controls.Add(_treGumplings);
            _tpgCustom.Location = new Point(4, 29);
            _tpgCustom.Name = "_tpgCustom";
            _tpgCustom.Size = new Size(167, 596);
            _tpgCustom.TabIndex = 1;
            _tpgCustom.Text = "Gumplings";
            // 
            // _treGumplings
            // 
            _treGumplings.Dock = DockStyle.Fill;
            _treGumplings.Location = new Point(0, 0);
            _treGumplings.Name = "_treGumplings";
            _treGumplings.Size = new Size(167, 596);
            _treGumplings.TabIndex = 1;
            _treGumplings.DoubleClick += treGumplings_DoubleClick;
            _treGumplings.MouseUp += treGumplings_MouseUp;
            // 
            // m_Label1
            // 
            m_Label1.BackColor = SystemColors.ControlDark;
            m_Label1.BorderStyle = BorderStyle.Fixed3D;
            m_Label1.Dock = DockStyle.Top;
            m_Label1.Location = new Point(0, 0);
            m_Label1.Name = "m_Label1";
            m_Label1.Size = new Size(175, 25);
            m_Label1.TabIndex = 0;
            m_Label1.Text = "Toolbox";
            m_Label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _StatusBar
            // 
            _StatusBar.Dock = DockStyle.None;
            _StatusBar.ImageScalingSize = new Size(20, 20);
            _StatusBar.Location = new Point(0, 0);
            _StatusBar.Name = "_StatusBar";
            _StatusBar.Size = new Size(1350, 22);
            _StatusBar.TabIndex = 0;
            // 
            // _Splitter1
            // 
            _Splitter1.BorderStyle = BorderStyle.Fixed3D;
            _Splitter1.Location = new Point(179, 0);
            _Splitter1.MinSize = 80;
            _Splitter1.Name = "_Splitter1";
            _Splitter1.Size = new Size(4, 658);
            _Splitter1.TabIndex = 1;
            _Splitter1.TabStop = false;
            // 
            // _Panel1
            // 
            _Panel1.Controls.Add(_Panel2);
            _Panel1.Dock = DockStyle.Fill;
            _Panel1.Location = new Point(183, 0);
            _Panel1.Name = "_Panel1";
            _Panel1.Size = new Size(1167, 658);
            _Panel1.TabIndex = 2;
            // 
            // _Panel2
            // 
            _Panel2.Controls.Add(_pnlCanvasScroller);
            _Panel2.Controls.Add(_TabPager);
            _Panel2.Controls.Add(_Splitter2);
            _Panel2.Controls.Add(_Panel3);
            _Panel2.Dock = DockStyle.Fill;
            _Panel2.Location = new Point(0, 0);
            _Panel2.Name = "_Panel2";
            _Panel2.Size = new Size(1167, 658);
            _Panel2.TabIndex = 0;
            // 
            // _pnlCanvasScroller
            // 
            _pnlCanvasScroller.AutoScroll = true;
            _pnlCanvasScroller.AutoScrollMargin = new Size(1, 1);
            _pnlCanvasScroller.AutoScrollMinSize = new Size(1, 1);
            _pnlCanvasScroller.BackColor = Color.Silver;
            _pnlCanvasScroller.BorderStyle = BorderStyle.Fixed3D;
            _pnlCanvasScroller.Controls.Add(_picCanvas);
            _pnlCanvasScroller.Dock = DockStyle.Fill;
            _pnlCanvasScroller.Location = new Point(0, 37);
            _pnlCanvasScroller.Name = "_pnlCanvasScroller";
            _pnlCanvasScroller.Size = new Size(789, 621);
            _pnlCanvasScroller.TabIndex = 2;
            _pnlCanvasScroller.MouseLeave += pnlCanvasScroller_MouseLeave;
            // 
            // _picCanvas
            // 
            _picCanvas.BackColor = Color.Black;
            _picCanvas.Location = new Point(0, 0);
            _picCanvas.Name = "_picCanvas";
            _picCanvas.Size = new Size(2240, 1846);
            _picCanvas.TabIndex = 0;
            _picCanvas.TabStop = false;
            _picCanvas.Paint += picCanvas_Paint;
            _picCanvas.MouseDown += picCanvas_MouseDown;
            _picCanvas.MouseMove += picCanvas_MouseMove;
            _picCanvas.MouseUp += picCanvas_MouseUp;
            // 
            // _TabPager
            // 
            _TabPager.Controls.Add(_TabPage1);
            _TabPager.Dock = DockStyle.Top;
            _TabPager.HotTrack = true;
            _TabPager.Location = new Point(0, 0);
            _TabPager.Name = "_TabPager";
            _TabPager.SelectedIndex = 0;
            _TabPager.Size = new Size(789, 37);
            _TabPager.TabIndex = 3;
            _TabPager.SelectedIndexChanged += TabPager_SelectedIndexChanged;
            // 
            // _TabPage1
            // 
            _TabPage1.Location = new Point(4, 29);
            _TabPage1.Name = "_TabPage1";
            _TabPage1.Size = new Size(781, 4);
            _TabPage1.TabIndex = 0;
            _TabPage1.Text = "0";
            // 
            // _Splitter2
            // 
            _Splitter2.Dock = DockStyle.Right;
            _Splitter2.Location = new Point(789, 0);
            _Splitter2.Name = "_Splitter2";
            _Splitter2.Size = new Size(30, 658);
            _Splitter2.TabIndex = 1;
            _Splitter2.TabStop = false;
            // 
            // _Panel3
            // 
            _Panel3.Controls.Add(m_cboElements);
            _Panel3.Controls.Add(m_ElementProperties);
            _Panel3.Controls.Add(m_CanvasFocus);
            _Panel3.Dock = DockStyle.Right;
            _Panel3.Location = new Point(819, 0);
            _Panel3.Name = "_Panel3";
            _Panel3.Size = new Size(348, 658);
            _Panel3.TabIndex = 0;
            // 
            // m_cboElements
            // 
            m_cboElements.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            m_cboElements.DropDownStyle = ComboBoxStyle.DropDownList;
            m_cboElements.Location = new Point(0, 12);
            m_cboElements.Name = "m_cboElements";
            m_cboElements.Size = new Size(336, 28);
            m_cboElements.TabIndex = 1;
            m_cboElements.SelectedIndexChanged += cboElements_SelectedIndexChanged;
            m_cboElements.Click += cboElements_Click;
            // 
            // m_ElementProperties
            // 
            m_ElementProperties.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            m_ElementProperties.Cursor = Cursors.HSplit;
            m_ElementProperties.LineColor = SystemColors.ScrollBar;
            m_ElementProperties.Location = new Point(0, 49);
            m_ElementProperties.Name = "m_ElementProperties";
            m_ElementProperties.Size = new Size(336, 606);
            m_ElementProperties.TabIndex = 0;
            m_ElementProperties.PropertyValueChanged += ElementProperties_PropertyValueChanged;
            // 
            // m_CanvasFocus
            // 
            m_CanvasFocus.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            m_CanvasFocus.Location = new Point(22, 581);
            m_CanvasFocus.Name = "m_CanvasFocus";
            m_CanvasFocus.Size = new Size(140, 27);
            m_CanvasFocus.TabIndex = 1;
            m_CanvasFocus.Text = "TextBox1";
            // 
            // m_mnuContextMenu
            // 
            m_mnuContextMenu.ImageScalingSize = new Size(20, 20);
            m_mnuContextMenu.Name = "m_mnuContextMenu";
            m_mnuContextMenu.Size = new Size(61, 4);
            // 
            // m_MainMenu
            // 
            m_MainMenu.Dock = DockStyle.None;
            m_MainMenu.ImageScalingSize = new Size(20, 20);
            m_MainMenu.Items.AddRange(new ToolStripItem[] { _mnuFile, _mnuEdit, _mnuMisc, _mnuPage, _mnuPlugins, _mnuHelp });
            m_MainMenu.Location = new Point(0, 0);
            m_MainMenu.Name = "m_MainMenu";
            m_MainMenu.Size = new Size(1350, 28);
            m_MainMenu.TabIndex = 0;
            // 
            // _mnuFile
            // 
            _mnuFile.DropDownItems.AddRange(new ToolStripItem[] { _mnuFileNew, m_MenuItem9, _mnuFileOpen, _mnuFileSave, _mnuFileImport, _mnuFileExport, m_MenuItem5, _mnuFileExit });
            _mnuFile.Name = "_mnuFile";
            _mnuFile.Size = new Size(46, 24);
            _mnuFile.Text = "File";
            // 
            // _mnuFileNew
            // 
            _mnuFileNew.Name = "_mnuFileNew";
            _mnuFileNew.Size = new Size(137, 26);
            _mnuFileNew.Text = "New";
            _mnuFileNew.Click += mnuFileNew_Click;
            // 
            // m_MenuItem9
            // 
            m_MenuItem9.Name = "m_MenuItem9";
            m_MenuItem9.Size = new Size(137, 26);
            m_MenuItem9.Text = "-";
            // 
            // _mnuFileOpen
            // 
            _mnuFileOpen.Name = "_mnuFileOpen";
            _mnuFileOpen.Size = new Size(137, 26);
            _mnuFileOpen.Text = "Open";
            _mnuFileOpen.Click += mnuFileOpen_Click;
            // 
            // _mnuFileSave
            // 
            _mnuFileSave.Name = "_mnuFileSave";
            _mnuFileSave.Size = new Size(137, 26);
            _mnuFileSave.Text = "Save";
            _mnuFileSave.Click += mnuFileSave_Click;
            // 
            // _mnuFileImport
            // 
            _mnuFileImport.Enabled = false;
            _mnuFileImport.Name = "_mnuFileImport";
            _mnuFileImport.Size = new Size(137, 26);
            _mnuFileImport.Text = "Import";
            // 
            // _mnuFileExport
            // 
            _mnuFileExport.Enabled = false;
            _mnuFileExport.Name = "_mnuFileExport";
            _mnuFileExport.Size = new Size(137, 26);
            _mnuFileExport.Text = "Export";
            // 
            // m_MenuItem5
            // 
            m_MenuItem5.Name = "m_MenuItem5";
            m_MenuItem5.Size = new Size(137, 26);
            m_MenuItem5.Text = "-";
            // 
            // _mnuFileExit
            // 
            _mnuFileExit.Name = "_mnuFileExit";
            _mnuFileExit.Size = new Size(137, 26);
            _mnuFileExit.Text = "Exit";
            _mnuFileExit.Click += mnuFileExit_Click;
            // 
            // _mnuEdit
            // 
            _mnuEdit.DropDownItems.AddRange(new ToolStripItem[] { _mnuEditUndo, _mnuEditRedo, m_MenuItem3, _mnuCut, m_mnuCopy, _mnuPaste, _mnuDelete, m_MenuItem4, _mnuSelectAll });
            _mnuEdit.Name = "_mnuEdit";
            _mnuEdit.Size = new Size(49, 24);
            _mnuEdit.Text = "Edit";
            // 
            // _mnuEditUndo
            // 
            _mnuEditUndo.Enabled = false;
            _mnuEditUndo.Name = "_mnuEditUndo";
            _mnuEditUndo.Size = new Size(154, 26);
            _mnuEditUndo.Text = "Undo";
            _mnuEditUndo.ShortcutKeys = Keys.Control | Keys.Z;
            _mnuEditUndo.Click += mnuEditUndo_Click;
            // 
            // _mnuEditRedo
            // 
            _mnuEditRedo.Enabled = false;
            _mnuEditRedo.Name = "_mnuEditRedo";
            _mnuEditRedo.Size = new Size(154, 26);
            _mnuEditRedo.Text = "Redo";
            _mnuEditRedo.Click += mnuEditRedo_Click;
            _mnuEditRedo.ShortcutKeys = Keys.Control | Keys.Y;
            // 
            // m_MenuItem3
            // 
            m_MenuItem3.Name = "m_MenuItem3";
            m_MenuItem3.Size = new Size(154, 26);
            m_MenuItem3.Text = "-";
            // 
            // _mnuCut
            // 
            _mnuCut.Name = "_mnuCut";
            _mnuCut.Size = new Size(154, 26);
            _mnuCut.Text = "Cu&t";
            _mnuCut.Click += mnuCut_Click;
            _mnuCut.ShortcutKeys = Keys.Control | Keys.X;
            // 
            // m_mnuCopy
            // 
            m_mnuCopy.Name = "m_mnuCopy";
            m_mnuCopy.Size = new Size(154, 26);
            m_mnuCopy.Text = "&Copy";
            m_mnuCopy.Click += mnuCopy_Click;
            m_mnuCopy.ShortcutKeys = Keys.Control | Keys.C;
            // 
            // _mnuPaste
            // 
            _mnuPaste.Name = "_mnuPaste";
            _mnuPaste.Size = new Size(154, 26);
            _mnuPaste.Text = "&Paste";
            _mnuPaste.Click += mnuPaste_Click;
            _mnuPaste.ShortcutKeys = Keys.Control | Keys.V;
            // 
            // _mnuDelete
            // 
            _mnuDelete.Name = "_mnuDelete";
            _mnuDelete.Size = new Size(154, 26);
            _mnuDelete.Text = "Delete";
            _mnuDelete.Click += mnuDelete_Click;
            // 
            // m_MenuItem4
            // 
            m_MenuItem4.Name = "m_MenuItem4";
            m_MenuItem4.Size = new Size(154, 26);
            m_MenuItem4.Text = "-";
            // 
            // _mnuSelectAll
            // 
            _mnuSelectAll.Name = "_mnuSelectAll";
            _mnuSelectAll.Size = new Size(154, 26);
            _mnuSelectAll.Text = "Select &All";
            _mnuSelectAll.Click += mnuSelectAll_Click;
            _mnuSelectAll.ShortcutKeys = Keys.Control | Keys.A;
            // 
            // _mnuMisc
            // 
            _mnuMisc.DropDownItems.AddRange(new ToolStripItem[] { _mnuMiscLoadGumpling, _mnuImportGumpling, _mnuDataFile });
            _mnuMisc.Name = "_mnuMisc";
            _mnuMisc.Size = new Size(53, 24);
            _mnuMisc.Text = "Misc";
            // 
            // _mnuMiscLoadGumpling
            // 
            _mnuMiscLoadGumpling.Name = "_mnuMiscLoadGumpling";
            _mnuMiscLoadGumpling.Size = new Size(206, 26);
            _mnuMiscLoadGumpling.Text = "Load gumpling";
            _mnuMiscLoadGumpling.Click += MenuItem2_Click;
            // 
            // _mnuImportGumpling
            // 
            _mnuImportGumpling.Name = "_mnuImportGumpling";
            _mnuImportGumpling.Size = new Size(206, 26);
            _mnuImportGumpling.Text = "Import Gumpling";
            _mnuImportGumpling.Click += mnuImportGumpling_Click;
            // 
            // _mnuDataFile
            // 
            _mnuDataFile.Name = "_mnuDataFile";
            _mnuDataFile.Size = new Size(206, 26);
            _mnuDataFile.Text = "Data File Path";
            _mnuDataFile.Click += mnuDataFile_Click;
            // 
            // _mnuPage
            // 
            _mnuPage.DropDownItems.AddRange(new ToolStripItem[] { _mnuPageAdd, _mnuPageInsert, _mnuPageDelete, _mnuPageClear, m_MenuItem10, _mnuShow0 });
            _mnuPage.Name = "_mnuPage";
            _mnuPage.Size = new Size(55, 24);
            _mnuPage.Text = "Page";
            // 
            // _mnuPageAdd
            // 
            _mnuPageAdd.Name = "_mnuPageAdd";
            _mnuPageAdd.Size = new Size(226, 26);
            _mnuPageAdd.Text = "Add Page";
            _mnuPageAdd.Click += mnuAddPage_Click;
            // 
            // _mnuPageInsert
            // 
            _mnuPageInsert.Name = "_mnuPageInsert";
            _mnuPageInsert.Size = new Size(226, 26);
            _mnuPageInsert.Text = "Insert Page";
            _mnuPageInsert.Click += mnuPageInsert_Click;
            // 
            // _mnuPageDelete
            // 
            _mnuPageDelete.Name = "_mnuPageDelete";
            _mnuPageDelete.Size = new Size(226, 26);
            _mnuPageDelete.Text = "Delete Page";
            _mnuPageDelete.Click += mnuPageDelete_Click;
            // 
            // _mnuPageClear
            // 
            _mnuPageClear.Name = "_mnuPageClear";
            _mnuPageClear.Size = new Size(226, 26);
            _mnuPageClear.Text = "Clear Page";
            _mnuPageClear.Click += mnuPageClear_Click;
            // 
            // m_MenuItem10
            // 
            m_MenuItem10.Name = "m_MenuItem10";
            m_MenuItem10.Size = new Size(226, 26);
            m_MenuItem10.Text = "-";
            // 
            // _mnuShow0
            // 
            _mnuShow0.Checked = true;
            _mnuShow0.CheckState = CheckState.Checked;
            _mnuShow0.Name = "_mnuShow0";
            _mnuShow0.Size = new Size(226, 26);
            _mnuShow0.Text = "Always Show Page 0";
            _mnuShow0.Click += mnuShow0_Click;
            // 
            // _mnuPlugins
            // 
            _mnuPlugins.DropDownItems.AddRange(new ToolStripItem[] { _mnuPluginManager });
            _mnuPlugins.Name = "_mnuPlugins";
            _mnuPlugins.Size = new Size(76, 24);
            _mnuPlugins.Text = "Plug-Ins";
            // 
            // _mnuPluginManager
            // 
            _mnuPluginManager.Name = "_mnuPluginManager";
            _mnuPluginManager.Size = new Size(151, 26);
            _mnuPluginManager.Text = "Manager";
            _mnuPluginManager.Click += mnuPluginManager_Click;
            // 
            // _mnuHelp
            // 
            _mnuHelp.DropDownItems.AddRange(new ToolStripItem[] { _mnuHelpAbout });
            _mnuHelp.Name = "_mnuHelp";
            _mnuHelp.Size = new Size(55, 24);
            _mnuHelp.Text = "Help";
            // 
            // _mnuHelpAbout
            // 
            _mnuHelpAbout.Name = "_mnuHelpAbout";
            _mnuHelpAbout.Size = new Size(142, 26);
            _mnuHelpAbout.Text = "About...";
            _mnuHelpAbout.Click += mnuHelpAbout_Click;
            // 
            // _mnuGumplingContext
            // 
            _mnuGumplingContext.ImageScalingSize = new Size(20, 20);
            _mnuGumplingContext.Items.AddRange(new ToolStripItem[] { _mnuGumplingRename, _mnuGumplingMove, _mnuGumplingDelete, m_MenuItem1, _mnuGumplingAddGumpling, _mnuGumplingAddFolder });
            _mnuGumplingContext.Name = "_mnuGumplingContext";
            _mnuGumplingContext.Size = new Size(176, 148);
            // 
            // _mnuGumplingRename
            // 
            _mnuGumplingRename.Name = "_mnuGumplingRename";
            _mnuGumplingRename.Size = new Size(175, 24);
            _mnuGumplingRename.Text = "Rename";
            // 
            // _mnuGumplingMove
            // 
            _mnuGumplingMove.Name = "_mnuGumplingMove";
            _mnuGumplingMove.Size = new Size(175, 24);
            _mnuGumplingMove.Text = "Move";
            // 
            // _mnuGumplingDelete
            // 
            _mnuGumplingDelete.Name = "_mnuGumplingDelete";
            _mnuGumplingDelete.Size = new Size(175, 24);
            _mnuGumplingDelete.Text = "Delete";
            // 
            // m_MenuItem1
            // 
            m_MenuItem1.Name = "m_MenuItem1";
            m_MenuItem1.Size = new Size(175, 24);
            m_MenuItem1.Text = "-";
            // 
            // _mnuGumplingAddGumpling
            // 
            _mnuGumplingAddGumpling.Name = "_mnuGumplingAddGumpling";
            _mnuGumplingAddGumpling.Size = new Size(175, 24);
            _mnuGumplingAddGumpling.Text = "Add Gumpling";
            // 
            // _mnuGumplingAddFolder
            // 
            _mnuGumplingAddFolder.Name = "_mnuGumplingAddFolder";
            _mnuGumplingAddFolder.Size = new Size(175, 24);
            _mnuGumplingAddFolder.Text = "Add Folder";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            toolStripContainer1.BottomToolStripPanel.Controls.Add(_StatusBar);
            // 
            // toolStripContainer1.ContentPanel
            // 
            toolStripContainer1.ContentPanel.AutoScroll = true;
            toolStripContainer1.ContentPanel.Controls.Add(_Panel1);
            toolStripContainer1.ContentPanel.Controls.Add(_Splitter1);
            toolStripContainer1.ContentPanel.Controls.Add(_pnlToolboxHolder);
            toolStripContainer1.ContentPanel.Size = new Size(1350, 658);
            toolStripContainer1.Dock = DockStyle.Fill;
            toolStripContainer1.Location = new Point(0, 0);
            toolStripContainer1.Name = "toolStripContainer1";
            toolStripContainer1.Size = new Size(1350, 708);
            toolStripContainer1.TabIndex = 3;
            toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            toolStripContainer1.TopToolStripPanel.Controls.Add(m_MainMenu);
            // 
            // DesignerForm
            // 
            AutoScaleBaseSize = new Size(7, 20);
            ClientSize = new Size(1350, 708);
            Controls.Add(toolStripContainer1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MainMenuStrip = m_MainMenu;
            Name = "DesignerForm";
            Text = "Gump Studio (-Unsaved Gump-)";
            FormClosing += DesignerForm_FormClosing;
            Load += DesignerForm_Load;
            KeyDown += DesignerForm_KeyDown;
            KeyUp += DesignerForm_KeyUp;
            _pnlToolboxHolder.ResumeLayout(false);
            _Panel4.ResumeLayout(false);
            _tabToolbox.ResumeLayout(false);
            _tpgStandard.ResumeLayout(false);
            _tpgCustom.ResumeLayout(false);
            _Panel1.ResumeLayout(false);
            _Panel2.ResumeLayout(false);
            _pnlCanvasScroller.ResumeLayout(false);
            ((ISupportInitialize)_picCanvas).EndInit();
            _TabPager.ResumeLayout(false);
            _Panel3.ResumeLayout(false);
            _Panel3.PerformLayout();
            m_MainMenu.ResumeLayout(false);
            m_MainMenu.PerformLayout();
            _mnuGumplingContext.ResumeLayout(false);
            toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            toolStripContainer1.BottomToolStripPanel.PerformLayout();
            toolStripContainer1.ContentPanel.ResumeLayout(false);
            toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            toolStripContainer1.TopToolStripPanel.PerformLayout();
            toolStripContainer1.ResumeLayout(false);
            toolStripContainer1.PerformLayout();
            ResumeLayout(false);
        }

        public void LoadFrom( string Path )
        {
            IEnumerator enumerator = null;
            _StatusBar.Text = "Loading gump...";
            FileStream fileStream = null;
            Stacks.Clear();
            _TabPager.TabPages.Clear();
            try
            {
                fileStream = new FileStream( Path, FileMode.Open );
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                Stacks = (ArrayList) binaryFormatter.Deserialize( fileStream );
                try
                {
                    GumpProperties = (GumpProperties) binaryFormatter.Deserialize( fileStream );
                }
                catch ( Exception ex )
                {
                    Exception exception = ex;
                    GumpProperties = new GumpProperties();
                    MessageBox.Show( exception.InnerException.Message );
                }
                SetActiveElement( null, true );
                RefreshElementList();
            }
            catch ( Exception ex )
            {
                MessageBox.Show( ex.Message );
            }
            finally
            {
                fileStream?.Close();
            }
            int num1 = 0;
            try
            {
                foreach ( object stack in Stacks )
                {
                    RuntimeHelpers.GetObjectValue( stack );
                    _TabPager.TabPages.Add( new TabPage( num1.ToString() ) );
                    ++num1;
                }
            }
            finally
            {
                ( enumerator as IDisposable )?.Dispose();
            }
            ChangeActiveStack( 0 );
            ElementStack.UpdateParent += new BaseElement.UpdateParentEventHandler( ChangeActiveElementEventHandler );
            ElementStack.Repaint += new BaseElement.RepaintEventHandler( RefreshView );
            _StatusBar.Text = "";
        }

        private void MenuItem2_Click( object sender, EventArgs e )
        {
            _OpenDialog.Filter = "Gumpling (*.gumpling)|*.gumpling|Gump (*.gump)|*.gump";
            if ( _OpenDialog.ShowDialog() != DialogResult.OK )
                return;
            FileStream fileStream = new FileStream( _OpenDialog.FileName, FileMode.Open );
            GroupElement groupElement = (GroupElement) new BinaryFormatter().Deserialize( fileStream );
            groupElement.mIsBaseWindow = false;
            groupElement.RecalculateBounds();
            Point point = new Point( 0, 0 );
            groupElement.Location = point;
            fileStream.Close();
            AddElement( groupElement );
        }

        private void mnuAddPage_Click( object sender, EventArgs e )
        {
            AddPage();
            CreateUndoPoint( "Add page" );
        }

        private void mnuCopy_Click( object sender, EventArgs e )
        {
            Copy();
        }

        private void mnuCut_Click( object sender, EventArgs e )
        {
            Cut();
            CreateUndoPoint();
        }

        private void mnuDataFile_Click( object sender, EventArgs e )
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Select the folder that contains the UO data (.mul) files you want to use.";
            if ( folderBrowserDialog.ShowDialog() != DialogResult.OK )
                return;
            if ( File.Exists( Path.Combine( folderBrowserDialog.SelectedPath, "art.mul" ) ) )
            {
                XMLSettings.CurrentOptions.ClientPath = folderBrowserDialog.SelectedPath;
                XMLSettings.Save( this, XMLSettings.CurrentOptions );
                //int num = (int) Interaction.MsgBox( (object) "New path set, please restart Gump Studio to activate your changes.", MsgBoxStyle.OkOnly, (object) "Data Files" );
                MessageBox.Show( "New path set, please restart Gump Studio to activate your changes.", "Data Files" );
            }
            else
            {
                //int num1 = (int) Interaction.MsgBox( (object) "This path does not contain a file named \"art.mul\", it is most likely not the correct path.", MsgBoxStyle.OkOnly, (object) "Data Files" );
                MessageBox.Show( "This path does not contain a file named \"art.mul\", it is most likely not the correct path.", "Data Files" );
            }
        }

        private void mnuDelete_Click( object sender, EventArgs e )
        {
            DeleteSelectedElements();
        }

        private void mnuEditRedo_Click( object sender, EventArgs e )
        {
            Redo();
        }

        private void mnuEditUndo_Click( object sender, EventArgs e )
        {
            Undo();
        }

        private void mnuFileExit_Click( object sender, EventArgs e )
        {
            Close();
        }

        private void mnuFileNew_Click( object sender, EventArgs e )
        {
            //if ( Interaction.MsgBox( (object) "Are you sure you want to start a new gump?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, (object) null ) != MsgBoxResult.Yes )
            //    return;

            var result = MessageBox.Show( "Are you sure you want to start a new gump?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question );

            if ( result != DialogResult.OK )
                return;

            ClearGump();
        }

        private void mnuFileOpen_Click( object sender, EventArgs e )
        {
            _OpenDialog.CheckFileExists = true;
            _OpenDialog.Filter = @"Gump|*.gump";
            if ( _OpenDialog.ShowDialog() == DialogResult.OK )
            {
                LoadFrom( _OpenDialog.FileName );
                FileName = Path.GetFileName( _OpenDialog.FileName );
                Text = "Gump Studio (" + FileName + ")";
            }
            _picCanvas.Invalidate();
        }

        private void mnuFileSave_Click( object sender, EventArgs e )
        {
            _SaveDialog.AddExtension = true;
            _SaveDialog.DefaultExt = "gump";
            _SaveDialog.Filter = "Gump|*.gump";
            if ( _SaveDialog.ShowDialog() != DialogResult.OK )
                return;
            SaveTo( _SaveDialog.FileName );
            FileName = Path.GetFileName( _SaveDialog.FileName );
            Text = "Gump Studio (" + FileName + ")";
        }

        private void mnuGroupCreate_Click( object sender, EventArgs e )
        {
            IEnumerator enumerator1 = null;
            ArrayList arrayList = new ArrayList();
            try
            {
                foreach ( object element in ElementStack.GetElements() )
                {
                    BaseElement objectValue = (BaseElement) RuntimeHelpers.GetObjectValue( element );
                    if ( objectValue.Selected )
                        arrayList.Add( objectValue );
                }
            }
            finally
            {
                ( enumerator1 as IDisposable )?.Dispose();
            }
            if ( arrayList.Count >= 2 )
            {
                IEnumerator enumerator2 = null;
                GroupElement groupElement = new GroupElement( ElementStack, null, "New Group" );
                try
                {
                    foreach ( object obj in arrayList )
                    {
                        BaseElement objectValue = (BaseElement) RuntimeHelpers.GetObjectValue( obj );
                        groupElement.AddElement( objectValue );
                        ElementStack.RemoveElement( objectValue );
                        ElementStack.RemoveEvents( objectValue );
                    }
                }
                finally
                {
                    ( enumerator2 as IDisposable )?.Dispose();
                }
                AddElement( groupElement );
                _picCanvas.Invalidate();
            }
            CreateUndoPoint();
        }

        private void mnuHelpAbout_Click( object sender, EventArgs e )
        {
            frmAboutBox frmAboutBox = new frmAboutBox();
            frmAboutBox.SetText( AboutElementAppend );
            int num = (int) frmAboutBox.ShowDialog();
        }

        private void mnuImportGumpling_Click( object sender, EventArgs e )
        {
            _OpenDialog.Filter = @"Gumpling (*.gumpling)|*.gumpling|Gump (*.gump)|*.gump";
            if ( _OpenDialog.ShowDialog() != DialogResult.OK )
                return;
            FileStream fileStream = new FileStream( _OpenDialog.FileName, FileMode.Open );
            GroupElement Gumpling = (GroupElement) new BinaryFormatter().Deserialize( fileStream );
            Gumpling.mIsBaseWindow = false;
            Gumpling.RecalculateBounds();
            Point point = new Point( 0, 0 );
            Gumpling.Location = point;
            fileStream.Close();
            UncategorizedFolder.AddItem( new TreeGumpling( Path.GetFileName( _OpenDialog.FileName ), Gumpling ) );
            BuildGumplingTree();
        }

        private void mnuPageClear_Click( object sender, EventArgs e )
        {
            ElementStack = new GroupElement( null, null, "Element Stack", true );
            CreateUndoPoint( "Clear Page" );
        }

        private void mnuPageDelete_Click( object sender, EventArgs e )
        {
            if ( _TabPager.SelectedIndex == 0 )
            {
                MessageBox.Show( @"Page 0 can not be deleted." );

            }
            else
            {
                int selectedIndex = _TabPager.SelectedIndex;
                int num2 = _TabPager.TabCount - 1;
                for ( int index = selectedIndex + 1 ; index <= num2 ; ++index )
                    _TabPager.TabPages[index].Text = Convert.ToString( index - 1 );
                Stacks.RemoveAt( selectedIndex );
                _TabPager.TabPages.RemoveAt( selectedIndex );
                ChangeActiveStack( selectedIndex - 1 );
                CreateUndoPoint( "Delete page" );
            }
        }

        private void mnuPageInsert_Click( object sender, EventArgs e )
        {
            if ( _TabPager.SelectedIndex == 0 )
            {
                //int num1 = (int) Interaction.MsgBox( (object) "Page 0 may not be moved.", MsgBoxStyle.OkOnly, (object) null );
                MessageBox.Show( @"Page 0 may not be moved." );
            }
            else
            {
                int tabCount = _TabPager.TabCount;
                int selectedIndex = _TabPager.SelectedIndex;
                int num2 = _TabPager.TabCount - 1;
                for ( int index = selectedIndex ; index <= num2 ; ++index )
                    _TabPager.TabPages.RemoveAt( selectedIndex );
                _TabPager.TabPages.Add( new TabPage( selectedIndex.ToString() ) );
                int num3 = tabCount;
                for ( int index = selectedIndex + 1 ; index <= num3 ; ++index )
                    _TabPager.TabPages.Add( new TabPage( index.ToString() ) );
                GroupElement groupElement = new GroupElement( null, null, "Element Stack", true );
                Stacks.Insert( selectedIndex, groupElement );
                ChangeActiveStack( selectedIndex );
                _TabPager.SelectedIndex = selectedIndex;
                CreateUndoPoint( "Insert page" );
            }
        }

        private void mnuPaste_Click( object sender, EventArgs e )
        {
            Paste();
            CreateUndoPoint();
        }

        private void mnuPluginManager_Click( object sender, EventArgs e )
        {
            int num = (int) new PluginManager()
            {
                AvailablePlugins = AvailablePlugins,
                LoadedPlugins = LoadedPlugins,
                OrderList = PluginTypesToLoad,
                MainForm = this
            }.ShowDialog();
        }

        private void mnuSelectAll_Click( object sender, EventArgs e )
        {
            SelectAll();
        }

        private void mnuShow0_Click( object sender, EventArgs e )
        {
            ShowPage0 = !ShowPage0;
            _mnuShow0.Checked = ShowPage0;
            _picCanvas.Refresh();
        }

        public void Paste()
        {
            IDataObject dataObject = Clipboard.GetDataObject();
            ArrayList arrayList = new ArrayList();
            ArrayList data = (ArrayList) dataObject.GetData( typeof( ArrayList ) );
            if ( data != null )
            {
                SetActiveElement( null, true );

                foreach ( object obj in data )
                {
                    BaseElement objectValue = (BaseElement) RuntimeHelpers.GetObjectValue( obj );
                    if ( CopyMode == ClipBoardMode.Copy )
                        objectValue.Name = "Copy of " + objectValue.Name;
                    objectValue.Selected = true;
                    ElementStack.AddElement( objectValue );
                }
            }
            _picCanvas.Invalidate();
        }

        private void picCanvas_MouseDown( object sender, MouseEventArgs e )
        {
            CanvasFocus.Focus();
            Point point = new Point( e.X, e.Y );
            mAnchor = point;
            BaseElement Element = ElementStack.GetElementFromPoint( point );
            if ( ( ActiveElement == null || ActiveElement.HitTest( point ) == MoveModeType.None ? 0 : 1 ) != 0 )
                Element = ActiveElement;
            if ( Element != null )
            {
                MoveMode = Element.HitTest( point );
                if ( ( ActiveElement == null || ActiveElement.HitTest( point ) != MoveModeType.None ? 0 : 1 ) != 0 )
                {
                    if ( Element.Selected )
                    {
                        if ( ( ModifierKeys & Keys.Control ) > Keys.None )
                            Element.Selected = false;
                        else
                            SetActiveElement( Element, false );
                    }
                    else
                        SetActiveElement( Element, ( ModifierKeys & Keys.Control ) <= Keys.None );
                }
                else if ( ActiveElement == null )
                    SetActiveElement( Element, false );
                else if ( ActiveElement != null && ( ModifierKeys & Keys.Control ) > Keys.None )
                {
                    ActiveElement.Selected = false;
                    ArrayList selectedElements = ElementStack.GetSelectedElements();
                    if ( selectedElements.Count > 0 )
                    {
                        SetActiveElement( (BaseElement) selectedElements[0], false );
                    }
                    else
                    {
                        SetActiveElement( null, true );
                        MoveMode = MoveModeType.None;
                    }
                }
            }
            else
            {
                MoveMode = MoveModeType.None;
                if ( ( e.Button & MouseButtons.Left ) > MouseButtons.None )
                    SetActiveElement( null, ( ModifierKeys & Keys.Control ) <= Keys.None );
            }
            _picCanvas.Invalidate();
            LastPos = point;
            if ( ActiveElement != null )
            {
                mAnchorOffset.Width = ActiveElement.X - point.X;
                mAnchorOffset.Height = ActiveElement.Y - point.Y;
            }
            ElementChanged = false;
            MoveCount = 0;
        }

        private void picCanvas_MouseMove( object sender, MouseEventArgs e )
        {
            Point point1 = new Point( e.X, e.Y );
            int num1 = point1.X - LastPos.X;
            int num2 = point1.Y - LastPos.Y;
            BaseElement baseElement = ElementStack.GetElementFromPoint( point1 );
            if ( ( ActiveElement == null || ActiveElement.HitTest( point1 ) == MoveModeType.None ? 0 : 1 ) != 0 )
                baseElement = ActiveElement;
            if ( MoveMode == MoveModeType.Move )
                point1.Offset( mAnchorOffset.Width, mAnchorOffset.Height );
            MouseMoveHookEventArgs e1 = new MouseMoveHookEventArgs();
            e1.Keys = ModifierKeys;
            e1.MouseButtons = e.Button;
            e1.MouseLocation = point1;
            e1.MoveMode = MoveMode;

            foreach ( object loadedPlugin in LoadedPlugins )
            {
                ( (BasePlugin) RuntimeHelpers.GetObjectValue( loadedPlugin ) ).MouseMoveHook( ref e1 );
                point1 = e1.MouseLocation;
            }

            if ( ( MoveMode != MoveModeType.None || Math.Abs( num1 ) <= 0 || Math.Abs( num2 ) <= 0 ? 0 : 1 ) != 0 )
                MoveMode = MoveModeType.SelectionBox;
            if ( e.Button != MouseButtons.Left )
            {
                if ( baseElement != null )
                {
                    switch ( baseElement.HitTest( point1 ) )
                    {
                        case MoveModeType.ResizeTopLeft:
                        case MoveModeType.ResizeBottomRight:
                            Cursor = Cursors.SizeNWSE;
                            break;
                        case MoveModeType.ResizeTopRight:
                        case MoveModeType.ResizeBottomLeft:
                            Cursor = Cursors.SizeNESW;
                            break;
                        case MoveModeType.Move:
                            Cursor = Cursors.SizeAll;
                            break;
                        case MoveModeType.ResizeLeft:
                        case MoveModeType.ResizeRight:
                            Cursor = Cursors.SizeWE;
                            break;
                        case MoveModeType.ResizeTop:
                        case MoveModeType.ResizeBottom:
                            Cursor = Cursors.SizeNS;
                            break;
                        default:
                            Cursor = Cursors.Default;
                            break;
                    }
                }
                else
                    Cursor = Cursors.Default;
            }
            else
            {
                ++MoveCount;
                if ( MoveCount > 100 )
                    MoveCount = 2;
                Rectangle rectangle = new Rectangle( 0, 0, _picCanvas.Width, _picCanvas.Height );
                Cursor.Clip = _picCanvas.RectangleToScreen( rectangle );
                if ( MoveMode != MoveModeType.None )
                {
                    switch ( MoveMode )
                    {
                        case MoveModeType.ResizeTopLeft:
                        case MoveModeType.ResizeBottomRight:
                            Cursor = Cursors.SizeNWSE;
                            break;
                        case MoveModeType.ResizeTopRight:
                        case MoveModeType.ResizeBottomLeft:
                            Cursor = Cursors.SizeNESW;
                            break;
                        case MoveModeType.Move:
                            Cursor = Cursors.SizeAll;
                            break;
                        case MoveModeType.ResizeLeft:
                        case MoveModeType.ResizeRight:
                            Cursor = Cursors.SizeWE;
                            break;
                        case MoveModeType.ResizeTop:
                        case MoveModeType.ResizeBottom:
                            Cursor = Cursors.SizeNS;
                            break;
                        default:
                            Cursor = Cursors.Default;
                            break;
                    }
                    if ( MoveCount >= 2 )
                        ElementChanged = true;
                }
                switch ( MoveMode )
                {
                    case MoveModeType.SelectionBox:
                        rectangle = new Rectangle( mAnchor, new Size( point1.X - mAnchor.X, point1.Y - mAnchor.Y ) );
                        SelectionRect = GetPositiveRect( rectangle );
                        ShowSelectionRect = true;
                        _picCanvas.Invalidate();
                        break;
                    case MoveModeType.ResizeTopLeft:
                        point1.Offset( 3, 0 );
                        Point point2 = new Point( ActiveElement.X + ActiveElement.Width, ActiveElement.Y + ActiveElement.Height );
                        ActiveElement.Location = point1;
                        Size size1 = ActiveElement.Size;
                        Point location1 = ActiveElement.Location;
                        size1.Width = point2.X - point1.X;
                        size1.Height = point2.Y - point1.Y;
                        if ( size1.Width < 1 )
                        {
                            location1.X = point2.X - 1;
                            size1.Width = 1;
                        }
                        if ( size1.Height < 1 )
                        {
                            location1.Y = point2.Y - 1;
                            size1.Height = 1;
                        }
                        ActiveElement.Size = size1;
                        ActiveElement.Location = location1;
                        _picCanvas.Invalidate();
                        break;
                    case MoveModeType.ResizeTopRight:
                        point1.Offset( -3, 0 );
                        Point point3 = new Point( ActiveElement.X + ActiveElement.Width, ActiveElement.Y + ActiveElement.Height );
                        Point location2 = ActiveElement.Location;
                        location2.Y = point1.Y;
                        ActiveElement.Location = location2;
                        Size size2 = ActiveElement.Size;
                        size2.Height = point3.Y - point1.Y;
                        size2.Width = point1.X - ActiveElement.X;
                        if ( size2.Height < 1 )
                        {
                            location2.Y = point3.Y - 1;
                            size2.Height = 1;
                        }
                        if ( size2.Width < 1 )
                            size2.Width = 1;
                        location2.X = ActiveElement.Location.X;
                        ActiveElement.Size = size2;
                        ActiveElement.Location = location2;
                        _picCanvas.Invalidate();
                        break;
                    case MoveModeType.ResizeBottomRight:

                        if ( ActiveElement == null )
                            break;

                        point1.Offset( -3, -3 );
                        Size size3 = ActiveElement.Size;
                        size3.Width = point1.X - ActiveElement.X;
                        size3.Height = point1.Y - ActiveElement.Y;
                        if ( size3.Width < 1 )
                            size3.Width = 1;
                        if ( size3.Height < 1 )
                            size3.Height = 1;
                        ActiveElement.Size = size3;
                        _picCanvas.Invalidate();
                        break;
                    case MoveModeType.ResizeBottomLeft:

                        if ( ActiveElement == null )
                            break;

                        point1.Offset( 0, -3 );
                        Point point4 = new Point( ActiveElement.X + ActiveElement.Width, ActiveElement.Y + ActiveElement.Height );
                        Point location3 = ActiveElement.Location;
                        location3.X = point1.X;
                        ActiveElement.Location = location3;
                        Size size4 = ActiveElement.Size;
                        size4.Width = point4.X - point1.X;
                        size4.Height = point1.Y - ActiveElement.Y;
                        if ( size4.Width < 1 )
                        {
                            location3.X = point4.X - 1;
                            size4.Width = 1;
                        }
                        if ( size4.Height < 1 )
                            size4.Height = 1;
                        location3.Y = ActiveElement.Y;
                        ActiveElement.Size = size4;
                        ActiveElement.Location = location3;
                        _picCanvas.Invalidate();
                        break;
                    case MoveModeType.Move:

                        if ( ActiveElement == null )
                            break;

                        IEnumerator enumerator2 = null;
                        Point location4 = ActiveElement.Location;
                        ActiveElement.Location = point1;
                        int dx = ActiveElement.X - location4.X;
                        int dy = ActiveElement.Y - location4.Y;
                        try
                        {
                            foreach ( object selectedElement in ElementStack.GetSelectedElements() )
                            {
                                BaseElement objectValue = (BaseElement) RuntimeHelpers.GetObjectValue( selectedElement );
                                if ( objectValue != ActiveElement )
                                {
                                    Point location5 = objectValue.Location;
                                    location5.Offset( dx, dy );
                                    objectValue.Location = location5;
                                }
                            }
                        }
                        finally
                        {
                            ( enumerator2 as IDisposable )?.Dispose();
                        }
                        _picCanvas.Invalidate();
                        break;
                    case MoveModeType.ResizeLeft:
                        point1.Offset( 3, 0 );
                        Point point5 = new Point( ActiveElement.X + ActiveElement.Width, ActiveElement.Y + ActiveElement.Height );
                        int y = ActiveElement.Y;
                        ActiveElement.Location = point1;
                        Size size5 = ActiveElement.Size;
                        Point location6 = ActiveElement.Location;
                        size5.Width = point5.X - point1.X;
                        if ( size5.Width < 1 )
                        {
                            location6.X = point5.X - 1;
                            size5.Width = 1;
                        }
                        location6.Y = y;
                        ActiveElement.Size = size5;
                        ActiveElement.Location = location6;
                        _picCanvas.Invalidate();
                        break;
                    case MoveModeType.ResizeTop:
                        point1.Offset( 0, 3 );
                        Point point6 = new Point( ActiveElement.X + ActiveElement.Width, ActiveElement.Y + ActiveElement.Height );
                        int x = ActiveElement.X;
                        ActiveElement.Location = point1;
                        Size size6 = ActiveElement.Size;
                        Point location7 = ActiveElement.Location;
                        size6.Height = point6.Y - point1.Y;
                        if ( size6.Height < 1 )
                        {
                            location7.Y = point6.Y - 1;
                            size6.Height = 1;
                        }
                        location7.X = x;
                        ActiveElement.Size = size6;
                        ActiveElement.Location = location7;
                        _picCanvas.Invalidate();
                        break;
                    case MoveModeType.ResizeRight:
                        point1.Offset( -3, 0 );
                        Size size7 = ActiveElement.Size;
                        size7.Width = point1.X - ActiveElement.X;
                        if ( size7.Width < 1 )
                            size7.Width = 1;
                        ActiveElement.Size = size7;
                        _picCanvas.Invalidate();
                        break;
                    case MoveModeType.ResizeBottom:
                        point1.Offset( 0, -3 );
                        Size size8 = ActiveElement.Size;
                        size8.Height = point1.Y - ActiveElement.Y;
                        if ( size8.Height < 1 )
                            size8.Height = 1;
                        ActiveElement.Size = size8;
                        _picCanvas.Invalidate();
                        break;
                }
            }
            LastPos = point1;
        }

        private void picCanvas_MouseUp( object sender, MouseEventArgs e )
        {
            Rectangle rectangle = new Rectangle();
            Point point = new Point( e.X, e.Y );
            ElementStack.GetElementFromPoint( point );
            ShowSelectionRect = false;
            Cursor.Clip = rectangle;
            if ( MoveMode == MoveModeType.SelectionBox )
            {
                BaseElement Element = null;

                foreach ( object element in ElementStack.GetElements() )
                {
                    BaseElement objectValue = (BaseElement) RuntimeHelpers.GetObjectValue( element );
                    if ( objectValue.ContainsTest( SelectionRect ) )
                    {
                        objectValue.Selected = true;
                        Element = objectValue;
                    }
                    else if ( ( ModifierKeys & Keys.Control ) <= Keys.None )
                        objectValue.Selected = false;
                }

                SetActiveElement( Element, false );
            }
            if ( ( MoveMode == MoveModeType.None || MoveMode == MoveModeType.SelectionBox || !ElementChanged ? 0 : 1 ) != 0 )
            {
                CreateUndoPoint( "Element Moved" );
                ElementChanged = false;
            }
            if ( ( e.Button & MouseButtons.Right ) > MouseButtons.None )
            {
                
                ContextMenuStrip mnuContextMenu = m_mnuContextMenu;
                GetContextMenu( ref ActiveElement, mnuContextMenu );
                mnuContextMenu.Show( _picCanvas, point );
                ClearContextMenu( mnuContextMenu );
            }
            SetActiveElement( ActiveElement, false );
            _picCanvas.Invalidate();
            MoveMode = MoveModeType.None;
            mAnchorOffset = new Size( 0, 0 );
        }

        private void picCanvas_Paint( object sender, PaintEventArgs e )
        {
            Render( e.Graphics );
        }

        private void pnlCanvasScroller_MouseLeave( object sender, EventArgs e )
        {
            Cursor = Cursors.Default;
        }

        public void RebuildTabPages()
        {
            _TabPager.TabPages.Clear();
            int num = -1;

            foreach ( object stack in Stacks )
            {
                object objectValue = RuntimeHelpers.GetObjectValue( stack );
                ++num;
                _TabPager.TabPages.Add( new TabPage( Convert.ToString( num ) ) );
                if ( ElementStack == objectValue )
                    _TabPager.SelectedIndex = num;
            }
        }

        public void Redo()
        {
            if ( CurrentUndoPoint < UndoPoints.Count )
            {
                ++CurrentUndoPoint;
                RevertToUndoPoint( CurrentUndoPoint );
            }
            if ( CurrentUndoPoint == UndoPoints.Count - 1 )
                _mnuEditRedo.Enabled = false;
            _mnuEditUndo.Enabled = true;
        }

        public void RefreshElementList()
        {
            m_cboElements.Items.Clear();
            m_cboElements.Items.AddRange( ElementStack.GetElements().ToArray() );
        }

        public void RefreshView( object sender )
        {
            RefreshElementList();
            m_cboElements.SelectedItem = ActiveElement;
            if ( ElementStack.GetSelectedElements().Count > 1 )
                m_ElementProperties.SelectedObjects = ElementStack.GetSelectedElements().ToArray();
            else
                m_ElementProperties.SelectedObject = ActiveElement;
        }

        protected void Render( Graphics Target )
        {
            Graphics Target1 = Graphics.FromImage( Canvas );
            if ( !PluginClearsCanvas )
                Target1.Clear( Color.Black );
            HookPreRenderEventHandler hookPreRender = HookPreRender;
            hookPreRender?.Invoke( Canvas );
            if ( ( !ShowPage0 || ElementStack == Stacks[0] ? 0 : 1 ) != 0 )
                ( (BaseElement) Stacks[0] ).Render( Target1 );
            ElementStack.Render( Target1 );

            foreach ( object element in ElementStack.GetElements() )
            {
                BaseElement objectValue = (BaseElement) RuntimeHelpers.GetObjectValue( element );
                if ( ( !objectValue.Selected || objectValue == ActiveElement ? 0 : 1 ) != 0 )
                    objectValue.DrawBoundingBox( Target1, false );
            }

            ActiveElement?.DrawBoundingBox( Target1, true );
            if ( ShowSelectionRect )
            {
                Target1.FillRectangle( SelBG, SelectionRect );
                Target1.DrawRectangle( SelFG, SelectionRect );
            }
            HookPostRenderEventHandler hookPostRender = HookPostRender;
            hookPostRender?.Invoke( Canvas );
            Target1.Dispose();
            Target.DrawImage( Canvas, 0, 0 );
        }

        public void RevertToUndoPoint( int Index )
        {
            UndoPoint undoPoint = (UndoPoint) UndoPoints[Index];
            GumpProperties = (GumpProperties) undoPoint.GumpProperties.Clone();
            Stacks = new ArrayList();
            foreach ( object obj in undoPoint.Stack )
            {
                GroupElement objectValue = (GroupElement) RuntimeHelpers.GetObjectValue( obj );
                GroupElement groupElement = (GroupElement) objectValue.Clone();
                Stacks.Add( groupElement );
                if ( undoPoint.ElementStack == objectValue )
                    ElementStack = groupElement;
            }

            RebuildTabPages();
            _picCanvas.Invalidate();
            SetActiveElement( null, true );
            CurrentUndoPoint = Index;
        }

        public void SaveTo( string Path )
        {
            _StatusBar.Text = $@"Saving gump...";
            ElementStack.UpdateParent -= new BaseElement.UpdateParentEventHandler( ChangeActiveElementEventHandler );
            ElementStack.Repaint -= new BaseElement.RepaintEventHandler( RefreshView );
            FileStream fileStream = new FileStream( Path, FileMode.Create );
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize( fileStream, Stacks );
            binaryFormatter.Serialize( fileStream, GumpProperties );
            fileStream.Close();
            ElementStack.UpdateParent += new BaseElement.UpdateParentEventHandler( ChangeActiveElementEventHandler );
            ElementStack.Repaint += new BaseElement.RepaintEventHandler( RefreshView );
            _StatusBar.Text = "";
        }

        public void SelectAll()
        {
            foreach ( object selectedElement in ElementStack.GetSelectedElements() )
                ( (BaseElement) RuntimeHelpers.GetObjectValue( selectedElement ) ).Selected = true;
            _picCanvas.Invalidate();
        }

        public void SetActiveElement( BaseElement e )
        {
            SetActiveElement( e, false );
        }

        public void SetActiveElement( BaseElement Element, bool DeselectOthers )
        {
            if ( DeselectOthers )
            {
                foreach ( object element in ElementStack.GetElements() )
                    ( (BaseElement) RuntimeHelpers.GetObjectValue( element ) ).Selected = false;
            }
            if ( ActiveElement != Element )
            {
                RefreshElementList();
                ActiveElement = Element;
                m_cboElements.SelectedItem = Element;
                if ( Element != null )
                    Element.Selected = true;
            }
            if ( ElementStack.GetSelectedElements().Count > 1 )
                m_ElementProperties.SelectedObjects = ElementStack.GetSelectedElements().ToArray();
            else if ( Element != null )
                m_ElementProperties.SelectedObject = Element;
            else
                m_ElementProperties.SelectedObject = GumpProperties;
        }

        public Point SnapLocToGrid( Point Position, Size GridSize )
        {
            Point point = Position;
            point.X = point.X / GridSize.Width * GridSize.Width;
            point.Y = point.Y / GridSize.Height * GridSize.Height;
            return point;
        }

        private void TabPager_SelectedIndexChanged( object sender, EventArgs e )
        {
            if ( _TabPager.SelectedIndex != -1 )
                ChangeActiveStack( _TabPager.SelectedIndex );
            RefreshElementList();
        }

        private void treGumplings_DoubleClick( object sender, EventArgs e )
        {
            if ( _treGumplings.SelectedNode.Tag == null || !( _treGumplings.SelectedNode.Tag is TreeGumpling ) )
                return;
            GroupElement groupElement = (GroupElement) ( (TreeGumpling) _treGumplings.SelectedNode.Tag ).Gumpling.Clone();
            groupElement.mIsBaseWindow = false;
            groupElement.RecalculateBounds();
            Point point = new Point( 0, 0 );
            groupElement.Location = point;
            AddElement( groupElement );
        }

        private void treGumplings_MouseUp( object sender, MouseEventArgs e )
        {
            _treGumplings.SelectedNode = _treGumplings.GetNodeAt( new Point( e.X, e.Y ) );
        }

        public void Undo()
        {
            --CurrentUndoPoint;
            RevertToUndoPoint( CurrentUndoPoint );
            if ( CurrentUndoPoint == 0 )
                _mnuEditUndo.Enabled = false;
            _mnuEditRedo.Enabled = true;
        }

        public void WritePluginsToLoad()
        {
            if ( PluginTypesToLoad != null )
            {
                FileStream fileStream = new FileStream( Application.StartupPath + "\\Plugins\\LoadInfo", FileMode.Create );
                new BinaryFormatter().Serialize( fileStream, PluginTypesToLoad );
                fileStream.Close();
            }
            else
            {
                if ( !File.Exists( Application.StartupPath + "\\Plugins\\LoadInfo" ) )
                    return;
                File.Delete( Application.StartupPath + "\\Plugins\\LoadInfo" );
            }
        }

        public delegate void HookKeyDownEventHandler( object sender, ref KeyEventArgs e );
        public delegate void HookPostRenderEventHandler( Bitmap Target );
        public delegate void HookPreRenderEventHandler( Bitmap Target );
    }
}
