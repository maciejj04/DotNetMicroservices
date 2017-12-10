using System.Collections.Generic;

namespace MonitoringService{
    public class DBService{
        public Dictionary<string, AgregatedTransactionInfo> transactions{get;private set;}

        public DBService()
        {
            this.transactions = new Dictionary<string, AgregatedTransactionInfo>(){

            };
        }

        public void AddTransaction(string id, Transaction transaction){

            if ( ! this.transactions.ContainsKey(id) ) {
                this.transactions.Add(id, new AgregatedTransactionInfo());
            }
            this.transactions.GetValueOrDefault(id).AddTransaction(transaction.type, transaction);
        }
        public AgregatedTransactionInfo getAgregatedTransactionInfo(int id){
            return transactions.GetValueOrDefault(id.ToString());
        } 
    }
}