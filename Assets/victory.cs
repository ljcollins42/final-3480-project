using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class victory : MonoBehaviour
{
   public GameObject endscreen;
   public void OnCollisionEnter(Collision collision)
   {
        if(collision.gameObject.CompareTag("Player"))
        {
            endscreen.SetActive(true);
        }
        
   }

   void PlayGame()
   {
        SceneManager.LoadSceneAsync("Main");
   }
}
