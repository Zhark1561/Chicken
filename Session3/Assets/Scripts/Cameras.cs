using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameras : MonoBehaviour
{
    public GameObject currentCamera;
    public GameObject startCamera;
    public GameObject minimap;
    public List<GameObject> cameras;
    public GameManager gameManager;


    void Awake()
    {
        startCamera = cameras[0];
        currentCamera = startCamera;
        
    }
    void Update()
    {
        if (gameManager.gameIsRunning)
        {
            if (!minimap.activeInHierarchy)
            {
                for (int i = 0; i < cameras.Count; i++)
                {
                    cameras[i].SetActive(false);
                }
                currentCamera.SetActive(true);
            }
            

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                ChangeCamera(true);
            }
            else if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                ChangeCamera(false);
            }
        
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (!minimap.activeInHierarchy)
                {
                    OpenMinimap(true);
                }
                else if (minimap.activeInHierarchy)
                {
                    OpenMinimap(false);
                }
            }
        }
        else
        {
            minimap.SetActive(true);
        }
    }

    void ChangeCamera(bool leftClick)
    {
        if (leftClick)
        {
            var nextCamera = GetNextCameraForwards();
            currentCamera = nextCamera;
        }
        else if (!leftClick)
        {
            var nextCamera = GetNextCameraBackwards();
            currentCamera = nextCamera;
        }
        
        SetCurrentCameraActive();
    }
    GameObject GetNextCameraForwards()
    {
        for (int i = 0; i < cameras.Count; i++)
        {
            if (currentCamera == cameras[i])
            {
                if (i == cameras.Count - 1)
                {
                    return cameras[0];
                }
                else
                {
                    return cameras[i + 1];
                }
                
            }
        }

        return currentCamera;
    }
    GameObject GetNextCameraBackwards()
    {
        for (int i = cameras.Count - 1; i >= 0; i--)
        {
            if (currentCamera == cameras[i])
            {
                if (i == 0)
                {
                    return cameras[cameras.Count - 1];
                }
                else
                {
                    return cameras[i - 1];
                }
                
            }
        }

        return currentCamera;
    }
    void SetCurrentCameraActive()
    {
        for (int i = 0; i < cameras.Count; i++)
        {
            cameras[i].SetActive(false);
        }
        currentCamera.SetActive(true);
    }
    void OpenMinimap(bool isHoldingDown)
    {
        minimap.SetActive(isHoldingDown);
    }
}
