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

namespace Ruyi.SDK.Speech
{

  /// <summary>
  /// @VoiceCommand_desc
  /// </summary>
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class VoiceCommand : TBase
  {
    private string _Filename;
    private byte[] _RawData;

    /// <summary>
    /// @VoiceCommand_Filename_desc
    /// </summary>
    public string Filename
    {
      get
      {
        return _Filename;
      }
      set
      {
        __isset.Filename = true;
        this._Filename = value;
      }
    }

    /// <summary>
    /// @VoiceCommand_RawData_desc
    /// </summary>
    public byte[] RawData
    {
      get
      {
        return _RawData;
      }
      set
      {
        __isset.RawData = true;
        this._RawData = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool Filename;
      public bool RawData;
    }

    public VoiceCommand() {
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
                Filename = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.String) {
                RawData = iprot.ReadBinary();
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
        TStruct struc = new TStruct("VoiceCommand");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (Filename != null && __isset.Filename) {
          field.Name = "Filename";
          field.Type = TType.String;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Filename);
          oprot.WriteFieldEnd();
        }
        if (RawData != null && __isset.RawData) {
          field.Name = "RawData";
          field.Type = TType.String;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          oprot.WriteBinary(RawData);
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
      StringBuilder __sb = new StringBuilder("VoiceCommand(");
      bool __first = true;
      if (Filename != null && __isset.Filename) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Filename: ");
        __sb.Append(Filename);
      }
      if (RawData != null && __isset.RawData) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("RawData: ");
        __sb.Append(RawData);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
