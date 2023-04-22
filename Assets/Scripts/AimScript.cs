using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour
{

    private Vector3 vectorToPointToLook;
    private Vector3 mousePos;
    private float angle;

   private Camera gameCamera;

    private void Start()
    {

        gameCamera = Camera.main;
     
    }

    private void Update()
    {
           AimToMouse();

        Ray rayFromTower = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 10, Color.green);
        RaycastHit hitpoint;
        if (Physics.Raycast(rayFromTower, out hitpoint))
        {
            if (hitpoint.transform.tag == "Wall")
            {

                Vector3 fromTowerToPoint = hitpoint.point - transform.position;

                //  Debug.DrawLine(��������� ����� hitpoint.point, ����������� ??, ����  )

                Debug.DrawRay(hitpoint.point, Vector3.Reflect(fromTowerToPoint, hitpoint.normal), Color.red);


            }


        }


    }


  
    private void AimToMouse()

    {   //������� ������� ������� ���� � ����������
        mousePos = Input.mousePosition;
        // ������� ������ ����� ����� ������� � �������� ���� (� ���������� �����������) (�.� ������ �� ������ �� ������� )
        Vector3 vectorToPointToLook = mousePos - gameCamera.WorldToScreenPoint(transform.position);
       // ����� ���� ���������� ����  ����� ������������� ���� x � �����  " vectorToPointToLook  �� ����� (������� mousePos) "
        angle = (float)Math.Atan2(vectorToPointToLook.y, vectorToPointToLook.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(new Vector3(0, -angle, 0));
        
        
   

    }


}
