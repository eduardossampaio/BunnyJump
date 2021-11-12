using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, IPlayerEventListenner
{
    [Header("Scenario")]
    [SerializeField] private Scenario[] scenarioPrefab;
    [SerializeField] private int scenarioSpawDelay;
    
    [Header("Player")]
    [SerializeField] private Bunny bunny;
    [SerializeField] private float deadZone;
    
    [Header("UI")]
    [SerializeField] private Text collectedItensCount;

    private GameObject currentScenario;
    
    private int totalItensCollected = 0;
    private bool hasFinishedGame;
    private int lastIndex;
    
    void Start()
    {
        currentScenario = FindObjectOfType<Scenario>().gameObject;
        StartCoroutine(SpanNewScenario());
        bunny.RegisterPlayerEventListener(this);
        hasFinishedGame = false;
        lastIndex = -1;
    }
    private void Update()
    {
        if(bunny.transform.position.x < deadZone && !hasFinishedGame)
        {
            hasFinishedGame = true;
            StartCoroutine(LoadGameOverScene());
        }
    }
    IEnumerator SpanNewScenario()
    {
        int spawIndex = 0;
        do
        {
            spawIndex = Random.Range(0, scenarioPrefab.Length);
        } while (spawIndex == lastIndex);
        lastIndex = spawIndex;
        
        Scenario scenario = scenarioPrefab[spawIndex];
       
        GameObject newScenarioGameObject = Instantiate(scenario.gameObject);
        float x = currentScenario.transform.position.x + scenario.GetSizeX();
        float y = 0;
        newScenarioGameObject.transform.position = new Vector3(x,y,0);
        currentScenario = newScenarioGameObject;

        yield return new WaitForSeconds(scenarioSpawDelay);
        StartCoroutine(SpanNewScenario());
    }

    public void OnPlayerDeath()
    {
        StopAll();
        StartCoroutine(LoadGameOverScene());
    }

    public void OnPlayerCollectItem(Collectable collectable)
    {
        totalItensCollected += collectable.Value();
        collectedItensCount.text = totalItensCollected.ToString();
    }

    IEnumerator LoadGameOverScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(Constants.SCENES.GAMEOVER_SCENE);

    }

    public void StopAll()
    {
        var scenarios = FindObjectsOfType<Scenario>();
        foreach(var scenario in scenarios)
        {
            scenario.Stop();
        }

        var paralaxBackgrounds = FindObjectsOfType<ParalaxBackground>();
        foreach (var background in paralaxBackgrounds)
        {
            background.Stop();
        }

    }
}
