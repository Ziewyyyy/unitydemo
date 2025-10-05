    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using TMPro;
    using UnityEngine.UI;
    using JetBrains.Annotations;
    using Unity.VisualScripting;

    public class Player : MonoBehaviour
    {
        public Sprite[] SpriteToChoose;
        public Image playerAction;

        public Button reload;
        public Button shoot;
        public Button shield;
        public Button bomb_shield;
        public Button bomb;
        public Button laser;

        public int bullet = 0;

        public int isShield = 0;

        public int isBShield = 0;

        public int pHealth = 3;

        public int Player_Choice = -1;

        public int isLasered = 0;

    public int player_damage = 0;

        public TextMeshProUGUI PlayerChoiceText;
        public TextMeshProUGUI NumberBulletText;
        public GameManager gameManager;

        public Ai ai;
        public void Start()
        {
            shoot.gameObject.SetActive(false);
            bomb.gameObject.SetActive(false);
            laser.gameObject.SetActive(false);
            playerAction.gameObject.SetActive(false);
        }

        public void UpdateButtons()
        {
            if(bullet >= 1)
            {
                shoot.gameObject.SetActive(true);
                shoot.interactable = true;
            }
            if(bullet >= 3)
            {
                bomb.gameObject.SetActive(true);
                bomb.interactable = true;
            }
            if(bullet >= 5)
            {
                laser.gameObject.SetActive(true);
                laser.interactable = true;
            }
            NumberBulletText.text = "Bullet: " + bullet;
        }


    
    public void Choose_Reload()
        {
            ai.playerBulletLastTurn = bullet;
            Player_Choice = 0;
            PlayerChoiceText.text = "Choose Reload";
            playerAction.gameObject.SetActive(true);
            playerAction.sprite = SpriteToChoose[Player_Choice]; 
            bullet += 1;
            UpdateButtons();
            gameManager.OnPlayerChoose();
        }

        public void Choose_Shoot()
        {
            ai.playerBulletLastTurn = bullet;
            Player_Choice = 1;
            PlayerChoiceText.text = "Choose Shoot";
            playerAction.gameObject.SetActive(true);
            playerAction.sprite = SpriteToChoose[Player_Choice];
            bullet -= 1;
            player_damage = 1;
            UpdateButtons();
            gameManager.OnPlayerChoose();
        }

        public void Choose_Shield()
        {
            ai.playerBulletLastTurn = bullet;
            Player_Choice = 2;
            isShield = 1;
            PlayerChoiceText.text = "Choose Shield";
            playerAction.gameObject.SetActive(true);
            playerAction.sprite = SpriteToChoose[Player_Choice];
            gameManager.OnPlayerChoose();
        }

        public void Choose_Shield_Bomb()
        {
            ai.playerBulletLastTurn = bullet;
            Player_Choice = 4;
            isBShield = 1;
            PlayerChoiceText.text = "Choose Shield Bomb";
            playerAction.sprite = SpriteToChoose[Player_Choice];
            gameManager.OnPlayerChoose();
        }

        public void Choose_Bomb()
        {
            ai.playerBulletLastTurn = bullet;
            Player_Choice = 3;
            PlayerChoiceText.text = "Choose Bomb";
            bullet -= 3;
            playerAction.sprite = SpriteToChoose[Player_Choice];
            gameManager.OnPlayerChoose();
            player_damage = 2;
            UpdateButtons();
            gameManager.OnPlayerChoose();
        }

        public void Choose_Laser()
        {
            ai.playerBulletLastTurn = bullet;
            Player_Choice = 5;
            PlayerChoiceText.text = "Choose Laser";
            playerAction.sprite = SpriteToChoose[Player_Choice];
            bullet -= 5;
            ai.islasered -= 1;
            UpdateButtons();
            gameManager.OnPlayerChoose();
        }


    }


