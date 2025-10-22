using System;
using UnityEngine;
using UnityEngine.UI;

public class WizardUpgrade : MonoBehaviour
{
    [Header("UI")]
    public GameObject choicePanel;
    public Button healthButton;
    public Button damageButton;

    private bool playerInRange = false;
    private bool hasUsed = false;

    private Health playerHealth;
    private PlayerAttackj playerAttack;

    void Start()
    {
        choicePanel.SetActive(false);

        healthButton.onClick.AddListener(OnHealthClicked);
        damageButton.onClick.AddListener(OnDamageClicked);
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E) && !hasUsed)
        {
            choicePanel.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

            // Get both scripts from the player
            playerHealth = other.GetComponent<Health>();
            playerAttack = other.GetComponent<PlayerAttackj>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            choicePanel.SetActive(false);
        }
    }

    void OnHealthClicked()
    {
        if (playerHealth != null)
        {
            playerHealth.IncreaseMaxHealth(1); 
            Debug.Log("Wizard increased health!");
        }
        else
        {
            Debug.LogWarning("PlayerHealth script not found on player!");
        }

        EndInteraction();
    }

    void OnDamageClicked()
    {
        if (playerAttack != null)
        {
            playerAttack.IncreaseDamage(1); 
            Debug.Log("Wizard increased damage!");
        }
        else
        {
            Debug.LogWarning("PlayerAttack script not found on player!");
        }

        EndInteraction();
    }

    void EndInteraction()
    {
        choicePanel.SetActive(false);
        hasUsed = true;
    }

    internal void Interact(PlayerStats ps)
    {
        throw new NotImplementedException();
    }

    public void OpenChoicePanel()
    {
        if (!hasUsed)
        {
            choicePanel.SetActive(true);
        }
    }
}
