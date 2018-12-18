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

namespace Ruyi.SDK.InputManager
{

  /// <summary>
  /// @RuyiJoystickInput_desc
  /// </summary>
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class RuyiJoystickInput : TBase
  {
    private string _DeviceId;
    private string _UserId;
    private int _RawOffset;
    private int _Value;
    private int _Timestamp;
    private int _Sequence;
    private JoystickOffset _Offset;

    /// <summary>
    /// @RuyiJoystickInput_DeviceId_desc
    /// </summary>
    public string DeviceId
    {
      get
      {
        return _DeviceId;
      }
      set
      {
        __isset.DeviceId = true;
        this._DeviceId = value;
      }
    }

    /// <summary>
    /// @RuyiJoystickInput_UserId_desc
    /// </summary>
    public string UserId
    {
      get
      {
        return _UserId;
      }
      set
      {
        __isset.UserId = true;
        this._UserId = value;
      }
    }

    /// <summary>
    /// @RuyiJoystickInput_RawOffset_desc
    /// </summary>
    public int RawOffset
    {
      get
      {
        return _RawOffset;
      }
      set
      {
        __isset.RawOffset = true;
        this._RawOffset = value;
      }
    }

    /// <summary>
    /// @RuyiJoystickInput_Value_desc
    /// </summary>
    public int Value
    {
      get
      {
        return _Value;
      }
      set
      {
        __isset.@Value = true;
        this._Value = value;
      }
    }

    /// <summary>
    /// @RuyiJoystickInput_Timestamp_desc
    /// </summary>
    public int Timestamp
    {
      get
      {
        return _Timestamp;
      }
      set
      {
        __isset.Timestamp = true;
        this._Timestamp = value;
      }
    }

    /// <summary>
    /// @RuyiJoystickInput_Sequence_desc
    /// </summary>
    public int Sequence
    {
      get
      {
        return _Sequence;
      }
      set
      {
        __isset.Sequence = true;
        this._Sequence = value;
      }
    }

    /// <summary>
    /// @RuyiJoystickInput_Offset_desc
    /// 
    /// <seealso cref="JoystickOffset"/>
    /// </summary>
    public JoystickOffset Offset
    {
      get
      {
        return _Offset;
      }
      set
      {
        __isset.Offset = true;
        this._Offset = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool DeviceId;
      public bool UserId;
      public bool RawOffset;
      public bool @Value;
      public bool Timestamp;
      public bool Sequence;
      public bool Offset;
    }

    public RuyiJoystickInput() {
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
                DeviceId = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.String) {
                UserId = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 3:
              if (field.Type == TType.I32) {
                RawOffset = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 4:
              if (field.Type == TType.I32) {
                Value = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 5:
              if (field.Type == TType.I32) {
                Timestamp = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 6:
              if (field.Type == TType.I32) {
                Sequence = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 7:
              if (field.Type == TType.I32) {
                Offset = (JoystickOffset)iprot.ReadI32();
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
        TStruct struc = new TStruct("RuyiJoystickInput");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (DeviceId != null && __isset.DeviceId) {
          field.Name = "DeviceId";
          field.Type = TType.String;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(DeviceId);
          oprot.WriteFieldEnd();
        }
        if (UserId != null && __isset.UserId) {
          field.Name = "UserId";
          field.Type = TType.String;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(UserId);
          oprot.WriteFieldEnd();
        }
        if (__isset.RawOffset) {
          field.Name = "RawOffset";
          field.Type = TType.I32;
          field.ID = 3;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(RawOffset);
          oprot.WriteFieldEnd();
        }
        if (__isset.@Value) {
          field.Name = "Value";
          field.Type = TType.I32;
          field.ID = 4;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(Value);
          oprot.WriteFieldEnd();
        }
        if (__isset.Timestamp) {
          field.Name = "Timestamp";
          field.Type = TType.I32;
          field.ID = 5;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(Timestamp);
          oprot.WriteFieldEnd();
        }
        if (__isset.Sequence) {
          field.Name = "Sequence";
          field.Type = TType.I32;
          field.ID = 6;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(Sequence);
          oprot.WriteFieldEnd();
        }
        if (__isset.Offset) {
          field.Name = "Offset";
          field.Type = TType.I32;
          field.ID = 7;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32((int)Offset);
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
      StringBuilder __sb = new StringBuilder("RuyiJoystickInput(");
      bool __first = true;
      if (DeviceId != null && __isset.DeviceId) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("DeviceId: ");
        __sb.Append(DeviceId);
      }
      if (UserId != null && __isset.UserId) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("UserId: ");
        __sb.Append(UserId);
      }
      if (__isset.RawOffset) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("RawOffset: ");
        __sb.Append(RawOffset);
      }
      if (__isset.@Value) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Value: ");
        __sb.Append(Value);
      }
      if (__isset.Timestamp) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Timestamp: ");
        __sb.Append(Timestamp);
      }
      if (__isset.Sequence) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Sequence: ");
        __sb.Append(Sequence);
      }
      if (__isset.Offset) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Offset: ");
        __sb.Append(Offset);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
