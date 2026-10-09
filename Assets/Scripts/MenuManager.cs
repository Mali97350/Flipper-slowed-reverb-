using System;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
  public GameObject menuGameObject;

  private void Update()
  {
    if(Input.GetKeyDown(KeyCode.Escape))
      {
      OpenCloseMenu;
      }
    void  OpenCloseMenu()
    {
      menuGameObject.SetActive(false);
      
    }
  }
}
