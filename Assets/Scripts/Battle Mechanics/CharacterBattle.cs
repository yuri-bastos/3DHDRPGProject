using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBattle : MonoBehaviour
{

    private SpriteRenderer characterBase;

    private void Awake() {
        characterBase = GetComponent<SpriteRenderer>();
    }

    public void Setup(bool isAlly)
    {
        if(isAlly)
        {
            characterBase.sprite = BattleHandler.GetInstance().playerSpritesheet.sprite;
        }
        else
        {
            characterBase.sprite = BattleHandler.GetInstance().enemySpritesheet.sprite;
        }
    }
}
