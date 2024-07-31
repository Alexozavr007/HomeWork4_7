using HomeWork4_7_5;
using static HomeWork4_7_5.Employee;

Programmer programmer = new Programmer();
Manager manager = new Manager();
Director director = new Director();

int requiredAccessLevel = 2;

//AccessLevelAttribute accessLevelAttribute = (AccessLevelAttribute)Attribute.GetCustomAttribute(type, typeof(AccessLevelAttribute));

AccessControlSystem.CheckAccess(programmer, requiredAccessLevel);
AccessControlSystem.CheckAccess(manager, requiredAccessLevel);
AccessControlSystem.CheckAccess(director, requiredAccessLevel);