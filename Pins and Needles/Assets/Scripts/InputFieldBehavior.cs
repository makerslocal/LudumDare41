using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
		if (this.GetComponent<InputField>().isFocused && this.GetComponent<InputField>().text != "" && Input.GetKey(KeyCode.Return))
        {
			float score = GameObject.Find ("Scripts").GetComponent<GameController> ().Score;
			Debug.Log (score);
			WWW www = new WWW ("http://projects.makerslocal.org/LudumDare41/board/enter.php?name=" + this.GetComponent<InputField> ().text + "&score=" + score.ToString());
			this.GetComponent<InputField> ().text = "";
			this.gameObject.SetActive (false);
        }
    }
}
