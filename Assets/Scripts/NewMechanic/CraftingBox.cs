using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingBox : MonoBehaviour
{
    public GameObject _craftableBox;
    public GameObject tempBox;
    private Interactable interactable;
    private InteractionController interactionController;

    // Start is called before the first frame update
    void Start()
    {
        interactionController = GetComponent<InteractionController>();
    }

    private void createBox()
    {   
        // Here the box is created and instantiate it. I give it a rigidbody and freezing the rotation
        tempBox = Instantiate(_craftableBox, this.transform.position + this.transform.forward , Quaternion.identity);
        Rigidbody tempRigidbodyBox = tempBox.GetComponent<Rigidbody>();
        tempRigidbodyBox.constraints = RigidbodyConstraints.FreezeRotation;
        interactable = tempBox.GetComponent<Interactable>();       
        // I make the player pick the box inmediatly
        interactionController.BeginInteraction(interactable);

    }

    public void craftABox() 
    {
        // I check if there is no crafted box to be able to create one & if the player is not currently holding a pickup object
        if (tempBox == null && interactionController.currentInteractable == null) 
        {
            createBox();
            
        }
        else 
        {
            //Since only one box can exist, when the player create another one, the previous box is destroy and then become null to be able to create another one
            Destroy( tempBox );
            tempBox = null; 
        }
    }   


}
