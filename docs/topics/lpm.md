# Low-Power Mode

Low-power mode (LPM) is a special feature of the console where it consumes less power than normal.  Note that this is different from special power states found on normal laptops and desktops (i.e. [S3, S4](https://msdn.microsoft.com/en-us/library/windows/desktop/aa373229(v=vs.85).aspx)) and is actually still S5.

Reduced hardware functionality/performance:

- Single CPU core at 600 MHz (other 3 cores power-gated)
- GPU and related IPs (including HW encoder/decoder) clock-gated
- Display off
- Memory bandwidth reduced to 51.2 GB/s

In this mode the [OS](os.md) and [platform](layer0.md) are still running- albeit with reduced functionality and performance.

This mode is intended for:

- Downloading/uploading
- Patching of both the system and applications
- "Always-on" fileserver
- IoT functionality

Because of the above constraints, apps will need to react to notifications that the console is about to switch to LPM and shutdown.

## Switching

You can enter LPM by doing any of the following:  
- Press and release power button on front of console and wait 2 seconds
- From main client, select __Settings > Power > Switch to LPM__
- In [PC mode](pc_mode),  can use [Z+ Assist](ruyi_assist)

You can exit LPM and switch back to "High-Power Mode" (HPM- normal operation) by:
- Press and release power button on front of console
- Pressing "home" button on gamepad
- Any mouse/keyboard input
