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
pub enum CondType {
  EXEPRESENT = 0,
  FILEPRESENT = 1,
  FILEABSENT = 2,
  ARGPRESENT = 3,
  ARGABSENT = 4,
}

impl CondType {
  pub fn write_to_out_protocol(&self, o_prot: &mut TOutputProtocol) -> thrift::Result<()> {
    o_prot.write_i32(*self as i32)
  }
  pub fn read_from_in_protocol(i_prot: &mut TInputProtocol) -> thrift::Result<CondType> {
    let enum_value = i_prot.read_i32()?;
    CondType::try_from(enum_value)  }
}

impl TryFrom<i32> for CondType {
  type Err = thrift::Error;  fn try_from(i: i32) -> Result<Self, Self::Err> {
    match i {
      0 => Ok(CondType::EXEPRESENT),
      1 => Ok(CondType::FILEPRESENT),
      2 => Ok(CondType::FILEABSENT),
      3 => Ok(CondType::ARGPRESENT),
      4 => Ok(CondType::ARGABSENT),
      _ => {
        Err(
          thrift::Error::Protocol(
            ProtocolError::new(
              ProtocolErrorKind::InvalidData,
              format!("cannot convert enum constant {} to CondType", i)
            )
          )
        )
      },
    }
  }
}

//
// Runtime
//

#[derive(Clone, Debug, Eq, Hash, Ord, PartialEq, PartialOrd)]
pub struct Runtime {
}

impl Runtime {
  pub fn new() -> Runtime {
    Runtime {}
  }
  pub fn read_from_in_protocol(i_prot: &mut TInputProtocol) -> thrift::Result<Runtime> {
    i_prot.read_struct_begin()?;
    loop {
      let field_ident = i_prot.read_field_begin()?;
      if field_ident.field_type == TType::Stop {
        break;
      }
      let field_id = field_id(&field_ident)?;
      match field_id {
        _ => {
          i_prot.skip(field_ident.field_type)?;
        },
      };
      i_prot.read_field_end()?;
    }
    i_prot.read_struct_end()?;
    let ret = Runtime {};
    Ok(ret)
  }
  pub fn write_to_out_protocol(&self, o_prot: &mut TOutputProtocol) -> thrift::Result<()> {
    let struct_ident = TStructIdentifier::new("Runtime");
    o_prot.write_struct_begin(&struct_ident)?;
    o_prot.write_field_stop()?;
    o_prot.write_struct_end()
  }
}

impl Default for Runtime {
  fn default() -> Self {
    Runtime{}
  }
}

//
// GameDB
//

#[derive(Clone, Debug, Eq, Hash, Ord, PartialEq, PartialOrd)]
pub struct GameDB {
  pub id: Option<i32>,
  pub name: Option<String>,
  pub conditions: Option<Vec<Box<Cond>>>,
  pub detection: Option<Vec<Box<Variant>>>,
  pub runtime: Option<Runtime>,
}

