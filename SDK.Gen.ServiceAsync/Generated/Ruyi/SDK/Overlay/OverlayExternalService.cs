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


namespace Ruyi.SDK.Overlay
{
  public partial class OverlayExternalService
  {
    public interface IAsync
    {
      Task ShowInGameOverlayAsync(Ruyi.SDK.Overlay.OverlayState arguments, CancellationToken cancellationToken);

      Task<bool> TakeScreenShotAsync(CancellationToken cancellationToken);

      Task VideoCaptureAsync(Ruyi.SDK.Overlay.VideoCaptureState arguments, CancellationToken cancellationToken);

    }


    public class Client : TBaseClient, IDisposable, IAsync
    {
      public Client(TProtocol protocol) : this(protocol, protocol)
      {
      }

      public Client(TProtocol inputProtocol, TProtocol outputProtocol) : base(inputProtocol, outputProtocol)      {
      }
      public async Task ShowInGameOverlayAsync(Ruyi.SDK.Overlay.OverlayState arguments, CancellationToken cancellationToken)
      {
        await OutputProtocol.WriteMessageBeginAsync(new TMessage("ShowInGameOverlay", TMessageType.Call, SeqId), cancellationToken);
        
        var args = new ShowInGameOverlayArgs();
        args.Arguments = arguments;
        
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

        var result = new ShowInGameOverlayResult();
        await result.ReadAsync(InputProtocol, cancellationToken);
        await InputProtocol.ReadMessageEndAsync(cancellationToken);
        return;
      }

      public async Task<bool> TakeScreenShotAsync(CancellationToken cancellationToken)
      {
        await OutputProtocol.WriteMessageBeginAsync(new TMessage("TakeScreenShot", TMessageType.Call, SeqId), cancellationToken);
        
        var args = new TakeScreenShotArgs();
        
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

        var result = new TakeScreenShotResult();
        await result.ReadAsync(InputProtocol, cancellationToken);
        await InputProtocol.ReadMessageEndAsync(cancellationToken);
        if (result.__isset.success)
        {
          return result.Success;
        }
        throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "TakeScreenShot failed: unknown result");
      }

      public async Task VideoCaptureAsync(Ruyi.SDK.Overlay.VideoCaptureState arguments, CancellationToken cancellationToken)
      {
        await OutputProtocol.WriteMessageBeginAsync(new TMessage("VideoCapture", TMessageType.Call, SeqId), cancellationToken);
        
        var args = new VideoCaptureArgs();
        args.Arguments = arguments;
        
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

        var result = new VideoCaptureResult();
        await result.ReadAsync(InputProtocol, cancellationToken);
        await InputProtocol.ReadMessageEndAsync(cancellationToken);
        return;
      }

    }

    public class AsyncProcessor : ITAsyncProcessor
    {
      private IAsync _iAsync;

      public AsyncProcessor(IAsync iAsync)
      {
        if (iAsync == null) throw new ArgumentNullException(nameof(iAsync));

        _iAsync = iAsync;
        processMap_["ShowInGameOverlay"] = ShowInGameOverlay_ProcessAsync;
        processMap_["TakeScreenShot"] = TakeScreenShot_ProcessAsync;
        processMap_["VideoCapture"] = VideoCapture_ProcessAsync;
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

      public async Task ShowInGameOverlay_ProcessAsync(int seqid, TProtocol iprot, TProtocol oprot, CancellationToken cancellationToken)
      {
        var args = new ShowInGameOverlayArgs();
        await args.ReadAsync(iprot, cancellationToken);
        await iprot.ReadMessageEndAsync(cancellationToken);
        var result = new ShowInGameOverlayResult();
        try
        {
          await _iAsync.ShowInGameOverlayAsync(args.Arguments, cancellationToken);
          await oprot.WriteMessageBeginAsync(new TMessage("ShowInGameOverlay", TMessageType.Reply, seqid), cancellationToken); 
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
          await oprot.WriteMessageBeginAsync(new TMessage("ShowInGameOverlay", TMessageType.Exception, seqid), cancellationToken);
          await x.WriteAsync(oprot, cancellationToken);
        }
        await oprot.WriteMessageEndAsync(cancellationToken);
        await oprot.Transport.FlushAsync(cancellationToken);
      }

      public async Task TakeScreenShot_ProcessAsync(int seqid, TProtocol iprot, TProtocol oprot, CancellationToken cancellationToken)
      {
        var args = new TakeScreenShotArgs();
        await args.ReadAsync(iprot, cancellationToken);
        await iprot.ReadMessageEndAsync(cancellationToken);
        var result = new TakeScreenShotResult();
        try
        {
          result.Success = await _iAsync.TakeScreenShotAsync(cancellationToken);
          await oprot.WriteMessageBeginAsync(new TMessage("TakeScreenShot", TMessageType.Reply, seqid), cancellationToken); 
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
          await oprot.WriteMessageBeginAsync(new TMessage("TakeScreenShot", TMessageType.Exception, seqid), cancellationToken);
          await x.WriteAsync(oprot, cancellationToken);
        }
        await oprot.WriteMessageEndAsync(cancellationToken);
        await oprot.Transport.FlushAsync(cancellationToken);
      }

      public async Task VideoCapture_ProcessAsync(int seqid, TProtocol iprot, TProtocol oprot, CancellationToken cancellationToken)
      {
        var args = new VideoCaptureArgs();
        await args.ReadAsync(iprot, cancellationToken);
        await iprot.ReadMessageEndAsync(cancellationToken);
        var result = new VideoCaptureResult();
        try
        {
          await _iAsync.VideoCaptureAsync(args.Arguments, cancellationToken);
          await oprot.WriteMessageBeginAsync(new TMessage("VideoCapture", TMessageType.Reply, seqid), cancellationToken); 
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
          await oprot.WriteMessageBeginAsync(new TMessage("VideoCapture", TMessageType.Exception, seqid), cancellationToken);
          await x.WriteAsync(oprot, cancellationToken);
        }
        await oprot.WriteMessageEndAsync(cancellationToken);
        await oprot.Transport.FlushAsync(cancellationToken);
      }

    }


