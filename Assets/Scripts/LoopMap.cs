using UnityEngine;

public class ScrollMap : MonoBehaviour
{
    public Transform player; // 플레이어 캐릭터의 Transform 컴포넌트
    public GameObject mapPrefab; // 맵 프리팹
    public float scrollSpeed = 5.0f; // 맵의 스크롤 속도
    public float mapWidth = 20.0f; // 맵의 가로 길이

    private Transform lastMap; // 가장 오른쪽에 있는 맵

    private void Start()
    {
        // 초기 맵 생성
        CreateNewMap(Vector3.zero);
    }

    private void Update()
    {
        // 플레이어 이동 입력 처리
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 playerMovement = new Vector3(horizontalInput, 0, 0) * scrollSpeed * Time.deltaTime;
        player.Translate(playerMovement);

        // 카메라 이동 (플레이어가 이동할 때마다)
        Camera.main.transform.Translate(playerMovement);

        // 맵 재사용 (맵의 끝에 도달하면)
        if (player.position.x > lastMap.position.x - (mapWidth / 2))
        {
            CreateNewMap(new Vector3(lastMap.position.x + mapWidth, 0, 0));
        }
    }

    private void CreateNewMap(Vector3 position)
    {
        // 새로운 맵 생성
        GameObject newMap = Instantiate(mapPrefab, position, Quaternion.identity);
        lastMap = newMap.transform;
    }
}


