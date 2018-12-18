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
using System.Threading;
using System.Threading.Tasks;
using Thrift;
using Thrift.Collections;

using Thrift.Protocols;
using Thrift.Protocols.Entities;
using Thrift.Protocols.Utilities;
using Thrift.Transports;
using Thrift.Transports.Client;
using Thrift.Transports.Server;


namespace Ruyi.SDK.SettingSystem.Api
{

  /// <summary>
  /// @WifiEntity_desc
  /// </summary>
  public partial class WifiEntity : TBase
  {
    private string _Name;
    private string _MacAddress;
    private int _Channel;
    private int _CenterFrequancy;
    private int _Rssi;
    private bool _Connected;
    private bool _SecurityEnabled;
    private bool _HasProfile;

    /// <summary>
    /// @WifiEntity_Name_desc
    /// </summary>
    public string Name
    {
      get
      {
        return _Name;
      }
      set
      {
        __isset.Name = true;
        this._Name = value;
      }
    }

    /// <summary>
    /// @WifiEntity_MacAddress_desc
    /// </summary>
    public string MacAddress
    {
      get
      {
        return _MacAddress;
      }
      set
      {
        __isset.MacAddress = true;
        this._MacAddress = value;
      }
    }

    /// <summary>
    /// @WifiEntity_Channel_desc
    /// </summary>
    public int Channel
    {
      get
      {
        return _Channel;
      }
      set
      {
        __isset.Channel = true;
        this._Channel = value;
      }
    }

    /// <summary>
    /// @WifiEntity_CenterFrequancy_desc
    /// </summary>
    public int CenterFrequancy
    {
      get
      {
        return _CenterFrequancy;
      }
      set
      {
        __isset.CenterFrequancy = true;
        this._CenterFrequancy = value;
      }
    }

    /// <summary>
    /// @WifiEntity_Rssi_desc
    /// </summary>
    public int Rssi
    {
      get
      {
        return _Rssi;
      }
      set
      {
        __isset.Rssi = true;
        this._Rssi = value;
      }
    }

    /// <summary>
    /// @WifiEntity_Connected_desc
    /// </summary>
    public bool Connected
    {
      get
      {
        return _Connected;
      }
      set
      {
        __isset.Connected = true;
        this._Connected = value;
      }
    }

    /// <summary>
    /// @WifiEntity_SecurityEnabled_desc
    /// </summary>
    public bool SecurityEnabled
    {
      get
      {
        return _SecurityEnabled;
      }
      set
      {
        __isset.SecurityEnabled = true;
        this._SecurityEnabled = value;
      }
    }

