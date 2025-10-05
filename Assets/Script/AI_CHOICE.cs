using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using System.Net;
using Unity.VisualScripting;

public class Ai : MonoBehaviour
{
    public Sprite[] sprites;
    public Image aiImage;

    public int bullet = 0;
    public int round = 0;
    public int AI = -1;
    public int isShield = 0;
    public int isBShield = 0;
    public int aHealth = 3;
    public int playerBulletLastTurn = 0;
    public int islasered = 0;
    public int ai_damage = 0;

    public TextMeshProUGUI AIChoiceText;
    public Player player;


    private Dictionary<int, string> actionNames = new Dictionary<int, string>()
    {
        {0, "Reload"},
        {1, "Shoot"},
        {2, "Shield"},
        {3, "Bomb Shield"},
        {4, "Bomb"},
        {5, "Laser"}
    };
    public void Start()
    {
        aiImage.gameObject.SetActive(false);
    }
    public void PlayButton()
    {
        aiImage.gameObject.SetActive(true);
        if (round == 0)
        {
            AI = 0;
            bullet++;
            AIChoiceText.text = "Choose Reload";
            Debug.Log("First round: Forced action -> Reload (100%)");
        }
        else
        {
            Dictionary<int, float> validChoices = new Dictionary<int, float>
            {
                { 0, 0f },
                { 2, 0f }
            };

            switch (bullet)
            {
                case 0:
                    switch (player.bullet)
                    {
                        case 0:
                            validChoices[0] = 1f;
                            break;
                        case 1:
                            validChoices[0] = 0.5f;
                            validChoices[2] = 0.5f;
                            break;
                        case 2:
                            validChoices[0] = 0.5f;
                            validChoices[2] = 0.5f;
                            break;
                        case 3:
                            validChoices[0] = 0.3f;
                            validChoices[2] = 0.3f;
                            validChoices[3] = 0.3f;
                            break;
                        case 4:
                            validChoices[0] = 0.3f;
                            validChoices[2] = 0.3f;
                            validChoices[3] = 0.3f;
                            break;
                        case 5:
                            validChoices[0] = 0.3f;
                            validChoices[2] = 0.3f;
                            validChoices[3] = 0.3f;
                            break;
                    }
                    break;
                case 1:
                    switch (player.bullet)
                    {
                        case 0:
                            validChoices[0] = 0.5f;
                            validChoices[1] = 0.5f;
                            break;
                        case 1:
                            validChoices[0] = 0.3f;
                            validChoices[1] = 0.3f;
                            validChoices[2] = 0.3f;
                            break;
                        case 2:
                            validChoices[0] = 0.3f;
                            validChoices[1] = 0.3f;
                            validChoices[2] = 0.3f;
                            break;
                        case 3:
                            validChoices[0] = 0.25f;
                            validChoices[1] = 0.25f;
                            validChoices[2] = 0.25f;
                            validChoices[3] = 0.25f;
                            break;
                        case 4:
                            validChoices[0] = 0.25f;
                            validChoices[1] = 0.25f;
                            validChoices[2] = 0.25f;
                            validChoices[3] = 0.25f;
                            break;
                        case 5:
                            validChoices[0] = 0.25f;
                            validChoices[1] = 0.25f;
                            validChoices[2] = 0.25f;
                            validChoices[3] = 0.25f;
                            break;
                    }
                    break;
                case 2:
                    switch (player.bullet)
                    {
                        case 0:
                            validChoices[0] = 0.5f;
                            validChoices[1] = 0.5f;
                            break;
                        case 1:
                            validChoices[0] = 0.3f;
                            validChoices[1] = 0.3f;
                            validChoices[2] = 0.3f;
                            break;
                        case 2:
                            validChoices[0] = 0.3f;
                            validChoices[1] = 0.3f;
                            validChoices[2] = 0.3f;
                            break;
                        case 3:
                            validChoices[0] = 0.25f;
                            validChoices[1] = 0.25f;
                            validChoices[2] = 0.25f;
                            validChoices[3] = 0.25f;
                            break;
                        case 4:
                            validChoices[0] = 0.25f;
                            validChoices[1] = 0.25f;
                            validChoices[2] = 0.25f;
                            validChoices[3] = 0.25f;
                            break;
                        case 5:
                            validChoices[0] = 0.25f;
                            validChoices[1] = 0.25f;
                            validChoices[2] = 0.25f;
                            validChoices[3] = 0.25f;
                            break;
                    }
                    break;
                case 3:
                    switch (player.bullet)
                    {
                        case 0:
                            validChoices[0] = 0.3f;
                            validChoices[1] = 0.3f;
                            validChoices[4] = 0.3f;
                            break;
                        case 1:
                            validChoices[0] = 0.25f;
                            validChoices[1] = 0.25f;
                            validChoices[2] = 0.25f;
                            validChoices[4] = 0.25f;
                            break;
                        case 2:
                            validChoices[0] = 0.25f;
                            validChoices[1] = 0.25f;
                            validChoices[2] = 0.25f;
                            validChoices[4] = 0.25f;
                            break;
                        case 3:
                            validChoices[0] = 0.2f;
                            validChoices[1] = 0.2f;
                            validChoices[2] = 0.2f;
                            validChoices[3] = 0.2f;
                            validChoices[4] = 0.2f;
                            break;
                        case 4:
                            validChoices[0] = 0.2f;
                            validChoices[1] = 0.2f;
                            validChoices[2] = 0.2f;
                            validChoices[3] = 0.2f;
                            validChoices[4] = 0.2f;
                            break;
                        case 5:
                            validChoices[0] = 0.2f;
                            validChoices[1] = 0.2f;
                            validChoices[2] = 0.2f;
                            validChoices[3] = 0.2f;
                            validChoices[4] = 0.2f;
                            break;
                    }
                    break;
                case 4:
                    switch (player.bullet)
                    {
                        case 0:
                            validChoices[0] = 0.3f;
                            validChoices[1] = 0.3f;
                            validChoices[4] = 0.3f;
                            break;
                        case 1:
                            validChoices[0] = 0.25f;
                            validChoices[1] = 0.25f;
                            validChoices[2] = 0.25f;
                            validChoices[4] = 0.25f;
                            break;
                        case 2:
                            validChoices[0] = 0.25f;
                            validChoices[1] = 0.25f;
                            validChoices[2] = 0.25f;
                            validChoices[4] = 0.25f;
                            break;
                        case 3:
                            validChoices[0] = 0.2f;
                            validChoices[1] = 0.2f;
                            validChoices[2] = 0.2f;
                            validChoices[3] = 0.2f;
                            validChoices[4] = 0.2f;
                            break;
                        case 4:
                            validChoices[0] = 0.2f;
                            validChoices[1] = 0.2f;
                            validChoices[2] = 0.2f;
                            validChoices[3] = 0.2f;
                            validChoices[4] = 0.2f;
                            break;
                        case 5:
                            validChoices[0] = 0.2f;
                            validChoices[1] = 0.2f;
                            validChoices[2] = 0.2f;
                            validChoices[3] = 0.2f;
                            validChoices[4] = 0.2f;
                            break;
                    }
                    break;
                case 5:
                    switch (player.bullet)
                    {
                        case 0:
                            validChoices[0] = 0.3f;
                            validChoices[1] = 0.3f;
                            validChoices[4] = 0.3f;
                            break;
                        case 1:
                            validChoices[0] = 0.25f;
                            validChoices[1] = 0.25f;
                            validChoices[2] = 0.25f;
                            validChoices[4] = 0.25f;
                            break;
                        case 2:
                            validChoices[0] = 0.25f;
                            validChoices[1] = 0.25f;
                            validChoices[2] = 0.25f;
                            validChoices[4] = 0.25f;
                            break;
                        case 3:
                            validChoices[0] = 0.2f;
                            validChoices[1] = 0.2f;
                            validChoices[2] = 0.2f;
                            validChoices[3] = 0.2f;
                            validChoices[4] = 0.2f;
                            break;
                        case 4:
                            validChoices[0] = 0.2f;
                            validChoices[1] = 0.2f;
                            validChoices[2] = 0.2f;
                            validChoices[3] = 0.2f;
                            validChoices[4] = 0.2f;
                            break;
                        case 5:
                            validChoices[0] = 0.2f;
                            validChoices[1] = 0.2f;
                            validChoices[2] = 0.2f;
                            validChoices[3] = 0.2f;
                            validChoices[4] = 0.2f;
                            break;
                    }
                    break;
            }

            if (bullet < 1) validChoices.Remove(1);
            if (bullet < 3) validChoices.Remove(3);
            if (bullet < 5) validChoices.Remove(5);
            if (playerBulletLastTurn < 1) validChoices.Remove(2);
            if (playerBulletLastTurn < 3) validChoices.Remove(3);

            float totalPer = 0f;
            foreach (var pair in validChoices)
                totalPer += pair.Value;

            foreach (var pair in validChoices)
            {
                float normalized = pair.Value / totalPer;
                Debug.Log($"Action: {actionNames[pair.Key]}, Normalized: {normalized:P2}");
            }

            float rand = Random.Range(0f, totalPer);
            float current = 0f;

            foreach (var pair in validChoices)
            {
                current += pair.Value;
                if (rand <= current)
                {
                    AI = pair.Key;
                    break;
                }
            }

            switch (AI)
            {
                case 0:
                    bullet++;
                    aiImage.gameObject.SetActive(true);
                    AIChoiceText.text = "Choose Reload";
                    break;
                case 1:
                    bullet--;
                    AIChoiceText.text = "Choose Shoot";
                    aiImage.gameObject.SetActive(true);
                    ai_damage = 1;
                    break;
                case 2:
                    AIChoiceText.text = "Choose Shield";
                    aiImage.gameObject.SetActive(true);
                    isShield += 1;
                    break;
                case 3:
                    AIChoiceText.text = "Choose Bomb Shield";
                    isBShield += 1;
                    break;
                case 4:
                    bullet -= 3;
                    AIChoiceText.text = "Choose Bomb";
                    ai_damage = 2;
                    break;
                case 5:
                    bullet -= 5;
                    AIChoiceText.text = "Choose Laser";
                    player.isLasered -= 1;
                    break;
            }
        }

        if (AI >= 0 && AI < sprites.Length)
        {
            aiImage.gameObject.SetActive(true);
            aiImage.sprite = sprites[AI];
        }
        
        aiImage.gameObject.SetActive(true);
        round++;
    }
}

