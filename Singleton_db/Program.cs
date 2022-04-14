// See https://aka.ms/new-console-template for more information

using Autofac;
using NUnit.Framework;
using Singleton_db;

var db = SingletonDatabase.Instance;

ContainerBuilder builder = new ContainerBuilder();

Console.WriteLine(db.GetPopulation("My"));

Console.WriteLine("Hello, World!");