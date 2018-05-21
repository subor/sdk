# 技术支持

您可以通过以下方式找到帮助:

- [常见问题](../faq.md)
- [开发者论坛](http://dev.playruyi.com/forum/) 
- 在[技术支持仓库（Support repository）](https://bitbucket.org/playruyi/support)提交问题
- 发送邮件到dev-support@playruyi.com

其他来源:

- [版本发布信息](release_notes.md)

## 查找已发现/解决的问题

1. 在浏览器中打开 [技术支持仓库（Support repository）](https://bitbucket.org/playruyi/support)
1. 在左侧面板中选择问题（__Issues__），显示目前的问题。
1. 通过过滤功能（__FILTER BY__）来过滤显示的问题。
1. 使用右上角的搜索框（__Advanced search__）来寻找相似问题。  
![](/docs/img/support_search.png)
1. 点击问题名，显示详细信息。
![](/docs/img/support_issue.png)
    - 为问题添加评论（__comments__）
    - 点击为该问题投票（__Vote for the issue__）引起Ruyi团队关注，加速问题解决

## 提交发现问题

1. 在浏览器中打开 [技术支持仓库（support repository）](https://bitbucket.org/playruyi/support)
1. 在左侧面板中选择问题（__Issues__），显示当前问题列表  
![](/docs/img/support_issues.png)
1. 通过右上角的搜索框，可以快速找到相似问题（请优先使用该方法）
1. 如果无法找到和您相似的问题, 可以点击创建问题（__Create issue__）来提交您的问题
![](/docs/img/support_create_issue.png)
1. 完成问题表单
    - 被分配者（__Assignee__）- 不要填写
    - 题目（__Title__）- 尽量精短，描述准确
    - 描述（__Description__）- 包含问题相关信息:
        - 重现该问题的步骤
        - [Ruyi操作系统版本](os.md#Version)
        - 注意使用标记[（markdown）](https://bitbucket.org/tutorials/markdowndemo/overview)功能
    - 分类（__Kind__）- 如果是bug请选“_bug_”，如果是意见/评论/需求/或者其他，请任意选择除“_bug_”外的选项。
    - 组件（__Component__）- 选择分类最接近的选项:  
    ![](/docs/img/support_issue_component.png)
    - 版本（__Version__）- SDK版本号 (右键layer0.exe选择属性，在“详细”（__Details__）页签查看)
1. 添加附件，以帮助我们更快定位问题
    - 相关截图和视频
    - Layer0的日志文件 (`layer0.log`)
    - Main Client的日志文件 (`MainClient/client.log`)
1. 点击创建问题（__Create issue__）提交

## 需求/建议

和[提交发现问题](support.md#Reporting-an-issue)类似, 除了在分类（__Kind__）项选择 改进（_Enhancement_） 或 建议（_Proposal_）.

![](/docs/img/support_suggestion.png)

### 投票

如果对问题感兴趣, 可以点击右上角的__为该问题投票__（__Vote for this issue__）:  

![](/docs/img/support_vote.png)