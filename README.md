## Unity를 사용한 Android게임 개발
목표 : 세로형 레그돌을 사용한 하이퍼 캐쥬얼 퍼즐게임 제작

### BaseSystem
- Raycast\
![ra1](https://user-images.githubusercontent.com/93506849/183329773-15173325-fe04-472f-9146-bfe58d447f25.png)\
![image](https://user-images.githubusercontent.com/93506849/183329503-e06a9fae-505f-4708-ad00-37cdff711c94.png)\
-유니티에 있는 Ray구조체를 이용해 Targer의 거리를 알아낸다.\
-Target에서는 Camera에서 쏘여진 ray(마우스 위치)를 받고 rayhit이 발생하면 해당 위치로 위치를 이동해 준다. 여기서Z축 좌표(평면)가 고정인 게임을 만들꺼라 z는 자신의 위치 그대로 해주었다.




### Chracter
- Player\
![Aiming](https://user-images.githubusercontent.com/93506849/183337142-1acf49b7-0305-4c11-b8f3-136282fa57d8.JPG)\
-타겟(마우스)위치와 자신이 속한 오브젝트의 위치를 비교하여 몸체를 회전시킨다.\
-Ragdoll을 On/Off해주기 위해 넣어준다. 처음부터 바닥에 기어다니니 보기가 안좋았다.\
![유저](https://user-images.githubusercontent.com/93506849/183338249-b739a23f-a228-442e-8025-18625f4c1784.JPG)\
-해당 스크립트들은 유저 컴포넌트에 다 넣어주었다.\
![Fire](https://user-images.githubusercontent.com/93506849/183338029-43d49c38-fcf9-46ef-ac3a-ec319a84ce9f.JPG)\
![fire위치](https://user-images.githubusercontent.com/93506849/183337342-04eee02b-8bc6-4206-b83f-0c5f1a39c394.JPG)\
-조준 후 버튼을 때는 순간 총알오브젝트를 형성하게 만들었으며, 사격은 나중에 한손으로 하니 스크립트는 오른쪽 로우암에 넣어주었다.\
![KakaoTalk_20220808_130430759](https://user-images.githubusercontent.com/93506849/183338350-44217eab-44d2-4512-a9ba-4ac987bcc639.gif)




- Camera\
![CameraMove](https://user-images.githubusercontent.com/93506849/183330579-47110c61-dfa6-4f6d-9163-f5b1f4c5df63.JPG)
![KakaoTalk_20220808_120710274](https://user-images.githubusercontent.com/93506849/183330732-21193113-8b23-4f7b-a2a0-10925e879045.gif)\
-세로로 잡고하는 게임이므로 카매라 무빙에 신경을써보았는데, 마우스의 위치(후에 터치 위치)에 따라 x축에 offset을 주어 처리 하였다.캐릭터가 항상아래오도록 y축은 고정 오프셋이다.



- Weapon\
![불렛1](https://user-images.githubusercontent.com/93506849/183339015-20cd2127-40f0-4ff9-82e1-16d539e91393.JPG)\
-Bullet는 생성된순간 타겟(마우스위치)로 날아가게 만들어주었으며, 물체에 충돌 시 삭제가 되게 해주었다. Trigger과 Collision둘다 사용한 이유는 Map전체에 Rigidbody를 주어 벽에Rigidbody 컴포넌트를 주지 않았기 때문이다. 벽에서는 물리적으로 충돌이 없으므로 Trigger로써만 총알은 벽을 감지한다.


### Enemy
- Search & AI\
![AI1](https://user-images.githubusercontent.com/93506849/183344733-866f4680-3c11-462c-844b-6645124e990f.JPG)\
![Search](https://user-images.githubusercontent.com/93506849/183342959-ea7e3ca7-c76d-4bd9-ad31-2e6126d9a9b0.JPG)\
![KakaoTalk_20220808_165739069](https://user-images.githubusercontent.com/93506849/183368907-0e32c3a5-8545-4ac2-862a-f107926861e5.gif)\
-기본적으로 큰 Trigger형 충돌체 하나와 몸체를 이루는 Collision으로 구성되어 있다.\
-Trigger는 Player를 찾는 용도로 사용하며 발견하면 즉시 자신의 속도로 돌진을 하게 설정되어있다.\
-Patrol은 X축 고정 Y축고정등 원하는 설정을 할 수 있으며 코루틴을 이용해 시간에 따라 명령을 발생시키는 방식으로 사용하였다.\
-Player를 찾았는데 코루틴을 안끄는 이유는 벽을 옆으로 돌아가게 약간 비비는기능을 넣어주고 싶었기 때문이다.(저렴한AI..)


### Map
- Wall
- Trap\
![Trap](https://user-images.githubusercontent.com/93506849/183345142-85541c5d-9e5d-40f4-b1ed-649dd73f902a.JPG)
-닿으면 동작 끝

### UI
- UI Setting\
![ui사라짐](https://user-images.githubusercontent.com/93506849/183366961-91c1d4be-5268-414b-b0e2-0ebb080c1c82.JPG)\
-기종에 해상도 설정으로 UI가 잘릴 수 있는데 해당 부분을 스케일로 바꾸고 해상도를 넣어주면 비율대로 적용된다\
-Expand:해상도가 커짐에 따라 수평,수직으로 확장/ Shrink : 설정값 보다 커지면 모두 잘라냄..

