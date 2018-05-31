# 文档

本文位于[__docs__ 仓库](https://bitbucket.org/playruyi/docs).  
GIT仓库地址`git clone https://your_username_here@bitbucket.org/playruyi/docs.git`(或[Sourcetree](https://www.sourcetreeapp.com/))

创建一个[拉拽请求(pull request)](https://bitbucket.org/playruyi/docs/pull-requests/)来提交更新(我们会负责审核):  
![](/docs/img/pull_requests.png)

## 格式说明

- __粗体(Bold)__
	- __界面 -> 菜单 -> 子菜单等__ 的标题 
	- 特指 __文件/路径/__ 或 __文件名.txt__.
- _斜体(Italics)_
	- 特强某段 _内容区域_
	- __任何粗体__  内容 _已经_ __无法再使用斜体__
- `代码块(code)`
	- 单个关键字(词)或组合，比如: `Enter`, `Ctrl+Alt+Del`
	- 命令行语句或者其他打印文字
	- 文件内容的部分引用(包括源代码)，终端输出等等。

## 编辑提示

- 下标(markdown)参考:
	- [Bitbucket下标(markdown)说明](https://bitbucket.org/tutorials/markdowndemo/overview)
	- [Daring Fireball](https://daringfireball.net/projects/markdown/syntax)

- 将某段内容链接到Bitbucket上的某个文件最新版本:

    注意下面链接中使用的是`master`分支名而不是SHA1哈希值

      https://bitbucket.org/playruyi/docs/src/master/docs/en/topics/support.md

- 将某段内容链接到问题(issue):

    注意替换下面链接中的`1`为需要的[问题(issue)编号](https://bitbucket.org/playruyi/support/issues?status=new&status=open)

      https://bitbucket.org/playruyi/support/issues/1

- 我们使用[Visual Studio Code](https://code.visualstudio.com/)。查看相应的[下标编辑提示](https://code.visualstudio.com/Docs/languages/markdown):  
![](/docs/img/docs_vs_code_preview.png)

- 配置VS Code，更改插入制表符(tab)为空白(spaces):

	1. 点击__View -> Command Palette...__ (或者按`Ctrl+Shift+P`)  
	![](/docs/img/vscode_command.png)
	1. 输入`indent using spaces`  
	![](/docs/img/vscode_indent_using.png)

    或者

	1. 点击窗口右下角  
	![](/docs/img/vscode_lower_right.png)
	1. 选择`Indent Using Spaces`  
	![](/docs/img/vscode_spaces.png)