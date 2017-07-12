using UnityEngine.SceneManagement;
using UnityEngine;

public class mainMenu : MonoBehaviour
{
	public string levelToLoad = "ProjectOutland";
	public void Play ()
	{
		SceneManager.LoadScene (levelToLoad);
		Debug.Log ("You Are Pressing Play");
	}

	public void Quit () 
	{
		Debug.Log ("You Are Pressing Quit");
		Application.Quit ();
	}
}

