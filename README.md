## Unity를 사용한 Android게임 개발
목표 : 레그돌을 사용한 하이퍼 캐쥬얼 퍼즐게임 제작\
간단 소개 영상-> https://studio.youtube.com/video/IeHmAAoZXs8/edit

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
![Fire](https://user-images.githubusercontent.com/93506849/183338029-43d49c38-fcf9-46ef-ac3a-ec319a84ce9f.JPG)\
-사격할때 반동으로 밀려나가기 위한 스크립트 사격위치와 타겟의 위치를 받는다.
![user](https://user-images.githubusercontent.com/93506849/183376721-88954e83-b620-4787-bd4c-ff89e3c734ad.JPG)\
-해당 스크립트들은 유저 컴포넌트에 다 넣어주었다.\
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
-Player를 찾았는데 코루틴을 안끄는 이유는 벽을 옆으로 돌아가게 약간 비비는기능을 넣어주고 싶었기 때문이다.(저렴한AI..)\
![서치를최상위](https://user-images.githubusercontent.com/93506849/184577033-2dab6d25-a869-4107-8995-42ad9a02e358.JPG)\
![블랜더](https://user-images.githubusercontent.com/93506849/184589598-6d71809b-f51f-4878-9b99-196e3916f1d2.JPG)\
-Search를 최상위로 받아 몬스터 스크립트를 작성, Search의 상태를 받아와서 Animater를 사용한다.\
-애니메이터와 파라미터는 위와같이 설정을 해주었다.





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

- Monster HPBar\
![Slider유아이를통해 작성](https://user-images.githubusercontent.com/93506849/184577236-07a2c432-cead-4fbc-9773-67d0f1a08f1d.JPG)\
![HPbar](https://user-images.githubusercontent.com/93506849/184577248-477cee35-913d-41f8-b5d4-dafa3b90b13f.JPG)\
-Monster HP를 받아와서 표시, Slider 를 사용하여 만들어 보았다.\
![HPMove](https://user-images.githubusercontent.com/93506849/184577255-c3ffb7fe-851e-455f-b2d3-d0b35da3b846.JPG)\
-Offset을 이용해 머리 상단에 표시되게 만든 뒤 몬스터의 위치에 따라 움직이게 변환을 시켜준다.\
![KakaoTalk_20220815_133705741](https://user-images.githubusercontent.com/93506849/184577787-5fcc8ac6-49a4-4dd1-a6a0-5b0dd64850a8.gif)

- User Joystick\
![디자인](https://user-images.githubusercontent.com/93506849/185296211-3ae700a0-2d84-4e30-935c-ae1434394eaf.JPG)\
![조이스틱 위치](https://user-images.githubusercontent.com/93506849/185296254-ba99904a-7e4e-49d8-bee6-5d8edcb871b9.JPG)\
-일단 모양과 스크립트를 만들어준다.\
![조이스틱 선언-위치](https://user-images.githubusercontent.com/93506849/185296514-e967a4fa-c4dd-47c5-8367-1c9b1d54c9f4.JPG)\
![업데이트](https://user-images.githubusercontent.com/93506849/185296799-0990f637-080b-4349-bd48-70052c7c1665.JPG)\
-설계를 눌렀을 때 나오고 손때면 다시 꺼지게 할 생각이므로 Joystick의 게임 오브젝트가 수시로 ON/Off처리된다. 그러므로 없을경우 재 할당하게끔 처리\
-EventSystem에서 출력되는 값은 ON/Off정도 해줘야 업데이트가 가능하므로 bTouch가 되면 joystick과 연동된 타겟이 동작하게 해주었다.\
-타겟이 일정범위를 벗어나면 플레이어의 중심으로 돌아가게 해주었다.(카매라 범위지정해서 충돌일으키는 방법 보다 좋은거같아서 해주었다.)\
![불값 반환](https://user-images.githubusercontent.com/93506849/185297387-702071c6-345a-4952-9915-85c4c5f6ab16.JPG)
-EventSystem과 Stick이동 시 코드는 이렇게 짜보았다. 결국 2차원 평면게임에다가 타겟은 굳이 회전할 필요가 없기에 xy축만 해당 방향으로 움직이게 해주었다.\
-추가적으로 게임성을 위해 스틱이동시에만 총쏘자는 의견이 있어 반영해 드렸다.\
![이후판넬](https://user-images.githubusercontent.com/93506849/185297719-1d58c4e5-dc40-41f9-a17b-bfe43d017240.JPG)\
-joystick이 꺼졌다 켜졌다 하면 Eventsystem이 바로 동작하지 않기 때문에 범위용 판넬을 하나 깔아주었다.\
![결합](https://user-images.githubusercontent.com/93506849/185297956-ab0cf13b-2107-4027-a8fa-b55326694be9.JPG)\
-카메라에 결합해주고 사용자 터치에만 조이스틱이 활성화 되게 코딩해주었다.\
![KakaoTalk_20220818_142944729](https://user-images.githubusercontent.com/93506849/185301357-216a8a19-df5d-4319-a6f6-d7ee8f6c726d.gif)



