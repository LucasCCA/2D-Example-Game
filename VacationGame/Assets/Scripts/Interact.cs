using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] Transform interactPoint;
    [SerializeField] float interactRange;

    [SerializeField] LayerMask interactLayers;

    // Update is called once per frame
    void Update()
    {
        InteractionWithoutAll();
    }

    void InteractionWithoutAll()
    {
        Collider2D interactable = Physics2D.OverlapCircle(interactPoint.position, interactRange, interactLayers);

        bool interact = interactable;
        
        if (interact == true)
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
            GameObject[] buttons = GameObject.FindGameObjectsWithTag("InteragirT");
            foreach(GameObject button in buttons)
            {
                button.GetComponent<SpriteRenderer>().enabled = false;
            }
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
}
