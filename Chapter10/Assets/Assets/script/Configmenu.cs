using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Configmenu : MonoBehaviour
{
    [SerializeField] 
    private string nama;
  public void playGame ()
  {
      UnityEngine.SceneManagement.SceneManager.LoadScene(nama);
  }
  public void QuitGame()
      {
          Application.Quit();
      }

      
}