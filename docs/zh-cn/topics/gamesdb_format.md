# Gamesdb.xml格式

如果你的游戏在默认的[标签记录](overlay.md#Compatibility)下无法使用,可以添加更多标签，在以下情况下可能会适用：

* 你的exe文件是一个常用通用的游戏
* 你的游戏由很多可执行文件组成
* 你需要开启/不开启[<runtime><features>]标签内的enabled值(true/false)(#Runtime-element)

本文档会详细解释gamesdb.xml文件的所有标签结构。如果你的游戏仍然无法使用游戏内界面(Overlay)功能，可以在这里[请求帮助](support.md).

## 综述

Gamesdb.xml包含大量如下所示的标签结构:
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

如果在`<variant>`标签中定义的规则和启动游戏的可执行文件匹配，该游戏则会被识别为<game>标签所定义的游戏实例。
之后游戏内界面（overlay）程序会根据`<runtime>`内的值是否附加到该游戏进程中。

| XML 元素 | 说明 | 是否必须 | 详细
|-|-|-|-
| id | 小霸王提供的App ID([link](dev_onboarding.md)) | 是 | 比如`<id>12345</id>`
| name | 游戏名称（注意是运行时进程名称） | 是 | 比如`<name>Ruyi Test App</name>`
| conditions | 游戏运行的外部环境条件，需要在`<detection>``<variant>`内具体定义 | 是 | 参考[Conditions 元素](#conditions-element)
| detection | 在`<variant>`定义的规则，以此来识别程序 | 是 | 参考[Detection 元素](#detection-element)
| runtime | 运行时是否启动/不启动`<features>` | 否 | 参考[Runtime 元素](#conditions-element)

## Conditions 元素

`<conditions>`可以包含一个或多个`<cond>`。`<cond>`内容是程序运行的条件检测（判断程序是否运行等等），具体在[`<detection>`](#Detection-element)中定义是否检测该条件.

格式: `<cond name="CONDITION_NAME" type="TYPE" TYPE_ATTR="ADDITIONAL_ARG" />`

`CONDITION_NAME`是条件的名称（唯一）

`TYPE`、`TYPE_ATTR`和`ADDITIONAL_ARG`定义如下:

| TYPE | 描述 | TYPE_ATTR | ADDITIONAL_ARG
|-|-|-|-
| exe-present | 可执行文件名检测 | `exe` | 可执行文件名称
| file-present | 检测对应文件是否存在 | `file` | 文件路径
| file-absent | 检测对应文件是否不存在 | `file` | 文件路径
| arg-present | 检测对应命令行参数是否存在 | `arg` | 命令行参数
| arg-absent | 检测对应命令行参数是否存在 | `arg` | 命令行参数
| reg-value-op | 已过时 | 

如果 __TYPE__ 为`file-present`或`file-absent`，那么`file`属性值可以使用以下宏:

| Macro | Description
|-|-|-
| `{exedir}` | 包含可执行文件的文件夹
| `{exe}` | 可执行文件名称

## Detection 元素

`<detection>`包含一个或多个`<variant>`。每个`<variant>`包含一个或多个规则。如果所有在`<variant>`定义的规则都匹配，那么该游戏实例会被检测到。

支持以下规则:

| 规则 | 描述 | 例子
|-|-|-
| `if` | 检查在`<cond>`下对应 [`<conditions>`](#Conditions-element)定义的条件是否满足 | `<if name="CONDITION_NAME" />`

## Runtime 元素

当游戏内界面(overlay)程序附加到游戏进程后，`<runtime>`决定其是否挂钩或渲染。

具体格式类似`<ELEMENT ATTR="VALUE" />`:

| ELEMENT | ATTR | VALUE | 说明 | 默认值
|-|-|-|-|-
| overlay | enabled | true/false | | true
| forcebind | enabled | true/false | | false
| forcetopmost | enabled | true/false | | false
| opengl-vbo-rendering | enabled | true/false | | true
| opengl-state-hooking | enabled | true/false | | true
| game-window-subclassing | enabled | true/false | Deprecated | true
| forcerenderer | type | direct3d/opengl | 强制 overlay使用特定渲染API | `""`; Auto-detect
| forcecursor | type | software/hardware | 强制 overlay使用硬件/软件光标 | `""`; Auto
| renderer-hooking | method | normal/intrusive/factory | 已过时 | normal
| party-network | | | 已过时