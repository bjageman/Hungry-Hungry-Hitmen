using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour {

	[SerializeField] GameObject tankPrefab;
	[SerializeField] int tankIndex;

	public void AddPlayer(){
		TankController newTank = CreateNewTank();
		newTank.gameObject.AddComponent<PlayerController>();
	}

	public void AddBot()
    {
        TankController newTank = CreateNewTank();
        newTank.gameObject.AddComponent<AIController>();
    }

    private TankController CreateNewTank()
    {
        TankController newTank = Instantiate(tankPrefab).GetComponent<TankController>();
        newTank.PlayerNumber = tankIndex;
        MoveUIToPosition(newTank.GetComponent<TankUI>());
        newTank.gameObject.SetActive(false);
		GetComponent<TankEditor>().SetNewTank(newTank);
        return newTank;
    }

    //TODO Add UI position for 3 and 4 (and 1?)
    private void MoveUIToPosition(TankUI tankUI)
    {
        RectTransform canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
		RectTransform panel = tankUI.Panel;
		if ( tankIndex == 2){
			panel.anchorMin = new Vector2(1, 1);
			panel.anchorMax = new Vector2(1, 1);
			panel.anchoredPosition = new Vector3(-75, -70, 0);
		}

    }

    public void RemovePlayer()
    {
        TankController tank = GetTank();
		Destroy(tank.gameObject, .1f);

    }

    private TankController GetTank()
    {
        TankController[] players = Resources.FindObjectsOfTypeAll<TankController>();
        foreach (TankController player in players)
        {
            if (player.PlayerNumber == tankIndex)
            {
                return player;
            }
        }
		return null;
    }
}
