using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class InGameMenuController : MonoBehaviour {

	public GameObject PausePanel;
	public GameObject GameOverPanel;
	public GameObject HighestScorePanel;
    public GameObject SharePanel;
    public GameObject SharePicture;
    public GameObject LookAgainButton;
    public GameObject TrashPopup;
    public Camera MainCamera;
    public Camera SideCamera;
	public GameObject HighestScorePanelinGame;
	public Text HighestScoreonGameOver;
	public Text HighestScoreinGame;
	public Text HighestScoreinShot;
    public Text Gold;
	public Button SoundOnButton;
	public Button SoundOffButton;
	public bool IsLookAgainPressed = false;
	public Button Trash;
	GameObject[] Boxes;
	int HighestScore;
	int Score;
    string destination;
    string ShareDestination;
    int LastScore;

    //public Button ShotShareButton;

    // Use this for initialization
    void Start () {
		HighestScore = PlayerPrefs.GetInt ("HighestScore");
        

    }
	
	// Update is called once per frame
	void Update () {

        Gold.text = PlayerPrefs.GetInt("Gold").ToString();

        if (PlayerPrefs.GetInt ("Score") != 0) {
			Score = PlayerPrefs.GetInt ("Score");
		}
		HighestScoreonGameOver.text = PlayerPrefs.GetInt ("HighestScore").ToString ();
		HighestScoreinGame.text = PlayerPrefs.GetInt ("HighestScore").ToString ();
        if (LastScore != Score) {
            LastScore += 10;
        }
        HighestScoreinShot.text = LastScore.ToString();
		if (HighestScore < PlayerPrefs.GetInt ("Score")) {
			//HighestScorePanelinGame.gameObject.SetActive (true);
		}
		if (PlayerPrefs.GetInt ("GameOver") == 1) {
            Trash.interactable = false;
			if (IsLookAgainPressed) {
				GameOverPanel.gameObject.SetActive (false);
				HighestScorePanel.gameObject.SetActive (false);
			} else {
                if (!SharePanel.gameObject.activeSelf) {
                    GameOverPanel.gameObject.SetActive(true);
                    if (HighestScore < Score)
                    {
                        HighestScorePanel.gameObject.SetActive(true);
                    }
                }
			}
		}
		if (PlayerPrefs.GetInt("Sound") == 0){
			SoundOnButton.gameObject.SetActive (true);
			SoundOffButton.gameObject.SetActive (false);
			AudioListener.pause = true;
		} else {
			SoundOnButton.gameObject.SetActive (false);
			SoundOffButton.gameObject.SetActive (true);
			AudioListener.pause = false;
		}
	
	}
	public void OpenPausePanel(){
		PausePanel.gameObject.SetActive (true);
	}
	public void ClosePausePanel(){
		PausePanel.gameObject.SetActive (false);
	}
	public void ToMainMenu(){
		SceneManager.LoadScene ("main_menu");
	}
	public void Restart(){
		PlayerPrefs.SetInt ("Score", 0);
		PlayerPrefs.SetInt ("Played", 0);
		PlayerPrefs.SetInt ("GameOver", 0);
		SceneManager.LoadScene ("in-game");
        Trash.interactable = true;
    }
	public void LookAgainDown(){
		IsLookAgainPressed = true;
	}
	public void LookAgainUp(){
		IsLookAgainPressed = false;
	}
	public void Mute(){
		PlayerPrefs.SetInt ("Sound", 0);
	}
	public void UnMute(){
		PlayerPrefs.SetInt ("Sound", 1);
	}
	public void TrashButton(){
        if (PlayerPrefs.GetInt("Gold") > 500)
        {
            TrashPopup.gameObject.SetActive(true);
        }
        else {

        }
    }
    public void TrashOkeyButton() {
        if (PlayerPrefs.GetInt("Gold") > 500)
        {
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") - 500);
            Boxes = GameObject.FindGameObjectsWithTag("Boxes");
            for (int x = 0; x < Boxes.Length; x++)
            {
                Destroy(Boxes[x]);
            }
            TrashPopup.gameObject.SetActive(false);
        }
    }
    public void TrashNoButton() {
        TrashPopup.gameObject.SetActive(false);
    }
    public void SharePanelClose() {
        SharePanel.gameObject.SetActive(false);
        GameOverPanel.gameObject.SetActive(true);
        LookAgainButton.gameObject.SetActive(true);
    }
	public void TakeandShare(){
        //Application.CaptureScreenshot ("Shot.png");
        MainCamera.gameObject.SetActive(false);
        StartCoroutine(ScreenshotEncode ());
	}
	IEnumerator ScreenshotEncode() {
		int width = Screen.width;
		Texture2D texture1;
		byte[] bytes;
		yield return new WaitForEndOfFrame ();
		texture1 = new Texture2D (width, width, TextureFormat.RGB24, false);
		texture1.ReadPixels (new Rect (0 , 0, width, width), 0, 0);
		texture1.Apply ();
		yield return 0;
		bytes = texture1.EncodeToPNG ();
        Debug.Log(Application.persistentDataPath);
        destination = Path.Combine(Application.persistentDataPath, System.DateTime.Now.ToString("yyyy-MM-dd-HHmmss") + ".png");
        ShareDestination = Path.Combine(Application.persistentDataPath, System.DateTime.Now.ToString("yyyy-MM-dd-HHmmss"));
        File.WriteAllBytes (destination, bytes);
        MainCamera.gameObject.SetActive(true);
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(File.ReadAllBytes(destination));
        SharePicture.gameObject.GetComponent<RawImage>().texture = tex;
        SharePanel.gameObject.SetActive(true);
        GameOverPanel.gameObject.SetActive(false);
        LookAgainButton.gameObject.SetActive(false);
        
    }
    public void ShareImage() {

        //instantiate the class Intent
        AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");

        //instantiate the object Intent
        AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");

        //call setAction setting ACTION_SEND as parameter
        intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));

        //instantiate the class Uri
        AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");

        //instantiate the object Uri with the parse of the url's file
        AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", destination);

        //call putExtra with the uri object of the file
        intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);

        //set the type of file
        intentObject.Call<AndroidJavaObject>("setType", "image/jpeg");

        //instantiate the class UnityPlayer
        AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

        //instantiate the object currentActivity
        AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");

        //call the activity with our Intent
        currentActivity.Call("startActivity", intentObject);

    }
}
