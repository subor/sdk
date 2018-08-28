using System;
using System.Collections.Generic;
using System.Globalization;

namespace Ruyi.Logging
{
    public interface IFilter
    {
        bool Filter(LoggerMessage lm);

        void SetLogLevel(LogLevel lv);
    }

    public interface IFilterRule
    {
        bool Match(LoggerMessage lm);
    }

    public static class ListHelper
    {
        public static bool ExistTailFor(this List<string> ll, string ta)
        {
            for (int i = 0; i < ll.Count; i++)
            {
                if (ta.EndsWith(ll[i], StringComparison.CurrentCultureIgnoreCase))
                    return true;
            }
            return false;
        }
    }

    public class LogLevelRule : IFilterRule
    {
        public List<LogLevel> ValidLevels { get; set; }

        public bool Match(LoggerMessage lm)
        {
            if (ValidLevels == null || ValidLevels.Contains(lm.Level))
                return true;

            return false;
        }

        public void SetValid(List<LogLevel> valid, bool forall = false)
        {
            if (forall)
                ValidLevels = null;
            else
                ValidLevels = valid;
        }
    }

    public class LogSourceRule : IFilterRule
    {
        public List<string> ValidSources { get; set; }

        public bool Match(LoggerMessage lm)
        {
            if (ValidSources == null || ValidSources.ExistTailFor(lm.MsgSource))
                return true;

            return false;
        }

        public void SetValid(List<string> valid, bool forall = false)
        {
            if (forall)
                ValidSources = null;
            else
                ValidSources = valid;
        }
    }

    public class LogCategoryRule : IFilterRule
    {
        public List<MessageCategory> ValidCategaries { get; set; }

        public bool Match(LoggerMessage lm)
        {
            if (ValidCategaries == null || ValidCategaries.Contains(lm.Category))
                return true;

            return false;
        }

        public void SetValid(List<MessageCategory> valid, bool forall = false)
        {
            if (forall)
                ValidCategaries = null;
            else
                ValidCategaries = valid;
        }
    }

    public class LogServiceRule : IFilterRule
    {
        public List<string> ValidServices { get; set; }

        public bool Match(LoggerMessage lm)
        {
            if (lm.Category == MessageCategory.Publisher
                || (lm.Category == MessageCategory.Request && (ValidServices == null || ValidServices.ExistTailFor(lm.MsgTarget)))
                || (lm.Category == MessageCategory.Reply && (ValidServices == null || ValidServices.ExistTailFor(lm.MsgSource))))
                return true;

            return false;
        }

        public void SetValid(List<string> valid, bool forall = false)
        {
            if (forall)
                ValidServices = null;
            else
                ValidServices = valid;
        }
    }

    public class LogTopicRule : IFilterRule
    {
        public List<string> ValidTopic { get; set; }

        public bool Match(LoggerMessage lm)
        {
            if (ValidTopic == null || string.IsNullOrEmpty(lm.Topic))
                return true;

            if ((lm.Category == MessageCategory.Request || lm.Category == MessageCategory.Reply || lm.Category == MessageCategory.Framework)
                || ((lm.Category == MessageCategory.Publisher || lm.Category == MessageCategory.Subscriber)
                && (ValidTopic.ExistTailFor(lm.Topic))))
                return true;

            return false;
        }

        public void SetValid(List<string> valid, bool forall = false)
        {
            if (forall)
                ValidTopic = null;
            else
                ValidTopic = valid;
        }
    }

    public class LoggerFilter : IFilter
    {
        private List<IFilterRule> rules = new List<IFilterRule>();

        public LogLevelRule LevelRule { get; set; }
        //		public LogSourceRule SourceRule { get; set; }
        public LogCategoryRule CategoryRule { get; set; }
        public LogServiceRule ServiceRule { get; set; }
        public LogTopicRule TopicRule { get; set; }

        public LoggerFilter()
        {
            LevelRule = new LogLevelRule();
            rules.Add(LevelRule);

            //			SourceRule = new LogSourceRule();
            //			rules.Add(SourceRule);

            CategoryRule = new LogCategoryRule();
            rules.Add(CategoryRule);

            ServiceRule = new LogServiceRule();
            rules.Add(ServiceRule);

            TopicRule = new LogTopicRule();
            rules.Add(TopicRule);
        }

        public bool Filter(LoggerMessage lm)
        {
            for (int i = 0; i < rules.Count; i++)
            {
                if (!rules[i].Match(lm))
                    return false;
            }

            return true;
        }

        public void SetLogLevel(LogLevel lv)
        {
            List<LogLevel> lvs = new List<LogLevel>();
            foreach (var ll in Enum.GetValues(typeof(LogLevel)))
            {
                if ((int)ll >= (int)lv)
                    lvs.Add((LogLevel)ll);
            }
            LevelRule.SetValid(lvs);
        }
    }

    public class TRCFilter : IFilter
    {
        public bool Filter(LoggerMessage lm)
        {
            return lm.Category == MessageCategory.TRC;
        }

        public void SetLogLevel(LogLevel lv)
        {
        }
    }
}
