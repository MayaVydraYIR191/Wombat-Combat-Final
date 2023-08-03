using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace WombatCombat
{
    public class Timer : MonoBehaviour
    {
        public float timeStart = 180;

        public TMP_Text textTimer;
        public GameObject timerobj;
        public GameObject timezombie;

        public GameObject enemy;
        public GameObject grass;
        private bool isZombie;

        void Start()
        {
            isZombie = false;
            Playermove.lose = false;
            textTimer.text = timeStart.ToString();
            StartCoroutine(Apocalypse());
            GrowingGrass();
        }

        void Update()
        {
            timeStart -= Time.deltaTime;
            textTimer.text = Mathf.Round(timeStart).ToString();
            if (timeStart <= 0)
            {
                timerobj.SetActive(false);
                timezombie.SetActive(true);
            }

        }

        IEnumerator Apocalypse()
        {
            yield return new WaitForSeconds(timeStart);
            timeStart = 0;
            isZombie = true;
            StartCoroutine(Spawn());
        }

        IEnumerator Spawn()
        {
            while (!Playermove.lose)
            {
                Instantiate(enemy, new Vector2(Random.Range(-30f, 30f), 0.6f), Quaternion.identity);
                yield return new WaitForSeconds(3f);
            }
        }

        void GrowingGrass()
        {
            StartCoroutine(GrassSpawn());
        }

        IEnumerator GrassSpawn()
        {
            while (!isZombie && !Playermove.lose)
            {
                Instantiate(grass, new Vector2(Random.Range(-30f, 30f), 0.6f), Quaternion.identity);
                yield return new WaitForSeconds(1f);
            }
        }

    }
}
