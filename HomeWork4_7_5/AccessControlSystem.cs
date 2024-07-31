namespace HomeWork4_7_5;


public class AccessControlSystem {
    public static void CheckAccess(object employee, int requiredLevel) {

        Type type = employee.GetType();
        AccessLevelAttribute accessLevelAttribute = (AccessLevelAttribute)Attribute.GetCustomAttribute(type, typeof(AccessLevelAttribute));

        if (accessLevelAttribute != null) {
            if (accessLevelAttribute.Level >= requiredLevel) {
                Console.WriteLine($"{type.Name} has access to the protected section");
            } else {
                Console.WriteLine($"{type.Name} does not have access to the protected section");
            }
        } else {
            Console.WriteLine($"{type.Name} has no defined access level");
        }
    }
}
