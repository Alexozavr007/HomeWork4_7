namespace HomeWork4_7_5;

public class AccessLevelAttribute : Attribute{

    public int Level;

    public AccessLevelAttribute(int level) {
        Level = level;
    }
}
