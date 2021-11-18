namespace MinimalApiDemo.BackEnd;


public interface IDataService
{
    public List<string> GetStrings();
}
public class DataService: IDataService
{
    public List<string> GetStrings() => new List<string> { "one", "two", "three", "Four" };
}
