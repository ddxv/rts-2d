using System;
using UnityEngine;
using System.Collections;
//using GooglePlayGames;
//using UnityEngine.SocialPlatforms;
//using GoogleMobileAds;
//using GoogleMobileAds.Api;
//

public class adsandscores : MonoBehaviour {
	
	public static int count = 0;
	private GameObject[] getCount;
	private int highscore;
	private int currentscore;
	private int totalscore;
//
//	private InterstitialAd interstitial;
//	
//	void Start() {
//		RequestInterstitial();
//		Debug.Log("XXXXXXXX+++++++++++=========AFTER REQUEST ============+++++XXXXXXX");
//		
//	}
//	
//	private void RequestInterstitial()
//	{
//		#if UNITY_EDITOR
//		string adUnitId = "unused";
//		#elif UNITY_ANDROID
//		string adUnitId = "ca-app-pub-8051090665088755/6935667515";
//		#elif UNITY_IPHONE
//		string adUnitId = "INSERT_IOS_INTERSTITIAL_AD_UNIT_ID_HERE";
//		#else
//		string adUnitId = "unexpected_platform";
//		#endif
//		
//		// Create an interstitial.
//		interstitial = new InterstitialAd("ca-app-pub-8051090665088755/6935667515");
//		// Register for ad events.
//		interstitial.AdLoaded += HandleInterstitialLoaded;
//		interstitial.AdFailedToLoad += HandleInterstitialFailedToLoad;
//		interstitial.AdOpened += HandleInterstitialOpened;
//		interstitial.AdClosing += HandleInterstitialClosing;
//		interstitial.AdClosed += HandleInterstitialClosed;
//		interstitial.AdLeftApplication += HandleInterstitialLeftApplication;
//		// Load an interstitial ad.
//		interstitial.LoadAd(createAdRequest());
//	}
//	
//	// Returns an ad request with custom ad targeting.
//	private AdRequest createAdRequest()
//	{
//		
//		Debug.Log("XXXXXXXX+++++++++++=========BEFORE INSTERSIATALA ADREQUEST.BUILDER============+++++XXXXXXX");
//		
//		return new AdRequest.Builder().Build();
//		
//		//HAD ALL THIS STUFF BEFORE, DIDN"T WORK
//		//Create an empty ad request
//		//		AdRequest request = new AdRequest.Builder().Build();
//		
//		// load the interstitial with the request
//		//		interstitial.LoadAd (request);
//		
//		Debug.Log("XXXXXXXX+++++++++++=========AFTER INSTERSIATALA ADREQUEST.BUILDER============+++++XXXXXXX");
//	}
//	
//	private void ShowInterstitial()
//	{
//		if (interstitial.IsLoaded())
//		{
//			interstitial.Show();
//		}
//		else
//		{
//			print("Interstitial is not ready yet.");
//		}
//	}
//	
//	
//	
//	
//	
//	
	void Update()
	{
				getCount = GameObject.FindGameObjectsWithTag ("Green Ship");
				count = getCount.Length;
				if (count == 0) {
			
						
			
//						//display interstitial if score is larger than 100000
//						if (currentscore > 40000) {
//								ShowInterstitial ();
//						}
			
//			//report scores to google plus
//			Social.ReportScore(currentscore, "CgkI3srawucUEAIQAw", (bool success) => {
//				Debug.Log(success ? "Reported high score successfully" : "Failed to report high score"); });
//			
//			highscore = PlayerPrefs.GetInt("High Score");
//			totalscore = PlayerPrefs.GetInt("Total Score");
//			totalscore = totalscore + currentscore;
//			
//			PlayerPrefs.SetInt ("Total Score", totalscore);
//			
//			//post score 12345 to leaderboard ID "Cfji293fjsie_QA")
//			Social.ReportScore(totalscore, "CgkI3srawucUEAIQAg", (bool success) => {
//				Debug.Log(success ? "Reported total score successfully" : "Failed to report total score");
//				// handle success or failure
//			});
//			
//			if (currentscore > highscore)
//			{
//				PlayerPrefs.SetInt ("High Score", currentscore);
//				PlayerPrefs.Save();
//			}
//			
						Application.LoadLevel ("menu");
						//BallController.score = 0;
			

				}
		
//	}
//	
//	#region Interstitial callback handlers
//	
//	public void HandleInterstitialLoaded(object sender, EventArgs args)
//	{
//		print("XXXXXXXXXXXXXXXXXXHandleInterstitialLoaded event received.");
//	}
//	
//	public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
//	{
//		print("XXXXXXXXXXXXXXXXXXHandleInterstitialFailedToLoad event received with message: " + args.Message);
//	}
//	
//	public void HandleInterstitialOpened(object sender, EventArgs args)
//	{
//		print("HandleInterstitialOpened event received");
//	}
//	
//	void HandleInterstitialClosing(object sender, EventArgs args)
//	{
//		print("XXXXXXXXXXXXXXXXXXHandleInterstitialClosing event received");
//	}
//	
//	public void HandleInterstitialClosed(object sender, EventArgs args)
//	{
//		print("XXXXXXXXXXXXXXXXXXHandleInterstitialClosed event received");
//	}
//	
//	public void HandleInterstitialLeftApplication(object sender, EventArgs args)
//	{
//		print("XXXXXXXXXXXXXXXXXXHandleInterstitialLeftApplication event received");
//	}
//	
//	#endregion
//	
//	
		}
}
//
