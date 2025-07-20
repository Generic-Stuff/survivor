using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public Text ammoText;
    private PlayerController player;
    void Start()
    {
        player = Object.FindFirstObjectByType<PlayerController>();
        UpdateAmmo();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAmmo();
    }
    void UpdateAmmo()
    {
        if (player != null && ammoText != null)
        {
            ammoText.text = "Ammo: " + player.ammo.ToString();
        }
    }
}
