using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChar : MonoBehaviour
{
    public CharacterDatabase characterDB;

    private int selectedOption = 0;
    // Start is called before the first frame update
    void Start()
    {   
        if(!PlayerPrefs.HasKey("selectedOption")){
            selectedOption = 0;
        }else{
            Load();
        }
        UpdateCharacter(selectedOption);
        
    }
    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = character.characterSprite;
    }

    private void Load()
        {
            selectedOption=PlayerPrefs.GetInt("selectedOption");
        }
}
