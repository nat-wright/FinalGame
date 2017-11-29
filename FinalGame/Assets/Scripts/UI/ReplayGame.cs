using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReplayGame : MonoBehaviour {

	public Transform player;
	public Image uiBar;
	public GameObject GameOverUI;
	public static Vector3 startPosition;
	private float fillAmount;

	void Awake ()
	{
		startPosition = player.position;
		fillAmount = uiBar.fillAmount;
		GameOverUI.SetActive(false);
	}
	
	public void Click () 
	{
		CharacterControl.gameOver = false;
		player.position = startPosition;
		uiBar.fillAmount = fillAmount;
		GameOverUI.SetActive(false);
		gameObject.SetActive(false);
	}
}