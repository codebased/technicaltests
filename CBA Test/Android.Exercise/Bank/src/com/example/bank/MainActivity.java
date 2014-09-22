package com.example.bank;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.Date;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.SortedSet;
import java.util.TreeSet;

import com.example.bank.model.ATM;
import com.example.bank.model.Transaction;

import android.net.Uri;
import android.os.Bundle;
import android.app.Activity;
import android.content.Intent;
import android.graphics.Typeface;
import android.text.Html;
import android.view.Gravity;
import android.view.Menu;
import android.view.View;
import android.widget.TableLayout;
import android.widget.TableRow;
import android.widget.TextView;

public class MainActivity extends Activity {

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		TransactionBucket.map = null;
		getActionBar().setTitle(R.string.account_details);
		this.setContentView(R.layout.activity_main);
		this.showTransactions();
	}

	public void showTransactions() {

		// get hte table layout that will store all rows.
		TableLayout tl = (TableLayout) findViewById(R.id.transTable);

		CustomerAccount customerAccount = new CustomerAccount();
		customerAccount.Initialize(this);

		TextView tv = (TextView) findViewById(R.id.accountNameTV);
		tv.setText(customerAccount.getAccountDetails().getName());

		tv = (TextView) findViewById(R.id.accountNumberTV);
		tv.setText(customerAccount.getAccountDetails().getNumber());

		tv = (TextView) findViewById(R.id.availableBalanceTV);
		tv.setText(String.format("$%.2f", customerAccount.getAccountDetails().getBalance()));

		tv = (TextView) findViewById(R.id.availableFundsTV);
		tv.setText(String.format("$%.2f", customerAccount.getAccountDetails().getAvailable()));

		// get all keys and sort them in descending order.
		List<Date> keys = new ArrayList<Date>();
		keys.addAll(customerAccount.getBucket().keySet());

		Collections.sort(keys, new Comparator<Date>() {

			public int compare(Date d1, Date d2) {
				return d2.compareTo(d1);
			}
		});

		// loop through each key of the bucket value and then loop it further
		// for the transaction of that date/ bucket key.
		for (Date key : keys) {

			TransactionBucket b = customerAccount.getBucket().get(key);
			ArrayList<Transaction> transactions = b.programs;

			tl.addView(this.getHeader(b.transactionDate, b.transactionDay));

			for (int index = 0; index < transactions.size(); index++) {

				Transaction transactionData = transactions.get(index);

				final TableRow tr = this.getTransactionRow(
						transactionData.getPending() ? "PENDING" : "",
						transactionData.getDescription(),
						transactionData.getAmount());

				if (transactionData.getATMID() > 0) {

					final ATM atm = customerAccount.getATMLocation(String
							.valueOf(transactionData.getATMID()));

					if (atm != null) {
						// add the click even against ATM.
						tr.setClickable(true);
						tr.setId(atm.getID());
						tr.setOnClickListener(new View.OnClickListener() {

							@Override
							public void onClick(View v) {
								showMap(atm.getLocation().getLatitude(), atm
										.getLocation().getLongitude());
							}
						});
					}
				}

				tl.addView(tr);

			}
		}

		// tl.addView(tr, new
		// TableLayout.LayoutParams(TableLayout.LayoutParams.MATCH_PARENT,
		// TableLayout.LayoutParams.MATCH_PARENT));

	}

	public TableRow getHeader(Date transDate, String transactionDay) {

		/* Create a new row to be added. */
		final TableRow tr = new TableRow(this);
		tr.setLayoutParams(new TableRow.LayoutParams(
				TableRow.LayoutParams.MATCH_PARENT,
				TableRow.LayoutParams.MATCH_PARENT));
		tr.setMinimumHeight(30);

		tr.setBackgroundColor(getResources().getColor(
				R.color.transactionHeaderBackground));
		tr.invalidate();

		tr.setPadding(2, 2, 2, 2);

		TextView transDateTV = new TextView(this);
		transDateTV.setLayoutParams(new TableRow.LayoutParams(
				TableRow.LayoutParams.MATCH_PARENT,
				TableRow.LayoutParams.MATCH_PARENT));
		transDateTV.setGravity(Gravity.CENTER | Gravity.LEFT);
		SimpleDateFormat format = new SimpleDateFormat("dd MMM yyyy");
		transDateTV.setText(format.format(transDate));
		transDateTV.setTypeface(Typeface.DEFAULT_BOLD);

		tr.addView(transDateTV);

		TextView emptyTV = new TextView(this);
		emptyTV.setLayoutParams(new TableRow.LayoutParams(
				TableRow.LayoutParams.MATCH_PARENT,
				TableRow.LayoutParams.MATCH_PARENT));
		emptyTV.setText("");

		tr.addView(emptyTV);

		TextView transDayTV = new TextView(this);
		transDayTV.setLayoutParams(new TableRow.LayoutParams(
				TableRow.LayoutParams.MATCH_PARENT,
				TableRow.LayoutParams.MATCH_PARENT));
		transDayTV.setGravity(Gravity.CENTER | Gravity.RIGHT);
		transDayTV.setText(transactionDay);
		transDayTV.setTypeface(Typeface.DEFAULT_BOLD);

		tr.addView(transDayTV);

		return tr;

	}

	public TableRow getTransactionRow(String status, String description,
			String amount) {

		final TableRow tr = new TableRow(this);
		TableRow.LayoutParams params = new TableRow.LayoutParams(
				TableRow.LayoutParams.MATCH_PARENT,
				TableRow.LayoutParams.MATCH_PARENT);
		params.setMargins(0, 2, 0, 0);
		tr.setLayoutParams(params);

		tr.setMinimumHeight(50);
		tr.setBackgroundColor(getResources().getColor(
				R.color.transactionRowBackground));
		tr.invalidate();
		tr.setPadding(2, 2, 2, 2);

		TextView transactionStatusTV = new TextView(this);
		transactionStatusTV.setLayoutParams(new TableRow.LayoutParams(
				TableRow.LayoutParams.MATCH_PARENT,
				TableRow.LayoutParams.MATCH_PARENT));
		transactionStatusTV.setGravity(Gravity.CENTER | Gravity.LEFT);
		transactionStatusTV.setText("");
		transactionStatusTV.setTypeface(Typeface.DEFAULT_BOLD);

		tr.addView(transactionStatusTV);

		TextView transactionDescriptionTV = new TextView(this);
		transactionDescriptionTV.setLayoutParams(new TableRow.LayoutParams(
				TableRow.LayoutParams.MATCH_PARENT,
				TableRow.LayoutParams.MATCH_PARENT));
		transactionDescriptionTV.setGravity(Gravity.CENTER | Gravity.LEFT);
		transactionDescriptionTV.setText(String.format("%s %s",
				Html.fromHtml("<b>" + status + "</b>"),
				Html.fromHtml(description)));

		tr.addView(transactionDescriptionTV);

		TextView transactionAmountTV = new TextView(this);
		transactionAmountTV.setLayoutParams(new TableRow.LayoutParams(
				TableRow.LayoutParams.MATCH_PARENT,
				TableRow.LayoutParams.MATCH_PARENT));
		transactionAmountTV.setGravity(Gravity.CENTER | Gravity.RIGHT);
		transactionAmountTV.setText(amount);

		tr.addView(transactionAmountTV);

		return tr;
	}

	public void showMap(double lat, double lng) {
		Intent intent = new Intent(Intent.ACTION_VIEW);

		intent.setData(Uri.parse("geo:0,0?q="
				+ String.format("%f,%f", lat, lng)));
		try {
			startActivity(intent);
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
