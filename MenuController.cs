using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    public Text HighestScore;
    public Text TotalScore;
    public Text Gold;
    public Button SoundOnButton;
    public Button SoundOffButton;
    public GameObject RewardedPanel;
    int Skin;
    //public Button ChangeSkin;
    public GameObject MarketPanel;

    // Use this for initialization
    void Start() {

        if (PlayerPrefs.GetInt("PlayedBefore") == 0) {
            PlayerPrefs.SetInt("Sound", 1);
            PlayerPrefs.SetInt("Trash", 3);
            PlayerPrefs.SetInt("Skin", 1);
            PlayerPrefs.SetInt("Tutorial", 1);
            Skin = 1;
        }
        if (PlayerPrefs.GetInt("Trash") == 3) {
            PlayerPrefs.SetInt("Gold", 1000);
            PlayerPrefs.SetInt("Trash", 0);
        }
        PlayerPrefs.SetInt("PlayedBefore", 1);
        PlayerPrefs.SetInt("GameOver", 0);
        //ChangeSkinFunc (PlayerPrefs.GetInt ("Skin"));
    }

    // Update is called once per frame
    void Update() {

        HighestScore.text = PlayerPrefs.GetInt("HighestScore").ToString();
        TotalScore.text = PlayerPrefs.GetInt("TotalScore").ToString();
        Gold.text = PlayerPrefs.GetInt("Gold").ToString();

        if (PlayerPrefs.GetInt("Sound") == 0) {
            SoundOnButton.gameObject.SetActive(true);
            SoundOffButton.gameObject.SetActive(false);
            AudioListener.pause = true;
        } else {
            SoundOnButton.gameObject.SetActive(false);
            SoundOffButton.gameObject.SetActive(true);
            AudioListener.pause = false;
        }
    }
    public void Play() {
        SceneManager.LoadScene("in-game");
    }
    public void Mute() {
        PlayerPrefs.SetInt("Sound", 0);
    }
    public void UnMute() {
        PlayerPrefs.SetInt("Sound", 1);
    }
    void ChangeSkinFunc(int Skin) {

        if (Skin == 1) { //Beyaz
            GameObject.Find("Main Camera").gameObject.GetComponent<Camera>().backgroundColor = new Color32(0xC1, 0xC1, 0xC3, 0x00);
        }
        if (Skin == 2) { //Siyah
            GameObject.Find("Main Camera").gameObject.GetComponent<Camera>().backgroundColor = new Color32(0x1C, 0x1C, 0x1C, 0x00);
        }
    }
    public void ChangeSkinButton() {
        if (Skin == 1) {
            ChangeSkinFunc(2);
        }
        if (Skin == 2) {
            ChangeSkinFunc(1);
        }
    }
    public void OpenMarket() {
        MarketPanel.gameObject.SetActive(true);
    }
    public void CloseMarket() {
        MarketPanel.gameObject.SetActive(false);
    }
}

