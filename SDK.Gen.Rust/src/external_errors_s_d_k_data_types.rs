// Autogenerated by Thrift Compiler (0.11.0)
// DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING

#![allow(unused_imports)]
#![allow(unused_extern_crates)]
#![cfg_attr(feature = "cargo-clippy", allow(too_many_arguments, type_complexity))]
#![cfg_attr(rustfmt, rustfmt_skip)]

extern crate ordered_float;
extern crate thrift;
extern crate try_from;

use ordered_float::OrderedFloat;
use std::cell::RefCell;
use std::collections::{BTreeMap, BTreeSet};
use std::convert::From;
use std::default::Default;
use std::error::Error;
use std::fmt;
use std::fmt::{Display, Formatter};
use std::rc::Rc;
use try_from::TryFrom;

use thrift::{ApplicationError, ApplicationErrorKind, ProtocolError, ProtocolErrorKind, TThriftClient};
use thrift::protocol::{TFieldIdentifier, TListIdentifier, TMapIdentifier, TMessageIdentifier, TMessageType, TInputProtocol, TOutputProtocol, TSetIdentifier, TStructIdentifier, TType};
use thrift::protocol::field_id;
use thrift::protocol::verify_expected_message_type;
use thrift::protocol::verify_expected_sequence_number;
use thrift::protocol::verify_expected_service_call;
use thrift::protocol::verify_required_field_exists;
use thrift::server::TProcessor;

#[derive(Copy, Clone, Debug, Eq, Hash, Ord, PartialEq, PartialOrd)]
pub enum ExternalErrorCode {
  ERR_0 = 0,
  ERR_1 = 1,
  ERR_2 = 2,
  ERR_3 = 3,
  ERR_4 = 4,
  ERR_5 = 5,
  ERR_6 = 6,
  ERR_7 = 7,
  ERR_8 = 8,
  ERR_9 = 9,
  ERR_10 = 10,
  ERR_11 = 11,
  ERR_12 = 12,
  ERR_13 = 13,
  ERR_14 = 14,
  ERR_15 = 15,
  ERR_16 = 16,
  ERR_17 = 17,
  ERR_18 = 18,
}

impl ExternalErrorCode {
  pub fn write_to_out_protocol(&self, o_prot: &mut TOutputProtocol) -> thrift::Result<()> {
    o_prot.write_i32(*self as i32)
  }
  pub fn read_from_in_protocol(i_prot: &mut TInputProtocol) -> thrift::Result<ExternalErrorCode> {
    let enum_value = i_prot.read_i32()?;
    ExternalErrorCode::try_from(enum_value)  }
}

impl TryFrom<i32> for ExternalErrorCode {
  type Err = thrift::Error;  fn try_from(i: i32) -> Result<Self, Self::Err> {
    match i {
      0 => Ok(ExternalErrorCode::ERR_0),
      1 => Ok(ExternalErrorCode::ERR_1),
      2 => Ok(ExternalErrorCode::ERR_2),
      3 => Ok(ExternalErrorCode::ERR_3),
      4 => Ok(ExternalErrorCode::ERR_4),
      5 => Ok(ExternalErrorCode::ERR_5),
      6 => Ok(ExternalErrorCode::ERR_6),
      7 => Ok(ExternalErrorCode::ERR_7),
      8 => Ok(ExternalErrorCode::ERR_8),
      9 => Ok(ExternalErrorCode::ERR_9),
      10 => Ok(ExternalErrorCode::ERR_10),
      11 => Ok(ExternalErrorCode::ERR_11),
      12 => Ok(ExternalErrorCode::ERR_12),
      13 => Ok(ExternalErrorCode::ERR_13),
      14 => Ok(ExternalErrorCode::ERR_14),
      15 => Ok(ExternalErrorCode::ERR_15),
      16 => Ok(ExternalErrorCode::ERR_16),
      17 => Ok(ExternalErrorCode::ERR_17),
      18 => Ok(ExternalErrorCode::ERR_18),
      _ => {
        Err(
          thrift::Error::Protocol(
            ProtocolError::new(
              ProtocolErrorKind::InvalidData,
              format!("cannot convert enum constant {} to ExternalErrorCode", i)
            )
          )
        )
      },
    }
  }
}

