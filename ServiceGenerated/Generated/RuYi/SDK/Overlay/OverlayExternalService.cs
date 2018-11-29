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
using System.Threading.Tasks;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace Ruyi.SDK.Overlay
{
  public partial class OverlayExternalService {
    public interface ISync {
      void ShowInGameOverlay(Ruyi.SDK.Overlay.OverlayState arguments);
      bool TakeScreenShot();
      void VideoCapture(Ruyi.SDK.Overlay.VideoCaptureState arguments);
    }

    public interface IAsync {
      Task ShowInGameOverlayAsync(Ruyi.SDK.Overlay.OverlayState arguments);
      Task<bool> TakeScreenShotAsync();
      Task VideoCaptureAsync(Ruyi.SDK.Overlay.VideoCaptureState arguments);
    }

    public interface Iface : ISync, IAsync {
      IAsyncResult Begin_ShowInGameOverlay(AsyncCallback callback, object state, Ruyi.SDK.Overlay.OverlayState arguments);
      void End_ShowInGameOverlay(IAsyncResult asyncResult);
      IAsyncResult Begin_TakeScreenShot(AsyncCallback callback, object state);
      bool End_TakeScreenShot(IAsyncResult asyncResult);
      IAsyncResult Begin_VideoCapture(AsyncCallback callback, object state, Ruyi.SDK.Overlay.VideoCaptureState arguments);
      void End_VideoCapture(IAsyncResult asyncResult);
    }

    public class Client : IDisposable, Iface {
      public Client(TProtocol prot) : this(prot, prot)
      {
      }

      public Client(TProtocol iprot, TProtocol oprot)
      {
        iprot_ = iprot;
        oprot_ = oprot;
      }

      protected TProtocol iprot_;
      protected TProtocol oprot_;
      protected int seqid_;

      public TProtocol InputProtocol
      {
        get { return iprot_; }
      }
      public TProtocol OutputProtocol
      {
        get { return oprot_; }
      }


      #region " IDisposable Support "
      private bool _IsDisposed;

      // IDisposable
      public void Dispose()
      {
        Dispose(true);
      }
      

      protected virtual void Dispose(bool disposing)
      {
        if (!_IsDisposed)
        {
          if (disposing)
          {
            if (iprot_ != null)
            {
              ((IDisposable)iprot_).Dispose();
            }
            if (oprot_ != null)
            {
              ((IDisposable)oprot_).Dispose();
            }
          }
        }
        _IsDisposed = true;
      }
      #endregion


      
      public IAsyncResult Begin_ShowInGameOverlay(AsyncCallback callback, object state, Ruyi.SDK.Overlay.OverlayState arguments)
      {
        return send_ShowInGameOverlay(callback, state, arguments);
      }

      public void End_ShowInGameOverlay(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        recv_ShowInGameOverlay();
      }

      public async Task ShowInGameOverlayAsync(Ruyi.SDK.Overlay.OverlayState arguments)
      {
        await Task.Run(() =>
        {
          ShowInGameOverlay(arguments);
        });
      }

      public void ShowInGameOverlay(Ruyi.SDK.Overlay.OverlayState arguments)
      {
        var asyncResult = Begin_ShowInGameOverlay(null, null, arguments);
        End_ShowInGameOverlay(asyncResult);

      }
      public IAsyncResult send_ShowInGameOverlay(AsyncCallback callback, object state, Ruyi.SDK.Overlay.OverlayState arguments)
      {
        oprot_.WriteMessageBegin(new TMessage("ShowInGameOverlay", TMessageType.Call, seqid_));
        ShowInGameOverlay_args args = new ShowInGameOverlay_args();
        args.Arguments = arguments;
        args.Write(oprot_);
        oprot_.WriteMessageEnd();
        return oprot_.Transport.BeginFlush(callback, state);
      }

      public void recv_ShowInGameOverlay()
      {
        TMessage msg = iprot_.ReadMessageBegin();
        if (msg.Type == TMessageType.Exception) {
          TApplicationException x = TApplicationException.Read(iprot_);
          iprot_.ReadMessageEnd();
          throw x;
        }
        ShowInGameOverlay_result result = new ShowInGameOverlay_result();
        result.Read(iprot_);
        iprot_.ReadMessageEnd();
        return;
      }

      
      public IAsyncResult Begin_TakeScreenShot(AsyncCallback callback, object state)
      {
        return send_TakeScreenShot(callback, state);
      }

      public bool End_TakeScreenShot(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        return recv_TakeScreenShot();
      }

      public async Task<bool> TakeScreenShotAsync()
      {
        bool retval;
        retval = await Task.Run(() =>
        {
          return TakeScreenShot();
        });
        return retval;
      }

      public bool TakeScreenShot()
      {
        var asyncResult = Begin_TakeScreenShot(null, null);
        return End_TakeScreenShot(asyncResult);

      }
      public IAsyncResult send_TakeScreenShot(AsyncCallback callback, object state)
      {
        oprot_.WriteMessageBegin(new TMessage("TakeScreenShot", TMessageType.Call, seqid_));
        TakeScreenShot_args args = new TakeScreenShot_args();
        args.Write(oprot_);
        oprot_.WriteMessageEnd();
        return oprot_.Transport.BeginFlush(callback, state);
      }

      public bool recv_TakeScreenShot()
      {
        TMessage msg = iprot_.ReadMessageBegin();
        if (msg.Type == TMessageType.Exception) {
          TApplicationException x = TApplicationException.Read(iprot_);
          iprot_.ReadMessageEnd();
          throw x;
        }
        TakeScreenShot_result result = new TakeScreenShot_result();
        result.Read(iprot_);
        iprot_.ReadMessageEnd();
        if (result.__isset.success) {
          return result.Success;
        }
        throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "TakeScreenShot failed: unknown result");
      }

      
      public IAsyncResult Begin_VideoCapture(AsyncCallback callback, object state, Ruyi.SDK.Overlay.VideoCaptureState arguments)
      {
        return send_VideoCapture(callback, state, arguments);
      }

      public void End_VideoCapture(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        recv_VideoCapture();
      }

      public async Task VideoCaptureAsync(Ruyi.SDK.Overlay.VideoCaptureState arguments)
      {
        await Task.Run(() =>
        {
          VideoCapture(arguments);
        });
      }

      public void VideoCapture(Ruyi.SDK.Overlay.VideoCaptureState arguments)
      {
        var asyncResult = Begin_VideoCapture(null, null, arguments);
        End_VideoCapture(asyncResult);

      }
      public IAsyncResult send_VideoCapture(AsyncCallback callback, object state, Ruyi.SDK.Overlay.VideoCaptureState arguments)
      {
        oprot_.WriteMessageBegin(new TMessage("VideoCapture", TMessageType.Call, seqid_));
        VideoCapture_args args = new VideoCapture_args();
        args.Arguments = arguments;
        args.Write(oprot_);
        oprot_.WriteMessageEnd();
        return oprot_.Transport.BeginFlush(callback, state);
      }

      public void recv_VideoCapture()
      {
        TMessage msg = iprot_.ReadMessageBegin();
        if (msg.Type == TMessageType.Exception) {
          TApplicationException x = TApplicationException.Read(iprot_);
          iprot_.ReadMessageEnd();
          throw x;
        }
        VideoCapture_result result = new VideoCapture_result();
        result.Read(iprot_);
        iprot_.ReadMessageEnd();
        return;
      }

    }
    public class AsyncProcessor : TAsyncProcessor {
      public AsyncProcessor(IAsync iface)
      {
        iface_ = iface;
        processMap_["ShowInGameOverlay"] = ShowInGameOverlay_ProcessAsync;
        processMap_["TakeScreenShot"] = TakeScreenShot_ProcessAsync;
        processMap_["VideoCapture"] = VideoCapture_ProcessAsync;
      }

      protected delegate Task ProcessFunction(int seqid, TProtocol iprot, TProtocol oprot);
      private IAsync iface_;
      protected Dictionary<string, ProcessFunction> processMap_ = new Dictionary<string, ProcessFunction>();

      public async Task<bool> ProcessAsync(TProtocol iprot, TProtocol oprot)
      {
        try
        {
          TMessage msg = iprot.ReadMessageBegin();
          ProcessFunction fn;
          processMap_.TryGetValue(msg.Name, out fn);
          if (fn == null) {
            TProtocolUtil.Skip(iprot, TType.Struct);
            iprot.ReadMessageEnd();
            TApplicationException x = new TApplicationException (TApplicationException.ExceptionType.UnknownMethod, "Invalid method name: '" + msg.Name + "'");
            oprot.WriteMessageBegin(new TMessage(msg.Name, TMessageType.Exception, msg.SeqID));
            x.Write(oprot);
            oprot.WriteMessageEnd();
            oprot.Transport.Flush();
            return true;
          }
          await fn(msg.SeqID, iprot, oprot);
        }
        catch (IOException)
        {
          return false;
        }
        return true;
      }

      public async Task ShowInGameOverlay_ProcessAsync(int seqid, TProtocol iprot, TProtocol oprot)
      {
        ShowInGameOverlay_args args = new ShowInGameOverlay_args();
        args.Read(iprot);
        iprot.ReadMessageEnd();
        ShowInGameOverlay_result result = new ShowInGameOverlay_result();
        try
        {
          await iface_.ShowInGameOverlayAsync(args.Arguments);
          oprot.WriteMessageBegin(new TMessage("ShowInGameOverlay", TMessageType.Reply, seqid)); 
          result.Write(oprot);
        }
        catch (TTransportException)
        {
          throw;
        }
        catch (Exception ex)
        {
          Console.Error.WriteLine("Error occurred in processor:");
          Console.Error.WriteLine(ex.ToString());
          TApplicationException x = new TApplicationException        (TApplicationException.ExceptionType.InternalError," Internal error.");
          oprot.WriteMessageBegin(new TMessage("ShowInGameOverlay", TMessageType.Exception, seqid));
          x.Write(oprot);
        }
        oprot.WriteMessageEnd();
        oprot.Transport.Flush();
      }

      public async Task TakeScreenShot_ProcessAsync(int seqid, TProtocol iprot, TProtocol oprot)
      {
        TakeScreenShot_args args = new TakeScreenShot_args();
        args.Read(iprot);
        iprot.ReadMessageEnd();
        TakeScreenShot_result result = new TakeScreenShot_result();
        try
        {
          result.Success = await iface_.TakeScreenShotAsync();
          oprot.WriteMessageBegin(new TMessage("TakeScreenShot", TMessageType.Reply, seqid)); 
          result.Write(oprot);
        }
        catch (TTransportException)
        {
          throw;
        }
        catch (Exception ex)
        {
          Console.Error.WriteLine("Error occurred in processor:");
          Console.Error.WriteLine(ex.ToString());
          TApplicationException x = new TApplicationException        (TApplicationException.ExceptionType.InternalError," Internal error.");
          oprot.WriteMessageBegin(new TMessage("TakeScreenShot", TMessageType.Exception, seqid));
          x.Write(oprot);
        }
        oprot.WriteMessageEnd();
        oprot.Transport.Flush();
      }

      public async Task VideoCapture_ProcessAsync(int seqid, TProtocol iprot, TProtocol oprot)
      {
        VideoCapture_args args = new VideoCapture_args();
        args.Read(iprot);
        iprot.ReadMessageEnd();
        VideoCapture_result result = new VideoCapture_result();
        try
        {
          await iface_.VideoCaptureAsync(args.Arguments);
          oprot.WriteMessageBegin(new TMessage("VideoCapture", TMessageType.Reply, seqid)); 
          result.Write(oprot);
        }
        catch (TTransportException)
        {
          throw;
        }
        catch (Exception ex)
        {
          Console.Error.WriteLine("Error occurred in processor:");
          Console.Error.WriteLine(ex.ToString());
          TApplicationException x = new TApplicationException        (TApplicationException.ExceptionType.InternalError," Internal error.");
          oprot.WriteMessageBegin(new TMessage("VideoCapture", TMessageType.Exception, seqid));
          x.Write(oprot);
        }
        oprot.WriteMessageEnd();
        oprot.Transport.Flush();
      }

    }

    public class Processor : TProcessor {
      public Processor(ISync iface)
      {
        iface_ = iface;
        processMap_["ShowInGameOverlay"] = ShowInGameOverlay_Process;
        processMap_["TakeScreenShot"] = TakeScreenShot_Process;
        processMap_["VideoCapture"] = VideoCapture_Process;
      }

      protected delegate void ProcessFunction(int seqid, TProtocol iprot, TProtocol oprot);
      private ISync iface_;
      protected Dictionary<string, ProcessFunction> processMap_ = new Dictionary<string, ProcessFunction>();

      public bool Process(TProtocol iprot, TProtocol oprot)
      {
        try
        {
          TMessage msg = iprot.ReadMessageBegin();
          ProcessFunction fn;
          processMap_.TryGetValue(msg.Name, out fn);
          if (fn == null) {
            TProtocolUtil.Skip(iprot, TType.Struct);
            iprot.ReadMessageEnd();
            TApplicationException x = new TApplicationException (TApplicationException.ExceptionType.UnknownMethod, "Invalid method name: '" + msg.Name + "'");
            oprot.WriteMessageBegin(new TMessage(msg.Name, TMessageType.Exception, msg.SeqID));
            x.Write(oprot);
            oprot.WriteMessageEnd();
            oprot.Transport.Flush();
            return true;
          }
          fn(msg.SeqID, iprot, oprot);
        }
        catch (IOException)
        {
          return false;
        }
        return true;
      }

      public void ShowInGameOverlay_Process(int seqid, TProtocol iprot, TProtocol oprot)
      {
        ShowInGameOverlay_args args = new ShowInGameOverlay_args();
        args.Read(iprot);
        iprot.ReadMessageEnd();
        ShowInGameOverlay_result result = new ShowInGameOverlay_result();
        try
        {
          iface_.ShowInGameOverlay(args.Arguments);
          oprot.WriteMessageBegin(new TMessage("ShowInGameOverlay", TMessageType.Reply, seqid)); 
          result.Write(oprot);
        }
        catch (TTransportException)
        {
          throw;
        }
        catch (Exception ex)
        {
          Console.Error.WriteLine("Error occurred in processor:");
          Console.Error.WriteLine(ex.ToString());
          TApplicationException x = new TApplicationException        (TApplicationException.ExceptionType.InternalError," Internal error.");
          oprot.WriteMessageBegin(new TMessage("ShowInGameOverlay", TMessageType.Exception, seqid));
          x.Write(oprot);
        }
        oprot.WriteMessageEnd();
        oprot.Transport.Flush();
      }

      public void TakeScreenShot_Process(int seqid, TProtocol iprot, TProtocol oprot)
      {
        TakeScreenShot_args args = new TakeScreenShot_args();
        args.Read(iprot);
        iprot.ReadMessageEnd();
        TakeScreenShot_result result = new TakeScreenShot_result();
        try
        {
          result.Success = iface_.TakeScreenShot();
          oprot.WriteMessageBegin(new TMessage("TakeScreenShot", TMessageType.Reply, seqid)); 
          result.Write(oprot);
        }
        catch (TTransportException)
        {
          throw;
        }
        catch (Exception ex)
        {
          Console.Error.WriteLine("Error occurred in processor:");
          Console.Error.WriteLine(ex.ToString());
          TApplicationException x = new TApplicationException        (TApplicationException.ExceptionType.InternalError," Internal error.");
          oprot.WriteMessageBegin(new TMessage("TakeScreenShot", TMessageType.Exception, seqid));
          x.Write(oprot);
        }
        oprot.WriteMessageEnd();
        oprot.Transport.Flush();
      }

      public void VideoCapture_Process(int seqid, TProtocol iprot, TProtocol oprot)
      {
        VideoCapture_args args = new VideoCapture_args();
        args.Read(iprot);
        iprot.ReadMessageEnd();
        VideoCapture_result result = new VideoCapture_result();
        try
        {
          iface_.VideoCapture(args.Arguments);
          oprot.WriteMessageBegin(new TMessage("VideoCapture", TMessageType.Reply, seqid)); 
          result.Write(oprot);
        }
        catch (TTransportException)
        {
          throw;
        }
        catch (Exception ex)
        {
          Console.Error.WriteLine("Error occurred in processor:");
          Console.Error.WriteLine(ex.ToString());
          TApplicationException x = new TApplicationException        (TApplicationException.ExceptionType.InternalError," Internal error.");
          oprot.WriteMessageBegin(new TMessage("VideoCapture", TMessageType.Exception, seqid));
          x.Write(oprot);
        }
        oprot.WriteMessageEnd();
        oprot.Transport.Flush();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class ShowInGameOverlay_args : TBase
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
      #if !SILVERLIGHT
      [Serializable]
      #endif
      public struct Isset {
        public bool arguments;
      }

      public ShowInGameOverlay_args() {
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
                if (field.Type == TType.Struct) {
                  Arguments = new Ruyi.SDK.Overlay.OverlayState();
                  Arguments.Read(iprot);
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
          TStruct struc = new TStruct("ShowInGameOverlay_args");
          oprot.WriteStructBegin(struc);
          TField field = new TField();
          if (Arguments != null && __isset.arguments) {
            field.Name = "arguments";
            field.Type = TType.Struct;
            field.ID = 1;
            oprot.WriteFieldBegin(field);
            Arguments.Write(oprot);
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
        StringBuilder __sb = new StringBuilder("ShowInGameOverlay_args(");
        bool __first = true;
        if (Arguments != null && __isset.arguments) {
          if(!__first) { __sb.Append(", "); }
          __first = false;
          __sb.Append("Arguments: ");
          __sb.Append(Arguments== null ? "<null>" : Arguments.ToString());
        }
        __sb.Append(")");
        return __sb.ToString();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class ShowInGameOverlay_result : TBase
    {

      public ShowInGameOverlay_result() {
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
          TStruct struc = new TStruct("ShowInGameOverlay_result");
          oprot.WriteStructBegin(struc);

          oprot.WriteFieldStop();
          oprot.WriteStructEnd();
        }
        finally
        {
          oprot.DecrementRecursionDepth();
        }
      }

      public override string ToString() {
        StringBuilder __sb = new StringBuilder("ShowInGameOverlay_result(");
        __sb.Append(")");
        return __sb.ToString();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class TakeScreenShot_args : TBase
    {

      public TakeScreenShot_args() {
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
          TStruct struc = new TStruct("TakeScreenShot_args");
          oprot.WriteStructBegin(struc);
          oprot.WriteFieldStop();
          oprot.WriteStructEnd();
        }
        finally
        {
          oprot.DecrementRecursionDepth();
        }
      }

      public override string ToString() {
        StringBuilder __sb = new StringBuilder("TakeScreenShot_args(");
        __sb.Append(")");
        return __sb.ToString();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class TakeScreenShot_result : TBase
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
      #if !SILVERLIGHT
      [Serializable]
      #endif
      public struct Isset {
        public bool success;
      }

      public TakeScreenShot_result() {
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
              case 0:
                if (field.Type == TType.Bool) {
                  Success = iprot.ReadBool();
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
          TStruct struc = new TStruct("TakeScreenShot_result");
          oprot.WriteStructBegin(struc);
          TField field = new TField();

          if (this.__isset.success) {
            field.Name = "Success";
            field.Type = TType.Bool;
            field.ID = 0;
            oprot.WriteFieldBegin(field);
            oprot.WriteBool(Success);
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
        StringBuilder __sb = new StringBuilder("TakeScreenShot_result(");
        bool __first = true;
        if (__isset.success) {
          if(!__first) { __sb.Append(", "); }
          __first = false;
          __sb.Append("Success: ");
          __sb.Append(Success);
        }
        __sb.Append(")");
        return __sb.ToString();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class VideoCapture_args : TBase
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
      #if !SILVERLIGHT
      [Serializable]
      #endif
      public struct Isset {
        public bool arguments;
      }

      public VideoCapture_args() {
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
                if (field.Type == TType.Struct) {
                  Arguments = new Ruyi.SDK.Overlay.VideoCaptureState();
                  Arguments.Read(iprot);
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
          TStruct struc = new TStruct("VideoCapture_args");
          oprot.WriteStructBegin(struc);
          TField field = new TField();
          if (Arguments != null && __isset.arguments) {
            field.Name = "arguments";
            field.Type = TType.Struct;
            field.ID = 1;
            oprot.WriteFieldBegin(field);
            Arguments.Write(oprot);
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
        StringBuilder __sb = new StringBuilder("VideoCapture_args(");
        bool __first = true;
        if (Arguments != null && __isset.arguments) {
          if(!__first) { __sb.Append(", "); }
          __first = false;
          __sb.Append("Arguments: ");
          __sb.Append(Arguments== null ? "<null>" : Arguments.ToString());
        }
        __sb.Append(")");
        return __sb.ToString();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class VideoCapture_result : TBase
    {

      public VideoCapture_result() {
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
          TStruct struc = new TStruct("VideoCapture_result");
          oprot.WriteStructBegin(struc);

          oprot.WriteFieldStop();
          oprot.WriteStructEnd();
        }
        finally
        {
          oprot.DecrementRecursionDepth();
        }
      }

      public override string ToString() {
        StringBuilder __sb = new StringBuilder("VideoCapture_result(");
        __sb.Append(")");
        return __sb.ToString();
      }

    }

  }
}
