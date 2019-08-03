// Decompiled with JetBrains decompiler
// Type: GumpStudio.DesignerForm
// Assembly: GumpStudioCore, Version=1.8.3024.24259, Culture=neutral, PublicKeyToken=null
// MVID: A77D32E5-7519-4865-AA26-DCCB34429732
// Assembly location: C:\GumpStudio_1_8_R3_quinted-02\GumpStudioCore.dll

using GumpStudio.Elements;
using GumpStudio.Plugins;
using Microsoft.VisualBasic.CompilerServices;
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

namespace GumpStudio
{
    public class DesignerForm : Form
    {
        [AccessedThroughProperty( "CanvasFocus" )]
        private TextBox m_CanvasFocus;
        [AccessedThroughProperty( "cboElements" )]
        private ComboBox m_cboElements;
        [AccessedThroughProperty( "ElementProperties" )]
        private PropertyGrid m_ElementProperties;
        [AccessedThroughProperty( "Label1" )]
        private Label m_Label1;
        [AccessedThroughProperty( "MainMenu" )]
        private MainMenu m_MainMenu;
        [AccessedThroughProperty( "MenuItem1" )]
        private MenuItem m_MenuItem1;
        [AccessedThroughProperty( "MenuItem10" )]
        private MenuItem m_MenuItem10;
        [AccessedThroughProperty( "MenuItem3" )]
        private MenuItem m_MenuItem3;
        [AccessedThroughProperty( "MenuItem4" )]
        private MenuItem m_MenuItem4;
        [AccessedThroughProperty( "MenuItem5" )]
        private MenuItem m_MenuItem5;
        [AccessedThroughProperty( "MenuItem9" )]
        private MenuItem m_MenuItem9;
        [AccessedThroughProperty( "mnuContextMenu" )]
        private ContextMenu m_mnuContextMenu;
        [AccessedThroughProperty( "mnuCopy" )]
        private MenuItem m_mnuCopy;
        [AccessedThroughProperty( "mnuCut" )]
        private MenuItem _mnuCut;
        [AccessedThroughProperty( "mnuDataFile" )]
        private MenuItem _mnuDataFile;
        [AccessedThroughProperty( "mnuDelete" )]
        private MenuItem _mnuDelete;
        [AccessedThroughProperty( "mnuEdit" )]
        private MenuItem _mnuEdit;
        [AccessedThroughProperty( "mnuEditRedo" )]
        private MenuItem _mnuEditRedo;
        [AccessedThroughProperty( "mnuEditUndo" )]
        private MenuItem _mnuEditUndo;
        [AccessedThroughProperty( "mnuFile" )]
        private MenuItem _mnuFile;
        [AccessedThroughProperty( "mnuFileExit" )]
        private MenuItem _mnuFileExit;
        [AccessedThroughProperty( "mnuFileExport" )]
        private MenuItem _mnuFileExport;
        [AccessedThroughProperty( "mnuFileImport" )]
        private MenuItem _mnuFileImport;
        [AccessedThroughProperty( "mnuFileNew" )]
        private MenuItem _mnuFileNew;
        [AccessedThroughProperty( "mnuFileOpen" )]
        private MenuItem _mnuFileOpen;
        [AccessedThroughProperty( "mnuFileSave" )]
        private MenuItem _mnuFileSave;
        [AccessedThroughProperty( "mnuGumplingAddFolder" )]
        private MenuItem _mnuGumplingAddFolder;
        [AccessedThroughProperty( "mnuGumplingAddGumpling" )]
        private MenuItem _mnuGumplingAddGumpling;
        [AccessedThroughProperty( "mnuGumplingContext" )]
        private ContextMenu _mnuGumplingContext;
        [AccessedThroughProperty( "mnuGumplingDelete" )]
        private MenuItem _mnuGumplingDelete;
        [AccessedThroughProperty( "mnuGumplingMove" )]
        private MenuItem _mnuGumplingMove;
        [AccessedThroughProperty( "mnuGumplingRename" )]
        private MenuItem _mnuGumplingRename;
        [AccessedThroughProperty( "mnuHelp" )]
        private MenuItem _mnuHelp;
        [AccessedThroughProperty( "mnuHelpAbout" )]
        private MenuItem _mnuHelpAbout;
        [AccessedThroughProperty( "mnuImportGumpling" )]
        private MenuItem _mnuImportGumpling;
        [AccessedThroughProperty( "mnuMisc" )]
        private MenuItem _mnuMisc;
        [AccessedThroughProperty( "mnuMiscLoadGumpling" )]
        private MenuItem _mnuMiscLoadGumpling;
        [AccessedThroughProperty( "mnuPage" )]
        private MenuItem _mnuPage;
        [AccessedThroughProperty( "mnuPageAdd" )]
        private MenuItem _mnuPageAdd;
        [AccessedThroughProperty( "mnuPageClear" )]
        private MenuItem _mnuPageClear;
        [AccessedThroughProperty( "mnuPageDelete" )]
        private MenuItem _mnuPageDelete;
        [AccessedThroughProperty( "mnuPageInsert" )]
        private MenuItem _mnuPageInsert;
        [AccessedThroughProperty( "mnuPaste" )]
        private MenuItem _mnuPaste;
        [AccessedThroughProperty( "mnuPluginManager" )]
        private MenuItem _mnuPluginManager;
        [AccessedThroughProperty( "mnuPlugins" )]
        private MenuItem _mnuPlugins;
        [AccessedThroughProperty( "mnuSelectAll" )]
        private MenuItem _mnuSelectAll;
        [AccessedThroughProperty( "mnuShow0" )]
        private MenuItem _mnuShow0;
        [AccessedThroughProperty( "OpenDialog" )]
        private OpenFileDialog _OpenDialog;
        [AccessedThroughProperty( "Panel1" )]
        private Panel _Panel1;
        [AccessedThroughProperty( "Panel2" )]
        private Panel _Panel2;
        [AccessedThroughProperty( "Panel3" )]
        private Panel _Panel3;
        [AccessedThroughProperty( "Panel4" )]
        private Panel _Panel4;
        [AccessedThroughProperty( "picCanvas" )]
        private PictureBox _picCanvas;
        [AccessedThroughProperty( "pnlCanvasScroller" )]
        private Panel _pnlCanvasScroller;
        [AccessedThroughProperty( "pnlToolbox" )]
        private Panel _pnlToolbox;
        [AccessedThroughProperty( "pnlToolboxHolder" )]
        private Panel _pnlToolboxHolder;
        [AccessedThroughProperty( "SaveDialog" )]
        private SaveFileDialog _SaveDialog;
        [AccessedThroughProperty( "Splitter1" )]
        private Splitter _Splitter1;
        [AccessedThroughProperty( "Splitter2" )]
        private Splitter _Splitter2;
        [AccessedThroughProperty( "StatusBar" )]
        private StatusBar _StatusBar;
        [AccessedThroughProperty( "TabPage1" )]
        private TabPage _TabPage1;
        [AccessedThroughProperty( "TabPager" )]
        private TabControl _TabPager;
        [AccessedThroughProperty( "tabToolbox" )]
        private TabControl _tabToolbox;
        [AccessedThroughProperty( "tpgCustom" )]
        private TabPage _tpgCustom;
        [AccessedThroughProperty( "tpgStandard" )]
        private TabPage _tpgStandard;
        [AccessedThroughProperty( "treGumplings" )]
        private TreeView _treGumplings;
        protected string AboutElementAppend;
        public BaseElement ActiveElement;
        public string AppPath;
        public Decimal ArrowKeyDelta;
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
        protected ArrayList UndoPoints;

        public virtual TextBox CanvasFocus
        {
            [DebuggerNonUserCode]
            get => m_CanvasFocus;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => m_CanvasFocus = value;
        }

