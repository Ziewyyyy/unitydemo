using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Ai ai;
    public TextMeshProUGUI Win;

    public Button playButton;
    public GameObject retryButton;

    public GameObject statusPanel;
    public TextMeshProUGUI playerStatsText;
    public TextMeshProUGUI aiStatsText;
    public GameObject gameRoot;

    private bool isPlayerTurn = true;
    private bool playerHasChosen = false;
    void Start()
    {
        EnablePlayerButtons();
        playButton.interactable = false;
        retryButton.SetActive(false);
    }

    private bool statusOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            statusOpen = !statusOpen; 

            if (statusOpen)
            {
                UpdateStatusPanel();
                statusPanel.SetActive(true);
                gameRoot.SetActive(false);
            }
            else
            {
                statusPanel.SetActive(false);
                gameRoot.SetActive(true);
            }

            Debug.Log("Status Open: " + statusOpen);
        }
    }

    void UpdateStatusPanel()
    {
        playerStatsText.text = "Player Status: \nPlayer Health: " + player.pHealth + "\nBullets: " + player.bullet;
        aiStatsText.text = "AI Status: \nAI Health: " + ai.aHealth + "\nBullets: " + ai.bullet; 
    }
    public void check_player_damage()
    {
        if(player.player_damage == 1)
        {
            if(ai.isShield == 1)
            {
                player.player_damage = 0;
            }
            else
            {
                player.player_damage = 1;
            }
        }
        else if (player.player_damage == 2)
        {
            if(ai.isBShield == 1)
            {
                player.player_damage = 0;
            }
            else
            {
                player.player_damage = 2;
            }
        }
        else
        {
            player.player_damage = 0;
        }
    }

    public void check_ai_damage()
    {
        if (ai.ai_damage == 1)
        {
            if (player.isShield == 1)
            {
                ai.ai_damage = 0;
            }
            else
            {
                ai.ai_damage = 1;
            }
        }
        else if (ai.ai_damage == 2)
        {
            if (player.isBShield == 1)
            {
                ai.ai_damage = 0;
            }
            else
            {
                ai.ai_damage = 2;
            }
        }
        else
        {
            ai.ai_damage = 0;
        }
    }

    public void check_player_health()
    {
        player.pHealth -= ai.ai_damage;
    }

    public void check_ai_health()
    {
        ai.aHealth -= player.player_damage;
    }

    public void OnPlayerChoose()
    {
        if (!isPlayerTurn) return;

        DisablePlayerButtons();
        playButton.interactable = true;
        playerHasChosen = true;

    }

    public void OnPlayButtonPressed()
    {
        if (!playerHasChosen) return;

        playButton.interactable = false;
        isPlayerTurn = false;
        StartCoroutine(AiTurn());
    }   

    IEnumerator AiTurn()
    {
        yield return new WaitForSeconds(1f);
        ai.PlayButton();
        check_player_damage();
        check_ai_damage();
        check_player_health();
        check_ai_health();
        yield return new WaitForSeconds(1f);
        CheckWinCondition();
        isPlayerTurn = true;
        playerHasChosen = false;
        EnablePlayerButtons();
    }

    void CheckWinCondition()
    {
        if (player.pHealth <= 0 && ai.aHealth <= 0)
        {
            Win.text = "Draw";
            DisablePlayerButtons();
            playButton.interactable = false;
            retryButton.SetActive(true);
        }
        else if (player.pHealth > 0 && ai.aHealth <= 0)
        {
            Win.text = "You Win";
            DisablePlayerButtons();
            playButton.interactable = false;
            retryButton.SetActive(true);
        }
        else if(player.pHealth <= 0 && ai.aHealth > 0)
        {
            Win.text = "You Lose";
            DisablePlayerButtons();
            playButton.interactable = false;
            retryButton.SetActive(true);
        }
        ai.isShield = 0;
        ai.isBShield = 0;
        ai.islasered = 0;
        player.isBShield = 0;
        player.isShield = 0;
        player.isLasered = 0;
        player.player_damage = 0;
        ai.ai_damage = 0;
    }


    void DisablePlayerButtons()
    {
        player.reload.interactable = false;
        player.shoot.interactable = false;
        player.shield.interactable = false;
        player.bomb.interactable = false;
        player.bomb_shield.interactable = false;
        player.laser.interactable = false;
    }

    void EnablePlayerButtons()  
    {
        player.reload.interactable = true;
        player.shield.interactable = true;
        player.bomb_shield.interactable = true;
        player.UpdateButtons();
    }
}


