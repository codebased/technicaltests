package com.example.bank.model;

import java.util.Date;

public class Transaction {
	
	private String amount;
	private String description;
	private Date effectiveDate;
	private boolean pending;
	private long atmID;
	
	public String getDescription(){
		return this.description;
	}
	
	public void setDescription(String description){
		this.description = description;
	}
	
	public String getAmount(){
		return this.amount;
	}
	
	public void setAmount(String amount){
		this.amount = amount;
	}
	
	public Date getEffectiveDate(){
		return this.effectiveDate;
	}
	
	public void setEffectiveDate(Date effectiveDate){
		this.effectiveDate = effectiveDate;
	}
	
	public boolean getPending(){
		return this.pending;
	}
	
	public void setPending(boolean pending){
		this.pending = pending;
	}
	
	public long getATMID(){
		return this.atmID;
	}
	
	public void setATMID(long atmID){
		this.atmID = atmID;
	}
} 