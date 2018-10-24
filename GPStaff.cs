using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;


public class GPStaff : MonoBehaviour {

	bool Connected = false;

	// Use this for initialization
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);

		if (!Connected) {
			PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
				// registers a callback to handle game invitations received while the game is not running.
				//.WithInvitationDelegate(<callback method>)
				// registers a callback for turn based match notifications received while the
				// game is not running.
				//.WithMatchDelegate(<callback method>)
				// require access to a player's Google+ social graph (usually not needed)
				.RequireGooglePlus()
				.Build();

			PlayGamesPlatform.InitializeInstance(config);
			// recommended for debugging:
			PlayGamesPlatform.DebugLogEnabled = true;
			// Activate the Google Play Games platform
			PlayGamesPlatform.Activate();

			Social.localUser.Authenticate ((bool success) => {
				if (success){
					Connected = true;
				}
			});
		}

	}
    void Start() {

        if (PlayGamesPlatform.Instance.IsAuthenticated()) {
            PlayGamesPlatform.Instance.LoadScores(
            "CgkIs9Hx6tETEAIQAA",
            LeaderboardStart.PlayerCentered,
            1,
            LeaderboardCollection.Public,
            LeaderboardTimeSpan.AllTime,
            (LeaderboardScoreData data) => {
                if (int.Parse(data.PlayerScore.formattedValue) > PlayerPrefs.GetInt("HighestScore"))
                {
                    PlayerPrefs.SetInt("HighestScore", int.Parse(data.PlayerScore.formattedValue));
                }
            });
            PlayGamesPlatform.Instance.LoadScores(
                "CgkIs9Hx6tETEAIQDw",
                LeaderboardStart.PlayerCentered,
                1,
                LeaderboardCollection.Public,
                LeaderboardTimeSpan.AllTime,
                (LeaderboardScoreData data) => {
                    if (int.Parse(data.PlayerScore.formattedValue) > PlayerPrefs.GetInt("TotalScore"))
                    {
                        PlayerPrefs.SetInt("TotalScore", int.Parse(data.PlayerScore.formattedValue));
                    }
                });
        }
    }
	public void ShowLeaderBoard(){
		Social.ShowLeaderboardUI();
	}
	public void ShowAchievements(){
		Social.ShowAchievementsUI();
	}
}
