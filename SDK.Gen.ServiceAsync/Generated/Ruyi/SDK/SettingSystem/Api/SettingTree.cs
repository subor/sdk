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
  /// @SettingTree_desc
  /// </summary>
  public partial class SettingTree : TBase
  {
    private CategoryNode _CateNode;
    private Dictionary<string, Ruyi.SDK.CommonType.SettingCategory> _SettingCategories;
    private Dictionary<string, Ruyi.SDK.CommonType.SettingItem> _SettingItems;

    /// <summary>
    /// @SettingTree_CateNode_desc
    /// </summary>
    public CategoryNode CateNode
    {
      get
      {
        return _CateNode;
      }
      set
      {
        __isset.CateNode = true;
        this._CateNode = value;
      }
    }

    /// <summary>
    /// @SettingTree_SettingCategories_desc
    /// </summary>
    public Dictionary<string, Ruyi.SDK.CommonType.SettingCategory> SettingCategories
    {
      get
      {
        return _SettingCategories;
      }
      set
      {
        __isset.SettingCategories = true;
        this._SettingCategories = value;
      }
    }

    /// <summary>
    /// @SettingTree_SettingItems_desc
    /// </summary>
    public Dictionary<string, Ruyi.SDK.CommonType.SettingItem> SettingItems
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
      public bool CateNode;
      public bool SettingCategories;
      public bool SettingItems;
    }

    public SettingTree()
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
              if (field.Type == TType.Struct)
              {
                CateNode = new CategoryNode();
                await CateNode.ReadAsync(iprot, cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.Map)
              {
                {
                  SettingCategories = new Dictionary<string, Ruyi.SDK.CommonType.SettingCategory>();
                  TMap _map8 = await iprot.ReadMapBeginAsync(cancellationToken);
                  for(int _i9 = 0; _i9 < _map8.Count; ++_i9)
                  {
                    string _key10;
                    Ruyi.SDK.CommonType.SettingCategory _val11;
                    _key10 = await iprot.ReadStringAsync(cancellationToken);
                    _val11 = new Ruyi.SDK.CommonType.SettingCategory();
                    await _val11.ReadAsync(iprot, cancellationToken);
                    SettingCategories[_key10] = _val11;
                  }
                  await iprot.ReadMapEndAsync(cancellationToken);
                }
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 3:
              if (field.Type == TType.Map)
              {
                {
                  SettingItems = new Dictionary<string, Ruyi.SDK.CommonType.SettingItem>();
                  TMap _map12 = await iprot.ReadMapBeginAsync(cancellationToken);
                  for(int _i13 = 0; _i13 < _map12.Count; ++_i13)
                  {
                    string _key14;
                    Ruyi.SDK.CommonType.SettingItem _val15;
                    _key14 = await iprot.ReadStringAsync(cancellationToken);
                    _val15 = new Ruyi.SDK.CommonType.SettingItem();
                    await _val15.ReadAsync(iprot, cancellationToken);
                    SettingItems[_key14] = _val15;
                  }
                  await iprot.ReadMapEndAsync(cancellationToken);
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
        var struc = new TStruct("SettingTree");
        await oprot.WriteStructBeginAsync(struc, cancellationToken);
        var field = new TField();
        if (CateNode != null && __isset.CateNode)
        {
          field.Name = "CateNode";
          field.Type = TType.Struct;
          field.ID = 1;
          await oprot.WriteFieldBeginAsync(field, cancellationToken);
          await CateNode.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if (SettingCategories != null && __isset.SettingCategories)
        {
          field.Name = "SettingCategories";
          field.Type = TType.Map;
          field.ID = 2;
          await oprot.WriteFieldBeginAsync(field, cancellationToken);
          {
            await oprot.WriteMapBeginAsync(new TMap(TType.String, TType.Struct, SettingCategories.Count), cancellationToken);
            foreach (string _iter16 in SettingCategories.Keys)
            {
              await oprot.WriteStringAsync(_iter16, cancellationToken);
              await SettingCategories[_iter16].WriteAsync(oprot, cancellationToken);
            }
            await oprot.WriteMapEndAsync(cancellationToken);
          }
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if (SettingItems != null && __isset.SettingItems)
        {
          field.Name = "SettingItems";
          field.Type = TType.Map;
          field.ID = 3;
          await oprot.WriteFieldBeginAsync(field, cancellationToken);
          {
            await oprot.WriteMapBeginAsync(new TMap(TType.String, TType.Struct, SettingItems.Count), cancellationToken);
            foreach (string _iter17 in SettingItems.Keys)
            {
              await oprot.WriteStringAsync(_iter17, cancellationToken);
              await SettingItems[_iter17].WriteAsync(oprot, cancellationToken);
            }
            await oprot.WriteMapEndAsync(cancellationToken);
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
      var sb = new StringBuilder("SettingTree(");
      bool __first = true;
      if (CateNode != null && __isset.CateNode)
      {
        if(!__first) { sb.Append(", "); }
        __first = false;
        sb.Append("CateNode: ");
        sb.Append(CateNode== null ? "<null>" : CateNode.ToString());
      }
      if (SettingCategories != null && __isset.SettingCategories)
      {
        if(!__first) { sb.Append(", "); }
        __first = false;
        sb.Append("SettingCategories: ");
        sb.Append(SettingCategories);
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