impl GameDB {
  pub fn new<F1, F2, F3, F4, F5>(id: F1, name: F2, conditions: F3, detection: F4, runtime: F5) -> GameDB where F1: Into<Option<i32>>, F2: Into<Option<String>>, F3: Into<Option<Vec<Box<Cond>>>>, F4: Into<Option<Vec<Box<Variant>>>>, F5: Into<Option<Runtime>> {
    GameDB {
      id: id.into(),
      name: name.into(),
      conditions: conditions.into(),
      detection: detection.into(),
      runtime: runtime.into(),
    }
  }
  pub fn read_from_in_protocol(i_prot: &mut TInputProtocol) -> thrift::Result<GameDB> {
    i_prot.read_struct_begin()?;
    let mut f_1: Option<i32> = Some(0);
    let mut f_2: Option<String> = Some("".to_owned());
    let mut f_3: Option<Vec<Box<Cond>>> = Some(Vec::new());
    let mut f_4: Option<Vec<Box<Variant>>> = Some(Vec::new());
    let mut f_5: Option<Runtime> = None;
    loop {
      let field_ident = i_prot.read_field_begin()?;
      if field_ident.field_type == TType::Stop {
        break;
      }
      let field_id = field_id(&field_ident)?;
      match field_id {
        1 => {
          let val = i_prot.read_i32()?;
          f_1 = Some(val);
        },
        2 => {
          let val = i_prot.read_string()?;
          f_2 = Some(val);
        },
        3 => {
          let list_ident = i_prot.read_list_begin()?;
          let mut val: Vec<Box<Cond>> = Vec::with_capacity(list_ident.size as usize);
          for _ in 0..list_ident.size {
            let list_elem_0 = Box::new(Cond::read_from_in_protocol(i_prot)?);
            val.push(list_elem_0);
          }
          i_prot.read_list_end()?;
          f_3 = Some(val);
        },
        4 => {
          let list_ident = i_prot.read_list_begin()?;
          let mut val: Vec<Box<Variant>> = Vec::with_capacity(list_ident.size as usize);
          for _ in 0..list_ident.size {
            let list_elem_1 = Box::new(Variant::read_from_in_protocol(i_prot)?);
            val.push(list_elem_1);
          }
          i_prot.read_list_end()?;
          f_4 = Some(val);
        },
        5 => {
          let val = Runtime::read_from_in_protocol(i_prot)?;
          f_5 = Some(val);
        },
        _ => {
          i_prot.skip(field_ident.field_type)?;
        },
      };
      i_prot.read_field_end()?;
    }
    i_prot.read_struct_end()?;
    let ret = GameDB {
      id: f_1,
      name: f_2,
      conditions: f_3,
      detection: f_4,
      runtime: f_5,
    };
    Ok(ret)
  }
  pub fn write_to_out_protocol(&self, o_prot: &mut TOutputProtocol) -> thrift::Result<()> {
    let struct_ident = TStructIdentifier::new("GameDB");
    o_prot.write_struct_begin(&struct_ident)?;
    if let Some(fld_var) = self.id {
      o_prot.write_field_begin(&TFieldIdentifier::new("id", TType::I32, 1))?;
      o_prot.write_i32(fld_var)?;
      o_prot.write_field_end()?;
      ()
    } else {
      ()
    }
    if let Some(ref fld_var) = self.name {
      o_prot.write_field_begin(&TFieldIdentifier::new("name", TType::String, 2))?;
      o_prot.write_string(fld_var)?;
      o_prot.write_field_end()?;
      ()
    } else {
      ()
    }
    if let Some(ref fld_var) = self.conditions {
      o_prot.write_field_begin(&TFieldIdentifier::new("conditions", TType::List, 3))?;
      o_prot.write_list_begin(&TListIdentifier::new(TType::Struct, fld_var.len() as i32))?;
      for e in fld_var {
        e.write_to_out_protocol(o_prot)?;
        o_prot.write_list_end()?;
      }
      o_prot.write_field_end()?;
      ()
    } else {
      ()
    }
    if let Some(ref fld_var) = self.detection {
      o_prot.write_field_begin(&TFieldIdentifier::new("detection", TType::List, 4))?;
      o_prot.write_list_begin(&TListIdentifier::new(TType::Struct, fld_var.len() as i32))?;
      for e in fld_var {
        e.write_to_out_protocol(o_prot)?;
        o_prot.write_list_end()?;
      }
      o_prot.write_field_end()?;
      ()
    } else {
      ()
    }
    if let Some(ref fld_var) = self.runtime {
      o_prot.write_field_begin(&TFieldIdentifier::new("runtime", TType::Struct, 5))?;
      fld_var.write_to_out_protocol(o_prot)?;
      o_prot.write_field_end()?;
      ()
    } else {
      ()
    }
    o_prot.write_field_stop()?;
    o_prot.write_struct_end()
  }
}

impl Default for GameDB {
  fn default() -> Self {
    GameDB{
      id: Some(0),
      name: Some("".to_owned()),
      conditions: Some(Vec::new()),
      detection: Some(Vec::new()),
      runtime: None,
    }
  }
}

//
// Cond
//

#[derive(Clone, Debug, Eq, Hash, Ord, PartialEq, PartialOrd)]
pub struct Cond {
  pub name: Option<String>,
  pub type_: Option<CondType>,
  pub additional_arg: Option<String>,
}

