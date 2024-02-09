using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _pausePanel;
    private CharacterController _playerController;

    private LabProject _inputs;
    private void Awake()
    {
        _playerController = _player.GetComponent<CharacterController>();
        _inputs = new LabProject();
        _inputs.Player.Pause.performed += context => PauseGame();
        _inputs.Enable();
    }

    void OnDisable()
    {
        _inputs.Disable();
    }

    public void PauseGame()
    {
        _playerController.enabled = false;
        _pausePanel.SetActive(true);
    }

    public void UnPauseGame()
    {
        _playerController.enabled = true;
        _pausePanel.SetActive(false);
    }



    
}
