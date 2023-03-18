using UnityEngine;

public class MoveLeft : MonoBehaviour           //bewegt das Objekt konstant nach links
{
    public float speed;
    public float startpos;

    public bool bossLevel = false;
    public GameObject bossStartpoint;
    public GameObject boss;

    private void Start() {
        startpos = transform.position.x;
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (bossLevel)
        {
            ActivateBoss();
        }
    }

    void ActivateBoss() //aktiviert den Boss und looped das Terrain
    {
        if(bossStartpoint.transform.position.x < 0)
        {
            boss.SetActive(true);
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + 20, gameObject.transform.position.y);
        }
    }
}
