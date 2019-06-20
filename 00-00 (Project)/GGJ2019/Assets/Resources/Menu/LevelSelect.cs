using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{

   

    public void Level1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Level2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void Level3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void Level4()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }

    public void Level5()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
    }

    public void Level6()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 6);
    }

    public void Level7()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 7);
    }

    public void Level8()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 8);
    }

    public void Level9()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 9);
    }

    public void Level10()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 10);
    }

    public void Level11()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 11);
    }

    public void Level12()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 12);
    }

    public void Level13()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 13);
    }

    public void Level14()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 14);
    }

    public void Level15()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 15);
    }

    public void Level16()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 16);
    }


    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
