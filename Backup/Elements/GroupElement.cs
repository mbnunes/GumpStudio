// Decompiled with JetBrains decompiler
// Type: GumpStudio.Elements.GroupElement
// Assembly: GumpStudioCore, Version=1.8.3024.24259, Culture=neutral, PublicKeyToken=null
// MVID: A77D32E5-7519-4865-AA26-DCCB34429732
// Assembly location: C:\GumpStudio_1_8_R3_quinted-02\GumpStudioCore.dll

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace GumpStudio.Elements
{
  [Serializable]
  public class GroupElement : BaseElement
  {
    internal ArrayList mElements;
    internal bool mIsBaseWindow;

    public BaseElement[] Elements
    {
      get
      {
        BaseElement[] baseElementArray = (BaseElement[]) null;
        IEnumerator enumerator = (IEnumerator) null;
        try
        {
          foreach (object mElement in this.mElements)
          {
            BaseElement objectValue = (BaseElement) RuntimeHelpers.GetObjectValue(mElement);
            baseElementArray = baseElementArray != null ? (BaseElement[]) Utils.CopyArray((Array) baseElementArray, (Array) new BaseElement[baseElementArray.Length + 1]) : new BaseElement[1];
            baseElementArray[baseElementArray.Length - 1] = objectValue;
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        return baseElementArray;
      }
    }

    public int Items
    {
      get
      {
        return this.mElements.Count;
      }
    }

    public override string Type
    {
      get
      {
        return "Group";
      }
    }

    public GroupElement(GroupElement Parent)
      : this(Parent, (ArrayList) null, (string) null, false)
    {
    }

    protected GroupElement(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
      this.mIsBaseWindow = false;
      info.GetInt32("GroupElementVersion");
      this.mElements = (ArrayList) info.GetValue(nameof (Elements), typeof (ArrayList));
      this.mIsBaseWindow = info.GetBoolean("IsBaseWindow");
    }

    public GroupElement(GroupElement Parent, ArrayList Elements, string Name)
      : this(Parent, Elements, Name, false)
    {
    }

    public GroupElement(GroupElement Parent, ArrayList Elements, string Name, bool IsBaseWindow)
    {
      this.mIsBaseWindow = false;
      this.mIsBaseWindow = IsBaseWindow;
      this.mElements = new ArrayList();
      if (Name != null)
        this.mName = Name;
      if (Elements != null)
      {
        IEnumerator enumerator = (IEnumerator) null;
        try
        {
          foreach (object element in Elements)
            this.mElements.Add((object) (BaseElement) RuntimeHelpers.GetObjectValue(element));
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
      }
      this.Location = new Point(0, 0);
    }

    public override void AddContextMenus(ref MenuItem GroupMenu, ref MenuItem PositionMenu, ref MenuItem OrderMenu, ref MenuItem MiscMenu)
    {
      base.AddContextMenus(ref GroupMenu, ref PositionMenu, ref OrderMenu, ref MiscMenu);
      if (this.mParent.GetSelectedElements().Count > 1)
        GroupMenu.MenuItems.Add(new MenuItem("Add Selection to Group", new EventHandler(this.DoAddMenu)));
      GroupMenu.MenuItems.Add(new MenuItem("Break Group", new EventHandler(this.DoBreakGroupMenu)));
      MiscMenu.MenuItems.Add(new MenuItem("Export Gumpling", new EventHandler(this.DoExportGumplingMenu)));
    }

    public virtual void AddElement(BaseElement e)
    {
      if (this.mElements.Contains((object) e))
        return;
      if (!this.mIsBaseWindow)
      {
        Rectangle rectangle;
        if (this.mElements.Count == 0)
        {
          rectangle = e.Bounds;
        }
        else
        {
          rectangle = Rectangle.Union(this.Bounds, e.Bounds);
          if (this.X != rectangle.X | this.Y != rectangle.Y)
          {
            IEnumerator enumerator = (IEnumerator) null;
            int dx = this.X - rectangle.X;
            int dy = this.Y - rectangle.Y;
            try
            {
              foreach (object mElement in this.mElements)
              {
                BaseElement objectValue = (BaseElement) RuntimeHelpers.GetObjectValue(mElement);
                Point location = objectValue.Location;
                location.Offset(dx, dy);
                objectValue.Location = location;
              }
            }
            finally
            {
              if (enumerator is IDisposable)
                (enumerator as IDisposable).Dispose();
            }
          }
        }
        this.Location = rectangle.Location;
        this.mSize = rectangle.Size;
        Point location1 = e.Location;
        location1.X -= rectangle.Location.X;
        location1.Y -= rectangle.Location.Y;
        e.Location = location1;
      }
      this.mElements.Add((object) e);
      e.Reparent(this);
      this.AttachEvents(e);
    }

    public void AttachEvents(BaseElement Element)
    {
      Element.UpdateParent += new BaseElement.UpdateParentEventHandler(((BaseElement) this).RaiseUpdateEvent);
      Element.Repaint += new BaseElement.RepaintEventHandler(((BaseElement) this).RaiseRepaintEvent);
    }

    public void BreakGroup()
    {
      IEnumerator enumerator = (IEnumerator) null;
      try
      {
        foreach (object mElement in this.mElements)
        {
          BaseElement objectValue = (BaseElement) RuntimeHelpers.GetObjectValue(mElement);
          this.mParent.AddElement(objectValue);
          objectValue.Selected = true;
          Point point = new Point(this.X + objectValue.X, this.Y + objectValue.Y);
          objectValue.Location = point;
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.mParent.RemoveElement((BaseElement) this);
    }

    protected override object CloneMe()
    {
      IEnumerator enumerator = (IEnumerator) null;
      GroupElement Parent = (GroupElement) base.CloneMe();
      Parent.mElements = new ArrayList();
      try
      {
        foreach (object mElement in this.mElements)
        {
          BaseElement Element = ((BaseElement) RuntimeHelpers.GetObjectValue(mElement)).Clone();
          Parent.mElements.Add((object) Element);
          Parent.AttachEvents(Element);
          Element.Reparent(Parent);
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      return (object) Parent;
    }

    public override void DebugDump()
    {
      IEnumerator enumerator = (IEnumerator) null;
      base.DebugDump();
      try
      {
        foreach (object mElement in this.mElements)
          ((BaseElement) RuntimeHelpers.GetObjectValue(mElement)).DebugDump();
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    protected void DoAddMenu(object sender, EventArgs e)
    {
      IEnumerator enumerator = (IEnumerator) null;
      ArrayList arrayList = new ArrayList();
      arrayList.AddRange((ICollection) this.mParent.GetElements());
      try
      {
        foreach (object obj in arrayList)
        {
          BaseElement objectValue = (BaseElement) RuntimeHelpers.GetObjectValue(obj);
          if (objectValue != this & objectValue.Selected)
          {
            this.AddElement(objectValue);
            this.mParent.RemoveElement(objectValue);
            objectValue.Selected = false;
          }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    protected void DoBreakGroupMenu(object sender, EventArgs e)
    {
      this.BreakGroup();
      this.mParent.RaiseUpdateEvent((BaseElement) null, false);
      GlobalObjects.DesignerForm.CreateUndoPoint();
    }

    protected void DoExportGumplingMenu(object sender, EventArgs e)
    {
      try
      {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "Gumpling|*.gumpling";
        saveFileDialog.AddExtension = true;
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
          GroupElement mParent = this.mParent;
          this.mParent.RemoveElement((BaseElement) this);
          this.mParent = (GroupElement) null;
          FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create);
          new BinaryFormatter().Serialize((Stream) fileStream, (object) this);
          fileStream.Close();
          this.mParent = mParent;
          this.mParent.AddElement((BaseElement) this);
        }
        saveFileDialog.Dispose();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) Interaction.MsgBox((object) ex.Message, MsgBoxStyle.OkOnly, (object) null);
        ProjectData.ClearProjectError();
      }
    }

    public BaseElement GetElementFromPoint(Point p)
    {
      BaseElement baseElement = (BaseElement) null;
      IEnumerator enumerator = (IEnumerator) null;
      try
      {
        foreach (object mElement in this.mElements)
        {
          BaseElement objectValue = (BaseElement) RuntimeHelpers.GetObjectValue(mElement);
          Rectangle bounds = objectValue.Bounds;
          bounds.Inflate(7, 7);
          if (bounds.Contains(p))
            baseElement = objectValue;
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      return baseElement;
    }

    public ArrayList GetElements()
    {
      return this.mElements;
    }

    public ArrayList GetElementsRecursive()
    {
      IEnumerator enumerator = (IEnumerator) null;
      ArrayList arrayList = new ArrayList();
      try
      {
        foreach (object mElement in this.mElements)
        {
          object objectValue = RuntimeHelpers.GetObjectValue(mElement);
          if (objectValue is GroupElement)
            arrayList.AddRange((ICollection) ((GroupElement) objectValue).GetElementsRecursive());
          else
            arrayList.Add(RuntimeHelpers.GetObjectValue(objectValue));
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      return arrayList;
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      base.GetObjectData(info, context);
      info.AddValue("GroupElementVersion", 1);
      info.AddValue("Elements", (object) this.mElements);
      info.AddValue("IsBaseWindow", this.mIsBaseWindow);
    }

    public ArrayList GetSelectedElements()
    {
      IEnumerator enumerator = (IEnumerator) null;
      ArrayList arrayList = new ArrayList();
      try
      {
        foreach (object mElement in this.mElements)
        {
          BaseElement objectValue = (BaseElement) RuntimeHelpers.GetObjectValue(mElement);
          if (objectValue.Selected)
            arrayList.Add((object) objectValue);
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      return arrayList;
    }

    public void RecalculateBounds()
    {
      int count = this.mElements.Count;
      if (count < 1)
        return;
      Rectangle a = ((BaseElement) this.mElements[0]).Bounds;
      if (count >= 2)
      {
        int num = count - 1;
        for (int index = 1; index <= num; ++index)
          a = Rectangle.Union(a, ((BaseElement) this.mElements[index]).Bounds);
      }
      this.mSize = a.Size;
      this.RaiseRepaintEvent((object) this);
    }

    public override void RefreshCache()
    {
      IEnumerator enumerator = (IEnumerator) null;
      try
      {
        foreach (object mElement in this.mElements)
          ((BaseElement) RuntimeHelpers.GetObjectValue(mElement)).RefreshCache();
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    public void RemoveElement(BaseElement e)
    {
      this.mElements.Remove((object) e);
      this.RemoveEvents(e);
    }

    public void RemoveEvents(BaseElement Element)
    {
      Element.UpdateParent -= new BaseElement.UpdateParentEventHandler(((BaseElement) this).RaiseUpdateEvent);
      Element.Repaint -= new BaseElement.RepaintEventHandler(((BaseElement) this).RaiseRepaintEvent);
    }

    public override void Render(Graphics Target)
    {
      IEnumerator enumerator = (IEnumerator) null;
      Target.TranslateTransform((float) this.X, (float) this.Y);
      try
      {
        foreach (object mElement in this.mElements)
          ((BaseElement) RuntimeHelpers.GetObjectValue(mElement)).Render(Target);
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      Target.TranslateTransform((float) -this.X, (float) -this.Y);
    }
  }
}
