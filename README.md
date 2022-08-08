## Unity를 사용한 Android게임 개발\
목표 : 세로형 하이퍼 캐쥬얼 게임

### BaseSystem
- Raycast\
![image](https://user-images.githubusercontent.com/93506849/183328107-fc9fb9a4-09e1-4d4a-ac40-a51b50ce5ba0.png)
-유니티에 있는 Ray구조체를 이용해 Targer의 거리를 알아낸다.
![image](https://user-images.githubusercontent.com/93506849/183328692-2ce80d7c-438f-4d81-85d2-64ebd239a7fd.png)
-Target에서는 Camera에서 쏘여진 ray(마우스 위치)를 받고 rayhit이 발생하면 해당 위치로 위치를 이동해 준다. 여기서Z축 좌표(평면)가 고정인 게임을 만들꺼라 z는 자신의 위치 그대로 해준다.

### Chracter
- Camera

- Player

- Weapon

### Enemy
