// Decompiled with JetBrains decompiler
// Type: GumpStudio.PluginManager
// Assembly: GumpStudioCore, Version=1.8.3024.24259, Culture=neutral, PublicKeyToken=null
// MVID: A77D32E5-7519-4865-AA26-DCCB34429732
// Assembly location: C:\GumpStudio_1_8_R3_quinted-02\GumpStudioCore.dll

using GumpStudio.Plugins;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace GumpStudio
{
    public class PluginManager : Form
    {
        private static List<WeakReference> __ENCList = new List<WeakReference>();
        [AccessedThroughProperty( "cmdAdd" )]
        private Button _cmdAdd;
        [AccessedThroughProperty( "cmdCancel" )]
        private Button _cmdCancel;
        [AccessedThroughProperty( "cmdMoveDown" )]
        private Button _cmdMoveDown;
        [AccessedThroughProperty( "cmdMoveUp" )]
        private Button _cmdMoveUp;
        [AccessedThroughProperty( "cmdOK" )]
        private Button _cmdOK;
        [AccessedThroughProperty( "cmdRemove" )]
        private Button _cmdRemove;
        [AccessedThroughProperty( "GroupBox1" )]
        private GroupBox _GroupBox1;
        [AccessedThroughProperty( "Label1" )]
        private Label _Label1;
        [AccessedThroughProperty( "Label2" )]
        private Label _Label2;
        [AccessedThroughProperty( "Label3" )]
        private Label _Label3;
        [AccessedThroughProperty( "Label4" )]
        private Label _Label4;
        [AccessedThroughProperty( "Label5" )]
        private Label _Label5;
        [AccessedThroughProperty( "Label6" )]
        private Label _Label6;
        [AccessedThroughProperty( "lstAvailable" )]
        private ListBox _lstAvailable;
        [AccessedThroughProperty( "lstLoaded" )]
        private ListBox _lstLoaded;
        [AccessedThroughProperty( "txtAuthor" )]
        private TextBox _txtAuthor;
        [AccessedThroughProperty( "txtDescription" )]
        private TextBox _txtDescription;
        [AccessedThroughProperty( "txtEmail" )]
        private TextBox _txtEmail;
        [AccessedThroughProperty( "txtVersion" )]
        private TextBox _txtVersion;
        public ArrayList AvailablePlugins;
        private IContainer components;
        public ArrayList LoadedPlugins;
        public DesignerForm MainForm;
        public PluginInfo[] OrderList;

        internal virtual Button cmdAdd
        {
            [DebuggerNonUserCode]
            get => this._cmdAdd;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                EventHandler eventHandler = new EventHandler( this.cmdAdd_Click );
                if ( this._cmdAdd != null )
                    this._cmdAdd.Click -= eventHandler;
                this._cmdAdd = value;
                if ( this._cmdAdd == null )
                    return;
                this._cmdAdd.Click += eventHandler;
            }
        }

        internal virtual Button cmdCancel
        {
            [DebuggerNonUserCode]
            get => this._cmdCancel;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                EventHandler eventHandler = new EventHandler( this.cmdCancel_Click );
                if ( this._cmdCancel != null )
                    this._cmdCancel.Click -= eventHandler;
                this._cmdCancel = value;
                if ( this._cmdCancel == null )
                    return;
                this._cmdCancel.Click += eventHandler;
            }
        }

        internal virtual Button cmdMoveDown
        {
            [DebuggerNonUserCode]
            get => this._cmdMoveDown;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                EventHandler eventHandler = new EventHandler( this.cmdMoveDown_Click );
                if ( this._cmdMoveDown != null )
                    this._cmdMoveDown.Click -= eventHandler;
                this._cmdMoveDown = value;
                if ( this._cmdMoveDown == null )
                    return;
                this._cmdMoveDown.Click += eventHandler;
            }
        }

        internal virtual Button cmdMoveUp
        {
            [DebuggerNonUserCode]
            get => this._cmdMoveUp;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                EventHandler eventHandler = new EventHandler( this.cmdMoveUp_Click );
                if ( this._cmdMoveUp != null )
                    this._cmdMoveUp.Click -= eventHandler;
                this._cmdMoveUp = value;
                if ( this._cmdMoveUp == null )
                    return;
                this._cmdMoveUp.Click += eventHandler;
            }
        }

        internal virtual Button cmdOK
        {
            [DebuggerNonUserCode]
            get => this._cmdOK;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                EventHandler eventHandler = new EventHandler( this.cmdOK_Click );
                if ( this._cmdOK != null )
                    this._cmdOK.Click -= eventHandler;
                this._cmdOK = value;
                if ( this._cmdOK == null )
                    return;
                this._cmdOK.Click += eventHandler;
            }
        }

        internal virtual Button cmdRemove
        {
            [DebuggerNonUserCode]
            get => this._cmdRemove;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                EventHandler eventHandler = new EventHandler( this.cmdRemove_Click );
                if ( this._cmdRemove != null )
                    this._cmdRemove.Click -= eventHandler;
                this._cmdRemove = value;
                if ( this._cmdRemove == null )
                    return;
                this._cmdRemove.Click += eventHandler;
            }
        }

        internal virtual GroupBox GroupBox1
        {
            [DebuggerNonUserCode]
            get => this._GroupBox1;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => this._GroupBox1 = value;
        }

        internal virtual Label Label1
        {
            [DebuggerNonUserCode]
            get => this._Label1;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => this._Label1 = value;
        }

        internal virtual Label Label2
        {
            [DebuggerNonUserCode]
            get => this._Label2;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => this._Label2 = value;
        }

        internal virtual Label Label3
        {
            [DebuggerNonUserCode]
            get => this._Label3;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => this._Label3 = value;
        }

        internal virtual Label Label4
        {
            [DebuggerNonUserCode]
            get => this._Label4;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => this._Label4 = value;
        }

        internal virtual Label Label5
        {
            [DebuggerNonUserCode]
            get => this._Label5;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => this._Label5 = value;
        }

        internal virtual Label Label6
        {
            [DebuggerNonUserCode]
            get => this._Label6;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => this._Label6 = value;
        }

        internal virtual ListBox lstAvailable
        {
            [DebuggerNonUserCode]
            get => this._lstAvailable;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                EventHandler eventHandler = new EventHandler( this.Plugins_SelectedIndexChanged );
                if ( this._lstAvailable != null )
                    this._lstAvailable.SelectedIndexChanged -= eventHandler;
                this._lstAvailable = value;
                if ( this._lstAvailable == null )
                    return;
                this._lstAvailable.SelectedIndexChanged += eventHandler;
            }
        }

        internal virtual ListBox lstLoaded
        {
            [DebuggerNonUserCode]
            get => this._lstLoaded;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set
            {
                EventHandler eventHandler = new EventHandler( this.Plugins_SelectedIndexChanged );
                if ( this._lstLoaded != null )
                    this._lstLoaded.SelectedIndexChanged -= eventHandler;
                this._lstLoaded = value;
                if ( this._lstLoaded == null )
                    return;
                this._lstLoaded.SelectedIndexChanged += eventHandler;
            }
        }

        internal virtual TextBox txtAuthor
        {
            [DebuggerNonUserCode]
            get => this._txtAuthor;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => this._txtAuthor = value;
        }

        internal virtual TextBox txtDescription
        {
            [DebuggerNonUserCode]
            get => this._txtDescription;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => this._txtDescription = value;
        }

        internal virtual TextBox txtEmail
        {
            [DebuggerNonUserCode]
            get => this._txtEmail;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => this._txtEmail = value;
        }

        internal virtual TextBox txtVersion
        {
            [DebuggerNonUserCode]
            get => this._txtVersion;
            [DebuggerNonUserCode, MethodImpl( MethodImplOptions.Synchronized )]
            set => this._txtVersion = value;
        }

        public PluginManager()
        {
            this.Load += new EventHandler( this.PluginManager_Load );
            lock ( PluginManager.__ENCList )
                PluginManager.__ENCList.Add( new WeakReference( this ) );
            this.InitializeComponent();
        }

        private void cmdAdd_Click( object sender, EventArgs e )
        {
            PluginInfo pluginInfo = (PluginInfo) this.lstAvailable.Items[this.lstAvailable.SelectedIndex];
            this.lstAvailable.Items.RemoveAt( this.lstAvailable.SelectedIndex );
            this.lstLoaded.Items.Add( pluginInfo );
        }

        private void cmdCancel_Click( object sender, EventArgs e )
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cmdMoveDown_Click( object sender, EventArgs e )
        {
            int selectedIndex = this.lstLoaded.SelectedIndex;
            if ( selectedIndex >= this.lstLoaded.Items.Count - 2 )
                return;
            object objectValue = RuntimeHelpers.GetObjectValue( this.lstLoaded.SelectedItem );
            this.lstLoaded.Items.RemoveAt( selectedIndex );
            this.lstLoaded.Items.Insert( selectedIndex + 1, RuntimeHelpers.GetObjectValue( objectValue ) );
            this.lstLoaded.SelectedIndex = selectedIndex + 1;
        }

        private void cmdMoveUp_Click( object sender, EventArgs e )
        {
            int selectedIndex = this.lstLoaded.SelectedIndex;
            if ( selectedIndex <= 0 )
                return;
            object objectValue = RuntimeHelpers.GetObjectValue( this.lstLoaded.SelectedItem );
            this.lstLoaded.Items.RemoveAt( selectedIndex );
            this.lstLoaded.Items.Insert( selectedIndex - 1, RuntimeHelpers.GetObjectValue( objectValue ) );
            this.lstLoaded.SelectedIndex = selectedIndex - 1;
        }

        private void cmdOK_Click( object sender, EventArgs e )
        {
            IEnumerator enumerator = null;
            MessageBox.Show( "You will need to restart the program for plugin changes to take effect." );
            PluginInfo[] pluginInfoArray = null;
            try
            {
                foreach ( object obj in this.lstLoaded.Items )
                {
                    PluginInfo objectValue = (PluginInfo) RuntimeHelpers.GetObjectValue( obj );
                    pluginInfoArray = pluginInfoArray != null ? (PluginInfo[]) Utils.CopyArray( pluginInfoArray, new PluginInfo[pluginInfoArray.Length + 1] ) : new PluginInfo[1];
                    pluginInfoArray[pluginInfoArray.Length - 1] = objectValue;
                }
            }
            finally
            {
                if ( enumerator is IDisposable )
                    ( enumerator as IDisposable ).Dispose();
            }
            this.MainForm.PluginTypesToLoad = pluginInfoArray;
            this.MainForm.WritePluginsToLoad();
            this.DialogResult = DialogResult.OK;
        }

        private void cmdRemove_Click( object sender, EventArgs e )
        {
            PluginInfo pluginInfo = (PluginInfo) this.lstLoaded.Items[this.lstLoaded.SelectedIndex];
            this.lstLoaded.Items.RemoveAt( this.lstLoaded.SelectedIndex );
            this.lstAvailable.Items.Add( pluginInfo );
        }

        protected override void Dispose( bool disposing )
        {
            if ( disposing && this.components != null )
                this.components.Dispose();
            base.Dispose( disposing );
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager resourceManager = new ResourceManager( typeof( PluginManager ) );
            this.Label1 = new Label();
            this.cmdMoveUp = new Button();
            this.cmdMoveDown = new Button();
            this.cmdOK = new Button();
            this.GroupBox1 = new GroupBox();
            this.txtDescription = new TextBox();
            this.txtVersion = new TextBox();
            this.txtEmail = new TextBox();
            this.txtAuthor = new TextBox();
            this.Label5 = new Label();
            this.Label4 = new Label();
            this.Label3 = new Label();
            this.Label2 = new Label();
            this.cmdCancel = new Button();
            this.cmdAdd = new Button();
            this.cmdRemove = new Button();
            this.lstAvailable = new ListBox();
            this.Label6 = new Label();
            this.lstLoaded = new ListBox();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            this.Label1.AutoSize = true;
            Point point = new Point( 8, 8 );
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            Size size = new Size( 82, 16 );
            this.Label1.Size = size;
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Loaded Plugins";
            this.cmdMoveUp.Enabled = false;
            this.cmdMoveUp.Image = (Image) resourceManager.GetObject( "cmdMoveUp.Image" );
            point = new Point( 152, 24 );
            this.cmdMoveUp.Location = point;
            this.cmdMoveUp.Name = "cmdMoveUp";
            size = new Size( 24, 32 );
            this.cmdMoveUp.Size = size;
            this.cmdMoveUp.TabIndex = 3;
            this.cmdMoveDown.Enabled = false;
            this.cmdMoveDown.Image = (Image) resourceManager.GetObject( "cmdMoveDown.Image" );
            point = new Point( 152, 104 );
            this.cmdMoveDown.Location = point;
            this.cmdMoveDown.Name = "cmdMoveDown";
            size = new Size( 24, 32 );
            this.cmdMoveDown.Size = size;
            this.cmdMoveDown.TabIndex = 4;
            this.cmdOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            point = new Point( 176, 304 );
            this.cmdOK.Location = point;
            this.cmdOK.Name = "cmdOK";
            size = new Size( 72, 23 );
            this.cmdOK.Size = size;
            this.cmdOK.TabIndex = 6;
            this.cmdOK.Text = "OK";
            this.GroupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.GroupBox1.Controls.Add( this.txtDescription );
            this.GroupBox1.Controls.Add( this.txtVersion );
            this.GroupBox1.Controls.Add( this.txtEmail );
            this.GroupBox1.Controls.Add( this.txtAuthor );
            this.GroupBox1.Controls.Add( this.Label5 );
            this.GroupBox1.Controls.Add( this.Label4 );
            this.GroupBox1.Controls.Add( this.Label3 );
            this.GroupBox1.Controls.Add( this.Label2 );
            point = new Point( 8, 144 );
            this.GroupBox1.Location = point;
            this.GroupBox1.Name = "GroupBox1";
            size = new Size( 328, 152 );
            this.GroupBox1.Size = size;
            this.GroupBox1.TabIndex = 7;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Description";
            point = new Point( 72, 88 );
            this.txtDescription.Location = point;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.ScrollBars = ScrollBars.Vertical;
            size = new Size( 248, 56 );
            this.txtDescription.Size = size;
            this.txtDescription.TabIndex = 7;
            this.txtDescription.Text = "";
            point = new Point( 72, 64 );
            this.txtVersion.Location = point;
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.ReadOnly = true;
            size = new Size( 248, 20 );
            this.txtVersion.Size = size;
            this.txtVersion.TabIndex = 6;
            this.txtVersion.Text = "";
            point = new Point( 72, 40 );
            this.txtEmail.Location = point;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            size = new Size( 248, 20 );
            this.txtEmail.Size = size;
            this.txtEmail.TabIndex = 5;
            this.txtEmail.Text = "";
            point = new Point( 72, 16 );
            this.txtAuthor.Location = point;
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.ReadOnly = true;
            size = new Size( 248, 20 );
            this.txtAuthor.Size = size;
            this.txtAuthor.TabIndex = 4;
            this.txtAuthor.Text = "";
            this.Label5.AutoSize = true;
            point = new Point( 8, 88 );
            this.Label5.Location = point;
            this.Label5.Name = "Label5";
            size = new Size( 61, 16 );
            this.Label5.Size = size;
            this.Label5.TabIndex = 3;
            this.Label5.Text = "Description";
            this.Label4.AutoSize = true;
            point = new Point( 8, 64 );
            this.Label4.Location = point;
            this.Label4.Name = "Label4";
            size = new Size( 43, 16 );
            this.Label4.Size = size;
            this.Label4.TabIndex = 2;
            this.Label4.Text = "Version";
            this.Label3.AutoSize = true;
            point = new Point( 8, 40 );
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new Size( 33, 16 );
            this.Label3.Size = size;
            this.Label3.TabIndex = 1;
            this.Label3.Text = "Email";
            this.Label2.AutoSize = true;
            point = new Point( 8, 16 );
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size( 38, 16 );
            this.Label2.Size = size;
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Author";
            this.cmdCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.cmdCancel.DialogResult = DialogResult.Cancel;
            point = new Point( 264, 304 );
            this.cmdCancel.Location = point;
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.TabIndex = 8;
            this.cmdCancel.Text = "Cancel";
            this.cmdAdd.Enabled = false;
            this.cmdAdd.Image = (Image) resourceManager.GetObject( "cmdAdd.Image" );
            point = new Point( 152, 56 );
            this.cmdAdd.Location = point;
            this.cmdAdd.Name = "cmdAdd";
            size = new Size( 40, 23 );
            this.cmdAdd.Size = size;
            this.cmdAdd.TabIndex = 9;
            this.cmdRemove.Enabled = false;
            this.cmdRemove.Image = (Image) resourceManager.GetObject( "cmdRemove.Image" );
            point = new Point( 152, 80 );
            this.cmdRemove.Location = point;
            this.cmdRemove.Name = "cmdRemove";
            size = new Size( 40, 23 );
            this.cmdRemove.Size = size;
            this.cmdRemove.TabIndex = 10;
            this.lstAvailable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            this.lstAvailable.IntegralHeight = false;
            point = new Point( 192, 24 );
            this.lstAvailable.Location = point;
            this.lstAvailable.Name = "lstAvailable";
            size = new Size( 144, 112 );
            this.lstAvailable.Size = size;
            this.lstAvailable.TabIndex = 11;
            this.Label6.AutoSize = true;
            point = new Point( 184, 8 );
            this.Label6.Location = point;
            this.Label6.Name = "Label6";
            size = new Size( 91, 16 );
            this.Label6.Size = size;
            this.Label6.TabIndex = 12;
            this.Label6.Text = "Available Plugins";
            this.lstLoaded.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            this.lstLoaded.IntegralHeight = false;
            point = new Point( 8, 24 );
            this.lstLoaded.Location = point;
            this.lstLoaded.Name = "lstLoaded";
            size = new Size( 144, 112 );
            this.lstLoaded.Size = size;
            this.lstLoaded.TabIndex = 13;
            this.AcceptButton = this.cmdOK;
            size = new Size( 5, 13 );
            this.AutoScaleBaseSize = size;
            this.CancelButton = this.cmdCancel;
            size = new Size( 344, 336 );
            this.ClientSize = size;
            this.Controls.Add( this.lstLoaded );
            this.Controls.Add( this.Label6 );
            this.Controls.Add( this.lstAvailable );
            this.Controls.Add( this.cmdCancel );
            this.Controls.Add( this.GroupBox1 );
            this.Controls.Add( this.cmdOK );
            this.Controls.Add( this.Label1 );
            this.Controls.Add( this.cmdRemove );
            this.Controls.Add( this.cmdAdd );
            this.Controls.Add( this.cmdMoveDown );
            this.Controls.Add( this.cmdMoveUp );
            this.MaximizeBox = false;
            size = new Size( 352, 1200 );
            this.MaximumSize = size;
            this.MinimizeBox = false;
            size = new Size( 352, 370 );
            this.MinimumSize = size;
            this.Name = nameof( PluginManager );
            this.Text = "Plugin Manager";
            this.GroupBox1.ResumeLayout( false );
            this.ResumeLayout( false );
        }

        private void PluginManager_Load( object sender, EventArgs e )
        {
            IEnumerator enumerator1 = null;
            this.lstLoaded.Items.Clear();
            this.lstAvailable.Items.Clear();
            if ( this.OrderList != null )
            {
                foreach ( PluginInfo order in this.OrderList )
                {
                    IEnumerator enumerator2 = null;
                    bool flag = false;
                    try
                    {
                        foreach ( object availablePlugin in this.AvailablePlugins )
                        {
                            if ( ( (BasePlugin) RuntimeHelpers.GetObjectValue( availablePlugin ) ).GetPluginInfo().Equals( order ) )
                                flag = true;
                        }
                    }
                    finally
                    {
                        if ( enumerator2 is IDisposable )
                            ( enumerator2 as IDisposable ).Dispose();
                    }
                    if ( flag )
                        this.lstLoaded.Items.Add( order );
                }
            }
            try
            {
                foreach ( object availablePlugin in this.AvailablePlugins )
                {
                    BasePlugin objectValue = (BasePlugin) RuntimeHelpers.GetObjectValue( availablePlugin );
                    if ( !objectValue.IsLoaded )
                        this.lstAvailable.Items.Add( objectValue.GetPluginInfo() );
                }
            }
            finally
            {
                if ( enumerator1 is IDisposable )
                    ( enumerator1 as IDisposable ).Dispose();
            }
        }

        private void Plugins_SelectedIndexChanged( object sender, EventArgs e )
        {
            ListBox listBox = (ListBox) sender;
            if ( listBox.SelectedIndex == -1 )
                return;
            PluginInfo selectedItem = (PluginInfo) listBox.SelectedItem;
            this.txtAuthor.Text = selectedItem.AuthorName;
            this.txtEmail.Text = selectedItem.AuthorEmail;
            this.txtVersion.Text = selectedItem.Version;
            this.txtDescription.Text = selectedItem.Description;
            if ( this.lstLoaded.SelectedIndex > 0 )
                this.cmdMoveUp.Enabled = true;
            else
                this.cmdMoveUp.Enabled = false;
            if ( this.lstLoaded.SelectedIndex < listBox.Items.Count - 1 )
                this.cmdMoveDown.Enabled = true;
            else
                this.cmdMoveDown.Enabled = false;
            if ( this.lstAvailable.SelectedIndex == -1 )
                this.cmdAdd.Enabled = false;
            else
                this.cmdAdd.Enabled = true;
            if ( this.lstLoaded.SelectedIndex == -1 )
                this.cmdRemove.Enabled = false;
            else
                this.cmdRemove.Enabled = true;
        }
    }
}
