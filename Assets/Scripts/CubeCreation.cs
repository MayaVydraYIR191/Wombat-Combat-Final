using UnityEngine;

namespace WombatCombat
{
    public class CubeCreation : MonoBehaviour
    {
        [SerializeField] private GameObject cube;
        [SerializeField] private Transform player;
        [SerializeField] private GameObject cubeImage;

        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        void Update()
        {
            if (GameParameters.Instance.GrassCount == 3)
            {
                GameParameters.Instance.GrassCount -= 3;
                cubeImage.SetActive(true);
            }
        }

        public void SpawnCube()
        {
            Vector2 playerPos = new Vector2(player.position.x, player.position.y);
            Instantiate(cube, playerPos, Quaternion.identity);
            cubeImage.SetActive(false);
        }
    }
}
