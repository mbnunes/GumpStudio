// Decompiled with JetBrains decompiler
// Type: GumpStudio.DesignerForm
// Assembly: GumpStudioCore, Version=1.8.3024.24259, Culture=neutral, PublicKeyToken=null
// MVID: A77D32E5-7519-4865-AA26-DCCB34429732
// Assembly location: C:\GumpStudio_1_8_R3_quinted-02\GumpStudioCore.dll

using GumpStudio.Elements;
using GumpStudio.My;
using GumpStudio.Plugins;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
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
    private static List<WeakReference> __ENCList = new List<WeakReference>();
    [AccessedThroughProperty("CanvasFocus")]
    private TextBox m_CanvasFocus;
    [AccessedThroughProperty("cboElements")]
    private ComboBox m_cboElements;
    [AccessedThroughProperty("ElementProperties")]
    private PropertyGrid m_ElementProperties;
    [AccessedThroughProperty("Label1")]
    private Label m_Label1;
    [AccessedThroughProperty("MainMenu")]
    private MainMenu m_MainMenu;
    [AccessedThroughProperty("MenuItem1")]
    private MenuItem m_MenuItem1;
    [AccessedThroughProperty("MenuItem10")]
    private MenuItem m_MenuItem10;
    [AccessedThroughProperty("MenuItem3")]
    private MenuItem m_MenuItem3;
    [AccessedThroughProperty("MenuItem4")]
    private MenuItem m_MenuItem4;
    [AccessedThroughProperty("MenuItem5")]
    private MenuItem m_MenuItem5;
    [AccessedThroughProperty("MenuItem9")]
    private MenuItem m_MenuItem9;
    [AccessedThroughProperty("mnuContextMenu")]
    private ContextMenu m_mnuContextMenu;
    [AccessedThroughProperty("mnuCopy")]
    private MenuItem m_mnuCopy;
    [AccessedThroughProperty("mnuCut")]
    private MenuItem _mnuCut;
    [AccessedThroughProperty("mnuDataFile")]
    private MenuItem _mnuDataFile;
    [AccessedThroughProperty("mnuDelete")]
    private MenuItem _mnuDelete;
    [AccessedThroughProperty("mnuEdit")]
    private MenuItem _mnuEdit;
    [AccessedThroughProperty("mnuEditRedo")]
    private MenuItem _mnuEditRedo;
    [AccessedThroughProperty("mnuEditUndo")]
    private MenuItem _mnuEditUndo;
    [AccessedThroughProperty("mnuFile")]
    private MenuItem _mnuFile;
    [AccessedThroughProperty("mnuFileExit")]
    private MenuItem _mnuFileExit;
    [AccessedThroughProperty("mnuFileExport")]
    private MenuItem _mnuFileExport;
    [AccessedThroughProperty("mnuFileImport")]
    private MenuItem _mnuFileImport;
    [AccessedThroughProperty("mnuFileNew")]
    private MenuItem _mnuFileNew;
    [AccessedThroughProperty("mnuFileOpen")]
    private MenuItem _mnuFileOpen;
    [AccessedThroughProperty("mnuFileSave")]
    private MenuItem _mnuFileSave;
    [AccessedThroughProperty("mnuGumplingAddFolder")]
    private MenuItem _mnuGumplingAddFolder;
    [AccessedThroughProperty("mnuGumplingAddGumpling")]
    private MenuItem _mnuGumplingAddGumpling;
    [AccessedThroughProperty("mnuGumplingContext")]
    private ContextMenu _mnuGumplingContext;
    [AccessedThroughProperty("mnuGumplingDelete")]
    private MenuItem _mnuGumplingDelete;
    [AccessedThroughProperty("mnuGumplingMove")]
    private MenuItem _mnuGumplingMove;
    [AccessedThroughProperty("mnuGumplingRename")]
    private MenuItem _mnuGumplingRename;
    [AccessedThroughProperty("mnuHelp")]
    private MenuItem _mnuHelp;
    [AccessedThroughProperty("mnuHelpAbout")]
    private MenuItem _mnuHelpAbout;
    [AccessedThroughProperty("mnuImportGumpling")]
    private MenuItem _mnuImportGumpling;
    [AccessedThroughProperty("mnuMisc")]
    private MenuItem _mnuMisc;
    [AccessedThroughProperty("mnuMiscLoadGumpling")]
    private MenuItem _mnuMiscLoadGumpling;
    [AccessedThroughProperty("mnuPage")]
    private MenuItem _mnuPage;
    [AccessedThroughProperty("mnuPageAdd")]
    private MenuItem _mnuPageAdd;
    [AccessedThroughProperty("mnuPageClear")]
    private MenuItem _mnuPageClear;
    [AccessedThroughProperty("mnuPageDelete")]
    private MenuItem _mnuPageDelete;
    [AccessedThroughProperty("mnuPageInsert")]
    private MenuItem _mnuPageInsert;
    [AccessedThroughProperty("mnuPaste")]
    private MenuItem _mnuPaste;
    [AccessedThroughProperty("mnuPluginManager")]
    private MenuItem _mnuPluginManager;
    [AccessedThroughProperty("mnuPlugins")]
    private MenuItem _mnuPlugins;
    [AccessedThroughProperty("mnuSelectAll")]
    private MenuItem _mnuSelectAll;
    [AccessedThroughProperty("mnuShow0")]
    private MenuItem _mnuShow0;
    [AccessedThroughProperty("OpenDialog")]
    private OpenFileDialog _OpenDialog;
    [AccessedThroughProperty("Panel1")]
    private Panel _Panel1;
    [AccessedThroughProperty("Panel2")]
    private Panel _Panel2;
    [AccessedThroughProperty("Panel3")]
    private Panel _Panel3;
    [AccessedThroughProperty("Panel4")]
    private Panel _Panel4;
    [AccessedThroughProperty("picCanvas")]
    private PictureBox _picCanvas;
    [AccessedThroughProperty("pnlCanvasScroller")]
    private Panel _pnlCanvasScroller;
    [AccessedThroughProperty("pnlToolbox")]
    private Panel _pnlToolbox;
    [AccessedThroughProperty("pnlToolboxHolder")]
    private Panel _pnlToolboxHolder;
    [AccessedThroughProperty("SaveDialog")]
    private SaveFileDialog _SaveDialog;
    [AccessedThroughProperty("Splitter1")]
    private Splitter _Splitter1;
    [AccessedThroughProperty("Splitter2")]
    private Splitter _Splitter2;
    [AccessedThroughProperty("StatusBar")]
    private StatusBar _StatusBar;
    [AccessedThroughProperty("TabPage1")]
    private TabPage _TabPage1;
    [AccessedThroughProperty("TabPager")]
    private TabControl _TabPager;
    [AccessedThroughProperty("tabToolbox")]
    private TabControl _tabToolbox;
    [AccessedThroughProperty("tpgCustom")]
    private TabPage _tpgCustom;
    [AccessedThroughProperty("tpgStandard")]
    private TabPage _tpgStandard;
    [AccessedThroughProperty("treGumplings")]
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
      [DebuggerNonUserCode] get
      {
        return this.m_CanvasFocus;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this.m_CanvasFocus = value;
      }
    }

    internal virtual ComboBox cboElements
    {
      [DebuggerNonUserCode] get
      {
        return this.m_cboElements;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.cboElements_SelectedIndexChanged);
        EventHandler eventHandler2 = new EventHandler(this.cboElements_Click);
        if (this.m_cboElements != null)
        {
          this.m_cboElements.SelectedIndexChanged -= eventHandler1;
          this.m_cboElements.Click -= eventHandler2;
        }
        this.m_cboElements = value;
        if (this.m_cboElements == null)
          return;
        this.m_cboElements.SelectedIndexChanged += eventHandler1;
        this.m_cboElements.Click += eventHandler2;
      }
    }

    public virtual PropertyGrid ElementProperties
    {
      [DebuggerNonUserCode] get
      {
        return this.m_ElementProperties;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        PropertyValueChangedEventHandler changedEventHandler = new PropertyValueChangedEventHandler(this.ElementProperties_PropertyValueChanged);
        if (this.m_ElementProperties != null)
          this.m_ElementProperties.PropertyValueChanged -= changedEventHandler;
        this.m_ElementProperties = value;
        if (this.m_ElementProperties == null)
          return;
        this.m_ElementProperties.PropertyValueChanged += changedEventHandler;
      }
    }

    internal virtual Label Label1
    {
      [DebuggerNonUserCode] get
      {
        return this.m_Label1;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this.m_Label1 = value;
      }
    }

    public virtual MainMenu MainMenu
    {
      [DebuggerNonUserCode] get
      {
        return this.m_MainMenu;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this.m_MainMenu = value;
      }
    }

    internal virtual MenuItem MenuItem1
    {
      [DebuggerNonUserCode] get
      {
        return this.m_MenuItem1;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this.m_MenuItem1 = value;
      }
    }

    internal virtual MenuItem MenuItem10
    {
      [DebuggerNonUserCode] get
      {
        return this.m_MenuItem10;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this.m_MenuItem10 = value;
      }
    }

    internal virtual MenuItem MenuItem3
    {
      [DebuggerNonUserCode] get
      {
        return this.m_MenuItem3;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this.m_MenuItem3 = value;
      }
    }

    internal virtual MenuItem MenuItem4
    {
      [DebuggerNonUserCode] get
      {
        return this.m_MenuItem4;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this.m_MenuItem4 = value;
      }
    }

    internal virtual MenuItem MenuItem5
    {
      [DebuggerNonUserCode] get
      {
        return this.m_MenuItem5;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this.m_MenuItem5 = value;
      }
    }

    internal virtual MenuItem MenuItem9
    {
      [DebuggerNonUserCode] get
      {
        return this.m_MenuItem9;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this.m_MenuItem9 = value;
      }
    }

    public virtual ContextMenu mnuContextMenu
    {
      [DebuggerNonUserCode] get
      {
        return this.m_mnuContextMenu;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this.m_mnuContextMenu = value;
      }
    }

    public virtual MenuItem mnuCopy
    {
      [DebuggerNonUserCode] get
      {
        return this.m_mnuCopy;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuCopy_Click);
        if (this.m_mnuCopy != null)
          this.m_mnuCopy.Click -= eventHandler;
        this.m_mnuCopy = value;
        if (this.m_mnuCopy == null)
          return;
        this.m_mnuCopy.Click += eventHandler;
      }
    }

    public virtual MenuItem mnuCut
    {
      [DebuggerNonUserCode] get
      {
        return this._mnuCut;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuCut_Click);
        if (this._mnuCut != null)
          this._mnuCut.Click -= eventHandler;
        this._mnuCut = value;
        if (this._mnuCut == null)
          return;
        this._mnuCut.Click += eventHandler;
      }
    }

    internal virtual MenuItem mnuDataFile
    {
      [DebuggerNonUserCode] get
      {
        return this._mnuDataFile;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuDataFile_Click);
        if (this._mnuDataFile != null)
          this._mnuDataFile.Click -= eventHandler;
        this._mnuDataFile = value;
        if (this._mnuDataFile == null)
          return;
        this._mnuDataFile.Click += eventHandler;
      }
    }

    internal virtual MenuItem mnuDelete
    {
      [DebuggerNonUserCode] get
      {
        return this._mnuDelete;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuDelete_Click);
        if (this._mnuDelete != null)
          this._mnuDelete.Click -= eventHandler;
        this._mnuDelete = value;
        if (this._mnuDelete == null)
          return;
        this._mnuDelete.Click += eventHandler;
      }
    }

    public virtual MenuItem mnuEdit
    {
      [DebuggerNonUserCode] get
      {
        return this._mnuEdit;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._mnuEdit = value;
      }
    }

    internal virtual MenuItem mnuEditRedo
    {
      [DebuggerNonUserCode] get
      {
        return this._mnuEditRedo;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuEditRedo_Click);
        if (this._mnuEditRedo != null)
          this._mnuEditRedo.Click -= eventHandler;
        this._mnuEditRedo = value;
        if (this._mnuEditRedo == null)
          return;
        this._mnuEditRedo.Click += eventHandler;
      }
    }

    internal virtual MenuItem mnuEditUndo
    {
      [DebuggerNonUserCode] get
      {
        return this._mnuEditUndo;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuEditUndo_Click);
        if (this._mnuEditUndo != null)
          this._mnuEditUndo.Click -= eventHandler;
        this._mnuEditUndo = value;
        if (this._mnuEditUndo == null)
          return;
        this._mnuEditUndo.Click += eventHandler;
      }
    }

    public virtual MenuItem mnuFile
    {
      [DebuggerNonUserCode] get
      {
        return this._mnuFile;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._mnuFile = value;
      }
    }

    public virtual MenuItem mnuFileExit
    {
      [DebuggerNonUserCode] get
      {
        return this._mnuFileExit;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuFileExit_Click);
        if (this._mnuFileExit != null)
          this._mnuFileExit.Click -= eventHandler;
        this._mnuFileExit = value;
        if (this._mnuFileExit == null)
          return;
        this._mnuFileExit.Click += eventHandler;
      }
    }

    public virtual MenuItem mnuFileExport
    {
      [DebuggerNonUserCode] get
      {
        return this._mnuFileExport;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._mnuFileExport = value;
      }
    }

    public virtual MenuItem mnuFileImport
    {
      [DebuggerNonUserCode] get
      {
        return this._mnuFileImport;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._mnuFileImport = value;
      }
    }

    public virtual MenuItem mnuFileNew
    {
      [DebuggerNonUserCode] get
      {
        return this._mnuFileNew;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuFileNew_Click);
        if (this._mnuFileNew != null)
          this._mnuFileNew.Click -= eventHandler;
        this._mnuFileNew = value;
        if (this._mnuFileNew == null)
          return;
        this._mnuFileNew.Click += eventHandler;
      }
    }

    public virtual MenuItem mnuFileOpen
    {
      [DebuggerNonUserCode] get
      {
        return this._mnuFileOpen;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuFileOpen_Click);
        if (this._mnuFileOpen != null)
          this._mnuFileOpen.Click -= eventHandler;
        this._mnuFileOpen = value;
        if (this._mnuFileOpen == null)
          return;
        this._mnuFileOpen.Click += eventHandler;
      }
    }

    public virtual MenuItem mnuFileSave
    {
      [DebuggerNonUserCode] get
      {
        return this._mnuFileSave;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuFileSave_Click);
        if (this._mnuFileSave != null)
          this._mnuFileSave.Click -= eventHandler;
        this._mnuFileSave = value;
        if (this._mnuFileSave == null)
          return;
        this._mnuFileSave.Click += eventHandler;
      }
    }

    internal virtual MenuItem mnuGumplingAddFolder
    {
      [DebuggerNonUserCode] get
      {
        return this._mnuGumplingAddFolder;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._mnuGumplingAddFolder = value;
      }
    }

    internal virtual MenuItem mnuGumplingAddGumpling
    {
      [DebuggerNonUserCode] get
      {
        return this._mnuGumplingAddGumpling;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._mnuGumplingAddGumpling = value;
      }
    }

    internal virtual ContextMenu mnuGumplingContext
    {
      [DebuggerNonUserCode] get
      {
        return this._mnuGumplingContext;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._mnuGumplingContext = value;
      }
    }

    internal virtual MenuItem mnuGumplingDelete
    {
      [DebuggerNonUserCode] get
      {
        return this._mnuGumplingDelete;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._mnuGumplingDelete = value;
      }
    }

    internal virtual MenuItem mnuGumplingMove
    {
      [DebuggerNonUserCode] get
      {
        return this._mnuGumplingMove;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._mnuGumplingMove = value;
      }
    }

    internal virtual MenuItem mnuGumplingRename
    {
      [DebuggerNonUserCode] get
      {
        return this._mnuGumplingRename;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._mnuGumplingRename = value;
      }
    }

    public virtual MenuItem mnuHelp
    {
      [DebuggerNonUserCode] get
      {
        return this._mnuHelp;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._mnuHelp = value;
      }
    }

    public virtual MenuItem mnuHelpAbout
    {
      [DebuggerNonUserCode] get
      {
        return this._mnuHelpAbout;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuHelpAbout_Click);
        if (this._mnuHelpAbout != null)
          this._mnuHelpAbout.Click -= eventHandler;
        this._mnuHelpAbout = value;
        if (this._mnuHelpAbout == null)
          return;
        this._mnuHelpAbout.Click += eventHandler;
      }
    }

    internal virtual MenuItem mnuImportGumpling
    {
      [DebuggerNonUserCode] get
      {
        return this._mnuImportGumpling;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuImportGumpling_Click);
        if (this._mnuImportGumpling != null)
          this._mnuImportGumpling.Click -= eventHandler;
        this._mnuImportGumpling = value;
        if (this._mnuImportGumpling == null)
          return;
        this._mnuImportGumpling.Click += eventHandler;
      }
    }

    public virtual MenuItem mnuMisc
    {
      [DebuggerNonUserCode] get
      {
        return this._mnuMisc;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._mnuMisc = value;
      }
    }

    public virtual MenuItem mnuMiscLoadGumpling
    {
      [DebuggerNonUserCode] get
      {
        return this._mnuMiscLoadGumpling;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.MenuItem2_Click);
        if (this._mnuMiscLoadGumpling != null)
          this._mnuMiscLoadGumpling.Click -= eventHandler;
        this._mnuMiscLoadGumpling = value;
        if (this._mnuMiscLoadGumpling == null)
          return;
        this._mnuMiscLoadGumpling.Click += eventHandler;
      }
    }

    public virtual MenuItem mnuPage
    {
      [DebuggerNonUserCode] get
      {
        return this._mnuPage;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._mnuPage = value;
      }
    }

    public virtual MenuItem mnuPageAdd
    {
      [DebuggerNonUserCode] get
      {
        return this._mnuPageAdd;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuAddPage_Click);
        if (this._mnuPageAdd != null)
          this._mnuPageAdd.Click -= eventHandler;
        this._mnuPageAdd = value;
        if (this._mnuPageAdd == null)
          return;
        this._mnuPageAdd.Click += eventHandler;
      }
    }

    internal virtual MenuItem mnuPageClear
    {
      [DebuggerNonUserCode] get
      {
        return this._mnuPageClear;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuPageClear_Click);
        if (this._mnuPageClear != null)
          this._mnuPageClear.Click -= eventHandler;
        this._mnuPageClear = value;
        if (this._mnuPageClear == null)
          return;
        this._mnuPageClear.Click += eventHandler;
      }
    }

    public virtual MenuItem mnuPageDelete
    {
      [DebuggerNonUserCode] get
      {
        return this._mnuPageDelete;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuPageDelete_Click);
        if (this._mnuPageDelete != null)
          this._mnuPageDelete.Click -= eventHandler;
        this._mnuPageDelete = value;
        if (this._mnuPageDelete == null)
          return;
        this._mnuPageDelete.Click += eventHandler;
      }
    }

    public virtual MenuItem mnuPageInsert
    {
      [DebuggerNonUserCode] get
      {
        return this._mnuPageInsert;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuPageInsert_Click);
        if (this._mnuPageInsert != null)
          this._mnuPageInsert.Click -= eventHandler;
        this._mnuPageInsert = value;
        if (this._mnuPageInsert == null)
          return;
        this._mnuPageInsert.Click += eventHandler;
      }
    }

    public virtual MenuItem mnuPaste
    {
      [DebuggerNonUserCode] get
      {
        return this._mnuPaste;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuPaste_Click);
        if (this._mnuPaste != null)
          this._mnuPaste.Click -= eventHandler;
        this._mnuPaste = value;
        if (this._mnuPaste == null)
          return;
        this._mnuPaste.Click += eventHandler;
      }
    }

    public virtual MenuItem mnuPluginManager
    {
      [DebuggerNonUserCode] get
      {
        return this._mnuPluginManager;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuPluginManager_Click);
        if (this._mnuPluginManager != null)
          this._mnuPluginManager.Click -= eventHandler;
        this._mnuPluginManager = value;
        if (this._mnuPluginManager == null)
          return;
        this._mnuPluginManager.Click += eventHandler;
      }
    }

    public virtual MenuItem mnuPlugins
    {
      [DebuggerNonUserCode] get
      {
        return this._mnuPlugins;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._mnuPlugins = value;
      }
    }

    public virtual MenuItem mnuSelectAll
    {
      [DebuggerNonUserCode] get
      {
        return this._mnuSelectAll;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuSelectAll_Click);
        if (this._mnuSelectAll != null)
          this._mnuSelectAll.Click -= eventHandler;
        this._mnuSelectAll = value;
        if (this._mnuSelectAll == null)
          return;
        this._mnuSelectAll.Click += eventHandler;
      }
    }

    public virtual MenuItem mnuShow0
    {
      [DebuggerNonUserCode] get
      {
        return this._mnuShow0;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuShow0_Click);
        if (this._mnuShow0 != null)
          this._mnuShow0.Click -= eventHandler;
        this._mnuShow0 = value;
        if (this._mnuShow0 == null)
          return;
        this._mnuShow0.Click += eventHandler;
      }
    }

    internal virtual OpenFileDialog OpenDialog
    {
      [DebuggerNonUserCode] get
      {
        return this._OpenDialog;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._OpenDialog = value;
      }
    }

    internal virtual Panel Panel1
    {
      [DebuggerNonUserCode] get
      {
        return this._Panel1;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Panel1 = value;
      }
    }

    internal virtual Panel Panel2
    {
      [DebuggerNonUserCode] get
      {
        return this._Panel2;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Panel2 = value;
      }
    }

    internal virtual Panel Panel3
    {
      [DebuggerNonUserCode] get
      {
        return this._Panel3;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Panel3 = value;
      }
    }

    internal virtual Panel Panel4
    {
      [DebuggerNonUserCode] get
      {
        return this._Panel4;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Panel4 = value;
      }
    }

    public virtual PictureBox picCanvas
    {
      [DebuggerNonUserCode] get
      {
        return this._picCanvas;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler1 = new MouseEventHandler(this.picCanvas_MouseUp);
        MouseEventHandler mouseEventHandler2 = new MouseEventHandler(this.picCanvas_MouseMove);
        PaintEventHandler paintEventHandler = new PaintEventHandler(this.picCanvas_Paint);
        MouseEventHandler mouseEventHandler3 = new MouseEventHandler(this.picCanvas_MouseDown);
        if (this._picCanvas != null)
        {
          this._picCanvas.MouseUp -= mouseEventHandler1;
          this._picCanvas.MouseMove -= mouseEventHandler2;
          this._picCanvas.Paint -= paintEventHandler;
          this._picCanvas.MouseDown -= mouseEventHandler3;
        }
        this._picCanvas = value;
        if (this._picCanvas == null)
          return;
        this._picCanvas.MouseUp += mouseEventHandler1;
        this._picCanvas.MouseMove += mouseEventHandler2;
        this._picCanvas.Paint += paintEventHandler;
        this._picCanvas.MouseDown += mouseEventHandler3;
      }
    }

    internal virtual Panel pnlCanvasScroller
    {
      [DebuggerNonUserCode] get
      {
        return this._pnlCanvasScroller;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.pnlCanvasScroller_MouseLeave);
        if (this._pnlCanvasScroller != null)
          this._pnlCanvasScroller.MouseLeave -= eventHandler;
        this._pnlCanvasScroller = value;
        if (this._pnlCanvasScroller == null)
          return;
        this._pnlCanvasScroller.MouseLeave += eventHandler;
      }
    }

    internal virtual Panel pnlToolbox
    {
      [DebuggerNonUserCode] get
      {
        return this._pnlToolbox;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._pnlToolbox = value;
      }
    }

    internal virtual Panel pnlToolboxHolder
    {
      [DebuggerNonUserCode] get
      {
        return this._pnlToolboxHolder;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._pnlToolboxHolder = value;
      }
    }

    internal virtual SaveFileDialog SaveDialog
    {
      [DebuggerNonUserCode] get
      {
        return this._SaveDialog;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._SaveDialog = value;
      }
    }

    internal virtual Splitter Splitter1
    {
      [DebuggerNonUserCode] get
      {
        return this._Splitter1;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Splitter1 = value;
      }
    }

    internal virtual Splitter Splitter2
    {
      [DebuggerNonUserCode] get
      {
        return this._Splitter2;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Splitter2 = value;
      }
    }

    public virtual StatusBar StatusBar
    {
      [DebuggerNonUserCode] get
      {
        return this._StatusBar;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._StatusBar = value;
      }
    }

    internal virtual TabPage TabPage1
    {
      [DebuggerNonUserCode] get
      {
        return this._TabPage1;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._TabPage1 = value;
      }
    }

    internal virtual TabControl TabPager
    {
      [DebuggerNonUserCode] get
      {
        return this._TabPager;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.TabPager_SelectedIndexChanged);
        if (this._TabPager != null)
          this._TabPager.SelectedIndexChanged -= eventHandler;
        this._TabPager = value;
        if (this._TabPager == null)
          return;
        this._TabPager.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual TabControl tabToolbox
    {
      [DebuggerNonUserCode] get
      {
        return this._tabToolbox;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._tabToolbox = value;
      }
    }

    internal virtual TabPage tpgCustom
    {
      [DebuggerNonUserCode] get
      {
        return this._tpgCustom;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._tpgCustom = value;
      }
    }

    internal virtual TabPage tpgStandard
    {
      [DebuggerNonUserCode] get
      {
        return this._tpgStandard;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._tpgStandard = value;
      }
    }

    internal virtual TreeView treGumplings
    {
      [DebuggerNonUserCode] get
      {
        return this._treGumplings;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.treGumplings_MouseUp);
        EventHandler eventHandler = new EventHandler(this.treGumplings_DoubleClick);
        if (this._treGumplings != null)
        {
          this._treGumplings.MouseUp -= mouseEventHandler;
          this._treGumplings.DoubleClick -= eventHandler;
        }
        this._treGumplings = value;
        if (this._treGumplings == null)
          return;
        this._treGumplings.MouseUp += mouseEventHandler;
        this._treGumplings.DoubleClick += eventHandler;
      }
    }

    public event DesignerForm.HookKeyDownEventHandler HookKeyDown;

    public event DesignerForm.HookPostRenderEventHandler HookPostRender;

    public event DesignerForm.HookPreRenderEventHandler HookPreRender;

    public DesignerForm()
    {
      this.Closed += new EventHandler(this.DesignerForm_Closed);
      this.Closing += new CancelEventHandler(this.DesignerForm_Closing);
      this.KeyUp += new KeyEventHandler(this.DesignerForm_KeyUp);
      this.Load += new EventHandler(this.DesignerForm_Load);
      this.FormClosing += new FormClosingEventHandler(this.DesignerForm_FormClosing);
      this.KeyDown += new KeyEventHandler(this.DesignerForm_KeyDown);
      lock (DesignerForm.__ENCList)
        DesignerForm.__ENCList.Add(new WeakReference((object) this));
      this.ElementStack = new GroupElement((GroupElement) null, (ArrayList) null, "CanvasStack", true);
      this.Stacks = new ArrayList();
      this.ShouldClearActiveElement = false;
      this.PluginClearsCanvas = false;
      this.AppPath = Application.StartupPath;
      this.ArrowKeyDelta = new Decimal(1);
      this.ShowSelectionRect = false;
      this.MoveMode = MoveModeType.None;
      this.ShowGrid = false;
      this.ShowPage0 = true;
      this.ElementChanged = false;
      this.UndoPoints = new ArrayList();
      this.CurrentUndoPoint = -1;
      this.MaxUndoPoints = 25;
      this.SuppressUndoPoints = false;
      this.RegisteredTypes = new ArrayList();
      this.AvailablePlugins = new ArrayList();
      this.LoadedPlugins = new ArrayList();
      this.InitializeComponent();
    }

    public void AddElement(BaseElement Element)
    {
      this.ElementStack.AddElement(Element);
      Element.Selected = true;
      this.SetActiveElement(Element, true);
      this._picCanvas.Invalidate();
      this.CreateUndoPoint(Element.Name + " added");
    }

    public int AddPage()
    {
      this.Stacks.Add((object) new GroupElement((GroupElement) null, (ArrayList) null, "CanvasStack", true));
      this._TabPager.TabPages.Add(new TabPage(Conversions.ToString(this.Stacks.Count - 1)));
      this._TabPager.SelectedIndex = this.Stacks.Count - 1;
      this.ChangeActiveStack(this.Stacks.Count - 1);
      return this.Stacks.Count - 1;
    }

    public void BuildGumplingTree()
    {
      this._treGumplings.Nodes.Clear();
      this.BuildGumplingTree(this.GumplingTree, (TreeNode) null);
    }

    public void BuildGumplingTree(TreeFolder Item, TreeNode Node)
    {
      IEnumerator enumerator = (IEnumerator) null;
      try
      {
        foreach (object child in Item.GetChildren())
        {
          TreeItem objectValue = (TreeItem) RuntimeHelpers.GetObjectValue(child);
          TreeNode treeNode = new TreeNode();
          treeNode.Text = objectValue.Text;
          treeNode.Tag = (object) objectValue;
          if (Node == null)
            this._treGumplings.Nodes.Add(treeNode);
          else
            Node.Nodes.Add(treeNode);
          if (objectValue is TreeFolder)
            this.BuildGumplingTree((TreeFolder) objectValue, treeNode);
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    protected void BuildToolbox()
    {
      IEnumerator enumerator1 = (IEnumerator) null;
      this._pnlToolbox.Controls.Clear();
      try
      {
        enumerator1 = this.RegisteredTypes.GetEnumerator();
        int y = 0;
        while (enumerator1.MoveNext())
        {
          IEnumerator enumerator2 = (IEnumerator) null;
          System.Type objectValue = (System.Type) RuntimeHelpers.GetObjectValue(enumerator1.Current);
          BaseElement instance = (BaseElement) Activator.CreateInstance(objectValue);
          Button button = new Button();
          button.Text = instance.Type;
          Point point = new Point(0, y);
          button.Location = point;
          button.FlatStyle = FlatStyle.System;
          button.Width = this._pnlToolbox.Width;
          button.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
          button.Tag = (object) objectValue;
          y += button.Height - 1;
          this._pnlToolbox.Controls.Add((Control) button);
          button.Click += new EventHandler(this.CreateElementFromToolbox);
          if (instance.DispayInAbout())
            this.AboutElementAppend = this.AboutElementAppend + "\r\n\r\n" + instance.Type + ": " + instance.GetAboutText();
          try
          {
            foreach (object loadedPlugin in this.LoadedPlugins)
              ((BasePlugin) RuntimeHelpers.GetObjectValue(loadedPlugin)).InitializeElementExtenders(instance);
          }
          finally
          {
            if (enumerator2 is IDisposable)
              (enumerator2 as IDisposable).Dispose();
          }
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("HOHO\n" + ex.Message + "\n" + ex.StackTrace);
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
      BaseElement.ResetID();
      this.GumplingTree = new TreeFolder("Root");
      this.GumplingsFolder = new TreeFolder("My Gumplings");
      this.UncategorizedFolder = new TreeFolder("Uncategorized");
      this.GumplingTree.AddItem((TreeItem) this.GumplingsFolder);
      this.GumplingTree.AddItem((TreeItem) this.UncategorizedFolder);
      this.BuildGumplingTree();
    }

    private void cboElements_Click(object sender, EventArgs e)
    {
      IEnumerator enumerator = (IEnumerator) null;
      try
      {
        foreach (object element in this.ElementStack.GetElements())
          ((BaseElement) RuntimeHelpers.GetObjectValue(element)).Selected = false;
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.ActiveElement = (BaseElement) null;
    }

    private void cboElements_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.SetActiveElement((BaseElement) this.m_cboElements.SelectedItem, false);
      this._picCanvas.Invalidate();
    }

    protected void ChangeActiveElementEventHandler(BaseElement e, bool DeselectOthers)
    {
      this.SetActiveElement(e, DeselectOthers);
      this._picCanvas.Invalidate();
    }

    public void ChangeActiveStack(int StackID)
    {
      if (StackID > this.Stacks.Count - 1)
        return;
      this.SetActiveElement((BaseElement) null, true);
      if (this.ElementStack != null)
      {
        this.ElementStack.UpdateParent -= new BaseElement.UpdateParentEventHandler(this.ChangeActiveElementEventHandler);
        this.ElementStack.Repaint -= new BaseElement.RepaintEventHandler(this.RefreshView);
      }
      this.ElementStack = (GroupElement) this.Stacks[StackID];
      this.ElementStack.UpdateParent += new BaseElement.UpdateParentEventHandler(this.ChangeActiveElementEventHandler);
      this.ElementStack.Repaint += new BaseElement.RepaintEventHandler(this.RefreshView);
      this._picCanvas.Invalidate();
    }

    public void ClearContextMenu(Menu Menu)
    {
      int num = Menu.MenuItems.Count - 1;
      for (int index = 0; index <= num; ++index)
      {
        MenuItem menuItem = Menu.MenuItems[0];
        Menu.MenuItems.RemoveAt(0);
      }
    }

    public void ClearGump()
    {
      this._TabPager.TabPages.Clear();
      this._TabPager.TabPages.Add(new TabPage("0"));
      this.Stacks.Clear();
      BaseElement.ResetID();
      this.ElementStack = new GroupElement((GroupElement) null, (ArrayList) null, "Element Stack", true);
      this.Stacks.Add((object) this.ElementStack);
      this.GumpProperties = new GumpProperties();
      this.ElementStack.UpdateParent += new BaseElement.UpdateParentEventHandler(this.ChangeActiveElementEventHandler);
      this.ElementStack.Repaint += new BaseElement.RepaintEventHandler(this.RefreshView);
      this.SetActiveElement((BaseElement) null);
      this._picCanvas.Invalidate();
      this.FileName = "";
      this.Text = "Gump Studio (-Unsaved Gump-)";
      this.ChangeActiveStack(0);
      this.UndoPoints = new ArrayList();
      this.CreateUndoPoint("Blank");
      this._mnuEditUndo.Enabled = false;
      this._mnuEditRedo.Enabled = false;
    }

    public void Copy()
    {
      IEnumerator enumerator = (IEnumerator) null;
      ArrayList arrayList = new ArrayList();
      try
      {
        foreach (object selectedElement in this.ElementStack.GetSelectedElements())
          arrayList.Add((object) ((BaseElement) RuntimeHelpers.GetObjectValue(selectedElement)).Clone());
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      Clipboard.SetDataObject((object) arrayList);
      this.CopyMode = ClipBoardMode.Copy;
    }

    public void CreateElementFromToolbox(object sender, EventArgs e)
    {
      this.AddElement((BaseElement) Activator.CreateInstance((System.Type) ((Control) sender).Tag));
      this._picCanvas.Invalidate();
      this._picCanvas.Focus();
    }

    public void CreateUndoPoint()
    {
      this.CreateUndoPoint("Unknown Action");
    }

    public void CreateUndoPoint(string Action)
    {
      if (this.SuppressUndoPoints)
        return;
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();
      while (this.CurrentUndoPoint < this.UndoPoints.Count - 1)
      {
        UndoPoint undoPoint = (UndoPoint) this.UndoPoints[this.CurrentUndoPoint + 1];
        this.UndoPoints.RemoveAt(this.CurrentUndoPoint + 1);
      }
      UndoPoint undoPoint1 = new UndoPoint(this);
      undoPoint1.Text = Action;
      if (this.UndoPoints.Count > this.MaxUndoPoints)
        this.UndoPoints.RemoveAt(0);
      this.UndoPoints.Add((object) undoPoint1);
      this.CurrentUndoPoint = this.UndoPoints.Count - 1;
      this._mnuEditUndo.Enabled = true;
      this._mnuEditRedo.Enabled = false;
      stopwatch.Stop();
    }

    public void Cut()
    {
      IEnumerator enumerator = (IEnumerator) null;
      ArrayList arrayList = new ArrayList();
      try
      {
        foreach (object selectedElement in this.ElementStack.GetSelectedElements())
        {
          BaseElement objectValue = (BaseElement) RuntimeHelpers.GetObjectValue(selectedElement);
          arrayList.Add((object) objectValue);
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      Clipboard.SetDataObject((object) arrayList);
      this.DeleteSelectedElements();
      this.CopyMode = ClipBoardMode.Cut;
    }

    protected void DeleteSelectedElements()
    {
      IEnumerator enumerator = (IEnumerator) null;
      ArrayList arrayList = new ArrayList();
      arrayList.AddRange((ICollection) this.ElementStack.GetElements());
      bool flag = false;
      try
      {
        foreach (object obj in arrayList)
        {
          object objectValue = RuntimeHelpers.GetObjectValue(obj);
          flag = true;
          BaseElement e = (BaseElement) objectValue;
          if (e.Selected)
            this.ElementStack.RemoveElement(e);
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.SetActiveElement(this.GetLastSelectedControl());
      this._picCanvas.Invalidate();
      if (!flag)
        return;
      this.CreateUndoPoint("Delete Elements");
    }

    private void DesignerForm_Closed(object sender, EventArgs e)
    {
      if (this.SelFG != null)
        this.SelFG.Dispose();
      if (this.SelBG != null)
        this.SelBG.Dispose();
      this.WritePluginsToLoad();
    }

    private void DesignerForm_Closing(object sender, CancelEventArgs e)
    {
      IEnumerator enumerator = (IEnumerator) null;
      try
      {
        foreach (object availablePlugin in this.AvailablePlugins)
        {
          BasePlugin objectValue = (BasePlugin) RuntimeHelpers.GetObjectValue(availablePlugin);
          if (objectValue.IsLoaded)
            objectValue.Unload();
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private void DesignerForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      MySettings.Default.DesignerFormSize = this.WindowState != FormWindowState.Normal ? this.RestoreBounds.Size : this.Size;
      MySettings.Default.Save();
    }

    private void DesignerForm_KeyDown(object sender, KeyEventArgs e)
    {
      DesignerForm.HookKeyDownEventHandler hookKeyDown = this.HookKeyDown;
      if (hookKeyDown != null)
        hookKeyDown((object) this.ActiveControl, ref e);
      if (e.Handled || this.ActiveControl != this.CanvasFocus)
        return;
      bool flag = false;
      if ((e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back ? 1 : 0) != 0)
      {
        this.DeleteSelectedElements();
        e.Handled = true;
        flag = true;
      }
      else if (e.KeyCode == Keys.Up)
      {
        IEnumerator enumerator = (IEnumerator) null;
        try
        {
          foreach (object selectedElement in this.ElementStack.GetSelectedElements())
          {
            BaseElement objectValue = (BaseElement) RuntimeHelpers.GetObjectValue(selectedElement);
            Point location = objectValue.Location;
            location.Offset(0, -Convert.ToInt32(this.ArrowKeyDelta));
            objectValue.Location = location;
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        this.ArrowKeyDelta = Decimal.Multiply(this.ArrowKeyDelta, new Decimal(106, 0, 0, false, (byte) 2));
        flag = true;
      }
      else if (e.KeyCode == Keys.Down)
      {
        IEnumerator enumerator = (IEnumerator) null;
        try
        {
          foreach (object selectedElement in this.ElementStack.GetSelectedElements())
          {
            BaseElement objectValue = (BaseElement) RuntimeHelpers.GetObjectValue(selectedElement);
            Point location = objectValue.Location;
            location.Offset(0, Convert.ToInt32(this.ArrowKeyDelta));
            objectValue.Location = location;
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        this.ArrowKeyDelta = Decimal.Multiply(this.ArrowKeyDelta, new Decimal(106, 0, 0, false, (byte) 2));
        flag = true;
      }
      else if (e.KeyCode == Keys.Left)
      {
        IEnumerator enumerator = (IEnumerator) null;
        try
        {
          foreach (object selectedElement in this.ElementStack.GetSelectedElements())
          {
            BaseElement objectValue = (BaseElement) RuntimeHelpers.GetObjectValue(selectedElement);
            Point location = objectValue.Location;
            location.Offset(-Convert.ToInt32(this.ArrowKeyDelta), 0);
            objectValue.Location = location;
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        this.ArrowKeyDelta = Decimal.Multiply(this.ArrowKeyDelta, new Decimal(106, 0, 0, false, (byte) 2));
        flag = true;
      }
      else if (e.KeyCode == Keys.Right)
      {
        IEnumerator enumerator = (IEnumerator) null;
        try
        {
          foreach (object selectedElement in this.ElementStack.GetSelectedElements())
          {
            BaseElement objectValue = (BaseElement) RuntimeHelpers.GetObjectValue(selectedElement);
            Point location = objectValue.Location;
            location.Offset(Convert.ToInt32(this.ArrowKeyDelta), 0);
            objectValue.Location = location;
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        this.ArrowKeyDelta = Decimal.Multiply(this.ArrowKeyDelta, new Decimal(106, 0, 0, false, (byte) 2));
        flag = true;
      }
      else if (e.KeyCode == Keys.Next)
      {
        int index = (this.ActiveElement == null ? this.ElementStack.GetElements().Count - 1 : this.ActiveElement.Z) - 1;
        if (index < 0)
          index = this.ElementStack.GetElements().Count - 1;
        if (index >= 0 & index <= this.ElementStack.GetElements().Count - 1)
          this.SetActiveElement((BaseElement) this.ElementStack.GetElements()[index], true);
      }
      else if (e.KeyCode == Keys.Prior)
      {
        int index = (this.ActiveElement == null ? this.ElementStack.GetElements().Count - 1 : this.ActiveElement.Z) + 1;
        if (index > this.ElementStack.GetElements().Count - 1)
          index = 0;
        this.SetActiveElement((BaseElement) this.ElementStack.GetElements()[index], true);
      }
      if (Decimal.Compare(this.ArrowKeyDelta, new Decimal(10)) > 0)
        this.ArrowKeyDelta = new Decimal(10);
      if (!flag)
        return;
      this._picCanvas.Invalidate();
      this.m_ElementProperties.SelectedObjects = this.m_ElementProperties.SelectedObjects;
    }

    private void DesignerForm_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Up && e.KeyCode != Keys.Down)
      {
        int keyCode = (int) e.KeyCode;
      }
      if ((e.KeyCode == Keys.Right ? 1 : 0) == 0)
        return;
      this.CreateUndoPoint("Move element");
      this.ArrowKeyDelta = new Decimal(1);
    }

    private void DesignerForm_Load(object sender, EventArgs e)
    {
      if (MySettings.Default.ClientPath == "")
        MySettings.Default.Upgrade();
      if (!File.Exists(Path.Combine(MySettings.Default.ClientPath, "art.mul")))
      {
        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        folderBrowserDialog.SelectedPath = MyProject.Computer.FileSystem.SpecialDirectories.ProgramFiles;
        folderBrowserDialog.Description = "Select the folder that contains the UO data (.mul) files you want to use.";
        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        {
          if (File.Exists(Path.Combine(folderBrowserDialog.SelectedPath, "art.mul")))
          {
            MySettings.Default.ClientPath = folderBrowserDialog.SelectedPath;
            MySettings.Default.Save();
          }
          else
          {
            int num = (int) Interaction.MsgBox((object) "This path does not contain a file named \"art.mul\", it is most likely not the correct path. Gump Studio can not run without valid client data files.", MsgBoxStyle.OkOnly, (object) "Data Files");
            this.Close();
            return;
          }
        }
        else
        {
          this.Close();
          return;
        }
      }
      Client.Directories.Add(MySettings.Default.ClientPath);
      this.Size = MySettings.Default.DesignerFormSize;
      this.MaxUndoPoints = MySettings.Default.UndoLevels;
      this._picCanvas.Width = 1600;
      this._picCanvas.Height = 1200;
      this.CenterToScreen();
      frmSplash.DisplaySplash();
      this.EnumeratePlugins();
      this.Canvas = new Bitmap(this._picCanvas.Width, this._picCanvas.Height, PixelFormat.Format32bppRgb);
      this.Activate();
      this.GumpProperties = new GumpProperties();
      this.ElementStack.UpdateParent += new BaseElement.UpdateParentEventHandler(this.ChangeActiveElementEventHandler);
      this.ElementStack.Repaint += new BaseElement.RepaintEventHandler(this.RefreshView);
      this.Stacks.Clear();
      this.Stacks.Add((object) this.ElementStack);
      this.ChangeActiveStack(0);
      this.RegisteredTypes.Clear();
      this.RegisteredTypes.Add((object) typeof (LabelElement));
      this.RegisteredTypes.Add((object) typeof (ImageElement));
      this.RegisteredTypes.Add((object) typeof (TiledElement));
      this.RegisteredTypes.Add((object) typeof (BackgroundElement));
      this.RegisteredTypes.Add((object) typeof (AlphaElement));
      this.RegisteredTypes.Add((object) typeof (CheckboxElement));
      this.RegisteredTypes.Add((object) typeof (RadioElement));
      this.RegisteredTypes.Add((object) typeof (ItemElement));
      this.RegisteredTypes.Add((object) typeof (TextEntryElement));
      this.RegisteredTypes.Add((object) typeof (ButtonElement));
      this.RegisteredTypes.Add((object) typeof (HTMLElement));
      this.BuildToolbox();
      this.SelFG = new Pen(Color.Blue, 2f);
      this.SelBG = new LinearGradientBrush(new Rectangle(0, 0, 50, 50), Color.FromArgb(90, Color.Blue), Color.FromArgb(110, Color.Blue), LinearGradientMode.ForwardDiagonal);
      this.SelBG.WrapMode = WrapMode.TileFlipXY;
      this.CreateUndoPoint("Blank");
      this._mnuEditUndo.Enabled = false;
    }

    protected void DrawBoundingBox(Graphics Target, BaseElement Element)
    {
      Rectangle bounds = Element.Bounds;
      Target.DrawRectangle(Pens.Red, bounds);
      bounds.Offset(1, 1);
      Target.DrawRectangle(Pens.Black, bounds);
    }

    private void ElementProperties_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
    {
      if (e.ChangedItem.PropertyDescriptor.Name == "Name")
      {
        this.m_cboElements.Items.Clear();
        this.m_cboElements.Items.AddRange(this.ElementStack.GetElements().ToArray());
        this.m_cboElements.SelectedItem = RuntimeHelpers.GetObjectValue(this.m_ElementProperties.SelectedObject);
      }
      this._picCanvas.Invalidate();
      this.CreateUndoPoint("Property Changed");
    }

    protected void EnumeratePlugins()
    {
      if (!Directory.Exists(Application.StartupPath + "\\Plugins"))
        Directory.CreateDirectory(Application.StartupPath + "\\Plugins");
      this.PluginTypesToLoad = this.GetPluginsToLoad();
      foreach (string file in Directory.GetFiles(Application.StartupPath + "\\Plugins", "*.dll"))
      {
        foreach (System.Type type in Assembly.LoadFile(file).GetTypes())
        {
          try
          {
            if (type.IsSubclassOf(typeof (BasePlugin)) & !type.IsAbstract)
            {
              BasePlugin instance = (BasePlugin) Activator.CreateInstance(type);
              PluginInfo pluginInfo = instance.GetPluginInfo();
              this.AboutElementAppend = this.AboutElementAppend + "\r\n" + pluginInfo.PluginName + ": " + pluginInfo.Description + "\r\nAuthor: " + pluginInfo.AuthorName + "  (" + pluginInfo.AuthorEmail + ")\r\nVersion: " + pluginInfo.Version + "\r\n";
              this.AvailablePlugins.Add((object) instance);
            }
            if (type.IsSubclassOf(typeof (BaseElement)))
              this.RegisteredTypes.Add((object) type);
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            Exception exception = ex;
            int num = (int) Interaction.MsgBox((object) ("Error loading plugin: " + type.Name + "(" + file + ")\r\n\r\n" + exception.Message), MsgBoxStyle.OkOnly, (object) null);
            ProjectData.ClearProjectError();
          }
        }
      }
      if (this.PluginTypesToLoad == null)
        return;
      foreach (PluginInfo pluginInfo1 in this.PluginTypesToLoad)
      {
        IEnumerator enumerator = (IEnumerator) null;
        try
        {
          foreach (object availablePlugin in this.AvailablePlugins)
          {
            BasePlugin objectValue = (BasePlugin) RuntimeHelpers.GetObjectValue(availablePlugin);
            PluginInfo pluginInfo2 = objectValue.GetPluginInfo();
            if (pluginInfo1.Equals(pluginInfo2))
            {
              objectValue.Load(this);
              this.LoadedPlugins.Add((object) objectValue);
            }
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
      }
    }

    protected void GetContextMenu(ref BaseElement Element, ContextMenu Menu)
    {
      MenuItem GroupMenu = new MenuItem("Grouping");
      MenuItem PositionMenu = new MenuItem("Positioning");
      MenuItem OrderMenu = new MenuItem("Order");
      MenuItem MiscMenu = new MenuItem("Misc");
      MenuItem menuItem = new MenuItem("Edit");
      menuItem.MenuItems.Add(new MenuItem("Cut", new EventHandler(this.mnuCut_Click)));
      menuItem.MenuItems.Add(new MenuItem("Copy", new EventHandler(this.mnuCopy_Click)));
      menuItem.MenuItems.Add(new MenuItem("Paste", new EventHandler(this.mnuPaste_Click)));
      menuItem.MenuItems.Add(new MenuItem("Delete", new EventHandler(this.mnuDelete_Click)));
      Menu.MenuItems.Add(menuItem);
      Menu.MenuItems.Add(new MenuItem("-"));
      Menu.MenuItems.Add(GroupMenu);
      Menu.MenuItems.Add(PositionMenu);
      Menu.MenuItems.Add(OrderMenu);
      Menu.MenuItems.Add(new MenuItem("-"));
      Menu.MenuItems.Add(MiscMenu);
      if (this.ElementStack.GetSelectedElements().Count >= 2)
        GroupMenu.MenuItems.Add(new MenuItem("Create Group", new EventHandler(this.mnuGroupCreate_Click)));
      if (Element != null)
        Element.AddContextMenus(ref GroupMenu, ref PositionMenu, ref OrderMenu, ref MiscMenu);
      if (GroupMenu.MenuItems.Count == 0)
        GroupMenu.Enabled = false;
      if (PositionMenu.MenuItems.Count == 0)
        PositionMenu.Enabled = false;
      if (OrderMenu.MenuItems.Count == 0)
        OrderMenu.Enabled = false;
      if (MiscMenu.MenuItems.Count != 0)
        return;
      MiscMenu.Enabled = false;
    }

    public BaseElement GetLastSelectedControl()
    {
      BaseElement baseElement = (BaseElement) null;
      IEnumerator enumerator = (IEnumerator) null;
      try
      {
        foreach (object element in this.ElementStack.GetElements())
          baseElement = (BaseElement) RuntimeHelpers.GetObjectValue(element);
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      return baseElement;
    }

    protected PluginInfo[] GetPluginsToLoad()
    {
      PluginInfo[] pluginInfoArray = (PluginInfo[]) null;
      if (File.Exists(Application.StartupPath + "\\Plugins\\LoadInfo"))
      {
        FileStream fileStream = new FileStream(Application.StartupPath + "\\Plugins\\LoadInfo", FileMode.Open);
        pluginInfoArray = (PluginInfo[]) new BinaryFormatter().Deserialize((Stream) fileStream);
        fileStream.Close();
      }
      return pluginInfoArray;
    }

    protected Rectangle GetPositiveRect(Rectangle Rect)
    {
      if (Rect.Height < 0)
      {
        Rect.Height = Math.Abs(Rect.Height);
        Rect.Y -= Rect.Height;
      }
      if (Rect.Width < 0)
      {
        Rect.Width = Math.Abs(Rect.Width);
        Rect.X -= Rect.Width;
      }
      return Rect;
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
      this.components = (IContainer) new System.ComponentModel.Container();
      this.pnlToolboxHolder = new Panel();
      this.Panel4 = new Panel();
      this.tabToolbox = new TabControl();
      this.tpgStandard = new TabPage();
      this.pnlToolbox = new Panel();
      this.tpgCustom = new TabPage();
      this.treGumplings = new TreeView();
      this.Label1 = new Label();
      this.StatusBar = new StatusBar();
      this.Splitter1 = new Splitter();
      this.Panel1 = new Panel();
      this.Panel2 = new Panel();
      this.pnlCanvasScroller = new Panel();
      this.picCanvas = new PictureBox();
      this.TabPager = new TabControl();
      this.TabPage1 = new TabPage();
      this.Splitter2 = new Splitter();
      this.Panel3 = new Panel();
      this.cboElements = new ComboBox();
      this.ElementProperties = new PropertyGrid();
      this.CanvasFocus = new TextBox();
      this.OpenDialog = new OpenFileDialog();
      this.SaveDialog = new SaveFileDialog();
      this.mnuContextMenu = new ContextMenu();
      this.MainMenu = new MainMenu(this.components);
      this.mnuFile = new MenuItem();
      this.mnuFileNew = new MenuItem();
      this.MenuItem9 = new MenuItem();
      this.mnuFileOpen = new MenuItem();
      this.mnuFileSave = new MenuItem();
      this.mnuFileImport = new MenuItem();
      this.mnuFileExport = new MenuItem();
      this.MenuItem5 = new MenuItem();
      this.mnuFileExit = new MenuItem();
      this.mnuEdit = new MenuItem();
      this.mnuEditUndo = new MenuItem();
      this.mnuEditRedo = new MenuItem();
      this.MenuItem3 = new MenuItem();
      this.mnuCut = new MenuItem();
      this.mnuCopy = new MenuItem();
      this.mnuPaste = new MenuItem();
      this.mnuDelete = new MenuItem();
      this.MenuItem4 = new MenuItem();
      this.mnuSelectAll = new MenuItem();
      this.mnuMisc = new MenuItem();
      this.mnuMiscLoadGumpling = new MenuItem();
      this.mnuImportGumpling = new MenuItem();
      this.mnuDataFile = new MenuItem();
      this.mnuPage = new MenuItem();
      this.mnuPageAdd = new MenuItem();
      this.mnuPageInsert = new MenuItem();
      this.mnuPageDelete = new MenuItem();
      this.mnuPageClear = new MenuItem();
      this.MenuItem10 = new MenuItem();
      this.mnuShow0 = new MenuItem();
      this.mnuPlugins = new MenuItem();
      this.mnuPluginManager = new MenuItem();
      this.mnuHelp = new MenuItem();
      this.mnuHelpAbout = new MenuItem();
      this.mnuGumplingContext = new ContextMenu();
      this.mnuGumplingRename = new MenuItem();
      this.mnuGumplingMove = new MenuItem();
      this.mnuGumplingDelete = new MenuItem();
      this.MenuItem1 = new MenuItem();
      this.mnuGumplingAddGumpling = new MenuItem();
      this.mnuGumplingAddFolder = new MenuItem();
      this._pnlToolboxHolder.SuspendLayout();
      this._Panel4.SuspendLayout();
      this._tabToolbox.SuspendLayout();
      this._tpgStandard.SuspendLayout();
      this._tpgCustom.SuspendLayout();
      this._Panel1.SuspendLayout();
      this._Panel2.SuspendLayout();
      this._pnlCanvasScroller.SuspendLayout();
      this._TabPager.SuspendLayout();
      this._Panel3.SuspendLayout();
      this.SuspendLayout();
      this._pnlToolboxHolder.BorderStyle = BorderStyle.Fixed3D;
      this._pnlToolboxHolder.Controls.Add((Control) this._Panel4);
      this._pnlToolboxHolder.Controls.Add((Control) this.m_Label1);
      this._pnlToolboxHolder.Dock = DockStyle.Left;
      this._pnlToolboxHolder.Location = new Point(0, 0);
      this._pnlToolboxHolder.Name = "_pnlToolboxHolder";
      this._pnlToolboxHolder.Size = new Size(128, 523);
      this._pnlToolboxHolder.TabIndex = 0;
      this._Panel4.Controls.Add((Control) this._tabToolbox);
      this._Panel4.Dock = DockStyle.Fill;
      this._Panel4.Location = new Point(0, 16);
      this._Panel4.Name = "_Panel4";
      this._Panel4.Size = new Size(124, 503);
      this._Panel4.TabIndex = 1;
      this._tabToolbox.Controls.Add((Control) this._tpgStandard);
      this._tabToolbox.Controls.Add((Control) this._tpgCustom);
      this._tabToolbox.Dock = DockStyle.Fill;
      this._tabToolbox.Location = new Point(0, 0);
      this._tabToolbox.Multiline = true;
      this._tabToolbox.Name = "_tabToolbox";
      this._tabToolbox.SelectedIndex = 0;
      this._tabToolbox.Size = new Size(124, 503);
      this._tabToolbox.TabIndex = 1;
      this._tpgStandard.Controls.Add((Control) this._pnlToolbox);
      this._tpgStandard.Location = new Point(4, 22);
      this._tpgStandard.Name = "_tpgStandard";
      this._tpgStandard.Size = new Size(116, 477);
      this._tpgStandard.TabIndex = 0;
      this._tpgStandard.Text = "Standard";
      this._pnlToolbox.AutoScroll = true;
      this._pnlToolbox.Dock = DockStyle.Fill;
      this._pnlToolbox.Location = new Point(0, 0);
      this._pnlToolbox.Name = "_pnlToolbox";
      this._pnlToolbox.Size = new Size(116, 477);
      this._pnlToolbox.TabIndex = 1;
      this._tpgCustom.Controls.Add((Control) this._treGumplings);
      this._tpgCustom.Location = new Point(4, 22);
      this._tpgCustom.Name = "_tpgCustom";
      this._tpgCustom.Size = new Size(116, 477);
      this._tpgCustom.TabIndex = 1;
      this._tpgCustom.Text = "Gumplings";
      this._treGumplings.Dock = DockStyle.Fill;
      this._treGumplings.Location = new Point(0, 0);
      this._treGumplings.Name = "_treGumplings";
      this._treGumplings.Size = new Size(116, 477);
      this._treGumplings.TabIndex = 1;
      this.m_Label1.BackColor = SystemColors.ControlDark;
      this.m_Label1.BorderStyle = BorderStyle.Fixed3D;
      this.m_Label1.Dock = DockStyle.Top;
      this.m_Label1.Location = new Point(0, 0);
      this.m_Label1.Name = "m_Label1";
      this.m_Label1.Size = new Size(124, 16);
      this.m_Label1.TabIndex = 0;
      this.m_Label1.Text = "Toolbox";
      this.m_Label1.TextAlign = ContentAlignment.MiddleCenter;
      this._StatusBar.Location = new Point(0, 523);
      this._StatusBar.Name = "_StatusBar";
      this._StatusBar.Size = new Size(904, 22);
      this._StatusBar.TabIndex = 0;
      this._Splitter1.BorderStyle = BorderStyle.Fixed3D;
      this._Splitter1.Location = new Point(128, 0);
      this._Splitter1.MinSize = 80;
      this._Splitter1.Name = "_Splitter1";
      this._Splitter1.Size = new Size(3, 523);
      this._Splitter1.TabIndex = 1;
      this._Splitter1.TabStop = false;
      this._Panel1.Controls.Add((Control) this._Panel2);
      this._Panel1.Dock = DockStyle.Fill;
      this._Panel1.Location = new Point(131, 0);
      this._Panel1.Name = "_Panel1";
      this._Panel1.Size = new Size(773, 523);
      this._Panel1.TabIndex = 2;
      this._Panel2.Controls.Add((Control) this._pnlCanvasScroller);
      this._Panel2.Controls.Add((Control) this._TabPager);
      this._Panel2.Controls.Add((Control) this._Splitter2);
      this._Panel2.Controls.Add((Control) this._Panel3);
      this._Panel2.Dock = DockStyle.Fill;
      this._Panel2.Location = new Point(0, 0);
      this._Panel2.Name = "_Panel2";
      this._Panel2.Size = new Size(773, 523);
      this._Panel2.TabIndex = 0;
      this._pnlCanvasScroller.AutoScroll = true;
      this._pnlCanvasScroller.AutoScrollMargin = new Size(1, 1);
      this._pnlCanvasScroller.AutoScrollMinSize = new Size(1, 1);
      this._pnlCanvasScroller.BackColor = Color.Silver;
      this._pnlCanvasScroller.BorderStyle = BorderStyle.Fixed3D;
      this._pnlCanvasScroller.Controls.Add((Control) this._picCanvas);
      this._pnlCanvasScroller.Dock = DockStyle.Fill;
      this._pnlCanvasScroller.Location = new Point(0, 24);
      this._pnlCanvasScroller.Name = "_pnlCanvasScroller";
      this._pnlCanvasScroller.Size = new Size(503, 499);
      this._pnlCanvasScroller.TabIndex = 2;
      this._picCanvas.BackColor = Color.Black;
      this._picCanvas.Location = new Point(0, 0);
      this._picCanvas.Name = "_picCanvas";
      this._picCanvas.Size = new Size(1600, 1200);
      this._picCanvas.TabIndex = 0;
      this._picCanvas.TabStop = false;
      this._TabPager.Controls.Add((Control) this._TabPage1);
      this._TabPager.Dock = DockStyle.Top;
      this._TabPager.HotTrack = true;
      this._TabPager.Location = new Point(0, 0);
      this._TabPager.Name = "_TabPager";
      this._TabPager.SelectedIndex = 0;
      this._TabPager.Size = new Size(503, 24);
      this._TabPager.TabIndex = 3;
      this._TabPage1.Location = new Point(4, 22);
      this._TabPage1.Name = "_TabPage1";
      this._TabPage1.Size = new Size(495, 0);
      this._TabPage1.TabIndex = 0;
      this._TabPage1.Text = "0";
      this._Splitter2.Dock = DockStyle.Right;
      this._Splitter2.Location = new Point(503, 0);
      this._Splitter2.Name = "_Splitter2";
      this._Splitter2.Size = new Size(22, 523);
      this._Splitter2.TabIndex = 1;
      this._Splitter2.TabStop = false;
      this._Panel3.Controls.Add((Control) this.m_cboElements);
      this._Panel3.Controls.Add((Control) this.m_ElementProperties);
      this._Panel3.Controls.Add((Control) this.m_CanvasFocus);
      this._Panel3.Dock = DockStyle.Right;
      this._Panel3.Location = new Point(525, 0);
      this._Panel3.Name = "_Panel3";
      this._Panel3.Size = new Size(248, 523);
      this._Panel3.TabIndex = 0;
      this.m_cboElements.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.m_cboElements.DropDownStyle = ComboBoxStyle.DropDownList;
      this.m_cboElements.Location = new Point(0, 8);
      this.m_cboElements.Name = "m_cboElements";
      this.m_cboElements.Size = new Size(240, 21);
      this.m_cboElements.TabIndex = 1;
      this.m_ElementProperties.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.m_ElementProperties.Cursor = Cursors.HSplit;
      this.m_ElementProperties.LineColor = SystemColors.ScrollBar;
      this.m_ElementProperties.Location = new Point(0, 32);
      this.m_ElementProperties.Name = "m_ElementProperties";
      this.m_ElementProperties.Size = new Size(240, 488);
      this.m_ElementProperties.TabIndex = 0;
      this.m_CanvasFocus.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.m_CanvasFocus.Location = new Point(16, 472);
      this.m_CanvasFocus.Name = "m_CanvasFocus";
      this.m_CanvasFocus.Size = new Size(100, 20);
      this.m_CanvasFocus.TabIndex = 1;
      this.m_CanvasFocus.Text = "TextBox1";
      this.m_MainMenu.MenuItems.AddRange(new MenuItem[6]
      {
        this._mnuFile,
        this._mnuEdit,
        this._mnuMisc,
        this._mnuPage,
        this._mnuPlugins,
        this._mnuHelp
      });
      this._mnuFile.Index = 0;
      this._mnuFile.MenuItems.AddRange(new MenuItem[8]
      {
        this._mnuFileNew,
        this.m_MenuItem9,
        this._mnuFileOpen,
        this._mnuFileSave,
        this._mnuFileImport,
        this._mnuFileExport,
        this.m_MenuItem5,
        this._mnuFileExit
      });
      this._mnuFile.Text = "File";
      this._mnuFileNew.Index = 0;
      this._mnuFileNew.Text = "New";
      this.m_MenuItem9.Index = 1;
      this.m_MenuItem9.Text = "-";
      this._mnuFileOpen.Index = 2;
      this._mnuFileOpen.Text = "Open";
      this._mnuFileSave.Index = 3;
      this._mnuFileSave.Text = "Save";
      this._mnuFileImport.Enabled = false;
      this._mnuFileImport.Index = 4;
      this._mnuFileImport.Text = "Import";
      this._mnuFileExport.Enabled = false;
      this._mnuFileExport.Index = 5;
      this._mnuFileExport.Text = "Export";
      this.m_MenuItem5.Index = 6;
      this.m_MenuItem5.Text = "-";
      this._mnuFileExit.Index = 7;
      this._mnuFileExit.Text = "Exit";
      this._mnuEdit.Index = 1;
      this._mnuEdit.MenuItems.AddRange(new MenuItem[9]
      {
        this._mnuEditUndo,
        this._mnuEditRedo,
        this.m_MenuItem3,
        this._mnuCut,
        this.m_mnuCopy,
        this._mnuPaste,
        this._mnuDelete,
        this.m_MenuItem4,
        this._mnuSelectAll
      });
      this._mnuEdit.Text = "Edit";
      this._mnuEditUndo.Enabled = false;
      this._mnuEditUndo.Index = 0;
      this._mnuEditUndo.Shortcut = Shortcut.CtrlZ;
      this._mnuEditUndo.Text = "Undo";
      this._mnuEditRedo.Enabled = false;
      this._mnuEditRedo.Index = 1;
      this._mnuEditRedo.Shortcut = Shortcut.CtrlY;
      this._mnuEditRedo.Text = "Redo";
      this.m_MenuItem3.Index = 2;
      this.m_MenuItem3.Text = "-";
      this._mnuCut.Index = 3;
      this._mnuCut.Shortcut = Shortcut.CtrlX;
      this._mnuCut.Text = "Cu&t";
      this.m_mnuCopy.Index = 4;
      this.m_mnuCopy.Shortcut = Shortcut.CtrlC;
      this.m_mnuCopy.Text = "&Copy";
      this._mnuPaste.Index = 5;
      this._mnuPaste.Shortcut = Shortcut.CtrlV;
      this._mnuPaste.Text = "&Paste";
      this._mnuDelete.Index = 6;
      this._mnuDelete.Text = "Delete";
      this.m_MenuItem4.Index = 7;
      this.m_MenuItem4.Text = "-";
      this._mnuSelectAll.Index = 8;
      this._mnuSelectAll.Shortcut = Shortcut.CtrlA;
      this._mnuSelectAll.Text = "Select &All";
      this._mnuMisc.Index = 2;
      this._mnuMisc.MenuItems.AddRange(new MenuItem[3]
      {
        this._mnuMiscLoadGumpling,
        this._mnuImportGumpling,
        this._mnuDataFile
      });
      this._mnuMisc.Text = "Misc";
      this._mnuMiscLoadGumpling.Index = 0;
      this._mnuMiscLoadGumpling.Text = "Load gumpling";
      this._mnuImportGumpling.Index = 1;
      this._mnuImportGumpling.Text = "Import Gumpling";
      this._mnuDataFile.Index = 2;
      this._mnuDataFile.Text = "Data File Path";
      this._mnuPage.Index = 3;
      this._mnuPage.MenuItems.AddRange(new MenuItem[6]
      {
        this._mnuPageAdd,
        this._mnuPageInsert,
        this._mnuPageDelete,
        this._mnuPageClear,
        this.m_MenuItem10,
        this._mnuShow0
      });
      this._mnuPage.Text = "Page";
      this._mnuPageAdd.Index = 0;
      this._mnuPageAdd.Text = "Add Page";
      this._mnuPageInsert.Index = 1;
      this._mnuPageInsert.Text = "Insert Page";
      this._mnuPageDelete.Index = 2;
      this._mnuPageDelete.Text = "Delete Page";
      this._mnuPageClear.Index = 3;
      this._mnuPageClear.Text = "Clear Page";
      this.m_MenuItem10.Index = 4;
      this.m_MenuItem10.Text = "-";
      this._mnuShow0.Checked = true;
      this._mnuShow0.Index = 5;
      this._mnuShow0.Text = "Always Show Page 0";
      this._mnuPlugins.Index = 4;
      this._mnuPlugins.MenuItems.AddRange(new MenuItem[1]
      {
        this._mnuPluginManager
      });
      this._mnuPlugins.Text = "Plug-Ins";
      this._mnuPluginManager.Index = 0;
      this._mnuPluginManager.Text = "Manager";
      this._mnuHelp.Index = 5;
      this._mnuHelp.MenuItems.AddRange(new MenuItem[1]
      {
        this._mnuHelpAbout
      });
      this._mnuHelp.Text = "Help";
      this._mnuHelpAbout.Index = 0;
      this._mnuHelpAbout.Text = "About...";
      this._mnuGumplingContext.MenuItems.AddRange(new MenuItem[6]
      {
        this._mnuGumplingRename,
        this._mnuGumplingMove,
        this._mnuGumplingDelete,
        this.m_MenuItem1,
        this._mnuGumplingAddGumpling,
        this._mnuGumplingAddFolder
      });
      this._mnuGumplingRename.Index = 0;
      this._mnuGumplingRename.Text = "Rename";
      this._mnuGumplingMove.Index = 1;
      this._mnuGumplingMove.Text = "Move";
      this._mnuGumplingDelete.Index = 2;
      this._mnuGumplingDelete.Text = "Delete";
      this.m_MenuItem1.Index = 3;
      this.m_MenuItem1.Text = "-";
      this._mnuGumplingAddGumpling.Index = 4;
      this._mnuGumplingAddGumpling.Text = "Add Gumpling";
      this._mnuGumplingAddFolder.Index = 5;
      this._mnuGumplingAddFolder.Text = "Add Folder";
      this.AutoScaleBaseSize = new Size(5, 13);
      this.ClientSize = new Size(904, 545);
      this.Controls.Add((Control) this._Panel1);
      this.Controls.Add((Control) this._Splitter1);
      this.Controls.Add((Control) this._pnlToolboxHolder);
      this.Controls.Add((Control) this._StatusBar);
      this.KeyPreview = true;
      this.Menu = this.m_MainMenu;
      this.Name = nameof (DesignerForm);
      this.Text = "Gump Studio (-Unsaved Gump-)";
      this._pnlToolboxHolder.ResumeLayout(false);
      this._Panel4.ResumeLayout(false);
      this._tabToolbox.ResumeLayout(false);
      this._tpgStandard.ResumeLayout(false);
      this._tpgCustom.ResumeLayout(false);
      this._Panel1.ResumeLayout(false);
      this._Panel2.ResumeLayout(false);
      this._pnlCanvasScroller.ResumeLayout(false);
      this._TabPager.ResumeLayout(false);
      this._Panel3.ResumeLayout(false);
      this._Panel3.PerformLayout();
      this.ResumeLayout(false);
    }

    public void LoadFrom(string Path)
    {
      IEnumerator enumerator = (IEnumerator) null;
      this._StatusBar.Text = "Loading gump...";
      FileStream fileStream = (FileStream) null;
      this.Stacks.Clear();
      this._TabPager.TabPages.Clear();
      try
      {
        fileStream = new FileStream(Path, FileMode.Open);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        this.Stacks = (ArrayList) binaryFormatter.Deserialize((Stream) fileStream);
        try
        {
          this.GumpProperties = (GumpProperties) binaryFormatter.Deserialize((Stream) fileStream);
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          this.GumpProperties = new GumpProperties();
          int num = (int) Interaction.MsgBox((object) exception.InnerException.Message, MsgBoxStyle.OkOnly, (object) null);
          ProjectData.ClearProjectError();
        }
        this.SetActiveElement((BaseElement) null, true);
        this.RefreshElementList();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) Interaction.MsgBox((object) ex.Message, MsgBoxStyle.OkOnly, (object) null);
        ProjectData.ClearProjectError();
      }
      finally
      {
        fileStream?.Close();
      }
      int num1 = 0;
      try
      {
        foreach (object stack in this.Stacks)
        {
          RuntimeHelpers.GetObjectValue(stack);
          this._TabPager.TabPages.Add(new TabPage(num1.ToString()));
          ++num1;
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.ChangeActiveStack(0);
      this.ElementStack.UpdateParent += new BaseElement.UpdateParentEventHandler(this.ChangeActiveElementEventHandler);
      this.ElementStack.Repaint += new BaseElement.RepaintEventHandler(this.RefreshView);
      this._StatusBar.Text = "";
    }

    private void MenuItem2_Click(object sender, EventArgs e)
    {
      this._OpenDialog.Filter = "Gumpling (*.gumpling)|*.gumpling|Gump (*.gump)|*.gump";
      if (this._OpenDialog.ShowDialog() != DialogResult.OK)
        return;
      FileStream fileStream = new FileStream(this._OpenDialog.FileName, FileMode.Open);
      GroupElement groupElement = (GroupElement) new BinaryFormatter().Deserialize((Stream) fileStream);
      groupElement.mIsBaseWindow = false;
      groupElement.RecalculateBounds();
      Point point = new Point(0, 0);
      groupElement.Location = point;
      fileStream.Close();
      this.AddElement((BaseElement) groupElement);
    }

    private void mnuAddPage_Click(object sender, EventArgs e)
    {
      this.AddPage();
      this.CreateUndoPoint("Add page");
    }

    private void mnuCopy_Click(object sender, EventArgs e)
    {
      this.Copy();
    }

    private void mnuCut_Click(object sender, EventArgs e)
    {
      this.Cut();
      this.CreateUndoPoint();
    }

    private void mnuDataFile_Click(object sender, EventArgs e)
    {
      FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
      folderBrowserDialog.Description = "Select the folder that contains the UO data (.mul) files you want to use.";
      if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
        return;
      if (File.Exists(Path.Combine(folderBrowserDialog.SelectedPath, "art.mul")))
      {
        MySettings.Default.ClientPath = folderBrowserDialog.SelectedPath;
        MySettings.Default.Save();
        int num = (int) Interaction.MsgBox((object) "New path set, please restart Gump Studio to activate your changes.", MsgBoxStyle.OkOnly, (object) "Data Files");
      }
      else
      {
        int num1 = (int) Interaction.MsgBox((object) "This path does not contain a file named \"art.mul\", it is most likely not the correct path.", MsgBoxStyle.OkOnly, (object) "Data Files");
      }
    }

    private void mnuDelete_Click(object sender, EventArgs e)
    {
      this.DeleteSelectedElements();
    }

    private void mnuEditRedo_Click(object sender, EventArgs e)
    {
      this.Redo();
    }

    private void mnuEditUndo_Click(object sender, EventArgs e)
    {
      this.Undo();
    }

    private void mnuFileExit_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void mnuFileNew_Click(object sender, EventArgs e)
    {
      if (Interaction.MsgBox((object) "Are you sure you want to start a new gump?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, (object) null) != MsgBoxResult.Yes)
        return;
      this.ClearGump();
    }

    private void mnuFileOpen_Click(object sender, EventArgs e)
    {
      this._OpenDialog.CheckFileExists = true;
      this._OpenDialog.Filter = "Gump|*.gump";
      if (this._OpenDialog.ShowDialog() == DialogResult.OK)
      {
        this.LoadFrom(this._OpenDialog.FileName);
        this.FileName = Path.GetFileName(this._OpenDialog.FileName);
        this.Text = "Gump Studio (" + this.FileName + ")";
      }
      this._picCanvas.Invalidate();
    }

    private void mnuFileSave_Click(object sender, EventArgs e)
    {
      this._SaveDialog.AddExtension = true;
      this._SaveDialog.DefaultExt = "gump";
      this._SaveDialog.Filter = "Gump|*.gump";
      if (this._SaveDialog.ShowDialog() != DialogResult.OK)
        return;
      this.SaveTo(this._SaveDialog.FileName);
      this.FileName = Path.GetFileName(this._SaveDialog.FileName);
      this.Text = "Gump Studio (" + this.FileName + ")";
    }

    private void mnuGroupCreate_Click(object sender, EventArgs e)
    {
      IEnumerator enumerator1 = (IEnumerator) null;
      ArrayList arrayList = new ArrayList();
      try
      {
        foreach (object element in this.ElementStack.GetElements())
        {
          BaseElement objectValue = (BaseElement) RuntimeHelpers.GetObjectValue(element);
          if (objectValue.Selected)
            arrayList.Add((object) objectValue);
        }
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
      if (arrayList.Count >= 2)
      {
        IEnumerator enumerator2 = (IEnumerator) null;
        GroupElement groupElement = new GroupElement(this.ElementStack, (ArrayList) null, "New Group");
        try
        {
          foreach (object obj in arrayList)
          {
            BaseElement objectValue = (BaseElement) RuntimeHelpers.GetObjectValue(obj);
            groupElement.AddElement(objectValue);
            this.ElementStack.RemoveElement(objectValue);
            this.ElementStack.RemoveEvents(objectValue);
          }
        }
        finally
        {
          if (enumerator2 is IDisposable)
            (enumerator2 as IDisposable).Dispose();
        }
        this.AddElement((BaseElement) groupElement);
        this._picCanvas.Invalidate();
      }
      this.CreateUndoPoint();
    }

    private void mnuHelpAbout_Click(object sender, EventArgs e)
    {
      frmAboutBox frmAboutBox = new frmAboutBox();
      frmAboutBox.SetText(this.AboutElementAppend);
      int num = (int) frmAboutBox.ShowDialog();
    }

    private void mnuImportGumpling_Click(object sender, EventArgs e)
    {
      this._OpenDialog.Filter = "Gumpling (*.gumpling)|*.gumpling|Gump (*.gump)|*.gump";
      if (this._OpenDialog.ShowDialog() != DialogResult.OK)
        return;
      FileStream fileStream = new FileStream(this._OpenDialog.FileName, FileMode.Open);
      GroupElement Gumpling = (GroupElement) new BinaryFormatter().Deserialize((Stream) fileStream);
      Gumpling.mIsBaseWindow = false;
      Gumpling.RecalculateBounds();
      Point point = new Point(0, 0);
      Gumpling.Location = point;
      fileStream.Close();
      this.UncategorizedFolder.AddItem((TreeItem) new TreeGumpling(Path.GetFileName(this._OpenDialog.FileName), Gumpling));
      this.BuildGumplingTree();
    }

    private void mnuPageClear_Click(object sender, EventArgs e)
    {
      this.ElementStack = new GroupElement((GroupElement) null, (ArrayList) null, "Element Stack", true);
      this.CreateUndoPoint("Clear Page");
    }

    private void mnuPageDelete_Click(object sender, EventArgs e)
    {
      if (this._TabPager.SelectedIndex == 0)
      {
        int num1 = (int) Interaction.MsgBox((object) "Page 0  can not be deleted.", MsgBoxStyle.OkOnly, (object) null);
      }
      else
      {
        int selectedIndex = this._TabPager.SelectedIndex;
        int num2 = this._TabPager.TabCount - 1;
        for (int index = selectedIndex + 1; index <= num2; ++index)
          this._TabPager.TabPages[index].Text = Conversions.ToString(index - 1);
        this.Stacks.RemoveAt(selectedIndex);
        this._TabPager.TabPages.RemoveAt(selectedIndex);
        this.ChangeActiveStack(selectedIndex - 1);
        this.CreateUndoPoint("Delete page");
      }
    }

    private void mnuPageInsert_Click(object sender, EventArgs e)
    {
      if (this._TabPager.SelectedIndex == 0)
      {
        int num1 = (int) Interaction.MsgBox((object) "Page 0 may not be moved.", MsgBoxStyle.OkOnly, (object) null);
      }
      else
      {
        int tabCount = this._TabPager.TabCount;
        int selectedIndex = this._TabPager.SelectedIndex;
        int num2 = this._TabPager.TabCount - 1;
        for (int index = selectedIndex; index <= num2; ++index)
          this._TabPager.TabPages.RemoveAt(selectedIndex);
        this._TabPager.TabPages.Add(new TabPage(selectedIndex.ToString()));
        int num3 = tabCount;
        for (int index = selectedIndex + 1; index <= num3; ++index)
          this._TabPager.TabPages.Add(new TabPage(index.ToString()));
        GroupElement groupElement = new GroupElement((GroupElement) null, (ArrayList) null, "Element Stack", true);
        this.Stacks.Insert(selectedIndex, (object) groupElement);
        this.ChangeActiveStack(selectedIndex);
        this._TabPager.SelectedIndex = selectedIndex;
        this.CreateUndoPoint("Insert page");
      }
    }

    private void mnuPaste_Click(object sender, EventArgs e)
    {
      this.Paste();
      this.CreateUndoPoint();
    }

    private void mnuPluginManager_Click(object sender, EventArgs e)
    {
      int num = (int) new PluginManager()
      {
        AvailablePlugins = this.AvailablePlugins,
        LoadedPlugins = this.LoadedPlugins,
        OrderList = this.PluginTypesToLoad,
        MainForm = this
      }.ShowDialog();
    }

    private void mnuSelectAll_Click(object sender, EventArgs e)
    {
      this.SelectAll();
    }

    private void mnuShow0_Click(object sender, EventArgs e)
    {
      this.ShowPage0 = !this.ShowPage0;
      this._mnuShow0.Checked = this.ShowPage0;
      this._picCanvas.Refresh();
    }

    public void Paste()
    {
      IDataObject dataObject = Clipboard.GetDataObject();
      ArrayList arrayList = new ArrayList();
      ArrayList data = (ArrayList) dataObject.GetData(typeof (ArrayList));
      if (data != null)
      {
        IEnumerator enumerator = (IEnumerator) null;
        this.SetActiveElement((BaseElement) null, true);
        try
        {
          foreach (object obj in data)
          {
            BaseElement objectValue = (BaseElement) RuntimeHelpers.GetObjectValue(obj);
            if (this.CopyMode == ClipBoardMode.Copy)
              objectValue.Name = "Copy of " + objectValue.Name;
            objectValue.Selected = true;
            this.ElementStack.AddElement(objectValue);
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
      }
      this._picCanvas.Invalidate();
    }

    private void picCanvas_MouseDown(object sender, MouseEventArgs e)
    {
      this.CanvasFocus.Focus();
      Point point = new Point(e.X, e.Y);
      this.mAnchor = point;
      BaseElement Element = this.ElementStack.GetElementFromPoint(point);
      if ((this.ActiveElement == null || this.ActiveElement.HitTest(point) == MoveModeType.None ? 0 : 1) != 0)
        Element = this.ActiveElement;
      if (Element != null)
      {
        this.MoveMode = Element.HitTest(point);
        if ((this.ActiveElement == null || this.ActiveElement.HitTest(point) != MoveModeType.None ? 0 : 1) != 0)
        {
          if (Element.Selected)
          {
            if ((Control.ModifierKeys & Keys.Control) > Keys.None)
              Element.Selected = false;
            else
              this.SetActiveElement(Element, false);
          }
          else
            this.SetActiveElement(Element, (Control.ModifierKeys & Keys.Control) <= Keys.None);
        }
        else if (this.ActiveElement == null)
          this.SetActiveElement(Element, false);
        else if (this.ActiveElement != null && (Control.ModifierKeys & Keys.Control) > Keys.None)
        {
          this.ActiveElement.Selected = false;
          ArrayList selectedElements = this.ElementStack.GetSelectedElements();
          if (selectedElements.Count > 0)
          {
            this.SetActiveElement((BaseElement) selectedElements[0], false);
          }
          else
          {
            this.SetActiveElement((BaseElement) null, true);
            this.MoveMode = MoveModeType.None;
          }
        }
      }
      else
      {
        this.MoveMode = MoveModeType.None;
        if ((e.Button & MouseButtons.Left) > MouseButtons.None)
          this.SetActiveElement((BaseElement) null, (Control.ModifierKeys & Keys.Control) <= Keys.None);
      }
      this._picCanvas.Invalidate();
      this.LastPos = point;
      if (this.ActiveElement != null)
      {
        this.mAnchorOffset.Width = this.ActiveElement.X - point.X;
        this.mAnchorOffset.Height = this.ActiveElement.Y - point.Y;
      }
      this.ElementChanged = false;
      this.MoveCount = 0;
    }

    private void picCanvas_MouseMove(object sender, MouseEventArgs e)
    {
      IEnumerator enumerator1 = (IEnumerator) null;
      Point point1 = new Point(e.X, e.Y);
      int num1 = point1.X - this.LastPos.X;
      int num2 = point1.Y - this.LastPos.Y;
      BaseElement baseElement = this.ElementStack.GetElementFromPoint(point1);
      if ((this.ActiveElement == null || this.ActiveElement.HitTest(point1) == MoveModeType.None ? 0 : 1) != 0)
        baseElement = this.ActiveElement;
      if (this.MoveMode == MoveModeType.Move)
        point1.Offset(this.mAnchorOffset.Width, this.mAnchorOffset.Height);
      MouseMoveHookEventArgs e1 = new MouseMoveHookEventArgs();
      e1.Keys = Control.ModifierKeys;
      e1.MouseButtons = e.Button;
      e1.MouseLocation = point1;
      e1.MoveMode = this.MoveMode;
      try
      {
        foreach (object loadedPlugin in this.LoadedPlugins)
        {
          ((BasePlugin) RuntimeHelpers.GetObjectValue(loadedPlugin)).MouseMoveHook(ref e1);
          point1 = e1.MouseLocation;
        }
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
      if ((this.MoveMode != MoveModeType.None || Math.Abs(num1) <= 0 || Math.Abs(num2) <= 0 ? 0 : 1) != 0)
        this.MoveMode = MoveModeType.SelectionBox;
      if (e.Button != MouseButtons.Left)
      {
        if (baseElement != null)
        {
          switch (baseElement.HitTest(point1))
          {
            case MoveModeType.ResizeTopLeft:
            case MoveModeType.ResizeBottomRight:
              this.Cursor = Cursors.SizeNWSE;
              break;
            case MoveModeType.ResizeTopRight:
            case MoveModeType.ResizeBottomLeft:
              this.Cursor = Cursors.SizeNESW;
              break;
            case MoveModeType.Move:
              this.Cursor = Cursors.SizeAll;
              break;
            case MoveModeType.ResizeLeft:
            case MoveModeType.ResizeRight:
              this.Cursor = Cursors.SizeWE;
              break;
            case MoveModeType.ResizeTop:
            case MoveModeType.ResizeBottom:
              this.Cursor = Cursors.SizeNS;
              break;
            default:
              this.Cursor = Cursors.Default;
              break;
          }
        }
        else
          this.Cursor = Cursors.Default;
      }
      else
      {
        ++this.MoveCount;
        if (this.MoveCount > 100)
          this.MoveCount = 2;
        Rectangle rectangle = new Rectangle(0, 0, this._picCanvas.Width, this._picCanvas.Height);
        Cursor.Clip = this._picCanvas.RectangleToScreen(rectangle);
        if (this.MoveMode != MoveModeType.None)
        {
          switch (this.MoveMode)
          {
            case MoveModeType.ResizeTopLeft:
            case MoveModeType.ResizeBottomRight:
              this.Cursor = Cursors.SizeNWSE;
              break;
            case MoveModeType.ResizeTopRight:
            case MoveModeType.ResizeBottomLeft:
              this.Cursor = Cursors.SizeNESW;
              break;
            case MoveModeType.Move:
              this.Cursor = Cursors.SizeAll;
              break;
            case MoveModeType.ResizeLeft:
            case MoveModeType.ResizeRight:
              this.Cursor = Cursors.SizeWE;
              break;
            case MoveModeType.ResizeTop:
            case MoveModeType.ResizeBottom:
              this.Cursor = Cursors.SizeNS;
              break;
            default:
              this.Cursor = Cursors.Default;
              break;
          }
          if (this.MoveCount >= 2)
            this.ElementChanged = true;
        }
        switch (this.MoveMode)
        {
          case MoveModeType.SelectionBox:
            rectangle = new Rectangle(this.mAnchor, new Size(point1.X - this.mAnchor.X, point1.Y - this.mAnchor.Y));
            this.SelectionRect = this.GetPositiveRect(rectangle);
            this.ShowSelectionRect = true;
            this._picCanvas.Invalidate();
            break;
          case MoveModeType.ResizeTopLeft:
            point1.Offset(3, 0);
            Point point2 = new Point(this.ActiveElement.X + this.ActiveElement.Width, this.ActiveElement.Y + this.ActiveElement.Height);
            this.ActiveElement.Location = point1;
            Size size1 = this.ActiveElement.Size;
            Point location1 = this.ActiveElement.Location;
            size1.Width = point2.X - point1.X;
            size1.Height = point2.Y - point1.Y;
            if (size1.Width < 1)
            {
              location1.X = point2.X - 1;
              size1.Width = 1;
            }
            if (size1.Height < 1)
            {
              location1.Y = point2.Y - 1;
              size1.Height = 1;
            }
            this.ActiveElement.Size = size1;
            this.ActiveElement.Location = location1;
            this._picCanvas.Invalidate();
            break;
          case MoveModeType.ResizeTopRight:
            point1.Offset(-3, 0);
            Point point3 = new Point(this.ActiveElement.X + this.ActiveElement.Width, this.ActiveElement.Y + this.ActiveElement.Height);
            Point location2 = this.ActiveElement.Location;
            location2.Y = point1.Y;
            this.ActiveElement.Location = location2;
            Size size2 = this.ActiveElement.Size;
            size2.Height = point3.Y - point1.Y;
            size2.Width = point1.X - this.ActiveElement.X;
            if (size2.Height < 1)
            {
              location2.Y = point3.Y - 1;
              size2.Height = 1;
            }
            if (size2.Width < 1)
              size2.Width = 1;
            location2.X = this.ActiveElement.Location.X;
            this.ActiveElement.Size = size2;
            this.ActiveElement.Location = location2;
            this._picCanvas.Invalidate();
            break;
          case MoveModeType.ResizeBottomRight:
            point1.Offset(-3, -3);
            Size size3 = this.ActiveElement.Size;
            size3.Width = point1.X - this.ActiveElement.X;
            size3.Height = point1.Y - this.ActiveElement.Y;
            if (size3.Width < 1)
              size3.Width = 1;
            if (size3.Height < 1)
              size3.Height = 1;
            this.ActiveElement.Size = size3;
            this._picCanvas.Invalidate();
            break;
          case MoveModeType.ResizeBottomLeft:
            point1.Offset(0, -3);
            Point point4 = new Point(this.ActiveElement.X + this.ActiveElement.Width, this.ActiveElement.Y + this.ActiveElement.Height);
            Point location3 = this.ActiveElement.Location;
            location3.X = point1.X;
            this.ActiveElement.Location = location3;
            Size size4 = this.ActiveElement.Size;
            size4.Width = point4.X - point1.X;
            size4.Height = point1.Y - this.ActiveElement.Y;
            if (size4.Width < 1)
            {
              location3.X = point4.X - 1;
              size4.Width = 1;
            }
            if (size4.Height < 1)
              size4.Height = 1;
            location3.Y = this.ActiveElement.Y;
            this.ActiveElement.Size = size4;
            this.ActiveElement.Location = location3;
            this._picCanvas.Invalidate();
            break;
          case MoveModeType.Move:
            IEnumerator enumerator2 = (IEnumerator) null;
            Point location4 = this.ActiveElement.Location;
            this.ActiveElement.Location = point1;
            int dx = this.ActiveElement.X - location4.X;
            int dy = this.ActiveElement.Y - location4.Y;
            try
            {
              foreach (object selectedElement in this.ElementStack.GetSelectedElements())
              {
                BaseElement objectValue = (BaseElement) RuntimeHelpers.GetObjectValue(selectedElement);
                if (objectValue != this.ActiveElement)
                {
                  Point location5 = objectValue.Location;
                  location5.Offset(dx, dy);
                  objectValue.Location = location5;
                }
              }
            }
            finally
            {
              if (enumerator2 is IDisposable)
                (enumerator2 as IDisposable).Dispose();
            }
            this._picCanvas.Invalidate();
            break;
          case MoveModeType.ResizeLeft:
            point1.Offset(3, 0);
            Point point5 = new Point(this.ActiveElement.X + this.ActiveElement.Width, this.ActiveElement.Y + this.ActiveElement.Height);
            int y = this.ActiveElement.Y;
            this.ActiveElement.Location = point1;
            Size size5 = this.ActiveElement.Size;
            Point location6 = this.ActiveElement.Location;
            size5.Width = point5.X - point1.X;
            if (size5.Width < 1)
            {
              location6.X = point5.X - 1;
              size5.Width = 1;
            }
            location6.Y = y;
            this.ActiveElement.Size = size5;
            this.ActiveElement.Location = location6;
            this._picCanvas.Invalidate();
            break;
          case MoveModeType.ResizeTop:
            point1.Offset(0, 3);
            Point point6 = new Point(this.ActiveElement.X + this.ActiveElement.Width, this.ActiveElement.Y + this.ActiveElement.Height);
            int x = this.ActiveElement.X;
            this.ActiveElement.Location = point1;
            Size size6 = this.ActiveElement.Size;
            Point location7 = this.ActiveElement.Location;
            size6.Height = point6.Y - point1.Y;
            if (size6.Height < 1)
            {
              location7.Y = point6.Y - 1;
              size6.Height = 1;
            }
            location7.X = x;
            this.ActiveElement.Size = size6;
            this.ActiveElement.Location = location7;
            this._picCanvas.Invalidate();
            break;
          case MoveModeType.ResizeRight:
            point1.Offset(-3, 0);
            Size size7 = this.ActiveElement.Size;
            size7.Width = point1.X - this.ActiveElement.X;
            if (size7.Width < 1)
              size7.Width = 1;
            this.ActiveElement.Size = size7;
            this._picCanvas.Invalidate();
            break;
          case MoveModeType.ResizeBottom:
            point1.Offset(0, -3);
            Size size8 = this.ActiveElement.Size;
            size8.Height = point1.Y - this.ActiveElement.Y;
            if (size8.Height < 1)
              size8.Height = 1;
            this.ActiveElement.Size = size8;
            this._picCanvas.Invalidate();
            break;
        }
      }
      this.LastPos = point1;
    }

    private void picCanvas_MouseUp(object sender, MouseEventArgs e)
    {
      Rectangle rectangle = new Rectangle();
      Point point = new Point(e.X, e.Y);
      this.ElementStack.GetElementFromPoint(point);
      this.ShowSelectionRect = false;
      Cursor.Clip = rectangle;
      if (this.MoveMode == MoveModeType.SelectionBox)
      {
        IEnumerator enumerator = (IEnumerator) null;
        BaseElement Element = (BaseElement) null;
        try
        {
          foreach (object element in this.ElementStack.GetElements())
          {
            BaseElement objectValue = (BaseElement) RuntimeHelpers.GetObjectValue(element);
            if (objectValue.ContainsTest(this.SelectionRect))
            {
              objectValue.Selected = true;
              Element = objectValue;
            }
            else if ((Control.ModifierKeys & Keys.Control) <= Keys.None)
              objectValue.Selected = false;
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        this.SetActiveElement(Element, false);
      }
      if ((this.MoveMode == MoveModeType.None || this.MoveMode == MoveModeType.SelectionBox || !this.ElementChanged ? 0 : 1) != 0)
      {
        this.CreateUndoPoint("Element Moved");
        this.ElementChanged = false;
      }
      if ((e.Button & MouseButtons.Right) > MouseButtons.None)
      {
        ContextMenu mnuContextMenu = this.m_mnuContextMenu;
        this.GetContextMenu(ref this.ActiveElement, mnuContextMenu);
        mnuContextMenu.Show((Control) this._picCanvas, point);
        this.ClearContextMenu((Menu) mnuContextMenu);
      }
      this.SetActiveElement(this.ActiveElement, false);
      this._picCanvas.Invalidate();
      this.MoveMode = MoveModeType.None;
      this.mAnchorOffset = new Size(0, 0);
    }

    private void picCanvas_Paint(object sender, PaintEventArgs e)
    {
      this.Render(e.Graphics);
    }

    private void pnlCanvasScroller_MouseLeave(object sender, EventArgs e)
    {
      this.Cursor = Cursors.Default;
    }

    public void RebuildTabPages()
    {
      IEnumerator enumerator = (IEnumerator) null;
      this._TabPager.TabPages.Clear();
      int num = -1;
      try
      {
        foreach (object stack in this.Stacks)
        {
          object objectValue = RuntimeHelpers.GetObjectValue(stack);
          ++num;
          this._TabPager.TabPages.Add(new TabPage(Conversions.ToString(num)));
          if (this.ElementStack == objectValue)
            this._TabPager.SelectedIndex = num;
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    public void Redo()
    {
      if (this.CurrentUndoPoint < this.UndoPoints.Count)
      {
        ++this.CurrentUndoPoint;
        this.RevertToUndoPoint(this.CurrentUndoPoint);
      }
      if (this.CurrentUndoPoint == this.UndoPoints.Count - 1)
        this._mnuEditRedo.Enabled = false;
      this._mnuEditUndo.Enabled = true;
    }

    public void RefreshElementList()
    {
      this.m_cboElements.Items.Clear();
      this.m_cboElements.Items.AddRange(this.ElementStack.GetElements().ToArray());
    }

    public void RefreshView(object sender)
    {
      this.RefreshElementList();
      this.m_cboElements.SelectedItem = (object) this.ActiveElement;
      if (this.ElementStack.GetSelectedElements().Count > 1)
        this.m_ElementProperties.SelectedObjects = this.ElementStack.GetSelectedElements().ToArray();
      else
        this.m_ElementProperties.SelectedObject = (object) this.ActiveElement;
    }

    protected void Render(Graphics Target)
    {
      IEnumerator enumerator = (IEnumerator) null;
      Graphics Target1 = Graphics.FromImage((Image) this.Canvas);
      if (!this.PluginClearsCanvas)
        Target1.Clear(Color.Black);
      DesignerForm.HookPreRenderEventHandler hookPreRender = this.HookPreRender;
      if (hookPreRender != null)
        hookPreRender(this.Canvas);
      if ((!this.ShowPage0 || this.ElementStack == this.Stacks[0] ? 0 : 1) != 0)
        ((BaseElement) this.Stacks[0]).Render(Target1);
      this.ElementStack.Render(Target1);
      try
      {
        foreach (object element in this.ElementStack.GetElements())
        {
          BaseElement objectValue = (BaseElement) RuntimeHelpers.GetObjectValue(element);
          if ((!objectValue.Selected || objectValue == this.ActiveElement ? 0 : 1) != 0)
            objectValue.DrawBoundingBox(Target1, false);
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      if (this.ActiveElement != null)
        this.ActiveElement.DrawBoundingBox(Target1, true);
      if (this.ShowSelectionRect)
      {
        Target1.FillRectangle((Brush) this.SelBG, this.SelectionRect);
        Target1.DrawRectangle(this.SelFG, this.SelectionRect);
      }
      DesignerForm.HookPostRenderEventHandler hookPostRender = this.HookPostRender;
      if (hookPostRender != null)
        hookPostRender(this.Canvas);
      Target1.Dispose();
      Target.DrawImage((Image) this.Canvas, 0, 0);
    }

    public void RevertToUndoPoint(int Index)
    {
      IEnumerator enumerator = (IEnumerator) null;
      UndoPoint undoPoint = (UndoPoint) this.UndoPoints[Index];
      this.GumpProperties = (GumpProperties) undoPoint.GumpProperties.Clone();
      this.Stacks = new ArrayList();
      try
      {
        foreach (object obj in undoPoint.Stack)
        {
          GroupElement objectValue = (GroupElement) RuntimeHelpers.GetObjectValue(obj);
          GroupElement groupElement = (GroupElement) objectValue.Clone();
          this.Stacks.Add((object) groupElement);
          if (undoPoint.ElementStack == objectValue)
            this.ElementStack = groupElement;
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.RebuildTabPages();
      this._picCanvas.Invalidate();
      this.SetActiveElement((BaseElement) null, true);
      this.CurrentUndoPoint = Index;
    }

    public void SaveTo(string Path)
    {
      this._StatusBar.Text = "Saving gump...";
      this.ElementStack.UpdateParent -= new BaseElement.UpdateParentEventHandler(this.ChangeActiveElementEventHandler);
      this.ElementStack.Repaint -= new BaseElement.RepaintEventHandler(this.RefreshView);
      FileStream fileStream = new FileStream(Path, FileMode.Create);
      BinaryFormatter binaryFormatter = new BinaryFormatter();
      binaryFormatter.Serialize((Stream) fileStream, (object) this.Stacks);
      binaryFormatter.Serialize((Stream) fileStream, (object) this.GumpProperties);
      fileStream.Close();
      this.ElementStack.UpdateParent += new BaseElement.UpdateParentEventHandler(this.ChangeActiveElementEventHandler);
      this.ElementStack.Repaint += new BaseElement.RepaintEventHandler(this.RefreshView);
      this._StatusBar.Text = "";
    }

    public void SelectAll()
    {
      IEnumerator enumerator = (IEnumerator) null;
      try
      {
        foreach (object selectedElement in this.ElementStack.GetSelectedElements())
          ((BaseElement) RuntimeHelpers.GetObjectValue(selectedElement)).Selected = true;
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this._picCanvas.Invalidate();
    }

    public void SetActiveElement(BaseElement e)
    {
      this.SetActiveElement(e, false);
    }

    public void SetActiveElement(BaseElement Element, bool DeselectOthers)
    {
      if (DeselectOthers)
      {
        IEnumerator enumerator = (IEnumerator) null;
        try
        {
          foreach (object element in this.ElementStack.GetElements())
            ((BaseElement) RuntimeHelpers.GetObjectValue(element)).Selected = false;
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
      }
      if (this.ActiveElement != Element)
      {
        this.RefreshElementList();
        this.ActiveElement = Element;
        this.m_cboElements.SelectedItem = (object) Element;
        if (Element != null)
          Element.Selected = true;
      }
      if (this.ElementStack.GetSelectedElements().Count > 1)
        this.m_ElementProperties.SelectedObjects = this.ElementStack.GetSelectedElements().ToArray();
      else if (Element != null)
        this.m_ElementProperties.SelectedObject = (object) Element;
      else
        this.m_ElementProperties.SelectedObject = (object) this.GumpProperties;
    }

    public Point SnapLocToGrid(Point Position, Size GridSize)
    {
      Point point = Position;
      point.X = point.X / GridSize.Width * GridSize.Width;
      point.Y = point.Y / GridSize.Height * GridSize.Height;
      return point;
    }

    private void TabPager_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this._TabPager.SelectedIndex != -1)
        this.ChangeActiveStack(this._TabPager.SelectedIndex);
      this.RefreshElementList();
    }

    private void treGumplings_DoubleClick(object sender, EventArgs e)
    {
      if (this._treGumplings.SelectedNode.Tag == null || !(this._treGumplings.SelectedNode.Tag is TreeGumpling))
        return;
      GroupElement groupElement = (GroupElement) ((TreeGumpling) this._treGumplings.SelectedNode.Tag).Gumpling.Clone();
      groupElement.mIsBaseWindow = false;
      groupElement.RecalculateBounds();
      Point point = new Point(0, 0);
      groupElement.Location = point;
      this.AddElement((BaseElement) groupElement);
    }

    private void treGumplings_MouseUp(object sender, MouseEventArgs e)
    {
      this._treGumplings.SelectedNode = this._treGumplings.GetNodeAt(new Point(e.X, e.Y));
    }

    public void Undo()
    {
      --this.CurrentUndoPoint;
      this.RevertToUndoPoint(this.CurrentUndoPoint);
      if (this.CurrentUndoPoint == 0)
        this._mnuEditUndo.Enabled = false;
      this._mnuEditRedo.Enabled = true;
    }

    public void WritePluginsToLoad()
    {
      if (this.PluginTypesToLoad != null)
      {
        FileStream fileStream = new FileStream(Application.StartupPath + "\\Plugins\\LoadInfo", FileMode.Create);
        new BinaryFormatter().Serialize((Stream) fileStream, (object) this.PluginTypesToLoad);
        fileStream.Close();
      }
      else
      {
        if (!File.Exists(Application.StartupPath + "\\Plugins\\LoadInfo"))
          return;
        File.Delete(Application.StartupPath + "\\Plugins\\LoadInfo");
      }
    }

    public delegate void HookKeyDownEventHandler(object sender, ref KeyEventArgs e);

    public delegate void HookPostRenderEventHandler(Bitmap Target);

    public delegate void HookPreRenderEventHandler(Bitmap Target);
  }
}
