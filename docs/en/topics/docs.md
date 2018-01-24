# Documentation

This documentation is hosted in [__docs__ repository](https://bitbucket.org/playruyi/docs).  
Use `git clone https://your_username_here@bitbucket.org/playruyi/docs.git` (or [Sourcetree](https://www.sourcetreeapp.com/)) to the clone the repository.

Create a [pull request](https://bitbucket.org/playruyi/docs/pull-requests/) to submit changes to us for review:  
![](/docs/img/pull_requests.png)

## Formatting Guidelines

- __Bold__
	- Listing a series of __UI -> menu -> iteractions__
	- Specifying a __short/path/__ or __filename.txt__.
- _Italics_
	- Bringing attention to a _general area_
	- __Anywhere bold__ _is already_ __overused__
- `code`
	- Invidual keys or combinations like: `Enter`, `Ctrl+Alt+Del`
	- Commands lines or other typed text
	- Portions or references to file text (including source code), console output, etc.

## Editing tips

- Markdown references:
	- [Bitbucket markdown](https://bitbucket.org/tutorials/markdowndemo/overview)
	- [Daring Fireball](https://daringfireball.net/projects/markdown/syntax)

- Linking to latest version of a file in Bitbucket:

    Note use of `master` (the branch name) rather than SHA1 hash

      https://bitbucket.org/playruyi/docs/src/master/docs/en/topics/support.md

- Linking to support ticket/issue:

    Where `1` is replaced by desired [issue number](https://bitbucket.org/playruyi/support/issues?status=new&status=open)

      https://bitbucket.org/playruyi/support/issues/1

- We use [Visual Studio Code](https://code.visualstudio.com/).  Check their [markdown editing tips](https://code.visualstudio.com/Docs/languages/markdown) for how to preview changes:  
![](/docs/img/docs_vs_code_preview.png)

- Configure VS Code to insert spaces instead of tabs:

	1. Click __View -> Command Palette...__ (or press `Ctrl+Shift+P`)  
	![](/docs/img/vscode_command.png)
	1. Type all or part of `indent using spaces`  
	![](/docs/img/vscode_indent_using.png)

    OR

	1. Click in the lower-right of the window  
	![](/docs/img/vscode_lower_right.png)
	1. Select `Indent Using Spaces`  
	![](/docs/img/vscode_spaces.png)