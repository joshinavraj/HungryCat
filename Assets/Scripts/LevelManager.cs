using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	// for changing scene
	public void LoadScene(string name){
		SceneManager.LoadScene(name);
	}
	// for Quit the  game
	public void QuitGame(){
		Application.Quit ();
	}
}
