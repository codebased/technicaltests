package com.example.bank;

import java.io.IOException;
import java.io.InputStream;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.HashMap;
import java.util.Locale;
import java.util.TreeMap;
import org.json.JSONArray;
import org.json.JSONObject;
import com.example.bank.model.ATM;
import com.example.bank.model.Account;
import com.example.bank.model.Location;
import com.example.bank.model.Transaction;
import android.app.Activity;
import android.util.Log;

/*
 * Defines customer account details.
 */
public class CustomerAccount {

	private HashMap<String, ATM> ATMLocations;
	private Account accountDetails;

	public CustomerAccount() {

	}

	public ATM getATMLocation(String atmkey) {
		return (ATM) this.ATMLocations.get(atmkey);
	}

	public TreeMap<Date, TransactionBucket> getBucket() {
		return TransactionBucket.map;
	}

	public Account getAccountDetails() {
		return this.accountDetails;
	}

	public void Initialize(Activity activity) {

		try {

			this.accountDetails = new Account();
			this.ATMLocations = new HashMap<String, ATM>();

			// load data from the json asset.
			JSONObject jObject = new JSONObject(
					this.loadJSONFromAsset(activity));

			// prepare json array.
			JSONArray transJSON = jObject.optJSONArray("transactions");
			JSONArray pTransJSON = jObject.optJSONArray("pending");
			JSONArray atmlocationJSON = jObject.optJSONArray("atms");
			JSONObject accountJSON = jObject.optJSONObject("account");

			// define date format to store.
			SimpleDateFormat dateFormat = new SimpleDateFormat("dd/MM/yyyy",
					Locale.getDefault());

			// loop through all transactions and set respective variables.
			for (int idx = 0; idx < transJSON.length(); idx++) {
				JSONObject o = transJSON.getJSONObject(idx);
				Transaction trans = new Transaction();

				trans.setEffectiveDate(dateFormat.parse(o
						.getString("effectiveDate")));
				trans.setDescription(o.getString("description"));
				trans.setAmount(o.getString("amount"));

				// if it has an atm details then set that value too.
				if (o.isNull("atmId")) {
					trans.setATMID(0);
				} else {
					trans.setATMID(o.getLong("atmId"));
				}

				trans.setPending(false);
				TransactionBucket.addTransaction(trans);
			}

			// loop through all pending transactions.
			for (int idx = 0; idx < pTransJSON.length(); idx++) {
				JSONObject o = pTransJSON.getJSONObject(idx);
				Transaction trans = new Transaction();
				trans.setEffectiveDate((Date) dateFormat.parse(o
						.getString("effectiveDate")));
				trans.setDescription(o.getString("description"));
				trans.setAmount(o.getString("amount"));

				if (o.isNull("atmId")) {
					trans.setATMID(0);
				} else {
					trans.setATMID(o.getLong("atmId"));
				}

				trans.setPending(true);
				TransactionBucket.addTransaction(trans);
			}

			// loop through all atm locations.
			for (int idx = 0; idx < atmlocationJSON.length(); idx++) {
				JSONObject o = atmlocationJSON.getJSONObject(idx);
				ATM atm = new ATM();
				atm.setID(o.getInt("id"));
				atm.setName(o.getString("name"));
				atm.setAddress(o.getString("address"));
				Location l = new Location();

				l.setLatitude(o.getJSONObject("location").getDouble("lat"));
				l.setLongitude(o.getJSONObject("location").getDouble("lng"));
				atm.setLocation(l);

				this.ATMLocations.put(String.valueOf(atm.getID()), atm);
			}

			// set account details.
			this.accountDetails.setName(accountJSON.getString("accountName"));
			this.accountDetails.setNumber(accountJSON
					.getString("accountNumber"));
			this.accountDetails
					.setAvailable(accountJSON.getDouble("available"));
			this.accountDetails.setBalance(accountJSON.getDouble("balance"));
		} catch (Exception ex) {
			Log.e("Bank App", ex.toString());
		}
	}

	/* function that fetch data from json file */
	public String loadJSONFromAsset(Activity activity) {
		String json = null;
		try {

			InputStream is = activity.getAssets().open("exercise.json");

			int size = is.available();

			byte[] buffer = new byte[size];

			is.read(buffer);

			is.close();

			json = new String(buffer, "UTF-8");

		} catch (IOException ex) {
			ex.printStackTrace();
			return null;
		}
		return json;
	}
}