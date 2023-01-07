## Unity를 사용한 Android게임 개발
목표 : 레그돌을 사용한 하이퍼 캐쥬얼 퍼즐게임 제작\
간단 소개 영상-> https://www.youtube.com/watch?v=IeHmAAoZXs8  \
제작 기간 : 3주(개발기간)+ 1개월(SDK,추가스테이지 작업)\
담당 : 개발,레벨,맵 디자인

### BaseSystem
- Raycast\
![ra1](https://user-images.githubusercontent.com/93506849/183329773-15173325-fe04-472f-9146-bfe58d447f25.png)\
![image](https://user-images.githubusercontent.com/93506849/183329503-e06a9fae-505f-4708-ad00-37cdff711c94.png)\
-유니티에 있는 Ray구조체를 이용해 Targer의 거리를 알아낸다.\
-Target에서는 Camera에서 쏘여진 ray(마우스 위치)를 받고 rayhit이 발생하면 해당 위치로 위치를 이동해 준다. 여기서Z축 좌표(평면)가 고정인 게임을 만들꺼라 z는 자신의 위치 그대로 해주었다.
- Letter Box\
![레터박스](https://user-images.githubusercontent.com/93506849/193741567-e67b7586-1fd9-42af-9c09-eee8b70147b6.JPG)\
-모바일 환경에서 핸드폰 기종에 따라 다른 화면크기를 적용하기 위해 레터박스 기능을 활용해 주었다.\
-설정비를 벗어나면 컬링해주고 Black로 설정을 하게 해주었다.Main Camera에 셋팅해주었다.



### Chracter
- Player\
![Aiming](https://user-images.githubusercontent.com/93506849/183337142-1acf49b7-0305-4c11-b8f3-136282fa57d8.JPG)\
-타겟(마우스)위치와 자신이 속한 오브젝트의 위치를 비교하여 몸체를 회전시킨다.\
-Ragdoll을 On/Off해주기 위해 넣어준다. 처음부터 바닥에 기어다니니 보기가 안좋았다.\
![Fire](https://user-images.githubusercontent.com/93506849/183338029-43d49c38-fcf9-46ef-ac3a-ec319a84ce9f.JPG)\
-사격할때 반동으로 밀려나가기 위한 스크립트 사격위치와 타겟의 위치를 받는다.\
<font color ='red'> -보완점 : ObjectPooling을 안사용하였다.[다음 프로젝트](https://github.com/rokMkiaz/POOOO-Games-Test-retrospect)에서는 적용하였으므로 참고.</font>\
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
-Patrol은 X축 고정 Y축고정등 원하는 설정을 할 수 있으며 [코루틴](https://github.com/rokMkiaz/GunBooster_TeamRocket_iwnam_summary/blob/main/Coroutine.md) 을 이용해 시간에 따라 명령을 발생시키는 방식으로 사용하였다.\
<span style="red">-보완점 : Search를 구성할 때, 너무 비대하게 기능을 많이 넣어, Enemy자체가 되어 버렸다. Search, Patrol, Move를 각각 나누어 관리했어야 했는데, 개별적인 세팅을 끝내버리고 방치한게 잘못이다.</span>\
![서치를최상위](https://user-images.githubusercontent.com/93506849/184577033-2dab6d25-a869-4107-8995-42ad9a02e358.JPG)\
![블랜더](https://user-images.githubusercontent.com/93506849/184589598-6d71809b-f51f-4878-9b99-196e3916f1d2.JPG)\
-Search를 최상위로 받아 몬스터 스크립트를 작성, Search의 상태를 받아와서 Animater를 사용한다.\
-애니메이터와 파라미터는 위와같이 설정을 해주었다.





### Map
- Wall
- Trap\
![Trap](https://user-images.githubusercontent.com/93506849/183345142-85541c5d-9e5d-40f4-b1ed-649dd73f902a.JPG)
-닿으면 동작 끝
- LaserGate\
![controller](https://user-images.githubusercontent.com/93506849/201021922-342df9bc-9a10-463d-8be8-264fcc9a62b7.PNG)
-입력된 시간들을 기준으로 Laser들이 켜졌다 꺼졌다 설정을 시켜준다.\
![세팅](https://user-images.githubusercontent.com/93506849/201021049-3eed2e48-027a-4358-825c-ae190b7c8d3b.JPG)\
![trap setting](https://user-images.githubusercontent.com/93506849/201021612-9f1eb3ad-c0bf-420b-bc55-ca932c0fa1cd.PNG)\
-Laser개별로는 이펙트와, 위의 Trap 스크립트를 넣어준다.\
![KakaoTalk_20221110_155307209](https://user-images.githubusercontent.com/93506849/201021989-f1ad2298-a96d-45a4-b810-3e881009c632.gif)

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
![조이스틱 업데이 수정](https://user-images.githubusercontent.com/93506849/190901310-98cb5498-6625-4d27-be67-9c9bf79d5942.JPG)\
-설계를 눌렀을 때 나오고 손때면 다시 꺼지게 할 생각이므로 Joystick의 게임 오브젝트가 수시로 ON/Off처리된다. 그러므로 없을경우 재 할당하게끔 처리\
-EventSystem에서 출력되는 값은 ON/Off정도 해줘야 업데이트가 가능하므로 bTouch가 되면 joystick과 연동된 타겟이 동작하게 해주었다.\
-타겟이 일정범위를 벗어나면 플레이어의 중심으로 돌아가게 해주었다.(카매라 범위지정해서 충돌일으키는 방법 보다 좋은거같아서 해주었다.)\
![불값 반환](https://user-images.githubusercontent.com/93506849/185297387-702071c6-345a-4952-9915-85c4c5f6ab16.JPG)
-EventSystem과 Stick이동 시 코드는 이렇게 짜보았다. 결국 2차원 평면게임에다가 타겟은 굳이 회전할 필요가 없기에 xy축만 해당 방향으로 움직이게 해주었다.\
-추가적으로 게임성을 위해 스틱이동시에만 총쏘자는 의견이 있어 반영해 드렸다.\
-[InterFace사용에 관하여](https://github.com/rokMkiaz/GunBooster_TeamRocket_iwnam_summary/blob/main/Interface.md)
![이후판넬](https://user-images.githubusercontent.com/93506849/185297719-1d58c4e5-dc40-41f9-a17b-bfe43d017240.JPG)\
-joystick이 꺼졌다 켜졌다 하면 Eventsystem이 바로 동작하지 않기 때문에 범위용 판넬을 하나 깔아주었다.\
![결합](https://user-images.githubusercontent.com/93506849/185297956-ab0cf13b-2107-4027-a8fa-b55326694be9.JPG)\
-카메라에 결합해주고 사용자 터치에만 조이스틱이 활성화 되게 코딩해주었다.\
![KakaoTalk_20220818_142944729](https://user-images.githubusercontent.com/93506849/185301357-216a8a19-df5d-4319-a6f6-d7ee8f6c726d.gif)


### 추가 SDK
- Facebook SDK\
![Facebooksdk](https://user-images.githubusercontent.com/93506849/195235347-7a045518-ca80-40bf-850e-8abd93e49d16.JPG)\
https://developers.facebook.com/docs/unity/getting-started/android \
-모바일 앱 홍보 및 광고배포 용도로 설치
- Firebase SDK\
![firebase](https://user-images.githubusercontent.com/93506849/195235645-aacc57d1-3179-404a-941d-af8e0b8d5f13.JPG)\
https://firebase.google.com/docs/unity/setup?hl=ko \
-설치 및 제거, 플레이시간 등 추적을 위해 설치
- Singular SDK\
![Singular](https://user-images.githubusercontent.com/93506849/195236164-5c1111ed-5adf-419c-a51a-dda286422583.JPG)\
https://support.singular.net/hc/ko/articles/360037635452 \
-Firebase와 동일한 용도로 설치



