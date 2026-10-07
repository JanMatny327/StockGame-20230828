# 📈 Stock Game

> **주식 변동과 랜덤 이벤트를 활용해 빚을 상환하는 Unity 게임 프로젝트**

<p>
  <img src="https://img.shields.io/badge/Unity-2022.3.7f1-000000?logo=unity&logoColor=white" />
  <img src="https://img.shields.io/badge/C%23-512BD4?logo=csharp&logoColor=white" />
  <img src="https://img.shields.io/badge/Status-Portfolio%20Project-2ea44f" />
</p>

## 🎮 About

가상의 종목을 사고팔며 자산을 늘리고, 최종적으로 **5억 원의 빚을 상환하는 것**을 목표로 하는 게임입니다.  
단순 매매뿐 아니라 시간에 따라 발생하는 랜덤 이벤트가 주가에 영향을 주도록 구성했습니다.

## ✨ Features

- 📊 여러 가상 종목의 가격 및 보유 수량 관리
- 📰 랜덤 뉴스/이벤트에 따른 주가 변동
- 💰 보유 현금 및 천 단위 금액 UI 표시
- 🧾 원하는 금액만큼 빚을 직접 상환하는 시스템
- ❤️ 게임 라이프 및 Game Over 처리
- 🏁 빚 상환 완료 시 Game Clear 처리
- 🚚 배달 등 부가 콘텐츠와 튜토리얼 구성

## 🛠 Tech Stack

| Category | Technology |
| --- | --- |
| Engine | Unity 2022.3.7f1 |
| Language | C# |
| UI | TextMeshPro / Unity UI |
| Version Control | Git / GitHub |

## 📂 Main Scripts

```text
Assets/Scripts/
├─ Stock.cs              # 종목, 보유 수량, 랜덤 이벤트
├─ StockBox.cs           # 주식 UI / 가격 데이터
├─ GameManager.cs        # 빚, 라이프, Clear / Game Over
├─ Daily.cs              # 일자 진행 관련 로직
├─ Courier.cs            # 부가 콘텐츠
├─ EnemySystem.cs        # 적 시스템
├─ PlayerController.cs   # 플레이어 제어
└─ Tutorial.cs           # 튜토리얼
```

## 🚀 Run

1. Unity Hub에서 프로젝트를 추가합니다.
2. **Unity 2022.3.7f1**로 프로젝트를 엽니다.
3. 시작 Scene을 열고 Play 버튼을 실행합니다.

---

### 👨‍💻 Developer

**JanMatny327**  
게임 시스템을 직접 구현하며 Unity/C# 구조 설계와 상태 관리 경험을 쌓기 위해 제작한 프로젝트입니다.
