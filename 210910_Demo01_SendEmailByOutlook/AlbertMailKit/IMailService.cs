using MailKit.Net.Smtp;

namespace _210910_Demo01_SendEmailByOutlook
{
    public interface IMailService
    {
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <returns></returns>
        SendResultEntity SendMail();

        /// <summary>
        /// 接收邮件
        /// </summary>
        void ReceiveEmail();

        /// <summary>
        /// 下载邮件内容
        /// </summary>
        void DownloadBodyParts();
    }
}