using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;


    public GameObject mainMenu;


	private bool isPlayerActive = false;
	private bool isGameOver = false;
    private bool isGameStarted = false;


	public bool IsGameOver {
		get { return isGameOver;}
	}

	public bool IsPlayerActive {
		get { return isPlayerActive;}
	}

    public bool IsGameStarted
    {
        get { return isGameStarted; }
    }
	/*
	 * Awake is called when the script instance is being loaded.
	 * 
	 * Awake is used to initialize any variables or game state before the game starts. 
	 * Awake is called only once during the lifetime of the script instance. Awake is called 
	 * after all objects are initialized so you can safely speak to other objects or query them using eg. 
	 * GameObject.FindWithTag. Each GameObject's Awake is called in a random order between objects. Because 
	 * of this, you should use Awake to set up references between scripts, and use Start to pass any information back and forth. 
	 * Awake is always called before any Start functions. This allows you to order initialization of scripts. 
	 * Awake can not act as a coroutine. a component or game object then its entire transform hierarchy will not be destroyed either.
	 */ 
	void Awake(){

        Assert.IsNotNull(mainMenu);

		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}


		/*
		 * Makes the object target not be destroyed automatically when loading a new scene. 
		 * 
		 * When loading a new level all objects in the scene are destroyed, then the objects in the new level are loaded. In order to 
		 * preserve an object during level loading call DontDestroyOnLoad on it. If the object is a component or 
		 * game object then its entire transform hierarchy will not be destroyed either.
		 * 
		 */ 
		DontDestroyOnLoad (gameObject);
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void PlayerStartedGame(){
		isPlayerActive = true;
	}
	public void PlayerCollided(){
		isGameOver = true;
	}
   

    public void EnterGame()
    {
        mainMenu.SetActive(false);
        isGameStarted = true;
    }


}
