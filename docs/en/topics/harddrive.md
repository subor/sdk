# Hard Drive

Ruyi has two drive bays for 2.5" SATA drives (max 9.5mm height):

* The drive in the center of the device is the _primary_ drive and __must__ be present as Ruyi always boots from this drive.
* The other drive is the _secondary_ drive and is optional.

Early Ruyi devkits shipped with a single Toshiba HDD.

Later Ruyi devkits shipped with a 128 GB SSD and 1 TB HDD.

Partitioning scheme between [RuyiOS](os.md) and [PC mode](pc_mode.md):

| Ruyi OS Version | Primary Drive | Secondary Drive
|-|-|-
| v0.5 or lower | 100% RuyiOS | Not supported
| v0.6 or higher | 50/50 RuyiOS/PC mode | 30/70 RuyiOS/PC mode

## Maintenance

1. Make sure Ruyi is powered off, and flip it over
1. Slide switch in __Open__ direction
1. While holding switch in open position, gently pull hard drive cover towards the front of the Ruyi:  
![](/docs/img/harddrive_cover_open.jpg)
1. When installing a drive, make sure it is upright in the frame with the connector pointing out:  
![](/docs/img/harddrive_rail.jpg)
1. When finished, replace hard drive cover by gently pushing it back into place