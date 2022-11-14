using UnityEngine;
using TMPro;

public class SetOfBlocks : MonoBehaviour
{
    public TextMeshProUGUI chosenSetText;

    void Update()
    {
        int chosenSet = PlayerPrefs.GetInt("setofblocks") + 1;
        chosenSetText.text = "Chosen set: " + chosenSet;
    }
    
    public void setBlocksSet(int id)
    {
        PlayerPrefs.SetInt("setofblocks",id);
        PlayerPrefs.Save();
    }
}
