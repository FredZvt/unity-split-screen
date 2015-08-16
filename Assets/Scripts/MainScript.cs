using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour
{
    public PlayerController PlayerOne;
    public PlayerController PlayerTwo;
    public CameraController TopCamera;
    public CameraController BottomCamera;
    public GameObject PauseMenu;

    private bool paused = false;

    void Start()
    {
        if (PlayerOne == null)
            throw new UnityException("PlayerOne is null.");
            
        if (PlayerTwo == null)
            throw new UnityException("PlayerTwo is null.");
        
        if (TopCamera == null)
            throw new UnityException("TopCamera is null.");
        
        if (BottomCamera == null)
            throw new UnityException("BottomCamera is null.");
        
        if (PauseMenu == null)
            throw new UnityException("PauseMenu is null.");
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (paused)
            {
                paused = false;
                PauseMenu.SetActive(false);
                PlayerOne.Unpause();
                PlayerTwo.Unpause();
                TopCamera.Unpause();
                BottomCamera.Unpause();
            }
            else
            {
                paused = true;
                PauseMenu.SetActive(true);
                PlayerOne.Pause();
                PlayerTwo.Pause();
                TopCamera.Pause();
                BottomCamera.Pause();
            }
        }
    }
}
