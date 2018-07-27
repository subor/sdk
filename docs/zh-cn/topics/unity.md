# Unity 3D

我们计划在Ruyi主机上对基于[Unity 3D](https://unity3d.com/)的开发提供"第一级别"的支持力度。

## 前提条件

- Unity 2017.1.1f1 (之后版本也应该适用)

## 快速开始

RuyiNet类提供了Ruyi C# API的上层封装。

1. [下载SDK的Unity组件包](http://dev.playruyi.com/udownloadslist/SDK)，导入项目中(Assets->Import Package->Custom Package...). 
1. 创建一个RuyiNet类的实例，填写应用ID/密码:  
![](/docs/img/unity_ruyinet.png)
1. 在__Edit/Project Settings/Player__, 点开 _Other Settings_, 设置 __Api Compatibility Level__ 为`.NET 2.0`

## 进阶使用

__即将到来__

## 链接

- [Unity示例GIT](https://bitbucket.org/playruyi/space_shooter)
- [Unity示例使用说明](../tutorials/run_unity_sample_console.md)