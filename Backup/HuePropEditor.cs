// Decompiled with JetBrains decompiler
// Type: GumpStudio.HuePropEditor
// Assembly: GumpStudioCore, Version=1.8.3024.24259, Culture=neutral, PublicKeyToken=null
// MVID: A77D32E5-7519-4865-AA26-DCCB34429732
// Assembly location: C:\GumpStudio_1_8_R3_quinted-02\GumpStudioCore.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Security.Permissions;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Ultima;

namespace GumpStudio
{
  public class HuePropEditor : UITypeEditor
  {
    protected IWindowsFormsEditorService edSvc;
    protected Hue ReturnValue;

    protected static Color Convert555ToARGB(short Col)
    {
      return Color.FromArgb(((int) (short) ((int) Col >> 10) & 31) * 8, ((int) (short) ((int) Col >> 5) & 31) * 8, ((int) Col & 31) * 8);
    }

    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
    {
      if (value == null)
        value = (object) Hues.GetHue(0);
      if (value.GetType() == typeof (Hue))
      {
        this.edSvc = (IWindowsFormsEditorService) provider.GetService(typeof (IWindowsFormsEditorService));
        if (this.edSvc != null)
        {
          HuePickerControl huePickerControl = new HuePickerControl((Hue) value);
          huePickerControl.ValueChanged += new HuePickerControl.ValueChangedEventHandler(this.ValueSelected);
          this.edSvc.DropDownControl((Control) huePickerControl);
          if (this.ReturnValue != null)
          {
            huePickerControl.Dispose();
            return (object) this.ReturnValue;
          }
          huePickerControl.Dispose();
        }
      }
      return value;
    }

    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
    {
      return UITypeEditorEditStyle.DropDown;
    }

    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public override bool GetPaintValueSupported(ITypeDescriptorContext context)
    {
      return true;
    }

    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public override void PaintValue(PaintValueEventArgs e)
    {
      Graphics graphics = e.Graphics;
      graphics.FillRectangle(Brushes.White, e.Bounds);
      float num1 = (float) (e.Bounds.Width - 3) / 32f;
      Hue hue = (Hue) e.Value;
      if (hue == null)
        return;
      int num2 = 0;
      foreach (short color in hue.Colors)
      {
        Rectangle bounds = e.Bounds;
        int x = (int) Math.Round((double) bounds.X + (double) num2 * (double) num1);
        bounds = e.Bounds;
        int y = bounds.Y;
        int width = (int) Math.Round((double) num1) + 1;
        bounds = e.Bounds;
        int height = bounds.Height;
        Rectangle rect = new Rectangle(x, y, width, height);
        graphics.FillRectangle((Brush) new SolidBrush(HuePropEditor.Convert555ToARGB(color)), rect);
        ++num2;
      }
    }

    protected void ValueSelected(Hue Hue)
    {
      this.edSvc.CloseDropDown();
      this.ReturnValue = Hue;
    }
  }
}
