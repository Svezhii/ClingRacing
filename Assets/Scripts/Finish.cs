using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private PauseMenu _pauseMenu;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent(out Mover player))
        {
            Time.timeScale = 0f;

            _pauseMenu.gameObject.SetActive(true);
        }
    }
}
