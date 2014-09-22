package com.example.bank.model;

public class ATM {
	
	private int id;
	private String name;
	private String address;
	private Location location;
	
	
	public int getID()
	{
		return this.id;
	}
	
	public void setID(int id){
		this.id = id;
	}
	
	public String getName(){
		return this.name;
	}
	
	public String getAddress() { 
		return this.address;
	}
	
	public Location getLocation(){
		return this.location;
	}
	
	public void setName(String name){
		this.name = name;
	}
	
	public void setAddress(String address){
		this.address = address;
	}
	
	public void setLocation(Location location ){
		this.location = location;
	}
}
