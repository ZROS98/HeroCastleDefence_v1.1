using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    public GameObject prefabSelectedCharacter;

    public void ChangeSelectedCharacter(GameObject character)
    {
        prefabSelectedCharacter = character;
    }

    public void LoadArena()
    {
        SelectedCharacter.Prefab = prefabSelectedCharacter;
        SceneManager.LoadScene(2);
    }
}
