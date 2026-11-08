# Unity 작업 지침

- 상위 `AGENTS.md` 적용. Unity 경로는 이 폴더 기준.
- 여기서 시작한 새 대화는 Unity만 연결. 대상 선택 없이 Unity 주소부터 질문. 기존 대화의 연결 선택은 유지. 사용자 요청 우선.
- 기준은 Unity 2022.3.62f3, Built-in, Input Manager. 실제 설정·버전·패키지는 파일로 확인하고 필요한 범위만 변경.
- 배치: `Assets/Scripts/`, `Editor/`, `Prefabs/`, `Scenes/`. 테스트는 `Assets/Tests/EditMode/`, `PlayMode/`와 필요한 assembly definition 사용.
- `Library/`, `Temp/`, `Obj/`, `Logs/`, `UserSettings/`, 생성된 프로젝트 파일은 수정 금지. 로그·패키지 캐시는 읽기만.
- 에셋과 `.meta`는 함께 이동·삭제. GUID·Inspector 값·직렬화 설정 보존. 새 `.meta`는 에디터 생성 우선.
- 씬·프리팹은 에디터 수정 우선. YAML 수정 시 GUID·fileID·참조 확인. 필드 이름 변경 시 필요하면 `FormerlySerializedAs` 사용.
- Unity 2022.3 호환 C#과 기존 스타일 사용. 기본 공백 4칸, 컴포넌트 클래스명과 파일명 일치, Inspector 필드는 `[SerializeField] private` 기본.
- 참조는 초기화 때 확보. 매 프레임 검색·할당·반복 오류 로그 피하기. 이동은 시간 보정, 물리는 적절한 주기 사용.
- 이벤트·비동기 작업은 수명에 맞게 정리. Unity API는 메인 스레드에서 호출. `UnityEditor` 코드는 에디터 전용으로 분리.
- 패키지 변경 후 Unity 해석 결과와 lock 파일 확인. 불필요한 프레임워크·추상화 추가 금지.
- 컴파일 오류부터 확인하고 가능하면 Play Mode·Console 확인. 위험에 맞는 테스트만 추가.
- CLI 검증 전 실행 파일·버전·라이선스 확인. 같은 프로젝트의 에디터와 배치 동시 실행 금지.
- 테스트는 Unity Test Runner로 실행하고 XML·로그 확인. `dotnet build`만으로 검증 대체 금지. 빌드 전 플랫폼·씬·진입점 확인.
- 직접 연결하지 못한 씬·컴포넌트·Inspector 값은 구체적으로 안내.
