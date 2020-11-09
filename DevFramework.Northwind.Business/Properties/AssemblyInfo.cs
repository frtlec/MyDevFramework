using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using DevFramework.Core.Aspects.Postsharp.LogAspects;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using DevFramework.Core.Aspects.Postsharp.ExceptionAspects;
using DevFramework.Core.Aspects.Postsharp.PerformanceAspects;

//logger
//[assembly: LogAspect(typeof(DatabaseLogger), AttributeTargetTypes = "DevFramework.Northwind.Business.Concrete.Managers.*")]
//[assembly: ExceptionLogAspect(typeof(DatabaseLogger), AttributeTargetTypes = "DevFramework.Northwind.Business.Concrete.Managers.*")]
[assembly: PerformanceCounterAspect( AttributeTargetTypes = "DevFramework.Northwind.Business.Concrete.Managers.*")]