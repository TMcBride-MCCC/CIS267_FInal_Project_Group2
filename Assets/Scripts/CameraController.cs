using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] PolygonCollider2D mapBoundaryStartScene;
    [SerializeField] PolygonCollider2D mapBoundaryPath01;

    private CinemachineConfiner2D confiner;
    private CinemachineVirtualCamera virtualCamera;
    private GameObject player;
    

    private void Awake()
    {
        confiner = FindObjectOfType<CinemachineConfiner2D>();
        virtualCamera = FindAnyObjectByType<CinemachineVirtualCamera>();
        player = GameObject.FindGameObjectWithTag("Player");

        if (confiner == null )
        {
            Debug.Log("No confiner found on Awake()");
        }
        else
        {
            Debug.Log("Confiner found!");
        }

        if (virtualCamera == null)
        {
            Debug.Log("No virtual camera found on Awake()");
        }
        else
        {
            Debug.Log("Virtual camera found!");
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        updateBoundary();
        updateFollow();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        updateBoundary();
        updateFollow();
    }

    private void updateBoundary()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "StartScene")
        {
            confiner.m_BoundingShape2D = mapBoundaryStartScene;
            confiner.InvalidateCache();
            Debug.Log("Boundary updated to: " + sceneName);
            Debug.Log("BoundingShape is: " + confiner.m_BoundingShape2D);
        }
        else if (sceneName == "Path01")
        {
            confiner.m_BoundingShape2D = mapBoundaryPath01;
            confiner.InvalidateCache();
            Debug.Log("Boundary updated to: " + sceneName);
            Debug.Log("BoundingShape is: " + confiner.m_BoundingShape2D);
        }
    }

    private void updateFollow()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Debug.Log("Player found!");
            virtualCamera.Follow = player.transform;
        }
        else
        {
            Debug.Log("Player not found");
        }
    }


    /*    private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("LoadPath01"))
            {
                Debug.Log("I have collided with the path01 object");
                confiner.m_BoundingShape2D = mapBoundaryPath01;
                confiner.InvalidateCache();
            }
        }*/
}
