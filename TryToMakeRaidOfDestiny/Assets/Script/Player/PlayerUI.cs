using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{

    [SerializeField]TextMeshProUGUI promptText;
    [SerializeField] Image crossAir;
    void Start()
    {
        
    }
    
    public void UpdateText(string PromtMessage) 
    {
        promptText.text = PromtMessage;
    }

    public void UpdateCrossAir(Sprite interactCrossAir) 
    {
        crossAir.sprite = interactCrossAir;
    }
}
