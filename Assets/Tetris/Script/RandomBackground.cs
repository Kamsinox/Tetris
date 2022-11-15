using UnityEngine;
using UnityEngine.UI;

public class RandomBackground : MonoBehaviour
{
    public Sprite[] backgrounds;
    public Canvas canvas;

    public void chooseBackground()
    {
        Sprite newSprite = backgrounds[randomNumber()];
        canvas.GetComponent<Image>().sprite = newSprite;
        Debug.Log("image: "+ canvas.GetComponent<Image>().sprite.name);
    }

    private int randomNumber()
    {
        int chosenId = Random.Range(0,backgrounds.Length);
        Debug.Log("Wybrany sprite: "+ chosenId);
        return chosenId;
    }
}
