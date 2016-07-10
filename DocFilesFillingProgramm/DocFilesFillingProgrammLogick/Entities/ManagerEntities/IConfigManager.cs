namespace DocFilesFillingProgrammLogick.Entities.ManagetEntities
{
    public interface IConfigManager
    {
        string this[string key]
        {
            get;
        }
    }
}
