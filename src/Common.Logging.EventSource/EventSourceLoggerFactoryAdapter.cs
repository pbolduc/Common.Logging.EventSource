using Common.Logging.Configuration;
using System;

namespace Common.Logging.EventSource
{
    public class EventSourceLoggerFactoryAdapter : ILoggerFactoryAdapter
    {
                /// <summary>
        /// Initializes a new instance of the <see cref="EventSourceLoggerFactoryAdapter"/> class.
        /// </summary>
        /// <param name="properties">The properties.</param>
        public EventSourceLoggerFactoryAdapter(NameValueCollection properties)
        {
            if (properties == null)
            {
                throw new ArgumentNullException("properties");
            }
        }

        /// <summary>
        /// Get a ILog instance by type.
        /// </summary>
        /// <param name="type">The type to use for the logger</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">type</exception>
        public ILog GetLogger(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            return new EventSourceLogger(type);
        }

        /// <summary>
        /// Get a ILog instance by name.
        /// </summary>
        /// <param name="name">The name of the logger</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">name</exception>
        /// <exception cref="System.ArgumentException">name</exception>
        public ILog GetLogger(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("name");
            }

            return new EventSourceLogger(name);
        }
    }
}
