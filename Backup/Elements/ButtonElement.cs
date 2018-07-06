// Decompiled with JetBrains decompiler
// Type: GumpStudio.Elements.ButtonElement
// Assembly: GumpStudioCore, Version=1.8.3024.24259, Culture=neutral, PublicKeyToken=null
// MVID: A77D32E5-7519-4865-AA26-DCCB34429732
// Assembly location: C:\GumpStudio_1_8_R3_quinted-02\GumpStudioCore.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.Serialization;
using Ultima;

namespace GumpStudio.Elements
{
  [Serializable]
  public class ButtonElement : BaseElement
  {
    protected Bitmap Cache;
    protected string mCodeBehind;
    protected int mNormalID;
    protected int mParam;
    protected int mPressedID;
    protected ButtonStateEnum mState;
    protected ButtonTypeEnum mType;

    [Description("The Type of button. Page buttons change the current page, and Reply buttons return a value to the script.")]
    public ButtonTypeEnum ButtonType
    {
      get
      {
        return this.mType;
      }
      set
      {
        this.mType = value;
        this.RefreshCache();
      }
    }

    [Editor(typeof (LargeTextPropEditor), typeof (UITypeEditor))]
    [Description("This contains script code to be executed when this button is pressed. (must be supported by the export plugin)")]
    public string Code
    {
      get
      {
        return this.mCodeBehind;
      }
      set
      {
        this.mCodeBehind = value;
      }
    }

    [Description("The ID of the image to display when the button is not being pressed.")]
    [Editor(typeof (GumpIDPropEditor), typeof (UITypeEditor))]
    public int NormalID
    {
      get
      {
        return this.mNormalID;
      }
      set
      {
        this.mNormalID = value;
        this.RefreshCache();
      }
    }

    [Description("For Page Buttons this represents the page to switch to.  For Reply buttons this represents the value to return to the script.")]
    public int Param
    {
      get
      {
        return this.mParam;
      }
      set
      {
        this.mParam = value;
      }
    }

    [Description("The ID of the image to display when the button is being pressed by the user.")]
    [Editor(typeof (GumpIDPropEditor), typeof (UITypeEditor))]
    public int PressedID
    {
      get
      {
        return this.mPressedID;
      }
      set
      {
        this.mPressedID = value;
        this.RefreshCache();
      }
    }

    [Description("Change this to see the button in it's different states.")]
    public ButtonStateEnum State
    {
      get
      {
        return this.mState;
      }
      set
      {
        this.mState = value;
        this.RefreshCache();
      }
    }

    public override string Type
    {
      get
      {
        return "Button";
      }
    }

    public ButtonElement()
    {
      this.mType = ButtonTypeEnum.Reply;
      this.mState = ButtonStateEnum.Normal;
      this.mType = ButtonTypeEnum.Reply;
      this.mState = ButtonStateEnum.Normal;
      this.mPressedID = 248;
      this.mNormalID = 247;
      this.RefreshCache();
    }

    protected ButtonElement(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
      this.mType = ButtonTypeEnum.Reply;
      this.mState = ButtonStateEnum.Normal;
      info.GetInt32("ButtonElementVersion");
      this.mPressedID = info.GetInt32(nameof (PressedID));
      this.mNormalID = info.GetInt32(nameof (NormalID));
      this.mType = (ButtonTypeEnum) info.GetInt32(nameof (Type));
      this.mState = (ButtonStateEnum) info.GetInt32(nameof (State));
      this.mCodeBehind = info.GetString("CodeBehind");
      this.mParam = info.GetInt32(nameof (Param));
      this.RefreshCache();
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      base.GetObjectData(info, context);
      info.AddValue("ButtonElementVersion", 1);
      info.AddValue("PressedID", this.mPressedID);
      info.AddValue("NormalID", this.mNormalID);
      info.AddValue("Type", (int) this.mType);
      info.AddValue("State", (int) this.mState);
      info.AddValue("CodeBehind", (object) this.mCodeBehind);
      info.AddValue("Param", this.mParam);
    }

    public override void RefreshCache()
    {
      if (this.Cache != null)
        this.Cache.Dispose();
      this.Cache = this.mState != ButtonStateEnum.Normal ? Gumps.GetGump(this.mPressedID) : Gumps.GetGump(this.mNormalID);
      if (this.Cache == null)
        return;
      this.mSize = this.Cache.Size;
    }

    public override void Render(Graphics Target)
    {
      if (this.Cache == null)
        this.RefreshCache();
      Target.DrawImage((Image) this.Cache, this.Location);
    }
  }
}