impl Cond {
  pub fn new<F1, F2, F3>(name: F1, type_: F2, additional_arg: F3) -> Cond where F1: Into<Option<String>>, F2: Into<Option<CondType>>, F3: Into<Option<String>> {
    Cond {
      name: name.into(),
      type_: type_.into(),
      additional_arg: additional_arg.into(),
    }
  }
  pub fn read_from_in_protocol(i_prot: &mut TInputProtocol) -> thrift::Result<Cond> {
    i_prot.read_struct_begin()?;
    let mut f_1: Option<String> = Some("".to_owned());
    let mut f_2: Option<CondType> = None;
    let mut f_3: Option<String> = Some("".to_owned());
    loop {
      let field_ident = i_prot.read_field_begin()?;
      if field_ident.field_type == TType::Stop {
        break;
      }
      let field_id = field_id(&field_ident)?;
      match field_id {
        1 => {
          let val = i_prot.read_string()?;
          f_1 = Some(val);
        },
        2 => {
          let val = CondType::read_from_in_protocol(i_prot)?;
          f_2 = Some(val);
        },
        3 => {
          let val = i_prot.read_string()?;
          f_3 = Some(val);
        },
        _ => {
          i_prot.skip(field_ident.field_type)?;
        },
      };
      i_prot.read_field_end()?;
    }
    i_prot.read_struct_end()?;
    let ret = Cond {
      name: f_1,
      type_: f_2,
      additional_arg: f_3,
    };
    Ok(ret)
  }
  pub fn write_to_out_protocol(&self, o_prot: &mut TOutputProtocol) -> thrift::Result<()> {
    let struct_ident = TStructIdentifier::new("Cond");
    o_prot.write_struct_begin(&struct_ident)?;
    if let Some(ref fld_var) = self.name {
      o_prot.write_field_begin(&TFieldIdentifier::new("name", TType::String, 1))?;
      o_prot.write_string(fld_var)?;
      o_prot.write_field_end()?;
      ()
    } else {
      ()
    }
    if let Some(ref fld_var) = self.type_ {
      o_prot.write_field_begin(&TFieldIdentifier::new("type", TType::I32, 2))?;
      fld_var.write_to_out_protocol(o_prot)?;
      o_prot.write_field_end()?;
      ()
    } else {
      ()
    }
    if let Some(ref fld_var) = self.additional_arg {
      o_prot.write_field_begin(&TFieldIdentifier::new("additionalArg", TType::String, 3))?;
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

impl Default for Cond {
  fn default() -> Self {
    Cond{
      name: Some("".to_owned()),
      type_: None,
      additional_arg: Some("".to_owned()),
    }
  }
}

//
// Variant
//

#[derive(Clone, Debug, Eq, Hash, Ord, PartialEq, PartialOrd)]
pub struct Variant {
  pub name: Option<String>,
  pub id: Option<String>,
  pub order: Option<String>,
  pub rules: Option<Vec<Box<If>>>,
}

impl Variant {
  pub fn new<F1, F2, F3, F4>(name: F1, id: F2, order: F3, rules: F4) -> Variant where F1: Into<Option<String>>, F2: Into<Option<String>>, F3: Into<Option<String>>, F4: Into<Option<Vec<Box<If>>>> {
    Variant {
      name: name.into(),
      id: id.into(),
      order: order.into(),
      rules: rules.into(),
    }
  }
  pub fn read_from_in_protocol(i_prot: &mut TInputProtocol) -> thrift::Result<Variant> {
    i_prot.read_struct_begin()?;
    let mut f_1: Option<String> = Some("".to_owned());
    let mut f_2: Option<String> = Some("".to_owned());
    let mut f_3: Option<String> = Some("".to_owned());
    let mut f_4: Option<Vec<Box<If>>> = Some(Vec::new());
    loop {
      let field_ident = i_prot.read_field_begin()?;
      if field_ident.field_type == TType::Stop {
        break;
      }
      let field_id = field_id(&field_ident)?;
      match field_id {
        1 => {
          let val = i_prot.read_string()?;
          f_1 = Some(val);
        },
        2 => {
          let val = i_prot.read_string()?;
          f_2 = Some(val);
        },
        3 => {
          let val = i_prot.read_string()?;
          f_3 = Some(val);
        },
        4 => {
          let list_ident = i_prot.read_list_begin()?;
          let mut val: Vec<Box<If>> = Vec::with_capacity(list_ident.size as usize);
          for _ in 0..list_ident.size {
            let list_elem_2 = Box::new(If::read_from_in_protocol(i_prot)?);
            val.push(list_elem_2);
          }
          i_prot.read_list_end()?;
          f_4 = Some(val);
        },
        _ => {
          i_prot.skip(field_ident.field_type)?;
        },
      };
      i_prot.read_field_end()?;
    }
    i_prot.read_struct_end()?;
    let ret = Variant {
      name: f_1,
      id: f_2,
      order: f_3,
      rules: f_4,
    };
    Ok(ret)
  }
  pub fn write_to_out_protocol(&self, o_prot: &mut TOutputProtocol) -> thrift::Result<()> {
    let struct_ident = TStructIdentifier::new("Variant");
    o_prot.write_struct_begin(&struct_ident)?;
    if let Some(ref fld_var) = self.name {
      o_prot.write_field_begin(&TFieldIdentifier::new("name", TType::String, 1))?;
      o_prot.write_string(fld_var)?;
      o_prot.write_field_end()?;
      ()
    } else {
      ()
    }
    if let Some(ref fld_var) = self.id {
      o_prot.write_field_begin(&TFieldIdentifier::new("id", TType::String, 2))?;
      o_prot.write_string(fld_var)?;
      o_prot.write_field_end()?;
      ()
    } else {
      ()
    }
    if let Some(ref fld_var) = self.order {
      o_prot.write_field_begin(&TFieldIdentifier::new("order", TType::String, 3))?;
      o_prot.write_string(fld_var)?;
      o_prot.write_field_end()?;
      ()
    } else {
      ()
    }
    if let Some(ref fld_var) = self.rules {
      o_prot.write_field_begin(&TFieldIdentifier::new("rules", TType::List, 4))?;
      o_prot.write_list_begin(&TListIdentifier::new(TType::Struct, fld_var.len() as i32))?;
      for e in fld_var {
        e.write_to_out_protocol(o_prot)?;
        o_prot.write_list_end()?;
      }
      o_prot.write_field_end()?;
      ()
    } else {
      ()
    }
    o_prot.write_field_stop()?;
    o_prot.write_struct_end()
  }
}

impl Default for Variant {
  fn default() -> Self {
    Variant{
      name: Some("".to_owned()),
      id: Some("".to_owned()),
      order: Some("".to_owned()),
      rules: Some(Vec::new()),
    }
  }
}

//
// If
//

#[derive(Clone, Debug, Eq, Hash, Ord, PartialEq, PartialOrd)]
pub struct If {
  pub cond: Option<String>,
}

impl If {
  pub fn new<F1>(cond: F1) -> If where F1: Into<Option<String>> {
    If {
      cond: cond.into(),
    }
  }
  pub fn read_from_in_protocol(i_prot: &mut TInputProtocol) -> thrift::Result<If> {
    i_prot.read_struct_begin()?;
    let mut f_1: Option<String> = Some("".to_owned());
    loop {
      let field_ident = i_prot.read_field_begin()?;
      if field_ident.field_type == TType::Stop {
        break;
      }
      let field_id = field_id(&field_ident)?;
      match field_id {
        1 => {
          let val = i_prot.read_string()?;
          f_1 = Some(val);
        },
        _ => {
          i_prot.skip(field_ident.field_type)?;
        },
      };
      i_prot.read_field_end()?;
    }
    i_prot.read_struct_end()?;
    let ret = If {
      cond: f_1,
    };
    Ok(ret)
  }
  pub fn write_to_out_protocol(&self, o_prot: &mut TOutputProtocol) -> thrift::Result<()> {
    let struct_ident = TStructIdentifier::new("If");
    o_prot.write_struct_begin(&struct_ident)?;
    if let Some(ref fld_var) = self.cond {
      o_prot.write_field_begin(&TFieldIdentifier::new("cond", TType::String, 1))?;
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

impl Default for If {
  fn default() -> Self {
    If{
      cond: Some("".to_owned()),
    }
  }
}

