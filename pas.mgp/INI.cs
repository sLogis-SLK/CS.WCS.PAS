// Decompiled with JetBrains decompiler
// Type: pas.mgp.INI
// Assembly: pas.mgp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CA03B7AC-3AB6-4BAB-9133-D086CEC3F322
// Assembly location: C:\Users\User\Desktop\pas_20170601\pas_20170601\pas.mgp.exe

using System.Runtime.InteropServices;
using System.Text;

// #nullable disable
// namespace pas.mgp;

public class INI
{
  private string Path { get; set; }

  public INI(string sPath) => this.Path = sPath;

  [DllImport("kernel32.dll")]
  private static extern int GetPrivateProfileString(
    string section,
    string key,
    string def,
    StringBuilder retVal,
    int size,
    string filePath);

  [DllImport("kernel32.dll")]
  private static extern long WritePrivateProfileString(
    string section,
    string key,
    string val,
    string filePath);

  public string GetIniValue(INI_SECTION section, INI_KEY key)
  {
    return this.GetIniValue(section.ToString(), key.ToString());
  }

  public string GetIniValue(string section, string key)
  {
    StringBuilder retVal = new StringBuilder(4096 /*0x1000*/);
    INI.GetPrivateProfileString(section, key, "", retVal, 4096 /*0x1000*/, this.Path);
    return retVal.ToString();
  }

  public void SetIniValue(INI_SECTION section, INI_KEY key, string value)
  {
    this.SetIniValue(section.ToString(), key.ToString(), value);
  }

  public void SetIniValue(string section, string key, string value)
  {
    INI.WritePrivateProfileString(section, key, value, this.Path);
  }
}
