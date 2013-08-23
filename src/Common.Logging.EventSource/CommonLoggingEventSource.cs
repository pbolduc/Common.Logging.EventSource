using System.Diagnostics.Tracing;

namespace Common.Logging.EventSource
{
    /// <summary>
    /// Logs the details of the internals of Quartz.Net
    /// </summary>
    [EventSource(Guid = EventSourceNameId, Name = EventSourceName)]
    public abstract class CommonLoggingEventSource : System.Diagnostics.Tracing.EventSource
    {
        /// <summary>
        /// Gets the id of the event source.
        /// </summary>
        /// <remarks>
        /// The value of this constant is &quot;dab0da4f-7fc0-42dc-bbcd-2275412951d1&quot;
        /// </remarks>
        public const string EventSourceNameId = "dab0da4f-7fc0-42dc-bbcd-2275412951d1";

        /// <summary>
        /// Gets the name of the event source
        /// </summary>
        /// <remarks>
        /// The value of this constant is &quot;Common-Logging&quot;
        /// </remarks>
        public const string EventSourceName = "Common-Logging";

        public static CommonLoggingEventSource Log = EventSourceProxy.EventSourceImplementer.GetEventSourceAs<CommonLoggingEventSource>();
        private const string MessageFormat = "{1}";

        [Event(EventId.Fatal, Level = EventLevel.Critical, Message = MessageFormat)]
        public abstract void Fatal(string loggerName, string message, EventSourceLogEntry entry);

        [Event(EventId.Error, Level = EventLevel.Error, Message = MessageFormat)]
        public abstract void Error(string loggerName, string message, EventSourceLogEntry entry);

        [Event(EventId.Warn, Level = EventLevel.Warning, Message = MessageFormat)]
        public abstract void Warn(string loggerName, string message, EventSourceLogEntry entry);

        [Event(EventId.Info, Level = EventLevel.Informational, Message = MessageFormat)]
        public abstract void Info(string loggerName, string message, EventSourceLogEntry entry);

        [Event(EventId.Debug, Level = EventLevel.Verbose, Message = MessageFormat)]
        public abstract void Debug(string loggerName, string message, EventSourceLogEntry entry);

        [Event(EventId.Trace, Level = EventLevel.Verbose, Message = MessageFormat)]
        public abstract void Trace(string loggerName, string message, EventSourceLogEntry entry);

        private static class EventId
        {
            public const int Fatal = (int)LogLevel.Fatal;
            public const int Error = (int)LogLevel.Error;
            public const int Warn = (int)LogLevel.Warn;
            public const int Info = (int)LogLevel.Info;
            public const int Debug = (int)LogLevel.Debug;
            public const int Trace = (int)LogLevel.Trace;
        }
    }
}