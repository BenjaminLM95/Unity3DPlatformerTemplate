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
        tempBox = Instantiate(_craftableBox, this.transform.position + this.transform.forward , Quaternion.identity);
        Rigidbody tempRigidbodyBox = tempBox.GetComponent<Rigidbody>();
        tempRigidbodyBox.constraints = RigidbodyConstraints.FreezeRotation;
        interactable = tempBox.GetComponent<Interactable>();        
        interactionController.BeginInteraction(interactable);

    }

    public void craftABox() 
    {
        if (tempBox == null && interactionController.currentInteractable == null) 
        {
            createBox();
            
        }
        else 
        {
            Destroy( tempBox );
            tempBox = null; 
        }
    }   


}
