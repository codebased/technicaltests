package com.example.bank.model;

public class Location {
	
	private double lat;
	private double lng;
	
	public double getLatitude(){
		return this.lat;
	}
	
	public double getLongitude(){
		return this.lng;
	}
	
	public void setLatitude(double lat){
		this.lat = lat;
	}
	
	public void setLongitude(double lng){
		this.lng = lng;
	}
}
