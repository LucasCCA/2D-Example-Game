using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractNotWorking : MonoBehaviour
{
    [SerializeField] GameObject botao;

    [SerializeField] Transform interactPoint;
    [SerializeField] float interactRange;

    [SerializeField] LayerMask interactLayers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Interaction();
    }

    void Interaction()
    {
        //bool hasInteractable;
        Collider2D[] interactables = Physics2D.OverlapCircleAll(interactPoint.position, interactRange, interactLayers);

        /*if(interactables.Length > 0)
        {
            hasInteractable = true;
        }
        else
        {
            hasInteractable = false;
        }*/

        if (Input.GetKeyDown(KeyCode.Q))
        {
            foreach(Collider2D interactable in interactables)
            {
                interactable.GetComponent<SpriteRenderer>().color = Color.green;
                botao.SetActive(false);
                this.enabled = false;
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
