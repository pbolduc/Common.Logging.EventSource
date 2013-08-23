using System;
using Newtonsoft.Json;

namespace Common.Logging.EventSource
{
    [Serializable]
    public class EventSourceLogEntry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventSourceLogEntry"/> class.
        /// </summary>
        /// <param name="level">The level.</param>
        /// <param name="name">The name.</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public EventSourceLogEntry(LogLevel level, string name, object message, Exception exception)
        {
            Message = string.Format("{0}", message);
            Level = level.ToString();
            LoggerName = name;

            if (exception != null)
            {
                Exception = exception;
                StackTrace = exception.StackTrace;
            }
        }

        public string Message { get; set; }
        public string Level { get; set; }
        public string LoggerName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Exception Exception { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string StackTrace { get; set; }
    }
}