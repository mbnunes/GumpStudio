// Decompiled with JetBrains decompiler
// Type: GumpStudio.Elements.GumpProperties
// Assembly: GumpStudioCore, Version=1.8.3024.24259, Culture=neutral, PublicKeyToken=null
// MVID: A77D32E5-7519-4865-AA26-DCCB34429732
// Assembly location: C:\GumpStudio_1_8_R3_quinted-02\GumpStudioCore.dll

using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace GumpStudio.Elements
{
  [Serializable]
  public class GumpProperties : ISerializable, ICloneable
  {
    protected bool mCloseable;
    protected bool mDisposeable;
    protected Point mLocation;
    protected bool mMoveable;
    protected int mType;

    public bool Closeable
    {
      get
      {
        return this.mCloseable;
      }
      set
      {
        this.mCloseable = value;
      }
    }

    public bool Disposeable
    {
      get
      {
        return this.mDisposeable;
      }
      set
      {
        this.mDisposeable = value;
      }
    }

    public Point Location
    {
      get
      {
        return this.mLocation;
      }
      set
      {
        this.mLocation = value;
      }
    }

    public bool Moveable
    {
      get
      {
        return this.mMoveable;
      }
      set
      {
        this.mMoveable = value;
      }
    }

    public int Type
    {
      get
      {
        return this.mType;
      }
      set
      {
        this.mType = value;
      }
    }

    public GumpProperties()
    {
      this.mMoveable = true;
      this.mCloseable = true;
      this.mDisposeable = true;
    }

    protected GumpProperties(SerializationInfo info, StreamingContext context)
    {
      this.mMoveable = true;
      this.mCloseable = true;
      this.mDisposeable = true;
      info.GetInt32("Version");
      this.mLocation = (Point) info.GetValue(nameof (Location), typeof (Point));
      this.mMoveable = info.GetBoolean(nameof (Moveable));
      this.mCloseable = info.GetBoolean(nameof (Closeable));
      this.mDisposeable = info.GetBoolean(nameof (Disposeable));
      this.mType = info.GetInt32(nameof (Type));
    }

    public object Clone()
    {
      return this.MemberwiseClone();
    }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      info.AddValue("Version", 1);
      info.AddValue("Location", (object) this.mLocation);
      info.AddValue("Moveable", this.mMoveable);
      info.AddValue("Closeable", this.mCloseable);
      info.AddValue("Disposeable", this.mDisposeable);
      info.AddValue("Type", this.mType);
    }
  }
}
