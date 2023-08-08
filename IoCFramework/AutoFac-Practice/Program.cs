using Autofac;
using AutoFac_Practice;
using System.ComponentModel;
ContainerBuilder cb = new ContainerBuilder();

cb.RegisterType<ConsoleWriter>().As<IWriter>();

