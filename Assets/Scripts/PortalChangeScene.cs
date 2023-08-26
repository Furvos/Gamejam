using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalChangeScene : MonoBehaviour
{
  [SerializeField] private string _nextSceneName;

  public void loadNextScene()
  {
    SceneManager.LoadScene(_nextSceneName);
  }
}
