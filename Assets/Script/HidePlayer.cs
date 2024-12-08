using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;              
    [SerializeField] private Transform hidingSpot;           
    public float interactionRange = 2f;                     
    private bool isHidden = false;                          
    public Color gizmoColor = new Color(0, 1, 0, 0.5f);     
    public bool drawSolidGizmo = false;                     

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, hidingSpot.position);

        if (distance <= interactionRange)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                ToggleHide();
            }
        }
    }

    void ToggleHide()
    {
        if (isHidden)
        {
            player.SetActive(true);
            isHidden = false;
        }
        else
        {
            player.SetActive(false);
            isHidden = true;
        }
    }

    private void OnDrawGizmos()
    {
        if (hidingSpot != null)
        {
            Gizmos.color = gizmoColor; 
            if (drawSolidGizmo)
            {
                
                Gizmos.DrawSphere(hidingSpot.position, interactionRange);
            }
            else
            {
                
                Gizmos.DrawWireSphere(hidingSpot.position, interactionRange);
            }
        }
    }
}
