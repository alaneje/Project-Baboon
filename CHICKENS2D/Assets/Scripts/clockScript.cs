using UnityEngine;
using System.Collections;

public class clockScript : MonoBehaviour {

	
	public double totalGameSeconds;
	
	public double seconds;
	public double minutes;
	public double hours;
	public double days;
	public double months;
	public double years;

	public static double whichHour;
	public static double whichDay;
	
	public static float secondsPerSecond;

	public static bool day;
	public static bool night;
	
	void Start () {
		totalGameSeconds = 21600;

		secondsPerSecond = 1;
		totalGameSeconds += secondsPerSecond * Time.fixedDeltaTime;

		night = false;
		day = true;
		
	}
	
	
	void Update () {

	 

	

		if (((int)hours%24 >=6 && (int)hours%24 <=18))
		{
			day = true;
			night = false;
		}
		else  if (((int)hours%24 <6)||((int)hours%24 > 18))
		{
			day = false;
			night = true;
		}

		
		
		if( Input.GetKeyDown(KeyCode.Alpha1)){
			secondsPerSecond = 1;
			
			
		}
		else if( Input.GetKeyDown(KeyCode.Alpha2)){
			secondsPerSecond = 60;

			
		}
		else if( Input.GetKeyDown(KeyCode.Alpha3)){
			secondsPerSecond = 3600;
			
			
		}
		//else if( Input.GetKeyDown(KeyCode.Alpha4)){
			//secondsPerSecond = 86400;
			
			
		//}
		//else if( Input.GetKeyDown(KeyCode.Alpha5)){
			//secondsPerSecond = 2629743;
			
			
		//}




		
		totalGameSeconds += secondsPerSecond * Time.deltaTime;
		
		seconds = totalGameSeconds;
		minutes = totalGameSeconds / 60;
		hours = minutes / 60;
		days = hours / 24;
		months = days / (365/12);
		years = months / 12;
		whichHour = (int)hours%24;
		whichDay = (int)days % 24;
		print (whichHour);
	}
	
	
	void OnGUI(){

		if (secondsPerSecond == 1)
		{
			GUI.Label(new Rect(0,225, 500, 500), "Multiplier: x1");
		}

		if (secondsPerSecond == 60)
		{
			GUI.Label(new Rect(0,225, 500, 500), "Multiplier: x2");
		}

		if (secondsPerSecond == 3600)
		{
			GUI.Label(new Rect(0,225, 500, 500), "Multiplier: x3");
		}

		GUI.Label(new Rect(0,275, 500, 500), "Minute: " + (int)minutes%60);
		GUI.Label(new Rect(0,300, 500, 500), "Hour: " + (int)hours%24);
		GUI.Label(new Rect(0,325, 500, 500), "Day: " + (int)days%(365/12));
		GUI.Label(new Rect(0,350, 500, 500), "Month: " + (int)months%12);
		GUI.Label(new Rect(0,375, 500, 500), "Year: " + (int)years);
		
	}
}
