# Gamesdb.xml Format

If a [simple entry](overlay.md#Compatibility) isn't working for your application, you might need to create a more advanced entry.  It might be necessary in the following cases:

* Your exe is a commonly used or very generic name
* Your application is composed of multiple executables
* You need to enable/disable [runtime features](#Runtime-element)

This section describes the full grammar of the gamesdb.xml file.  If you still can't get it working, [get help](support.md).

## Overview

Gamesdb.xml contains numerous entries similar to:
```
<game>
    <id>9999</id> 
    <name>YourGameName</name>
    <conditions>
        <cond name="is-YourGameName.exe-present" type="exe-present" exe="YourGameName.exe"/>
    </conditions>
    <detection>
        <variant order="1" name="default">
            <if cond="is-YourGameName.exe-present"/>
        </variant>
    </detection>
    <runtime>
        <features>
            <option enabled="true"/>
        </features>
    </runtime>
</game>
```

If the rules specified by a `<variant>` matches for a running executable, it will be identified as an instance of the application specified by `<game>`.  Then the overlay will attach to the application based on `<runtime>`.

| XML Element | Description | Required | Details
|-|-|-|-
| id | App ID assigned to you by Subor ([link](dev_onboarding.md)) | Yes | E.g. `<id>12345</id>`
| name | Title of your application | Yes | E.g. `<name>Ruyi Test App</name>`
| conditions | All the environment conditions used in `<detection>` to specify `<variant>` rules | Yes | See [Conditions Element](#conditions-element)
| detection | Specify `<variant>` rules used to identify applications | Yes | See [Detection Element](#detection-element)
| runtime | Enables/disables `<features>` at runtime | No | See [Runtime Element](#conditions-element)

## Conditions Element

`<conditions>` contains one or more `<cond>` elements.  These are simple environment checks that are combined in [`<detection>`](#Detection-element).

Format is: `<cond name="CONDITION_NAME" type="TYPE" TYPE_ATTR="ADDITIONAL_ARG" />`

Where `CONDITION_NAME` is the unique name of the condition.

And `TYPE`, `TYPE_ATTR`, and `ADDITIONAL_ARG` are defined as follows:
| TYPE | Description | TYPE_ATTR | ADDITIONAL_ARG
|-|-|-|-
| exe-present | Matches name of executable | `exe` | Name of running executable
| file-present | Checks for presence of a file | `file` | Path of file
| file-absent | Checks for absence of a file | `file` | Path of file
| arg-present | Checks for presense of command-line argument | `arg` | Command line argument
| arg-absent | Checks for absence of command-line argument | `arg` | Command line argument
| reg-value-op | Deprecated | 

If __TYPE__ is `file-present` or `file-absent`, the `file` attribute may use the following macros:
| Macro | Description
|-|-|-
| `{exedir}` | Directory containing running executable
| `{exe}` | Name of running executable

## Detection Element

`<detection>` contains one or more `<variant>` elements.  Each `<variant>` contains one or more rules.  If all the rules in a `<variant>` match, then an instance of an application is detected.

The following rules are supported:
| Rule | Description | Example
|-|-|-
| `if` | Check if `<cond>` specified in `<condition>` is true | `<if name="CONDITION_NAME" />`

## Runtime Element

When the overlay attaches to an application, `<runtime>` configures some aspect of the hooking or rendering.

All are similar to `<ELEMENT ATTR="VALUE" />`:
| ELEMENT | ATTR | VALUE | Description | Default
|-|-|-|-|-
| overlay | enabled | true/false |
| forcebind | enabled | true/false |
| forcetopmost | enabled | true/false |
| opengl-vbo-rendering | enabled | true/false |
| opengl-state-hooking | enabled | true/false |
| game-window-subclassing | enabled | true/false | Deprecated
| forcerenderer | type | direct3d/opengl | Force overlay to use specified rendering API | Auto-detect
| forcecursor | type | software/hardware | Force overlay to use hardware/software cursor |
| renderer-hooking | method | intrusive/factory | Deprecated
| party-network | | | Deprecated