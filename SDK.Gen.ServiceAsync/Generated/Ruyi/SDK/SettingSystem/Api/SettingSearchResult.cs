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
    public struct Isset
    {
      public bool Version;
      public bool SettingItems;
    }

    public SettingSearchResult()
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
                Version = await iprot.ReadStringAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.List)
              {
                {
                  SettingItems = new List<Ruyi.SDK.CommonType.SettingItem>();
                  TList _list4 = await iprot.ReadListBeginAsync(cancellationToken);
                  for(int _i5 = 0; _i5 < _list4.Count; ++_i5)
                  {
                    Ruyi.SDK.CommonType.SettingItem _elem6;
                    _elem6 = new Ruyi.SDK.CommonType.SettingItem();
                    await _elem6.ReadAsync(iprot, cancellationToken);
                    SettingItems.Add(_elem6);
                  }
                  await iprot.ReadListEndAsync(cancellationToken);
                }
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
        var struc = new TStruct("SettingSearchResult");
        await oprot.WriteStructBeginAsync(struc, cancellationToken);
        var field = new TField();
        if (Version != null && __isset.Version)
        {
          field.Name = "Version";
          field.Type = TType.String;
          field.ID = 1;
          await oprot.WriteFieldBeginAsync(field, cancellationToken);
          await oprot.WriteStringAsync(Version, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if (SettingItems != null && __isset.SettingItems)
        {
          field.Name = "SettingItems";
          field.Type = TType.List;
          field.ID = 2;
          await oprot.WriteFieldBeginAsync(field, cancellationToken);
          {
            await oprot.WriteListBeginAsync(new TList(TType.Struct, SettingItems.Count), cancellationToken);
            foreach (Ruyi.SDK.CommonType.SettingItem _iter7 in SettingItems)
            {
              await _iter7.WriteAsync(oprot, cancellationToken);
            }
            await oprot.WriteListEndAsync(cancellationToken);
          }
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
      var sb = new StringBuilder("SettingSearchResult(");
      bool __first = true;
      if (Version != null && __isset.Version)
      {
        if(!__first) { sb.Append(", "); }
        __first = false;
        sb.Append("Version: ");
        sb.Append(Version);
      }
      if (SettingItems != null && __isset.SettingItems)
      {
        if(!__first) { sb.Append(", "); }
        __first = false;
        sb.Append("SettingItems: ");
        sb.Append(SettingItems);
      }
      sb.Append(")");
      return sb.ToString();
    }
  }

}
