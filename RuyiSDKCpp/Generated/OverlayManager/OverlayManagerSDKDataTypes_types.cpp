/**
 * Autogenerated by Thrift Compiler (0.11.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
#include "OverlayManagerSDKDataTypes_types.h"

#include <algorithm>
#include <ostream>

#include <thrift/TToString.h>

namespace Ruyi { namespace SDK { namespace Overlay {


OverlayState::~OverlayState() throw() {
}


void OverlayState::__set_isVisible(const bool val) {
  this->isVisible = val;
}

void OverlayState::__set_arguments(const std::string& val) {
  this->arguments = val;
}
std::ostream& operator<<(std::ostream& out, const OverlayState& obj)
{
  obj.printTo(out);
  return out;
}


uint32_t OverlayState::read(::apache::thrift::protocol::TProtocol* iprot) {

  ::apache::thrift::protocol::TInputRecursionTracker tracker(*iprot);
  uint32_t xfer = 0;
  std::string fname;
  ::apache::thrift::protocol::TType ftype;
  int16_t fid;

  xfer += iprot->readStructBegin(fname);

  using ::apache::thrift::protocol::TProtocolException;


  while (true)
  {
    xfer += iprot->readFieldBegin(fname, ftype, fid);
    if (ftype == ::apache::thrift::protocol::T_STOP) {
      break;
    }
    switch (fid)
    {
      case 1:
        if (ftype == ::apache::thrift::protocol::T_BOOL) {
          xfer += iprot->readBool(this->isVisible);
          this->__isset.isVisible = true;
        } else {
          xfer += iprot->skip(ftype);
        }
        break;
      case 2:
        if (ftype == ::apache::thrift::protocol::T_STRING) {
          xfer += iprot->readString(this->arguments);
          this->__isset.arguments = true;
        } else {
          xfer += iprot->skip(ftype);
        }
        break;
      default:
        xfer += iprot->skip(ftype);
        break;
    }
    xfer += iprot->readFieldEnd();
  }

  xfer += iprot->readStructEnd();

  return xfer;
}

uint32_t OverlayState::write(::apache::thrift::protocol::TProtocol* oprot) const {
  uint32_t xfer = 0;
  ::apache::thrift::protocol::TOutputRecursionTracker tracker(*oprot);
  xfer += oprot->writeStructBegin("OverlayState");

  xfer += oprot->writeFieldBegin("isVisible", ::apache::thrift::protocol::T_BOOL, 1);
  xfer += oprot->writeBool(this->isVisible);
  xfer += oprot->writeFieldEnd();

  xfer += oprot->writeFieldBegin("arguments", ::apache::thrift::protocol::T_STRING, 2);
  xfer += oprot->writeString(this->arguments);
  xfer += oprot->writeFieldEnd();

  xfer += oprot->writeFieldStop();
  xfer += oprot->writeStructEnd();
  return xfer;
}

void swap(OverlayState &a, OverlayState &b) {
  using ::std::swap;
  swap(a.isVisible, b.isVisible);
  swap(a.arguments, b.arguments);
  swap(a.__isset, b.__isset);
}

OverlayState::OverlayState(const OverlayState& other0) {
  isVisible = other0.isVisible;
  arguments = other0.arguments;
  __isset = other0.__isset;
}
OverlayState& OverlayState::operator=(const OverlayState& other1) {
  isVisible = other1.isVisible;
  arguments = other1.arguments;
  __isset = other1.__isset;
  return *this;
}
void OverlayState::printTo(std::ostream& out) const {
  using ::apache::thrift::to_string;
  out << "OverlayState(";
  out << "isVisible=" << to_string(isVisible);
  out << ", " << "arguments=" << to_string(arguments);
  out << ")";
}


NotifyTakeScreenShot::~NotifyTakeScreenShot() throw() {
}

std::ostream& operator<<(std::ostream& out, const NotifyTakeScreenShot& obj)
{
  obj.printTo(out);
  return out;
}


uint32_t NotifyTakeScreenShot::read(::apache::thrift::protocol::TProtocol* iprot) {

  ::apache::thrift::protocol::TInputRecursionTracker tracker(*iprot);
  uint32_t xfer = 0;
  std::string fname;
  ::apache::thrift::protocol::TType ftype;
  int16_t fid;

  xfer += iprot->readStructBegin(fname);

  using ::apache::thrift::protocol::TProtocolException;


  while (true)
  {
    xfer += iprot->readFieldBegin(fname, ftype, fid);
    if (ftype == ::apache::thrift::protocol::T_STOP) {
      break;
    }
    xfer += iprot->skip(ftype);
    xfer += iprot->readFieldEnd();
  }

  xfer += iprot->readStructEnd();

  return xfer;
}

uint32_t NotifyTakeScreenShot::write(::apache::thrift::protocol::TProtocol* oprot) const {
  uint32_t xfer = 0;
  ::apache::thrift::protocol::TOutputRecursionTracker tracker(*oprot);
  xfer += oprot->writeStructBegin("NotifyTakeScreenShot");

  xfer += oprot->writeFieldStop();
  xfer += oprot->writeStructEnd();
  return xfer;
}

void swap(NotifyTakeScreenShot &a, NotifyTakeScreenShot &b) {
  using ::std::swap;
  (void) a;
  (void) b;
}

NotifyTakeScreenShot::NotifyTakeScreenShot(const NotifyTakeScreenShot& other2) {
  (void) other2;
}
NotifyTakeScreenShot& NotifyTakeScreenShot::operator=(const NotifyTakeScreenShot& other3) {
  (void) other3;
  return *this;
}
void NotifyTakeScreenShot::printTo(std::ostream& out) const {
  using ::apache::thrift::to_string;
  out << "NotifyTakeScreenShot(";
  out << ")";
}


VideoCaptureState::~VideoCaptureState() throw() {
}


void VideoCaptureState::__set_isRecording(const bool val) {
  this->isRecording = val;
}
std::ostream& operator<<(std::ostream& out, const VideoCaptureState& obj)
{
  obj.printTo(out);
  return out;
}


uint32_t VideoCaptureState::read(::apache::thrift::protocol::TProtocol* iprot) {

  ::apache::thrift::protocol::TInputRecursionTracker tracker(*iprot);
  uint32_t xfer = 0;
  std::string fname;
  ::apache::thrift::protocol::TType ftype;
  int16_t fid;

  xfer += iprot->readStructBegin(fname);

  using ::apache::thrift::protocol::TProtocolException;


  while (true)
  {
    xfer += iprot->readFieldBegin(fname, ftype, fid);
    if (ftype == ::apache::thrift::protocol::T_STOP) {
      break;
    }
    switch (fid)
    {
      case 1:
        if (ftype == ::apache::thrift::protocol::T_BOOL) {
          xfer += iprot->readBool(this->isRecording);
          this->__isset.isRecording = true;
        } else {
          xfer += iprot->skip(ftype);
        }
        break;
      default:
        xfer += iprot->skip(ftype);
        break;
    }
    xfer += iprot->readFieldEnd();
  }

  xfer += iprot->readStructEnd();

  return xfer;
}

uint32_t VideoCaptureState::write(::apache::thrift::protocol::TProtocol* oprot) const {
  uint32_t xfer = 0;
  ::apache::thrift::protocol::TOutputRecursionTracker tracker(*oprot);
  xfer += oprot->writeStructBegin("VideoCaptureState");

  xfer += oprot->writeFieldBegin("isRecording", ::apache::thrift::protocol::T_BOOL, 1);
  xfer += oprot->writeBool(this->isRecording);
  xfer += oprot->writeFieldEnd();

  xfer += oprot->writeFieldStop();
  xfer += oprot->writeStructEnd();
  return xfer;
}

void swap(VideoCaptureState &a, VideoCaptureState &b) {
  using ::std::swap;
  swap(a.isRecording, b.isRecording);
  swap(a.__isset, b.__isset);
}

VideoCaptureState::VideoCaptureState(const VideoCaptureState& other4) {
  isRecording = other4.isRecording;
  __isset = other4.__isset;
}
VideoCaptureState& VideoCaptureState::operator=(const VideoCaptureState& other5) {
  isRecording = other5.isRecording;
  __isset = other5.__isset;
  return *this;
}
void VideoCaptureState::printTo(std::ostream& out) const {
  using ::apache::thrift::to_string;
  out << "VideoCaptureState(";
  out << "isRecording=" << to_string(isRecording);
  out << ")";
}

}}} // namespace
