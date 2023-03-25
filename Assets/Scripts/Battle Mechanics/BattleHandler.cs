using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
    private static BattleHandler instance;
    [SerializeField] private Transform playerPosition;
    [SerializeField] public GameObject player;

    public SpriteRenderer playerSpritesheet;
    public SpriteRenderer enemySpritesheet;

    private Transform preBattlePlayerPosition;

    public static BattleHandler GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
    }

    public void StartBattle()
    {
        preBattlePlayerPosition = playerPosition;
        SpawnCharacter(true);
        SpawnCharacter(false);
        player.SetActive(false);
    }

    private void SpawnCharacter(bool isAlly) 
    {
        Vector3 position;
        if(isAlly)
        {
            position = new Vector3(+3, 0);
        }
        else
        {
            position = new Vector3(-3, 0);
        }
        Transform characterTransform = Instantiate(playerPosition, position, Quaternion.identity);
        CharacterBattle characterBattle = characterTransform.GetComponent<CharacterBattle>();
        characterBattle.Setup(isAlly);
    }

}