//
// ExternalErrorInfos
//

#[derive(Clone, Debug, Eq, Hash, Ord, PartialEq, PartialOrd)]
pub struct ExternalErrorInfos {
  pub error_code: Option<ExternalErrorCode>,
  pub description: Option<String>,
}

impl ExternalErrorInfos {
  pub fn new<F1, F2>(error_code: F1, description: F2) -> ExternalErrorInfos where F1: Into<Option<ExternalErrorCode>>, F2: Into<Option<String>> {
    ExternalErrorInfos {
      error_code: error_code.into(),
      description: description.into(),
    }
  }
  pub fn read_from_in_protocol(i_prot: &mut TInputProtocol) -> thrift::Result<ExternalErrorInfos> {
    i_prot.read_struct_begin()?;
    let mut f_1: Option<ExternalErrorCode> = None;
    let mut f_2: Option<String> = Some("".to_owned());
    loop {
      let field_ident = i_prot.read_field_begin()?;
      if field_ident.field_type == TType::Stop {
        break;
      }
      let field_id = field_id(&field_ident)?;
      match field_id {
        1 => {
          let val = ExternalErrorCode::read_from_in_protocol(i_prot)?;
          f_1 = Some(val);
        },
        2 => {
          let val = i_prot.read_string()?;
          f_2 = Some(val);
        },
        _ => {
          i_prot.skip(field_ident.field_type)?;
        },
      };
      i_prot.read_field_end()?;
    }
    i_prot.read_struct_end()?;
    let ret = ExternalErrorInfos {
      error_code: f_1,
      description: f_2,
    };
    Ok(ret)
  }
  pub fn write_to_out_protocol(&self, o_prot: &mut TOutputProtocol) -> thrift::Result<()> {
    let struct_ident = TStructIdentifier::new("ExternalErrorInfos");
    o_prot.write_struct_begin(&struct_ident)?;
    if let Some(ref fld_var) = self.error_code {
      o_prot.write_field_begin(&TFieldIdentifier::new("errorCode", TType::I32, 1))?;
      fld_var.write_to_out_protocol(o_prot)?;
      o_prot.write_field_end()?;
      ()
    } else {
      ()
    }
    if let Some(ref fld_var) = self.description {
      o_prot.write_field_begin(&TFieldIdentifier::new("description", TType::String, 2))?;
      o_prot.write_string(fld_var)?;
      o_prot.write_field_end()?;
      ()
    } else {
      ()
    }
    o_prot.write_field_stop()?;
    o_prot.write_struct_end()
  }
}

impl Default for ExternalErrorInfos {
  fn default() -> Self {
    ExternalErrorInfos{
      error_code: None,
      description: Some("".to_owned()),
    }
  }
}

pub struct ConstEXTERNALERRORLIST;
impl ConstEXTERNALERRORLIST {
  pub fn const_value() -> Vec<ExternalErrorInfos> {
    {
      let mut l: Vec<ExternalErrorInfos> = Vec::new();
      l.push(
        {
          unimplemented!()
        }
      );
      l.push(
        {
          unimplemented!()
        }
      );
      l.push(
        {
          unimplemented!()
        }
      );
      l.push(
        {
          unimplemented!()
        }
      );
      l.push(
        {
          unimplemented!()
        }
      );
      l.push(
        {
          unimplemented!()
        }
      );
      l.push(
        {
          unimplemented!()
        }
      );
      l.push(
        {
          unimplemented!()
        }
      );
      l.push(
        {
          unimplemented!()
        }
      );
      l.push(
        {
          unimplemented!()
        }
      );
      l.push(
        {
          unimplemented!()
        }
      );
      l.push(
        {
          unimplemented!()
        }
      );
      l.push(
        {
          unimplemented!()
        }
      );
      l.push(
        {
          unimplemented!()
        }
      );
      l.push(
        {
          unimplemented!()
        }
      );
      l.push(
        {
          unimplemented!()
        }
      );
      l.push(
        {
          unimplemented!()
        }
      );
      l.push(
        {
          unimplemented!()
        }
      );
      l.push(
        {
          unimplemented!()
        }
      );
      l
    }
  }
}

