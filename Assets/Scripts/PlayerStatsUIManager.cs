using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsUIManager : MonoBehaviour
{
    [SerializeField] private PlayerStatWidget statWidgetPrefab;
    private PlayerCharacterSheet player;

    private void Start()
    {
        player = FindObjectOfType<PlayerCharacterSheet>();
        //set widgets for health, armor, damage, all other stats
        for(int i = 0; i < player.stats.Length; i++)
        {
            Instantiate(statWidgetPrefab, gameObject.transform);
        }

        updateAllWidgets();
    }

    public void updateAllWidgets()
    {
        int i = 0;
        foreach(PlayerStatValue stat in player.stats)
        {
            transform.GetChild(i).GetComponent<PlayerStatWidget>().UpdateWidget(stat.name, stat.totalValue);
            i++;
        }
    }
}