        internal virtual ComboBox cboElements
        {
            [DebuggerNonUserCode]
            get => m_cboElements;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                EventHandler eventHandler1 = new EventHandler( cboElements_SelectedIndexChanged );
                EventHandler eventHandler2 = new EventHandler( cboElements_Click );
                if ( m_cboElements != null )
                {
                    m_cboElements.SelectedIndexChanged -= eventHandler1;
                    m_cboElements.Click -= eventHandler2;
                }
                m_cboElements = value;
                if ( m_cboElements == null )
                    return;
                m_cboElements.SelectedIndexChanged += eventHandler1;
                m_cboElements.Click += eventHandler2;
            }
        }

        public virtual PropertyGrid ElementProperties
        {
            [DebuggerNonUserCode]
            get => m_ElementProperties;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                PropertyValueChangedEventHandler changedEventHandler = new PropertyValueChangedEventHandler( ElementProperties_PropertyValueChanged );
                if ( m_ElementProperties != null )
                    m_ElementProperties.PropertyValueChanged -= changedEventHandler;
                m_ElementProperties = value;
                if ( m_ElementProperties == null )
                    return;
                m_ElementProperties.PropertyValueChanged += changedEventHandler;
            }
        }

        internal virtual Label Label1
        {
            [DebuggerNonUserCode]
            get => m_Label1;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => m_Label1 = value;
        }

        public virtual MainMenu MainMenu
        {
            [DebuggerNonUserCode]
            get => m_MainMenu;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => m_MainMenu = value;
        }

        internal virtual MenuItem MenuItem1
        {
            [DebuggerNonUserCode]
            get => m_MenuItem1;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => m_MenuItem1 = value;
        }

        internal virtual MenuItem MenuItem10
        {
            [DebuggerNonUserCode]
            get => m_MenuItem10;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => m_MenuItem10 = value;
        }

        internal virtual MenuItem MenuItem3
        {
            [DebuggerNonUserCode]
            get => m_MenuItem3;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => m_MenuItem3 = value;
        }

        internal virtual MenuItem MenuItem4
        {
            [DebuggerNonUserCode]
            get => m_MenuItem4;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => m_MenuItem4 = value;
        }

        internal virtual MenuItem MenuItem5
        {
            [DebuggerNonUserCode]
            get => m_MenuItem5;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => m_MenuItem5 = value;
        }

        internal virtual MenuItem MenuItem9
        {
            [DebuggerNonUserCode]
            get => m_MenuItem9;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => m_MenuItem9 = value;
        }

        public virtual ContextMenu mnuContextMenu
        {
            [DebuggerNonUserCode]
            get => m_mnuContextMenu;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => m_mnuContextMenu = value;
        }

        public virtual MenuItem mnuCopy
        {
            [DebuggerNonUserCode]
            get => m_mnuCopy;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                EventHandler eventHandler = new EventHandler( mnuCopy_Click );
                if ( m_mnuCopy != null )
                    m_mnuCopy.Click -= eventHandler;
                m_mnuCopy = value;
                if ( m_mnuCopy == null )
                    return;
                m_mnuCopy.Click += eventHandler;
            }
        }

        public virtual MenuItem mnuCut
        {
            [DebuggerNonUserCode]
            get => _mnuCut;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                EventHandler eventHandler = new EventHandler( mnuCut_Click );
                if ( _mnuCut != null )
                    _mnuCut.Click -= eventHandler;
                _mnuCut = value;
                if ( _mnuCut == null )
                    return;
                _mnuCut.Click += eventHandler;
            }
        }

        internal virtual MenuItem mnuDataFile
        {
            [DebuggerNonUserCode]
            get => _mnuDataFile;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                EventHandler eventHandler = new EventHandler( mnuDataFile_Click );
                if ( _mnuDataFile != null )
                    _mnuDataFile.Click -= eventHandler;
                _mnuDataFile = value;
                if ( _mnuDataFile == null )
                    return;
                _mnuDataFile.Click += eventHandler;
            }
        }

        internal virtual MenuItem mnuDelete
        {
            [DebuggerNonUserCode]
            get => _mnuDelete;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                EventHandler eventHandler = new EventHandler( mnuDelete_Click );
                if ( _mnuDelete != null )
                    _mnuDelete.Click -= eventHandler;
                _mnuDelete = value;
                if ( _mnuDelete == null )
                    return;
                _mnuDelete.Click += eventHandler;
            }
        }

        public virtual MenuItem mnuEdit
        {
            [DebuggerNonUserCode]
            get => _mnuEdit;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _mnuEdit = value;
        }

        internal virtual MenuItem mnuEditRedo
        {
            [DebuggerNonUserCode]
            get => _mnuEditRedo;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                EventHandler eventHandler = new EventHandler( mnuEditRedo_Click );
                if ( _mnuEditRedo != null )
                    _mnuEditRedo.Click -= eventHandler;
                _mnuEditRedo = value;
                if ( _mnuEditRedo == null )
                    return;
                _mnuEditRedo.Click += eventHandler;
            }
        }

        internal virtual MenuItem mnuEditUndo
        {
            [DebuggerNonUserCode]
            get => _mnuEditUndo;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                EventHandler eventHandler = new EventHandler( mnuEditUndo_Click );
                if ( _mnuEditUndo != null )
                    _mnuEditUndo.Click -= eventHandler;
                _mnuEditUndo = value;
                if ( _mnuEditUndo == null )
                    return;
                _mnuEditUndo.Click += eventHandler;
            }
        }

        public virtual MenuItem mnuFile
        {
            [DebuggerNonUserCode]
            get => _mnuFile;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _mnuFile = value;
        }

        public virtual MenuItem mnuFileExit
        {
            [DebuggerNonUserCode]
            get => _mnuFileExit;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                EventHandler eventHandler = new EventHandler( mnuFileExit_Click );
                if ( _mnuFileExit != null )
                    _mnuFileExit.Click -= eventHandler;
                _mnuFileExit = value;
                if ( _mnuFileExit == null )
                    return;
                _mnuFileExit.Click += eventHandler;
            }
        }

        public virtual MenuItem mnuFileExport
        {
            [DebuggerNonUserCode]
            get => _mnuFileExport;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _mnuFileExport = value;
        }

        public virtual MenuItem mnuFileImport
        {
            [DebuggerNonUserCode]
            get => _mnuFileImport;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _mnuFileImport = value;
        }

        public virtual MenuItem mnuFileNew
        {
            [DebuggerNonUserCode]
            get => _mnuFileNew;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                EventHandler eventHandler = new EventHandler( mnuFileNew_Click );
                if ( _mnuFileNew != null )
                    _mnuFileNew.Click -= eventHandler;
                _mnuFileNew = value;
                if ( _mnuFileNew == null )
                    return;
                _mnuFileNew.Click += eventHandler;
            }
        }

        public virtual MenuItem mnuFileOpen
        {
            [DebuggerNonUserCode]
            get => _mnuFileOpen;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                EventHandler eventHandler = new EventHandler( mnuFileOpen_Click );
                if ( _mnuFileOpen != null )
                    _mnuFileOpen.Click -= eventHandler;
                _mnuFileOpen = value;
                if ( _mnuFileOpen == null )
                    return;
                _mnuFileOpen.Click += eventHandler;
            }
        }

        public virtual MenuItem mnuFileSave
        {
            [DebuggerNonUserCode]
            get => _mnuFileSave;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                EventHandler eventHandler = new EventHandler( mnuFileSave_Click );
                if ( _mnuFileSave != null )
                    _mnuFileSave.Click -= eventHandler;
                _mnuFileSave = value;
                if ( _mnuFileSave == null )
                    return;
                _mnuFileSave.Click += eventHandler;
            }
        }

        internal virtual MenuItem mnuGumplingAddFolder
        {
            [DebuggerNonUserCode]
            get => _mnuGumplingAddFolder;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _mnuGumplingAddFolder = value;
        }

        internal virtual MenuItem mnuGumplingAddGumpling
        {
            [DebuggerNonUserCode]
            get => _mnuGumplingAddGumpling;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _mnuGumplingAddGumpling = value;
        }

        internal virtual ContextMenu mnuGumplingContext
        {
            [DebuggerNonUserCode]
            get => _mnuGumplingContext;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _mnuGumplingContext = value;
        }

        internal virtual MenuItem mnuGumplingDelete
        {
            [DebuggerNonUserCode]
            get => _mnuGumplingDelete;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _mnuGumplingDelete = value;
        }

        internal virtual MenuItem mnuGumplingMove
        {
            [DebuggerNonUserCode]
            get => _mnuGumplingMove;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _mnuGumplingMove = value;
        }

        internal virtual MenuItem mnuGumplingRename
        {
            [DebuggerNonUserCode]
            get => _mnuGumplingRename;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _mnuGumplingRename = value;
        }

        public virtual MenuItem mnuHelp
        {
            [DebuggerNonUserCode]
            get => _mnuHelp;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _mnuHelp = value;
        }

        public virtual MenuItem mnuHelpAbout
        {
            [DebuggerNonUserCode]
            get => _mnuHelpAbout;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                EventHandler eventHandler = new EventHandler( mnuHelpAbout_Click );
                if ( _mnuHelpAbout != null )
                    _mnuHelpAbout.Click -= eventHandler;
                _mnuHelpAbout = value;
                if ( _mnuHelpAbout == null )
                    return;
                _mnuHelpAbout.Click += eventHandler;
            }
        }

        internal virtual MenuItem mnuImportGumpling
        {
            [DebuggerNonUserCode]
            get => _mnuImportGumpling;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                EventHandler eventHandler = new EventHandler( mnuImportGumpling_Click );
                if ( _mnuImportGumpling != null )
                    _mnuImportGumpling.Click -= eventHandler;
                _mnuImportGumpling = value;
                if ( _mnuImportGumpling == null )
                    return;
                _mnuImportGumpling.Click += eventHandler;
            }
        }

        public virtual MenuItem mnuMisc
        {
            [DebuggerNonUserCode]
            get => _mnuMisc;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _mnuMisc = value;
        }

        public virtual MenuItem mnuMiscLoadGumpling
        {
            [DebuggerNonUserCode]
            get => _mnuMiscLoadGumpling;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                EventHandler eventHandler = new EventHandler( MenuItem2_Click );
                if ( _mnuMiscLoadGumpling != null )
                    _mnuMiscLoadGumpling.Click -= eventHandler;
                _mnuMiscLoadGumpling = value;
                if ( _mnuMiscLoadGumpling == null )
                    return;
                _mnuMiscLoadGumpling.Click += eventHandler;
            }
        }

        public virtual MenuItem mnuPage
        {
            [DebuggerNonUserCode]
            get => _mnuPage;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _mnuPage = value;
        }

        public virtual MenuItem mnuPageAdd
        {
            [DebuggerNonUserCode]
            get => _mnuPageAdd;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                EventHandler eventHandler = new EventHandler( mnuAddPage_Click );
                if ( _mnuPageAdd != null )
                    _mnuPageAdd.Click -= eventHandler;
                _mnuPageAdd = value;
                if ( _mnuPageAdd == null )
                    return;
                _mnuPageAdd.Click += eventHandler;
            }
        }

        internal virtual MenuItem mnuPageClear
        {
            [DebuggerNonUserCode]
            get => _mnuPageClear;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                EventHandler eventHandler = new EventHandler( mnuPageClear_Click );
                if ( _mnuPageClear != null )
                    _mnuPageClear.Click -= eventHandler;
                _mnuPageClear = value;
                if ( _mnuPageClear == null )
                    return;
                _mnuPageClear.Click += eventHandler;
            }
        }

        public virtual MenuItem mnuPageDelete
        {
            [DebuggerNonUserCode]
            get => _mnuPageDelete;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                EventHandler eventHandler = new EventHandler( mnuPageDelete_Click );
                if ( _mnuPageDelete != null )
                    _mnuPageDelete.Click -= eventHandler;
                _mnuPageDelete = value;
                if ( _mnuPageDelete == null )
                    return;
                _mnuPageDelete.Click += eventHandler;
            }
        }

        public virtual MenuItem mnuPageInsert
        {
            [DebuggerNonUserCode]
            get => _mnuPageInsert;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                EventHandler eventHandler = new EventHandler( mnuPageInsert_Click );
                if ( _mnuPageInsert != null )
                    _mnuPageInsert.Click -= eventHandler;
                _mnuPageInsert = value;
                if ( _mnuPageInsert == null )
                    return;
                _mnuPageInsert.Click += eventHandler;
            }
        }

        public virtual MenuItem mnuPaste
        {
            [DebuggerNonUserCode]
            get => _mnuPaste;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                EventHandler eventHandler = new EventHandler( mnuPaste_Click );
                if ( _mnuPaste != null )
                    _mnuPaste.Click -= eventHandler;
                _mnuPaste = value;
                if ( _mnuPaste == null )
                    return;
                _mnuPaste.Click += eventHandler;
            }
        }

        public virtual MenuItem mnuPluginManager
        {
            [DebuggerNonUserCode]
            get => _mnuPluginManager;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                EventHandler eventHandler = new EventHandler( mnuPluginManager_Click );
                if ( _mnuPluginManager != null )
                    _mnuPluginManager.Click -= eventHandler;
                _mnuPluginManager = value;
                if ( _mnuPluginManager == null )
                    return;
                _mnuPluginManager.Click += eventHandler;
            }
        }

        public virtual MenuItem mnuPlugins
        {
            [DebuggerNonUserCode]
            get => _mnuPlugins;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _mnuPlugins = value;
        }

        public virtual MenuItem mnuSelectAll
        {
            [DebuggerNonUserCode]
            get => _mnuSelectAll;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                EventHandler eventHandler = new EventHandler( mnuSelectAll_Click );
                if ( _mnuSelectAll != null )
                    _mnuSelectAll.Click -= eventHandler;
                _mnuSelectAll = value;
                if ( _mnuSelectAll == null )
                    return;
                _mnuSelectAll.Click += eventHandler;
            }
        }

        public virtual MenuItem mnuShow0
        {
            [DebuggerNonUserCode]
            get => _mnuShow0;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                EventHandler eventHandler = new EventHandler( mnuShow0_Click );
                if ( _mnuShow0 != null )
                    _mnuShow0.Click -= eventHandler;
                _mnuShow0 = value;
                if ( _mnuShow0 == null )
                    return;
                _mnuShow0.Click += eventHandler;
            }
        }

        internal virtual OpenFileDialog OpenDialog
        {
            [DebuggerNonUserCode]
            get => _OpenDialog;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _OpenDialog = value;
        }

        internal virtual Panel Panel1
        {
            [DebuggerNonUserCode]
            get => _Panel1;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _Panel1 = value;
        }

        internal virtual Panel Panel2
        {
            [DebuggerNonUserCode]
            get => _Panel2;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _Panel2 = value;
        }

        internal virtual Panel Panel3
        {
            [DebuggerNonUserCode]
            get => _Panel3;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _Panel3 = value;
        }

        internal virtual Panel Panel4
        {
            [DebuggerNonUserCode]
            get => _Panel4;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _Panel4 = value;
        }

        public virtual PictureBox picCanvas
        {
            [DebuggerNonUserCode]
            get => _picCanvas;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                MouseEventHandler mouseEventHandler1 = new MouseEventHandler( picCanvas_MouseUp );
                MouseEventHandler mouseEventHandler2 = new MouseEventHandler( picCanvas_MouseMove );
                PaintEventHandler paintEventHandler = new PaintEventHandler( picCanvas_Paint );
                MouseEventHandler mouseEventHandler3 = new MouseEventHandler( picCanvas_MouseDown );
                if ( _picCanvas != null )
                {
                    _picCanvas.MouseUp -= mouseEventHandler1;
                    _picCanvas.MouseMove -= mouseEventHandler2;
                    _picCanvas.Paint -= paintEventHandler;
                    _picCanvas.MouseDown -= mouseEventHandler3;
                }
                _picCanvas = value;
                if ( _picCanvas == null )
                    return;
                _picCanvas.MouseUp += mouseEventHandler1;
                _picCanvas.MouseMove += mouseEventHandler2;
                _picCanvas.Paint += paintEventHandler;
                _picCanvas.MouseDown += mouseEventHandler3;
            }
        }

        internal virtual Panel pnlCanvasScroller
        {
            [DebuggerNonUserCode]
            get => _pnlCanvasScroller;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                EventHandler eventHandler = new EventHandler( pnlCanvasScroller_MouseLeave );
                if ( _pnlCanvasScroller != null )
                    _pnlCanvasScroller.MouseLeave -= eventHandler;
                _pnlCanvasScroller = value;
                if ( _pnlCanvasScroller == null )
                    return;
                _pnlCanvasScroller.MouseLeave += eventHandler;
            }
        }

        internal virtual Panel pnlToolbox
        {
            [DebuggerNonUserCode]
            get => _pnlToolbox;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _pnlToolbox = value;
        }

        internal virtual Panel pnlToolboxHolder
        {
            [DebuggerNonUserCode]
            get => _pnlToolboxHolder;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _pnlToolboxHolder = value;
        }

        internal virtual SaveFileDialog SaveDialog
        {
            [DebuggerNonUserCode]
            get => _SaveDialog;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _SaveDialog = value;
        }

        internal virtual Splitter Splitter1
        {
            [DebuggerNonUserCode]
            get => _Splitter1;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _Splitter1 = value;
        }

        internal virtual Splitter Splitter2
        {
            [DebuggerNonUserCode]
            get => _Splitter2;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _Splitter2 = value;
        }

        public virtual StatusBar StatusBar
        {
            [DebuggerNonUserCode]
            get => _StatusBar;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _StatusBar = value;
        }

        internal virtual TabPage TabPage1
        {
            [DebuggerNonUserCode]
            get => _TabPage1;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _TabPage1 = value;
        }

        internal virtual TabControl TabPager
        {
            [DebuggerNonUserCode]
            get => _TabPager;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                EventHandler eventHandler = new EventHandler( TabPager_SelectedIndexChanged );
                if ( _TabPager != null )
                    _TabPager.SelectedIndexChanged -= eventHandler;
                _TabPager = value;
                if ( _TabPager == null )
                    return;
                _TabPager.SelectedIndexChanged += eventHandler;
            }
        }

        internal virtual TabControl tabToolbox
        {
            [DebuggerNonUserCode]
            get => _tabToolbox;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _tabToolbox = value;
        }

        internal virtual TabPage tpgCustom
        {
            [DebuggerNonUserCode]
            get => _tpgCustom;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _tpgCustom = value;
        }

        internal virtual TabPage tpgStandard
        {
            [DebuggerNonUserCode]
            get => _tpgStandard;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => _tpgStandard = value;
        }

        internal virtual TreeView treGumplings
        {
            [DebuggerNonUserCode]
            get => _treGumplings;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                MouseEventHandler mouseEventHandler = new MouseEventHandler( treGumplings_MouseUp );
                EventHandler eventHandler = new EventHandler( treGumplings_DoubleClick );
                if ( _treGumplings != null )
                {
                    _treGumplings.MouseUp -= mouseEventHandler;
                    _treGumplings.DoubleClick -= eventHandler;
                }
                _treGumplings = value;
                if ( _treGumplings == null )
                    return;
                _treGumplings.MouseUp += mouseEventHandler;
                _treGumplings.DoubleClick += eventHandler;
            }
        }

        public event HookKeyDownEventHandler HookKeyDown;

        public event HookPostRenderEventHandler HookPostRender;

        public event HookPreRenderEventHandler HookPreRender;

        public DesignerForm()
        {
            Closed += new EventHandler( DesignerForm_Closed );
            Closing += new CancelEventHandler( DesignerForm_Closing );
            KeyUp += new KeyEventHandler( DesignerForm_KeyUp );
            Load += new EventHandler( DesignerForm_Load );
            FormClosing += new FormClosingEventHandler( DesignerForm_FormClosing );
            KeyDown += new KeyEventHandler( DesignerForm_KeyDown );
            ElementStack = new GroupElement( null, null, "CanvasStack", true );
            Stacks = new ArrayList();
            ShouldClearActiveElement = false;
            PluginClearsCanvas = false;
            AppPath = Application.StartupPath;
            ArrowKeyDelta = new Decimal( 1 );
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
            _TabPager.TabPages.Add( new TabPage( Conversions.ToString( Stacks.Count - 1 ) ) );
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
            IEnumerator enumerator = null;
            try
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
            finally
            {
                if ( enumerator is IDisposable )
                    ( enumerator as IDisposable ).Dispose();
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
                    IEnumerator enumerator2 = null;
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
                    try
                    {
                        foreach ( object loadedPlugin in LoadedPlugins )
                            ( (BasePlugin) RuntimeHelpers.GetObjectValue( loadedPlugin ) ).InitializeElementExtenders( instance );
                    }
                    finally
                    {
                        if ( enumerator2 is IDisposable )
                            ( enumerator2 as IDisposable ).Dispose();
                    }
                }
            }
            catch ( Exception ex )
            {
                int num = (int) MessageBox.Show( "HOHO\n" + ex.Message + "\n" + ex.StackTrace );
            }
            finally
            {
                if ( enumerator1 is IDisposable )
                    ( enumerator1 as IDisposable ).Dispose();
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
            IEnumerator enumerator = null;
            try
            {
                foreach ( object element in ElementStack.GetElements() )
                    ( (BaseElement) RuntimeHelpers.GetObjectValue( element ) ).Selected = false;
            }
            finally
            {
                if ( enumerator is IDisposable )
                    ( enumerator as IDisposable ).Dispose();
            }
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

        public void ClearContextMenu( Menu Menu )
        {
            int num = Menu.MenuItems.Count - 1;
            for ( int index = 0 ; index <= num ; ++index )
            {
                MenuItem menuItem = Menu.MenuItems[0];
                Menu.MenuItems.RemoveAt( 0 );
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
            Text = "Gump Studio (-Unsaved Gump-)";
            ChangeActiveStack( 0 );
            UndoPoints = new ArrayList();
            CreateUndoPoint( "Blank" );
            _mnuEditUndo.Enabled = false;
            _mnuEditRedo.Enabled = false;
        }

        public void Copy()
        {
            IEnumerator enumerator = null;
            ArrayList arrayList = new ArrayList();
            try
            {
                foreach ( object selectedElement in ElementStack.GetSelectedElements() )
                    arrayList.Add( ( (BaseElement) RuntimeHelpers.GetObjectValue( selectedElement ) ).Clone() );
            }
            finally
            {
                if ( enumerator is IDisposable )
                    ( enumerator as IDisposable ).Dispose();
            }
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
                if ( enumerator is IDisposable )
                    ( enumerator as IDisposable ).Dispose();
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
                if ( enumerator is IDisposable )
                    ( enumerator as IDisposable ).Dispose();
            }
            SetActiveElement( GetLastSelectedControl() );
            _picCanvas.Invalidate();
            if ( !flag )
                return;
            CreateUndoPoint( "Delete Elements" );
        }

        private void DesignerForm_Closed( object sender, EventArgs e )
        {
            if ( SelFG != null )
                SelFG.Dispose();
            if ( SelBG != null )
                SelBG.Dispose();
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
                if ( enumerator is IDisposable )
                    ( enumerator as IDisposable ).Dispose();
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
            if ( hookKeyDown != null )
                hookKeyDown( ActiveControl, ref e );
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
                    if ( enumerator is IDisposable )
                        ( enumerator as IDisposable ).Dispose();
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
                    if ( enumerator is IDisposable )
                        ( enumerator as IDisposable ).Dispose();
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
                    if ( enumerator is IDisposable )
                        ( enumerator as IDisposable ).Dispose();
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
                    if ( enumerator is IDisposable )
                        ( enumerator as IDisposable ).Dispose();
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

            if ( !File.Exists( Path.Combine( XMLSettings.CurrentOptions.ClientPath, "art.mul" ) ) )
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.SelectedPath = Environment.SpecialFolder.ProgramFiles.ToString();
                folderBrowserDialog.Description = "Select the folder that contains the UO data (.mul) files you want to use.";
                if ( folderBrowserDialog.ShowDialog() == DialogResult.OK )
                {
                    if ( File.Exists( Path.Combine( folderBrowserDialog.SelectedPath, "art.mul" ) ) )
                    {
                        XMLSettings.CurrentOptions.ClientPath = folderBrowserDialog.SelectedPath;
                        XMLSettings.Save( this, XMLSettings.CurrentOptions );
                    }
                    else
                    {
                        //int num = (int) Interaction.MsgBox( (object) "This path does not contain a file named \"art.mul\", it is most likely not the correct path. Gump Studio can not run without valid client data files.", MsgBoxStyle.OkOnly, (object) "Data Files" );
                        MessageBox.Show( "This path does not contain a file named \"art.mul\", it is most likely not the correct path. Gump Studio can not run without valid client data files.", "Data Files" );
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
            Client.Directories.Add( XMLSettings.CurrentOptions.ClientPath );
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
                        ProjectData.SetProjectError( ex );
                        Exception exception = ex;
                        //int num = (int) Interaction.MsgBox( (object) ( "Error loading plugin: " + type.Name + "(" + file + ")\r\n\r\n" + exception.Message ), MsgBoxStyle.OkOnly, (object) null );
                        MessageBox.Show( "Error loading plugin: " + type.Name + "(" + file + ")\r\n\r\n" + exception.Message );
                        ProjectData.ClearProjectError();
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
                    if ( enumerator is IDisposable )
                        ( enumerator as IDisposable ).Dispose();
                }
            }
        }

        protected void GetContextMenu( ref BaseElement Element, ContextMenu Menu )
        {
            MenuItem GroupMenu = new MenuItem( "Grouping" );
            MenuItem PositionMenu = new MenuItem( "Positioning" );
            MenuItem OrderMenu = new MenuItem( "Order" );
            MenuItem MiscMenu = new MenuItem( "Misc" );
            MenuItem menuItem = new MenuItem( "Edit" );
            menuItem.MenuItems.Add( new MenuItem( "Cut", new EventHandler( mnuCut_Click ) ) );
            menuItem.MenuItems.Add( new MenuItem( "Copy", new EventHandler( mnuCopy_Click ) ) );
            menuItem.MenuItems.Add( new MenuItem( "Paste", new EventHandler( mnuPaste_Click ) ) );
            menuItem.MenuItems.Add( new MenuItem( "Delete", new EventHandler( mnuDelete_Click ) ) );
            Menu.MenuItems.Add( menuItem );
            Menu.MenuItems.Add( new MenuItem( "-" ) );
            Menu.MenuItems.Add( GroupMenu );
            Menu.MenuItems.Add( PositionMenu );
            Menu.MenuItems.Add( OrderMenu );
            Menu.MenuItems.Add( new MenuItem( "-" ) );
            Menu.MenuItems.Add( MiscMenu );
            if ( ElementStack.GetSelectedElements().Count >= 2 )
                GroupMenu.MenuItems.Add( new MenuItem( "Create Group", new EventHandler( mnuGroupCreate_Click ) ) );
            if ( Element != null )
                Element.AddContextMenus( ref GroupMenu, ref PositionMenu, ref OrderMenu, ref MiscMenu );
            if ( GroupMenu.MenuItems.Count == 0 )
                GroupMenu.Enabled = false;
            if ( PositionMenu.MenuItems.Count == 0 )
                PositionMenu.Enabled = false;
            if ( OrderMenu.MenuItems.Count == 0 )
                OrderMenu.Enabled = false;
            if ( MiscMenu.MenuItems.Count != 0 )
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
                if ( enumerator is IDisposable )
                    ( enumerator as IDisposable ).Dispose();
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
            if ( disposing && components != null )
                components.Dispose();
            base.Dispose( disposing );
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            components = new Container();
            pnlToolboxHolder = new Panel();
            Panel4 = new Panel();
            tabToolbox = new TabControl();
            tpgStandard = new TabPage();
            pnlToolbox = new Panel();
            tpgCustom = new TabPage();
            treGumplings = new TreeView();
            Label1 = new Label();
            StatusBar = new StatusBar();
            Splitter1 = new Splitter();
            Panel1 = new Panel();
            Panel2 = new Panel();
            pnlCanvasScroller = new Panel();
            picCanvas = new PictureBox();
            TabPager = new TabControl();
            TabPage1 = new TabPage();
            Splitter2 = new Splitter();
            Panel3 = new Panel();
            cboElements = new ComboBox();
            ElementProperties = new PropertyGrid();
            CanvasFocus = new TextBox();
            OpenDialog = new OpenFileDialog();
            SaveDialog = new SaveFileDialog();
            mnuContextMenu = new ContextMenu();
            MainMenu = new MainMenu( components );
            mnuFile = new MenuItem();
            mnuFileNew = new MenuItem();
            MenuItem9 = new MenuItem();
            mnuFileOpen = new MenuItem();
            mnuFileSave = new MenuItem();
            mnuFileImport = new MenuItem();
            mnuFileExport = new MenuItem();
            MenuItem5 = new MenuItem();
            mnuFileExit = new MenuItem();
            mnuEdit = new MenuItem();
            mnuEditUndo = new MenuItem();
            mnuEditRedo = new MenuItem();
            MenuItem3 = new MenuItem();
            mnuCut = new MenuItem();
            mnuCopy = new MenuItem();
            mnuPaste = new MenuItem();
            mnuDelete = new MenuItem();
            MenuItem4 = new MenuItem();
            mnuSelectAll = new MenuItem();
            mnuMisc = new MenuItem();
            mnuMiscLoadGumpling = new MenuItem();
            mnuImportGumpling = new MenuItem();
            mnuDataFile = new MenuItem();
            mnuPage = new MenuItem();
            mnuPageAdd = new MenuItem();
            mnuPageInsert = new MenuItem();
            mnuPageDelete = new MenuItem();
            mnuPageClear = new MenuItem();
            MenuItem10 = new MenuItem();
            mnuShow0 = new MenuItem();
            mnuPlugins = new MenuItem();
            mnuPluginManager = new MenuItem();
            mnuHelp = new MenuItem();
            mnuHelpAbout = new MenuItem();
            mnuGumplingContext = new ContextMenu();
            mnuGumplingRename = new MenuItem();
            mnuGumplingMove = new MenuItem();
            mnuGumplingDelete = new MenuItem();
            MenuItem1 = new MenuItem();
            mnuGumplingAddGumpling = new MenuItem();
            mnuGumplingAddFolder = new MenuItem();
            _pnlToolboxHolder.SuspendLayout();
            _Panel4.SuspendLayout();
            _tabToolbox.SuspendLayout();
            _tpgStandard.SuspendLayout();
            _tpgCustom.SuspendLayout();
            _Panel1.SuspendLayout();
            _Panel2.SuspendLayout();
            _pnlCanvasScroller.SuspendLayout();
            _TabPager.SuspendLayout();
            _Panel3.SuspendLayout();
            SuspendLayout();
            _pnlToolboxHolder.BorderStyle = BorderStyle.Fixed3D;
            _pnlToolboxHolder.Controls.Add( _Panel4 );
            _pnlToolboxHolder.Controls.Add( m_Label1 );
            _pnlToolboxHolder.Dock = DockStyle.Left;
            _pnlToolboxHolder.Location = new Point( 0, 0 );
            _pnlToolboxHolder.Name = "_pnlToolboxHolder";
            _pnlToolboxHolder.Size = new Size( 128, 523 );
            _pnlToolboxHolder.TabIndex = 0;
            _Panel4.Controls.Add( _tabToolbox );
            _Panel4.Dock = DockStyle.Fill;
            _Panel4.Location = new Point( 0, 16 );
            _Panel4.Name = "_Panel4";
            _Panel4.Size = new Size( 124, 503 );
            _Panel4.TabIndex = 1;
            _tabToolbox.Controls.Add( _tpgStandard );
            _tabToolbox.Controls.Add( _tpgCustom );
            _tabToolbox.Dock = DockStyle.Fill;
            _tabToolbox.Location = new Point( 0, 0 );
            _tabToolbox.Multiline = true;
            _tabToolbox.Name = "_tabToolbox";
            _tabToolbox.SelectedIndex = 0;
            _tabToolbox.Size = new Size( 124, 503 );
            _tabToolbox.TabIndex = 1;
            _tpgStandard.Controls.Add( _pnlToolbox );
            _tpgStandard.Location = new Point( 4, 22 );
            _tpgStandard.Name = "_tpgStandard";
            _tpgStandard.Size = new Size( 116, 477 );
            _tpgStandard.TabIndex = 0;
            _tpgStandard.Text = "Standard";
            _pnlToolbox.AutoScroll = true;
            _pnlToolbox.Dock = DockStyle.Fill;
            _pnlToolbox.Location = new Point( 0, 0 );
            _pnlToolbox.Name = "_pnlToolbox";
            _pnlToolbox.Size = new Size( 116, 477 );
            _pnlToolbox.TabIndex = 1;
            _tpgCustom.Controls.Add( _treGumplings );
            _tpgCustom.Location = new Point( 4, 22 );
            _tpgCustom.Name = "_tpgCustom";
            _tpgCustom.Size = new Size( 116, 477 );
            _tpgCustom.TabIndex = 1;
            _tpgCustom.Text = "Gumplings";
            _treGumplings.Dock = DockStyle.Fill;
            _treGumplings.Location = new Point( 0, 0 );
            _treGumplings.Name = "_treGumplings";
            _treGumplings.Size = new Size( 116, 477 );
            _treGumplings.TabIndex = 1;
            m_Label1.BackColor = SystemColors.ControlDark;
            m_Label1.BorderStyle = BorderStyle.Fixed3D;
            m_Label1.Dock = DockStyle.Top;
            m_Label1.Location = new Point( 0, 0 );
            m_Label1.Name = "m_Label1";
            m_Label1.Size = new Size( 124, 16 );
            m_Label1.TabIndex = 0;
            m_Label1.Text = "Toolbox";
            m_Label1.TextAlign = ContentAlignment.MiddleCenter;
            _StatusBar.Location = new Point( 0, 523 );
            _StatusBar.Name = "_StatusBar";
            _StatusBar.Size = new Size( 904, 22 );
            _StatusBar.TabIndex = 0;
            _Splitter1.BorderStyle = BorderStyle.Fixed3D;
            _Splitter1.Location = new Point( 128, 0 );
            _Splitter1.MinSize = 80;
            _Splitter1.Name = "_Splitter1";
            _Splitter1.Size = new Size( 3, 523 );
            _Splitter1.TabIndex = 1;
            _Splitter1.TabStop = false;
            _Panel1.Controls.Add( _Panel2 );
            _Panel1.Dock = DockStyle.Fill;
            _Panel1.Location = new Point( 131, 0 );
            _Panel1.Name = "_Panel1";
            _Panel1.Size = new Size( 773, 523 );
            _Panel1.TabIndex = 2;
            _Panel2.Controls.Add( _pnlCanvasScroller );
            _Panel2.Controls.Add( _TabPager );
            _Panel2.Controls.Add( _Splitter2 );
            _Panel2.Controls.Add( _Panel3 );
            _Panel2.Dock = DockStyle.Fill;
            _Panel2.Location = new Point( 0, 0 );
            _Panel2.Name = "_Panel2";
            _Panel2.Size = new Size( 773, 523 );
            _Panel2.TabIndex = 0;
            _pnlCanvasScroller.AutoScroll = true;
            _pnlCanvasScroller.AutoScrollMargin = new Size( 1, 1 );
            _pnlCanvasScroller.AutoScrollMinSize = new Size( 1, 1 );
            _pnlCanvasScroller.BackColor = Color.Silver;
            _pnlCanvasScroller.BorderStyle = BorderStyle.Fixed3D;
            _pnlCanvasScroller.Controls.Add( _picCanvas );
            _pnlCanvasScroller.Dock = DockStyle.Fill;
            _pnlCanvasScroller.Location = new Point( 0, 24 );
            _pnlCanvasScroller.Name = "_pnlCanvasScroller";
            _pnlCanvasScroller.Size = new Size( 503, 499 );
            _pnlCanvasScroller.TabIndex = 2;
            _picCanvas.BackColor = Color.Black;
            _picCanvas.Location = new Point( 0, 0 );
            _picCanvas.Name = "_picCanvas";
            _picCanvas.Size = new Size( 1600, 1200 );
            _picCanvas.TabIndex = 0;
            _picCanvas.TabStop = false;
            _TabPager.Controls.Add( _TabPage1 );
            _TabPager.Dock = DockStyle.Top;
            _TabPager.HotTrack = true;
            _TabPager.Location = new Point( 0, 0 );
            _TabPager.Name = "_TabPager";
            _TabPager.SelectedIndex = 0;
            _TabPager.Size = new Size( 503, 24 );
            _TabPager.TabIndex = 3;
            _TabPage1.Location = new Point( 4, 22 );
            _TabPage1.Name = "_TabPage1";
            _TabPage1.Size = new Size( 495, 0 );
            _TabPage1.TabIndex = 0;
            _TabPage1.Text = "0";
            _Splitter2.Dock = DockStyle.Right;
            _Splitter2.Location = new Point( 503, 0 );
            _Splitter2.Name = "_Splitter2";
            _Splitter2.Size = new Size( 22, 523 );
            _Splitter2.TabIndex = 1;
            _Splitter2.TabStop = false;
            _Panel3.Controls.Add( m_cboElements );
            _Panel3.Controls.Add( m_ElementProperties );
            _Panel3.Controls.Add( m_CanvasFocus );
            _Panel3.Dock = DockStyle.Right;
            _Panel3.Location = new Point( 525, 0 );
            _Panel3.Name = "_Panel3";
            _Panel3.Size = new Size( 248, 523 );
            _Panel3.TabIndex = 0;
            m_cboElements.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            m_cboElements.DropDownStyle = ComboBoxStyle.DropDownList;
            m_cboElements.Location = new Point( 0, 8 );
            m_cboElements.Name = "m_cboElements";
            m_cboElements.Size = new Size( 240, 21 );
            m_cboElements.TabIndex = 1;
            m_ElementProperties.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            m_ElementProperties.Cursor = Cursors.HSplit;
            m_ElementProperties.LineColor = SystemColors.ScrollBar;
            m_ElementProperties.Location = new Point( 0, 32 );
            m_ElementProperties.Name = "m_ElementProperties";
            m_ElementProperties.Size = new Size( 240, 488 );
            m_ElementProperties.TabIndex = 0;
            m_CanvasFocus.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            m_CanvasFocus.Location = new Point( 16, 472 );
            m_CanvasFocus.Name = "m_CanvasFocus";
            m_CanvasFocus.Size = new Size( 100, 20 );
            m_CanvasFocus.TabIndex = 1;
            m_CanvasFocus.Text = "TextBox1";
            m_MainMenu.MenuItems.AddRange( new MenuItem[6]
            {
        _mnuFile,
        _mnuEdit,
        _mnuMisc,
        _mnuPage,
        _mnuPlugins,
        _mnuHelp
            } );
            _mnuFile.Index = 0;
            _mnuFile.MenuItems.AddRange( new MenuItem[8]
            {
        _mnuFileNew,
        m_MenuItem9,
        _mnuFileOpen,
        _mnuFileSave,
        _mnuFileImport,
        _mnuFileExport,
        m_MenuItem5,
        _mnuFileExit
            } );
            _mnuFile.Text = "File";
            _mnuFileNew.Index = 0;
            _mnuFileNew.Text = "New";
            m_MenuItem9.Index = 1;
            m_MenuItem9.Text = "-";
            _mnuFileOpen.Index = 2;
            _mnuFileOpen.Text = "Open";
            _mnuFileSave.Index = 3;
            _mnuFileSave.Text = "Save";
            _mnuFileImport.Enabled = false;
            _mnuFileImport.Index = 4;
            _mnuFileImport.Text = "Import";
            _mnuFileExport.Enabled = false;
            _mnuFileExport.Index = 5;
            _mnuFileExport.Text = "Export";
            m_MenuItem5.Index = 6;
            m_MenuItem5.Text = "-";
            _mnuFileExit.Index = 7;
            _mnuFileExit.Text = "Exit";
            _mnuEdit.Index = 1;
            _mnuEdit.MenuItems.AddRange( new MenuItem[9]
            {
        _mnuEditUndo,
        _mnuEditRedo,
        m_MenuItem3,
        _mnuCut,
        m_mnuCopy,
        _mnuPaste,
        _mnuDelete,
        m_MenuItem4,
        _mnuSelectAll
            } );
            _mnuEdit.Text = "Edit";
            _mnuEditUndo.Enabled = false;
            _mnuEditUndo.Index = 0;
            _mnuEditUndo.Shortcut = Shortcut.CtrlZ;
            _mnuEditUndo.Text = "Undo";
            _mnuEditRedo.Enabled = false;
            _mnuEditRedo.Index = 1;
            _mnuEditRedo.Shortcut = Shortcut.CtrlY;
            _mnuEditRedo.Text = "Redo";
            m_MenuItem3.Index = 2;
            m_MenuItem3.Text = "-";
            _mnuCut.Index = 3;
            _mnuCut.Shortcut = Shortcut.CtrlX;
            _mnuCut.Text = "Cu&t";
            m_mnuCopy.Index = 4;
            m_mnuCopy.Shortcut = Shortcut.CtrlC;
            m_mnuCopy.Text = "&Copy";
            _mnuPaste.Index = 5;
            _mnuPaste.Shortcut = Shortcut.CtrlV;
            _mnuPaste.Text = "&Paste";
            _mnuDelete.Index = 6;
            _mnuDelete.Text = "Delete";
            m_MenuItem4.Index = 7;
            m_MenuItem4.Text = "-";
            _mnuSelectAll.Index = 8;
            _mnuSelectAll.Shortcut = Shortcut.CtrlA;
            _mnuSelectAll.Text = "Select &All";
            _mnuMisc.Index = 2;
            _mnuMisc.MenuItems.AddRange( new MenuItem[3]
            {
        _mnuMiscLoadGumpling,
        _mnuImportGumpling,
        _mnuDataFile
            } );
            _mnuMisc.Text = "Misc";
            _mnuMiscLoadGumpling.Index = 0;
            _mnuMiscLoadGumpling.Text = "Load gumpling";
            _mnuImportGumpling.Index = 1;
            _mnuImportGumpling.Text = "Import Gumpling";
            _mnuDataFile.Index = 2;
            _mnuDataFile.Text = "Data File Path";
            _mnuPage.Index = 3;
            _mnuPage.MenuItems.AddRange( new MenuItem[6]
            {
        _mnuPageAdd,
        _mnuPageInsert,
        _mnuPageDelete,
        _mnuPageClear,
        m_MenuItem10,
        _mnuShow0
            } );
            _mnuPage.Text = "Page";
            _mnuPageAdd.Index = 0;
            _mnuPageAdd.Text = "Add Page";
            _mnuPageInsert.Index = 1;
            _mnuPageInsert.Text = "Insert Page";
            _mnuPageDelete.Index = 2;
            _mnuPageDelete.Text = "Delete Page";
            _mnuPageClear.Index = 3;
            _mnuPageClear.Text = "Clear Page";
            m_MenuItem10.Index = 4;
            m_MenuItem10.Text = "-";
            _mnuShow0.Checked = true;
            _mnuShow0.Index = 5;
            _mnuShow0.Text = "Always Show Page 0";
            _mnuPlugins.Index = 4;
            _mnuPlugins.MenuItems.AddRange( new MenuItem[1]
            {
        _mnuPluginManager
            } );
            _mnuPlugins.Text = "Plug-Ins";
            _mnuPluginManager.Index = 0;
            _mnuPluginManager.Text = "Manager";
            _mnuHelp.Index = 5;
            _mnuHelp.MenuItems.AddRange( new MenuItem[1]
            {
        _mnuHelpAbout
            } );
            _mnuHelp.Text = "Help";
            _mnuHelpAbout.Index = 0;
            _mnuHelpAbout.Text = "About...";
            _mnuGumplingContext.MenuItems.AddRange( new MenuItem[6]
            {
        _mnuGumplingRename,
        _mnuGumplingMove,
        _mnuGumplingDelete,
        m_MenuItem1,
        _mnuGumplingAddGumpling,
        _mnuGumplingAddFolder
            } );
            _mnuGumplingRename.Index = 0;
            _mnuGumplingRename.Text = "Rename";
            _mnuGumplingMove.Index = 1;
            _mnuGumplingMove.Text = "Move";
            _mnuGumplingDelete.Index = 2;
            _mnuGumplingDelete.Text = "Delete";
            m_MenuItem1.Index = 3;
            m_MenuItem1.Text = "-";
            _mnuGumplingAddGumpling.Index = 4;
            _mnuGumplingAddGumpling.Text = "Add Gumpling";
            _mnuGumplingAddFolder.Index = 5;
            _mnuGumplingAddFolder.Text = "Add Folder";
            AutoScaleBaseSize = new Size( 5, 13 );
            ClientSize = new Size( 904, 545 );
            Controls.Add( _Panel1 );
            Controls.Add( _Splitter1 );
            Controls.Add( _pnlToolboxHolder );
            Controls.Add( _StatusBar );
            KeyPreview = true;
            Menu = m_MainMenu;
            Name = nameof( DesignerForm );
            Text = "Gump Studio (-Unsaved Gump-)";
            _pnlToolboxHolder.ResumeLayout( false );
            _Panel4.ResumeLayout( false );
            _tabToolbox.ResumeLayout( false );
            _tpgStandard.ResumeLayout( false );
            _tpgCustom.ResumeLayout( false );
            _Panel1.ResumeLayout( false );
            _Panel2.ResumeLayout( false );
            _pnlCanvasScroller.ResumeLayout( false );
            _TabPager.ResumeLayout( false );
            _Panel3.ResumeLayout( false );
            _Panel3.PerformLayout();
            ResumeLayout( false );
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
                    ProjectData.SetProjectError( ex );
                    Exception exception = ex;
                    GumpProperties = new GumpProperties();
                    //int num = (int) Interaction.MsgBox( (object) exception.InnerException.Message, MsgBoxStyle.OkOnly, (object) null );
                    MessageBox.Show( exception.InnerException.Message );
                    ProjectData.ClearProjectError();
                }
                SetActiveElement( null, true );
                RefreshElementList();
            }
            catch ( Exception ex )
            {
                ProjectData.SetProjectError( ex );
                ///int num = (int) Interaction.MsgBox( (object) ex.Message, MsgBoxStyle.OkOnly, (object) null );
                MessageBox.Show( ex.Message );
                ProjectData.ClearProjectError();
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
                if ( enumerator is IDisposable )
                    ( enumerator as IDisposable ).Dispose();
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
                if ( enumerator1 is IDisposable )
                    ( enumerator1 as IDisposable ).Dispose();
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
                    if ( enumerator2 is IDisposable )
                        ( enumerator2 as IDisposable ).Dispose();
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
            _OpenDialog.Filter = "Gumpling (*.gumpling)|*.gumpling|Gump (*.gump)|*.gump";
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
                //int num1 = (int) Interaction.MsgBox( (object) "Page 0  can not be deleted.", MsgBoxStyle.OkOnly, (object) null );
                MessageBox.Show( "Page 0 can not be deleted." );

            }
            else
            {
                int selectedIndex = _TabPager.SelectedIndex;
                int num2 = _TabPager.TabCount - 1;
                for ( int index = selectedIndex + 1 ; index <= num2 ; ++index )
                    _TabPager.TabPages[index].Text = Conversions.ToString( index - 1 );
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
                MessageBox.Show( "Page 0 may not be moved." );
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
                IEnumerator enumerator = null;
                SetActiveElement( null, true );
                try
                {
                    foreach ( object obj in data )
                    {
                        BaseElement objectValue = (BaseElement) RuntimeHelpers.GetObjectValue( obj );
                        if ( CopyMode == ClipBoardMode.Copy )
                            objectValue.Name = "Copy of " + objectValue.Name;
                        objectValue.Selected = true;
                        ElementStack.AddElement( objectValue );
                    }
                }
                finally
                {
                    if ( enumerator is IDisposable )
                        ( enumerator as IDisposable ).Dispose();
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
            IEnumerator enumerator1 = null;
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
            try
            {
                foreach ( object loadedPlugin in LoadedPlugins )
                {
                    ( (BasePlugin) RuntimeHelpers.GetObjectValue( loadedPlugin ) ).MouseMoveHook( ref e1 );
                    point1 = e1.MouseLocation;
                }
            }
            finally
            {
                if ( enumerator1 is IDisposable )
                    ( enumerator1 as IDisposable ).Dispose();
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
                            if ( enumerator2 is IDisposable )
                                ( enumerator2 as IDisposable ).Dispose();
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
                IEnumerator enumerator = null;
                BaseElement Element = null;
                try
                {
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
                }
                finally
                {
                    if ( enumerator is IDisposable )
                        ( enumerator as IDisposable ).Dispose();
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
                ContextMenu mnuContextMenu = m_mnuContextMenu;
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
            IEnumerator enumerator = null;
            _TabPager.TabPages.Clear();
            int num = -1;
            try
            {
                foreach ( object stack in Stacks )
                {
                    object objectValue = RuntimeHelpers.GetObjectValue( stack );
                    ++num;
                    _TabPager.TabPages.Add( new TabPage( Conversions.ToString( num ) ) );
                    if ( ElementStack == objectValue )
                        _TabPager.SelectedIndex = num;
                }
            }
            finally
            {
                if ( enumerator is IDisposable )
                    ( enumerator as IDisposable ).Dispose();
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
            IEnumerator enumerator = null;
            Graphics Target1 = Graphics.FromImage( Canvas );
            if ( !PluginClearsCanvas )
                Target1.Clear( Color.Black );
            HookPreRenderEventHandler hookPreRender = HookPreRender;
            if ( hookPreRender != null )
                hookPreRender( Canvas );
            if ( ( !ShowPage0 || ElementStack == Stacks[0] ? 0 : 1 ) != 0 )
                ( (BaseElement) Stacks[0] ).Render( Target1 );
            ElementStack.Render( Target1 );
            try
            {
                foreach ( object element in ElementStack.GetElements() )
                {
                    BaseElement objectValue = (BaseElement) RuntimeHelpers.GetObjectValue( element );
                    if ( ( !objectValue.Selected || objectValue == ActiveElement ? 0 : 1 ) != 0 )
                        objectValue.DrawBoundingBox( Target1, false );
                }
            }
            finally
            {
                if ( enumerator is IDisposable )
                    ( enumerator as IDisposable ).Dispose();
            }
            if ( ActiveElement != null )
                ActiveElement.DrawBoundingBox( Target1, true );
            if ( ShowSelectionRect )
            {
                Target1.FillRectangle( SelBG, SelectionRect );
                Target1.DrawRectangle( SelFG, SelectionRect );
            }
            HookPostRenderEventHandler hookPostRender = HookPostRender;
            if ( hookPostRender != null )
                hookPostRender( Canvas );
            Target1.Dispose();
            Target.DrawImage( Canvas, 0, 0 );
        }

        public void RevertToUndoPoint( int Index )
        {
            IEnumerator enumerator = null;
            UndoPoint undoPoint = (UndoPoint) UndoPoints[Index];
            GumpProperties = (GumpProperties) undoPoint.GumpProperties.Clone();
            Stacks = new ArrayList();
            try
            {
                foreach ( object obj in undoPoint.Stack )
                {
                    GroupElement objectValue = (GroupElement) RuntimeHelpers.GetObjectValue( obj );
                    GroupElement groupElement = (GroupElement) objectValue.Clone();
                    Stacks.Add( groupElement );
                    if ( undoPoint.ElementStack == objectValue )
                        ElementStack = groupElement;
                }
            }
            finally
            {
                if ( enumerator is IDisposable )
                    ( enumerator as IDisposable ).Dispose();
            }
            RebuildTabPages();
            _picCanvas.Invalidate();
            SetActiveElement( null, true );
            CurrentUndoPoint = Index;
        }

        public void SaveTo( string Path )
        {
            _StatusBar.Text = "Saving gump...";
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
            IEnumerator enumerator = null;
            try
            {
                foreach ( object selectedElement in ElementStack.GetSelectedElements() )
                    ( (BaseElement) RuntimeHelpers.GetObjectValue( selectedElement ) ).Selected = true;
            }
            finally
            {
                if ( enumerator is IDisposable )
                    ( enumerator as IDisposable ).Dispose();
            }
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
                IEnumerator enumerator = null;
                try
                {
                    foreach ( object element in ElementStack.GetElements() )
                        ( (BaseElement) RuntimeHelpers.GetObjectValue( element ) ).Selected = false;
                }
                finally
                {
                    if ( enumerator is IDisposable )
                        ( enumerator as IDisposable ).Dispose();
                }
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