    /// <summary>
    /// @WifiEntity_HasProfile_desc
    /// </summary>
    public bool HasProfile
    {
      get
      {
        return _HasProfile;
      }
      set
      {
        __isset.HasProfile = true;
        this._HasProfile = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool Name;
      public bool MacAddress;
      public bool Channel;
      public bool CenterFrequancy;
      public bool Rssi;
      public bool Connected;
      public bool SecurityEnabled;
      public bool HasProfile;
    }

    public WifiEntity()
    {
    }

    public async Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        TField field;
        await iprot.ReadStructBeginAsync(cancellationToken);
        while (true)
        {
          field = await iprot.ReadFieldBeginAsync(cancellationToken);
          if (field.Type == TType.Stop)
          {
            break;
          }

          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.String)
              {
                Name = await iprot.ReadStringAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.String)
              {
                MacAddress = await iprot.ReadStringAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 3:
              if (field.Type == TType.I32)
              {
                Channel = await iprot.ReadI32Async(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 4:
              if (field.Type == TType.I32)
              {
                CenterFrequancy = await iprot.ReadI32Async(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 5:
              if (field.Type == TType.I32)
              {
                Rssi = await iprot.ReadI32Async(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 6:
              if (field.Type == TType.Bool)
              {
                Connected = await iprot.ReadBoolAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 7:
              if (field.Type == TType.Bool)
              {
                SecurityEnabled = await iprot.ReadBoolAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 8:
              if (field.Type == TType.Bool)
              {
                HasProfile = await iprot.ReadBoolAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            default: 
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              break;
          }

          await iprot.ReadFieldEndAsync(cancellationToken);
        }

        await iprot.ReadStructEndAsync(cancellationToken);
      }
      finally
      {
        iprot.DecrementRecursionDepth();
      }
    }

    public async Task WriteAsync(TProtocol oprot, CancellationToken cancellationToken)
    {
      oprot.IncrementRecursionDepth();
      try
      {
        var struc = new TStruct("WifiEntity");
        await oprot.WriteStructBeginAsync(struc, cancellationToken);
        var field = new TField();
        if (Name != null && __isset.Name)
        {
          field.Name = "Name";
          field.Type = TType.String;
          field.ID = 1;
          await oprot.WriteFieldBeginAsync(field, cancellationToken);
          await oprot.WriteStringAsync(Name, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if (MacAddress != null && __isset.MacAddress)
        {
          field.Name = "MacAddress";
          field.Type = TType.String;
          field.ID = 2;
          await oprot.WriteFieldBeginAsync(field, cancellationToken);
          await oprot.WriteStringAsync(MacAddress, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if (__isset.Channel)
        {
          field.Name = "Channel";
          field.Type = TType.I32;
          field.ID = 3;
          await oprot.WriteFieldBeginAsync(field, cancellationToken);
          await oprot.WriteI32Async(Channel, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if (__isset.CenterFrequancy)
        {
          field.Name = "CenterFrequancy";
          field.Type = TType.I32;
          field.ID = 4;
          await oprot.WriteFieldBeginAsync(field, cancellationToken);
          await oprot.WriteI32Async(CenterFrequancy, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if (__isset.Rssi)
        {
          field.Name = "Rssi";
          field.Type = TType.I32;
          field.ID = 5;
          await oprot.WriteFieldBeginAsync(field, cancellationToken);
          await oprot.WriteI32Async(Rssi, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if (__isset.Connected)
        {
          field.Name = "Connected";
          field.Type = TType.Bool;
          field.ID = 6;
          await oprot.WriteFieldBeginAsync(field, cancellationToken);
          await oprot.WriteBoolAsync(Connected, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if (__isset.SecurityEnabled)
        {
          field.Name = "SecurityEnabled";
          field.Type = TType.Bool;
          field.ID = 7;
          await oprot.WriteFieldBeginAsync(field, cancellationToken);
          await oprot.WriteBoolAsync(SecurityEnabled, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if (__isset.HasProfile)
        {
          field.Name = "HasProfile";
          field.Type = TType.Bool;
          field.ID = 8;
          await oprot.WriteFieldBeginAsync(field, cancellationToken);
          await oprot.WriteBoolAsync(HasProfile, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        await oprot.WriteFieldStopAsync(cancellationToken);
        await oprot.WriteStructEndAsync(cancellationToken);
      }
      finally
      {
        oprot.DecrementRecursionDepth();
      }
    }

    public override string ToString()
    {
      var sb = new StringBuilder("WifiEntity(");
      bool __first = true;
      if (Name != null && __isset.Name)
      {
        if(!__first) { sb.Append(", "); }
        __first = false;
        sb.Append("Name: ");
        sb.Append(Name);
      }
      if (MacAddress != null && __isset.MacAddress)
      {
        if(!__first) { sb.Append(", "); }
        __first = false;
        sb.Append("MacAddress: ");
        sb.Append(MacAddress);
      }
      if (__isset.Channel)
      {
        if(!__first) { sb.Append(", "); }
        __first = false;
        sb.Append("Channel: ");
        sb.Append(Channel);
      }
      if (__isset.CenterFrequancy)
      {
        if(!__first) { sb.Append(", "); }
        __first = false;
        sb.Append("CenterFrequancy: ");
        sb.Append(CenterFrequancy);
      }
      if (__isset.Rssi)
      {
        if(!__first) { sb.Append(", "); }
        __first = false;
        sb.Append("Rssi: ");
        sb.Append(Rssi);
      }
      if (__isset.Connected)
      {
        if(!__first) { sb.Append(", "); }
        __first = false;
        sb.Append("Connected: ");
        sb.Append(Connected);
      }
      if (__isset.SecurityEnabled)
      {
        if(!__first) { sb.Append(", "); }
        __first = false;
        sb.Append("SecurityEnabled: ");
        sb.Append(SecurityEnabled);
      }
      if (__isset.HasProfile)
      {
        if(!__first) { sb.Append(", "); }
        __first = false;
        sb.Append("HasProfile: ");
        sb.Append(HasProfile);
      }
      sb.Append(")");
      return sb.ToString();
    }
  }

}
