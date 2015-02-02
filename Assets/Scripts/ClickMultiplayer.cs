using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;


public class ClickMultiplayer : MonoBehaviour {



	
	PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
		// enables saving game progress.
		.EnableSavedGames()
			// registers a callback to handle game invitations received while the game is not running.
			.WithInvitationDelegate(<callback method>)
			// registers a callback for turn based match notifications received while the
			// game is not running.
			.WithMatchDelegate(<callback method>)
			.Build();
	
	PlayGamesPlatform.InitializeInstance(config);
	// recommended for debugging:
	PlayGamesPlatform.DebugLogEnabled = true;
	// Activate the Google Play Games platform
	PlayGamesPlatform.Activate();




	void OnMouseDown()
	{

		}

	private void startQuickGame() {
		// auto-match criteria to invite one random automatch opponent.
		// You can also specify more opponents (up to 3).
		Bundle am = RoomConfig.createAutoMatchCriteria(1, 1, 0);
		
		// build the room config:
		RoomConfig.Builder roomConfigBuilder = makeBasicRoomConfigBuilder();
		roomConfigBuilder.setAutoMatchCriteria(am);
		RoomConfig roomConfig = roomConfigBuilder.build();
		
		// create room:
		Games.RealTimeMultiplayer.create(mGoogleApiClient, roomConfig);
		
		// prevent screen from sleeping during handshake
		getWindow().addFlags(WindowManager.LayoutParams.FLAG_KEEP_SCREEN_ON);
		
		// go to game screen
	}
}