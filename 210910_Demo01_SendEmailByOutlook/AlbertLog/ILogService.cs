namespace _210910_Demo01_SendEmailByOutlook.AlbertLog
{
    public interface ILogService {
        void LogErr(string msgErr);
        void LogInfo(string msgInfo);
    }
}