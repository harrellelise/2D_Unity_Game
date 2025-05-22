using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharSelect : MonoBehaviour
{
    public CharacterDatabase characterDB;

    private int selectedOption = 0;

    
    private void SelectChar(int selectedOption){
        this.selectedOption = selectedOption;
        Character character = characterDB.GetCharacter(selectedOption);
        Saving();
    }
   

    // Start is called before the first frame update
    void Start()
    {   
        if(!PlayerPrefs.HasKey("selectedOption")){
            selectedOption = 0;
        }else{
            Load();
        }
        
    }

    private void Load()
    {
        selectedOption=PlayerPrefs.GetInt("selectedOption");
    }
    
    private void Saving()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
        PlayerPrefs.Save();
    }

    public void Blobby0()
    {
        SelectChar(0);
    }

    public void Pinky1()
    {
        SelectChar(1);
    }

    public void Grape2()
    {
        SelectChar(2);
    }

    public void Bear3()
    {
        SelectChar(3);
    }

    public void Sushi4()
    {
        SelectChar(4);
    }

    public void Jelly5()
    {
        SelectChar(5);
    }

    public void Jam6()
    {
        SelectChar(6);
    }
}
