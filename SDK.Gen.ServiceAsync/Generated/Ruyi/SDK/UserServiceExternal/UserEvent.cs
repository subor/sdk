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


namespace Ruyi.SDK.UserServiceExternal
{

  /// <summary>
  /// @UserEvent_summary
  /// </summary>
  public partial class UserEvent : TBase
  {
    private string _userId;
    private string _action;
    private string _jsonData;

    /// <summary>
    /// @UserEvent_userId_desc
    /// </summary>
    public string UserId
    {
      get
      {
        return _userId;
      }
      set
      {
        __isset.userId = true;
        this._userId = value;
      }
    }

    /// <summary>
    /// @UserEvent_action_desc
    /// </summary>
    public string Action
    {
      get
      {
        return _action;
      }
      set
      {
        __isset.action = true;
        this._action = value;
      }
    }

    /// <summary>
    /// @UserEvent_parameters_desc
    /// </summary>
    public string JsonData
    {
      get
      {
        return _jsonData;
      }
      set
      {
        __isset.jsonData = true;
        this._jsonData = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool userId;
      public bool action;
      public bool jsonData;
    }

    public UserEvent()
    {
      this._jsonData = "{}";
      this.__isset.jsonData = true;
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
                UserId = await iprot.ReadStringAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.String)
              {
                Action = await iprot.ReadStringAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 3:
              if (field.Type == TType.String)
              {
                JsonData = await iprot.ReadStringAsync(cancellationToken);
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
        var struc = new TStruct("UserEvent");
        await oprot.WriteStructBeginAsync(struc, cancellationToken);
        var field = new TField();
        if (UserId != null && __isset.userId)
        {
          field.Name = "userId";
          field.Type = TType.String;
          field.ID = 1;
          await oprot.WriteFieldBeginAsync(field, cancellationToken);
          await oprot.WriteStringAsync(UserId, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if (Action != null && __isset.action)
        {
          field.Name = "action";
          field.Type = TType.String;
          field.ID = 2;
          await oprot.WriteFieldBeginAsync(field, cancellationToken);
          await oprot.WriteStringAsync(Action, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if (JsonData != null && __isset.jsonData)
        {
          field.Name = "jsonData";
          field.Type = TType.String;
          field.ID = 3;
          await oprot.WriteFieldBeginAsync(field, cancellationToken);
          await oprot.WriteStringAsync(JsonData, cancellationToken);
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
      var sb = new StringBuilder("UserEvent(");
      bool __first = true;
      if (UserId != null && __isset.userId)
      {
        if(!__first) { sb.Append(", "); }
        __first = false;
        sb.Append("UserId: ");
        sb.Append(UserId);
      }
      if (Action != null && __isset.action)
      {
        if(!__first) { sb.Append(", "); }
        __first = false;
        sb.Append("Action: ");
        sb.Append(Action);
      }
      if (JsonData != null && __isset.jsonData)
      {
        if(!__first) { sb.Append(", "); }
        __first = false;
        sb.Append("JsonData: ");
        sb.Append(JsonData);
      }
      sb.Append(")");
      return sb.ToString();
    }
  }

}
