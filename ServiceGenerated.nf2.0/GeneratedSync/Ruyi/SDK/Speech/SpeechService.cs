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
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace Ruyi.SDK.Speech
{
  public partial class SpeechService {
    public interface ISync {
      Ruyi.SDK.Speech.SpeechResult Say(Ruyi.SDK.Speech.VoiceCommand command);
    }

    public interface Iface : ISync {
      #if SILVERLIGHT
      IAsyncResult Begin_Say(AsyncCallback callback, object state, Ruyi.SDK.Speech.VoiceCommand command);
      Ruyi.SDK.Speech.SpeechResult End_Say(IAsyncResult asyncResult);
      #endif
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


      
      #if SILVERLIGHT
      
      public IAsyncResult Begin_Say(AsyncCallback callback, object state, Ruyi.SDK.Speech.VoiceCommand command)
      {
        return send_Say(callback, state, command);
      }

      public Ruyi.SDK.Speech.SpeechResult End_Say(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        return recv_Say();
      }

      #endif

      public Ruyi.SDK.Speech.SpeechResult Say(Ruyi.SDK.Speech.VoiceCommand command)
      {
        #if SILVERLIGHT
        var asyncResult = Begin_Say(null, null, command);
        return End_Say(asyncResult);

        #else
        send_Say(command);
        return recv_Say();

        #endif
      }
      #if SILVERLIGHT
      public IAsyncResult send_Say(AsyncCallback callback, object state, Ruyi.SDK.Speech.VoiceCommand command)
      {
        oprot_.WriteMessageBegin(new TMessage("Say", TMessageType.Call, seqid_));
        Say_args args = new Say_args();
        args.Command = command;
        args.Write(oprot_);
        oprot_.WriteMessageEnd();
        return oprot_.Transport.BeginFlush(callback, state);
      }

      #else

      public void send_Say(Ruyi.SDK.Speech.VoiceCommand command)
      {
        oprot_.WriteMessageBegin(new TMessage("Say", TMessageType.Call, seqid_));
        Say_args args = new Say_args();
        args.Command = command;
        args.Write(oprot_);
        oprot_.WriteMessageEnd();
        oprot_.Transport.Flush();
      }
      #endif

      public Ruyi.SDK.Speech.SpeechResult recv_Say()
      {
        TMessage msg = iprot_.ReadMessageBegin();
        if (msg.Type == TMessageType.Exception) {
          TApplicationException x = TApplicationException.Read(iprot_);
          iprot_.ReadMessageEnd();
          throw x;
        }
        Say_result result = new Say_result();
        result.Read(iprot_);
        iprot_.ReadMessageEnd();
        if (result.__isset.success) {
          return result.Success;
        }
        throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "Say failed: unknown result");
      }

    }
    public class Processor : TProcessor {
      public Processor(ISync iface)
      {
        iface_ = iface;
        processMap_["Say"] = Say_Process;
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

      public void Say_Process(int seqid, TProtocol iprot, TProtocol oprot)
      {
        Say_args args = new Say_args();
        args.Read(iprot);
        iprot.ReadMessageEnd();
        Say_result result = new Say_result();
        try
        {
          result.Success = iface_.Say(args.Command);
          oprot.WriteMessageBegin(new TMessage("Say", TMessageType.Reply, seqid)); 
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
          oprot.WriteMessageBegin(new TMessage("Say", TMessageType.Exception, seqid));
          x.Write(oprot);
        }
        oprot.WriteMessageEnd();
        oprot.Transport.Flush();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class Say_args : TBase
    {
      private Ruyi.SDK.Speech.VoiceCommand _command;

      public Ruyi.SDK.Speech.VoiceCommand Command
      {
        get
        {
          return _command;
        }
        set
        {
          __isset.command = true;
          this._command = value;
        }
      }


      public Isset __isset;
      #if !SILVERLIGHT
      [Serializable]
      #endif
      public struct Isset {
        public bool command;
      }

      public Say_args() {
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
                  Command = new Ruyi.SDK.Speech.VoiceCommand();
                  Command.Read(iprot);
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
          TStruct struc = new TStruct("Say_args");
          oprot.WriteStructBegin(struc);
          TField field = new TField();
          if (Command != null && __isset.command) {
            field.Name = "command";
            field.Type = TType.Struct;
            field.ID = 1;
            oprot.WriteFieldBegin(field);
            Command.Write(oprot);
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
        StringBuilder __sb = new StringBuilder("Say_args(");
        bool __first = true;
        if (Command != null && __isset.command) {
          if(!__first) { __sb.Append(", "); }
          __first = false;
          __sb.Append("Command: ");
          __sb.Append(Command== null ? "<null>" : Command.ToString());
        }
        __sb.Append(")");
        return __sb.ToString();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class Say_result : TBase
    {
      private Ruyi.SDK.Speech.SpeechResult _success;

      /// <summary>
      /// 
      /// <seealso cref="Ruyi.SDK.Speech.SpeechResult"/>
      /// </summary>
      public Ruyi.SDK.Speech.SpeechResult Success
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

      public Say_result() {
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
                if (field.Type == TType.I32) {
                  Success = (Ruyi.SDK.Speech.SpeechResult)iprot.ReadI32();
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
          TStruct struc = new TStruct("Say_result");
          oprot.WriteStructBegin(struc);
          TField field = new TField();

          if (this.__isset.success) {
            field.Name = "Success";
            field.Type = TType.I32;
            field.ID = 0;
            oprot.WriteFieldBegin(field);
            oprot.WriteI32((int)Success);
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
        StringBuilder __sb = new StringBuilder("Say_result(");
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

  }
}
