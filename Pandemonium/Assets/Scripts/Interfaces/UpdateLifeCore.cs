using UnityEngine;
using TMPro;

public class UpdateLifeCore : MonoBehaviour
{
    private TMP_Text lifeValue;
    private Core core;

    void Awake()
    {
        this.lifeValue = GetComponent<TMP_Text>();
        this.core = FindObjectOfType<Core>();
    }

    void Update()
    {        
        if(core == null) return;
        this.lifeValue.text = this.core.GetLife() + " %";
    }
}
