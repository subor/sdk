/**
 * Autogenerated by Thrift Compiler (0.11.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace Ruyi.SDK.SettingSystem.Api
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class SettingSearchResult : TBase
  {
    private string _Version;
    private List<Ruyi.SDK.CommonType.SettingItem> _SettingItems;

    public string Version
    {
      get
      {
        return _Version;
      }
      set
      {
        __isset.Version = true;
        this._Version = value;
      }
    }

    public List<Ruyi.SDK.CommonType.SettingItem> SettingItems
    {
      get
      {
        return _SettingItems;
      }
      set
      {
        __isset.SettingItems = true;
        this._SettingItems = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool Version;
      public bool SettingItems;
    }

    public SettingSearchResult() {
    }

    public void Read (TProtocol iprot)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.String) {
                Version = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.List) {
                {
                  SettingItems = new List<Ruyi.SDK.CommonType.SettingItem>();
                  TList _list8 = iprot.ReadListBegin();
                  for( int _i9 = 0; _i9 < _list8.Count; ++_i9)
                  {
                    Ruyi.SDK.CommonType.SettingItem _elem10;
                    _elem10 = new Ruyi.SDK.CommonType.SettingItem();
                    _elem10.Read(iprot);
                    SettingItems.Add(_elem10);
                  }
                  iprot.ReadListEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }
      finally
      {
        iprot.DecrementRecursionDepth();
      }
    }

    public void Write(TProtocol oprot) {
      oprot.IncrementRecursionDepth();
      try
      {
        TStruct struc = new TStruct("SettingSearchResult");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (Version != null && __isset.Version) {
          field.Name = "Version";
          field.Type = TType.String;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Version);
          oprot.WriteFieldEnd();
        }
        if (SettingItems != null && __isset.SettingItems) {
          field.Name = "SettingItems";
          field.Type = TType.List;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteListBegin(new TList(TType.Struct, SettingItems.Count));
            foreach (Ruyi.SDK.CommonType.SettingItem _iter11 in SettingItems)
            {
              _iter11.Write(oprot);
            }
            oprot.WriteListEnd();
          }
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }
      finally
      {
        oprot.DecrementRecursionDepth();
      }
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("SettingSearchResult(");
      bool __first = true;
      if (Version != null && __isset.Version) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Version: ");
        __sb.Append(Version);
      }
      if (SettingItems != null && __isset.SettingItems) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("SettingItems: ");
        __sb.Append(SettingItems);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
