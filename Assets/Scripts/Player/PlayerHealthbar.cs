using System;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerHealthbar : MonoBehaviour
    {
        private GameObject player;
        private Image healthbar;

        private void Start()
        {
            player = GameObject.FindObjectOfType<PlayerControl>().gameObject;
            healthbar = GetComponent<Image>();
        }

        private void Update()
        {
            if (player != null)
            {
                healthbar.fillAmount = player.GetComponent<PlayerControl>().health / player.GetComponent<PlayerControl>().maxHealth;
            }
        }
    }
}