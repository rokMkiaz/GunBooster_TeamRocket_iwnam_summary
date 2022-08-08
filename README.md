## Unity를 사용한 Android게임 개발\
목표 : 세로형 하이퍼 캐쥬얼 게임

### BaseSystem
- Raycast\
![ra1](https://user-images.githubusercontent.com/93506849/183329773-15173325-fe04-472f-9146-bfe58d447f25.png)\
![image](https://user-images.githubusercontent.com/93506849/183329503-e06a9fae-505f-4708-ad00-37cdff711c94.png)\
-유니티에 있는 Ray구조체를 이용해 Targer의 거리를 알아낸다.\
-Target에서는 Camera에서 쏘여진 ray(마우스 위치)를 받고 rayhit이 발생하면 해당 위치로 위치를 이동해 준다. 여기서Z축 좌표(평면)가 고정인 게임을 만들꺼라 z는 자신의 위치 그대로 해주었다.




### Chracter
- Camera\
![CameraMove](https://user-images.githubusercontent.com/93506849/183330579-47110c61-dfa6-4f6d-9163-f5b1f4c5df63.JPG)
![KakaoTalk_20220808_120710274](https://user-images.githubusercontent.com/93506849/183330732-21193113-8b23-4f7b-a2a0-10925e879045.gif)\
-세로로 잡고하는 게임이므로 카매라 무빙에 신경을써보았는데, 마우스의 위치(후에 터치 위치)에 따라 x축에 offset을 주어 처리 하였다.캐릭터가 항상아래오도록 y축은 고정 오프셋이다.

- Player

- Weapon

### Enemy
