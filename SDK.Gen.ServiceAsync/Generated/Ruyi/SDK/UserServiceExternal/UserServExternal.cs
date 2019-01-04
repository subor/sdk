/**
 * Autogenerated by Thrift Compiler (0.12.0)
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
  public partial class UserServExternal
  {
    public interface IAsync
    {
      /// <summary>
      /// @GetPlayingUserInfo_Summary
      /// </summary>
      /// <param name="userId">@GetPlayingUserInfo_userId_desc</param>
      Task<Ruyi.SDK.UserServiceExternal.UserInfo_Public> GetPlayingUserInfoAsync(string userId, CancellationToken cancellationToken);

    }


    public class Client : TBaseClient, IDisposable, IAsync
    {
      public Client(TProtocol protocol) : this(protocol, protocol)
      {
      }

      public Client(TProtocol inputProtocol, TProtocol outputProtocol) : base(inputProtocol, outputProtocol)      {
      }
      public async Task<Ruyi.SDK.UserServiceExternal.UserInfo_Public> GetPlayingUserInfoAsync(string userId, CancellationToken cancellationToken)
      {
        await OutputProtocol.WriteMessageBeginAsync(new TMessage("GetPlayingUserInfo", TMessageType.Call, SeqId), cancellationToken);
        
        var args = new GetPlayingUserInfoArgs();
        args.UserId = userId;
        
        await args.WriteAsync(OutputProtocol, cancellationToken);
        await OutputProtocol.WriteMessageEndAsync(cancellationToken);
        await OutputProtocol.Transport.FlushAsync(cancellationToken);
        
        var msg = await InputProtocol.ReadMessageBeginAsync(cancellationToken);
        if (msg.Type == TMessageType.Exception)
        {
          var x = await TApplicationException.ReadAsync(InputProtocol, cancellationToken);
          await InputProtocol.ReadMessageEndAsync(cancellationToken);
          throw x;
        }

        var result = new GetPlayingUserInfoResult();
        await result.ReadAsync(InputProtocol, cancellationToken);
        await InputProtocol.ReadMessageEndAsync(cancellationToken);
        if (result.__isset.success)
        {
          return result.Success;
        }
        if (result.__isset.error1)
        {
          throw result.Error1;
        }
        throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "GetPlayingUserInfo failed: unknown result");
      }

    }

    public class AsyncProcessor : ITAsyncProcessor
    {
      private IAsync _iAsync;

      public AsyncProcessor(IAsync iAsync)
      {
        if (iAsync == null) throw new ArgumentNullException(nameof(iAsync));

        _iAsync = iAsync;
        processMap_["GetPlayingUserInfo"] = GetPlayingUserInfo_ProcessAsync;
      }

      protected delegate Task ProcessFunction(int seqid, TProtocol iprot, TProtocol oprot, CancellationToken cancellationToken);
      protected Dictionary<string, ProcessFunction> processMap_ = new Dictionary<string, ProcessFunction>();

      public async Task<bool> ProcessAsync(TProtocol iprot, TProtocol oprot)
      {
        return await ProcessAsync(iprot, oprot, CancellationToken.None);
      }

      public async Task<bool> ProcessAsync(TProtocol iprot, TProtocol oprot, CancellationToken cancellationToken)
      {
        try
        {
          var msg = await iprot.ReadMessageBeginAsync(cancellationToken);

          ProcessFunction fn;
          processMap_.TryGetValue(msg.Name, out fn);

          if (fn == null)
          {
            await TProtocolUtil.SkipAsync(iprot, TType.Struct, cancellationToken);
            await iprot.ReadMessageEndAsync(cancellationToken);
            var x = new TApplicationException (TApplicationException.ExceptionType.UnknownMethod, "Invalid method name: '" + msg.Name + "'");
            await oprot.WriteMessageBeginAsync(new TMessage(msg.Name, TMessageType.Exception, msg.SeqID), cancellationToken);
            await x.WriteAsync(oprot, cancellationToken);
            await oprot.WriteMessageEndAsync(cancellationToken);
            await oprot.Transport.FlushAsync(cancellationToken);
            return true;
          }

          await fn(msg.SeqID, iprot, oprot, cancellationToken);

        }
        catch (IOException)
        {
          return false;
        }

        return true;
      }

      public async Task GetPlayingUserInfo_ProcessAsync(int seqid, TProtocol iprot, TProtocol oprot, CancellationToken cancellationToken)
      {
        var args = new GetPlayingUserInfoArgs();
        await args.ReadAsync(iprot, cancellationToken);
        await iprot.ReadMessageEndAsync(cancellationToken);
        var result = new GetPlayingUserInfoResult();
        try
        {
          try
          {
            result.Success = await _iAsync.GetPlayingUserInfoAsync(args.UserId, cancellationToken);
          }
          catch (Ruyi.SDK.CommonType.ErrorException error1)
          {
            result.Error1 = error1;
          }
          await oprot.WriteMessageBeginAsync(new TMessage("GetPlayingUserInfo", TMessageType.Reply, seqid), cancellationToken); 
          await result.WriteAsync(oprot, cancellationToken);
        }
        catch (TTransportException)
        {
          throw;
        }
        catch (Exception ex)
        {
          Console.Error.WriteLine("Error occurred in processor:");
          Console.Error.WriteLine(ex.ToString());
          var x = new TApplicationException(TApplicationException.ExceptionType.InternalError," Internal error.");
          await oprot.WriteMessageBeginAsync(new TMessage("GetPlayingUserInfo", TMessageType.Exception, seqid), cancellationToken);
          await x.WriteAsync(oprot, cancellationToken);
        }
        await oprot.WriteMessageEndAsync(cancellationToken);
        await oprot.Transport.FlushAsync(cancellationToken);
      }

    }


    public partial class GetPlayingUserInfoArgs : TBase
    {
      private string _userId;

      /// <summary>
      /// @GetPlayingUserInfo_userId_desc
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


      public Isset __isset;
      public struct Isset
      {
        public bool userId;
      }

      public GetPlayingUserInfoArgs()
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
                  UserId = await iprot.ReadStringAsync(cancellationToken);
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
          var struc = new TStruct("GetPlayingUserInfo_args");
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
        var sb = new StringBuilder("GetPlayingUserInfo_args(");
        bool __first = true;
        if (UserId != null && __isset.userId)
        {
          if(!__first) { sb.Append(", "); }
          __first = false;
          sb.Append("UserId: ");
          sb.Append(UserId);
        }
        sb.Append(")");
        return sb.ToString();
      }
    }


    public partial class GetPlayingUserInfoResult : TBase
    {
      private Ruyi.SDK.UserServiceExternal.UserInfo_Public _success;
      private Ruyi.SDK.CommonType.ErrorException _error1;

      public Ruyi.SDK.UserServiceExternal.UserInfo_Public Success
      {
        get
        {
          return _success;
        }
        set
        {
          __isset.success = true;
          this._success = value;
        }
      }

      public Ruyi.SDK.CommonType.ErrorException Error1
      {
        get
        {
          return _error1;
        }
        set
        {
          __isset.error1 = true;
          this._error1 = value;
        }
      }


      public Isset __isset;
      public struct Isset
      {
        public bool success;
        public bool error1;
      }

      public GetPlayingUserInfoResult()
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
              case 0:
                if (field.Type == TType.Struct)
                {
                  Success = new Ruyi.SDK.UserServiceExternal.UserInfo_Public();
                  await Success.ReadAsync(iprot, cancellationToken);
                }
                else
                {
                  await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
                }
                break;
              case 1:
                if (field.Type == TType.Struct)
                {
                  Error1 = new Ruyi.SDK.CommonType.ErrorException();
                  await Error1.ReadAsync(iprot, cancellationToken);
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
          var struc = new TStruct("GetPlayingUserInfo_result");
          await oprot.WriteStructBeginAsync(struc, cancellationToken);
          var field = new TField();

          if(this.__isset.success)
          {
            if (Success != null)
            {
              field.Name = "Success";
              field.Type = TType.Struct;
              field.ID = 0;
              await oprot.WriteFieldBeginAsync(field, cancellationToken);
              await Success.WriteAsync(oprot, cancellationToken);
              await oprot.WriteFieldEndAsync(cancellationToken);
            }
          }
          else if(this.__isset.error1)
          {
            if (Error1 != null)
            {
              field.Name = "Error1";
              field.Type = TType.Struct;
              field.ID = 1;
              await oprot.WriteFieldBeginAsync(field, cancellationToken);
              await Error1.WriteAsync(oprot, cancellationToken);
              await oprot.WriteFieldEndAsync(cancellationToken);
            }
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
        var sb = new StringBuilder("GetPlayingUserInfo_result(");
        bool __first = true;
        if (Success != null && __isset.success)
        {
          if(!__first) { sb.Append(", "); }
          __first = false;
          sb.Append("Success: ");
          sb.Append(Success== null ? "<null>" : Success.ToString());
        }
        if (Error1 != null && __isset.error1)
        {
          if(!__first) { sb.Append(", "); }
          __first = false;
          sb.Append("Error1: ");
          sb.Append(Error1== null ? "<null>" : Error1.ToString());
        }
        sb.Append(")");
        return sb.ToString();
      }
    }

  }
}
