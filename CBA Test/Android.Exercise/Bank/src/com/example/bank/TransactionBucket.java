package com.example.bank;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.TreeMap;
import com.example.bank.model.Transaction;

// store transaction data in date group through the hash/tree map. 
 class TransactionBucket {

	public ArrayList<Transaction> programs = new ArrayList<Transaction>();
	public Date transactionDate;
	public String transactionDay;
    public static TreeMap<Date, TransactionBucket> map; 

    public static void addTransaction(Transaction p) {
    	
    	if ( map == null ){
    		map = new TreeMap<Date, TransactionBucket>();
    	}
    	
    	Date key = p.getEffectiveDate();
    	 
        TransactionBucket correspondingBucket = map.get(key);
        if (correspondingBucket == null) {
            correspondingBucket = new TransactionBucket();
            correspondingBucket.transactionDate = p.getEffectiveDate();
            Calendar cal = Calendar.getInstance();
            int diffInDays = (int) ((cal.getTime().getTime() - p.getEffectiveDate().getTime())/ (1000 * 60 * 60 * 24));
            		
            correspondingBucket.transactionDay = String.format("%s days ago", diffInDays);
            
            
            map.put(key, correspondingBucket);
        }
        correspondingBucket.programs.add(p);
    }
}