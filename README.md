# Project: Dodge

</br>

## 1. 개요
총알을 피해 최고점수를 획득하는 간단한 PC 게임

</br>

## 2. 제작기간 & 참여인원
- 약 20일
- 개인 프로젝트

</br>

## 3. 사용언어 & 도구
- C#
- Visual Studio
- Unity 3D(에디터 버전: 2021.3.12

</br>

## 4. 구동 플랫폼
- Windows

</br>

## 5. 주요 구현 이슈
<details>
<summary>오브젝트 풀링</summary>
<div markdown="1">

- 총알 생성기로부터 발사되는 총알들을 재사용
- 벽이나 플레이어에 부딪혔을 때 발생하는 폭발 이펙트 재사용
- 맵 상에서 랜덤 출현하는 쉴드 아이템 재사용

</div>
</details>

<details>
<summary>스크립터블 오브젝트</summary>
<div markdown="1">

- 간편하게 총알 생성기의 공격 타입을 바꿀 수 있음

</div>
</details>

<details>
<summary>General Manager를 이용한 전체 게임 관리</summary>
<div markdown="1">

- DontDestroyOnLoad() 함수를 이용하여 플레이어의 점수 초기화 및 로드
- 난이도 설정 창과 연동하여 선택한 난이도 저장

</div>
</details>

<details>
<summary>그 외...</summary>
<div markdown="1">

- 스크립터블 오브젝트로 저장된 데이터를 로드하는 총알의 경우, 특정 총알만 강화하고 싶을 땐 어떻게 해야될까...

</div>
</details>

</br>

## 6. 스크린샷
<details>
<summary>메인화면</summary>
<div markdown="1">

![Dodge_Main1](https://user-images.githubusercontent.com/76508241/212594242-ed09df1d-4881-4529-8974-8e40e25641fb.png)
- 게임 시작, 세팅, 종료 버튼으로 구성

![Dodge_Main2](https://user-images.githubusercontent.com/76508241/212594416-6f129ff0-b642-4496-a796-7ad6288bc020.png)
- Dropdown으로 구성
- 난이도는 쉬움, 보통, 어려움으로 구성
- 난이도별 점수 차등 지급

</div>
</details>

<details>
<summary>인게임</summary>
<div markdown="1">

![Dodge_Ingame1](https://user-images.githubusercontent.com/76508241/212594410-7dfcafab-09c4-4a78-af65-82c796ffa312.png)
![Dodge_Ingame2](https://user-images.githubusercontent.com/76508241/212594413-0cf150ed-4edf-428a-89c2-ceeece5cba36.png)
![Dodge_Ingame3](https://user-images.githubusercontent.com/76508241/212594415-702bf1e2-a350-4e9f-a113-4aba46285e15.png)
- 빨간색 기둥 오브젝트는 BulletSpawner로써 총알 생성 및 발사
- 파란색 구슬 오브젝트는 쉴드로써 총알 1회 방어 할 수 있으며, 중첩 획득 가능.

</div>
</details>

<details>
<summary>게임오버</summary>
<div markdown="1">

![Dodge_End1](https://user-images.githubusercontent.com/76508241/212594419-b5c9a2a7-7374-451b-88ea-d5db146be037.png)
- R키 입력을 통해 재시작(메인화면으로 넘어감)
- PlayerPrefs를 통해 점수 저장 및 최고 기록 조회

</div>
</details>
