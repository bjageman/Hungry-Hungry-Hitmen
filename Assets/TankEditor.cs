using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankEditor : MonoBehaviour {

	[SerializeField] int tankIndex;
	[SerializeField] Text tankName;
	[SerializeField] Image tankImage;
	[SerializeField] Sprite[] tankSprites;
	
	TankController tank;
	int currentTankSpriteIndex = 1;

	public void SetNewTank(TankController newTank){
		tankImage.sprite = newTank.GetComponent<SpriteRenderer>().sprite;
		tankName.text = "Player " + newTank.PlayerNumber;
		currentTankSpriteIndex = newTank.PlayerNumber - 1;
		NextTankColor();
	}

	public void NextTankColor(){
		tank = GetTankByIndex(tankIndex);
		Sprite nextSprite = tankSprites[currentTankSpriteIndex % tankSprites.Length];
		tank.GetComponent<SpriteRenderer>().sprite = nextSprite;
		tankImage.sprite = nextSprite;
		currentTankSpriteIndex++;
	}

	public void SetName(string name){
		tankName.text = name;
	}

	private TankController GetTankByIndex(int playerIndex)
    {
        TankController[] players = Resources.FindObjectsOfTypeAll<TankController>();
        foreach (TankController player in players)
        {
            if (player.PlayerNumber == playerIndex)
            {
                return player;
            }
        }
		return null;
    }
}
