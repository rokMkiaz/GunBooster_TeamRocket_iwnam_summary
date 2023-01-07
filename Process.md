### Process란?
![1](https://user-images.githubusercontent.com/93506849/211146531-300ef097-2bcf-46f8-aa8f-9333239a238a.png)ㅅ
- Code : 실행할 프로그램의 코드가 저장된다. CPU는 이 영역에서 명령어를 하나씩 가져와 처리한다.
- Data : 전역변수와 정적변수가 저장됩니다. 이 변수들은 프로그램이 시작될 때 할당되어 프로그램 종료 시 소멸.\
+)  BSS(Block Stated Symbol) 영역이 존재, 이 영역에는 초기화 되지 않은 전역변수가 저장된다. 초기화 된 전역변수는 Data 영역에 저장되어 비휘발성 메모리인 ROM에 저장되는데 이 부분은 비용이 많이 들어 RAM에 저장될 것과 ROM에 저장될 것을 구분하기 위해 영역을 구분해 사용해야 한다.
- Stack :  지연변수, 매개변수, 리턴값 등 잠시 사용되었다가 사라지는 데이터를 저장하는 영역입니다. 함수 호출 시 할당되고 함수 반환 시 소멸됩니다. 로드 시(컴파일 타임) 크기가 결정. new를 해서 생긴 Heap영역의 참조 값을 가지게 된다.
- Heap : 동적 데이터 영역. 메모리 주소 값에 의해서만 참조되고 사용되는 영역.new 또는 colloc, malloc 등으로 공간이 할당된다.메모리공간 할당 후 delete를 free 등으로 해당지역을 할당해제하지 않으면 프로그램 종료시까지 계속 남아 있는다.
다만 어떠한 Stack 에서도 참조하지 않는다면 이 공간에 접근하는 방법은 없다.

#### Unity에서 관리
![1](https://user-images.githubusercontent.com/93506849/211147046-7db0c1fd-db20-4b92-b878-f4de5b4815d6.png)
- Unity에서 객체의 생성과 삭제는 사진과 같이 일어나는데, new나 Destroy를 통해 오브젝트를 관리하는 것은 사실상 메모리에 부하를 많이 줄 수 밖에 없는 구조이다.

![aha](https://user-images.githubusercontent.com/93506849/211147622-cafd5ae9-3a97-4e94-be9f-d2b329b06a6f.JPG)
- 실제 유니티에서 Instantiate 와 Destroy가 가지는 부하
- new를 할 경우 힙영역에 동적할당-> stack에 참조값을 생성하는 시간이 걸리며, Destroy역시 가비지컬렉션의 문제가 있다.

![dga](https://user-images.githubusercontent.com/93506849/211147963-afafcdac-c990-4c35-9b8d-564fc339f923.JPG)
- 가비지 컬렉션이 수행될 경우 Cpu에 부하를 많이 주는데, 이럴 경우 게임에선 Frame Drop의 주 원인이 된다.
- 문제는 Destroy를 호출 할 경우 delete를 가비지 콜렉터에서 수행하기에 언제 할 지 사용자는 알 수 없다.(그렇다고 직접적으로 호출 하는 것은 메커니즘이 간단하지 않기에 [성능상 부하가 있을 수 있다](https://overit.tistory.com/entry/C-%EB%A9%94%EB%AA%A8%EB%A6%AC-%EA%B4%80%EB%A6%AC-Feat-%EA%B0%80%EB%B9%84%EC%A7%80%EC%BD%9C%EB%A0%89%ED%84%B0)고 한다.)
- 그렇기에 한번에 생성과 삭제를 반복하는 프로그램을 지향 해야한다.

참조 : [[Unity3D] Programming - 오브젝트 풀링 기법 구현하기](https://wergia.tistory.com/203)



