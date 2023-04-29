using UnityEngine;
using Unity.Netcode;
using TMPro;

public class Core : NetworkBehaviour
{
    [SerializeField] private TMP_Text text;

    private NetworkVariable<int> health = new NetworkVariable<int>(100);

    public override void OnNetworkSpawn()
    {
        health.OnValueChanged += (int oldValue, int newValue) => { UpdateText(); };
    }

    private void Start() 
    {
        UpdateText();
    }

    public void TakeDamage(int damage)
    {
        if (!IsServer && !GameManager.Instance.IsSolo()) return;

        health.Value -= damage;
        UpdateText();

        if(health.Value <= 0)
        {
            GameManager.Instance.Defeat();
        }
    }

    void UpdateText()
    {
        text.text = health.Value.ToString();
    }
}
