using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBar : MonoBehaviour {

	public Image bar;
	public Text coinNum;
	public int totalCoinValue;
	public int coinValue = 10;
	public GameObject gameOverUI;
	public float powerLevel = 0.1f;
	public float ammountToAdd = 0.01f;

	public enum PowerUpType
	{
		PowerUp,
		PowerDown,
		CollectCoin
	}

	public PowerUpType powerUp;

	void OnTriggerEnter () {

		switch (powerUp)
		{
			case PowerUpType.PowerUp:
				StartCoroutine(PowerUpBar());
			break;

			case PowerUpType.PowerDown:
				StartCoroutine(PowerDownBar());
			break;

			case PowerUpType.CollectCoin:
				StartCoroutine(CollectCoin());
			break;
		}
	}

	IEnumerator CollectCoin () 
	{
		totalCoinValue = int.Parse(coinNum.text);
		int tempAmount = totalCoinValue + coinValue;
		while (totalCoinValue <= tempAmount)
		{
			coinNum.text = (totalCoinValue++).ToString();
			yield return new WaitForFixedUpdate();
		}
	}

	IEnumerator PowerUpBar () {
		float tempAmount = bar.fillAmount + powerLevel;
		if (tempAmount > 1)
		{
			tempAmount = 1;
		}

		while (bar.fillAmount < tempAmount)
		{
			bar.fillAmount += ammountToAdd;
			yield return new WaitForSeconds(ammountToAdd);
		}
	}

	IEnumerator PowerDownBar () {
		float tempAmount = bar.fillAmount - powerLevel;
		if (tempAmount <= 0)
		{
			tempAmount = 0;
		}
		
		while (bar.fillAmount > tempAmount)
		{
			bar.fillAmount -= ammountToAdd;
			yield return new WaitForSeconds(ammountToAdd);

			if(bar.fillAmount == 0) {
				yield return null;
			}

			if (bar.fillAmount == 0) {
				gameOverUI.SetActive(true);
				CharacterControl.gameOver = true;
			}
		}
	}

}
