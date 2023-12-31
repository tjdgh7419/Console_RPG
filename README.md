# Console_RPG
콘솔로 제작된 RPG 게임

## 프로젝트 소개
장비를 장착하고 던전을 돌며 강해지는 콘솔 RPG 게임 입니다.

## 개발 기간
* 23.08.18 ~ 23.08.23

## 멤버 구성
- 강성호 - 게임 시작 화면, 상태보기, 인벤토리(정렬, 장비 장착 관리), 아이템 추가, 콘솔 꾸미기, 인벤토리 크기 맞춤, 상점(구매, 판매),
  장착 개선, 던전(쉬움, 일반, 하드 스테이지), 휴식, 레벨업, 강화

### 개발 환경
- **IDE** : Visual Studio2022

## 주요 기능

#### 게임 시작 화면(Start.cs)

게임을 시작하면 나오는 첫 화면입니다. 상태 보기, 인벤토리, 던전 입장, 휴식 하기, 강화 하기 기능을 사용할 수 있습니다.

    GameStart();

#### 상태 화면(StateStage.cs) 

플레이어의 주요 스텟을 볼 수 있는 곳입니다. 장비의 장착 유무에 따라 수치가 변합니다. LV이 오를 때 마다 플레이어의 공격력과 방어력이 오릅니다.
  
    StateOn();
  
#### 인벤토리(Inventory.cs) 

플레이어의 장비들을 관리하는 곳입니다. 장비에는 강화수치, 공격력, 방어력, 정보 값이 들어 있습니다. 정렬과 장착, 해제가 가능합니다. 공격 아이템과 방어 아이템은 중복 장착이 불가능합니다.
  
    InventoryOn(); InventoryManager();

#### 상점(StoreStage.cs) 

아이템을 구매하거나 판매하는 곳입니다. 소지 중이거나 보유 골드가 부족할 시 구매가 불가능합니다.
  
    Store(); StoreSell(); StorePurchase();
  
#### 던전(DungeonStage.cs) 

던전의 각 스테이지를 도전할 수 있는 곳입니다. 스테이지는 쉬움, 일반, 어려움으로 나눠져 있으며 보상은 각 
던전의 기준 방어력과 플레이어의 공격력에 따라 달라집니다. 던전을 성공, 실패 할 때 현재 플레이어의 체력과 보상 현황을 보여 줍니다.
  
    Dungeon(); EasyStage(); NormalStage(); HardStage(); StageClear(); StageFail();
  
#### 휴식(Rest.cs) 

플레이어가 휴식을 할 수 있는 곳입니다. 휴식하기 기능을 실행하면 플레이어 체력이 모두 차고 500 G 가 소모 됩니다.

    RestOn();
  
#### 강화(EnhanceStage.cs) 

플레이어가 현재 소지 중인 무기를 선택하여 강화할 수 있습니다. 강화는 장착 해제상태일 때 가능합니다. 강화 수치에 따라 강화 비용이 증가하고 확률은 감소합니다. 강화 수치가 3 이상이면 실패할 때 강화 수치가 감소합니다. 
  
    EnhanceOn(); Enhance();
    
#### 플레이어 정보(Character.cs)

플레이어 대한 이름과 스텟 정보들이 들어있고 체력이 0이 되면 죽는 기능이 있습니다. 플레이어가 죽게 되면 다시하기와 종료하기 버튼이 나타나고 다시하기 버튼을 누른다면 플레이어의 스텟 정보가 초기화됩니다. 하지만 아이템 정보들은 남아있습니다. 종료하기 버튼을 누르면 콘솔이 종료됩니다.

    PlayerDead();
