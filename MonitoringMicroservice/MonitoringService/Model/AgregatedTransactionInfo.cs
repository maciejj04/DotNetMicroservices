using System.Collections.Generic;

namespace MonitoringService{
    public enum Type{
        REQUEST,
        RESPONSE
    }
    public class AgregatedTransactionInfo
    {
        public Dictionary<Type, Transaction> transactions{get; set;}
        public AgregatedTransactionInfo()
        {
            transactions = new Dictionary<Type, Transaction>();
        }
        public void AddTransaction(Type type, Transaction transaction){
            this.transactions.Add(type, transaction);
        }
        
    }
}