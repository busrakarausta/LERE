using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    [SerializeField]
    private AppleManager appleGame;
    [SerializeField]
    private RabbitController rabbitGame;
    [SerializeField]
    private OrangeManager orangeGame;
    [SerializeField]
    private TomatoBasketController tomatoGame;
    [SerializeField]
    private LampEnder lampGame;
    [SerializeField]
    private PianoEnder pianoGame;
    [SerializeField]
    private GuitarEnder guitarGame;
    [SerializeField]
    private CatEnder catGame;
    [SerializeField]
    private IceCreamEnder iceCreamGame;
    [SerializeField]
    private DuckEnder duckGame;
    [SerializeField]
    private MonkeyEnder monkeyGame;
    [SerializeField]
    private KangarooController kangarooGame;
    [SerializeField]
    private CrownController queenGame;
    [SerializeField]
    private FlowerEnder flowerGame;
    [SerializeField]
    private NutEnder nutGame;
    [SerializeField]
    private EggEnder eggGame;
    [SerializeField]
    private BalloonEnder balloonGame;
    [SerializeField]
    private UmbrellaEnder umbrellaGame;
    [SerializeField]
    private VacuumCleanerEnder vacuumCleanerGame;
    [SerializeField]
    private WatermelonManager watermelonGame;
    [SerializeField]
    private StrawController zebraGame;
    [SerializeField]
    private XylophoneEnder xylophoneGame;
    [SerializeField]
    private HamburgerEnder hamburgerGame;
    [SerializeField]
    private JellyfishEnder jellyfishGame;
    [SerializeField]
    private YogurtManager yogurtGame;
    [SerializeField]
    private CarEnder carEnder;

    void Awake()
    {
        appleGame.OnLevelEnd += OnLevelEnd;
        rabbitGame.OnLevelEnd += OnLevelEnd;
        orangeGame.OnLevelEnd += OnLevelEnd;
        tomatoGame.OnLevelEnd += OnLevelEnd;
        lampGame.OnLevelEnd += OnLevelEnd;
        pianoGame.OnLevelEnd += OnLevelEnd;
        guitarGame.OnLevelEnd += OnLevelEnd;
        catGame.OnLevelEnd += OnLevelEnd;
        iceCreamGame.OnLevelEnd += OnLevelEnd;
        duckGame.OnLevelEnd += OnLevelEnd;
        monkeyGame.OnLevelEnd += OnLevelEnd;
        kangarooGame.OnLevelEnd += OnLevelEnd;
        queenGame.OnLevelEnd += OnLevelEnd;
        flowerGame.OnLevelEnd += OnLevelEnd;
        nutGame.OnLevelEnd += OnLevelEnd;
        eggGame.OnLevelEnd += OnLevelEnd;
        balloonGame.OnLevelEnd += OnLevelEnd;
        umbrellaGame.OnLevelEnd += OnLevelEnd;
        vacuumCleanerGame.OnLevelEnd += OnLevelEnd;
        watermelonGame.OnLevelEnd += OnLevelEnd;
        zebraGame.OnLevelEnd += OnLevelEnd;
        xylophoneGame.OnLevelEnd += OnLevelEnd;
        hamburgerGame.OnLevelEnd += OnLevelEnd;
        jellyfishGame.OnLevelEnd += OnLevelEnd;
        yogurtGame.OnLevelEnd += OnLevelEnd;
        carEnder.OnLevelEnd += OnLevelEnd;



    }

    private void OnLevelEnd()
    {
        Debug.Log("LevelEnd");
    }
}
