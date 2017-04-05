using log4net;
using log4net.Config;
using System;

namespace ISCAE.Data
{
    public class Log4NetHelper
    {
        private static ILog _logger;

        public static ILog GetLogger(Type type)
        {
            if (_logger != null)
                return _logger;
            XmlConfigurator.Configure();
            _logger = LogManager.GetLogger(type);
            return _logger;
        }
    }
}
