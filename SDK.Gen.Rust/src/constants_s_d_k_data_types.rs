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

pub const LOW_LATENCY_SOCKET_PORT: i32 = 11290;

pub const HIGH_LATENCY_SOCKET_PORT: i32 = 11390;

pub const LAYER0_BROKER_ADDRESS: &str = "tcp://{addr}:5555";

pub const LAYER0_PUBLISHER_IN_URI: &str = "tcp://{addr}:5567";

pub const LAYER0_PUBLISHER_OUT_URI: &str = "tcp://{addr}:5568";

pub const SETTING_CONFIG_FOLDER: &str = "resources/configs/";

pub const SETTING_SYSTEM_CONFIG: &str = "resources/configs/systemsetting";

pub const SETTING_SYSTEM_USER_CONFIG: &str = "resources/configs/usersetting";

pub const SYSTEM_SETTING_VERSION: &str = "1.0.0.1";

pub const LAYER0_DEBUGGER_CHANNEL: &str = "layer0_debugger_channel";

pub const TRC_TEST_CHANNEL: &str = "trc_test_channel";

pub const BROKER_PLAYBACK_MESSAGE: &str = "mmi.developer.playback";

