using UnityEngine;

public class SaveGame
{

    //serialized
	public int curr_battery;
	public int true_battery;
	//upgrades
	public Body Body;
	public Scanner Scanner;
	public Booster Booster;
	public Probe Probe;
	public Subzero Subzero;
	public Heat Heat;
	//economy
	public int research;
	public int information;
	public int money;
	public bool landed;
	public int starsVisited;


	//may want to move these 3 to a game-manager-type script later


	public int current_sprite;

	public Planet targetPlanet;

	public Planet lastPlanet;

	public Rigidbody2D body;

	public float movementSpeed;

	public Transform fuelRing;
	public Transform scannerRing;
	public DialogManager Dialog;
	//private bool dialogFlag = false;

	public AudioManager audioManager;

	public bool menuOpen;

    public static string _gameDataFileName = "data.json";




    private static SaveGame _instance;
    public static SaveGame Instance
    {
        get
        {
            if (_instance == null)
                Load();
            return _instance;
        }

    }

    public static void Save()
    {
        FileManager.Save(_gameDataFileName, _instance);
    }

    public static void Load()
    {
        _instance = FileManager.Load<SaveGame>(_gameDataFileName);
    }

}