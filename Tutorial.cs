using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

    public GameObject TutorialPanel;
    public GameObject _1_0, _1_1, _1_2, _1_3; bool _1_b = true;
    public GameObject _2_0, _2_1, _2_2, _2_3; bool _2_b = true;
    public GameObject _3_0, _3_1, _3_2, _3_3; bool _3_b = true;
    public GameObject _4_0, _4_1, _4_2, _4_3; bool _4_b = true;
    int TCount;
    //string lng;

	// Use this for initialization
	void Start () {
        
        //lng = Application.systemLanguage.ToString();
        if (PlayerPrefs.GetInt("Tutorial") == 1)
        {
            TutorialPanel.gameObject.SetActive(true);
        }
        else {
            TutorialPanel.gameObject.SetActive(false);
        }
        TCount = 1;
	}

    // Update is called once per frame
	void Update () {

        if(Input.GetMouseButtonDown(0)){
            TCount++;
        }
        if (_1_b && TCount == 1) {
            StartCoroutine(_1_());
        }
        if (_2_b && TCount == 2)
        {
            StartCoroutine(_2_());
        }
        if (_3_b && TCount == 3)
        {
            StartCoroutine(_3_());
        }
        if (_4_b && TCount == 4)
        {
            StartCoroutine(_4_());
        }
        if (_4_b && TCount > 4)
        {
            TutorialPanel.gameObject.SetActive(false);
            PlayerPrefs.SetInt("Tutorial", 0);
        }

    }

    IEnumerator _1_()
    {
        _1_b = false;
        _1_0.gameObject.SetActive(true);
        _1_1.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        _1_2.gameObject.SetActive(true);
        _1_1.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.4f);
        _1_3.gameObject.SetActive(true);
        _1_2.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.4f);
        _1_b = true;
        /*if (lng == "tr") {
            _1_t_tr.gameObject.SetActive(true);
        }*/
    }
    IEnumerator _2_()
    {
        _2_b = false;
        _1_0.gameObject.SetActive(false);
        _2_0.gameObject.SetActive(true);
        _2_1.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        _2_2.gameObject.SetActive(true);
        _2_1.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.4f);
        _2_3.gameObject.SetActive(true);
        _2_2.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.4f);
        _2_b = true;
    }
    IEnumerator _3_()
    {
        _3_b = false;
        _2_0.gameObject.SetActive(false);
        _3_0.gameObject.SetActive(true);
        _3_1.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        _3_2.gameObject.SetActive(true);
        _3_1.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.4f);
        _3_3.gameObject.SetActive(true);
        _3_2.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.4f);
        _3_b = true;
    }
    IEnumerator _4_()
    {
        _4_b = false;
        _3_0.gameObject.SetActive(false);
        _4_0.gameObject.SetActive(true);
        _4_1.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        _4_2.gameObject.SetActive(true);
        _4_1.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.4f);
        _4_3.gameObject.SetActive(true);
        _4_2.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.4f);
        _4_b = true;
    }
}
