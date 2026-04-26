using UnityEngine;

public class Cameramovement : MonoBehaviour
{
   public Transform cameraPosition;

   private void Update()
   {
    transform.position = cameraPosition.position;
   }
}