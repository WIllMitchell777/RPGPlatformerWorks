using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private bool canInteract = false;
    private WizardUpgrade currentWizard;

    void Update()
    {

        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            currentWizard.OpenChoicePanel();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        WizardUpgrade wizard = other.GetComponent<WizardUpgrade>();

        if (wizard != null)
        {
            canInteract = true;
            currentWizard = wizard;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
       
        if (other.GetComponent<WizardUpgrade>() != null)
        {
            canInteract = false;
            currentWizard = null;
        }
    }
}
