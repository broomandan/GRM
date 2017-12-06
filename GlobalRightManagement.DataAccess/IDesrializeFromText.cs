namespace GlobalRightManagement.DataAccess
{
    public interface IDesrializeFromText<out T>
    {
        T DeserializeFromText(string line, char delimeter);
    }
}