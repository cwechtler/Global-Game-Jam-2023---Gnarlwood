using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDirector : MonoBehaviour
{
	public void CallLoadLevel(string name)
	{
		LevelManager.instance.LoadLevel(name);
	}

	public void StartGame()
	{
		GameController.instance.resetGame();	
		LevelManager.instance.LoadLevel(LevelManager.Level1String, true);
	}

	public void MainMenu()
	{
		LevelManager.instance.LoadLevel(LevelManager.MainMenuString);
	}

	public void OptionsMenu()
	{
		LevelManager.instance.LoadLevel(LevelManager.OptionsString);
	}

	public void Quit()
	{
		LevelManager.instance.QuitRequest();
	}
}
