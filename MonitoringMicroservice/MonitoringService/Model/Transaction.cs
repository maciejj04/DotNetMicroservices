using System;

namespace MonitoringService{
    public class Transaction
    {
        public DateTime dateTime;
        public string targetPath;
        public Type type;
        public Transaction(DateTime dateTime, string targetPath, Type type)
        {
            this.dateTime = dateTime;
            this.targetPath = targetPath;
            this.type = type;
        }
    }
}