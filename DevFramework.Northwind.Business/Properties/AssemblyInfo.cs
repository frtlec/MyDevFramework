using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using DevFramework.Core.Aspects.Postsharp.LogAspects;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using DevFramework.Core.Aspects.Postsharp.ExceptionAspects;

//logger
[assembly:LogAspect(typeof(FileLogger),AttributeTargetTypes= "DevFramework.Northwind.Business.Concrete.Managers.*")]
[assembly: LogAspect(typeof(DatabaseLogger), AttributeTargetTypes = "DevFramework.Northwind.Business.Concrete.Managers.*")]
[assembly: ExceptionLogAspect(typeof(DatabaseLogger))]