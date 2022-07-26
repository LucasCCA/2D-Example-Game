using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    [SerializeField] Transform interactPoint;
    [SerializeField] float interactRange;

    [SerializeField] LayerMask interactLayers;

    void Start()
    {
        DisableButton();
    }

    // Update is called once per frame
    void Update()
    {
        Interact();
    }

    void Interact()
    {
        Collider2D interactable = Physics2D.OverlapCircle(interactPoint.position, interactRange, interactLayers);

        if (interactable != null)
        {
            //ButtonDisplay buttonDisplay = interactable.GetComponent<ButtonDisplay>();
            //buttonDisplay.ShowButton();
            Transform botao = interactable.transform.GetChild(0);
            botao.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            if (Input.GetKeyDown(KeyCode.Q))
            {
                interactable.GetComponent<SpriteRenderer>().color = Color.green;
                //buttonDisplay.HideButton();
                botao.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                interactable.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        else
        {
            DisableButton();
        }
    }

    void OnDrawGizmosSelected()
    {
        if (interactPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(interactPoint.position, interactRange);
    }

    void DisableButton()
    {
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("InteractT");
        foreach (GameObject button in buttons)
        {
            button.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
