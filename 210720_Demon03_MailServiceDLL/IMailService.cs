using System;
using System.Collections.Generic;
using System.Text;

namespace _210720_Demon03_MailServiceDLL {
    public interface IMailService {
        void Send(string iniPaht, string body);
    }
}
