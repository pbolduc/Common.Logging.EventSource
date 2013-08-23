Common.Logging.EventSource
=========================

[Common.Logging.EventSource on NuGet](https://www.nuget.org/packages/Common.Logging.EventSource/)

Provides a Common.Logging logging adapter to redirect log messages to ETW.
In conjunction with Semantic Logging block, events can be written to Azure
storage.

**Event Source Name**: Common-Logging

**Event Source Guid**: dab0da4f-7fc0-42dc-bbcd-2275412951d1


Log Levels are mapped to [Event Levels](http://msdn.microsoft.com/en-us/library/system.diagnostics.tracing.eventlevel.aspx) using the following mapping:

| Common Logging Log Level | Event Level              |
|--------------------------|--------------------------|
| LogLevel.Fatal           | EventLevel.Critical      |
| LogLevel.Error           | EventLevel.Error         |
| LogLevel.Warn            | EventLevel.Warning       |
| LogLevel.Info            | EventLevel.Informational |
| LogLevel.Debug           | EventLevel.Verbose       |
| LogLevel.Trace           | EventLevel.Verbose       |

Sample configuration pragmatically:

	// create properties (no properties are required)
	NameValueCollection properties = new NameValueCollection();

	// set Adapter
	var adapter = new EventSourceLoggerFactoryAdapter(properties);
	LogManager.Adapter = adapter;

	
To configure using configuration file:

	<configuration>
	  <configSections>
		<sectionGroup name="common">
		  <section name="logging" type="Common.Logging.ConfigurationSectionHandler, Common.Logging" />
		</sectionGroup>
	  </configSections>

	  <common>
		<logging>
		  <factoryAdapter type="Common.Logging.EventSource.EventSourceLoggerFactoryAdapter, Common.Logging.EventSource">
		  </factoryAdapter>
		</logging>
	  </common>
	</configuration> 

To Do
-----
* allow inclusion/exclusion of specific logger names
* allow restricting the logging level at the event source (ie avoid Debug/Trace level events from ever reaching ETW) globally or for specific loggers.  Common Logging and ETW take different approaches to who is responsible for setting the log level, however, this could be a valuable feature.
* add unit tests
* add sample applications
