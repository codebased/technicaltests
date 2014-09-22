package com.example.bank.model;

public class Account {
	private String name;
	private String number;
	private double available;
	private double balance;
	
	public String getName(){
		return this.name;
	}
	
	public void setName(String name) { 
		this.name = name;
	}
	
	public String getNumber(){
		return this.number;
	}
	
	public void setNumber(String number){
		this.number = number;
	}
	
	public double getAvailable() { 
		return this.available;
	}
	
	public void setAvailable(double available){
		this.available = available;
	}
	
	public double getBalance(){
		return this.balance;
	}
	
	public void setBalance(double balance){
		this.balance = balance;
	}
}
