/**
 * Autogenerated by Thrift Compiler (0.11.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
#include "ConstantsSDKDataTypes_constants.h"

namespace Ruyi { namespace SDK { namespace Constants {

const ConstantsSDKDataTypesConstants g_ConstantsSDKDataTypes_constants;

ConstantsSDKDataTypesConstants::ConstantsSDKDataTypesConstants() {
  low_latency_socket_port = 11290;

  high_latency_socket_port = 11390;

  layer0_broker_address = "tcp://{addr}:5555";

  layer0_publisher_in_uri = "tcp://{addr}:5567";

  layer0_publisher_out_uri = "tcp://{addr}:5568";

  setting_config_folder = "resources/configs/";

  setting_system_config = "resources/configs/systemsetting";

  setting_system_user_config = "resources/configs/usersetting";

  system_setting_version = "1.0.0.1";

  layer0_debugger_channel = "layer0_debugger_channel";

  trc_test_channel = "trc_test_channel";

  broker_playback_message = "mmi.developer.playback";

  HDD0_DRIVER_TAG = "/<hdd0>/";

  MEMCACHE_DRIVER_TAG = "/<memcache>/";

  HTTP_HDD_CACHE_DRIVER_TAG = "/<httphddcache>/";

  HTTP_MEM_CACHE_DRIVER_TAG = "/<httpmemcache>/";

  RESOURCES_DRIVER_TAG = "/<resources>/";

  MEDIA_DRIVER_TAG = "/<media>/";

  DOWNLOAD_DRIVER_TAG = "/<download>/";

  DATA_DRIVER_TAG = "/<data>/";

}

}}} // namespace