    public partial class ShowInGameOverlayArgs : TBase
    {
      private Ruyi.SDK.Overlay.OverlayState _arguments;

      public Ruyi.SDK.Overlay.OverlayState Arguments
      {
        get
        {
          return _arguments;
        }
        set
        {
          __isset.arguments = true;
          this._arguments = value;
        }
      }


      public Isset __isset;
      public struct Isset
      {
        public bool arguments;
      }

      public ShowInGameOverlayArgs()
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
                  Arguments = new Ruyi.SDK.Overlay.OverlayState();
                  await Arguments.ReadAsync(iprot, cancellationToken);
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
          var struc = new TStruct("ShowInGameOverlay_args");
          await oprot.WriteStructBeginAsync(struc, cancellationToken);
          var field = new TField();
          if (Arguments != null && __isset.arguments)
          {
            field.Name = "arguments";
            field.Type = TType.Struct;
            field.ID = 1;
            await oprot.WriteFieldBeginAsync(field, cancellationToken);
            await Arguments.WriteAsync(oprot, cancellationToken);
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
        var sb = new StringBuilder("ShowInGameOverlay_args(");
        bool __first = true;
        if (Arguments != null && __isset.arguments)
        {
          if(!__first) { sb.Append(", "); }
          __first = false;
          sb.Append("Arguments: ");
          sb.Append(Arguments== null ? "<null>" : Arguments.ToString());
        }
        sb.Append(")");
        return sb.ToString();
      }
    }


    public partial class ShowInGameOverlayResult : TBase
    {

      public ShowInGameOverlayResult()
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
          var struc = new TStruct("ShowInGameOverlay_result");
          await oprot.WriteStructBeginAsync(struc, cancellationToken);
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
        var sb = new StringBuilder("ShowInGameOverlay_result(");
        sb.Append(")");
        return sb.ToString();
      }
    }


    public partial class TakeScreenShotArgs : TBase
    {

      public TakeScreenShotArgs()
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
          var struc = new TStruct("TakeScreenShot_args");
          await oprot.WriteStructBeginAsync(struc, cancellationToken);
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
        var sb = new StringBuilder("TakeScreenShot_args(");
        sb.Append(")");
        return sb.ToString();
      }
    }


    public partial class TakeScreenShotResult : TBase
    {
      private bool _success;

      public bool Success
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


      public Isset __isset;
      public struct Isset
      {
        public bool success;
      }

      public TakeScreenShotResult()
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
                if (field.Type == TType.Bool)
                {
                  Success = await iprot.ReadBoolAsync(cancellationToken);
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
          var struc = new TStruct("TakeScreenShot_result");
          await oprot.WriteStructBeginAsync(struc, cancellationToken);
          var field = new TField();

          if(this.__isset.success)
          {
            field.Name = "Success";
            field.Type = TType.Bool;
            field.ID = 0;
            await oprot.WriteFieldBeginAsync(field, cancellationToken);
            await oprot.WriteBoolAsync(Success, cancellationToken);
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
        var sb = new StringBuilder("TakeScreenShot_result(");
        bool __first = true;
        if (__isset.success)
        {
          if(!__first) { sb.Append(", "); }
          __first = false;
          sb.Append("Success: ");
          sb.Append(Success);
        }
        sb.Append(")");
        return sb.ToString();
      }
    }


    public partial class VideoCaptureArgs : TBase
    {
      private Ruyi.SDK.Overlay.VideoCaptureState _arguments;

      public Ruyi.SDK.Overlay.VideoCaptureState Arguments
      {
        get
        {
          return _arguments;
        }
        set
        {
          __isset.arguments = true;
          this._arguments = value;
        }
      }


      public Isset __isset;
      public struct Isset
      {
        public bool arguments;
      }

      public VideoCaptureArgs()
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
                  Arguments = new Ruyi.SDK.Overlay.VideoCaptureState();
                  await Arguments.ReadAsync(iprot, cancellationToken);
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
          var struc = new TStruct("VideoCapture_args");
          await oprot.WriteStructBeginAsync(struc, cancellationToken);
          var field = new TField();
          if (Arguments != null && __isset.arguments)
          {
            field.Name = "arguments";
            field.Type = TType.Struct;
            field.ID = 1;
            await oprot.WriteFieldBeginAsync(field, cancellationToken);
            await Arguments.WriteAsync(oprot, cancellationToken);
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
        var sb = new StringBuilder("VideoCapture_args(");
        bool __first = true;
        if (Arguments != null && __isset.arguments)
        {
          if(!__first) { sb.Append(", "); }
          __first = false;
          sb.Append("Arguments: ");
          sb.Append(Arguments== null ? "<null>" : Arguments.ToString());
        }
        sb.Append(")");
        return sb.ToString();
      }
    }


    public partial class VideoCaptureResult : TBase
    {

      public VideoCaptureResult()
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
          var struc = new TStruct("VideoCapture_result");
          await oprot.WriteStructBeginAsync(struc, cancellationToken);
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
        var sb = new StringBuilder("VideoCapture_result(");
        sb.Append(")");
        return sb.ToString();
      }
    }

  }
}
