# Low-Power Mode

Low-power mode (LPM) is a special feature of the Ruyi console where it consumes less power than normal.  Note that this is different from special power states found on normal laptops and desktops ([S3, S4](https://msdn.microsoft.com/en-us/library/windows/desktop/aa373229(v=vs.85).aspx)) and is really still S5.

Reduced hardware functionality/performance:

- Single CPU core at 600 MHz (other 3 cores power-gated)
- GPU and other IPs (including encoder/decoder) clock-gated
- Display off
- Memory bandwidth 51.2 GB/s

In this mode the [OS](os.md) and [Ruyi platform](layer0.md) are still running- albeit with reduced functionality (and performance).

This mode is intended for:

- Downloading/uploading
- Patching of both the system and applications
- "Always-on" fileserver