using System;
using Common.Logging.Factory;

namespace Common.Logging.EventSource
{
    public class EventSourceLogger : AbstractLogger
    {
        private readonly static CommonLoggingEventSource Log = CommonLoggingEventSource.Log;
        private readonly string _loggerName;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventSourceLogger"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <exception cref="System.ArgumentNullException">name</exception>
        /// <exception cref="System.ArgumentException">name</exception>
        public EventSourceLogger(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("name");
            }

            _loggerName = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventSourceLogger"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <exception cref="System.ArgumentNullException">type</exception>
        public EventSourceLogger(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            _loggerName = type.FullName;
        }

        protected string LoggerName { get { return _loggerName; } }

        public override bool IsTraceEnabled
        {
            get
            {
                bool enabled = Log.IsEnabled();
                return enabled;
            }
        }

        public override bool IsDebugEnabled
        {
            get
            {
                bool enabled = Log.IsEnabled();
                return enabled;
            }
        }

        public override bool IsErrorEnabled
        {
            get
            {
                bool enabled = Log.IsEnabled();
                return enabled;
            }
        }

        public override bool IsFatalEnabled
        {
            get
            {
                bool enabled = Log.IsEnabled();
                return enabled;
            }
        }

        public override bool IsInfoEnabled
        {
            get
            {
                bool enabled = Log.IsEnabled();
                return enabled;
            }
        }

        public override bool IsWarnEnabled
        {
            get
            {
                bool enabled = Log.IsEnabled();
                return enabled;
            }
        }

        protected override void WriteInternal(LogLevel level, object message, Exception exception)
        {
            var entry = new EventSourceLogEntry(level, LoggerName, message, exception);

            Action<string, string, EventSourceLogEntry> write = GetWriteAction(level);
            write(LoggerName, entry.Message, entry);
        }

        private Action<string, string, EventSourceLogEntry> GetWriteAction(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Fatal:
                    return Log.Fatal;
                case LogLevel.Error:
                    return Log.Error;
                case LogLevel.Warn:
                    return Log.Warn;
                case LogLevel.Info:
                    return Log.Info;
                case LogLevel.Debug:
                    return Log.Debug;
                case LogLevel.Trace:
                    return Log.Trace;
            }

            Action<string, string, EventSourceLogEntry> doNotWrite = (name, msg, e) => { /* do nothing */ };
            return doNotWrite;
        }
    }
}